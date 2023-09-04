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
    public class XML_Attrib_Member : IXmlSerializable
    {
        #region Data
        public string sName { get; set; } = string.Empty;
        public string sDataType { get; set; } = string.Empty;
        public string sComment { get; set; } = string.Empty;
        #endregion

        #region Constructors
        public XML_Attrib_Member(string _Name, string _DataType, string _Comment = "")
        {
            sName = _Name;
            sDataType = _DataType;
            sComment = _Comment;
        }

        public XML_Attrib_Member(string _Name)
        {
            sName = _Name;
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
            if (!(string.IsNullOrEmpty(sName)
                || string.IsNullOrEmpty(sDataType)))
            {
                writer.WriteStartElement("Member");
                writer.WriteAttributeString("Name", sName);
                writer.WriteAttributeString("Datatype", sDataType);

                writer.WriteStartElement("AttributeList");

                    writer.WriteStartElement("BooleanAttribute");
                    writer.WriteAttributeString("Name", "ExternalAccessible");
                    writer.WriteAttributeString("SystemDefined", "true");
                    writer.WriteString("false");
                    writer.WriteEndElement();

                    writer.WriteStartElement("BooleanAttribute");
                    writer.WriteAttributeString("Name", "ExternalVisible");
                    writer.WriteAttributeString("SystemDefined", "true");
                    writer.WriteString("false");
                    writer.WriteEndElement();

                    writer.WriteStartElement("BooleanAttribute");
                    writer.WriteAttributeString("Name", "ExternalWritable");
                    writer.WriteAttributeString("SystemDefined", "true");
                    writer.WriteString("false");
                    writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteStartElement("Comment");

                    writer.WriteStartElement("MultiLanguageText");
                    writer.WriteAttributeString("Lang", "en-US");
                    writer.WriteString(sComment);
                    writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndElement();
            }            
        }
        #endregion
    }
}
