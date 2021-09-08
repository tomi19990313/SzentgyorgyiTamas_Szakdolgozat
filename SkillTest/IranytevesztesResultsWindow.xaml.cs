using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace SkillTest
{
    public partial class IranytevesztesResultsWindow : Window
    {
        DatabaseHandler databaseHandler = new DatabaseHandler();
        string User;


        public IranytevesztesResultsWindow(string user)
        {
            InitializeComponent();

            User = user;
            getResults();
        }



        // Get and display the results of a current user
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
                string childName = child.Key;
                JToken testTypes = child.Value;

                Label childNameLabel = new Label();
                childNameLabel.FontSize = 20;
                childNameLabel.Margin = new Thickness(0, 30, 0, 0);
                childNameLabel.FontWeight = FontWeights.Bold;
                childNameLabel.Content = childName;

                foreach (KeyValuePair<string, JToken> test in (JObject)testTypes)
                {
                    string testType = test.Key;
                    string results = test.Value.ToString();
                    string[] resultsArray = results.Split('*');

                    if (testType == "Iránytévesztés")
                    {
                        ResultStackPanel.Children.Add(childNameLabel);

                        foreach (var result in resultsArray)
                        {
                            Label resultLabel = new Label();
                            resultLabel.FontSize = 16;
                            resultLabel.Margin = new Thickness(30, 0, 0, 0);
                            resultLabel.Content = result;
                            ResultStackPanel.Children.Add(resultLabel);
                        }
                    }
                }
            }
        }



        // Click the closeButton
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
