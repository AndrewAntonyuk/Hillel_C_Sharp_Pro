using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using Siemens.Engineering;
//using Siemens.Engineering.Multiuser;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW.WatchAndForceTables;
using TiaOpennessHelper;

namespace TestOpenessVS.Utils
{
    class TagTables_Create
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

        public void RetriveStartFormData(object _oRetrived)
        {
            _oTxtStatus = (RichTextBox)_oRetrived;
        }

        public TagTables_Create(ExcelData _excelData)
        {
            excelData = _excelData;
            _oWB = excelData._oWB;
            _oWSheet = excelData._oWSheet;
            _oLO = excelData._oLO;
            _oLRows = excelData._oLRows;
            _sLO_Name = excelData._sLO_Name;
            _sWS_Name = excelData._sWS_Name;
        }
        ~TagTables_Create()
        {
            
        }
             
       
        //Create tagtables
        public void CreateTagTables(PlcSoftware oPLCSoftware, object oProject)
        {
            string currSubFldName;
            string tagTableName;
            string tagName;
            string lineNumber;
            int currSubFolderCnt;
            PlcTagTableSystemGroup systemGroup = oPLCSoftware.TagTableGroup;
            PlcTagTableUserGroupComposition groupComposition = systemGroup.Groups;
            PlcTagTableUserGroup pathUserGroups = null;
            PlcTagTable tagTable = null;
                   
            _cntErr = 0;
            _cntWarn = 0;

            try
            {
                //Open workbook
                if(excelData._oOpenFileDialog == null)                
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Apropriate excel file wasn't choiced!", 3);
                    MessageBox.Show("Please, choice apropriate excel file!", "Info!");
                }

                if (_oLRows == null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Some of Parameters for excel table is invalid (name of sheet, name of table ect.)", 2);
                }
                else
                {
                    //Go through all lines in table and creat esential groups and tagtables
                    foreach (ListRow _oLRow in _oLRows)
                    {
                        //Init esential data
                        currSubFolderCnt = 0;
                        currSubFldName = GetSubFolderName(_oLRow, currSubFolderCnt);
                        tagTableName = oGenActions.CheckIsNullToString(_oLRow.Range[_oLO.ListColumns["PlcTagTable\nName"].Index].Value);
                        tagName = oGenActions.CheckIsNullToString(_oLRow.Range[_oLO.ListColumns["PlcTag\nName"].Index].Value);
                        lineNumber = oGenActions.CheckIsNullToString(_oLRow.Range[_oLO.ListColumns["№"].Index].Value);

                        tagTable = null;
                        pathUserGroups = null;

                        //Check if tagtable exist
                        if (tagTableName == string.Empty)
                        {
                            oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + tagName + " in line excel: " + lineNumber + " haven't Tagtable name", 2);
                            _cntErr++;
                        }
                        else
                        {
                            tagTable = OpennessHelper.FindPlcTagTableByName(oPLCSoftware, tagTableName);//   systemGroup.TagTables.Find(tagTableName);
                            if (tagTable == null)
                            {
                                //Create folders
                                //Check if exist subfolders
                                if (currSubFldName == string.Empty)
                                {
                                    tagTable = systemGroup.TagTables.Create(tagTableName);
                                }
                                else
                                {
                                    pathUserGroups = groupComposition.Find(currSubFldName);

                                    if (pathUserGroups == null)
                                    {
                                        pathUserGroups = groupComposition.Create(currSubFldName);
                                    }

                                    pathUserGroups = GetPathUserGroups(pathUserGroups, currSubFolderCnt, _oLRow);
                                    tagTable = pathUserGroups.TagTables.Find(tagTableName);

                                    if (tagTable == null)
                                    {
                                        tagTable = pathUserGroups.TagTables.Create(tagTableName);
                                    }
                                }


                            }
                            //else
                            //{
                            //    oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + tagName + " in line excel: " + lineNumber + " Tagtable has already exist", 3);
                            //}
                            CreateTagInTagtable(tagTable, _oLRow, oProject, oPLCSoftware);
                        }

                    }
                }
                
            }
            catch(Exception ex)
            {
               // MessageBox.Show("Exception occured: " + ex.Message);
                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
            }


            oGenActions.CreateStatus(_oTxtStatus, "Proccess of creating tags finished with " + _cntErr + " errors; " + _cntWarn + " warnings.", 3);

            //values = _oLRows[2].Range[1].Resize(Type.Missing, 5).Value;
            
        }
      
        private string GetSubFolderName(ListRow oRow, int cntCurrSF)
        {
            string retName = string.Empty;
            try
            {
                retName = oGenActions.CheckIsNullToString(oRow.Range[_oLO.ListColumns["subfolder1"].Index + cntCurrSF].Value);                        
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Exception occured: " + ex.Message);
                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
            }
            return retName;
        }
            

        private PlcTagTableUserGroup GetPathUserGroups(PlcTagTableUserGroup _oUserGrp, int _iCurrSubFld, ListRow _oRow)
        {
            PlcTagTableUserGroup retUserGroup = null;
            string sNextSubFldName = GetSubFolderName(_oRow, _iCurrSubFld + 1);
            if(sNextSubFldName == string.Empty)
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

        private void CreateTagInTagtable(PlcTagTable _oTagTable, ListRow _oRow, object _oProject, PlcSoftware _oPLCSoftware)
        {
            PlcTag plcTag = null;
            Language englishLanguage = null;
            Language ukrainLanguage = null;
            Project tiaProject;
            Boolean tagExist = false;
            //LocalSession _tiaPortalLocalSession;
            //PlcTagTableComposition plcTagTables = null;
            IEnumerable<PlcTagTable> plcTagTables =null;

            if (_oProject is Siemens.Engineering.Project)
            {
                tiaProject = (Siemens.Engineering.Project)_oProject;
                englishLanguage = tiaProject.LanguageSettings.Languages.Find(new CultureInfo("en-US"));
                ukrainLanguage = tiaProject.LanguageSettings.Languages.Find(new CultureInfo("uk-UA"));
            }

            /*if (_oProject is Siemens.Engineering.Multiuser.LocalSession)
            {
                _tiaPortalLocalSession = (Siemens.Engineering.Multiuser.LocalSession)_oProject;
                englishLanguage = _tiaPortalLocalSession.Project.LanguageSettings.Languages.Find(new CultureInfo("en-US"));
                ukrainLanguage = _tiaPortalLocalSession.Project.LanguageSettings.Languages.Find(new CultureInfo("uk-UA"));
            }*/

            string _TagName = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nName"].Index].Value);
            string _LineNum = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["№"].Index].Value);
            string _LogicAddr = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nLogicalAddress"].Index].Value);
            string _DataType = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nDataTypeName"].Index].Value);
            bool _ExtAccess = oGenActions.CheckIsNullToBool(_oRow.Range[_oLO.ListColumns["PlcTag\nExternalAccessible"].Index].Value);
            bool _ExtVisible = oGenActions.CheckIsNullToBool(_oRow.Range[_oLO.ListColumns["PlcTag\nExternalVisible"].Index].Value);
            bool _ExtWritable = oGenActions.CheckIsNullToBool(_oRow.Range[_oLO.ListColumns["PlcTag\nExternalWritable"].Index].Value);
            string _CommentUS = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nComment\nText\n<Culture>en-US"].Index].Value);
            string _CommentUKR = oGenActions.CheckIsNullToString(_oRow.Range[_oLO.ListColumns["PlcTag\nComment\nText\n<Culture>uk-UA"].Index].Value);

            #region Check essential data
            if (_TagName == string.Empty)
            {
                oGenActions.CreateStatus(_oTxtStatus, "Tag name: ??? in line excel: " + _LineNum + " Tag haven't name", 2);
                _cntErr++;
                return;
            }
            if (_LogicAddr == string.Empty)
            {
                oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + _TagName + "in line excel: " + _LineNum + " Tag haven't logic address", 2);
                _cntErr++;
                return;
            }
            if (_DataType == string.Empty)
            {
                oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + _TagName + "in line excel: " + _LineNum + " Tag haven't datatype address", 2);
                _cntErr++;
                return;
            }            
            if (_CommentUS == string.Empty)
            {
                oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + _TagName + "in line excel: " + _LineNum + " Tag haven't comment US", 3);
                _cntWarn++;
            }
            if (_CommentUKR == string.Empty)
            {
                oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + _TagName + "in line excel: " + _LineNum + " Tag haven't comment UKR", 3);
                _cntWarn++;
            }
            #endregion


            plcTagTables = OpennessHelper.GetAllTagTables(_oPLCSoftware);// _oPLCSoftware.TagTableGroup.TagTables;//   _oTagTable.Tags.Find(_LogicAddr);

            foreach(PlcTagTable oPlcTagTable in plcTagTables)
            {
                //Check if tag with that logic address exist
                plcTag = getTagByAddress(oPlcTagTable, "%" + _LogicAddr);

                if (plcTag != null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + _TagName + "in line excel: " + _LineNum + " Address have already been", 3);
                    _cntWarn++;
                    tagExist = true;
                    break;
                }

                //Check if tag with that name exist
                plcTag = oPlcTagTable.Tags.Find(_TagName);

                if (plcTag != null)
                {
                    oGenActions.CreateStatus(_oTxtStatus, "Tag name: " + _TagName + "in line excel: " + _LineNum + " Tag have already been", 3);
                    _cntWarn++;
                    tagExist = true;
                    break;
                }
            }

            //Create tag
            if (!tagExist)
            {
                plcTag = _oTagTable.Tags.Create(_TagName);
            } else
            {
                IList<String> tagList = new List<String>();
                tagList.Add("DataTypeName");
                tagList.Add("LogicalAddress");
                tagList.Add("Name");

                IList<object> atribbutesList = plcTag.GetAttributes(tagList);

                KeyValuePair<String, object> keyValue = new KeyValuePair<string, object>("Name", _TagName);
                IList<KeyValuePair<String, object>> atribbutes = new List<KeyValuePair<String, object>>();

                atribbutes.Add(keyValue);

                //plcTag.SetAttributes(atribbutes);
                PlcTag newPlcTag = _oTagTable.Tags.Create(_TagName, _DataType, _LogicAddr);


                plcTag.Delete();
            }
            
            //Set properties
            plcTag.LogicalAddress = _LogicAddr;
            plcTag.DataTypeName = _DataType;
            plcTag.ExternalAccessible = _ExtAccess;
            plcTag.ExternalVisible = _ExtVisible;
            plcTag.ExternalWritable = _ExtWritable;

            MultilingualText comment = plcTag.Comment;
            MultilingualTextItemComposition multilingualTextItemComposition = comment.Items;
            MultilingualTextItem multilingualTextItem = multilingualTextItemComposition.Find(englishLanguage);
            if (multilingualTextItem != null)
            {
                multilingualTextItem.Text = _CommentUS;
            }

            multilingualTextItem = multilingualTextItemComposition.Find(ukrainLanguage);
            if (multilingualTextItem != null)
            {
                multilingualTextItem.Text = _CommentUKR;
            }

        }

        private PlcTag getTagByAddress(PlcTagTable oPlcTagTable, String address)
        {
            foreach (PlcTag oTag in oPlcTagTable.Tags)
            {
                if(oTag.LogicalAddress.Equals(address))
                {
                    return oTag;
                }
            }

            return null;
        }
    }
}
