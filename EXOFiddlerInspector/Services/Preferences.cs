using Fiddler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EXOFiddlerInspector.Services
{
    public static class Preferences
    {
        public static void Initialize()
        {
        }

        /// <summary>
        /// Return DeveloperDemoMode value.
        /// </summary>
        /// <returns>DeveloperDemoMode</returns>
        public static bool GetDeveloperMode()
        {
            return Debugger.IsAttached;
        }

        /// <summary>
        /// This is the low water mark for what is considered a slow running session, considering a number of factors.
        /// Exchange response times are typically going to be much quicker than this. In the < 300ms range.
        /// </summary>
        public static int GetSlowRunningSessionThreshold()
        {
            return 5000;
        }


        public static Task<bool> SetDefaultPreferences()
        {
            ExtensionEnabled = true;
            //AppLoggingEnabled = true;
            HighlightOutlookOWAOnlyEnabled = true;
            IsLoadSaz = false;
            //ColumnsAllEnabled = true;

            ExecutionCount++;

            return Task.FromResult(true);
        }


        public static string AppVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fileVersionInfo.FileVersion;
            }
        }

        private static bool _extensionEnabled;
        public static bool ExtensionEnabled
        {
            get => _extensionEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.enabled", true);
            set
            {
                _extensionEnabled = value;
                FiddlerApplication.Prefs.SetBoolPref("extensions.O365FiddlerExtension.enabled", value);
                MenuUI.Instance.miEnabled.Text = ExtensionEnabled ? "Disable" : "Enable";
                MenuUI.Instance.ExchangeOnlineTopMenu.Text = ExtensionEnabled ? "Office 365" : "Office 365 (Disabled)";
            }
        }

        /*
        private static bool _appLoggingEnabled;
        public static bool AppLoggingEnabled
        {
            get => _appLoggingEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.AppLoggingEnabled", true);
            set
            {
                _appLoggingEnabled = value;
                FiddlerApplication.Prefs.SetBoolPref("extensions.O365FiddlerExtension.AppLoggingEnabled", value);
                MenuUI.Instance.miAppLoggingEnabled.Checked = AppLoggingEnabled;
            }
        }
        */

        private static bool _highlightOutlookOWAOnlyEnabled;
        public static bool HighlightOutlookOWAOnlyEnabled
        {
            get => _highlightOutlookOWAOnlyEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.HighlightOutlookOWAOnlyEnabled", false);
            set
            {
                _highlightOutlookOWAOnlyEnabled = value;
                FiddlerApplication.Prefs.SetBoolPref("extensions.O365FiddlerExtension.HighlightOutlookOWAOnlyEnabled", value);
                MenuUI.Instance.miHighlightOutlookOWAOnly.Checked = HighlightOutlookOWAOnlyEnabled;
            }
        }

        private static bool _isLoadSaz;
        public static bool IsLoadSaz
        {
            get => _isLoadSaz = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.LoadSaz", false);
            set { _isLoadSaz = value; FiddlerApplication.Prefs.SetBoolPref("extensions.O365FiddlerExtension.LoadSaz", value); }
        }

        private static string _LoadSazFileName;

        public static string LoadSazFileName
        {
            get => _LoadSazFileName = FiddlerApplication.Prefs.GetStringPref("extensions.O365FiddlerExtension.LoadSazFileName", "");
            set { _LoadSazFileName = value; FiddlerApplication.Prefs.SetStringPref("extensions.O365FiddlerExtension.LoadSazFileName", value); }
        }

        //private static bool _columnsAllEnabled;
        //public static bool ColumnsAllEnabled
        //{
        //    get => _columnsAllEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.enabled", _columnsAllEnabled);
        //    set { _columnsAllEnabled = value; FiddlerApplication.Prefs.SetBoolPref("extensions.O365FiddlerExtension.enabled", value); }
        //}

        private static Int32 _executionCount;
        public static Int32 ExecutionCount
        {
            get => _executionCount = FiddlerApplication.Prefs.GetInt32Pref("extensions.O365FiddlerExtension.ExecutionCount", 0);
            set { _executionCount = value; FiddlerApplication.Prefs.SetInt32Pref("extensions.O365FiddlerExtension.ExecutionCount", value); }
        }

        private static bool _ManualCheckForUpdate;

        public static bool ManualCheckForUpdate
        {
            get => _ManualCheckForUpdate = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.ManualCheckForUpdate", false);
            set { _ManualCheckForUpdate = value; FiddlerApplication.Prefs.SetBoolPref("extensions.O365FiddlerExtension.ManualCheckForUpdate", value); }
        }

        public static string _JSONSource;

        public static string JSONSource
        {
            get => JSONSource = FiddlerApplication.Prefs.GetStringPref("extensions.O365FiddlerExtension.JSONSource", "https://aka.ms/O365FiddlerExtensionUpdateJson");
            set { _JSONSource = value; FiddlerApplication.Prefs.SetStringPref("extensions.O365FiddlerExtension.JSONSource", value); }
        }

        public static string _InstallerURL;

        public static string InstallerURL
        {
            get => InstallerURL = FiddlerApplication.Prefs.GetStringPref("extensions.O365FiddlerExtension.InstallerURL", "https://aka.ms/O365FiddlerExtensionUpdateUrl");
            set { _InstallerURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.O365FiddlerExtension.InstallerURL", value); }
        }

        public static string _WikiURL;

        public static string WikiURL
        {
            get => WikiURL = FiddlerApplication.Prefs.GetStringPref("extensions.O365FiddlerExtension.WikiURL", "https://aka.ms/O365FiddlerExtensionWiki");
            set { _WikiURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.O365FiddlerExtension.WikiURL", value); }
        }

        public static string _ReportIssuesURL;

        public static string ReportIssuesURL
        {
            get => ReportIssuesURL = FiddlerApplication.Prefs.GetStringPref("extensions.O365FiddlerExtension.ReportIssuesURL", "https://aka.ms/O365FiddlerExtensionIssues");
            set { _ReportIssuesURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.O365FiddlerExtension.ReportIssuesURL", value); }
        }

        public static string _RulesetURL;

        public static string RulesetURL
        {
            get => RulesetURL = FiddlerApplication.Prefs.GetStringPref("extensions.O365FiddlerExtension.RulesetURL", "https://aka.ms/O365FiddlerExtensionRulesetURL");
            set { _RulesetURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.O365FiddlerExtension.RulesetURL", value); }
        }

        public static string _DebugRulesetURL;

        public static string DebugRulesetURL
        {
            get => DebugRulesetURL = FiddlerApplication.Prefs.GetStringPref("extensions.O365FiddlerExtension.DebugRulesetURL", "https://aka.ms/O365FiddlerExtensionDebugRulesetURL");
            set { _DebugRulesetURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.O365FiddlerExtension.DebugRulesetURL", value); }
        }

        public static bool _FiddlerAttached;

        public static bool FiddlerAttached
        {
            get => FiddlerAttached = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.FiddlerAttached", false);
            set { _FiddlerAttached = value; FiddlerApplication.Prefs.SetBoolPref("extensions.O365FiddlerExtension.FiddlerAttached", value); }
        }

        public static bool _NeverWebCall;

        public static bool NeverWebCall
        {
            get => NeverWebCall = FiddlerApplication.Prefs.GetBoolPref("extensions.O365FiddlerExtension.NeverWebCall", false);
            set { 
                // No nothing, honor the setting if set by user.
            }
        }
    }
}
