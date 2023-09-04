using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiaOpennessHelper.Utils;

namespace TestOpenessVS
{
    public partial class AssemblySelection : Form
    {
        public AssemblySelection()
        {
            AppDomain.CurrentDomain.AssemblyResolve += Resolver.OnResolve;
            InitializeComponent();            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_baseAS.SelectedAssembly)
                && !string.IsNullOrEmpty(_baseAS.SelectedVersion))
            {
                _baseAS.OnConfirmation(e);
                

                if (_baseAS.DialogResult != true)
                {
                    MessageBox.Show("No Assembly was selected.", "Shutdown");
                    return;
                }

                
                StartForm _oStartForm = new StartForm();

                del_PassAS_StartForm _PassAS_StartForm = new del_PassAS_StartForm(_oStartForm.retrieveAS_Data);
                _PassAS_StartForm(_baseAS);

                _oStartForm.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Engineering version or assemly version was not choiced!!!","WARNING!!!");
            }
           

        }
                

        private void fld_EngVersion_DropDown(object sender, EventArgs e)
        {
            _baseAS.OnGetVersions(e);

            fld_EngVersion.Items.Clear();

            foreach (string s in _baseAS.EngineeringVersions)
            {
                fld_EngVersion.Items.Add(s);
            }
            fld_EngVersion.Items.Add("");
        }

        private void fld_AssmVersion_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_baseAS.SelectedVersion))
                return;

            _baseAS.OnGetAssemblies(e);

            fld_AssmVersion.Items.Clear();

            foreach (string s in _baseAS.AssemblyVersions)
            {
                fld_AssmVersion.Items.Add(s);
            }
            fld_AssmVersion.Items.Add("");
        }

        private void fld_EngVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _baseAS.SelectedVersion = fld_EngVersion.SelectedItem.ToString();
        }

        private void fld_AssmVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _baseAS.SelectedAssembly = fld_AssmVersion.SelectedItem.ToString();
        }
    }
}
