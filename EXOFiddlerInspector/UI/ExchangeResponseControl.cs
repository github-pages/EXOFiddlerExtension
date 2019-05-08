using System;
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
