using System.Windows;


namespace SkillTest
{
    public partial class Login : Window
    {
        DatabaseHandler databaseHandler;  // DatabaseHandler object


        public Login()
        {
            InitializeComponent();
            databaseHandler = new DatabaseHandler();
        }



        // Click the loginButton
        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if ((userNameBox.Text == "") | (passwordBox.Password == ""))
            {
                MessageBox.Show("Töltsön ki minden mezőt!");
                return;
            }

            if (await databaseHandler.Login(userNameBox.Text, passwordBox.Password))  // Check the user
            {
                string user = userNameBox.Text;
                userNameBox.Clear();
                passwordBox.Clear();

                MainWindow mainWindow = new MainWindow(user);

                mainWindow.Owner = this;

                this.Hide();
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Helytelen felhasználónév, vagy jelszó!");
                return;
            }
        }



        // Click the registrationButton
        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            userNameBox.Clear();
            passwordBox.Clear();

            RegistrationWindow registrationWindow = new RegistrationWindow();

            this.Hide();
            registrationWindow.ShowDialog();
            this.Show();
        }
    }
}
