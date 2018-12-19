using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXOFiddlerInspector
{
    public partial class TabPageUserControl : UserControl
    {
        public TabPageUserControl()
        {
            InitializeComponent();
        }

        internal void SetUserIdentityTextBoxText(string txt)
        {
            UserIdentityTextBox.Text = txt;
        }

        internal void SetAnchorMailboxTextBoxText(string txt)
        {
            AnchorMailboxTextBox.Text = txt;
        }

        internal void SetRedirectAddressTextBoxText(string txt)
        {
            RedirectAddressTextBox.Text = txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
