using FireSharp.Response;
using System.Windows;


namespace SkillTest
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }



        // Click the backButton
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        // Click the registrationButton
        private async void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();

            SetResponse response = null;
            response = await databaseHandler.RegistrateUser(userNameBox.Text, passwordBox.Text);

            if (response != null)  // If this is a new user
            {
                MessageBox.Show("Sikeres regisztráció!");
                this.Close();
            }
        }
    }
}
