using FireSharp.Response;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace SkillTest
{
    public partial class NewChild : Window
    {
        DatabaseHandler databaseHandler = new DatabaseHandler();
        string User;

        public NewChild(string user)
        {
            InitializeComponent();

            User = user;
            getResults();
        }



        // Get and display the children of a current user
        private async void getResults()
        {
            JObject children;

            try  // If a result is already exists
            {
                children = await databaseHandler.getResults(User);
            }
            catch  // If a result is not exists yet
            {
                return;
            }

            foreach (KeyValuePair<string, JToken> child in children)
            {
                string ID;
                string childName = child.Key;
                JToken testTypes = child.Value;

                Label childNameLabel = new Label();
                childNameLabel.FontSize = 20;
                childNameLabel.Margin = new Thickness(0, 30, 0, 0);
                childNameLabel.Content = childName;

                foreach (KeyValuePair<string, JToken> test in (JObject)testTypes)
                {
                    string testType = test.Key;

                    if (testType == "ID")
                    {
                        ID = test.Value.ToString();
                        childNameLabel.Content = childName + "  -  " + ID;
                    }

                    if (testType == "Iránytévesztés")
                    {
                        ChildrenStackPanel.Children.Add(childNameLabel);
                    }
                }
            }
        }



        // Click the closeButton
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        // Click the closeButton
        private async void newChildButton_Click(object sender, RoutedEventArgs e)
        {
            AddChild addChild = new AddChild();

            addChild.ShowDialog();

            if (addChild.cancelButtonPressed)  // If Mégsem pressed
            {
                return;
            }

            if (addChild.saveButtonPressed)  // If Mentés button pressed
            {
                DatabaseHandler databaseHandler = new DatabaseHandler();

                SetResponse response = null;
                response = await databaseHandler.RegistrateChild(this.User, addChild.childNameTextBox.Text, addChild.childIDTextBox.Text);

                if (response != null)  // If the id added or changed successfully
                {
                    MessageBox.Show("Sikeres regisztráció!");
                    this.Close();
                }
            }
        }
    }
}
