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
    public class XML_Attrib_Section : IXmlSerializable
    {
        #region Data
        public string sName { get; set; } = "Static";
        public List<XML_Attrib_Member> MemberList { get; set; }
        #endregion

        #region Constructors
        public XML_Attrib_Section(string _Name)
        {
            sName = _Name;
            MemberList = new List<XML_Attrib_Member>();
        }
        public XML_Attrib_Section()
        {
            MemberList = new List<XML_Attrib_Member>();
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
            if(!string.IsNullOrEmpty(sName))
            {
                writer.WriteStartElement("Section");
                writer.WriteAttributeString("Name", sName);
                foreach (var oMember in MemberList)
                {
                    (oMember as IXmlSerializable).WriteXml(writer);
                }
                writer.WriteEndElement();
            }            
        }
        #endregion
    }
}
