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
    public class XML_MultiLangTextItem : IXmlSerializable
    {
        public XML_MultiLangTextItem()
        {
            AttributeList = new List<XML_Attribute>();
            oAttrCulture = new XML_Attribute();
            oAttrText = new XML_Attribute();
        }

        public string sText { get; set; } = "Def Text";
        public string sCulture { get; set; } = "en-US";
        public string sComposName { get; set; } = "Items";

        private List<XML_Attribute> AttributeList { get; set; }
        private XML_Attribute oAttrCulture;
        private XML_Attribute oAttrText;

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
            //Set culture
            oAttrCulture._Name = "Culture";
            oAttrText._Name = "Text";

            //Set text
            oAttrCulture._Value = sCulture;
            oAttrText._Value = sText;

            //Add to list
            AttributeList.Add(oAttrCulture);
            AttributeList.Add(oAttrText);

            writer.WriteStartElement("MultilingualTextItem");
            writer.WriteAttributeString("ID", XML_GenData.ID.ToString());
            XML_GenData.ID++;
            writer.WriteAttributeString("CompositionName", sComposName);

            writer.WriteStartElement("AttributeList");
            foreach (var attrib in AttributeList)
            {
                (attrib as IXmlSerializable).WriteXml(writer);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
