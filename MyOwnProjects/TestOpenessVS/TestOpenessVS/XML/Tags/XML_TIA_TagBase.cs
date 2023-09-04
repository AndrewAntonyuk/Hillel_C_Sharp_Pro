using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestOpenessVS.XML.MultiLangText;
using TestOpenessVS.XML.XML_Attributes;

namespace TestOpenessVS.XML.Data_blocks
{
    [Serializable]
    [XmlRoot("Document")]
    public class XML_TIA_TagBase : XML_BaseSW, IXmlSerializable
    {
        #region Data
        protected XML_Attribute oDataTypeName;
        protected XML_Attribute oExternalAccessible;
        protected XML_Attribute oExternalVisible;
        protected XML_Attribute oExternalWritable;
        protected XML_Attribute oLogicalAddress;
        protected XML_Attribute oName;
        private XML_MultiLangText oComment;

        public string sDataTypeName { get; set; } = "Bool";
        public string sExternalAccessible { get; set; } = "false";
        public string sExternalVisible { get; set; } = "false";
        public string sExternalWritable { get; set; } = "false";
        public string sLogicalAddress { get; set; } = "%I0.0";
        public string sName { get; set; } = "I_TagName";
        public string sCommentUA { get; set; } = string.Empty;
        public string sCommentUS { get; set; } = string.Empty;
        #endregion

        public XML_TIA_TagBase()
        {
             oDataTypeName = new XML_Attribute();
             oExternalAccessible = new XML_Attribute();
             oExternalVisible = new XML_Attribute();
             oExternalWritable = new XML_Attribute();
             oLogicalAddress = new XML_Attribute();
             oName = new XML_Attribute();
             oComment = new XML_MultiLangText();

            oDataTypeName._Name = "DataTypeName";
            oExternalAccessible._Name = "ExternalAccessible";
            oExternalVisible._Name = "ExternalVisible";
            oExternalWritable._Name = "ExternalWritable";
            oLogicalAddress._Name = "LogicalAddress";
            oName._Name = "Name";
        }

        #region XML functions (Read, Write, GetSchema)

        override public void WriteXml(XmlWriter writer)
        {
            AddAttributes();

            writer.WriteStartElement("SW.Tags.PlcTag");
            writer.WriteAttributeString("ID", (XML_GenData.ID).ToString());
            XML_GenData.ID++;

            writer.WriteStartElement("AttributeList");
            foreach (var attrib in AttributeList)
            {
                (attrib as IXmlSerializable).WriteXml(writer);
            }
            writer.WriteEndElement();  

            writer.WriteStartElement("ObjectList");
            foreach (var obj in ObjectList)
            {
                (obj as IXmlSerializable).WriteXml(writer);
            }

            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        virtual protected void AddAttributes()
        {
            oDataTypeName._Value = sDataTypeName;
            oExternalAccessible._Value = sExternalAccessible;
            oExternalVisible._Value = sExternalVisible;
            oExternalWritable._Value = sExternalWritable;
            oLogicalAddress._Value = sLogicalAddress;
            oName._Value = sName;

            AttributeList.Add(oDataTypeName);
            AttributeList.Add(oExternalAccessible);
            AttributeList.Add(oExternalVisible);
            AttributeList.Add(oExternalWritable);
            AttributeList.Add(oLogicalAddress);
            AttributeList.Add(oName);

            //Set comment and titles
            oComment.sComposName = "Comment";
            oComment.sTextUA = sCommentUA;
            oComment.sTextUS = sCommentUS;

            ObjectList.Add(oComment);
        }

        #endregion

    }
}
