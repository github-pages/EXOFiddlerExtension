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
    public partial class TimersUserControl : UserControl
    {
        public TimersUserControl()
        {
            InitializeComponent();
        }

        // Code to write to ClientRequestBeginTimeTextBox.Text value.
        internal void SetClientRequestBeginTimeTextBox(string txt)
        {
            ClientRequestBeginTimeTextBox.Text = txt;
        }

        // Code to write to ClientRequestBeginDateTextBox.Text value.
        internal void SetClientRequestBeginDateTextBox(string txt)
        {
            ClientRequestBeginDateTextBox.Text = txt;
        }

        // Code to write to ClientRequestEndTimeTextBox.Text value.
        internal void SetClientRequestEndTimeTextBox(string txt)
        {
            ClientRequestEndTimeTextBox.Text = txt;
        }

        // Code to write to ClientRequestEndDateTextBox.Text value.
        internal void SetClientRequestEndDateTextBox(string txt)
        {
            ClientRequestEndDateTextBox.Text = txt;
        }

        // Code to write to ServerGotRequestDateTextbox.Text value.
        internal void SetServerGotRequestDateTextbox(string txt)
        {
            ServerGotRequestDateTextbox.Text = txt;
        }

        // Code to write to ServerGotRequestTimeTextbox.Text value.
        internal void SetServerGotRequestTimeTextbox(string txt)
        {
            ServerGotRequestTimeTextbox.Text = txt;
        }

        // Code to write to ServerBeginResponseDateTextbox.Text value.
        internal void SetServerBeginResponseDateTextbox(string txt)
        {
            ServerBeginResponseDateTextbox.Text = txt;
        }

        // Code to write to ServerBeginResponseTimeTextbox.Text value.
        internal void SetServerBeginResponseTimeTextbox(string txt)
        {
            ServerBeginResponseTimeTextbox.Text = txt;
        }


        // Code to write to ServerDoneResponseDateTextbox.Text value.
        internal void SetServerDoneResponseDateTextbox(string txt)
        {
            ServerDoneResponseDateTextbox.Text = txt;
        }

        // Code to write to ServerDoneResponseTimeTextbox.Text value.
        internal void SetServerDoneResponseTimeTextbox(string txt)
        {
            ServerDoneResponseTimeTextbox.Text = txt;
        }

        // Code to write to ClientBeginRequestDoneResponseDurationTextbox.Text value.
        internal void SetOverallElapsedTextbox(string txt)
        {
            OverallElapsedTextbox.Text = txt;
        }

        // Code to write to ServerBeginRequestDoneResponseDurationTextbox.Text value.
        internal void SetServerThinkTimeTextbox(string txt)
        {
            ServerThinkTimeTextbox.Text = txt;
        }

        internal void SetTransmitTimeTextbox(string txt)
        {
            ServerDoneResponseTransmitTimeTextbox.Text = txt;
        }

        internal void SetClientBeginResponseDateTextBoxText(string txt)
        {
            ClientBeginResponseDateTextBox.Text = txt;
        }

        internal void SetClientBeginResponseTimeTextBoxText(string txt)
        {
            ClientBeginResponseTimeTextBox.Text = txt;
        }


        internal void SetClientDoneResponseDateTextBoxText(string txt)
        {
            ClientDoneResponseDateTextBox.Text = txt;
        }

        internal void SetClientDoneResponseTimeTextBoxText(string txt)
        {
            ClientDoneResponseTimeTextBox.Text = txt;
        }

        internal void SetClientDoneResponseTransmitTimeTextBoxText(string txt)
        {
            ClientDoneResponseTransmitTimeTextBox.Text = txt;
        }
    }
}
