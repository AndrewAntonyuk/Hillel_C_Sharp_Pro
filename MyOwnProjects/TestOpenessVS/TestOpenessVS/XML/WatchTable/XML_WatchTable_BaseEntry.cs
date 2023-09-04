using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TestOpenessVS.XML.WatchTable
{
    public class XML_WatchTable_BaseEntry : IXmlSerializable
    {
        public XML_WatchTable_BaseEntry()
        {
            AttributeList = new List<XML_Attribute>();
            ObjectList = new List<object>();
        }

        protected List<XML_Attribute> AttributeList { get; set; }
        protected List<object> ObjectList { get; set; }
        public string sComposName { get; set; } = "Comment";

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
            throw new NotImplementedException();
        }

        virtual public void ClearLists()
        {
            AttributeList.Clear();
            ObjectList.Clear();
        }
    }
}
