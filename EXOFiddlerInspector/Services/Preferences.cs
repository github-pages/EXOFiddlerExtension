﻿using Fiddler;
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
            AppLoggingEnabled = true;
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
            get => _extensionEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.EXOFiddlerExtension.enabled", true);
            set
            {
                _extensionEnabled = value;
                FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.enabled", value);
                MenuUI.Instance.miEnabled.Text = ExtensionEnabled ? "Disable" : "Enable";
                MenuUI.Instance.ExchangeOnlineTopMenu.Text = ExtensionEnabled ? "Office 365" : "Office 365 (Disabled)";
            }
        }

        private static bool _appLoggingEnabled;
        public static bool AppLoggingEnabled
        {
            get => _appLoggingEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.EXOFiddlerExtension.AppLoggingEnabled", true);
            set
            {
                _appLoggingEnabled = value;
                FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.AppLoggingEnabled", value);
                MenuUI.Instance.miAppLoggingEnabled.Checked = AppLoggingEnabled;
            }
        }

        private static bool _highlightOutlookOWAOnlyEnabled;
        public static bool HighlightOutlookOWAOnlyEnabled
        {
            get => _highlightOutlookOWAOnlyEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.EXOFiddlerExtension.HighlightOutlookOWAOnlyEnabled", false);
            set
            {
                _highlightOutlookOWAOnlyEnabled = value;
                FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.HighlightOutlookOWAOnlyEnabled", value);
                MenuUI.Instance.miHighlightOutlookOWAOnly.Checked = HighlightOutlookOWAOnlyEnabled;
            }
        }

        private static bool _isLoadSaz;
        public static bool IsLoadSaz
        {
            get => _isLoadSaz = FiddlerApplication.Prefs.GetBoolPref("extensions.EXOFiddlerExtension.LoadSaz", false);
            set { _isLoadSaz = value; FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.LoadSaz", value); }
        }

        //private static bool _columnsAllEnabled;
        //public static bool ColumnsAllEnabled
        //{
        //    get => _columnsAllEnabled = FiddlerApplication.Prefs.GetBoolPref("extensions.EXOFiddlerExtension.enabled", _columnsAllEnabled);
        //    set { _columnsAllEnabled = value; FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.enabled", value); }
        //}

        private static Int32 _executionCount;
        public static Int32 ExecutionCount
        {
            get => _executionCount = FiddlerApplication.Prefs.GetInt32Pref("extensions.EXOFiddlerExtension.ExecutionCount", 0);
            set { _executionCount = value; FiddlerApplication.Prefs.SetInt32Pref("extensions.EXOFiddlerExtension.ExecutionCount", value); }
        }

        private static bool _ManualCheckForUpdate;

        public static bool ManualCheckForUpdate
        {
            get => _ManualCheckForUpdate = FiddlerApplication.Prefs.GetBoolPref("extensions.EXOFiddlerExtension.ManualCheckForUpdate", false);
            set { _ManualCheckForUpdate = value; FiddlerApplication.Prefs.SetBoolPref("extensions.EXOFiddlerExtension.ManualCheckForUpdate", value); }
        }

        public static string _JSONSource;
        
        public static string JSONSource
        {
            get => JSONSource = FiddlerApplication.Prefs.GetStringPref("extensions.EXOFiddlerExtension.JSONSource", "https://aka.ms/O365FiddlerExtensionUpdateUrl");
            set { _JSONSource = value; FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.JSONSource", value); }
        }

        public static string _InstallerURL;

        public static string InstallerURL
        {
            get => InstallerURL = FiddlerApplication.Prefs.GetStringPref("extensions.EXOFiddlerExtension.InstallerURL", "https://aka.ms/O365FiddlerExtensionUpdateUrl");
            set { _InstallerURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.InstallerURL", value); }
        }

        

        public static string _WikiURL;

        public static string WikiURL
        {
            get => WikiURL = FiddlerApplication.Prefs.GetStringPref("extensions.EXOFiddlerExtension.WikiURL", "https://aka.ms/O365FiddlerExtensionWiki");
            set { _WikiURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.WikiURL", value); }
        }
        
        public static string _ReportIssuesURL;

        public static string ReportIssuesURL
        {
            get => ReportIssuesURL = FiddlerApplication.Prefs.GetStringPref("extensions.EXOFiddlerExtension.ReportIssuesURL", "https://aka.ms/O365FiddlerExtensionIssues");
            set { _ReportIssuesURL = value; FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.ReportIssuesURL", value); }
        }
    }
}
