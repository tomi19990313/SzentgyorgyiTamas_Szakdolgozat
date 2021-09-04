using System.Windows;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;


namespace SkillTest
{
    public partial class App : Application
    {
        private Host _host; // Manages connection to the Tobii Engine and provides all Tobii Core SDK functionality
        private WpfInteractorAgent _agent; // Controls lifetime of the interactors


        // Application starts with initializing _host, and _agent
        protected override void OnStartup(StartupEventArgs e)
        {
            _host = new Host();
            _agent = _host.InitializeWpfAgent();
        }

        // Close the coonection to the Tobii Engine before exit
        protected override void OnExit(ExitEventArgs e)
        {
            _host.DisableConnection();

            base.OnExit(e);
        }
    }
}
