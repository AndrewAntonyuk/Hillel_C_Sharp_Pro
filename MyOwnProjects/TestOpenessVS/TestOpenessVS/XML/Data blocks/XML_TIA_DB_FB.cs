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
    public class XML_TIA_DB_FB : XML_TIA_DB_Base, IXmlSerializable
    {
        #region Data

        #endregion

        #region Constructors
        public XML_TIA_DB_FB()
        {
            sProgrammingLanguage = "DB";
            sInstanceOfType = "FB";
        }
        #endregion

        #region XML functions (Read, Write, GetSchema)

        override public void WriteXml(XmlWriter writer)
        {
            oMemoryLayout._Name = string.Empty;
            oMemoryReserve._Name = string.Empty;
            sMemoryReserve = string.Empty;
            sMemoryLayout = string.Empty;

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
            oInterface.oSections.sInputSectionName = "Input";
            oInterface.oSections.sOutputSectionName = "Output";
            oInterface.oSections.sInputOutputSectionName = "InOut";
            oInterface.oSections.sStaticSectionName = "Static";
        }
        #endregion
    }
}
