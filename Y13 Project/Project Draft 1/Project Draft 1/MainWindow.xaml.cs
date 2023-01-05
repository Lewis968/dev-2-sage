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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Draft_1                       //https://flightclub.io/
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mode_Selector.Items.Add("Rocket Selector");
            Mode_Selector.Items.Add("Rocket Builder");
            Mode_Selector.Items.Add("See Previous Rockets");
            Mode_Selector.Items.Add("Tutorial");
        }

        private void Mode_Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {

            switch (Mode_Selector.Text)
            {
                case "Rocket Selector":
                    Selector p = new Selector();
                    p.Show();
                    break;



            }
        }


    }



    
}
