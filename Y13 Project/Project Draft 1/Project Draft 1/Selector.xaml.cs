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

namespace Project_Draft_1
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>

    public partial class Selector : Window
    {
        double atm = 101324;
        public static Rocket myRocket = null;
        public class Rocket
        {

            private string Name; // Name
            private int Thrust; //N;
            private double TWR; // N/KG
            private int WetMass; // kg
            private int DryMass; // kg
            private int SpecificImpulse; // s
            private double ExaustVelocity; // m/s
            private double ExitPressure; // nm/s2

            //public methods

            //get/set methods
            public void SetName(string n) { Name = n; }
            public string GetName() { return Name; }
            public void SetThrust(int t) { Thrust = t; }
            public int GetThrust() { return Thrust; }
            public void SetTWR(double w) { TWR = w; }
            public double GetTWR() { return TWR; }
            public void SetWetMass(int wm) { WetMass = wm; }
            public int GetWetMass() { return WetMass; }
            public void SetDryMass(int dm) { DryMass = dm; }
            public int GetDryMass() { return DryMass; }
            public void SetSpecificImpulse(int s) { SpecificImpulse = s; }
            public int GetSpecificImpulse() { return SpecificImpulse; }
            public void SetExaustVelocity(double e) { ExaustVelocity = e; }
            public double GetExaustVelocity() { return ExaustVelocity; }
            public void SetExitPressure(double ep) { ExitPressure = ep; }
            public double GetExitPressure() { return ExitPressure; }


            public Rocket(string name, int Thrust, double TWR, int WetMass, int DryMass, int SpecificImpulse, double ExaustVelocity, double ExitPressure)
            {
                this.SetName(name);
                this.SetThrust(Thrust);
                this.SetTWR(TWR);
                this.SetWetMass(WetMass);
                this.SetDryMass(DryMass);
                this.SetSpecificImpulse(SpecificImpulse);
                this.SetExaustVelocity(ExaustVelocity);
                this.SetExitPressure(ExitPressure);

            }
            public Rocket()
            {

                //default constructor no overloads
            }
        }
        public Selector()
        {
            InitializeComponent();
            Location.Items.Add("Earth");
            Location.Items.Add("Moon");
            Location.Items.Add("Mars");
            Chooser.Items.Add("Falcon 9");

        }




        private void Chooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            if (this.Location.SelectedItem == null || this.Location.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a launch location");
            }
            else
            {
                Hide(); // to close window
                Window w = new Window();
                w.Content = new Launch();      //Document had to call user control as a window
                w.Show();


            }



        }

        private void Values_Click(object sender, RoutedEventArgs e)
        {

            if (this.Location.SelectedItem == null || this.Location.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a launch location");
            }
            if (this.Chooser.SelectedItem == null || this.Chooser.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Rocket");
            }
            else
            {

                switch (Chooser.Text)
                {
                    case "Falcon 9":
                        myRocket = new Rocket("Falcon 9", 6804000, 1.8, 498044, 23768, 283, 0, 70927.5);
                        break;



                        // Document It was in Selection Changed, didnt work so needed to add a button to ensure stability

                }
                Thrusttxt.Text = myRocket.GetThrust().ToString();           //Crashes when rocket is not selected - Fixed Above using else statement
                Drytxt.Text = myRocket.GetDryMass().ToString();
                WetTxt.Text = myRocket.GetWetMass().ToString();
                SItxt.Text = myRocket.GetSpecificImpulse().ToString();
                Evtxt.Text = myRocket.GetExaustVelocity().ToString();
               
     

                switch (Location.Text)
                {
                    case "Earth":
                        {
                            double g = 9.81;
                            int T = myRocket.GetThrust();
                            double w = myRocket.GetWetMass();
                            double W = w * g;
                            double TW = T / W;
                            T_W_txt.Text = TW.ToString();
                            //double E = myRocket.GetExaustVelocity();
                            //double ep = myRocket.GetExitPressure(); // document the pain //app.diagrams.net
                            //E = (T - (ep - atm) * 2.086);
                            //E = E / 2960;
                            //myRocket.SetExaustVelocity(E);
                            //2776
                            int seconds = 283;
                            for (seconds = 283; seconds > 0 ;)
                            {

                                double E = myRocket.GetExaustVelocity();
                                E = g * seconds;
                                seconds = seconds - 1;
                                myRocket.SetExaustVelocity(E);


                            }

                        }
                        break;

                    case "Moon": // Make sure to edit Thrust and Weight, etc... for all values of g 
                        {

                            double g = 1.625;
                            int T = myRocket.GetThrust();
                            double w = myRocket.GetWetMass();
                            double W = w * g;
                            double TW = T / W;
                            T_W_txt.Text = TW.ToString();
                        }
                        break;

                    case "Mars":
                        {
                            double g = 3.72;
                            int T = myRocket.GetThrust();
                            double w = myRocket.GetWetMass();
                            double W = w * g;
                            double TW = T / W;
                            T_W_txt.Text = TW.ToString();
                        }
                        break;
                    default:
                        break;



                }


            }

        }
        public static void Global()      
        {
            string e = myRocket.GetExaustVelocity().ToString();
        }
        

      


}

}


