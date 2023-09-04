using Microsoft.Win32;
using Siemens.Engineering;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using TestOpenessVS.Utils;
using Application = System.Windows.Application;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using Screen = Siemens.Engineering.Hmi.Screen.Screen;
using TreeView = System.Windows.Forms.TreeView;
using View = Siemens.Engineering.HW.View;
using System.Windows.Threading;
using Siemens.Engineering.Library;
using TiaOpennessHelper;
using TestOpenessVS.XML;
using System.Xml.Serialization;
using Siemens.Engineering.SW.WatchAndForceTables;
using TestOpenessVS.XML.WatchTable;
using TestOpenessVS.XML.Data_blocks;
using System.Diagnostics;
using Siemens.Engineering.SW.Tags;

namespace TestOpenessVS
{
    public partial class StartForm : Form
    {

        #region Fields

        /// <summary>The tia portal</summary>
        /// TODO Edit XML Comment Template for tiaPortal
        private TiaPortal _tiaPortal;
        /// <summary>The tia portal project</summary>
        /// TODO Edit XML Comment Template for tiaPortalProject
        private Project _tiaPortalProject;

        //Excel object for tag and watch tables
        private ExcelData _ExcelTagWatchTables = null;

        //Excel object for DB
        private ExcelData _ExcelDB = null;

        //Excel object for Program
        private ExcelData _ExcelPrg = null;

        //Local session
       // private LocalSession _tiaPortalLocalSession;

       // private static string _workingDirectory = Environment.CurrentDirectory;

        //private string _defaultExportFolderPath = Directory.GetParent(_workingDirectory).Parent.FullName + "\\ExpFolder";

       // private string _defaultImportFolderPath = Directory.GetParent(_workingDirectory).Parent.FullName + "\\ImpFolder";

        //Server project
       // private ProjectServer _tiaPortalProjectServer;

        //Create tagtables
        private TagTables_Create _TTb_Create;

        //Create watchtable
        private WatchTables_Create _WTb_Create;

        //Create DB
        private DB_Create _DB_Create;

        //Create program
        Program_Create _Program_Create;

        DelegateToCreatePrg _PassDataStartFormToPrg;
        DelegateToCreateDB _PassDataStartFormToDB;
        DelegateToCreateWatchTable _PassDataStartFormToWatchTable;
        DelegateToCreateTagTable _PassDataStartFormToTagTable;

        //Selected item
        private string _selectedItem;
        /// <summary>The tia portal projects</summary>
        /// TODO Edit XML Comment Template for tiaPortalProjects
        private ProjectComposition _tiaPortalProjects;
        /// <summary>The tia global library</summary>
        /// TODO Edit XML Comment Template for tiaGlobalLibrary
        private UserGlobalLibrary _tiaGlobalLibrary;
        /// <summary>The PLCS to compile</summary>
        /// TODO Edit XML Comment Template for plcsToCompile
        private HashSet<PlcSoftware> _plcsToCompile;

        private Transaction _action;
        private ExclusiveAccess _access;

        /// <summary>The sub window</summary>
        /// TODO Edit XML Comment Template for subWindow
        private Window _subWindow;

        /// <summary>The project name</summary>
        /// TODO Edit XML Comment Template for projectName
        private string _projectName = string.Empty;
        /// <summary>The export path</summary>
        /// TODO Edit XML Comment Template for exportPath
        private string _exportPath = string.Empty;

        private GenActions oGenActions = new GenActions();
        private static TiaPortalProcess _tiaProcess;
        private GenData oGenData = new GenData();
        #endregion

        #region Enable Bits
        /// <summary>The portal opened</summary>
        /// TODO Edit XML Comment Template for portalOpened
        private bool _portalOpened;
        /// <summary>
        /// Gets or sets a value indicating whether [portal opened].
        /// </summary>
        /// <value><c>true</c> if [portal opened]; otherwise, <c>false</c>.</value>
        /// TODO Edit XML Comment Template for PortalOpened
        public bool PortalOpened
        {
            get { return _portalOpened; }
            set
            {
                if (_portalOpened == value)
                    return;
                _portalOpened = value;
                //RaisePropertyChanged("PortalOpened");
            }
        }

        /// <summary>The project opened</summary>
        /// TODO Edit XML Comment Template for projectOpened
        private bool _projectOpened;
        /// <summary>
        /// Gets or sets a value indicating whether [project opened].
        /// </summary>
        /// <value><c>true</c> if [project opened]; otherwise, <c>false</c>.</value>
        /// TODO Edit XML Comment Template for ProjectOpened
        public bool ProjectOpened
        {
            get { return _projectOpened; }
            set
            {
                if (_projectOpened == value)
                {
                    return;
                }

                _projectOpened = value;
                // RaisePropertyChanged("ProjectOpened");
            }
        }


        #endregion


        public StartForm()
        {
            InitializeComponent();
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);

            tre_ProjectTIA.BeforeSelect += Tre_ProjectTIA_BeforeSelect;
            tre_ProjectTIA.BeforeExpand += Tre_ProjectTIA_BeforeExpand;

        }
        
        #region Events functions
        private void Tre_ProjectTIA_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {

            }
            catch
            {

            }
        }


        private void Tre_ProjectTIA_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e != null)
            {
                // throw new NotImplementedException();
                _selectedItem = e.Node.Text;
                txt_SelectedItem.Text = _selectedItem;
                btn_Delete.Enabled = true;
                btn_Export.Enabled = true;
                btn_ImportXML.Enabled = true;
                btn_CreateDB.Enabled = true;
                btn_CreateIODB.Enabled = true;
                btn_CreateTagtbl.Enabled = true;
                btn_CreateWatchTable.Enabled = true;
            }
            else
            {
                _selectedItem = string.Empty;
                txt_SelectedItem.Text = string.Empty;
                btn_Delete.Enabled = false;
                btn_Export.Enabled = false;
                btn_ImportXML.Enabled = false;
                btn_CreateDB.Enabled = false;
                btn_CreateIODB.Enabled = false;
                btn_CreateTagtbl.Enabled = false;
                btn_CreateWatchTable.Enabled = false;
            }

        }
        #endregion


        private Assembly MyResolver(object sender, ResolveEventArgs args)
        {

            int index = args.Name.IndexOf(',');
            if (index == -1)
            {
                return null;
            }
            string name = args.Name.Substring(0, index);

            RegistryKey filePathReg = Registry.LocalMachine.OpenSubKey(
                "SOFTWARE\\Siemens\\Automation\\Openness\\" + _IntAS.SelectedVersion + "\\PublicAPI\\" + _IntAS.SelectedAssembly);


            if (filePathReg == null)
                return null;

            object oRegKeyValue = filePathReg.GetValue(name);
            if (oRegKeyValue != null)
            {
                string filePath = oRegKeyValue.ToString();

                string path = filePath;
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return Assembly.LoadFrom(fullPath);
                }
            }

            return null;
        }

        #region Buttons 

        #region Buttons for manage project
        private void StartTIA(object sender, EventArgs e)
        {
            try
            {
                if (rdb_WithoutUI.Checked == true)
                {
                    _tiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);
                    oGenActions.CreateStatus(txt_Status, "TIA Portal started without user interface");
                    _tiaProcess = TiaPortal.GetProcesses()[0];
                }
                else
                {
                    _tiaPortal = new TiaPortal(TiaPortalMode.WithUserInterface);
                    oGenActions.CreateStatus(txt_Status, "TIA Portal started with user interface");
                }

                btn_SearchProject.Enabled = true;
                btn_Dispose.Enabled = true;
                btn_Start.Enabled = false;
                btn_RefreshTree.Enabled = true;
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\n" + ex, 2);
            }


        }

        private void DisposeTIA(object sender, EventArgs e)
        {
            try
            {
                _tiaPortal.Dispose();
                oGenActions.CreateStatus(txt_Status, "TIA Portal disposed", 3);
                tre_ProjectTIA.BeginUpdate();
                tre_ProjectTIA.Nodes.Clear();
                tre_ProjectTIA.EndUpdate();
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Error while opening project" + ex.Message, 2);
            }
            ProjectOpened = false;
            btn_Start.Enabled = true;
            btn_Dispose.Enabled = false;
            btn_CloseProject.Enabled = false;
            btn_SearchProject.Enabled = false;
            btn_CompileHW.Enabled = false;
            btn_Save.Enabled = false;
            btn_RefreshTree.Enabled = false;
            btn_Delete.Enabled = false;
            _selectedItem = string.Empty;
        }

        private void SearchProject(object sender, EventArgs e)
        {

            OpenFileDialog fileSearch = new OpenFileDialog();

            try
            {
                fileSearch.Filter = "(TIA files)|*.ap*;*.als*";
                fileSearch.RestoreDirectory = true;
                fileSearch.ShowDialog();

                string ProjectPath = fileSearch.FileName.ToString();

                if (string.IsNullOrEmpty(ProjectPath) == false)
                {
                    OpenProject(ProjectPath);
                }
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Error while opening project" + ex.Message, 2);
            }
        }

        private void OpenProject(string ProjectPath)
        {
            try
            {
               /* if (rb_LocalSession.Checked)
                {
                    _tiaPortalLocalSession = _tiaPortal.LocalSessions.Open(new FileInfo(ProjectPath));
                    oGenActions.CreateStatus(txt_Status, "Local session " + ProjectPath + " opened");
                    ProjectOpened = _tiaPortalLocalSession != null;
                }*/

                if (rb_Project.Checked)
                {
                    _tiaPortalProject = _tiaPortal.Projects.OpenWithUpgrade(new FileInfo(ProjectPath));
                    oGenActions.CreateStatus(txt_Status, "Project " + ProjectPath + " opened");
                    ProjectOpened = _tiaPortalProject != null;
                }

                LoadProjectTreeView();

            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Error while opening project" + ex.Message, 2);
            }

            btn_CompileHW.Enabled = true;
            btn_CloseProject.Enabled = true;
            btn_SearchProject.Enabled = false;
            btn_Save.Enabled = true;
            btn_AddHW.Enabled = true;
            btn_RefreshTree.Enabled = true;


        }

        private void btn_ConnectTIA(object sender, EventArgs e)
        {
            btn_Connect.Enabled = false;
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();

            try
            {
                switch (processes.Count)
                {
                    case 1:
                        _tiaProcess = processes[0];
                        _tiaPortal = _tiaProcess.Attach();
                        if (_tiaPortal.GetCurrentProcess().Mode == TiaPortalMode.WithUserInterface)
                        {
                            rdb_WithUI.Checked = true;
                        }
                        else
                        {
                            rdb_WithoutUI.Checked = true;
                        }


                       /* if (rb_LocalSession.Checked)
                        {
                            if (_tiaPortal.LocalSessions.Count <= 0)
                            {
                                oGenActions.CreateStatus(txt_Status, "No TIA Portal Local session was found!", 3);
                                btn_Connect.Enabled = true;
                                return;
                            }
                            _tiaPortalLocalSession = _tiaPortal.LocalSessions[0];
                            ProjectOpened = _tiaPortalLocalSession != null;
                        }*/

                        if (rb_Project.Checked)
                        {
                            if (_tiaPortal.Projects.Count <= 0)
                            {
                                oGenActions.CreateStatus(txt_Status, "No TIA Portal Project was found!", 3);
                                btn_Connect.Enabled = true;
                                return;
                            }
                            _tiaPortalProject = _tiaPortal.Projects[0];
                            ProjectOpened = _tiaPortalProject != null;
                        }

                        break;
                    case 0:
                        oGenActions.CreateStatus(txt_Status, "No running instance of TIA Portal was found!", 3);
                        btn_Connect.Enabled = true;
                        return;
                    default:
                        oGenActions.CreateStatus(txt_Status, "More than one running instance of TIA Portal was found!", 3);
                        btn_Connect.Enabled = true;
                        return;
                }

                oGenActions.CreateStatus(txt_Status, "TIA project " + _tiaProcess.ProjectPath.ToString() + " was connected");
                LoadProjectTreeView();
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r " + ex.Message, 2);
            }

            btn_Start.Enabled = false;
            btn_Connect.Enabled = true;
            btn_Dispose.Enabled = true;
            btn_CompileHW.Enabled = true;
            btn_CloseProject.Enabled = true;
            btn_SearchProject.Enabled = false;
            btn_Save.Enabled = true;
            btn_AddHW.Enabled = true;
            btn_RefreshTree.Enabled = true;
            // LoadProjectTreeView();
        }

        private void SaveProject(object sender, EventArgs e)
        {
            try
            {
                /*if (rb_LocalSession.Checked)
                {
                    _tiaPortalLocalSession.Save();
                    oGenActions.CreateStatus(txt_Status, "TIA local session " + _tiaPortalLocalSession.Project.Path + " was saved"); // .ProjectPath.ToString()
                }*/
                if (rb_Project.Checked)
                {
                    _tiaPortalProject.Save();
                    oGenActions.CreateStatus(txt_Status, "TIA project " + _tiaPortalProject.Path + " was saved"); // .ProjectPath.ToString()
                }
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r " + ex.Message, 2);
            }

        }

        private void CloseProject(object sender, EventArgs e)
        {
            try
            {
               /* if (rb_LocalSession.Checked)
                {
                    oGenActions.CreateStatus(txt_Status, "TIA local session " + _tiaPortalLocalSession.Project.Path.ToString() + " was closed");
                    _tiaPortalLocalSession.Close();
                }*/
                if (rb_Project.Checked)
                {
                    oGenActions.CreateStatus(txt_Status, "TIA project " + _tiaPortalProject.Path.ToString() + " was closed");
                    _tiaPortalProject.Close();
                }

                ProjectOpened = false;

                tre_ProjectTIA.BeginUpdate();
                tre_ProjectTIA.Nodes.Clear();
                tre_ProjectTIA.EndUpdate();

            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }

            btn_SearchProject.Enabled = true;
            btn_CloseProject.Enabled = false;
            btn_Save.Enabled = false;
            btn_CompileHW.Enabled = false;
            btn_RefreshTree.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Export.Enabled = false;
            btn_ImportXML.Enabled = false;
            btn_CreateDB.Enabled = false;
            btn_CreateIODB.Enabled = false;
            btn_CreateTagtbl.Enabled = false;
            btn_CreateWatchTable.Enabled = false;
            _selectedItem = string.Empty;
        }

        private void Compile(object sender, EventArgs e)
        {
            btn_CompileHW.Enabled = false;

            string devname = _selectedItem;//  txt_Device.Text;
            bool found = false;

            DeviceComposition devices = null;

            try
            {
                /*if (rb_LocalSession.Checked)
                {
                    devices = _tiaPortalLocalSession.Project.Devices;
                }*/
                if (rb_Project.Checked)
                {
                    devices = _tiaPortalProject.Devices;
                }

                foreach (Device device in devices)
                {
                    DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                    foreach (DeviceItem deviceItem in deviceItemAggregation)
                    {
                        if (deviceItem.Name == devname || device.Name == devname)
                        {
                            SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                            if (softwareContainer != null)
                            {
                                if (softwareContainer.Software is PlcSoftware)
                                {
                                    PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                    if (controllerTarget != null)
                                    {
                                        found = true;
                                        ICompilable compiler = controllerTarget.GetService<ICompilable>();

                                        CompilerResult result = compiler.Compile();
                                        oGenActions.CreateStatus(txt_Status, "Compiling of " + controllerTarget.Name + ": State: " + result.State + " / Warning Count: " + result.WarningCount + " / Error Count: " + result.ErrorCount);

                                    }
                                }
                                if (softwareContainer.Software is HmiTarget)
                                {
                                    HmiTarget hmitarget = softwareContainer.Software as HmiTarget;
                                    if (hmitarget != null)
                                    {
                                        found = true;
                                        ICompilable compiler = hmitarget.GetService<ICompilable>();
                                        CompilerResult result = compiler.Compile();
                                        oGenActions.CreateStatus(txt_Status, "Compiling of " + hmitarget.Name + ": State: " + result.State + " / Warning Count: " + result.WarningCount + " / Error Count: " + result.ErrorCount);
                                    }

                                }
                            }
                        }
                    }
                }

                if (found == false)
                {
                    oGenActions.CreateStatus(txt_Status, "Found no device with name " + _selectedItem, 2); // txt_Device.Text, 2);
                }

                btn_CompileHW.Enabled = true;
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }


        }

        private void btn_AddHW_Click(object sender, EventArgs e)
        {
            btn_AddHW.Enabled = false;
            string MLFB = "OrderNumber:" + txt_OrderNo.Text + "/" + txt_Version.Text;

            string name = txt_AddDevice.Text;
            string devname = "station" + txt_AddDevice.Text;
            bool found = false;

            DeviceComposition devices = null;

            try
            {
               /* if (rb_LocalSession.Checked)
                {
                    devices = _tiaPortalLocalSession.Project.Devices;
                }*/
                if (rb_Project.Checked)
                {
                    devices = _tiaPortalProject.Devices;
                }


                foreach (Device device in devices) //_tiaPortalProject.Devices
                {
                    DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                    foreach (DeviceItem deviceItem in deviceItemAggregation)
                    {
                        if (deviceItem.Name == devname || device.Name == devname
                            || deviceItem.Name == name || device.Name == name)
                        {
                            SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                            if (softwareContainer != null)
                            {
                                if (softwareContainer.Software is PlcSoftware)
                                {
                                    PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                    if (controllerTarget != null)
                                    {
                                        found = true;

                                    }
                                }
                                if (softwareContainer.Software is HmiTarget)
                                {
                                    HmiTarget hmitarget = softwareContainer.Software as HmiTarget;
                                    if (hmitarget != null)
                                    {
                                        found = true;

                                    }

                                }
                            }
                        }
                    }
                }
                if (found == true)
                {
                    //txt_Status.Text = "Device " + _selectedItem + " already exists"; //txt_Device.Text
                    oGenActions.CreateStatus(txt_Status, "Device " + _selectedItem + " already exists", 3);
                }
                else
                {
                    Device deviceName = null;
                   /* if (rb_LocalSession.Checked)
                    {
                        deviceName = _tiaPortalLocalSession.Project.Devices.CreateWithItem(MLFB, name, devname);
                    }*/
                    if (rb_Project.Checked)
                    {
                        deviceName = _tiaPortalProject.Devices.CreateWithItem(MLFB, name, devname);
                    }

                    LoadProjectTreeView();
                    // txt_Status.Text = "Add Device Name: " + name + " with Order Number: " + txt_OrderNo.Text + " and Firmware Version: " + txt_Version.Text;
                    oGenActions.CreateStatus(txt_Status, "Add Device Name: " + name + " with Order Number: " + txt_OrderNo.Text + " and Firmware Version: " + txt_Version.Text);
                }
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }

            btn_AddHW.Enabled = true;

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            btn_Delete.Enabled = false;

            if (tre_ProjectTIA.SelectedNode != null)//  ProjectTree.SelectedItem != null)
            {
                var selectedProjectObject = tre_ProjectTIA.SelectedNode.Tag;

                try
                {
                    // most SystemFolder don't have a Name property
                    var engineeringObject = selectedProjectObject as IEngineeringObject;
                    engineeringObject?.Invoke("Delete", new Dictionary<Type, object>());
                    var deletedItemName = OpennessHelper.GetObjectName(selectedProjectObject as IEngineeringInstance);
                    LoadProjectTreeView();
                    oGenActions.CreateStatus(txt_Status, "Deleted item " + deletedItemName);
                    //WriteStatusEntry("Deleted item " + deletedItemName);
                }
                catch (EngineeringException)
                {
                    // WriteStatusEntry("The selected Item cannot be deleted");
                    oGenActions.CreateStatus(txt_Status, "The selected Item cannot be deleted", 3);
                }
            }
            else
            {
                //DeleteItem = false;
                // WriteStatusEntry("No target selected");
                oGenActions.CreateStatus(txt_Status, "No target selected", 3);
            }

            btn_Delete.Enabled = true;
        }

        private void btn_RefreshTree_Click(object sender, EventArgs e)
        {
            LoadProjectTreeView();
        }
        #endregion

        #region Choice Excel
        private void btn_ChoiceFileCreateTagTbl_Click(object sender, EventArgs e)
        {
            if (_ExcelTagWatchTables == null)
                _ExcelTagWatchTables = new ExcelData(txt_Status, txtb_SheetName.Text);

            _ExcelTagWatchTables.OpenXL();
            if (_ExcelTagWatchTables._oOpenFileDialog != null)
            {
                tbx_FileForCreateTagTables.Text = _ExcelTagWatchTables._oOpenFileDialog.FileName;
                oGenActions.CreateStatus(txt_Status, "Excel file: " + _ExcelTagWatchTables._oOpenFileDialog.FileName + " was opened for create tagtables");
            }
        }

        private void btn_ChoiceFileCreateDB_Click(object sender, EventArgs e)
        {
            if (_ExcelDB == null)
                _ExcelDB = new ExcelData(txt_Status, txtb_SheetNameDB.Text);

            _ExcelDB.OpenXL();
            if (_ExcelDB._oOpenFileDialog != null)
            {
                tbx_FileForCreateDB.Text = _ExcelDB._oOpenFileDialog.FileName;
                oGenActions.CreateStatus(txt_Status, "Excel file: " + _ExcelDB._oOpenFileDialog.FileName + " was opened for create tagtables");
            }
        }

        private void btn_ChoiceFileCreatePrg_Click(object sender, EventArgs e)
        {
            if (_ExcelPrg == null)
                _ExcelPrg = new ExcelData(txt_Status, txtb_SheetNamePrg.Text);

            _ExcelPrg.OpenXL();
            if (_ExcelPrg._oOpenFileDialog != null)
            {
                tbx_FileForCreatePrg.Text = _ExcelPrg._oOpenFileDialog.FileName;
                oGenActions.CreateStatus(txt_Status, "Excel file: " + _ExcelPrg._oOpenFileDialog.FileName + " was opened for create tagtables");
            }
        }

        #endregion

        #region Close Excel
        private void btn_CloseFileCreateTagTbl_MouseUp(object sender, MouseEventArgs e)
        {
            if(!(_ExcelTagWatchTables==null))
            {
                oGenActions.CreateStatus(txt_Status, "Excel file: " + _ExcelTagWatchTables._oOpenFileDialog.FileName + " was closed");
                _ExcelTagWatchTables.CloseExcel();
                tbx_FileForCreateTagTables.Text = string.Empty;
            }
        }

        private void btn_CloseFileCreateDB_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (!(_ExcelDB == null))
            {
                oGenActions.CreateStatus(txt_Status, "Excel file: " + _ExcelDB._oOpenFileDialog.FileName + " was closed");
                _ExcelDB.CloseExcel();
                tbx_FileForCreateDB.Text = string.Empty;
            }
        }

        private void btn_CloseFileCreatePrg_MouseUp(object sender, MouseEventArgs e)
        {
            if (!(_ExcelPrg == null))
            {
                oGenActions.CreateStatus(txt_Status, "Excel file: " + _ExcelPrg._oOpenFileDialog.FileName + " was closed");
                _ExcelPrg.CloseExcel();
                tbx_FileForCreatePrg.Text = string.Empty;
            }
        }

        #endregion

        #region Buttons for create, import, export elements
        private void btn_CreateTagtbl_Click(object sender, EventArgs e)
        {
            object tiaProjectObj = null;

            /*if (rb_LocalSession.Checked)
            {
                tiaProjectObj = _tiaPortalLocalSession;
            }*/

            if (rb_Project.Checked)
            {
                tiaProjectObj = _tiaPortalProject;
            }
            try
            {
                _TTb_Create = new TagTables_Create(_ExcelTagWatchTables);
                _PassDataStartFormToTagTable = new DelegateToCreateTagTable(_TTb_Create.RetriveStartFormData);
                _PassDataStartFormToTagTable(txt_Status);

                if (_selectedItem != null)
                {
                    string devname = _selectedItem;//  txt_Device.Text;
                    bool found = false;

                    DeviceComposition devices = null;


                   /* if (rb_LocalSession.Checked)
                    {
                        devices = _tiaPortalLocalSession.Project.Devices;
                    }*/
                    if (rb_Project.Checked)
                    {
                        devices = _tiaPortalProject.Devices;
                    }

                    foreach (Device device in devices)
                    {
                        DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                        foreach (DeviceItem deviceItem in deviceItemAggregation)
                        {
                            if (deviceItem.Name == devname || device.Name == devname)
                            {
                                SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                                if (softwareContainer != null)
                                {
                                    if (softwareContainer.Software is PlcSoftware)
                                    {
                                        PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                        if (controllerTarget != null)
                                        {
                                            found = true;
                                            oGenActions.CreateStatus(txt_Status, "Create tagtables for " + controllerTarget.Name + " started");
                                            _TTb_Create.CreateTagTables(controllerTarget, tiaProjectObj);
                                            LoadProjectTreeView();
                                            oGenActions.CreateStatus(txt_Status, "Create tagtables for " + controllerTarget.Name + " finished");
                                        }
                                    }

                                }
                            }
                        }
                    }

                    if (found == false)
                    {
                        oGenActions.CreateStatus(txt_Status, "Found no PLC with name " + _selectedItem, 2); // txt_Device.Text, 2);
                    }

                }
                else
                {
                    oGenActions.CreateStatus(txt_Status, "Device for create tagtable wasn't choice", 3);
                }

            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            bool IsLoading = false;

            if (_selectedItem != null)
            {
                _exportPath = Path.Combine(oGenData._defaultExportFolderPath, _projectName);
                var current = tre_ProjectTIA.SelectedNode.Tag;

                //var exportTask = Task<int>.Factory.StartNew(() =>
                //{
                IsLoading = true;
                oGenActions.CreateStatus(txt_Status, "Start Export");

                try
                {
                    /* if (_exportOptionsDefaults && _exportOptionsReadOnly)
                         OpennessHelper.ExportStructure(current as IEngineeringCompositionOrObject, ExportOptions.WithDefaults | ExportOptions.WithReadOnly, _exportPath);
                     else if (_exportOptionsDefaults)
                         OpennessHelper.ExportStructure(current as IEngineeringCompositionOrObject, ExportOptions.WithDefaults, _exportPath);
                     else if (_exportOptionsReadOnly)
                         OpennessHelper.ExportStructure(current as IEngineeringCompositionOrObject, ExportOptions.WithReadOnly, _exportPath);
                     else
                         OpennessHelper.ExportStructure(current as IEngineeringCompositionOrObject, ExportOptions.None, _exportPath);
                    */
                    OpennessHelper.ExportStructure(current as IEngineeringCompositionOrObject, ExportOptions.None, _exportPath);
                    oGenActions.CreateStatus(txt_Status, "Export successful");

                }
                catch (EngineeringTargetInvocationException invoEx)
                {
                    oGenActions.CreateStatus(txt_Status, "Export failed: " + invoEx.Message, 2);
                }
                catch (EngineeringException ee)
                {
                    oGenActions.CreateStatus(txt_Status, "Export failed: " + ee.Message, 2);
                }
                catch (ArgumentException ae)
                {
                    oGenActions.CreateStatus(txt_Status, "Export failed: " + ae.Message, 2);
                }
                catch (IOException ie)
                {
                    oGenActions.CreateStatus(txt_Status, "Export failed: " + ie.Message, 2);
                }
                IsLoading = false;
            }
        }

        private void btn_ImportXML_Click(object sender, EventArgs e)
        {
            bool IsLoading = false;

            if (_selectedItem != null)
            {
                var current = tre_ProjectTIA.SelectedNode.Tag;

                 var fileSearch = new OpenFileDialog();
                 fileSearch.InitialDirectory = oGenData._defaultImportFolderPath;
                 fileSearch.Filter = "xml File|*.xml|SCL|*.scl|DB|*.db|AWL|*.awl|UDT|*.udt|All files(*.*)|*.*";
                 fileSearch.FilterIndex = 1;
                 fileSearch.RestoreDirectory = true;
                 fileSearch.Multiselect = true;
                 var result = fileSearch.ShowDialog();
                
                if ( result == true)
                {
                    if (fileSearch.FileNames != null)
                    {

                        IsLoading = true;
                        oGenActions.CreateStatus(txt_Status, "Start Import");

                        using (var access = _tiaPortal.ExclusiveAccess("Import element"))
                        {
                            foreach (var file in fileSearch.FileNames)
                            {
                                if (string.IsNullOrEmpty(file) == false)
                                {
                                    using (var action = access.Transaction(_tiaPortalProject, "Import element"))
                                    {
                                        try
                                        {
                                            OpennessHelper.ImportItem(current as IEngineeringObject, file, ImportOptions.Override);
                                            action.CommitOnDispose();
                                        }
                                        catch (EngineeringException invoEx)
                                        {
                                            IsLoading = false;
                                            oGenActions.CreateStatus(txt_Status, "Import failed: " + invoEx.Message, 2);
                                        }
                                        catch (ArgumentException ae)
                                        {
                                            IsLoading = false;
                                            oGenActions.CreateStatus(txt_Status, "Import failed: " + ae.Message, 2);
                                        }
                                        catch (IOException ie)
                                        {
                                            IsLoading = false;
                                            oGenActions.CreateStatus(txt_Status, "Import failed: " + ie.Message, 2);
                                        }
                                    }
                                }
                            }
                        }

                        LoadProjectTreeView();
                        IsLoading = false;
                        oGenActions.CreateStatus(txt_Status, "Import finished");
                    }
                }
                else
                {
                    oGenActions.CreateStatus(txt_Status, "Import cancelled");
                }

                

                /*
                var fileSearch = new FolderBrowserDialog();
                fileSearch.SelectedPath = _defaultExportFolderPath;
                var result = fileSearch.ShowDialog();
                if (!(String.IsNullOrEmpty(result.ToString())) 
                    && !((String.IsNullOrEmpty(fileSearch.SelectedPath.ToString()))))
                {
                    if (result.ToString() != "")
                    {

                        IsLoading = true;
                        oGenActions.CreateStatus(txt_Status, "Start Import");

                        using (var access = _tiaPortal.ExclusiveAccess("Import element"))
                        {
                            
                            using (var action = access.Transaction(_tiaPortalProject, "Import element"))
                            {
                                try
                                {
                                    //OpennessHelper.ImportItem(current as IEngineeringObject, file, ImportOptions.Override);
                                    OpennessHelper.ImportStructure(current as IEngineeringObject, fileSearch.SelectedPath.ToString(), ImportOptions.Override);
                                    action.CommitOnDispose();
                                }
                                catch (EngineeringException invoEx)
                                {
                                    IsLoading = false;
                                    oGenActions.CreateStatus(txt_Status, "Import failed: " + invoEx.Message, 2);
                                }
                                catch (ArgumentException ae)
                                {
                                    IsLoading = false;
                                    oGenActions.CreateStatus(txt_Status, "Import failed: " + ae.Message, 2);
                                }
                                catch (IOException ie)
                                {
                                    IsLoading = false;
                                    oGenActions.CreateStatus(txt_Status, "Import failed: " + ie.Message, 2);
                                }
                            }
                             
                        }

                        LoadProjectTreeView();
                        IsLoading = false;
                        oGenActions.CreateStatus(txt_Status, "Import finished");
                    }
                }
                else
                {
                    oGenActions.CreateStatus(txt_Status, "Import cancelled");
                }
                */

            }
        }

        private void btn_CreateXML_ByClass_Click(object sender, EventArgs e)
        {

            //XML_TIA_DB_Global o_TestObj = new XML_TIA_DB_Global();

            //o_TestObj.sHeaderAutor = "AV";
            //o_TestObj.sName = "SrakaGlobalDB";
            //o_TestObj.sNumber = "777";

            //o_TestObj.CreateTagInGlobalDB("TestIntTag", "Int", "Bladskyy comment Int");
            // o_TestObj.CreateTagInGlobalDB("TestBoolTag", "Bool");
            // o_TestObj.CreateTagInGlobalDB("TestRealTag", "Real", "Bladskyy comment Real");

            // o_TestObj.CreateXML();

            XML_TIA_TagBase oTag = new XML_TIA_TagBase();

            oTag.sName = "I_TestTag_BlaBlaBla";
            oTag.sLogicalAddress = "I0.0";
            oTag.sCommentUA = "Test comment UA blablabla";
            oTag.sCommentUS = "Test comment US blablabla";

            oTag.CreateXML();

            /* XML_TIA_WatchTable o_TestObj = new XML_TIA_WatchTable();
             o_TestObj.s_Name = "Pysdos";

             o_TestObj.CreateXML();
            */
        }

        private void btn_CreateWatchTable_Click(object sender, EventArgs e)
        {
            object tiaProjectObj = null;

           /* if (rb_LocalSession.Checked)
            {
                tiaProjectObj = _tiaPortalLocalSession;
            }*/

            if (rb_Project.Checked)
            {
                tiaProjectObj = _tiaPortalProject;
            }
            try
            {
                _WTb_Create = new WatchTables_Create(_ExcelTagWatchTables);
                _PassDataStartFormToWatchTable = new DelegateToCreateWatchTable(_WTb_Create.RetriveStartFormData);
                _PassDataStartFormToWatchTable(txt_Status);

                if (_selectedItem != null)
                {
                    string devname = _selectedItem;//  txt_Device.Text;
                    bool found = false;

                    DeviceComposition devices = null;


                   /* if (rb_LocalSession.Checked)
                    {
                        devices = _tiaPortalLocalSession.Project.Devices;
                    }*/
                    if (rb_Project.Checked)
                    {
                        devices = _tiaPortalProject.Devices;
                    }

                    foreach (Device device in devices)
                    {
                        DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                        foreach (DeviceItem deviceItem in deviceItemAggregation)
                        {
                            if (deviceItem.Name == devname || device.Name == devname)
                            {
                                SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                                if (softwareContainer != null)
                                {
                                    if (softwareContainer.Software is PlcSoftware)
                                    {
                                        PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                        if (controllerTarget != null)
                                        {
                                            found = true;
                                            oGenActions.CreateStatus(txt_Status, "Create watchtables for " + controllerTarget.Name + " started");
                                            _WTb_Create.CreateWatchTables(controllerTarget, tiaProjectObj, _tiaPortal);
                                            LoadProjectTreeView();
                                            oGenActions.CreateStatus(txt_Status, "Create watchtables for " + controllerTarget.Name + " finished");
                                        }
                                    }

                                }
                            }
                        }
                    }

                    if (found == false)
                    {
                        oGenActions.CreateStatus(txt_Status, "Found no PLC with name " + _selectedItem, 2); // txt_Device.Text, 2);
                    }

                }
                else
                {
                    oGenActions.CreateStatus(txt_Status, "Device for create watchtables wasn't choice", 3);
                }

            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }

        }

        private void btn_CreateDB_Click(object sender, EventArgs e)
        {
            object tiaProjectObj = null;

          /*  if (rb_LocalSession.Checked)
            {
                tiaProjectObj = _tiaPortalLocalSession;
            }*/

            if (rb_Project.Checked)
            {
                tiaProjectObj = _tiaPortalProject;
            }
            try
            {
                _DB_Create = new DB_Create(_ExcelDB);
                _PassDataStartFormToDB = new DelegateToCreateDB(_DB_Create.RetriveStartFormData);
                _PassDataStartFormToDB(txt_Status);

                if (_selectedItem != null)
                {
                    string devname = _selectedItem;//  txt_Device.Text;
                    bool found = false;

                    DeviceComposition devices = null;


                   /* if (rb_LocalSession.Checked)
                    {
                        devices = _tiaPortalLocalSession.Project.Devices;
                    }*/
                    if (rb_Project.Checked)
                    {
                        devices = _tiaPortalProject.Devices;
                    }

                    foreach (Device device in devices)
                    {
                        DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                        foreach (DeviceItem deviceItem in deviceItemAggregation)
                        {
                            if (deviceItem.Name == devname || device.Name == devname)
                            {
                                SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                                if (softwareContainer != null)
                                {
                                    if (softwareContainer.Software is PlcSoftware)
                                    {
                                        PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                        if (controllerTarget != null)
                                        {
                                            found = true;
                                            oGenActions.CreateStatus(txt_Status, "Create DB for " + controllerTarget.Name + " started");
                                            _DB_Create.CreateDataBlocks(controllerTarget, tiaProjectObj, _tiaPortal);
                                            LoadProjectTreeView();
                                            oGenActions.CreateStatus(txt_Status, "Create DB for " + controllerTarget.Name + " finished");

                                        }
                                    }

                                }
                            }
                        }
                    }

                    if (found == false)
                    {
                        oGenActions.CreateStatus(txt_Status, "Found no PLC with name " + _selectedItem, 2); // txt_Device.Text, 2);
                    }

                }
                else
                {
                    oGenActions.CreateStatus(txt_Status, "Device for create instance DB wasn't choice", 3);
                }

            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }

        }

        private void btn_CreateIODB_Click(object sender, EventArgs e)
        {
            object tiaProjectObj = null;

           /* if (rb_LocalSession.Checked)
            {
                tiaProjectObj = _tiaPortalLocalSession;
            }*/

            if (rb_Project.Checked)
            {
                tiaProjectObj = _tiaPortalProject;
            }
            try
            {
                Program_Create oProgram_Create = new Program_Create(_ExcelPrg);
                _PassDataStartFormToPrg = new DelegateToCreatePrg(oProgram_Create.RetriveStartFormData);
                _PassDataStartFormToPrg(txt_Status);

                if (_selectedItem != null)
                {
                    string devname = _selectedItem;//  txt_Device.Text;
                    bool found = false;

                    DeviceComposition devices = null;


                    /*if (rb_LocalSession.Checked)
                    {
                        devices = _tiaPortalLocalSession.Project.Devices;
                    }*/
                    if (rb_Project.Checked)
                    {
                        devices = _tiaPortalProject.Devices;
                    }

                    foreach (Device device in devices)
                    {
                        DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                        foreach (DeviceItem deviceItem in deviceItemAggregation)
                        {
                            if (deviceItem.Name == devname || device.Name == devname)
                            {
                                SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                                if (softwareContainer != null)
                                {
                                    if (softwareContainer.Software is PlcSoftware)
                                    {
                                        PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                        if (controllerTarget != null)
                                        {
                                            found = true;

                                            oGenActions.CreateStatus(txt_Status, "Create IO DB for " + controllerTarget.Name + " started");
                                            oProgram_Create.CreateIODB(controllerTarget, tiaProjectObj, _tiaPortal);
                                            LoadProjectTreeView();
                                            oGenActions.CreateStatus(txt_Status, "Create IO DB for " + controllerTarget.Name + " finished");
                                        }
                                    }

                                }
                            }
                        }
                    }

                    if (found == false)
                    {
                        oGenActions.CreateStatus(txt_Status, "Found no PLC with name " + _selectedItem, 2); // txt_Device.Text, 2);
                    }

                }
                else
                {
                    oGenActions.CreateStatus(txt_Status, "Device for create DB for I/O wasn't choice", 3);
                }

            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }
        }

        private void btn_CreatePrg_Click(object sender, EventArgs e)
        {

            _Program_Create = new Program_Create(_ExcelPrg);
            _PassDataStartFormToPrg = new DelegateToCreatePrg(_Program_Create.RetriveStartFormData);
            _PassDataStartFormToPrg(txt_Status);

            oGenActions.CreateStatus(txt_Status, "Create program from file " + _ExcelPrg._oOpenFileDialog.FileName + " started");
            _Program_Create.CreateProgram();
            oGenActions.CreateStatus(txt_Status, "Create program from file " + _ExcelPrg._oOpenFileDialog.FileName + " finished");
                    

            //For help file
            //string appPath = Assembly.GetEntryAssembly().Location;
            //string filename = Path.Combine(Path.GetDirectoryName(appPath), "Help.htm");
            //Process.Start(filename);

        }

        #endregion

        #endregion

        #region Sys functions
        /// <summary>Loads the project TreeView.</summary>
        /// TODO Edit XML Comment Template for LoadProjectTreeView
        private void LoadProjectTreeView()
        {

            TreeNode treeNode = new TreeNode();
            DeviceUserGroupComposition deviceUserGroups = null;
            try
            {
                tre_ProjectTIA.BeginUpdate();
                if (ProjectOpened)
                {
                    tre_ProjectTIA.Nodes.Clear();
                    DeviceComposition devices = null;
                    // ReSharper disable once PossibleNullReferenceException
                   /* if (rb_LocalSession.Checked)
                    {
                        var splitPath = _tiaPortalLocalSession.Project.Path.ToString().Split('\\');
                        _projectName = splitPath[splitPath.Length - 1];
                        treeNode.Name = _projectName;
                        treeNode.Text = _projectName;
                        treeNode.Tag = _tiaPortalLocalSession;
                        devices = _tiaPortalLocalSession.Project.Devices;
                        deviceUserGroups = _tiaPortalLocalSession.Project.DeviceGroups;
                    }*/

                    if (rb_Project.Checked)
                    {
                        var splitPath = _tiaPortalProject.Path.ToString().Split('\\');
                        _projectName = splitPath[splitPath.Length - 1];
                        treeNode.Name = _projectName;
                        treeNode.Text = _projectName;
                        treeNode.Tag = _tiaPortalProject;
                        devices = _tiaPortalProject.Devices;
                        deviceUserGroups = _tiaPortalProject.DeviceGroups;
                    }

                    //expand Item
                    //treeNode.ExpandSubtree();


                    foreach (var device in devices)
                    {
                        var item = CreateDeviceTreeViewItem(device);

                        tre_ProjectTIA.Nodes.Add(item);
                    }

                    foreach (var folder in deviceUserGroups)
                    {
                        treeNode.Nodes.Clear();
                        FolderCrawler(treeNode, folder);
                        tre_ProjectTIA.Nodes.Add(treeNode);
                    }

                    if (rb_Project.Checked)
                    {
                        #region Multilingual graphics
                        tre_ProjectTIA.Nodes.Add(OpennessTreeViewsForms.GetGraphicsTreeView(_tiaPortalProject));
                        #endregion
                    }

                }
                else
                {
                    //projectTreeViewItem.Header = "TIA Portal without project connected";

                    //projectTreeView.Items.Add(projectTreeViewItem);
                    tre_ProjectTIA.Nodes.Clear();
                    tre_ProjectTIA.Nodes.Add("TIA Portal without project connected");
                }
                tre_ProjectTIA.EndUpdate();
            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }


        }

        /// <summary>Creates the device TreeView item.</summary>
        /// <param name="device">The device.</param>
        /// <returns>TreeViewItem</returns>
        /// TODO Edit XML Comment Template for CreateDeviceTreeViewItem
        private static TreeNode CreateDeviceTreeViewItem(Device device)
        {
            var hw = OpennessTreeViewsForms.GetHardwareTreeView(device);
            TreeNode plc = null;
            TreeNode hmi = null;
            TreeNode item = null;

            var plcSoftware = OpennessHelper.GetPlcSoftware(device);
            var hmiTarget = OpennessHelper.GetHmiTarget(device);

            if (plcSoftware != null)
            {
                plc = new TreeNode();
                plc.Name = plcSoftware.Name;
                plc.Text = plcSoftware.Name;
                plc.Tag = plcSoftware;
                if (hmiTarget == null)
                    plc.Nodes.Add(hw);

                #region Program blocks
                //TreeViewItem for Blocks
                var blocks = OpennessTreeViewsForms.GetBlocksTreeView(plcSoftware);
                plc.Nodes.Add(blocks);
                #endregion

                #region Tag Tables
                //TreeViewItem for TagTables
                var tagTables = OpennessTreeViewsForms.GetTagTablesTreeView(plcSoftware);
                plc.Nodes.Add(tagTables);
                #endregion

                #region Watch and Force Tables
                //TreeViewItem for TagTables
                var watchForceTables = OpennessTreeViewsForms.GetWatchAndForceTablesTreeView(plcSoftware);
                plc.Nodes.Add(watchForceTables);
                #endregion

                #region UDTs
                //TreeViewItem for UDTs
                var udts = OpennessTreeViewsForms.GetDatatypesTreeView(plcSoftware);
                plc.Nodes.Add(udts);
                #endregion

                #region Extrenal source files
                // TreeViewItem for External source files
                var ext = OpennessTreeViewsForms.GetExternalSourceFilesTreeView(plcSoftware);
                plc.Nodes.Add(ext);
                #endregion

                item = plc;
            }

            if (hmiTarget != null)
            {
                hmi = new TreeNode();
                hmi.Name = hw.Name;
                hmi.Text = hw.Name;
                hmi.Tag = hmiTarget;
                if (plcSoftware == null)
                    hmi.Nodes.Add(hw);

                #region ScreenOverview
                var screenOverview = new TreeNode
                {
                    Name = "ScreenOverview",
                    Text = "ScreenOverview",
                    Tag = hmiTarget.ScreenOverview
                };
                hmi.Nodes.Add(screenOverview);
                #endregion

                #region ScreenGlobalElements
                var screenGlobalElements = new TreeNode
                {
                    Name = "ScreenGlobalElements",
                    Text = "ScreenGlobalElements",
                    Tag = hmiTarget.ScreenGlobalElements
                };
                hmi.Nodes.Add(screenGlobalElements);
                #endregion

                #region Screens
                var screens = OpennessTreeViewsForms.GetScreensTreeView(hmiTarget);
                hmi.Nodes.Add(screens);
                #endregion

                #region ScreenTemplates
                var templates = OpennessTreeViewsForms.GetScreenTemplatesTreeView(hmiTarget);
                hmi.Nodes.Add(templates);
                #endregion

                #region PopUps
                var popUps = OpennessTreeViewsForms.GetScreenPopupTreeView(hmiTarget);
                hmi.Nodes.Add(popUps);
                #endregion

                #region SlideIns
                var slideIns = OpennessTreeViewsForms.GetScreenSlideInTreeView(hmiTarget);
                hmi.Nodes.Add(slideIns);
                #endregion

                #region TagTables
                var tagtables = OpennessTreeViewsForms.GetTagTablesTreeView(hmiTarget);
                hmi.Nodes.Add(tagtables);
                #endregion

                #region Cycles
                var cycles = OpennessTreeViewsForms.GetCyclesTreeView(hmiTarget);
                hmi.Nodes.Add(cycles);
                #endregion

                #region Connections
                var connections = OpennessTreeViewsForms.GetConnectionsTreeView(hmiTarget);
                hmi.Nodes.Add(connections);
                #endregion

                #region VBScripts
                var vbScripts = OpennessTreeViewsForms.GetScriptsTreeView(hmiTarget);
                hmi.Nodes.Add(vbScripts);
                #endregion

                #region GraphicLists
                var graphicLists = new TreeNode
                {
                    Name = "GraphicLists",
                    Text = "GraphicLists",
                    Tag = hmiTarget.GraphicLists
                };
                foreach (var list in hmiTarget.GraphicLists)
                {
                    graphicLists.Nodes.Add(new TreeNode { Name = list.Name, Text = list.Name, Tag = list });
                }
                hmi.Nodes.Add(graphicLists);
                #endregion

                #region TextLists
                var textLists = new TreeNode
                {
                    Name = "TextLists",
                    Tag = hmiTarget.TextLists
                };
                foreach (var list in hmiTarget.TextLists)
                {
                    textLists.Nodes.Add(new TreeNode { Name = list.Name, Text = list.Name, Tag = list });
                }
                hmi.Nodes.Add(textLists);
                #endregion

                item = hmi;
            }

            if (plcSoftware != null && hmiTarget != null && plc != null && hmi != null)
            {
                item = new TreeNode();
                item.Name = hw.Name;
                item.Text = hw.Name;
                item.Nodes.Add(hw);
                item.Nodes.Add(plc);
                hmi.Name = hmiTarget.Name;
                hmi.Text = hmiTarget.Name;
                item.Nodes.Add(hmi);
            }

            if (plcSoftware == null && hmiTarget == null)
                item = hw;

            return item;
        }


        /// <summary>Crawls through the folders.</summary>
        /// <param name="projectTreeViewItem">The project TreeView item.</param>
        /// <param name="folder">The folder.</param>
        /// TODO Edit XML Comment Template for FolderCrawler
        private static void FolderCrawler(TreeNode projectTreeViewItem, DeviceUserGroup folder)
        {
            var folderItem = new TreeNode();
            folderItem.Name = folder.Name;
            folderItem.Text = folder.Name;
            folderItem.Tag = folder;
            projectTreeViewItem.Nodes.Add(folderItem);

            foreach (var device in folder.Devices)
            {
                var item = CreateDeviceTreeViewItem(device);

                folderItem.Nodes.Add(item);
            }

            foreach (var subFolder in folder.Groups)
            {
                FolderCrawler(folderItem, subFolder);
            }
        }



        #endregion

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(_ExcelTagWatchTables == null))
            {
                _ExcelTagWatchTables.CloseExcel();
            }


            if (!(_ExcelDB == null))
            {
                _ExcelDB.CloseExcel();
            }


            if (!(_ExcelPrg == null))
            {
                _ExcelPrg.CloseExcel();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            object tiaProjectObj = null;

            /* if (rb_LocalSession.Checked)
             {
                 tiaProjectObj = _tiaPortalLocalSession;
             }*/

            if (rb_Project.Checked)
            {
                tiaProjectObj = _tiaPortalProject;
            }
            try
            {
                if (_selectedItem != null)
                {
                    string devname = _selectedItem;//  txt_Device.Text;
                    bool found = false;

                    DeviceComposition devices = null;


                    /*if (rb_LocalSession.Checked)
                    {
                        devices = _tiaPortalLocalSession.Project.Devices;
                    }*/
                    if (rb_Project.Checked)
                    {
                        devices = _tiaPortalProject.Devices;
                    }

                    foreach (Device device in devices)
                    {
                        DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                        foreach (DeviceItem deviceItem in deviceItemAggregation)
                        {
                            if (deviceItem.Name == devname || device.Name == devname)
                            {
                                SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                                if (softwareContainer != null)
                                {
                                    if (softwareContainer.Software is PlcSoftware)
                                    {
                                        PlcSoftware controllerTarget = softwareContainer.Software as PlcSoftware;
                                        if (controllerTarget != null)
                                        {
                                            found = true;
                                            
                                            PlcTagTableSystemGroup plcTagTableSystemgroup = controllerTarget.TagTableGroup;
                                            PlcTagTable tagTable = plcTagTableSystemgroup.TagTables.Find("Додатково (PSL_SAF_)__PF_H1");
                                            if (tagTable == null) return;
                                            tagTable.Tags.Import(new FileInfo("C:\\Samples\\Export.xml"), ImportOptions.Override);

                                        }
                                    }

                                }
                            }
                        }
                    }

                    if (found == false)
                    {
                        oGenActions.CreateStatus(txt_Status, "Found no PLC with name " + _selectedItem, 2); // txt_Device.Text, 2);
                    }

                }
                else
                {
                    oGenActions.CreateStatus(txt_Status, "Device for create DB for I/O wasn't choice", 3);
                }

            }
            catch (Exception ex)
            {
                oGenActions.CreateStatus(txt_Status, "Exception occured:\n\r" + ex.Message, 2);
            }

        }
    }
}

