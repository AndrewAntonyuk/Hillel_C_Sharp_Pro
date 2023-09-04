
using TestOpenessVS.Utils;

namespace TestOpenessVS
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //Internal assembly selection 
        private AssemblySelectionData _IntAS = new AssemblySelectionData();

        //Delegate function for assembly selection
        public void retrieveAS_Data(object objExtAS)
        {
            _IntAS = (AssemblySelectionData)objExtAS;
            fld_EngVersion.Text = _IntAS.SelectedVersion;
            fld_AssmVersion.Text = _IntAS.SelectedAssembly;
        }

        //Delegate to create tagtable
        public delegate void DelegateToCreateTagTable(object _sendObj);

        //Delegate to create watchtable
        public delegate void DelegateToCreateWatchTable(object _sendObj);

        //Delegate to create DB
        public delegate void DelegateToCreateDB(object _sendObj);

        //Delegate to create program
        public delegate void DelegateToCreatePrg(object _sendObj);

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grp_VerInfo = new System.Windows.Forms.GroupBox();
            this.fld_AssmVersion = new System.Windows.Forms.TextBox();
            this.fld_EngVersion = new System.Windows.Forms.TextBox();
            this.txt_AssmVersion = new System.Windows.Forms.Label();
            this.txt_EngVersion = new System.Windows.Forms.Label();
            this.grp_TIA = new System.Windows.Forms.GroupBox();
            this.rdb_WithoutUI = new System.Windows.Forms.RadioButton();
            this.rdb_WithUI = new System.Windows.Forms.RadioButton();
            this.btn_Dispose = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.rb_Server = new System.Windows.Forms.RadioButton();
            this.rb_LocalSession = new System.Windows.Forms.RadioButton();
            this.rb_Project = new System.Windows.Forms.RadioButton();
            this.grp_Project = new System.Windows.Forms.GroupBox();
            this.btn_RefreshTree = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_CloseProject = new System.Windows.Forms.Button();
            this.btn_SearchProject = new System.Windows.Forms.Button();
            this.txt_SelectedItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CompileHW = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_AddDevice = new System.Windows.Forms.TextBox();
            this.btn_AddHW = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Version = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_OrderNo = new System.Windows.Forms.TextBox();
            this.txt_Status = new System.Windows.Forms.RichTextBox();
            this.tre_ProjectTIA = new System.Windows.Forms.TreeView();
            this.groupAdditional = new System.Windows.Forms.GroupBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_ImportXML = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.grp_Sessions = new System.Windows.Forms.GroupBox();
            this.txt_FileForCreateTagtables = new System.Windows.Forms.Label();
            this.tbx_FileForCreateTagTables = new System.Windows.Forms.TextBox();
            this.btn_ChoiceFileCreateTagTbl = new System.Windows.Forms.Button();
            this.btn_CreateTagtbl = new System.Windows.Forms.Button();
            this.txtb_SheetName = new System.Windows.Forms.TextBox();
            this.txt_SheetName = new System.Windows.Forms.Label();
            this.btn_CreateXML_ByClass = new System.Windows.Forms.Button();
            this.grp_CreateTagWatchTbl = new System.Windows.Forms.GroupBox();
            this.btn_CloseFileCreateTagTbl = new System.Windows.Forms.Button();
            this.btn_CreateWatchTable = new System.Windows.Forms.Button();
            this.grp_CreateDB = new System.Windows.Forms.GroupBox();
            this.btn_CloseFileCreateDB = new System.Windows.Forms.Button();
            this.txt_FileForCreateDB = new System.Windows.Forms.Label();
            this.txtb_SheetNameDB = new System.Windows.Forms.TextBox();
            this.tbx_FileForCreateDB = new System.Windows.Forms.TextBox();
            this.txt_SheetNameDB = new System.Windows.Forms.Label();
            this.btn_ChoiceFileCreateDB = new System.Windows.Forms.Button();
            this.btn_CreateDB = new System.Windows.Forms.Button();
            this.btn_CreatePrg = new System.Windows.Forms.Button();
            this.txt_FileForCreatePrg = new System.Windows.Forms.Label();
            this.txtb_SheetNamePrg = new System.Windows.Forms.TextBox();
            this.tbx_FileForCreatePrg = new System.Windows.Forms.TextBox();
            this.txt_SheetNamePrg = new System.Windows.Forms.Label();
            this.btn_ChoiceFileCreatePrg = new System.Windows.Forms.Button();
            this.grp_CreatePRG = new System.Windows.Forms.GroupBox();
            this.btn_CloseFileCreatePrg = new System.Windows.Forms.Button();
            this.btn_CreateIODB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grp_VerInfo.SuspendLayout();
            this.grp_TIA.SuspendLayout();
            this.grp_Project.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupAdditional.SuspendLayout();
            this.grp_Sessions.SuspendLayout();
            this.grp_CreateTagWatchTbl.SuspendLayout();
            this.grp_CreateDB.SuspendLayout();
            this.grp_CreatePRG.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_VerInfo
            // 
            this.grp_VerInfo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grp_VerInfo.Controls.Add(this.fld_AssmVersion);
            this.grp_VerInfo.Controls.Add(this.fld_EngVersion);
            this.grp_VerInfo.Controls.Add(this.txt_AssmVersion);
            this.grp_VerInfo.Controls.Add(this.txt_EngVersion);
            this.grp_VerInfo.Location = new System.Drawing.Point(620, 12);
            this.grp_VerInfo.Name = "grp_VerInfo";
            this.grp_VerInfo.Size = new System.Drawing.Size(336, 86);
            this.grp_VerInfo.TabIndex = 2;
            this.grp_VerInfo.TabStop = false;
            this.grp_VerInfo.Text = "Versions info";
            // 
            // fld_AssmVersion
            // 
            this.fld_AssmVersion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.fld_AssmVersion.Font = new System.Drawing.Font("Siemens Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_AssmVersion.Location = new System.Drawing.Point(171, 55);
            this.fld_AssmVersion.Name = "fld_AssmVersion";
            this.fld_AssmVersion.ReadOnly = true;
            this.fld_AssmVersion.Size = new System.Drawing.Size(152, 23);
            this.fld_AssmVersion.TabIndex = 8;
            // 
            // fld_EngVersion
            // 
            this.fld_EngVersion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.fld_EngVersion.Font = new System.Drawing.Font("Siemens Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_EngVersion.Location = new System.Drawing.Point(171, 23);
            this.fld_EngVersion.Name = "fld_EngVersion";
            this.fld_EngVersion.ReadOnly = true;
            this.fld_EngVersion.Size = new System.Drawing.Size(152, 23);
            this.fld_EngVersion.TabIndex = 7;
            // 
            // txt_AssmVersion
            // 
            this.txt_AssmVersion.AutoSize = true;
            this.txt_AssmVersion.Font = new System.Drawing.Font("Siemens Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txt_AssmVersion.Location = new System.Drawing.Point(6, 58);
            this.txt_AssmVersion.Name = "txt_AssmVersion";
            this.txt_AssmVersion.Size = new System.Drawing.Size(130, 16);
            this.txt_AssmVersion.TabIndex = 6;
            this.txt_AssmVersion.Text = "Assembly version";
            // 
            // txt_EngVersion
            // 
            this.txt_EngVersion.AutoSize = true;
            this.txt_EngVersion.Font = new System.Drawing.Font("Siemens Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txt_EngVersion.Location = new System.Drawing.Point(6, 25);
            this.txt_EngVersion.Name = "txt_EngVersion";
            this.txt_EngVersion.Size = new System.Drawing.Size(146, 16);
            this.txt_EngVersion.TabIndex = 5;
            this.txt_EngVersion.Text = "Engineering version";
            // 
            // grp_TIA
            // 
            this.grp_TIA.Controls.Add(this.rdb_WithoutUI);
            this.grp_TIA.Controls.Add(this.rdb_WithUI);
            this.grp_TIA.Controls.Add(this.btn_Dispose);
            this.grp_TIA.Controls.Add(this.btn_Start);
            this.grp_TIA.Location = new System.Drawing.Point(12, 12);
            this.grp_TIA.Name = "grp_TIA";
            this.grp_TIA.Size = new System.Drawing.Size(151, 169);
            this.grp_TIA.TabIndex = 17;
            this.grp_TIA.TabStop = false;
            this.grp_TIA.Text = "TIA Portal";
            // 
            // rdb_WithoutUI
            // 
            this.rdb_WithoutUI.AutoSize = true;
            this.rdb_WithoutUI.Location = new System.Drawing.Point(16, 51);
            this.rdb_WithoutUI.Name = "rdb_WithoutUI";
            this.rdb_WithoutUI.Size = new System.Drawing.Size(132, 17);
            this.rdb_WithoutUI.TabIndex = 2;
            this.rdb_WithoutUI.Text = "Without User Interface";
            this.rdb_WithoutUI.UseVisualStyleBackColor = true;
            // 
            // rdb_WithUI
            // 
            this.rdb_WithUI.AutoSize = true;
            this.rdb_WithUI.Checked = true;
            this.rdb_WithUI.Location = new System.Drawing.Point(16, 28);
            this.rdb_WithUI.Name = "rdb_WithUI";
            this.rdb_WithUI.Size = new System.Drawing.Size(117, 17);
            this.rdb_WithUI.TabIndex = 1;
            this.rdb_WithUI.TabStop = true;
            this.rdb_WithUI.Text = "With User Interface";
            this.rdb_WithUI.UseVisualStyleBackColor = true;
            // 
            // btn_Dispose
            // 
            this.btn_Dispose.Enabled = false;
            this.btn_Dispose.Location = new System.Drawing.Point(16, 127);
            this.btn_Dispose.Name = "btn_Dispose";
            this.btn_Dispose.Size = new System.Drawing.Size(115, 36);
            this.btn_Dispose.TabIndex = 4;
            this.btn_Dispose.Text = "Dispose TIA";
            this.btn_Dispose.UseVisualStyleBackColor = true;
            this.btn_Dispose.Click += new System.EventHandler(this.DisposeTIA);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(16, 85);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(115, 36);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start TIA";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.StartTIA);
            // 
            // rb_Server
            // 
            this.rb_Server.AutoSize = true;
            this.rb_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rb_Server.Location = new System.Drawing.Point(22, 69);
            this.rb_Server.Name = "rb_Server";
            this.rb_Server.Size = new System.Drawing.Size(60, 19);
            this.rb_Server.TabIndex = 31;
            this.rb_Server.Text = "Server";
            this.rb_Server.UseVisualStyleBackColor = true;
            // 
            // rb_LocalSession
            // 
            this.rb_LocalSession.AutoSize = true;
            this.rb_LocalSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rb_LocalSession.Location = new System.Drawing.Point(22, 44);
            this.rb_LocalSession.Name = "rb_LocalSession";
            this.rb_LocalSession.Size = new System.Drawing.Size(100, 19);
            this.rb_LocalSession.TabIndex = 30;
            this.rb_LocalSession.Text = "Local session";
            this.rb_LocalSession.UseVisualStyleBackColor = true;
            // 
            // rb_Project
            // 
            this.rb_Project.AutoSize = true;
            this.rb_Project.Checked = true;
            this.rb_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rb_Project.Location = new System.Drawing.Point(22, 19);
            this.rb_Project.Name = "rb_Project";
            this.rb_Project.Size = new System.Drawing.Size(63, 19);
            this.rb_Project.TabIndex = 29;
            this.rb_Project.TabStop = true;
            this.rb_Project.Text = "Project";
            this.rb_Project.UseVisualStyleBackColor = true;
            // 
            // grp_Project
            // 
            this.grp_Project.Controls.Add(this.btn_RefreshTree);
            this.grp_Project.Controls.Add(this.btn_Connect);
            this.grp_Project.Controls.Add(this.btn_Save);
            this.grp_Project.Controls.Add(this.btn_CloseProject);
            this.grp_Project.Controls.Add(this.btn_SearchProject);
            this.grp_Project.Location = new System.Drawing.Point(169, 12);
            this.grp_Project.Name = "grp_Project";
            this.grp_Project.Size = new System.Drawing.Size(152, 251);
            this.grp_Project.TabIndex = 19;
            this.grp_Project.TabStop = false;
            this.grp_Project.Text = "Project";
            // 
            // btn_RefreshTree
            // 
            this.btn_RefreshTree.Enabled = false;
            this.btn_RefreshTree.Location = new System.Drawing.Point(24, 198);
            this.btn_RefreshTree.Name = "btn_RefreshTree";
            this.btn_RefreshTree.Size = new System.Drawing.Size(115, 36);
            this.btn_RefreshTree.TabIndex = 15;
            this.btn_RefreshTree.Text = "Refresh tree";
            this.btn_RefreshTree.UseVisualStyleBackColor = true;
            this.btn_RefreshTree.Click += new System.EventHandler(this.btn_RefreshTree_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(24, 65);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(115, 36);
            this.btn_Connect.TabIndex = 5;
            this.btn_Connect.Text = "Connect to open TIA Project";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_ConnectTIA);
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(24, 108);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(115, 36);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "Save Project";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.SaveProject);
            // 
            // btn_CloseProject
            // 
            this.btn_CloseProject.Enabled = false;
            this.btn_CloseProject.Location = new System.Drawing.Point(24, 152);
            this.btn_CloseProject.Name = "btn_CloseProject";
            this.btn_CloseProject.Size = new System.Drawing.Size(115, 36);
            this.btn_CloseProject.TabIndex = 8;
            this.btn_CloseProject.Text = "Close Project";
            this.btn_CloseProject.UseVisualStyleBackColor = true;
            this.btn_CloseProject.Click += new System.EventHandler(this.CloseProject);
            // 
            // btn_SearchProject
            // 
            this.btn_SearchProject.Enabled = false;
            this.btn_SearchProject.Location = new System.Drawing.Point(24, 23);
            this.btn_SearchProject.Name = "btn_SearchProject";
            this.btn_SearchProject.Size = new System.Drawing.Size(115, 36);
            this.btn_SearchProject.TabIndex = 5;
            this.btn_SearchProject.Text = "Open Project";
            this.btn_SearchProject.UseVisualStyleBackColor = true;
            this.btn_SearchProject.Click += new System.EventHandler(this.SearchProject);
            // 
            // txt_SelectedItem
            // 
            this.txt_SelectedItem.AutoSize = true;
            this.txt_SelectedItem.Font = new System.Drawing.Font("Siemens Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SelectedItem.Location = new System.Drawing.Point(19, 45);
            this.txt_SelectedItem.Name = "txt_SelectedItem";
            this.txt_SelectedItem.Size = new System.Drawing.Size(89, 14);
            this.txt_SelectedItem.TabIndex = 27;
            this.txt_SelectedItem.Text = "Selected item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Selected item";
            // 
            // btn_CompileHW
            // 
            this.btn_CompileHW.Enabled = false;
            this.btn_CompileHW.Location = new System.Drawing.Point(19, 67);
            this.btn_CompileHW.Name = "btn_CompileHW";
            this.btn_CompileHW.Size = new System.Drawing.Size(115, 36);
            this.btn_CompileHW.TabIndex = 12;
            this.btn_CompileHW.Text = "Compile";
            this.btn_CompileHW.UseVisualStyleBackColor = true;
            this.btn_CompileHW.Click += new System.EventHandler(this.Compile);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_AddDevice);
            this.groupBox1.Controls.Add(this.btn_AddHW);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Version);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_OrderNo);
            this.groupBox1.Location = new System.Drawing.Point(169, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 254);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Type Device name";
            // 
            // txt_AddDevice
            // 
            this.txt_AddDevice.Location = new System.Drawing.Point(18, 41);
            this.txt_AddDevice.Name = "txt_AddDevice";
            this.txt_AddDevice.Size = new System.Drawing.Size(115, 20);
            this.txt_AddDevice.TabIndex = 24;
            this.txt_AddDevice.Text = "PLC_1";
            // 
            // btn_AddHW
            // 
            this.btn_AddHW.Enabled = false;
            this.btn_AddHW.Location = new System.Drawing.Point(18, 161);
            this.btn_AddHW.Name = "btn_AddHW";
            this.btn_AddHW.Size = new System.Drawing.Size(115, 36);
            this.btn_AddHW.TabIndex = 23;
            this.btn_AddHW.Text = "Add Device";
            this.btn_AddHW.UseVisualStyleBackColor = true;
            this.btn_AddHW.Click += new System.EventHandler(this.btn_AddHW_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Type Version";
            // 
            // txt_Version
            // 
            this.txt_Version.Location = new System.Drawing.Point(18, 126);
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.Size = new System.Drawing.Size(115, 20);
            this.txt_Version.TabIndex = 21;
            this.txt_Version.Text = "V2.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Type Order Nr";
            // 
            // txt_OrderNo
            // 
            this.txt_OrderNo.Location = new System.Drawing.Point(4, 86);
            this.txt_OrderNo.Name = "txt_OrderNo";
            this.txt_OrderNo.Size = new System.Drawing.Size(143, 20);
            this.txt_OrderNo.TabIndex = 19;
            this.txt_OrderNo.Text = "6ES7 516-3AN01-0AB0";
            // 
            // txt_Status
            // 
            this.txt_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Status.Location = new System.Drawing.Point(-1, 572);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            this.txt_Status.Size = new System.Drawing.Size(957, 242);
            this.txt_Status.TabIndex = 25;
            this.txt_Status.Text = "";
            // 
            // tre_ProjectTIA
            // 
            this.tre_ProjectTIA.BackColor = System.Drawing.SystemColors.Menu;
            this.tre_ProjectTIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tre_ProjectTIA.Location = new System.Drawing.Point(620, 97);
            this.tre_ProjectTIA.Name = "tre_ProjectTIA";
            this.tre_ProjectTIA.Size = new System.Drawing.Size(336, 477);
            this.tre_ProjectTIA.TabIndex = 26;
            // 
            // groupAdditional
            // 
            this.groupAdditional.Controls.Add(this.txt_SelectedItem);
            this.groupAdditional.Controls.Add(this.btn_Delete);
            this.groupAdditional.Controls.Add(this.btn_ImportXML);
            this.groupAdditional.Controls.Add(this.label1);
            this.groupAdditional.Controls.Add(this.btn_Export);
            this.groupAdditional.Controls.Add(this.btn_CompileHW);
            this.groupAdditional.Location = new System.Drawing.Point(12, 285);
            this.groupAdditional.Name = "groupAdditional";
            this.groupAdditional.Size = new System.Drawing.Size(151, 238);
            this.groupAdditional.TabIndex = 28;
            this.groupAdditional.TabStop = false;
            this.groupAdditional.Text = "Additional";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Location = new System.Drawing.Point(19, 109);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(115, 36);
            this.btn_Delete.TabIndex = 12;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_ImportXML
            // 
            this.btn_ImportXML.Enabled = false;
            this.btn_ImportXML.Location = new System.Drawing.Point(19, 193);
            this.btn_ImportXML.Name = "btn_ImportXML";
            this.btn_ImportXML.Size = new System.Drawing.Size(115, 36);
            this.btn_ImportXML.TabIndex = 38;
            this.btn_ImportXML.Text = "Import from XML";
            this.btn_ImportXML.UseMnemonic = false;
            this.btn_ImportXML.UseVisualStyleBackColor = true;
            this.btn_ImportXML.Click += new System.EventHandler(this.btn_ImportXML_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Enabled = false;
            this.btn_Export.Location = new System.Drawing.Point(19, 151);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(115, 36);
            this.btn_Export.TabIndex = 37;
            this.btn_Export.Text = "Export to XML";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // grp_Sessions
            // 
            this.grp_Sessions.Controls.Add(this.rb_Server);
            this.grp_Sessions.Controls.Add(this.rb_Project);
            this.grp_Sessions.Controls.Add(this.rb_LocalSession);
            this.grp_Sessions.Location = new System.Drawing.Point(12, 181);
            this.grp_Sessions.Name = "grp_Sessions";
            this.grp_Sessions.Size = new System.Drawing.Size(151, 98);
            this.grp_Sessions.TabIndex = 30;
            this.grp_Sessions.TabStop = false;
            this.grp_Sessions.Text = "Session";
            // 
            // txt_FileForCreateTagtables
            // 
            this.txt_FileForCreateTagtables.AutoSize = true;
            this.txt_FileForCreateTagtables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txt_FileForCreateTagtables.Location = new System.Drawing.Point(31, 25);
            this.txt_FileForCreateTagtables.Name = "txt_FileForCreateTagtables";
            this.txt_FileForCreateTagtables.Size = new System.Drawing.Size(215, 15);
            this.txt_FileForCreateTagtables.TabIndex = 31;
            this.txt_FileForCreateTagtables.Text = "Opened file for create tag/watch tables";
            // 
            // tbx_FileForCreateTagTables
            // 
            this.tbx_FileForCreateTagTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbx_FileForCreateTagTables.Location = new System.Drawing.Point(13, 45);
            this.tbx_FileForCreateTagTables.Name = "tbx_FileForCreateTagTables";
            this.tbx_FileForCreateTagTables.Size = new System.Drawing.Size(229, 21);
            this.tbx_FileForCreateTagTables.TabIndex = 32;
            // 
            // btn_ChoiceFileCreateTagTbl
            // 
            this.btn_ChoiceFileCreateTagTbl.Location = new System.Drawing.Point(242, 38);
            this.btn_ChoiceFileCreateTagTbl.Name = "btn_ChoiceFileCreateTagTbl";
            this.btn_ChoiceFileCreateTagTbl.Size = new System.Drawing.Size(39, 21);
            this.btn_ChoiceFileCreateTagTbl.TabIndex = 33;
            this.btn_ChoiceFileCreateTagTbl.Text = "...";
            this.btn_ChoiceFileCreateTagTbl.UseVisualStyleBackColor = true;
            this.btn_ChoiceFileCreateTagTbl.Click += new System.EventHandler(this.btn_ChoiceFileCreateTagTbl_Click);
            // 
            // btn_CreateTagtbl
            // 
            this.btn_CreateTagtbl.Enabled = false;
            this.btn_CreateTagtbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_CreateTagtbl.Location = new System.Drawing.Point(64, 113);
            this.btn_CreateTagtbl.Name = "btn_CreateTagtbl";
            this.btn_CreateTagtbl.Size = new System.Drawing.Size(130, 26);
            this.btn_CreateTagtbl.TabIndex = 34;
            this.btn_CreateTagtbl.Text = "Create tagtables";
            this.btn_CreateTagtbl.UseVisualStyleBackColor = true;
            this.btn_CreateTagtbl.Click += new System.EventHandler(this.btn_CreateTagtbl_Click);
            // 
            // txtb_SheetName
            // 
            this.txtb_SheetName.Location = new System.Drawing.Point(16, 87);
            this.txtb_SheetName.Name = "txtb_SheetName";
            this.txtb_SheetName.Size = new System.Drawing.Size(226, 20);
            this.txtb_SheetName.TabIndex = 35;
            this.txtb_SheetName.Text = "Tags";
            // 
            // txt_SheetName
            // 
            this.txt_SheetName.AutoSize = true;
            this.txt_SheetName.Location = new System.Drawing.Point(87, 72);
            this.txt_SheetName.Name = "txt_SheetName";
            this.txt_SheetName.Size = new System.Drawing.Size(64, 13);
            this.txt_SheetName.TabIndex = 36;
            this.txt_SheetName.Text = "Sheet name";
            // 
            // btn_CreateXML_ByClass
            // 
            this.btn_CreateXML_ByClass.Location = new System.Drawing.Point(159, 527);
            this.btn_CreateXML_ByClass.Name = "btn_CreateXML_ByClass";
            this.btn_CreateXML_ByClass.Size = new System.Drawing.Size(120, 44);
            this.btn_CreateXML_ByClass.TabIndex = 39;
            this.btn_CreateXML_ByClass.Text = "Create XML from class";
            this.btn_CreateXML_ByClass.UseVisualStyleBackColor = true;
            this.btn_CreateXML_ByClass.Click += new System.EventHandler(this.btn_CreateXML_ByClass_Click);
            // 
            // grp_CreateTagWatchTbl
            // 
            this.grp_CreateTagWatchTbl.Controls.Add(this.btn_CloseFileCreateTagTbl);
            this.grp_CreateTagWatchTbl.Controls.Add(this.btn_CreateWatchTable);
            this.grp_CreateTagWatchTbl.Controls.Add(this.txt_FileForCreateTagtables);
            this.grp_CreateTagWatchTbl.Controls.Add(this.tbx_FileForCreateTagTables);
            this.grp_CreateTagWatchTbl.Controls.Add(this.btn_ChoiceFileCreateTagTbl);
            this.grp_CreateTagWatchTbl.Controls.Add(this.btn_CreateTagtbl);
            this.grp_CreateTagWatchTbl.Controls.Add(this.txtb_SheetName);
            this.grp_CreateTagWatchTbl.Controls.Add(this.txt_SheetName);
            this.grp_CreateTagWatchTbl.Location = new System.Drawing.Point(327, 12);
            this.grp_CreateTagWatchTbl.Name = "grp_CreateTagWatchTbl";
            this.grp_CreateTagWatchTbl.Size = new System.Drawing.Size(287, 199);
            this.grp_CreateTagWatchTbl.TabIndex = 40;
            this.grp_CreateTagWatchTbl.TabStop = false;
            this.grp_CreateTagWatchTbl.Text = "Create tag/watch tables";
            // 
            // btn_CloseFileCreateTagTbl
            // 
            this.btn_CloseFileCreateTagTbl.BackColor = System.Drawing.Color.Red;
            this.btn_CloseFileCreateTagTbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CloseFileCreateTagTbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CloseFileCreateTagTbl.Location = new System.Drawing.Point(242, 64);
            this.btn_CloseFileCreateTagTbl.Name = "btn_CloseFileCreateTagTbl";
            this.btn_CloseFileCreateTagTbl.Size = new System.Drawing.Size(39, 21);
            this.btn_CloseFileCreateTagTbl.TabIndex = 38;
            this.btn_CloseFileCreateTagTbl.Text = "X";
            this.btn_CloseFileCreateTagTbl.UseVisualStyleBackColor = false;
            this.btn_CloseFileCreateTagTbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_CloseFileCreateTagTbl_MouseUp);
            // 
            // btn_CreateWatchTable
            // 
            this.btn_CreateWatchTable.Enabled = false;
            this.btn_CreateWatchTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_CreateWatchTable.Location = new System.Drawing.Point(64, 145);
            this.btn_CreateWatchTable.Name = "btn_CreateWatchTable";
            this.btn_CreateWatchTable.Size = new System.Drawing.Size(130, 26);
            this.btn_CreateWatchTable.TabIndex = 37;
            this.btn_CreateWatchTable.Text = "Create watchtables";
            this.btn_CreateWatchTable.UseVisualStyleBackColor = true;
            this.btn_CreateWatchTable.Click += new System.EventHandler(this.btn_CreateWatchTable_Click);
            // 
            // grp_CreateDB
            // 
            this.grp_CreateDB.Controls.Add(this.btn_CloseFileCreateDB);
            this.grp_CreateDB.Controls.Add(this.txt_FileForCreateDB);
            this.grp_CreateDB.Controls.Add(this.txtb_SheetNameDB);
            this.grp_CreateDB.Controls.Add(this.tbx_FileForCreateDB);
            this.grp_CreateDB.Controls.Add(this.txt_SheetNameDB);
            this.grp_CreateDB.Controls.Add(this.btn_ChoiceFileCreateDB);
            this.grp_CreateDB.Controls.Add(this.btn_CreateDB);
            this.grp_CreateDB.Location = new System.Drawing.Point(327, 218);
            this.grp_CreateDB.Name = "grp_CreateDB";
            this.grp_CreateDB.Size = new System.Drawing.Size(287, 157);
            this.grp_CreateDB.TabIndex = 41;
            this.grp_CreateDB.TabStop = false;
            this.grp_CreateDB.Text = "Create Instance Data Blocks";
            // 
            // btn_CloseFileCreateDB
            // 
            this.btn_CloseFileCreateDB.BackColor = System.Drawing.Color.Red;
            this.btn_CloseFileCreateDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CloseFileCreateDB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CloseFileCreateDB.Location = new System.Drawing.Point(246, 67);
            this.btn_CloseFileCreateDB.Name = "btn_CloseFileCreateDB";
            this.btn_CloseFileCreateDB.Size = new System.Drawing.Size(39, 21);
            this.btn_CloseFileCreateDB.TabIndex = 39;
            this.btn_CloseFileCreateDB.Text = "X";
            this.btn_CloseFileCreateDB.UseVisualStyleBackColor = false;
            this.btn_CloseFileCreateDB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_CloseFileCreateDB_MouseUp);
            // 
            // txt_FileForCreateDB
            // 
            this.txt_FileForCreateDB.AutoSize = true;
            this.txt_FileForCreateDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txt_FileForCreateDB.Location = new System.Drawing.Point(54, 32);
            this.txt_FileForCreateDB.Name = "txt_FileForCreateDB";
            this.txt_FileForCreateDB.Size = new System.Drawing.Size(144, 15);
            this.txt_FileForCreateDB.TabIndex = 38;
            this.txt_FileForCreateDB.Text = "Opened file for create DB";
            // 
            // txtb_SheetNameDB
            // 
            this.txtb_SheetNameDB.Location = new System.Drawing.Point(20, 92);
            this.txtb_SheetNameDB.Name = "txtb_SheetNameDB";
            this.txtb_SheetNameDB.Size = new System.Drawing.Size(226, 20);
            this.txtb_SheetNameDB.TabIndex = 42;
            this.txtb_SheetNameDB.Text = "DB_DataOpenness";
            // 
            // tbx_FileForCreateDB
            // 
            this.tbx_FileForCreateDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbx_FileForCreateDB.Location = new System.Drawing.Point(17, 52);
            this.tbx_FileForCreateDB.Name = "tbx_FileForCreateDB";
            this.tbx_FileForCreateDB.Size = new System.Drawing.Size(229, 21);
            this.tbx_FileForCreateDB.TabIndex = 39;
            // 
            // txt_SheetNameDB
            // 
            this.txt_SheetNameDB.AutoSize = true;
            this.txt_SheetNameDB.Location = new System.Drawing.Point(91, 77);
            this.txt_SheetNameDB.Name = "txt_SheetNameDB";
            this.txt_SheetNameDB.Size = new System.Drawing.Size(64, 13);
            this.txt_SheetNameDB.TabIndex = 43;
            this.txt_SheetNameDB.Text = "Sheet name";
            // 
            // btn_ChoiceFileCreateDB
            // 
            this.btn_ChoiceFileCreateDB.Location = new System.Drawing.Point(246, 42);
            this.btn_ChoiceFileCreateDB.Name = "btn_ChoiceFileCreateDB";
            this.btn_ChoiceFileCreateDB.Size = new System.Drawing.Size(39, 21);
            this.btn_ChoiceFileCreateDB.TabIndex = 40;
            this.btn_ChoiceFileCreateDB.Text = "...";
            this.btn_ChoiceFileCreateDB.UseVisualStyleBackColor = true;
            this.btn_ChoiceFileCreateDB.Click += new System.EventHandler(this.btn_ChoiceFileCreateDB_Click);
            // 
            // btn_CreateDB
            // 
            this.btn_CreateDB.Enabled = false;
            this.btn_CreateDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_CreateDB.Location = new System.Drawing.Point(64, 120);
            this.btn_CreateDB.Name = "btn_CreateDB";
            this.btn_CreateDB.Size = new System.Drawing.Size(130, 26);
            this.btn_CreateDB.TabIndex = 41;
            this.btn_CreateDB.Text = "Create DB";
            this.btn_CreateDB.UseVisualStyleBackColor = true;
            this.btn_CreateDB.Click += new System.EventHandler(this.btn_CreateDB_Click);
            // 
            // btn_CreatePrg
            // 
            this.btn_CreatePrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_CreatePrg.Location = new System.Drawing.Point(64, 146);
            this.btn_CreatePrg.Name = "btn_CreatePrg";
            this.btn_CreatePrg.Size = new System.Drawing.Size(130, 26);
            this.btn_CreatePrg.TabIndex = 41;
            this.btn_CreatePrg.Text = "Create program";
            this.btn_CreatePrg.UseVisualStyleBackColor = true;
            this.btn_CreatePrg.Click += new System.EventHandler(this.btn_CreatePrg_Click);
            // 
            // txt_FileForCreatePrg
            // 
            this.txt_FileForCreatePrg.AutoSize = true;
            this.txt_FileForCreatePrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txt_FileForCreatePrg.Location = new System.Drawing.Point(41, 17);
            this.txt_FileForCreatePrg.Name = "txt_FileForCreatePrg";
            this.txt_FileForCreatePrg.Size = new System.Drawing.Size(174, 15);
            this.txt_FileForCreatePrg.TabIndex = 38;
            this.txt_FileForCreatePrg.Text = "Opened file for create program";
            // 
            // txtb_SheetNamePrg
            // 
            this.txtb_SheetNamePrg.Location = new System.Drawing.Point(15, 77);
            this.txtb_SheetNamePrg.Name = "txtb_SheetNamePrg";
            this.txtb_SheetNamePrg.Size = new System.Drawing.Size(226, 20);
            this.txtb_SheetNamePrg.TabIndex = 42;
            this.txtb_SheetNamePrg.Text = "PRG_DataOpenness";
            // 
            // tbx_FileForCreatePrg
            // 
            this.tbx_FileForCreatePrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbx_FileForCreatePrg.Location = new System.Drawing.Point(14, 37);
            this.tbx_FileForCreatePrg.Name = "tbx_FileForCreatePrg";
            this.tbx_FileForCreatePrg.Size = new System.Drawing.Size(229, 21);
            this.tbx_FileForCreatePrg.TabIndex = 39;
            // 
            // txt_SheetNamePrg
            // 
            this.txt_SheetNamePrg.AutoSize = true;
            this.txt_SheetNamePrg.Location = new System.Drawing.Point(96, 62);
            this.txt_SheetNamePrg.Name = "txt_SheetNamePrg";
            this.txt_SheetNamePrg.Size = new System.Drawing.Size(64, 13);
            this.txt_SheetNamePrg.TabIndex = 43;
            this.txt_SheetNamePrg.Text = "Sheet name";
            // 
            // btn_ChoiceFileCreatePrg
            // 
            this.btn_ChoiceFileCreatePrg.Location = new System.Drawing.Point(245, 24);
            this.btn_ChoiceFileCreatePrg.Name = "btn_ChoiceFileCreatePrg";
            this.btn_ChoiceFileCreatePrg.Size = new System.Drawing.Size(39, 21);
            this.btn_ChoiceFileCreatePrg.TabIndex = 40;
            this.btn_ChoiceFileCreatePrg.Text = "...";
            this.btn_ChoiceFileCreatePrg.UseVisualStyleBackColor = true;
            this.btn_ChoiceFileCreatePrg.Click += new System.EventHandler(this.btn_ChoiceFileCreatePrg_Click);
            // 
            // grp_CreatePRG
            // 
            this.grp_CreatePRG.Controls.Add(this.btn_CloseFileCreatePrg);
            this.grp_CreatePRG.Controls.Add(this.btn_CreateIODB);
            this.grp_CreatePRG.Controls.Add(this.btn_CreatePrg);
            this.grp_CreatePRG.Controls.Add(this.txt_FileForCreatePrg);
            this.grp_CreatePRG.Controls.Add(this.btn_ChoiceFileCreatePrg);
            this.grp_CreatePRG.Controls.Add(this.txtb_SheetNamePrg);
            this.grp_CreatePRG.Controls.Add(this.txt_SheetNamePrg);
            this.grp_CreatePRG.Controls.Add(this.tbx_FileForCreatePrg);
            this.grp_CreatePRG.Location = new System.Drawing.Point(327, 381);
            this.grp_CreatePRG.Name = "grp_CreatePRG";
            this.grp_CreatePRG.Size = new System.Drawing.Size(287, 185);
            this.grp_CreatePRG.TabIndex = 42;
            this.grp_CreatePRG.TabStop = false;
            this.grp_CreatePRG.Text = "Create IO Data and program Blocks";
            // 
            // btn_CloseFileCreatePrg
            // 
            this.btn_CloseFileCreatePrg.BackColor = System.Drawing.Color.Red;
            this.btn_CloseFileCreatePrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CloseFileCreatePrg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CloseFileCreatePrg.Location = new System.Drawing.Point(245, 51);
            this.btn_CloseFileCreatePrg.Name = "btn_CloseFileCreatePrg";
            this.btn_CloseFileCreatePrg.Size = new System.Drawing.Size(39, 21);
            this.btn_CloseFileCreatePrg.TabIndex = 43;
            this.btn_CloseFileCreatePrg.Text = "X";
            this.btn_CloseFileCreatePrg.UseVisualStyleBackColor = false;
            this.btn_CloseFileCreatePrg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_CloseFileCreatePrg_MouseUp);
            // 
            // btn_CreateIODB
            // 
            this.btn_CreateIODB.Enabled = false;
            this.btn_CreateIODB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_CreateIODB.Location = new System.Drawing.Point(64, 107);
            this.btn_CreateIODB.Name = "btn_CreateIODB";
            this.btn_CreateIODB.Size = new System.Drawing.Size(130, 26);
            this.btn_CreateIODB.TabIndex = 44;
            this.btn_CreateIODB.Text = "Create IO DB";
            this.btn_CreateIODB.UseVisualStyleBackColor = true;
            this.btn_CreateIODB.Click += new System.EventHandler(this.btn_CreateIODB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 46);
            this.button1.TabIndex = 43;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 816);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grp_CreatePRG);
            this.Controls.Add(this.grp_CreateDB);
            this.Controls.Add(this.grp_CreateTagWatchTbl);
            this.Controls.Add(this.btn_CreateXML_ByClass);
            this.Controls.Add(this.grp_Sessions);
            this.Controls.Add(this.groupAdditional);
            this.Controls.Add(this.tre_ProjectTIA);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_Project);
            this.Controls.Add(this.grp_TIA);
            this.Controls.Add(this.grp_VerInfo);
            this.DoubleBuffered = true;
            this.Name = "StartForm";
            this.Text = "Manage TIA with Openness";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartForm_FormClosing);
            this.grp_VerInfo.ResumeLayout(false);
            this.grp_VerInfo.PerformLayout();
            this.grp_TIA.ResumeLayout(false);
            this.grp_TIA.PerformLayout();
            this.grp_Project.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupAdditional.ResumeLayout(false);
            this.groupAdditional.PerformLayout();
            this.grp_Sessions.ResumeLayout(false);
            this.grp_Sessions.PerformLayout();
            this.grp_CreateTagWatchTbl.ResumeLayout(false);
            this.grp_CreateTagWatchTbl.PerformLayout();
            this.grp_CreateDB.ResumeLayout(false);
            this.grp_CreateDB.PerformLayout();
            this.grp_CreatePRG.ResumeLayout(false);
            this.grp_CreatePRG.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_VerInfo;
        private System.Windows.Forms.Label txt_AssmVersion;
        private System.Windows.Forms.Label txt_EngVersion;
        private System.Windows.Forms.TextBox fld_AssmVersion;
        private System.Windows.Forms.TextBox fld_EngVersion;
        private System.Windows.Forms.GroupBox grp_TIA;
        private System.Windows.Forms.RadioButton rdb_WithoutUI;
        private System.Windows.Forms.RadioButton rdb_WithUI;
        private System.Windows.Forms.Button btn_Dispose;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.GroupBox grp_Project;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_CloseProject;
        private System.Windows.Forms.Button btn_SearchProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CompileHW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_AddDevice;
        private System.Windows.Forms.Button btn_AddHW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Version;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_OrderNo;
        private System.Windows.Forms.RichTextBox txt_Status;
        private System.Windows.Forms.TreeView tre_ProjectTIA;
        private System.Windows.Forms.Label txt_SelectedItem;
        private System.Windows.Forms.GroupBox groupAdditional;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_RefreshTree;
        private System.Windows.Forms.RadioButton rb_Project;
        private System.Windows.Forms.RadioButton rb_LocalSession;
        private System.Windows.Forms.RadioButton rb_Server;
        private System.Windows.Forms.GroupBox grp_Sessions;
        private System.Windows.Forms.Label txt_FileForCreateTagtables;
        private System.Windows.Forms.TextBox tbx_FileForCreateTagTables;
        private System.Windows.Forms.Button btn_ChoiceFileCreateTagTbl;
        private System.Windows.Forms.Button btn_CreateTagtbl;
        private System.Windows.Forms.TextBox txtb_SheetName;
        private System.Windows.Forms.Label txt_SheetName;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_ImportXML;
        private System.Windows.Forms.Button btn_CreateXML_ByClass;
        private System.Windows.Forms.GroupBox grp_CreateTagWatchTbl;
        private System.Windows.Forms.GroupBox grp_CreateDB;
        private System.Windows.Forms.Button btn_CreateWatchTable;
        private System.Windows.Forms.Label txt_FileForCreateDB;
        private System.Windows.Forms.TextBox txtb_SheetNameDB;
        private System.Windows.Forms.TextBox tbx_FileForCreateDB;
        private System.Windows.Forms.Label txt_SheetNameDB;
        private System.Windows.Forms.Button btn_ChoiceFileCreateDB;
        private System.Windows.Forms.Button btn_CreateDB;
        private System.Windows.Forms.Label txt_FileForCreatePrg;
        private System.Windows.Forms.TextBox txtb_SheetNamePrg;
        private System.Windows.Forms.TextBox tbx_FileForCreatePrg;
        private System.Windows.Forms.Label txt_SheetNamePrg;
        private System.Windows.Forms.Button btn_ChoiceFileCreatePrg;
        private System.Windows.Forms.Button btn_CreatePrg;
        private System.Windows.Forms.GroupBox grp_CreatePRG;
        private System.Windows.Forms.Button btn_CreateIODB;
        private System.Windows.Forms.Button btn_CloseFileCreateTagTbl;
        private System.Windows.Forms.Button btn_CloseFileCreateDB;
        private System.Windows.Forms.Button btn_CloseFileCreatePrg;
        private System.Windows.Forms.Button button1;
    }
}

