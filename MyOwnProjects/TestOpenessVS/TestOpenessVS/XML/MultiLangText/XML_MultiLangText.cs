using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TestOpenessVS.XML.MultiLangText
{
    public class XML_MultiLangText : IXmlSerializable
    {
        public XML_MultiLangText()
        {
            MultiLangTexts = new List<XML_MultiLangTextItem>();
            oTextUS = new XML_MultiLangTextItem();
            oTextUA = new XML_MultiLangTextItem();
        }

        public string sTextUS { get; set; } = "Text US";
        public string sTextUA { get; set; } = "Text UA";
        public string sComposName { get; set; } = "Comment";
        private List<XML_MultiLangTextItem> MultiLangTexts { get; set; }
        private XML_MultiLangTextItem oTextUS;
        private XML_MultiLangTextItem oTextUA;

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
            //Set data for US text
            oTextUS.sCulture = "en-US";
            oTextUS.sText = sTextUS;
            oTextUS.sComposName = "Items";

            //Set data for UA text
            oTextUA.sCulture = "uk-UA";
            oTextUA.sText = sTextUA;
            oTextUA.sComposName = "Items";

            //Add objects into list
            MultiLangTexts.Add(oTextUS);
            MultiLangTexts.Add(oTextUA);

            //Create XML structure
            writer.WriteStartElement("MultilingualText");
            writer.WriteAttributeString("ID", (XML_GenData.ID).ToString());
            XML_GenData.ID++;
            writer.WriteAttributeString("CompositionName", sComposName);
            writer.WriteStartElement("ObjectList");

            foreach (var text in MultiLangTexts)
            {
                (text as IXmlSerializable).WriteXml(writer);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
