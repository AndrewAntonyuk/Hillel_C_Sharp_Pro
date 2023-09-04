using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

interface IGenActions
{
    void CreateStatus(RichTextBox oTextBox, string sText, int iType);
    void CreateStatus(RichTextBox oTextBox, string sText);
}

namespace TestOpenessVS.Utils
{

    class GenActions: IGenActions
    {
        public void CreateStatus(RichTextBox oTextBox, string sText, int iType)
        {

            oTextBox.Select(oTextBox.TextLength, 0);
            if (iType == 1)
            {
                oTextBox.SelectionColor = Color.Black;
            }

            if (iType == 2)
            {
                oTextBox.SelectionColor = Color.Red;
            }

            if (iType == 3)
            {
                oTextBox.SelectionColor = Color.Orange;
            }

            oTextBox.AppendText(DateTime.Now.ToString("h:mm:ss tt") + "::" + sText);
            oTextBox.AppendText("\r\n");
            oTextBox.AppendText("====================================");
            oTextBox.AppendText("\r\n");
            oTextBox.ScrollToCaret();
        }

        public void CreateStatus(RichTextBox oTextBox, string sText)
        {
            oTextBox.Select(oTextBox.TextLength, 0);
            oTextBox.SelectionColor = Color.Black;

            oTextBox.AppendText(DateTime.Now.ToString("h:mm:ss tt") + "::" + sText);
            oTextBox.AppendText("\r\n");
            oTextBox.AppendText("====================================");
            oTextBox.AppendText("\r\n");
            oTextBox.ScrollToCaret();
        }

        public string CheckIsNullToString(object oInput)
        {
            string returnVal = string.Empty;
            if (oInput == null)
            {
                returnVal = string.Empty;
            }
            else
            {
                returnVal = oInput.ToString();
            }

            return returnVal;
        }
        public bool CheckIsNullToBool(object oInput)
        {
            bool returnVal = false;
            if (oInput == null)
            {
                returnVal = false;
            }
            else
            {
                returnVal = Convert.ToBoolean(oInput);
            }

            return returnVal;
        }
    }
}
