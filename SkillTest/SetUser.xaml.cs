using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows;


namespace SkillTest
{
    public partial class SetUser : Window
    {
        public bool saveButtonPressed;
        public bool cancelButtonPressed;
        private bool exists = false;
        private string User;

        public SetUser(string child)
        {
            InitializeComponent();

            this.User = child;

            // Set default values
            saveButtonPressed = false;
            cancelButtonPressed = false;
        }



        // Click the saveButton
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.childTextBox.Text.Length == 0)  // If the textbox is empty
            {
                MessageBox.Show("Nem adott meg nevet!", "Hiányzó adat!");
                return;
            }

            DatabaseHandler databaseHandler = new DatabaseHandler();
            JObject children;

            try  // If a user is already exists
            {
                children = await databaseHandler.getResults(this.User);
            }
            catch  // If a user is not exists yet
            {
                return;
            }

            foreach (KeyValuePair<string, JToken> child in children)
            {
                string childName = child.Key;

                if (childName == this.childTextBox.Text)
                {
                    exists = true;
                }
            }

            if (!exists)  // If the child is not exists
            {
                MessageBox.Show("Ilyen nevű gyermeket még nem regisztráltak!", "Hiányzó gyermek!");
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
