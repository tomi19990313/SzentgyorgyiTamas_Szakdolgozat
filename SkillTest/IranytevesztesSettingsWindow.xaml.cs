using System.Windows;


namespace SkillTest
{
    public partial class IranytevesztesSettingsWindow : Window
    {

        private int[] directionNumberArray;   // Directions from 5 to 15
        private int[] gazeTimeDurationArray;  // Gaze time from 1 to 5
        public bool saveButtonPressed;
        public bool cancelButtonPressed;


        public IranytevesztesSettingsWindow(int gazeNumber, int gazeTimeDuration)
        {
            InitializeComponent();

            FillUpArrays();
            FillUpComboBoxes(gazeNumber, gazeTimeDuration);

            // Set default values
            saveButtonPressed = false;
            cancelButtonPressed = false;
        }



        // Fill up the arrays what will be in the combo boxes
        private void FillUpArrays()
        {
            directionNumberArray = new int[11];
            gazeTimeDurationArray = new int[5];

            for (int i = 0; i < 11; i++)
            {
                directionNumberArray[i] = i + 5;
            }

            for (int i = 0; i < 5; i++)
            {
                gazeTimeDurationArray[i] = i + 1;
            }
        }



        // Add the array values to the combo boxes
        private void FillUpComboBoxes(int gazeNumber, int gazeTimeDuration)
        {
            directionNumberComboBox.ItemsSource = directionNumberArray;
            gazeTimeDurationComboBox.ItemsSource = gazeTimeDurationArray;

            // Display the current values
            directionNumberComboBox.SelectedItem = gazeNumber;
            gazeTimeDurationComboBox.SelectedItem = gazeTimeDuration;
        }



        // Click the saveButton
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((directionNumberComboBox.SelectedIndex == -1) | (gazeTimeDurationComboBox.SelectedIndex == -1))  // If one of the combo boxes is empty
            {
                MessageBox.Show("Valamelyik érték nincs kiválasztva!", "Hiányzó érték!");
                return;
            }

            saveButtonPressed = true;
            this.Close();
        }



        // Click the cancelButton
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            cancelButtonPressed = true;
            this.Close();
        }
    }
}
