using Fiddler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXOFiddlerInspector.Services
{
    /// <summary>
    /// Global application initializer.
    /// </summary>
    public abstract class ActivationService : IAutoTamper
    {
        /// <summary>
        /// This should be consider the main constructor for the app. It's called after the UI has loaded.
        /// </summary>
        public async void OnLoad()
        {
            MenuUI.Instance.Initialize();
            if (Preferences.ExecutionCount == 0)
            {
                await Preferences.SetDefaultPreferences();
            }

            SessionProcessor.Instance.Initialize();

            CheckForAppUpdate.Instance.CheckForJsonUpdate();
            if (0 > 1)
            {
                CheckForAppUpdate.Instance.CheckForRuleSetUpdate();
            }

            // Set LoadSazFileName to null. 
            // Will be populated by Handleloadsaz function in SessionProcessor.cs if LoadSaz event occurs.
            Preferences.LoadSazFileName = null;

            FiddlerApplication.UI.lvSessions.AddBoundColumn("Elapsed Time", 110, "X-ElapsedTime");
            FiddlerApplication.UI.lvSessions.AddBoundColumn("Session Type", 150, "X-SessionType");
            FiddlerApplication.UI.lvSessions.AddBoundColumn("Authentication", 140, "X-Authentication");
            FiddlerApplication.UI.lvSessions.AddBoundColumn("Host IP", 110, "X-HostIP");
            FiddlerApplication.UI.lvSessions.AddBoundColumn("Response Server", 130, "X-ResponseServer");
            
            // Throw a message box to alert demo mode is running.
            if (Preferences.GetDeveloperMode())
            {
                MessageBox.Show("Developer / Demo mode is running!");
            }
            else
            {
                // Call into extension telemetry service if web calls are allowed.
                if (!(Preferences.NeverWebCall))
                {
                    await TelemetryService.InitializeAsync();
                }
                else
                {
                    FiddlerApplication.Log.LogString($"O365FiddlerExtention: ActivationService - NOT calling out to telemetry service.");
                }
            }
        }

        public async void OnBeforeUnload()
        {
            if (!(Preferences.NeverWebCall))
            {
                await TelemetryService.FlushClientAsync();
            }
            else
            {
                FiddlerApplication.Log.LogString($"O365FiddlerExtention: ActivationService - NOT calling out to telemetry service.");
            }
        }

        /// <summary>
        /// Called for each HTTP/HTTPS request after it's complete.
        /// </summary>
        /// <param name="_session"></param>
        public void AutoTamperRequestAfter(Session _session) { }

        /// <summary>
        /// Called for each HTTP/HTTPS request before it's complete.
        /// </summary>
        /// <param name="_session"></param>
        public void AutoTamperRequestBefore(Session _session) { }

        /// <summary>
        /// Called for each HTTP/HTTPS response after it's complete.
        /// </summary>
        /// <param name="_session"></param>
        public void AutoTamperResponseAfter(Session _session)
        {
            if (!Preferences.ExtensionEnabled)
            {
                return;
            }

            // Only do this on loadSAZ?
            SessionProcessor.Instance.SetElapsedTime(_session);

            SessionProcessor.Instance.SetResponseServer(_session);

            SessionProcessor.Instance.SetAuthentication(_session);

            SessionProcessor.Instance.OnPeekAtResponseHeaders(_session);

            _session.RefreshUI();
        }

        /// <summary>
        /// Called for each HTTP/HTTPS response before it's complete.
        /// </summary>
        /// <param name="_session"></param>
        public void AutoTamperResponseBefore(Session _session) { }

        /// <summary>
        /// Called for each HTTP/HTTPS error response before it's complete.
        /// </summary>
        /// <param name="_session"></param>
        public void OnBeforeReturningError(Session _session) { }
    }
}
