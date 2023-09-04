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
    public class XML_WatchTable_CommentEntry: XML_WatchTable_BaseEntry, IXmlSerializable
    {
        public XML_WatchTable_CommentEntry()
        {
            sComposName = "Entries";
            oMultiLangText = new XML_MultiLangText();
        }

        public string sCommentUS { get; set; } = "Comment US";
        public string sCommentUA { get; set; } = "Comment UA";
        private XML_MultiLangText oMultiLangText;

        override public void WriteXml(XmlWriter writer)
        {
            oMultiLangText.sComposName = "Comment";
            oMultiLangText.sTextUA = sCommentUA;
            oMultiLangText.sTextUS = sCommentUS;

            ObjectList.Add(oMultiLangText);

            writer.WriteStartElement("SW.WatchAndForceTables.PlcTableCommentEntry");
            writer.WriteAttributeString("ID", (XML_GenData.ID).ToString());
            XML_GenData.ID++;
            writer.WriteAttributeString("CompositionName", sComposName);

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
