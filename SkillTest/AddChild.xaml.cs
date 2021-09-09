using System.Windows;


namespace SkillTest
{
    public partial class AddChild : Window
    {
        public bool saveButtonPressed;
        public bool cancelButtonPressed;

        public AddChild()
        {
            InitializeComponent();

            // Set default values
            saveButtonPressed = false;
            cancelButtonPressed = false;
        }



        // Click the saveButton
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.childNameTextBox.Text.Length == 0) || (this.childIDTextBox.Text.Length == 0)) // If a textbox is empty
            {
                MessageBox.Show("Nem adott meg minden adatot!", "Hiányzó adat!");
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
