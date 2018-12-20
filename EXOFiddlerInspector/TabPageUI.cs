using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;

namespace EXOFiddlerInspector
{
    public class TabPageUI : IFiddlerExtension
    {
        public void OnLoad()
        {
            // Clear out any previous values.
            //FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.UserIdentity", "");
            //FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.AnchorMailbox", "");
            //FiddlerApplication.Prefs.SetStringPref("extensions.EXOFiddlerExtension.RedirectAddress", "");

            /*
            var oPage = new TabPage("EXO TEST");
            oPage.ImageIndex = (int)Fiddler.SessionIcons.Timeline;
            var oView = new TabPageUserControl();
            oPage.Controls.Add(oView);
            oView.Dock = DockStyle.Fill;
            FiddlerApplication.UI.tabsViews.TabPages.Add(oPage);
            */

            // http://fiddler.wikidot.com/creating-a-new-tab
            TabPage oPage = new TabPage("Exchange Online Summary");
            //oPage.ImageIndex = (int)Fiddler.SessionIcons.Timeline;  // This sets the Icon image used in the tab
            oPage.ImageIndex = Enum.GetNames(typeof(SessionIcons)).Length;
            TabPageUserControl oView = new TabPageUserControl(); // TabPageUserControl is a Windows Forms UserControl class
            oView.Dock = DockStyle.Fill;
            oPage.Controls.Add(oView);
            FiddlerApplication.UI.tabsViews.TabPages.Add(oPage);


            /*
            var oPage = new TabPage("Exchange Online Summary");

            using (var stream = GetType().Assembly.GetManifestResourceStream("EXOFiddlerInspector.Properties.Resources.icon"))
            {
                if (stream != null)
                {
                FiddlerApplication.UI.imglSessionIcons.Images.Add(Image.FromStream(stream));
                oPage.ImageIndex = Enum.GetNames(typeof(SessionIcons)).Length;
                }
            }
            */

            oView.SetUserIdentityTextBoxText(FiddlerApplication.Prefs.GetStringPref("extensions.EXOFiddlerExtension.UserIdentity", "Not Found"));
            oView.SetAnchorMailboxTextBoxText(FiddlerApplication.Prefs.GetStringPref("extensions.EXOFiddlerExtension.AnchorMailbox", "Not Found"));
            //oView.SetRedirectAddressTextBoxText(FiddlerApplication.Prefs.GetStringPref(SessionRuleSet.UserIdentity);
            


        }

        public void OnBeforeUnload()
        {
            // Do nothing.
        }
    }
}
