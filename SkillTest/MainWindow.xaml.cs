using System.Windows;


namespace SkillTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        // Click the Iranytevesztes_vizsgalat_Button
        private void Iranyteveztes_vizsgalat_Button_Click(object sender, RoutedEventArgs e)
        {
            IranytevesztesWindow iranytevesztesWindow = new IranytevesztesWindow();

            // Open the IranytevesztesWindow
            iranytevesztesWindow.ShowDialog();
        }
    }
}
