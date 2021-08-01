using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkillTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        // Click the Iranytevesztes_vizsgalat_Button
        private void Iranyteveztes_vizsgalat_Button_Click(object sender, RoutedEventArgs e)
        {
            IranytevesztesWindow iranytevesztesWindow = new IranytevesztesWindow();

            iranytevesztesWindow.ShowDialog();
        }
    }
}
