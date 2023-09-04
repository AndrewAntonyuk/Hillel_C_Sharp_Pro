using Microsoft.Office.Interop.Excel;
using Siemens.Engineering;
using Siemens.Engineering.SW.Blocks;
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
    class DB_Create
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

        public DB_Create(ExcelData _excelData)
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
        ~DB_Create()
        {
           
        }

        //Create watchtables
        public void CreateDataBlocks(PlcSoftware oPLCSoftware, object _oProject, TiaPortal _oTiaPortal)
        {
            
            string DBName;
            string DBType;
            string lineNumber;

            PlcBlock DataBlock = null;
            XML_TIA_DB_FB oDB_FB = null;
            XML_TIA_DB_UDT oDB_UDT = null;

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
                        DBName = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["DB Name"].Index].Value);
                        lineNumber = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["№"].Index].Value);
                        DBType = oGenActions.CheckIsNullToString(_oRowTable.Range[_oLO.ListColumns["Type DB Block"].Index].Value);

                        //Check if watchtable exist
                        if (DBName == string.Empty)
                        {
                            oGenActions.CreateStatus(_oTxtStatus, "DB in line excel: " + lineNumber + " haven't DB name", 2);
                            _cntErr++;
                        }
                        else
                        {
                            //Serch watchtable in exist watchtables
                            DataBlock = OpennessHelper.FindBlockByName(oPLCSoftware, DBName);

                            //If it is new -> create new folders and watchtable
                            if (DataBlock == null)
                            {
                                
                                //Create objects for DB
                                if (DBType.Equals("Instance_FB"))
                                {
                                    oDB_FB = new XML_TIA_DB_FB();

                                    //Create object of DB
                                    oDB_FB = CreateDB_FB(_oRowTable);

                                    //Create XML file for import
                                    sXMLPath = oDB_FB.CreateXML();

                                    //Create folders
                                    oFolderPath = CreateFolder(_oRowTable, oPLCSoftware);

                                    //Import XML
                                    ImportXML(_oProject, _oTiaPortal);
                                }
                                else if (DBType.Equals("Instance_UDT"))
                                {
                                    oDB_UDT = new XML_TIA_DB_UDT();

                                    //Create object of DB
                                    oDB_UDT = CreateDB_UDT(_oRowTable);

                                    //Create XML file for import
                                    sXMLPath = oDB_UDT.CreateXML();

                                    //Create folders
                                    oFolderPath = CreateFolder(_oRowTable, oPLCSoftware);

                                    //Import XML
                                    ImportXML(_oProject, _oTiaPortal);
                                }
                                else
                                {
                                    oGenActions.CreateStatus(_oTxtStatus, "DB " + DBName + " in line excel: " + lineNumber + " has incorrect type", 2);
                                    continue;
                                }
                                                              

                            }
                            else
                            {
                                oGenActions.CreateStatus(_oTxtStatus, "DB " + DBName + " in line excel: " + lineNumber + " already exists", 2);
                            }

                        }

                        DataBlock = null;
                        oDB_FB = null;
                        oDB_UDT = null;

                    }
                   
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Exception occured: " + ex.Message);
                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
                 DataBlock = null;
                oDB_FB = null;
                oDB_UDT = null;


            }

            oGenActions.CreateStatus(_oTxtStatus, "Proccess of creating watchtables finished with " + _cntErr + " errors; " + _cntWarn + " warnings.", 3);

            //values = _oLRows[2].Range[1].Resize(Type.Missing, 5).Value;
            DataBlock = null;
            oDB_FB = null;
            oDB_UDT = null;

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


        private PlcBlockUserGroup GetPathUserGroups(PlcBlockUserGroup _oUserGrp, int _iCurrSubFld, ListRow _oRow)
        {
            PlcBlockUserGroup retUserGroup = null;
            PlcBlockUserGroup nextUserGroup = null;
            string sNextSubFldNameSet = GetSubFolderName(_oRow, _iCurrSubFld + 1);
            string sNextSubFldNameAct;
            string sElementFldName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Element folder"].Index].Value);
            nextUserGroup = _oUserGrp.Groups.Find(sElementFldName);
            if (nextUserGroup != null)
            {
                sNextSubFldNameAct = oGenActions.CheckIsNullToString(nextUserGroup.Name);
            }
            else
            {
                sNextSubFldNameAct = string.Empty;
            }

            if (sNextSubFldNameSet == string.Empty
                && !sNextSubFldNameAct.Equals(sElementFldName))
            {
                //retUserGroup = _oUserGrp;
                retUserGroup = _oUserGrp.Groups.Create(sElementFldName);
            }
            else if (sNextSubFldNameSet == string.Empty
                     && sNextSubFldNameAct.Equals(sElementFldName))
            {
                retUserGroup = nextUserGroup;
            }
            else
            {
                retUserGroup = _oUserGrp.Groups.Find(sNextSubFldNameSet);
                if (retUserGroup == null)
                {
                    retUserGroup = _oUserGrp.Groups.Create(sNextSubFldNameSet);
                }
                retUserGroup = GetPathUserGroups(retUserGroup, _iCurrSubFld + 1, _oRow);
                //retUserGroup = retUserGroup.Groups.Create(sElementFldName);            
            }
            return retUserGroup;
        }

        //Create DB instance of FB
        private XML_TIA_DB_FB CreateDB_FB( ListRow _oRow)
        {
            XML_TIA_DB_FB oReturnTableEntry = new XML_TIA_DB_FB();
            string sOptimized = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Optimized NotOptimized"].Index].Value);

            oReturnTableEntry.sCommentUA = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Comment UA"].Index].Value);
            oReturnTableEntry.sCommentUS = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Comment US"].Index].Value);
            oReturnTableEntry.sHeaderAutor = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderAuthor"].Index].Value);
            oReturnTableEntry.sHeaderFamily = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderFamily"].Index].Value);
            oReturnTableEntry.sHeaderName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderName"].Index].Value);
            oReturnTableEntry.sHeaderVersion = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderVersion"].Index].Value);
            oReturnTableEntry.sInstanceOfName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Instance name"].Index].Value);

            if (sOptimized.Equals("n.u."))
            {
                oReturnTableEntry.sMemoryLayout = string.Empty;
            }

            if (sOptimized.Equals("Standard"))
            {
                oReturnTableEntry.sMemoryLayout = "Optimized";
            }

            oReturnTableEntry.sMemoryReserve = "100";
            oReturnTableEntry.sName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["DB Name"].Index].Value);
            oReturnTableEntry.sNumber = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["DB number"].Index].Value);
            oReturnTableEntry.sTitleUA = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Title UA"].Index].Value);
            oReturnTableEntry.sTitleUS = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Title US"].Index].Value);

            return oReturnTableEntry;
        }

        //Create DB instance of UDT
        private XML_TIA_DB_UDT CreateDB_UDT(ListRow _oRow)
        {
            XML_TIA_DB_UDT oReturnTableEntry = new XML_TIA_DB_UDT();
            string sOptimized = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Optimized NotOptimized"].Index].Value);

            oReturnTableEntry.sCommentUA = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Comment UA"].Index].Value);
            oReturnTableEntry.sCommentUS = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Comment US"].Index].Value);
            oReturnTableEntry.sHeaderAutor = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderAuthor"].Index].Value);
            oReturnTableEntry.sHeaderFamily = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderFamily"].Index].Value);
            oReturnTableEntry.sHeaderName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderName"].Index].Value);
            oReturnTableEntry.sHeaderVersion = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["HeaderVersion"].Index].Value);
            oReturnTableEntry.sInstanceOfName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Instance name"].Index].Value);

            if (sOptimized.Equals("n.u."))
            {
                oReturnTableEntry.sMemoryLayout = string.Empty;
            }

            if (sOptimized.Equals("Standard"))
            {
                oReturnTableEntry.sMemoryLayout = "Optimized";
            }

            oReturnTableEntry.sMemoryReserve = "100";
            oReturnTableEntry.sName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["DB Name"].Index].Value);
            oReturnTableEntry.sNumber = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["DB number"].Index].Value);
            oReturnTableEntry.sTitleUA = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Title UA"].Index].Value);
            oReturnTableEntry.sTitleUS = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["Title US"].Index].Value);

            return oReturnTableEntry;
        }


        //Create folder path
        private IEngineeringObject CreateFolder(ListRow _oRow, PlcSoftware _oPlcSoftware)
        {
            string currSubFldName;
            int currSubFolderCnt;
            PlcBlockSystemGroup systemGroup = _oPlcSoftware.BlockGroup;
            PlcBlockUserGroupComposition groupComposition = systemGroup.Groups;
            PlcBlockUserGroup pathUserGroups = null;
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