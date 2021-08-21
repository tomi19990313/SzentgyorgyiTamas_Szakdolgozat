using System.Windows;


namespace SkillTest
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }



        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
