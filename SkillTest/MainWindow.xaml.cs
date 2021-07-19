using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace SkillTest
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer Timer = new DispatcherTimer();  // Timer for the time periods
        private Result Result;  // Result class object for representing the correct, and the received results of the test
        private int CurrentGazeNumber;  // The serial number of the actual gaze


        public MainWindow()
        {
            InitializeComponent();

            this.Result = new Result(10);  // Temporary value 10 --> from constructor parameter TODO

            // Fill up the CorrectResults array, with random values from 0 to 3
            var random = new Random();
            for (int i = 0; i < this.Result.GazeNumber; i++)
            {
                this.Result.setCorrectResults(i, random.Next(4).ToString());
            }

            // Set Timer
            this.Timer.Interval = TimeSpan.FromSeconds(1); // Temporary value 3 --> from constructor parameter TODO
            this.Timer.Tick += this.TimerTicker;

            this.CurrentGazeNumber = 0;
        }


        // Click the StartButton
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.Timer.Start();
        }

        // When time period expire
        private void TimerTicker(object sender, EventArgs e)
        {
            this.CurrentGazeNumber++;

            if (this.CurrentGazeNumber.Equals(20))  // If last gaze finished, stop the timer. Temporary value 20 --> calculate from constructor parameter TODO (gazenumber * 2)
            {
                this.Timer.Stop();
                DirectionLabel.Content = "Vége!";
                this.DisplayTestResult();

                return;
            }

            if ((this.CurrentGazeNumber % 2).Equals(0))  // If it is time for looking the label
            {
                DirectionLabel.Foreground = new SolidColorBrush(Colors.Red);
                DirectionLabel.Content = "Ide nézz!";
            }
            else  // If it is time for looing the arrow
            {
                DirectionLabel.Foreground = new SolidColorBrush(Colors.Black);

                switch (this.Result.getCorrectResults(this.CurrentGazeNumber / 2))
                {
                    case "0":
                        DirectionLabel.Content = "Nézz fel!";
                        break;
                    case "1":
                        DirectionLabel.Content = "Nézz jobbra!";
                        break;
                    case "2":
                        DirectionLabel.Content = "Nézz le!";
                        break;
                    case "3":
                        DirectionLabel.Content = "Nézz balra!";
                        break;
                }
            }
        }

        // Event Handlers for arrow gaze moments
        private void TopArrow_HasGazeChanged(object sender, Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze.Equals(true))  // If looking upon
            {
                SaveGazeDatas("0");
            }
        }

        private void RightArrow_HasGazeChanged(object sender, Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze.Equals(true))  // If looking upon
            {
                SaveGazeDatas("1");
            }
        }

        private void BottomArrow_HasGazeChanged(object sender, Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze.Equals(true))  // If looking upon
            {
                SaveGazeDatas("2");
            }
        }

        private void LeftArrow_HasGazeChanged(object sender, Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze.Equals(true))  // If looking upon
            {
                SaveGazeDatas("3");
            }
        }

        // Function for save the gaze datas into the ReceivedResults array
        private void SaveGazeDatas(string direction)
        {
            // If it is time for looing the arrow, and it is the first looking at this time period
            if (((this.CurrentGazeNumber % 2).Equals(1)) && ((this.Result.getReceivedResults(this.CurrentGazeNumber / 2)) == null))
            {
                this.Result.setReceivedResults(this.CurrentGazeNumber / 2, direction);

                //MessageBox.Show((this.CurrentGazeNumber / 2).ToString() + " --> " + direction);
            }
        }

        // Function for displaying the result at the end of the test
        private void DisplayTestResult()
        {
            IranytevesztesResultWindow iranytevesztesResult = new IranytevesztesResultWindow(this.Result);

            iranytevesztesResult.ShowDialog();
        }
    }
}
