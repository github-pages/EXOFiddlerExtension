﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;

namespace EXOFiddlerInspector.UI
{
    public partial class ExchangeResponseControl : UserControl
    {
        public static TextBox ResultsOutput { get; set; }
        public ExchangeResponseControl()
        {
            InitializeComponent();
           
            ResultsOutput = ResultsDisplay;

        }

        private void ResetPrefs()
        {
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.enabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.ColumnsEnableAll");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.DemoMode");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.DemoModeBreakScenarios");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.ElapsedTimeColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.ResponseServerColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.ExchangeTypeColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.AppLoggingEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.HighlightOutlookOWAOnlyEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.ExecutionCount");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.ManualCheckForUpdate");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.MenuTitle");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.HostIPColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerInspector.AuthColumnEnabled");

            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.enabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.ColumnsEnableAll");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.DemoMode");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.DemoModeBreakScenarios");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.ElapsedTimeColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.ResponseServerColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.ExchangeTypeColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.AppLoggingEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.HighlightOutlookOWAOnlyEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.ExecutionCount");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.ManualCheckForUpdate");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.MenuTitle");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.HostIPColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.EXOFiddlerExtension.AuthColumnEnabled");

            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.enabled");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.ColumnsEnableAll");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.DemoMode");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.DemoModeBreakScenarios");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.ElapsedTimeColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.ResponseServerColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.ExchangeTypeColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.AppLoggingEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.HighlightOutlookOWAOnlyEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.ExecutionCount");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.ManualCheckForUpdate");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.MenuTitle");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.HostIPColumnEnabled");
            FiddlerApplication.Prefs.RemovePref("extensions.O365FiddlerExtension.AuthColumnEnabled");
        }

        // Scroll to top of Inspector text control. Default is scroll to bottom.
        // Want to highlight any update info as well as general info on session change.
        private void ResultsDisplay_TextChanged(object sender, EventArgs e)
        {
            ResultsDisplay.SelectionStart = 0;
            ResultsDisplay.ScrollToCaret();
            ResultsDisplay.Refresh();
        }
    }
}
