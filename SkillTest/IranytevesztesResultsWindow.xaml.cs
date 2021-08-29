using Newtonsoft.Json.Linq;
using System;
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



        private async void getResults()
        {
            JObject children = await databaseHandler.getResults(User);

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
                    JToken dates = test.Value;

                    if (testType == "Iránytévesztés")
                    {
                        ResultStackPanel.Children.Add(childNameLabel);
                    }

                    foreach (KeyValuePair<string, JToken> results in (JObject)dates)
                    {
                        string resultDate = results.Key;
                        string result = results.Value.ToString();

                        if (testType == "Iránytévesztés")
                        {
                            Label resultLabel = new Label();
                            resultLabel.FontSize = 16;
                            resultLabel.Margin = new Thickness(30, 0, 0, 0);
                            resultLabel.Content = resultDate + ":  " + result;
                            ResultStackPanel.Children.Add(resultLabel);
                        }
                    }
                }
            }
        }
    }
}
