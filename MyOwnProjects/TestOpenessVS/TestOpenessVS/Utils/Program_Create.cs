using Microsoft.Office.Interop.Excel;
using Siemens.Engineering;
using Siemens.Engineering.SW.Blocks;
using System.Text.RegularExpressions;
//using Siemens.Engineering.Multiuser;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW.WatchAndForceTables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestOpenessVS.XML;
using TestOpenessVS.XML.WatchTable;
using TiaOpennessHelper;
using TestOpenessVS.XML.Data_blocks;

namespace TestOpenessVS.Utils
{
    class Program_Create
    {
        struct ReplaceData
        {
            public string sReplaceKey;
            public string sReplaceValue;

            public void Add(List<ReplaceData> oList)
            {
                ReplaceData oReplace = this;

                oList.Add(oReplace);
            }

            public void Add(string sKey, string sValue, List<ReplaceData> oList)
            {
                sReplaceKey = sKey;
                sReplaceValue = sValue;
                ReplaceData oReplace = this;

                oList.Add(oReplace);
            }
        }

        private List<ReplaceData> oReplace;
        private RichTextBox _oTxtStatus;
        private GenActions oGenActions = new GenActions();
        private GenData oGenData = new GenData();
        private string sPathToProgram;
        private string sPathToData;
        private string sXML_Path;
        private int _cntErr;
        private int _cntWarn;
        private ExcelData excelData;
        private Workbook _oWB;
        private Worksheet _oWSheet;
        private ListObject _oLO;
        private ListRows _oLRows;
        private string _sLO_Name = "", _sWS_Name = "";
        private IEngineeringObject oFolderPath = null;

        public void RetriveStartFormData(object _oRetrived)
        {
            _oTxtStatus = (RichTextBox)_oRetrived;
        }

        public Program_Create(ExcelData _excelData)
        {
            if (_excelData != null)
            {
                excelData = _excelData;
                _oWB = excelData._oWB;
                _oWSheet = excelData._oWSheet;
                _oLO = excelData._oLO;
                _oLRows = excelData._oLRows;
                _sLO_Name = excelData._sLO_Name;
                _sWS_Name = excelData._sWS_Name;               
            }
            oReplace = new List<ReplaceData>();
            sPathToProgram = Path.Combine(oGenData._defaultImportFolderPath, "TempProgramDone\\");
            sPathToData = Path.Combine(oGenData._defaultImportFolderPath, "TemplatesProgram\\");

        }

        public Program_Create()
        {
            sPathToProgram = Path.Combine(oGenData._defaultImportFolderPath, "TempProgramDone\\");
            sPathToData = Path.Combine(oGenData._defaultImportFolderPath, "TemplatesProgram\\");
            oReplace = new List<ReplaceData>();
        }
        ~Program_Create()
        {
           
        }

        //Create program blocks
        public void CreateProgram()
        {
            
            string sNameFBCtrl = string.Empty ;
            string sTechNumePrg = string.Empty;
            string sTypeElement = string.Empty;
            string sID = string.Empty;
            string sTemplateText = string.Empty;
            string sTemplateFileName;
            string sDestFileName;

            _cntErr = 0;
            _cntWarn = 0;

            try
            {
                //Open workbook
                if (excelData == null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Apropriate excel file wasn't choiced!", 3);
                    MessageBox.Show("Please, choice apropriate excel file!", "Info!");
                    return;
                }
                if (excelData._oOpenFileDialog == null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Apropriate excel file wasn't choiced!", 3);
                    MessageBox.Show("Please, choice apropriate excel file!", "Info!");
                    return;
                }

                if (_oLRows == null)
                {
                    _cntErr++;
                    oGenActions.CreateStatus(_oTxtStatus, "Some of Parameters for excel table is invalid (name of sheet, name of table ect.)", 2);
                }
                else
                {
                    //Delete folder with program data
                    DeleteFolder(sPathToProgram);

                    //Read excel data
                    for(int i = 3; i < _oLO.ListRows.Count; i++)
                    {
                        ListRow oRow = _oLO.ListRows[i];
                        //Create replace data
                        AddReplaceData(oRow);

                        CreateProgramInstanceCall(oRow);
                        CreateProgramInputs(oRow);
                        CreateProgramOutputs(oRow);
                    }
                }               

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Exception occured: " + ex.Message);
                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
                _cntErr++;


            }

            oGenActions.CreateStatus(_oTxtStatus, "Proccess of creating program finished with " + _cntErr + " errors; " + _cntWarn + " warnings.", 3);


        }

        //Create program block for connect HW inputs to the IODBs tags
        private void CreateProgramInputs(ListRow oRow)
        {

            string sNameIOUDT = string.Empty;
            string sTechNumePrg = string.Empty;
            string sTypeElement = string.Empty;
            string sID = string.Empty;
            string sTemplateText = string.Empty;
            string sTemplateFileName;

            sNameIOUDT = Convert.ToString(oRow.Range[_oLO.ListColumns["Назва IO UDT"].Index].Value);
            sTechNumePrg = Convert.ToString(oRow.Range[_oLO.ListColumns["Технологічний номер"].Index].Value);
            sTypeElement = Convert.ToString(oRow.Range[_oLO.ListColumns["Тип елемента"].Index].Value);
            sID = Convert.ToString(oRow.Range[_oLO.ListColumns["ID"].Index].Value);

            //Try read template data
            sTemplateFileName = sNameIOUDT + "_Inputs.txt";
            sTemplateText = ReadFile(sTemplateFileName);
            if (sTemplateText.Equals(string.Empty))
            {
                _cntErr++;
                oGenActions.CreateStatus(_oTxtStatus, "Template file for inputs connection:" + sTemplateFileName
                                            + " for element type " + sTypeElement
                                            + " with technologie number " + sTechNumePrg
                                            + " and ID " + sID + " is empty.", 2);
            }
            else
            {
                //Replace esential places in template text
                sTemplateText = ChangeTemplateText(sTemplateText);

                //Create destination file
                    WriteFile("FC_Inputs.txt", sTemplateText);
                           
            }
                

        }

        //Create program block for connect HW inputs to the IODBs tags
        private void CreateProgramOutputs(ListRow oRow)
        {

            string sNameIOUDT = string.Empty;
            string sTechNumePrg = string.Empty;
            string sTypeElement = string.Empty;
            string sID = string.Empty;
            string sTemplateText = string.Empty;
            string sTemplateFileName;

            sNameIOUDT = Convert.ToString(oRow.Range[_oLO.ListColumns["Назва IO UDT"].Index].Value);
            sTechNumePrg = Convert.ToString(oRow.Range[_oLO.ListColumns["Технологічний номер"].Index].Value);
            sTypeElement = Convert.ToString(oRow.Range[_oLO.ListColumns["Тип елемента"].Index].Value);
            sID = Convert.ToString(oRow.Range[_oLO.ListColumns["ID"].Index].Value);

            //Try read template data
            sTemplateFileName = sNameIOUDT + "_Outputs.txt";
            sTemplateText = ReadFile(sTemplateFileName);
            if (sTemplateText.Equals(string.Empty))
            {
                _cntErr++;
                oGenActions.CreateStatus(_oTxtStatus, "Template file for outputs connection:" + sTemplateFileName
                                            + " for element type " + sTypeElement
                                            + " with technologie number " + sTechNumePrg
                                            + " and ID " + sID + " is empty.", 2);
            }
            else
            {
                //Replace esential places in template text
                sTemplateText = ChangeTemplateText(sTemplateText);

                //Create destination file
                WriteFile("FC_Outputs.txt", sTemplateText);

            }
                  
        }

        //Create program for call instance
        private void CreateProgramInstanceCall(ListRow oRow)
        {

            string sNameFBCtrl = string.Empty;
            string sTechNumePrg = string.Empty;
            string sTypeElement = string.Empty;
            string sID = string.Empty;
            string sTemplateText = string.Empty;
            string sTemplateFileName;
            string sDestFileName;

            sNameFBCtrl = Convert.ToString( oRow.Range[_oLO.ListColumns["Назва функціонального блоку Ctrl"].Index].Value);
            sTechNumePrg = Convert.ToString(oRow.Range[_oLO.ListColumns["Технологічний номер"].Index].Value);
            sTypeElement = Convert.ToString(oRow.Range[_oLO.ListColumns["Тип елемента"].Index].Value);
            sID = Convert.ToString(oRow.Range[_oLO.ListColumns["ID"].Index].Value);

            //Try read template data
            sTemplateFileName = sNameFBCtrl + ".txt";
            sTemplateText = ReadFile(sTemplateFileName);

            if (sTemplateText.Equals(string.Empty))
            {
                _cntErr++;
                oGenActions.CreateStatus(_oTxtStatus, "Template file:" + sTemplateFileName
                                            + " for element type " + sTypeElement
                                            + " with technologie number " + sTechNumePrg
                                            + " and ID " + sID + " is empty.", 2);
            }
            else
            {

                //Replace esential places in template text
                sTemplateText = ChangeTemplateText(sTemplateText);

                //Create destination file name
                sDestFileName = CreateDestFileName(oRow);

                //Create destination file
                if (!sDestFileName.Equals(string.Empty))
                {
                    WriteFile(sDestFileName, sTemplateText);
                }
                else
                {
                    _cntErr++;
                    oGenActions.CreateStatus(_oTxtStatus, "Element type " + sTypeElement
                                            + " with technologie number " + sTechNumePrg
                                            + " and ID " + sID + " haven't destination description (==,=,++,+).", 2);
                }
            }
        }

        //Create DB for IO signals
        public void CreateIODB(PlcSoftware oPLCSoftware, object _oProject, TiaPortal _oTiaPortal)
        {
            
            string sTagName;
            string sTagType;
            string sTagComment;

            int iLineCounter = 1;

            PlcBlock DataBlock = null;
            XML_TIA_DB_Global oDB_Global = null;

            _cntErr = 0;
            _cntWarn = 0;

            try
            {
                //Open workbook
                if (excelData == null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Apropriate excel file wasn't choiced!", 3);
                    MessageBox.Show("Please, choice apropriate excel file!", "Info!");
                    return;
                }
                if (excelData._oOpenFileDialog == null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Apropriate excel file wasn't choiced!", 3);
                    MessageBox.Show("Please, choice apropriate excel file!", "Info!");
                    return;
                }

                if (_oLRows == null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Some of Parameters for excel table is invalid (name of sheet, name of table ect.)", 2);
                }
                else
                {
                    //Create global DB for IO data
                    oDB_Global = new XML_TIA_DB_Global();
                    oDB_Global = CreateDB_Global();

                    //Create folders in PLC 
                    oFolderPath = CreateFolder(oPLCSoftware);

                    //Go through all lines for add new tags to DB
                    for (int i = 2; i <= _oLO.ListRows.Count; i++)
                    {
                        ListRow _oRowTable = _oLO.ListRows[i];
                        sTagName = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["Технологічний номер"].Index].Value);
                        sTagType = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["Назва IO UDT"].Index].Value);
                        sTagComment = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["Тип елемента"].Index].Value)
                         + " " + oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["Технологічний номер замовника"].Index].Value)
                         + " " +  oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["Технологічна назва"].Index].Value) ;
                         

                        if (sTagName.Equals(string.Empty))
                        {
                            oGenActions.CreateStatus(_oTxtStatus, "Tag in line " + iLineCounter + " haven't name of tag.", 2);
                            _cntErr++;
                            continue;
                        }
                        if (sTagType.Equals(string.Empty))
                        {
                            oGenActions.CreateStatus(_oTxtStatus, "Tag in line " + iLineCounter + " haven't type of tag.", 2);
                            _cntErr++;
                            continue;
                        }

                        oDB_Global.CreateTagInGlobalDB(sTagName, sTagType, sTagComment);
                        iLineCounter++;
                    }

                    //Create XML
                    sXML_Path = oDB_Global.CreateXML();

                    //Import XML
                    ImportXML(_oProject, _oTiaPortal);
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Exception occured: " + ex.Message);
                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
                DataBlock = null;
                _cntErr++;

            }

            oGenActions.CreateStatus(_oTxtStatus, "Proccess of creating IODB finished with " + _cntErr + " errors; " + _cntWarn + " warnings.", 3);

            //values = _oLRows[2].Range[1].Resize(Type.Missing, 5).Value;
            DataBlock = null;

        }

        #region Internal functions
        private void WriteFile(string _fileName, string _text)
        {
            string s_FilePath = Path.Combine(sPathToProgram, _fileName);

            if (!Directory.Exists(sPathToProgram))
            {
                Directory.CreateDirectory(sPathToProgram);
            }

            //if (File.Exists(s_FilePath))
            //{
            //    File.Delete(s_FilePath);
            //}
            using (var o_FileStream = new StreamWriter(s_FilePath, append: true))
            {
                o_FileStream.WriteLine(_text);
                o_FileStream.Dispose();
            }

        }

        private string ReadFile(string _fileName)
        {
            string sReturnText = "";
            string s_FilePath = Path.Combine(sPathToData, _fileName);

            if (!Directory.Exists(sPathToData))
            {
                Directory.CreateDirectory(sPathToData);
            }

            if (File.Exists(s_FilePath))
            {
                using (var o_FileStream = new StreamReader(s_FilePath))
                {
                    sReturnText = o_FileStream.ReadToEnd();
                    o_FileStream.Dispose();
                }
            }
            else
            {
                oGenActions.CreateStatus(_oTxtStatus, "Template file for:" + s_FilePath + " haven't existeed", 2);
                using (var o_FileStream = new StreamWriter(s_FilePath, append: true))
                {
                    o_FileStream.Write(string.Empty);
                    o_FileStream.Dispose();
                }
                _cntErr++;
            }

            return sReturnText;
        }

        private void DeledeFile(string _fileName)
        {
            string s_FilePath = Path.Combine(sPathToProgram, _fileName);

            if (!Directory.Exists(sPathToProgram))
            {
                Directory.CreateDirectory(sPathToProgram);
            }

            if (File.Exists(s_FilePath))
            {
                File.Delete(s_FilePath);
            }

        }

        private void DeleteFolder(string _folderName)
        {
            if (Directory.Exists(_folderName))
            {
                Directory.Delete(_folderName, true);
            }

        }

        private string ReplaceString(string _sSourse, string _sFindVal, string _sReplaceVal)
        {
            string sRetVal = string.Empty;

            sRetVal = Regex.Replace(_sSourse, _sFindVal, _sReplaceVal, RegexOptions.Multiline);

            return sRetVal;
        }

        private string ChangeTemplateText(string _sSource)
        {
            string sRetVal = _sSource;

            foreach (ReplaceData oCurrReplace in oReplace)
            {
                sRetVal = ReplaceString(sRetVal, oCurrReplace.sReplaceKey, oCurrReplace.sReplaceValue);
            }

            return sRetVal;
        }
                
        private bool FileExist(string _fileName)
        {
            bool retVal = false;
            string s_FilePath = Path.Combine(sPathToData, _fileName);

            if (File.Exists(s_FilePath))
            {
                retVal = true;
            }

            return retVal;
        }

        private void AddReplaceData(ListRow oRow)
        {
            oReplace = new List<ReplaceData>();
            ReplaceData currentReplaceData;
            String currentKey;
            String currentValue;

            foreach(ListColumn column in _oLO.ListColumns) {
                currentReplaceData = new ReplaceData();
                currentKey = Convert.ToString(column.Range[2].Value);
                currentValue = Convert.ToString(column.Range[oRow.Index].Value);

                currentReplaceData.Add(currentKey, currentValue, oReplace);
            }
        }

        private string CreateDestFileName(ListRow oRow)
        {
            string sRetValue = string.Empty;
            string sTempSring;
            ListObject oTable = oRow.Parent;

            sTempSring = oGenActions.CheckIsNullToString(oRow.Range[oTable.ListColumns["=="].Index].Value);
            if (!sTempSring.Equals(string.Empty))
            {
                sRetValue += sTempSring;
            }

            sTempSring = oGenActions.CheckIsNullToString(oRow.Range[oTable.ListColumns["="].Index].Value);
            if (!sTempSring.Equals(string.Empty))
            {
                sRetValue += "_" + sTempSring;
            }

            sTempSring = oGenActions.CheckIsNullToString(oRow.Range[oTable.ListColumns["++"].Index].Value);
            if (!sTempSring.Equals(string.Empty))
            {
                sRetValue += "_" + sTempSring;
            }

            sTempSring = oGenActions.CheckIsNullToString(oRow.Range[oTable.ListColumns["+"].Index].Value);
            if (!sTempSring.Equals(string.Empty))
            {
                sRetValue += "_" + sTempSring;
            }

            if (!sRetValue.Equals(string.Empty))
            {
                sRetValue += ".txt";
            }

            return sRetValue;
        }

        //Create DB Global
        private XML_TIA_DB_Global CreateDB_Global()
        {
            XML_TIA_DB_Global oReturnDB = new XML_TIA_DB_Global();
            oReturnDB.sHeaderAutor = oGenActions.CheckIsNullToString(_oWSheet.Range["sPRG_Author"].Value);

            oReturnDB.sName = oGenActions.CheckIsNullToString(_oWSheet.Range["sPRGIO_NameDB"].Value);
            oReturnDB.sNumber = oGenActions.CheckIsNullToString(_oWSheet.Range["sPRGIO_NumDB"].Value);

            return oReturnDB;
        }

        //Create folder path
        private IEngineeringObject CreateFolder(PlcSoftware _oPlcSoftware)
        {
            string rootFldName;
            string insertedFldName;
            PlcBlockSystemGroup systemGroup = _oPlcSoftware.BlockGroup;
            PlcBlockUserGroupComposition groupComposition = systemGroup.Groups;
            PlcBlockUserGroup pathUserGroups = null;

            IEngineeringObject oRetVal = null;

            //Init esential data
            rootFldName = oGenActions.CheckIsNullToString(_oWSheet.Range["sPRGIO_RootFld"].Value);
            insertedFldName = oGenActions.CheckIsNullToString(_oWSheet.Range["sPRGIO_InsertedFld"].Value);
            pathUserGroups = null;

            //Create folders
            //Check if exist subfolders
            pathUserGroups = groupComposition.Find(rootFldName);

            if (pathUserGroups == null)
            {
                pathUserGroups = groupComposition.Create(rootFldName);
            }

            pathUserGroups = pathUserGroups.Groups.Find(insertedFldName);

            if (pathUserGroups == null)
            {
                pathUserGroups = groupComposition.Find(rootFldName);
                pathUserGroups = pathUserGroups.Groups.Create(insertedFldName);
            }

            oRetVal = pathUserGroups;
            return oRetVal;
        }

        //Import XML file into project
        private void ImportXML(object _oProject, TiaPortal _oTiaPortal)
        {

            Project tiaProject;
            //LocalSession _tiaPortalLocalSession;

            if (_oProject is Siemens.Engineering.Project)
            {
                tiaProject = (Siemens.Engineering.Project)_oProject;
                using (var access = _oTiaPortal.ExclusiveAccess("Import element"))
                {
                    if (string.IsNullOrEmpty(sXML_Path) == false)
                    {
                        using (var action = access.Transaction(tiaProject, "Import element"))
                        {
                            try
                            {
                                OpennessHelper.ImportItem(oFolderPath, sXML_Path, ImportOptions.Override);
                                action.CommitOnDispose();
                            }
                            catch (EngineeringException invoEx)
                            {
                                oGenActions.CreateStatus(_oTxtStatus, "Import failed: " + invoEx.Message, 2);
                            }
                            catch (ArgumentException ae)
                            {
                                oGenActions.CreateStatus(_oTxtStatus, "Import failed: " + ae.Message, 2);
                            }
                            catch (IOException ie)
                            {
                                oGenActions.CreateStatus(_oTxtStatus, "Import failed: " + ie.Message, 2);
                            }
                        }
                    }
                }
            }

          /*  if (_oProject is Siemens.Engineering.Multiuser.LocalSession)
            {
                _tiaPortalLocalSession = (Siemens.Engineering.Multiuser.LocalSession)_oProject;
                using (var access = _oTiaPortal.ExclusiveAccess("Import element"))
                {
                    if (string.IsNullOrEmpty(sXML_Path) == false)
                    {
                        using (var action = access.Transaction(_tiaPortalLocalSession.Project, "Import element"))
                        {
                            try
                            {
                                OpennessHelper.ImportItem(oFolderPath, sXML_Path, ImportOptions.Override);
                                action.CommitOnDispose();
                            }
                            catch (EngineeringException invoEx)
                            {
                                oGenActions.CreateStatus(_oTxtStatus, "Import failed: " + invoEx.Message, 2);
                            }
                            catch (ArgumentException ae)
                            {
                                oGenActions.CreateStatus(_oTxtStatus, "Import failed: " + ae.Message, 2);
                            }
                            catch (IOException ie)
                            {
                                oGenActions.CreateStatus(_oTxtStatus, "Import failed: " + ie.Message, 2);
                            }
                        }
                    }
                }
            }*/

        }
        #endregion
    }
}