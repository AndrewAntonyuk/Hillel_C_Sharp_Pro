using Microsoft.Office.Interop.Excel;
using Siemens.Engineering;
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

namespace TestOpenessVS.Utils
{
    class WatchTables_Create
    {
        private RichTextBox _oTxtStatus;
        private GenActions oGenActions = new GenActions();
        private int _cntErr;
        private int _cntWarn;
        private ExcelData excelData;
        private Workbook _oWB;
        private Worksheet _oWSheet;
        private ListObject _oLO;
        private ListRows _oLRows;
        private string _sLO_Name = "", _sWS_Name = "";
        private string sXMLPath;
        private IEngineeringObject oFolderPath = null;

        public void RetriveStartFormData(object _oRetrived)
        {
            _oTxtStatus = (RichTextBox)_oRetrived;
        }

        public WatchTables_Create(ExcelData _excelData)
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
            
        }
        ~WatchTables_Create()
        {
           
        }

        //Create watchtables
        public void CreateWatchTables(PlcSoftware oPLCSoftware, object _oProject, TiaPortal _oTiaPortal)
        {
            
            string watchTableName;
            string currWatchTableName;
            string tagName;
            string lineNumber;
                      
            PlcWatchTable watchTable = null;
            XML_TIA_WatchTable oWatchTable = null;
            XML_WatchTable_CommentEntry oCommentEntry = null;
            XML_WatchTable_TableEntry oReturnTableEntry = null;

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
                    
                    //Go through all lines for find new watchtable
                    foreach (ListRow _oRowTable in _oLRows)
                    {
                        //Read name of watchtable
                        watchTableName = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["PlcTagTable\nName"].Index].Value);
                        tagName = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["PlcTag\nName"].Index].Value);
                        lineNumber = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["№"].Index].Value);

                        //Check if watchtable exist
                        if (watchTableName == string.Empty)
                        {
                            oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + tagName + " in line excel: " + lineNumber + " haven't Watchtable name", 2);
                            _cntErr++;
                        }
                        else
                        {
                            //Serch watchtable in exist watchtables
                            watchTable = OpennessHelper.FindPlcWatchTableByName(oPLCSoftware, watchTableName);

                            //If it is new -> create new folders and watchtable
                            if (watchTable == null)
                            {
                                //Create object of watchtable
                                oWatchTable = new XML_TIA_WatchTable();
                                oCommentEntry = new XML_WatchTable_CommentEntry();

                                oCommentEntry.sCommentUA = watchTableName;
                                oCommentEntry.sCommentUS = watchTableName;

                                oWatchTable.ObjectList.Add(oCommentEntry);
                                oWatchTable.s_Name = watchTableName;

                                //Go through all lines in table and create esential groups and watchtables
                                foreach (ListRow _oLRow in _oLRows)
                                {
                                    //Read name of watchtable of current tag
                                    currWatchTableName = oGenActions.CheckIsNullToString(_oLRow.Range[_oLO.ListColumns["PlcTagTable\nName"].Index].Value);

                                    //Add new entry for watchtable
                                    if (currWatchTableName.Equals(watchTableName))
                                    {
                                        oReturnTableEntry = CreateTableEntry(_oLRow);
                                        oWatchTable.ObjectList.Add(oReturnTableEntry);
                                    }

                                }

                                //Create XML file for import
                                sXMLPath = oWatchTable.CreateXML();

                                //Create folders
                                oFolderPath = CreateFolder(_oRowTable, oPLCSoftware);

                                //Import XML
                                ImportXML(_oProject, _oTiaPortal);

                                oWatchTable = null;
                                watchTable = null;
                                oCommentEntry = null;
                                oReturnTableEntry = null;

                            }

                        }


                    }
                   
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Exception occured: " + ex.Message);
                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
                oWatchTable = null;
                 watchTable = null;
                oCommentEntry = null;
                oReturnTableEntry = null;

                
            }

            oGenActions.CreateStatus(_oTxtStatus, "Proccess of creating watchtables finished with " + _cntErr + " errors; " + _cntWarn + " warnings.", 3);

            //values = _oLRows[2].Range[1].Resize(Type.Missing, 5).Value;
            
            oWatchTable = null;
            watchTable = null;
            oCommentEntry = null;
            oReturnTableEntry = null;

        }

        private string GetSubFolderName(ListRow oRow, int cntCurrSF)
        {
            string retName = string.Empty;
            try
            {
                retName = oGenActions.CheckIsNullToString(oRow.Range[_oLO.ListColumns["subfolder1"].Index + cntCurrSF].Value);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception occured: " + ex.Message);
                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
            }
            return retName;
        }


        private PlcWatchAndForceTableUserGroup GetPathUserGroups(PlcWatchAndForceTableUserGroup _oUserGrp, int _iCurrSubFld, ListRow _oRow)
        {
            PlcWatchAndForceTableUserGroup retUserGroup = null;
            string sNextSubFldName = GetSubFolderName(_oRow, _iCurrSubFld + 1);
            if (sNextSubFldName == string.Empty)
            {
                retUserGroup = _oUserGrp;
            }
            else
            {
                retUserGroup = _oUserGrp.Groups.Find(sNextSubFldName);
                if (retUserGroup == null)
                {
                    retUserGroup = _oUserGrp.Groups.Create(sNextSubFldName);
                }
                retUserGroup = GetPathUserGroups(retUserGroup, _iCurrSubFld + 1, _oRow);
            }
            return retUserGroup;
        }

        //Create table entry for watchtable
        private XML_WatchTable_TableEntry CreateTableEntry( ListRow _oRow)
        {
            XML_WatchTable_TableEntry oReturnTableEntry = new XML_WatchTable_TableEntry();

            string _TagName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nName"].Index].Value);
            string _LineNum = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["№"].Index].Value);
            string _LogicAddr = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nLogicalAddress"].Index].Value);
            string _DataType = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nDataTypeName"].Index].Value);
            bool _ExtAccess = oGenActions.CheckIsNullToBool(_oRow.Range[_oLO.ListColumns["PlcTag\nExternalAccessible"].Index].Value);
            bool _ExtVisible = oGenActions.CheckIsNullToBool(_oRow.Range[_oLO.ListColumns["PlcTag\nExternalVisible"].Index].Value);
            bool _ExtWritable = oGenActions.CheckIsNullToBool(_oRow.Range[_oLO.ListColumns["PlcTag\nExternalWritable"].Index].Value);
            string _CommentUS = "Checked: ";// oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nComment\nText\n<Culture>en-US"].Index].Value);
            string _CommentUKR = "Checked: ";// oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nComment\nText\n<Culture>uk-UA"].Index].Value);

            oReturnTableEntry.sTagName = _TagName;
            if (_DataType.Equals("Int"))
            {
                oReturnTableEntry.sTagFormat = "DEC_signed";
            }
            else
            {
                oReturnTableEntry.sTagFormat = _DataType;
            }
            oReturnTableEntry.sCommentUA = _CommentUKR;
            oReturnTableEntry.sCommentUS = _CommentUS;

            return oReturnTableEntry;
        }

        //Create folder path
        private IEngineeringObject CreateFolder(ListRow _oRow, PlcSoftware _oPlcSoftware)
        {
            string currSubFldName;
            int currSubFolderCnt;
            PlcWatchAndForceTableGroup systemGroup = _oPlcSoftware.WatchAndForceTableGroup;
            PlcWatchAndForceTableUserGroupComposition groupComposition = systemGroup.Groups;
            PlcWatchAndForceTableUserGroup pathUserGroups = null;
            string lineNumber;

            IEngineeringObject oRetVal = null;

            //Init esential data
            currSubFolderCnt = 0;
            currSubFldName = GetSubFolderName(_oRow, currSubFolderCnt);
            lineNumber = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["№"].Index].Value);
            pathUserGroups = null;

            //Create folders
            //Check if exist subfolders
            if (currSubFldName == string.Empty)
            {
                oRetVal = systemGroup;
            }
            else
            {
                pathUserGroups = groupComposition.Find(currSubFldName);

                if (pathUserGroups == null)
                {
                    pathUserGroups = groupComposition.Create(currSubFldName);
                }

                pathUserGroups = GetPathUserGroups(pathUserGroups, currSubFolderCnt, _oRow);
                oRetVal = pathUserGroups;
            }


            return oRetVal;
        }

        //Import XML file into project
        private void ImportXML(object _oProject, TiaPortal _oTiaPortal )
        {

            Project tiaProject;
            //LocalSession _tiaPortalLocalSession;

            if (_oProject is Siemens.Engineering.Project)
            {
                tiaProject = (Siemens.Engineering.Project)_oProject;
                using (var access = _oTiaPortal.ExclusiveAccess("Import element"))
                {
                    if (string.IsNullOrEmpty(sXMLPath) == false)
                    {
                        using (var action = access.Transaction(tiaProject, "Import element"))
                        {
                            try
                            {
                                OpennessHelper.ImportItem(oFolderPath, sXMLPath, ImportOptions.Override);
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

           /* if (_oProject is Siemens.Engineering.Multiuser.LocalSession)
            {
                _tiaPortalLocalSession = (Siemens.Engineering.Multiuser.LocalSession)_oProject;
                using (var access = _oTiaPortal.ExclusiveAccess("Import element"))
                {
                    if (string.IsNullOrEmpty(sXMLPath) == false)
                    {
                        using (var action = access.Transaction(_tiaPortalLocalSession.Project, "Import element"))
                        {
                            try
                            {
                                OpennessHelper.ImportItem(oFolderPath, sXMLPath, ImportOptions.Override);
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

    }
}