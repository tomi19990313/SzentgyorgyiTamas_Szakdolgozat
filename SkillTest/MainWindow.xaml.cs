using System.Windows;
using System.Windows.Threading;

namespace SkillTest
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timer = new DispatcherTimer();  // Timer for the time periods
        private Result Result;  // Result class object for representing the correct, and the received results of the test
        public int GazeNumber { get; set; }  // Gaze number of the current test


        public MainWindow()
        {
            InitializeComponent();

            //this.Result = new Result(GazeNumber);
            this.Result = new Result(10);  // Temporary value 10
        }
    }
}
