using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows;


namespace SkillTest
{
    public partial class SetUser : Window
    {
        private string[] childrenArray;
        public bool saveButtonPressed;
        public bool cancelButtonPressed;
        private string User;


        public SetUser(string user)
        {
            InitializeComponent();

            this.User = user;

            // Set default values
            saveButtonPressed = false;
            cancelButtonPressed = false;

            fillUpChildrenComboBox();
        }



        // Click the saveButton
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            saveButtonPressed = true;
            this.Close();
        }



        // Click the cancelButton
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            cancelButtonPressed = true;
            this.Close();
        }



        // Fill up the ChildrenComboBox with the User's children
        private async void fillUpChildrenComboBox()
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            JObject children;

            try  // If a user is already has a child
            {
                children = await databaseHandler.getResults(this.User);
            }
            catch  // If a user is not has a child yet
            {
                return;
            }

            childrenArray = new string[children.Count];

            int i = 0;
            foreach (KeyValuePair<string, JToken> child in children)
            {
                childrenArray[i] = child.Key;
                i++;
            }

            childrenComboBox.ItemsSource = childrenArray;
        }
    }
}
