using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RobotPlayground.ImportMap
{
    public class ImportMap
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(MapData.TubesheetModel));
        public MapData.TubesheetModel XmlData;
        public List<MapData.Tube> sortedPoints;

        public void LoadMap()
        {
            // Relative path to file
            string MapFileName = "Tubesheet.txt";
            string MapPath = Path.Combine(Environment.CurrentDirectory, @"Maps", MapFileName);
            // Data
            

            try
            {
                TextReader reader = new StreamReader(MapPath);
                object obj = deserializer.Deserialize(reader);
                 XmlData = (MapData.TubesheetModel)obj;
                reader.Close();

                //Test Import
                //Console.WriteLine(XmlData.TubesheetDiameter);
                //Console.WriteLine(XmlData.TubesheetPitch);
                //Console.WriteLine(XmlData.Tubes.Tube.Count);
                //Console.WriteLine(XmlData.Tubes.Tube[3135].Row);
                //Console.WriteLine(XmlData.Tubes.Tube[3135].Column.ToString());
                //Console.WriteLine(XmlData.Tubes.Tube[3135].Status);

                SortPoints();
            }
            catch (System.IO.FileNotFoundException)
            {
                // Add exception routine    
                Console.WriteLine("Map not found!");
            }
            finally
            {
                Console.WriteLine("Map is found!");
            }
        }

        public void SortPoints()
        {
            // LINQ sorted point 
            // 1. Row
            // 2. Column
            sortedPoints = XmlData.Tubes.Tube.OrderBy(x => x.Row).ThenBy(x => x.Column).ToList();

            // Sort Test
            // 1
            Console.WriteLine(sortedPoints[0].Row);
            Console.WriteLine(sortedPoints[0].Column);
            Console.WriteLine(sortedPoints[0].Status);
            // 2
            Console.WriteLine(sortedPoints[1].Row);
            Console.WriteLine(sortedPoints[1].Column);
            Console.WriteLine(sortedPoints[1].Status);
            // 3
            Console.WriteLine(sortedPoints[2].Row);
            Console.WriteLine(sortedPoints[2].Column);
            Console.WriteLine(sortedPoints[2].Status);
            //2
            Console.WriteLine(sortedPoints[3135].Row);
            Console.WriteLine(sortedPoints[3135].Column);
            Console.WriteLine(sortedPoints[3135].Status);
        }
    }
}
