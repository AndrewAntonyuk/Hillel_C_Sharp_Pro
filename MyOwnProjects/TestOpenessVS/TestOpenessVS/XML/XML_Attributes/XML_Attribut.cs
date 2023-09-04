using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TestOpenessVS.XML
{
    public class XML_Attribute : IXmlSerializable
    {
        public XML_Attribute()
        {

        }
        public XML_Attribute(string name, string value)
        {
            this._Name = name;            
            this._Value = value;
        }
        public XML_Attribute(string name)
        {
            this._Name = name;
            this._Value = "";
        }

        public string _Value { get; set; }
        public string _Name { get; set; }

        virtual public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        virtual public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        virtual public void WriteXml(XmlWriter writer)
        {
            if (!string.IsNullOrEmpty(_Name))
            {
                writer.WriteElementString(_Name, _Value);
            }                       
        }
    }
}
