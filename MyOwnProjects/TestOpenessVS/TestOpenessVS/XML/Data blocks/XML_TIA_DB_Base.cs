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
    public class XML_TIA_DB_Base : XML_BaseSW, IXmlSerializable
    {
        #region Data
        protected XML_Attribute oHeaderAutor;
        protected XML_Attribute oHeaderFamily;
        protected XML_Attribute oHeaderName;
        protected XML_Attribute oHeaderVersion;
        protected XML_Attribute oInstanceOfName;
        protected XML_Attribute oInstanceOfType;
        protected XML_Attrib_Interface oInterface;
        protected XML_Attribute oMemoryLayout;
        protected XML_Attribute oMemoryReserve;
        protected XML_Attribute oName;
        protected XML_Attribute oNumber;
        protected XML_Attribute oProgrammingLanguage;
        private XML_MultiLangText oComment;
        private XML_MultiLangText oTitle;

        public string sHeaderAutor { get; set; } = "PNG";
        public string sHeaderFamily { get; set; } = "Blocks";
        public string sHeaderName { get; set; } = "EngPNG";
        public string sHeaderVersion { get; set; } = "5.0";
        public string sMemoryLayout { get; set; } = "Optimized";
        public string sMemoryReserve { get; set; } = "100";
        public string sInstanceOfName { get; set; } = "Lib_UDT";
        protected string sInstanceOfType { get; set; } = "UDT";
        public string sName { get; set; } = "D_Block";
        public string sNumber { get; set; } = "999";
        protected string sProgrammingLanguage { get; set; } = "DB";
        public string sCommentUA { get; set; } = string.Empty;
        public string sCommentUS { get; set; } = string.Empty;
        public string sTitleUA { get; set; } = "PNG blocks";
        public string sTitleUS { get; set; } = "PNG blocks";
        #endregion

        public XML_TIA_DB_Base()
        {
             oHeaderAutor  = new XML_Attribute();
             oHeaderFamily  = new XML_Attribute();
             oHeaderName  = new XML_Attribute();
             oHeaderVersion  = new XML_Attribute();
             oInterface  = new XML_Attrib_Interface();
             oMemoryLayout  = new XML_Attribute();
             oMemoryReserve  = new XML_Attribute();
             oName  = new XML_Attribute();
             oNumber  = new XML_Attribute();
             oProgrammingLanguage  = new XML_Attribute();
             oInstanceOfName = new XML_Attribute();
             oInstanceOfType = new XML_Attribute();
             oComment = new XML_MultiLangText();
             oTitle = new XML_MultiLangText();

            oHeaderAutor._Name = "HeaderAuthor";
            oHeaderFamily._Name = "HeaderFamily";
            oHeaderName._Name = "HeaderName";
            oHeaderVersion._Name = "HeaderVersion";
            oMemoryLayout._Name = "MemoryLayout";
            oMemoryReserve._Name = "MemoryReserve";
            oName._Name = "Name";
            oNumber._Name = "Number";
            oProgrammingLanguage._Name = "ProgrammingLanguage";
            oInstanceOfName._Name = "InstanceOfName";
            oInstanceOfType._Name = "InstanceOfType";
        }

        #region XML functions (Read, Write, GetSchema)

        override public void WriteXml(XmlWriter writer)
        {
            AddAttributes();

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
        }

        virtual protected void AddInterfaces()
        {
            oInterface.oSections.sInputSectionName = "Input";
            oInterface.oSections.sOutputSectionName = "Output";
            oInterface.oSections.sInputOutputSectionName = "InOut";
            oInterface.oSections.sStaticSectionName = "Static";
        }

        virtual protected void AddAttributes()
        {
            AddInterfaces();
                        
            oHeaderAutor._Value = sHeaderAutor;
            oHeaderFamily._Value = sHeaderFamily;
            oHeaderName._Value = sHeaderName;
            oHeaderVersion._Value = sHeaderVersion;
            oMemoryLayout._Value = sMemoryLayout;
            oMemoryReserve._Value = sMemoryReserve;
            oName._Value = sName;
            oNumber._Value = sNumber;
            oProgrammingLanguage._Value = sProgrammingLanguage;
            oInstanceOfName._Value = sInstanceOfName;
            oInstanceOfType._Value = sInstanceOfType;

            AttributeList.Add(oHeaderAutor);
            AttributeList.Add(oHeaderFamily);
            AttributeList.Add(oHeaderName);
            AttributeList.Add(oHeaderVersion);
            AttributeList.Add(oInstanceOfName);
            AttributeList.Add(oInstanceOfType);
            AttributeList.Add(oInterface);
            AttributeList.Add(oMemoryLayout);
            AttributeList.Add(oMemoryReserve);
            AttributeList.Add(oName);
            AttributeList.Add(oNumber);
            AttributeList.Add(oProgrammingLanguage);

            //Set comment and titles
            oComment.sComposName = "Comment";
            oComment.sTextUA = sCommentUA;
            oComment.sTextUS = sCommentUS;

            oTitle.sComposName = "Title";
            oTitle.sTextUA = sTitleUA;
            oTitle.sTextUS = sTitleUS;

            ObjectList.Add(oComment);
            ObjectList.Add(oTitle);
        }

        #endregion

    }
}
