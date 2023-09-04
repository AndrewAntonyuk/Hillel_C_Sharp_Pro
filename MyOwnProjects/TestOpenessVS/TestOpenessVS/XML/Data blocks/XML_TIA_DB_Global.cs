using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestOpenessVS.XML.XML_Attributes.Interface;

namespace TestOpenessVS.XML.Data_blocks
{
    [Serializable]
    [XmlRoot("Document")]
    public class XML_TIA_DB_Global : XML_TIA_DB_Base, IXmlSerializable
    {
        #region Data
        private List<XML_Attrib_Member> arrOfTags;
        #endregion

        #region Constructors
        public XML_TIA_DB_Global()
        {
            sProgrammingLanguage = "DB";
            sCommentUA = "DB for storage data about IO";
            sCommentUS = "DB for storage data about IO";
            sHeaderAutor = "pngr";
            sHeaderFamily = "CommonData";
            sHeaderName = "DB_IO";
            sHeaderVersion = "5.0";
            sMemoryLayout = "Optimized";
            sMemoryReserve = "100";
            sName = "D_InOut";
            sNumber = "10";
            sTitleUA = "InOutDB";
            sTitleUS = "InOutDB";
            arrOfTags = new List<XML_Attrib_Member>();
        }
        #endregion

        #region XML functions (Read, Write, GetSchema)

        override public void WriteXml(XmlWriter writer)
        {
            oInstanceOfName._Name = string.Empty;
            oInstanceOfType._Name = string.Empty;

            writer.WriteStartElement("SW.Blocks.GlobalDB");
            writer.WriteAttributeString("ID", (XML_GenData.ID).ToString());
            XML_GenData.ID++;
            //(this.o_xmlBaseSW as IXmlSerializable).WriteXml(writer);
            //Call Writer from base class
            base.WriteXml(writer);  //(this as IXmlSerializable)
            writer.WriteEndElement();
        }

        protected override void AddInterfaces()
        {
            oInterface.oSections.sInputSectionName = string.Empty;
            oInterface.oSections.sOutputSectionName = string.Empty;
            oInterface.oSections.sInputOutputSectionName = string.Empty;
            oInterface.oSections.sStaticSectionName = "Static";
            oInterface.oSections.oStaticSection.MemberList = arrOfTags;
        }

        public void CreateTagInGlobalDB(string sName, string sDataType, string sComment = "")
        {
            XML_Attrib_Member oMember = new XML_Attrib_Member(sName, sDataType, sComment);
            arrOfTags.Add(oMember);
        }

        #endregion
    }
}
