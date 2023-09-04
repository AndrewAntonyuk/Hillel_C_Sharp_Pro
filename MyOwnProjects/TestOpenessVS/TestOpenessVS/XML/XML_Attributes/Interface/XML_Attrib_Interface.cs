using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestOpenessVS.XML.XML_Attributes.Interface;

namespace TestOpenessVS.XML.XML_Attributes
{
    public class XML_Attrib_Interface : XML_Attribute, IXmlSerializable
    {
        #region Data
        public XML_Attrib_Sections oSections;

        #endregion

        #region Constructors
        public XML_Attrib_Interface()
        {
            oSections = new XML_Attrib_Sections();
        }
        #endregion

        #region XML functions
        override public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Interface");
            
            (oSections as IXmlSerializable).WriteXml(writer);
            
            writer.WriteEndElement();
        }

        #endregion
    }
}
