
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using static Project_Draft_1.Selector;

namespace Project_Draft_1
{
    public partial class Launch : UserControl
    {
        public Launch()
        {
            InitializeComponent();
            myRocket.GetExaustVelocity();
            myRocket.GetWetMass();
            double seconds = 0;
            double Velocity = 0;
            int thrust = myRocket.GetThrust();
            double Ev = myRocket.GetExaustVelocity();
            int wetmass = myRocket.GetWetMass();
            int drymass = myRocket.GetDryMass();
            double g = 9.81;







            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { Velocity },
                    PointGeometry = null
                },

            };

            Labels = new[] { "0", "20", "40", "60", "80", "100", "120", "140", "160" };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            SeriesCollection.Add(new LineSeries
            {
                Title = "Series 1",
                Values = new ChartValues<double> { Velocity},
                PointGeometry = null
            });

            //modifying any series values will also animate and update the chart
            SeriesCollection[1].Values.Clear();
            for (seconds = 0; seconds < 160; seconds++)
            {

                 Velocity = Ev * (Math.Log(drymass) - Math.Log(wetmass) - g * seconds);
                 Math.Round(Velocity);
                Velocity = Velocity * -1;
                SeriesCollection[1].Values.Add(Velocity);

            }

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; } 
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
