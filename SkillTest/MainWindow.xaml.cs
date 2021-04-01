using System;
using System.Diagnostics;
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
            this.Timer.Interval = TimeSpan.FromSeconds(3); // Temporary value 3 --> from constructor parameter TODO
            this.Timer.Tick += this.TimerTicker;

            this.CurrentGazeNumber = 1;
        }


        // Click the StartButton
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.Timer.Start();
        }

        // When time period expire
        private void TimerTicker(object sender, EventArgs e)
        {
            if (this.CurrentGazeNumber.Equals(20))  // If last gaze finished, stop the timer 
            {
                this.Timer.Stop();
                DirectionLabel.Content = "Vége!";

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

            this.CurrentGazeNumber++;
        }
    }
}
