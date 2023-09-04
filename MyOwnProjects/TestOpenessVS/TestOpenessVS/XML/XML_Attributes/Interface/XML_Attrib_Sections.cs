using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TestOpenessVS.XML.XML_Attributes.Interface
{
    public class XML_Attrib_Sections : IXmlSerializable
    {
        #region Data
        private List<XML_Attrib_Section> SectionList;
        public XML_Attrib_Section oStaticSection;
        public XML_Attrib_Section oInputSection;
        public XML_Attrib_Section oOutputSection;
        public XML_Attrib_Section oInputOutputSection;

        public string sStaticSectionName { get; set; } = "Static";
        public string sInputSectionName { get; set; } = string.Empty;
        public string sOutputSectionName { get; set; } = string.Empty;
        public string sInputOutputSectionName { get; set; } = string.Empty;
        #endregion

        #region Constructors
        public XML_Attrib_Sections()
        {
            SectionList = new List<XML_Attrib_Section>();
            oStaticSection = new XML_Attrib_Section();
            oInputSection = new XML_Attrib_Section();
            oOutputSection = new XML_Attrib_Section();
            oInputOutputSection = new XML_Attrib_Section();
        }
        #endregion

        #region General functions
        private void AddSection()
        {
            oStaticSection.sName = sStaticSectionName;
            oInputSection.sName = sInputSectionName;
            oOutputSection.sName = sOutputSectionName;
            oInputOutputSection.sName = sInputOutputSectionName;

            SectionList.Add(oStaticSection);
            SectionList.Add(oInputSection);
            SectionList.Add(oOutputSection);
            SectionList.Add(oInputOutputSection);
        }
        #endregion


        #region XML functions
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            AddSection();
            writer.WriteStartElement("Sections");
            writer.WriteAttributeString("xmlns", "http://www.siemens.com/automation/Openness/SW/Interface/v1");
            foreach(var oSection in SectionList)
            {
                (oSection as IXmlSerializable).WriteXml(writer);
            }
            writer.WriteEndElement();
        }
        #endregion
    }
}
