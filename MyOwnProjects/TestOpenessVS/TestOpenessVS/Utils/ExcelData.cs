using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestOpenessVS.Utils
{
    public class ExcelData
    {
        public Microsoft.Office.Interop.Excel.Application _oXL = null;
        public  Workbook _oWB = null;
        public  Worksheet _oWSheet = null;
        public  ListObject _oLO = null;
        public  ListRows _oLRows = null;
        public string _sLO_Name = "", _sWS_Name = "";
        public  OpenFileDialog _oOpenFileDialog = null;

        Microsoft.Office.Interop.Excel.Application oXLApp = new Microsoft.Office.Interop.Excel.Application();

        public RichTextBox _oTxtStatus;
        private GenActions oGenActions = new GenActions();

        public ExcelData()
        {

        }
        public ExcelData(RichTextBox richTextBox)
        {
            _oTxtStatus = richTextBox;
        }
        public ExcelData(string workSheet)
        {
            _sWS_Name = workSheet;
        }
        public ExcelData(RichTextBox richTextBox,string workSheet)
        {
            _sWS_Name = workSheet;
            _oTxtStatus = richTextBox;
        }
        public void CloseExcel()
        {
            _oLRows = null;
            _oLO = null;
            _oWSheet = null;
            if (!(_oWB == null))
            {
                _oWB.Close();
            }
            if (!(_oXL == null))
            {
                _oXL.Quit();
            }
            
            _oWB = null;
            _oXL = null;
        }

        //Open Excel files
        public void OpenXL()
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();

            try
            {
                //Set default parameters
                oOpenFileDialog.InitialDirectory = Environment.CurrentDirectory;
                oOpenFileDialog.Title = "Choise esential file";
                oOpenFileDialog.Filter = "Excel files (*.xls, *.xlsx, *.xlm)|*.xls;*.xlsx;*.xlm";
                oOpenFileDialog.CheckFileExists = true;
                oOpenFileDialog.CheckPathExists = true;

                //Show open dialog and open excel 
                if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _oOpenFileDialog = oOpenFileDialog;
                    OpenWorkBook();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Exception occured: " + ex.Message);

                oGenActions.CreateStatus(_oTxtStatus, "Exception occured: " + ex.Message, 2);
            }

        }

        //Open workbook
        private void OpenWorkBook()
        {
            if (!string.IsNullOrEmpty(_oOpenFileDialog.FileName))
            {
                _oXL = oXLApp;
                _oWB = _oXL.Workbooks.Open(_oOpenFileDialog.FileName);

                if (_sWS_Name == string.Empty)
                {
                    _oWSheet = null;
                    _oLO = null;
                    _oLRows = null;
                    oGenActions.CreateStatus(_oTxtStatus, "Excel sheet name for create tagtables is empty!", 3);
                }
                else
                {
                    _oWSheet = _oWB.Worksheets[_sWS_Name];
                    _oLO = _oWSheet.ListObjects["Tab_" + _sWS_Name];
                    _oLRows = _oLO.ListRows;
                }

            }
            else
            {
                oGenActions.CreateStatus(_oTxtStatus, "Excel file name for create tagtables is empty!", 3);
            }
        }

    }
}
