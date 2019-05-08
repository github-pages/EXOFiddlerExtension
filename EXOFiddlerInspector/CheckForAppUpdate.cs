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
            using (var WebClient = new WebClient())
            {
                try
                {
                    var json = WebClient.DownloadString(Properties.Settings.Default.UpdateJsonURL);

                    var JsonData = JsonConvert.DeserializeObject<JSONTypeClass>(json);

                    Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                    // PRODUCTION.
                    if (JsonData.AppVersionAvailable.Major == appVersion.Major && JsonData.AppVersionAvailable.Minor == appVersion.Minor && JsonData.AppVersionAvailable.Build == appVersion.Build)
                    {
                        // Do nothing here, the available version and currently running version match. Ideal production scenario.
                    }
                    else
                    {
                        // Different version available found than what is currently running.
                        FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                            $"{Environment.NewLine}You should update to the latest build available." +
                            $"{Environment.NewLine}Currently using version: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}" +
                            $"{Environment.NewLine}New version available: v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}{Environment.NewLine} {Environment.NewLine}" +
                            $"Download the latest version: {Environment.NewLine}{Properties.Settings.Default.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                    }
                    
                    // BETA.
                    if (appVersion.Build.ToString().Length == 4 || appVersion.Build > 1000)
                    {
                        // Application version detected is a beta version.

                        if (JsonData.BetaVersionAvailable.Build.ToString().Length == 4 || JsonData.BetaVersionAvailable.Build > 1000)
                        {
                            // Beta testing is running.
                            if (JsonData.BetaVersionAvailable.Build > appVersion.Build)
                            {
                                // Newer Beta buld available.
                                FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                                    $"{Environment.NewLine}You should update to the newer beta build." +
                                    $"{Environment.NewLine}Currently using beta version: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}" +
                                    $"{Environment.NewLine}New beta version available: v{JsonData.BetaVersionAvailable.Major}.{JsonData.BetaVersionAvailable.Minor}.{JsonData.BetaVersionAvailable.Build}" +
                                    $"{Environment.NewLine}{Environment.NewLine}" +
                                    $"Download the latest version: {Environment.NewLine}{Properties.Settings.Default.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                            }
                            else
                            {
                                // Current Beta being used.
                                FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                                    $"{Environment.NewLine}You're using the current beta build. Thanks for the testing!{Environment.NewLine}" +
                                    $"Currently using beta build: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}{Environment.NewLine}" +
                                    $"Newest Beta build available: v{JsonData.BetaVersionAvailable.Major}.{JsonData.BetaVersionAvailable.Minor}.{JsonData.BetaVersionAvailable.Build}{Environment.NewLine}{Environment.NewLine}");
                            }
                        }
                        else
                        {
                            // Beta testing is not running.
                            FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Information{Environment.NewLine}----------------" +
                                $"{Environment.NewLine}You should update from this beta build to the latest production build." +
                                $"{Environment.NewLine}Currently using beta version: v{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}" +
                                $"{Environment.NewLine}New production version available: v{JsonData.AppVersionAvailable.Major}.{JsonData.AppVersionAvailable.Minor}.{JsonData.AppVersionAvailable.Build}" +
                                $"{Environment.NewLine}{Environment.NewLine}" +
                                $"Download the latest version: {Environment.NewLine}{Properties.Settings.Default.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void CheckForUpdate()
        {
            CheckForJsonUpdate();

            return;

            Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : CheckForUpdate begin.");

            string downloadUrl = "";
            Version newVersion = null;
            string xmlUrl = Properties.Settings.Default.UpdateURL;

            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(xmlUrl);
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "EXOFiddlerInspector")
                {
                    while (reader.Read())
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && reader.HasValue)
                            {
                                switch (elementName)
                                {
                                    case "version":
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        downloadUrl = reader.Value;
                                        break;
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            /// <remarks>
            /// Update available.
            /// </remarks>
            /// 
            if (applicationVersion.CompareTo(newVersion) < 0)
            {

                Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : Update Available.");
                //FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.MenuTitle", "Exchange Online (Update Available)");

                /// <remarks>
                /// Refresh the value of ManualCheckForUpdate and respond with feedback if needed.
                /// </remarks>

                //Boolean ManualCheckForUpdateFeedback = FiddlerApplication.Prefs.GetBoolPref("extensions.EXOFiddlerExtension.ManualCheckForUpdate", false);

                if (applicationVersion.Build >= 1000)
                {
                    FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Available{Environment.NewLine}----------------" +
                        $"{Environment.NewLine}You should update from this beta build to the latest production build." +
                        $"{Environment.NewLine}Currently using beta version: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}" +
                        $"{Environment.NewLine}New production version available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}" + 
                        $"{Environment.NewLine}{Environment.NewLine}" +
                        $"Download the latest version: {Environment.NewLine}{Properties.Settings.Default.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                }
                else
                {
                    FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Update Available{Environment.NewLine}----------------" +
                        $"{Environment.NewLine}Currently using version: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}" +
                        $"{Environment.NewLine}New version available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}{Environment.NewLine} {Environment.NewLine}" +
                        $"Download the latest version: {Environment.NewLine}{Properties.Settings.Default.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                }

                // Regardless of extension enabled or not, give the user feedback when they click the 'Check For Update' menu item if no update is available.
                if (Preferences.ManualCheckForUpdate)
                {
                    //MessageBox.Show("EXOFiddlerExtention: Update available. v" + newVersion.Major + "." + newVersion.Minor + "." + newVersion.Build + ".", "EXO Fiddler Extension");

                    string message = $"You are currently using v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}{Environment.NewLine}"+
                        $"A new version is available v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}{Environment.NewLine}" +
                        "Do you want to download the update?";

                    string caption = "O365 Fiddler Extension - Update Available";

                    /// <remarks>
                    /// Set menu title to show user there is an update available.
                    /// </remarks>

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : New Version Available. v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}");

                    //Display the MessageBox.
                    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        // Execute the installer MSI URL, which will open in the user's default browser.
                        System.Diagnostics.Process.Start(Properties.Settings.Default.InstallerURL);
                        if (Preferences.AppLoggingEnabled)
                        {
                            FiddlerApplication.Log.LogString($"O365FiddlerExtention: Version installed. v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}");
                            FiddlerApplication.Log.LogString($"O365FiddlerExtention: New Version Available. v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}");
                        }
                    }
                    // return this perference back to false, so we don't give this feedback unintentionally.
                    Preferences.ManualCheckForUpdate = false;
                    //FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.ManualCheckForUpdate", false);
                }
            }
            /// <remarks>
            /// No update available.
            /// </remarks>
            /// 
            else
            {
                Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : No update available.");
                //FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.MenuTitle", "Exchange Online");

                // Clear UpdateMessage if no update is available. More processing below if running a beta version.
                FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", "");

                if (Preferences.AppLoggingEnabled)
                {
                    FiddlerApplication.Log.LogString("O365FiddlerExtention: Latest version installed.");
                    Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : Latest version installed.");
                }

                // Tell user if they are either on a beta build.
                if (applicationVersion.Build >= 1000 && Preferences.ManualCheckForUpdate)
                {
                    MessageBox.Show($"O365FiddlerExtention: You are using a beta build. Thanks for the testing!{Environment.NewLine}" +
                        $"Currently using beta build: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}{Environment.NewLine}" +
                        $"Newest production build available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}", "O365 Fiddler Extension - Beta Version!");

                    Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : You are using a beta build. Thanks for the testing!{Environment.NewLine}" +
                        $"Currently using beta build: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}{Environment.NewLine}" +
                        $"Newest production build available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}", "O365 Fiddler Extension - Beta Version!");

                    FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Beta Build!{Environment.NewLine}-----------" +
                        $"{Environment.NewLine}Currently using beta build: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}" +
                        $"{Environment.NewLine}Newest production build available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}{Environment.NewLine}{Environment.NewLine}" +
                        $"Raise any issues at:{Environment.NewLine}{Properties.Settings.Default.InstallerURL}{Environment.NewLine}{Environment.NewLine}");
                    //FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.ManualCheckForUpdate", false);
                    Preferences.ManualCheckForUpdate = false; 
                }
                // Update the UpdateMessage if user is on beta build.
                else if (applicationVersion.Build >= 1000)
                {
                    FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UpdateMessage", $"Beta Build!{Environment.NewLine}-----------" +
                        $"{Environment.NewLine}Currently using beta build: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}" +
                        $"{Environment.NewLine}Newest production build available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}{Environment.NewLine}{Environment.NewLine}" +
                        $"Raise any issues at: {Environment.NewLine}{Properties.Settings.Default.ReportIssuesURL}{Environment.NewLine}{Environment.NewLine}");
                }
                // Tell user if they are on latest production build.
                else if (Preferences.ManualCheckForUpdate)
                {
                    MessageBox.Show("O365FiddlerExtention: You already have the latest version installed." + Environment.NewLine +
                        $"Currently using: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}{Environment.NewLine}" +
                        $"Newest available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}", "O365 Fiddler Extension");

                    Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs :You already have the latest version installed." + Environment.NewLine +
                        $"Currently using: v{applicationVersion.Major}.{applicationVersion.Minor}.{applicationVersion.Build}{Environment.NewLine}" +
                        $"Newest available: v{newVersion.Major}.{newVersion.Minor}.{newVersion.Build}", "O365 Fiddler Extension");
                    // return this perference back to false, so we don't give this feedback unintentionally.
                    //FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.ManualCheckForUpdate", false);
                    Preferences.ManualCheckForUpdate = false;
                }
            }

            /// <remarks>
            /// If DeveloperDemoMode set the menu title regardless of the availability of an update.
            /// </remarks>
            //if (Preferences.GetDeveloperMode())
            //{
            //    FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.MenuTitle", "Exchange Online (Update Available!)");
            //}
            Debug.WriteLine($"OFFICE 365 EXTENSION: {DateTime.Now}: CheckForAppUpdate.cs : CheckForUpdate done.");
        }
    }
}