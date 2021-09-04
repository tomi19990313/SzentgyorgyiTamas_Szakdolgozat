using System.Windows;


namespace SkillTest
{
    public partial class MainWindow : Window
    {
        string User;
        public MainWindow(string user)
        {
            InitializeComponent();
            User = user;
        }



        // Click the Iranytevesztes_vizsgalat_Button
        private void Iranyteveztes_vizsgalat_Button_Click(object sender, RoutedEventArgs e)
        {
            IranytevesztesWindow iranytevesztesWindow = new IranytevesztesWindow(5, 1, User);

            // Open the IranytevesztesWindow
            this.Hide();
            iranytevesztesWindow.ShowDialog();
            this.Show();
        }



        // Sign out
        private void signOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
