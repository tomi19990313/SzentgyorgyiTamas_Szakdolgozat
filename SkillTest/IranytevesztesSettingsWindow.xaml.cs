using System.Windows;


namespace SkillTest
{
    public partial class IranytevesztesSettingsWindow : Window
    {

        private int[] directionNumberArray;
        private int[] gazeTimeDurationArray;


        public IranytevesztesSettingsWindow()
        {
            InitializeComponent();

            FillUpArrays();
            FillUpComboBoxes();
        }



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


        private void FillUpComboBoxes()
        {
            directionNumberComboBox.ItemsSource = directionNumberArray;
            gazeTimeDurationComboBox.ItemsSource = gazeTimeDurationArray;
        }

    }
}
