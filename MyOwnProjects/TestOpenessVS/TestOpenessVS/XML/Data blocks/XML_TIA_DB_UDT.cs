using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestOpenessVS.XML.Data_blocks
{
    [Serializable]
    [XmlRoot("Document")]
    public class XML_TIA_DB_UDT : XML_TIA_DB_Base, IXmlSerializable
    {
        #region Data

        #endregion

        #region Constructors
        public XML_TIA_DB_UDT()
        {
            sProgrammingLanguage = "DB";
            sInstanceOfType = "UDT";
        }
        #endregion

        #region XML functions (Read, Write, GetSchema)

        override public void WriteXml(XmlWriter writer)
        {
            sMemoryReserve = string.Empty;
            oMemoryReserve._Name = string.Empty;

            writer.WriteStartElement("SW.Blocks.InstanceDB");
            writer.WriteAttributeString("ID", (XML_GenData.ID).ToString());
            XML_GenData.ID++;
            //(this.o_xmlBaseSW as IXmlSerializable).WriteXml(writer);
            //Call Writer from base class
            base.WriteXml(writer);  //(this as IXmlSerializable)
            writer.WriteEndElement();
        }

        protected override void AddInterfaces()
        {
            oInterface.oSections.sInputSectionName = string.Empty;
            oInterface.oSections.sOutputSectionName = string.Empty;
            oInterface.oSections.sInputOutputSectionName = string.Empty;
            oInterface.oSections.sStaticSectionName = "Static";
        }
        #endregion
    }
}
