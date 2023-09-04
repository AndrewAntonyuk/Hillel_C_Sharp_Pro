using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestOpenessVS.XML.MultiLangText;

namespace TestOpenessVS.XML.WatchTable
{
    public class XML_WatchTable_TableEntry: XML_WatchTable_BaseEntry, IXmlSerializable
    {
        public XML_WatchTable_TableEntry()
        {
            sComposName = "Entries";
            oMultiLangText = new XML_MultiLangText();
            oAttrName = new XML_Attribute("Name");
            oAttrFormat = new XML_Attribute("DisplayFormat");
        }

        public string sCommentUS { get; set; } = "Comment US";
        public string sCommentUA { get; set; } = "Comment UA";
        public string sTagName { get; set; } = "DefName";
        public string sTagFormat { get; set; } = "bool";

        private XML_MultiLangText oMultiLangText;
        private XML_Attribute oAttrName;
        private XML_Attribute oAttrFormat;

        override public void WriteXml(XmlWriter writer)
        {
            //Object list
            oMultiLangText.sComposName = "Comment";
            oMultiLangText.sTextUA = sCommentUA;
            oMultiLangText.sTextUS = sCommentUS;
            ObjectList.Add(oMultiLangText);

            //Attribute list
            oAttrName._Value = sTagName;
            oAttrFormat._Value = sTagFormat;            
            AttributeList.Add(oAttrName);
            AttributeList.Add(oAttrFormat);

            writer.WriteStartElement("SW.WatchAndForceTables.PlcWatchTableEntry");
            writer.WriteAttributeString("ID", (XML_GenData.ID).ToString());
            XML_GenData.ID++;
            writer.WriteAttributeString("CompositionName", sComposName);

            writer.WriteStartElement("AttributeList");
            foreach (var attrib in AttributeList)
            {
                (attrib as IXmlSerializable).WriteXml(writer);
            }
            writer.WriteEndElement();

            writer.WriteStartElement("ObjectList");
            foreach(var obj in ObjectList)
            {
                (obj as IXmlSerializable).WriteXml(writer);
            }

            writer.WriteEndElement();
            writer.WriteEndElement();

        }
    }
}
