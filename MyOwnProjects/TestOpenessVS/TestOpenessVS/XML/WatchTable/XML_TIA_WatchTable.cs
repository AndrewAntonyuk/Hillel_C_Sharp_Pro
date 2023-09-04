using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TestOpenessVS.Utils;

namespace TestOpenessVS.XML
{
    [Serializable]
    [XmlRoot("Document")]
    public class XML_TIA_WatchTable : XML_BaseSW, IXmlSerializable
    {
        public XML_TIA_WatchTable()
        {
           // o_xmlBaseSW = new XML_BaseSW();
            o_Name = new XML_Attribute();
           // XML_GenData.ID = 0;
        }
        [XmlElement("SW.WatchAndForceTables.PlcWatchTable")]
        //public XML_BaseSW o_xmlBaseSW { get; set; }
        public string s_Name { get; set; }
        private XML_Attribute o_Name;

        #region XML functions (Read, Write, GetSchema)

        override public XmlSchema  GetSchema()
        {
            throw new NotImplementedException();
        }

        override public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        override public void WriteXml(XmlWriter writer)
        {
            //Add attribute "Name" 
            o_Name._Name = "Name";
            o_Name._Value = s_Name;

            // o_xmlBaseSW.AttributeList.Add(o_Name);
            AttributeList.Add(o_Name);
            writer.WriteStartElement("SW.WatchAndForceTables.PlcWatchTable");
            writer.WriteAttributeString("ID", (XML_GenData.ID).ToString());
            XML_GenData.ID++;
            //(this.o_xmlBaseSW as IXmlSerializable).WriteXml(writer);
            //Call Writer from base class
             base.WriteXml(writer);  //(this as IXmlSerializable)
            writer.WriteEndElement();
        }
        #endregion
    }
}
