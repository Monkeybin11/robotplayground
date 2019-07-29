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

namespace RobotPlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadMap_Click(object sender, RoutedEventArgs e)
        {
            // Load XML data from map
            App.importmap.LoadMap();
        }

        private void GeneratePoints_Click(object sender, RoutedEventArgs e)
        {
            //var elipseNo1 = new Ellipse(); 
            //Canvas.SetLeft(elipseNo1,48);
            //elipseNo1.Width = 10;
            //elipseNo1.Height = 10;
            //elipseNo1.Fill = new SolidColorBrush((Color) ColorConverter.ConvertFromString("Red"));
            //Playground.Children.Add(elipseNo1);

            // Generate Elipse object field
            Ellipse[] ellipsePoints = new Ellipse[3136];

            // Generate Position points
            List<Point> points = new List<Point>() { };
            double xDiv = 0;
            double yDiv = 0;

            for (int j = 0; j < 56; j++)
            {
                for (int k = 0; k < 56; k++)
                {
                    points.Add(new Point(j * 12, k * 12));
                }
            }


            //Add elpse
            for (int pointNo = 0; pointNo < 3136; pointNo++)
            {
                if (App.importmap.sortedPoints[pointNo].Status == "Critical")
                {
                    ellipsePoints[pointNo] = new Ellipse() { Width = 10, Height = 10, Fill = Brushes.Red };
                }
                else if (App.importmap.sortedPoints[pointNo].Status == "Plugged")
                {
                    ellipsePoints[pointNo] = new Ellipse() { Width = 10, Height = 10, Fill = Brushes.Black };
                }
                else
                {
                    ellipsePoints[pointNo] = new Ellipse() { Width = 10, Height = 10, Fill = Brushes.Gray };
                }
                
                Playground.Children.Add(ellipsePoints[pointNo]);
            }

            // Change starting point
            //List<Point> changeStartPoint = points.OrderByDescending(x => x.X).ThenByDescending(y => y.Y).ToList();

            // Put elipse on canvas
            for (int _point = 0;  _point < points.Count ; _point++)
            {
                // Row def
                Canvas.SetTop(ellipsePoints[_point], points[_point].X);
                // Col def
                Canvas.SetLeft(ellipsePoints[_point], points[_point].Y);
                // Div list by 12 to get coordinates
                xDiv = (points[_point].X / 12) + 1;
                yDiv = (points[_point].Y / 12) + 1;
                ellipsePoints[_point].ToolTip = $"R {xDiv} C {yDiv}";
            }
        }
    }
}
