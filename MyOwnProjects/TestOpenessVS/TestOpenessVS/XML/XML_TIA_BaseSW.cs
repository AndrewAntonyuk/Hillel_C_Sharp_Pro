using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TestOpenessVS.Utils;

namespace TestOpenessVS.XML
{
    [Serializable]
    public class XML_BaseSW : IXmlSerializable
    {
        protected List<XML_Attribute> AttributeList { get; set; }
        public List<object> ObjectList { get; set; }
        protected GenData oGenData;

        public XML_BaseSW()
        {
            AttributeList = new List<XML_Attribute>();
            ObjectList = new List<object>();
            oGenData = new GenData();
            XML_GenData.ID = 0;
        }

        #region XML functions (Read, Write, GetSchema)

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

        #endregion

        #region General functions (Create, clearList)
        virtual public void ClearLists()
        {
            AttributeList.Clear();
            ObjectList.Clear();
            XML_GenData.ID = 0;
        }

        virtual public string CreateXML()  //object obj
        {
            string s_DirectoryPath = Path.Combine(oGenData._defaultImportFolderPath, "TempImportXML\\");
            string s_FilePath = Path.Combine(s_DirectoryPath, "TempImportFile.xml");

            Type oType = this.GetType();

            var o_Serialiazer = new XmlSerializer(oType);

            if (!Directory.Exists(s_DirectoryPath))
            {
                Directory.CreateDirectory(s_DirectoryPath);
            }

            if (File.Exists(s_FilePath))
            {
                File.Delete(s_FilePath);
            }
            using (var o_FileStream = new StreamWriter(s_FilePath))
            {
                o_Serialiazer.Serialize(o_FileStream, this);

            }

            return s_FilePath;
        }
        #endregion
    }
}
