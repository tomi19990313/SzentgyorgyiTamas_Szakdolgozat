using FireSharp.Response;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;


namespace SkillTest
{
    // This class is to representing the result of the Iránytévesztés teszt
    public partial class IranytevesztesResultWindow : Window
    {
        private FlowDocument flowDoc = new FlowDocument();
        private Table resultTable = new Table();
        private Result Result;
        private string User;
        private string Child;
        private int gazeTimeDuration;



        public IranytevesztesResultWindow(Result Result, string user, string child, int gazeTimeDuration)
        {
            InitializeComponent();

            this.Result = Result;
            this.User = user;
            this.Child = child;
            this.gazeTimeDuration = gazeTimeDuration;

            resultTable.CellSpacing = 5;
            resultTable.LineHeight = 30;

            flowDoc.Blocks.Add(resultTable);
            flowDoc.ColumnWidth = 1000;
            this.AddChild(flowDoc);

            DisplayResultTable();       // Display the result table
            FillUpResultTable();        // Fill up the result table with the results, and the point
            SaveResultsIntoDatabase();  // Save the results into the database
        }



        // Display the result table
        private void DisplayResultTable()
        {
            for (int i = 0; i <= Result.GazeNumber + 1; i++)
            {
                resultTable.Columns.Add(new TableColumn());
            }
        }



        // Fill up the result table with the results, and the point
        private void FillUpResultTable()
        {
            resultTable.RowGroups.Add(new TableRowGroup());


            // 1. Row --------------------
            resultTable.RowGroups[0].Rows.Add(new TableRow());

            TableRow currentRow = resultTable.RowGroups[0].Rows[0];

            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Normal;

            // Naming cell
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Helyes irányok: "))));
            currentRow.Cells[0].ColumnSpan = 10;
            currentRow.Cells[0].Background = Brushes.LightSteelBlue;
            currentRow.Cells[0].BorderThickness = new Thickness(1, 1, 1, 1);
            currentRow.Cells[0].BorderBrush = Brushes.Gray;
            currentRow.Cells[0].FontWeight = FontWeights.Bold;
            currentRow.Cells[0].FontSize = 14;

            // Direction cells
            for (int i = 0; i < Result.GazeNumber; i++)
            {
                switch (Result.getCorrectResults(i))
                {
                    case "0":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Fel"))));
                        break;
                    case "1":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Jobb"))));
                        break;
                    case "2":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Le"))));
                        break;
                    case "3":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Bal"))));
                        break;
                    default:
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Hiányzik"))));
                        break;
                }

                if ((i + 1) % 2 == 0)
                {
                    currentRow.Cells[i + 1].ColumnSpan = 5;
                    currentRow.Cells[i + 1].Background = Brushes.LightSteelBlue;
                    currentRow.Cells[i + 1].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[i + 1].BorderBrush = Brushes.Gray;
                }
                else
                {
                    currentRow.Cells[i + 1].ColumnSpan = 5;
                    currentRow.Cells[i + 1].Background = Brushes.White;
                    currentRow.Cells[i + 1].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[i + 1].BorderBrush = Brushes.Gray;
                }
            }

            // Point cell
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(Result.GazeNumber.ToString()))));
            currentRow.Cells[Result.GazeNumber + 1].ColumnSpan = 5;
            currentRow.Cells[Result.GazeNumber + 1].Background = Brushes.LightGray;
            currentRow.Cells[Result.GazeNumber + 1].BorderThickness = new Thickness(1, 1, 1, 1);
            currentRow.Cells[Result.GazeNumber + 1].BorderBrush = Brushes.Gray;
            currentRow.Cells[Result.GazeNumber + 1].FontSize = 16;
            currentRow.Cells[Result.GazeNumber + 1].FontWeight = FontWeights.Bold;


            // 2. Row --------------------
            resultTable.RowGroups[0].Rows.Add(new TableRow());

            currentRow = resultTable.RowGroups[0].Rows[1];

            currentRow.FontSize = 12;
            currentRow.FontWeight = FontWeights.Normal;

            // Naming cell
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Nézett irányok: "))));
            currentRow.Cells[0].ColumnSpan = 10;
            currentRow.Cells[0].Background = Brushes.LightSteelBlue;
            currentRow.Cells[0].BorderThickness = new Thickness(1, 1, 1, 1);
            currentRow.Cells[0].BorderBrush = Brushes.Gray;
            currentRow.Cells[0].FontWeight = FontWeights.Bold;
            currentRow.Cells[0].FontSize = 14;

            // Direction cells
            for (int i = 0; i < Result.GazeNumber; i++)
            {
                switch (Result.getReceivedResults(i))
                {
                    case "0":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Fel"))));
                        break;
                    case "1":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Jobb"))));
                        break;
                    case "2":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Le"))));
                        break;
                    case "3":
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Bal"))));
                        break;
                    default:
                        currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Hiányzik"))));
                        break;
                }

                if ((i + 1) % 2 == 0)
                {
                    currentRow.Cells[i + 1].ColumnSpan = 5;
                    currentRow.Cells[i + 1].Background = Brushes.LightSteelBlue;
                    currentRow.Cells[i + 1].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[i + 1].BorderBrush = Brushes.Gray;
                }
                else
                {
                    currentRow.Cells[i + 1].ColumnSpan = 5;
                    currentRow.Cells[i + 1].Background = Brushes.White;
                    currentRow.Cells[i + 1].BorderThickness = new Thickness(1, 1, 1, 1);
                    currentRow.Cells[i + 1].BorderBrush = Brushes.Gray;
                }     
            }

            // Point cell
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(Result.getNumericResult().ToString()))));
            currentRow.Cells[Result.GazeNumber + 1].ColumnSpan = 5;
            currentRow.Cells[Result.GazeNumber + 1].Background = Brushes.LightGray;
            currentRow.Cells[Result.GazeNumber + 1].BorderThickness = new Thickness(1, 1, 1, 1);
            currentRow.Cells[Result.GazeNumber + 1].BorderBrush = Brushes.Gray;
            currentRow.Cells[Result.GazeNumber + 1].FontSize = 16;
            currentRow.Cells[Result.GazeNumber + 1].FontWeight = FontWeights.Bold;
        }



        // Save the results into the database
        private async void SaveResultsIntoDatabase()
        {
            string testResult = Result.GazeNumber.ToString() + '/' + Result.getNumericResult().ToString() + '/' + this.gazeTimeDuration.ToString();

            DatabaseHandler databaseHandler = new DatabaseHandler();

            SetResponse response = null;
            response = await databaseHandler.SaveResults(this.User, this.Child, "Iránytévesztés", testResult);

            if (response != null)  // If the save vas successful
            {
                MessageBox.Show("Eredmény elmentve!");
            }
            else
            {
                MessageBox.Show("Ez nem sikerült!");
            }
        }
    }
}
