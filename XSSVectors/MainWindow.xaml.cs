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
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;

namespace XSSVectors
{
    public class VrstaXssNapada
    {
        public string Vrsta { get; set; }

        public string Vrijednost { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void centroid()
        {
            double x1 = ssl3dX.Points.ElementAt(1).X;
            double x2 = ssl3dY.Points.ElementAt(1).X;
            double x3 = ssl3dZ.Points.ElementAt(1).X;

            double y1 = ssl3dX.Points.ElementAt(1).Y;
            double y2 = ssl3dY.Points.ElementAt(1).Y;
            double y3 = ssl3dZ.Points.ElementAt(1).Y;
            
            double z1 = ssl3dX.Points.ElementAt(1).Z;
            double z2 = ssl3dY.Points.ElementAt(1).Z;
            double z3 = ssl3dZ.Points.ElementAt(1).Z;

            double xr = (x1 + x2 + x3) / 3;
            double yr = (y1 + y2 + y3) / 3;
            double zr = (z1 + z2 + z3) / 3;

            if ( ( (x1+y1+z1) != 0) && ((x2 + y2 + z2) != 0) && ((x3 + y3 + z3) != 0))
            {
                ssl3dcentroid.Points.Clear();
                ssl3dcentroid.Points.Add(new Point3D(0, 0, 0));
                ssl3dcentroid.Points.Add(new Point3D(xr, yr, zr));
            }else  if (
                        ((x1 + y1 + z1) == 0) && ((x2 + y2 + z2) != 0) && ((x3 + y3 + z3) != 0) ||
                        ((x1 + y1 + z1) != 0) && ((x2 + y2 + z2) == 0) && ((x3 + y3 + z3) != 0) ||
                        ((x1 + y1 + z1) != 0) && ((x2 + y2 + z2) != 0) && ((x3 + y3 + z3) == 0)
                        )
            {
                xr = (x1 + x2 + x3) / 2;
                yr = (y1 + y2 + y3) / 2;
                zr = (z1 + z2 + z3) / 2;
                ssl3dcentroid.Points.Clear();
                ssl3dcentroid.Points.Add(new Point3D(0, 0, 0));
                ssl3dcentroid.Points.Add(new Point3D(xr, yr, zr));
            }


        }
        public MainWindow()
        {
            InitializeComponent();
            lvVrijednosti0.Items.Add(new VrstaXssNapada { Vrsta = "Stored", Vrijednost = "1" });
            lvVrijednosti1.Items.Add(new VrstaXssNapada { Vrsta = "DOM", Vrijednost = "1" });
            lvVrijednosti2.Items.Add(new VrstaXssNapada { Vrsta = "Reflected", Vrijednost = "1" });

            DataObject.AddPastingHandler(vrijednost0, PasteHandler);
            DataObject.AddPastingHandler(vrijednost1, PasteHandler);
            DataObject.AddPastingHandler(vrijednost2, PasteHandler);
            centroid();
        }


        public bool isNotZero(Point3D p)
        {
            if ( (p.X + p.Y + p.Z) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            foreach (VrstaXssNapada red in lvVrijednosti0.Items)
            {
                sum += Double.Parse(red.Vrijednost);
            }
            double oldSum = sum;
            if (!string.IsNullOrEmpty(vrijednost0.Text))
            {
                lvVrijednosti0.Items.Add(new VrstaXssNapada { Vrsta = vrsta0.Text, Vrijednost = vrijednost0.Text });
                sum += Double.Parse(vrijednost0.Text);
            }
            // x -------------------------
            ssl3dX.Points.Clear();
            ssl3dX.Points.Add(new Point3D(0, 0, 0));
            ssl3dX.Points.Add(new Point3D(sum, 0, 0));

            double procenat = 1;
            if (oldSum != 0)
               procenat = sum / oldSum;

            double xssl3 = sum; 
            double yssl3 = ssl3dconnect.Points.ElementAt(0).Y;
            double zssl3 = ssl3dconnect.Points.ElementAt(0).Z;
            Point3D p0 = new Point3D(xssl3, yssl3, zssl3);
            Point3D p1 = ssl3dconnect.Points.ElementAt(1);
            Point3D p2 = ssl3dconnect.Points.ElementAt(2);
            Point3D p3 = ssl3dconnect.Points.ElementAt(3);
            Point3D p4 = ssl3dconnect.Points.ElementAt(4);
            xssl3 = sum; 
            yssl3 = ssl3dconnect.Points.ElementAt(5).Y;
            zssl3 = ssl3dconnect.Points.ElementAt(5).Z;
            Point3D p5 = new Point3D(xssl3, yssl3, zssl3);

            ssl3dconnect.Points.Clear();
            ssl3dconnect.Points.Add(p0);
            ssl3dconnect.Points.Add(p1);
            ssl3dconnect.Points.Add(p2);
            ssl3dconnect.Points.Add(p3);
            ssl3dconnect.Points.Add(p4);
            ssl3dconnect.Points.Add(p5);

            double x = procenat * perspcam.Position.X;
            double y = procenat * perspcam.Position.Y;
            double z = procenat * perspcam.Position.Z;


            perspcam.Position = new Point3D(x, y, z);
            centroid();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            foreach (VrstaXssNapada red in lvVrijednosti1.Items)
            {
                sum += Double.Parse(red.Vrijednost);
            }
            double oldSum = sum;
            if (!string.IsNullOrEmpty(vrijednost1.Text))
            {
                lvVrijednosti1.Items.Add(new VrstaXssNapada { Vrsta = vrsta1.Text, Vrijednost = vrijednost1.Text });
                sum += Double.Parse(vrijednost1.Text);
            }
            // y -------------------------
            ssl3dY.Points.Clear();
            ssl3dY.Points.Add(new Point3D(0, 0, 0));
            ssl3dY.Points.Add(new Point3D(0, sum, 0));
            double procenat = 1;
            if (oldSum != 0)
                procenat = sum / oldSum;

            Point3D p0 = ssl3dconnect.Points.ElementAt(0);

            double xssl3 = ssl3dconnect.Points.ElementAt(1).X;
            double yssl3 = sum; //procenat * ssl3dconnect.Points.ElementAt(1).Y;
            double zssl3 = ssl3dconnect.Points.ElementAt(1).Z;
            Point3D p1 = new Point3D(xssl3, yssl3, zssl3);

            xssl3 = ssl3dconnect.Points.ElementAt(2).X;
            yssl3 = sum; //procenat * ssl3dconnect.Points.ElementAt(2).Y;
            zssl3 = ssl3dconnect.Points.ElementAt(2).Z;
            Point3D p2 = new Point3D(xssl3, yssl3, zssl3);

            Point3D p3 = ssl3dconnect.Points.ElementAt(3);
            Point3D p4 = ssl3dconnect.Points.ElementAt(4);
            Point3D p5 = ssl3dconnect.Points.ElementAt(5);

            ssl3dconnect.Points.Clear();
            ssl3dconnect.Points.Add(p0);
            ssl3dconnect.Points.Add(p1);
            ssl3dconnect.Points.Add(p2);
            ssl3dconnect.Points.Add(p3);
            ssl3dconnect.Points.Add(p4);
            ssl3dconnect.Points.Add(p5);
            double y = procenat * perspcam.Position.Y;
            double z = procenat * perspcam.Position.Z;
            double x = procenat * perspcam.Position.X;


            perspcam.Position = new Point3D(x, y, z);
            centroid();
        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            foreach (VrstaXssNapada red in lvVrijednosti2.Items)
            {
                sum += Double.Parse(red.Vrijednost);
            }
            double oldSum = sum;
            if (!string.IsNullOrEmpty(vrijednost2.Text))
            {
                lvVrijednosti2.Items.Add(new VrstaXssNapada { Vrsta = vrsta2.Text, Vrijednost = vrijednost2.Text });
                sum += Double.Parse(vrijednost2.Text);
            }
            // z -------------------------
            ssl3dZ.Points.Clear();
            ssl3dZ.Points.Add(new Point3D(0, 0, 0));
            ssl3dZ.Points.Add(new Point3D(0, 0, sum));
            double procenat = 1;
            if (oldSum != 0)
                procenat = sum / oldSum;

            Point3D p0 = ssl3dconnect.Points.ElementAt(0);
            Point3D p1 = ssl3dconnect.Points.ElementAt(1);
            Point3D p2 = ssl3dconnect.Points.ElementAt(2);

            double xssl3 = ssl3dconnect.Points.ElementAt(3).X;
            double yssl3 = ssl3dconnect.Points.ElementAt(3).Y;
            double zssl3 = sum; 
            Point3D p3 = new Point3D(xssl3, yssl3, zssl3);
            
            xssl3 = ssl3dconnect.Points.ElementAt(4).X;
            yssl3 = ssl3dconnect.Points.ElementAt(4).Y;
            zssl3 = sum; 
            Point3D p4 = new Point3D(xssl3, yssl3, zssl3);
            Point3D p5 = ssl3dconnect.Points.ElementAt(5);

            ssl3dconnect.Points.Clear();
            ssl3dconnect.Points.Add(p0);
            ssl3dconnect.Points.Add(p1);
            ssl3dconnect.Points.Add(p2);
            ssl3dconnect.Points.Add(p3);
            ssl3dconnect.Points.Add(p4);
            ssl3dconnect.Points.Add(p5);

            double y = procenat * perspcam.Position.Y;
            double z = procenat * perspcam.Position.Z;
            double x = procenat * perspcam.Position.X;

            perspcam.Position = new Point3D(x, y, z);
            centroid();
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            lvVrijednosti0.Items.Clear();
            lvVrijednosti1.Items.Clear();
            lvVrijednosti2.Items.Clear();

            Point3D p1 = new Point3D(0, 0, 0);
            ssl3dX.Points.Clear();
            ssl3dX.Points.Add(p1);
            ssl3dX.Points.Add(p1);

            ssl3dY.Points.Clear();
            ssl3dY.Points.Add(p1);
            ssl3dY.Points.Add(p1); 
            
            ssl3dZ.Points.Clear();
            ssl3dZ.Points.Add(p1);
            ssl3dZ.Points.Add(p1);

            ssl3dconnect.Points.Clear();
            ssl3dconnect.Points.Add(p1);
            ssl3dconnect.Points.Add(p1);
            ssl3dconnect.Points.Add(p1);

            ssl3dconnect.Points.Add(p1);
            ssl3dconnect.Points.Add(p1);
            ssl3dconnect.Points.Add(p1);

            ssl3dcentroid.Points.Clear();

        }


        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            double y = 0.9 * perspcam.Position.Y;
            double z = 0.9 * perspcam.Position.Z;
            double x = 0.9 * perspcam.Position.X;
            perspcam.Position = new Point3D(x, y, z);
        }
        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            double y = 1.1 * perspcam.Position.Y;
            double z = 1.1 * perspcam.Position.Z;
            double x = 1.1 * perspcam.Position.X;
            perspcam.Position = new Point3D(x, y, z);
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }


        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void PasteHandler(object sender, DataObjectPastingEventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool textOK = false;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                // Allow pasting only alphabetic
                string pasteText = e.DataObject.GetData(typeof(string)) as string;
                if (IsTextAllowed(pasteText))
                    textOK = true;
            }

            if (!textOK)
                e.CancelCommand();
        }

    }
}
