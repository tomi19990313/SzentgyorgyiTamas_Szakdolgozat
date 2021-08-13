using System.Windows;


namespace SkillTest
{
    public partial class IranytevesztesSettingsWindow : Window
    {

        private int[] directionNumberArray;
        private int[] gazeTimeDurationArray;
        public bool saveButtonPressed;
        public bool cancelButtonPressed;


        public IranytevesztesSettingsWindow()
        {
            InitializeComponent();

            FillUpArrays();
            FillUpComboBoxes();

            // Set default values
            saveButtonPressed = false;
            cancelButtonPressed = false;
        }



        // Fill up the arrays what will be in the combo boxes
        private void FillUpArrays()
        {
            directionNumberArray = new int[30];
            gazeTimeDurationArray = new int[5];

            for (int i = 0; i < 30; i++)
            {
                directionNumberArray[i] = i + 1;
            }

            for (int i = 0; i < 5; i++)
            {
                gazeTimeDurationArray[i] = i + 1;
            }
        }



        // Add the array values to the combo boxes
        private void FillUpComboBoxes()
        {
            directionNumberComboBox.ItemsSource = directionNumberArray;
            gazeTimeDurationComboBox.ItemsSource = gazeTimeDurationArray;
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
