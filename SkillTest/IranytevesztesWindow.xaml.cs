using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;


namespace SkillTest
{
    public partial class IranytevesztesWindow : Window
    {
        private DispatcherTimer Timer;  // Timer for the time periods
        private Result Result;          // Result class object for representing the correct, and the received results of the test
        private int CurrentGazeNumber;  // The serial number of the actual gaze
        private int gazeNumber;         // Gaze repetition number
        private int gazeTimeDuration;   // Time for one gaze (mp)



        public IranytevesztesWindow(int gazeNumber, int gazeTimeDuration)
        {
            InitializeComponent();

            this.gazeNumber = gazeNumber;
            this.gazeTimeDuration = gazeTimeDuration;

            Settings();  // Setting the parameters
        }



        // Click the StartButton
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewResult(gazeNumber);  // Create a new Result object, and fill the CorrectResults array
            SetTimer(gazeTimeDuration);   // Set Timer

            this.Timer.Start();
        }



        // Click the MenuButton
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  // Close the IranytevesztesWindow
        }



        // When time period expire
        private void TimerTicker(object sender, EventArgs e)
        {
            this.CurrentGazeNumber++;

            if (this.CurrentGazeNumber.Equals(gazeNumber * 2))  // If last gaze finished, stop the timer
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
            if (e.HasGaze.Equals(true))  // If looking upon the top arrow
            {
                SaveGazeDatas("0");
            }
        }



        private void RightArrow_HasGazeChanged(object sender, Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze.Equals(true))  // If looking upon the right arrow
            {
                SaveGazeDatas("1");
            }
        }



        private void BottomArrow_HasGazeChanged(object sender, Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze.Equals(true))  // If looking upon the bottom arrow
            {
                SaveGazeDatas("2");
            }
        }



        private void LeftArrow_HasGazeChanged(object sender, Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs e)
        {
            if (e.HasGaze.Equals(true))  // If looking upon the left arrow
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
            }
        }



        // Function for displaying the result at the end of the test
        private void DisplayTestResult()
        {
            IranytevesztesResultWindow iranytevesztesResult = new IranytevesztesResultWindow(this.Result);

            iranytevesztesResult.ShowDialog();
        }



        // Create a new Result object, and fill the CorrectResults array
        private void CreateNewResult(int gazeNumber)
        {
            this.Result = new Result(gazeNumber);

            // Fill up the CorrectResults array, with random values from 0 to 3
            var random = new Random();
            for (int i = 0; i < gazeNumber; i++)
            {
                this.Result.setCorrectResults(i, random.Next(4).ToString());
            }
        }



        // Set Timer
        private void SetTimer(int gazeTimeDuration)
        {
            this.Timer = new DispatcherTimer();
            this.Timer.Interval = TimeSpan.FromSeconds(gazeTimeDuration);
            this.Timer.Tick += this.TimerTicker;

            this.CurrentGazeNumber = 0;
        }



        // Click the SettingsButton
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Settings();
        }



        // Setting the parameters
        private void Settings()
        {
            IranytevesztesSettingsWindow iranytevesztesSettingsWindow = new IranytevesztesSettingsWindow();

            iranytevesztesSettingsWindow.ShowDialog();

            if ((iranytevesztesSettingsWindow.directionNumberComboBox.SelectedIndex == -1) | (iranytevesztesSettingsWindow.gazeTimeDurationComboBox.SelectedIndex == -1))  // If the window closed
            {
                return;
            }

            if (iranytevesztesSettingsWindow.cancelButtonPressed)  // If Mégsem pressed
            {
                return;
            }

            if (iranytevesztesSettingsWindow.saveButtonPressed)    // If Mentés pressed
            {
                gazeNumber = int.Parse(iranytevesztesSettingsWindow.directionNumberComboBox.Text);
                gazeTimeDuration = int.Parse(iranytevesztesSettingsWindow.gazeTimeDurationComboBox.Text);
            }
        }
    }
}
