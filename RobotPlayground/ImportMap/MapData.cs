using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RobotPlayground.ImportMap
{
    public class MapData
    {
        [XmlRoot(ElementName = "Tube")]
        public class Tube
        {
            [XmlElement(ElementName = "Row")]
            public int Row { get; set; }
            [XmlElement(ElementName = "Column")]
            public int Column { get; set; }
            [XmlElement(ElementName = "Status")]
            public string Status { get; set; }
        }

        [XmlRoot(ElementName = "Tubes")]
        public class Tubes
        {
            [XmlElement(ElementName = "Tube")]
            public List<Tube> Tube { get; set; }
        }

        [XmlRoot(ElementName = "TubesheetModel")]
        public class TubesheetModel
        {
            [XmlElement(ElementName = "TubesheetDiameter")]
            public string TubesheetDiameter { get; set; }
            [XmlElement(ElementName = "TubesheetPitch")]
            public string TubesheetPitch { get; set; }
            [XmlElement(ElementName = "Tubes")]
            public Tubes Tubes { get; set; }
        }
    }
}
