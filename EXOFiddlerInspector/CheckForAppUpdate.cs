using System;
using System.Windows.Forms;
using Fiddler;
using System.Xml;
using System.Net;
using System.Diagnostics;
using EXOFiddlerInspector.Services;
using Newtonsoft.Json;

namespace EXOFiddlerInspector
{
    class JSONTypeClass
    {
        public ver AppVersionAvailable { get; set; }

        public class ver
        {
            public int Major { get; set; }
            public int Minor { get; set; }
            public int Build { get; set; }

        }

        public betaver BetaVersionAvailable { get; set; }

        public class betaver
        {
            public int Major { get; set; }
            public int Minor { get; set; }
            public int Build { get; set; }
        }

        public bool BetaTestingActive { get; set; }

        public string JSONSource { get; set; }
        public string InstallerURL { get; set; }
        public string WikiURL { get; set; }
        public string ReportIssuesURL { get; set; }

    }

    class CheckForAppUpdate : ActivationService
    {
        private static CheckForAppUpdate _instance;
        public static CheckForAppUpdate Instance => _instance ?? (_instance = new CheckForAppUpdate());

        public void CheckForJsonUpdate()
        {
            FiddlerApplication.Log.LogString($"O365FiddlerExtention: Update check.");

            using (var WebClient = new WebClient())
            {
                try
                {
                    var json = WebClient.DownloadString(Preferences.JSONSource);

                    //var updatejsonfile = @"%USERPROFILE%\Documents\Fiddler2\update.json";
                    //var filePath = Environment.ExpandEnvironmentVariables(updatejsonfile);

//                    System.IO.File.WriteAllLines(updatejsonfile, json.ToString());


                    var JsonData = JsonConvert.DeserializeObject<JSONTypeClass>(json);

                    Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                    // Update application preferences if they differ from what is already stored.
                    if (JsonData.JSONSource != Preferences.JSONSource)
                    {
                        Preferences.JSONSource = JsonData.JSONSource;
                    }
                    if (JsonData.InstallerURL != Preferences.InstallerURL)
                    {
                        Preferences.InstallerURL = JsonData.InstallerURL;
                    }
                    if (JsonData.WikiURL != Preferences.WikiURL)
                    {
                        Preferences.WikiURL = JsonData.WikiURL;
                    }
                    if (Preferences.ReportIssuesURL != JsonData.ReportIssuesURL)
                    {
                        Preferences.ReportIssuesURL = JsonData.ReportIssuesURL;
                    }

                    // PRODUCTION.
                    if (JsonData.AppVersionAvailable.Major == appVersion.Major && JsonData.AppVersionAvailable.Minor == appVersion.Minor && JsonData.AppVersionAvailable.Build == appVersion.Build)
                    {
                        // Current production version installed.
                        if (Preferences.ManualCheckForUpdate)
                        {
                            MessageBox.Show($"You are using the latest available version of the extension. v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}", "Office 365 Fiddler Extension");
                            Preferences.ManualCheckForUpdate = false;
                        }
                        // Clear the update message.
                        FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage","");

                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: Latest version installed. v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}");
                    }
                    else
                    {
                        // Different version available found than what is currently running.
                        FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                            $"{Environment.NewLine}You should update to the latest version available." +
                            $"{Environment.NewLine}New version available: v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}" +
                            $"{Environment.NewLine}Currently using: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}{Environment.NewLine}{Environment.NewLine}" +
                            $"Download the latest version: {Environment.NewLine}{Preferences.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: New version available: v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}");
                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: Currently using: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}");

                        // Regardless of extension enabled or not, give the user feedback when they click the 'Check For Update' menu item if no update is available.
                        if (Preferences.ManualCheckForUpdate)
                        {
                            //MessageBox.Show("EXOFiddlerExtention: Update available. v" + newVersion.Major + "." + newVersion.Minor + "." + newVersion.Build + ".", "EXO Fiddler Extension");

                            string message = $"You are currently using v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}{Environment.NewLine}" +
                                $"A new version is available v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}{Environment.NewLine}" +
                                "Do you want to download the update?";

                            string caption = "Office 365 Fiddler Extension - Update Available";

                            /// <remarks>
                            /// Set menu title to show user there is an update available.
                            /// </remarks>

                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : New Version Available. v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}");

                            //Display the MessageBox.
                            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            if (result == DialogResult.Yes)
                            {
                                // Execute the installer MSI URL, which will open in the user's default browser.
                                System.Diagnostics.Process.Start(Preferences.InstallerURL);
                                //if (Preferences.AppLoggingEnabled)
                                //{
                                FiddlerApplication.Log.LogString($"O365FiddlerExtention: Version installed. v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}");
                                FiddlerApplication.Log.LogString($"O365FiddlerExtention: New Version Available. v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}");
                                //}
                            }
                            // return this perference back to false, so we don't give this feedback unintentionally.
                            Preferences.ManualCheckForUpdate = false;
                            //FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.ManualCheckForUpdate", false);
                        }

                    }

                    // BETA.
                    if (appVersion.Build.ToString().Length >= 4 || appVersion.Build > 1000)
                    {
                        // Application version detected is a beta version.

                        //if (JsonData.BetaVersionAvailable.Build.ToString().Length == 4 || JsonData.BetaVersionAvailable.Build > 1000)
                        //{
                            if (JsonData.BetaTestingActive.Equals(true))
                            {
                                // Beta testing is running.
                                if (JsonData.BetaVersionAvailable.Build > appVersion.Build)
                                {
                                    // Newer Beta buld available.
                                    FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                                        $"{Environment.NewLine}You should update to the newer beta build." +
                                        $"{Environment.NewLine}Currently using BETA: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}" +
                                        $"{Environment.NewLine}New BETA version available: v{JsonData.BetaVersionAvailable.Major}.{JsonData.BetaVersionAvailable.Minor}.{JsonData.BetaVersionAvailable.Build}" +
                                        $"{Environment.NewLine}{Environment.NewLine}" +
                                        $"Download the latest version: {Environment.NewLine}{Preferences.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Currently using BETA: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}");
                                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: New BETA version available: v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}");
                                }
                                else
                                {
                                    // Current Beta being used.
                                    FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                                        $"{Environment.NewLine}You're using the current beta build. Thanks for the testing!{Environment.NewLine}" +
                                        $"Currently using beta build: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}{Environment.NewLine}" +
                                        $"Newest Beta build available: v{JsonData.BetaVersionAvailable.Major}.{JsonData.BetaVersionAvailable.Minor}.{JsonData.BetaVersionAvailable.Build}{Environment.NewLine}{Environment.NewLine}");
                                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Current BETA version installed. v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}");
                                }
                            }
                            else
                            {
                                // Beta testing is NOT running.
                                FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                                    $"{Environment.NewLine}BETA testing NOT currently running." +
                                    $"{Environment.NewLine}You should update from this beta build to the latest production build" +
                                    $"{Environment.NewLine}Currently using beta version: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}" +
                                    $"{Environment.NewLine}Newest production version available: v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}" +
                                    $"{Environment.NewLine}{Environment.NewLine}" +
                                    $"Download the latest version: {Environment.NewLine}{Preferences.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                                FiddlerApplication.Log.LogString($"O365FiddlerExtention: BETA testing NOT currently running.");
                                FiddlerApplication.Log.LogString($"O365FiddlerExtention: You should update from this beta build to the latest production build.");
                                FiddlerApplication.Log.LogString($"O365FiddlerExtention: Current BETA version installed. v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}");
                                FiddlerApplication.Log.LogString($"O365FiddlerExtention: Newest production version available: v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}");
                            }
                        }

                    //}
                }
                catch (Exception ex)
                {
                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Update check exception. {ex.Message}.");
                }
            }
        }


        public void CheckForRuleSetUpdate()
        {
            // 1. Get the local json file for rules if there is one.

            string LocalJsonData = "";
            string LocalJsonDataFilePath = "";

            string WebJsonData = "";

            // If debugger is running, get the debug ruleset.
            if (Preferences.GetDeveloperMode())
            {
                try
                {
                    var updatejsonfile = @"%USERPROFILE%\Documents\Fiddler2\DebugRuleSet.json";
                    LocalJsonDataFilePath = Environment.ExpandEnvironmentVariables(updatejsonfile);

                    LocalJsonData = System.IO.File.ReadAllText(LocalJsonDataFilePath);

                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get local ruleset {LocalJsonDataFilePath}");
                }
                catch (Exception ex)
                {
                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get debug local ruleset. {ex.Message}.");
                }
                
            }
            // Otherwise this is a production session, get the regular ruleset.
            else
            {
                try
                {
                    var updatejsonfile = @"%USERPROFILE%\Documents\Fiddler2\RuleSet.json";
                    LocalJsonDataFilePath = Environment.ExpandEnvironmentVariables(updatejsonfile);

                    LocalJsonData = System.IO.File.ReadAllText(LocalJsonDataFilePath);

                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get local ruleset {LocalJsonDataFilePath}");
                }
                catch (Exception ex)
                {
                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get local ruleset. {ex.Message}.");
                }
                
            }

            // 2. Get the latest json ruleset from the web.
            using (var WebClient = new WebClient())
            {

                // If debugger is running, get the debug ruleset.
                if (Preferences.GetDeveloperMode())
                {
                    try
                    {
                        WebJsonData = WebClient.DownloadString(Preferences.DebugRulesetURL);

                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get debug web ruleset {Preferences.DebugRulesetURL}");

                    }
                    catch (Exception ex)
                    {
                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get debug web ruleset. {ex.Message}.");
                    }
                }
                // Otherwise this is a production session, get the regular ruleset.
                else
                {
                    try
                    {
                        WebJsonData = WebClient.DownloadString(Preferences.RulesetURL);

                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get web ruleset {Preferences.RulesetURL}");
                    }
                    catch (Exception ex)
                    {
                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: Get web ruleset. {ex.Message}.");
                    }
                }
                
            }

            // 3. Compare the two, if newer on the web write this to the local.

            // If the locally stored Json does not equal what is available online update the ruleset.
            if (LocalJsonData != WebJsonData)
            {
                try
                {
                    using (System.IO.StreamWriter writefile = new System.IO.StreamWriter(LocalJsonDataFilePath))
                    {
                        writefile.Write(WebJsonData);

                        FiddlerApplication.Log.LogString($"O365FiddlerExtention: Write web ruleset to local json file {LocalJsonDataFilePath}.");
                    }
                }
                catch (Exception ex)
                {
                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: Write web ruleset to local json file. {ex.Message}.");
                }
                
            }

            

        }

    }
}