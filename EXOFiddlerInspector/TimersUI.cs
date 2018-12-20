using Fiddler;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXOFiddlerInspector
{
    public class TimersUI : EXOBaseFiddlerInspector, IResponseInspector2
    {
        public TimersUserControl _TimersUserControl;
        private HTTPResponseHeaders responseHeaders;

        public HTTPResponseHeaders headers
        {
            get { return responseHeaders; }
            set { responseHeaders = value; }
        }


        public byte[] body
        {
            get { return rawBody; }
            set
            {
                if (bExtensionEnabled)
                {
                    SetTimersValues(this.session);
                }
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public override int GetOrder()
        {
            return 0;
        }

        /////////////////////////////
        // Add the EXO Response tab into the inspector tab.
        public override void AddToTab(TabPage o)
        {
            _TimersUserControl = new TimersUserControl();
            o.Text = "Session Timers";
            o.ToolTipText = "Session Timers";
            o.Controls.Add(_TimersUserControl);
            o.Controls[0].Dock = DockStyle.Fill;
        }

        public void SetTimersValues(Session session)
        {
            this.session = session;

            _TimersUserControl.SetClientRequestBeginDateTextBox("");
            _TimersUserControl.SetClientRequestBeginTimeTextBox("");

            _TimersUserControl.SetClientRequestEndDateTextBox("");
            _TimersUserControl.SetClientRequestEndTimeTextBox("");

            _TimersUserControl.SetOverallElapsedTextbox("");

            _TimersUserControl.SetServerGotRequestDateTextbox("");
            _TimersUserControl.SetServerGotRequestTimeTextbox("");

            _TimersUserControl.SetServerDoneResponseDateTextbox("");
            _TimersUserControl.SetServerDoneResponseTimeTextbox("");

            _TimersUserControl.SetServerThinkTimeTextbox("");

            _TimersUserControl.SetClientBeginResponseDateTextBoxText("");
            _TimersUserControl.SetClientBeginResponseTimeTextBoxText("");

            _TimersUserControl.SetClientDoneResponseDateTextBoxText("");
            _TimersUserControl.SetClientDoneResponseTimeTextBoxText("");

            _TimersUserControl.SetClientDoneResponseTransmitTimeTextBoxText("");

            /// <remarks>
            /// Client Begin and done response. -- Overall elapsed time.
            /// </remarks>

            if (this.session.Timers.ClientBeginRequest.ToString("H:mm:ss.fff") == "0:00:00.000" || this.session.Timers.ClientDoneResponse.ToString("H:mm:ss.fff") == "0:00:00.000")
            {
                _TimersUserControl.SetClientRequestBeginDateTextBox("No Data");
                _TimersUserControl.SetClientRequestBeginTimeTextBox("No Data");

                _TimersUserControl.SetClientRequestEndDateTextBox("No Data");
                _TimersUserControl.SetClientRequestEndTimeTextBox("No Data");

                _TimersUserControl.SetOverallElapsedTextbox("No Data");

            }
            else
            {
                _TimersUserControl.SetClientRequestBeginDateTextBox(this.session.Timers.ClientBeginRequest.ToString("yyyy/MM/dd"));
                _TimersUserControl.SetClientRequestBeginTimeTextBox(this.session.Timers.ClientBeginRequest.ToString("H:mm:ss.fff"));

                _TimersUserControl.SetClientRequestEndDateTextBox(this.session.Timers.ClientDoneResponse.ToString("yyyy/MM/dd"));
                _TimersUserControl.SetClientRequestEndTimeTextBox(this.session.Timers.ClientDoneResponse.ToString("H:mm:ss.fff"));

                double ClientMilliseconds = Math.Round((this.session.Timers.ClientDoneResponse - this.session.Timers.ClientBeginRequest).TotalMilliseconds);

                _TimersUserControl.SetOverallElapsedTextbox(ClientMilliseconds + "ms");
            }

            /// <remarks>
            /// Server Got and Done Response. -- Server Think Time.
            /// </remarks>
            /// 
            if (this.session.Timers.ServerGotRequest.ToString("H:mm:ss.fff") == "0:00:00.000" ||
                this.session.Timers.ServerBeginResponse.ToString("H:mm:ss.fff") == "0:00:00.000" ||
                this.session.Timers.ServerDoneResponse.ToString("H:mm:ss.fff") == "0:00:00.000")
            {
                // No data on the session to write or calculate on.
                _TimersUserControl.SetServerGotRequestDateTextbox("No Data");
                _TimersUserControl.SetServerGotRequestTimeTextbox("No Data");

                _TimersUserControl.SetServerBeginResponseDateTextbox("No Data");
                _TimersUserControl.SetServerBeginResponseTimeTextbox("No Data");

                _TimersUserControl.SetServerDoneResponseDateTextbox("No Data");
                _TimersUserControl.SetServerDoneResponseTimeTextbox("No Data");

                _TimersUserControl.SetServerThinkTimeTextbox("No Data");

                _TimersUserControl.SetTransmitTimeTextbox("No Data");
            }
            else
            {
                // Write Server data into textboxes.
                _TimersUserControl.SetServerGotRequestDateTextbox(this.session.Timers.ServerGotRequest.ToString("yyyy/MM/dd"));
                _TimersUserControl.SetServerGotRequestTimeTextbox(this.session.Timers.ServerGotRequest.ToString("H:mm:ss.fff"));

                _TimersUserControl.SetServerBeginResponseDateTextbox(this.session.Timers.ServerBeginResponse.ToString("yyyy/MM/dd"));
                _TimersUserControl.SetServerBeginResponseTimeTextbox(this.session.Timers.ServerBeginResponse.ToString("H:mm:ss.fff"));

                _TimersUserControl.SetServerDoneResponseDateTextbox(this.session.Timers.ServerDoneResponse.ToString("yyyy/MM/dd"));
                _TimersUserControl.SetServerDoneResponseTimeTextbox(this.session.Timers.ServerDoneResponse.ToString("H:mm:ss.fff"));

                double ServerMilliseconds = Math.Round((this.session.Timers.ServerBeginResponse - this.session.Timers.ServerGotRequest).TotalMilliseconds);

                _TimersUserControl.SetServerThinkTimeTextbox(ServerMilliseconds + "ms");

                _TimersUserControl.SetTransmitTimeTextbox(Math.Round((this.session.Timers.ServerDoneResponse - this.session.Timers.ServerBeginResponse).TotalMilliseconds) + "ms");
            }

            _TimersUserControl.SetClientBeginResponseDateTextBoxText(this.session.Timers.ClientBeginResponse.ToString("yyyy/MM/dd"));
            _TimersUserControl.SetClientBeginResponseTimeTextBoxText(this.session.Timers.ClientBeginResponse.ToString("H:mm:ss.fff"));

            _TimersUserControl.SetClientDoneResponseDateTextBoxText(this.session.Timers.ClientDoneResponse.ToString("yyyy/MM/dd"));
            _TimersUserControl.SetClientDoneResponseTimeTextBoxText(this.session.Timers.ClientDoneResponse.ToString("H:mm:ss.fff"));

            double ClientDoneMilliseconds = Math.Round((this.session.Timers.ClientDoneResponse - this.session.Timers.ClientBeginResponse).TotalMilliseconds);

            _TimersUserControl.SetClientDoneResponseTransmitTimeTextBoxText(ClientDoneMilliseconds + "ms");
        }
    }
}
