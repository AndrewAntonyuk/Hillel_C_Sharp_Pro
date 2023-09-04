
using TestOpenessVS.Utils;

namespace TestOpenessVS
{
    partial class AssemblySelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //Delegate to start form
        public delegate void del_PassAS_StartForm(object oAS);

        //Instance of assembly selection object
        AssemblySelectionData _baseAS = new AssemblySelectionData();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblySelection));
            this.btn_Apply = new System.Windows.Forms.Button();
            this.fld_EngVersion = new System.Windows.Forms.ComboBox();
            this.txt_EngVersion = new System.Windows.Forms.Label();
            this.txt_AssmVersion = new System.Windows.Forms.Label();
            this.fld_AssmVersion = new System.Windows.Forms.ComboBox();
            this.assemblySelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assemblySelectionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.assemblySelectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblySelectionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Apply
            // 
            this.btn_Apply.Font = new System.Drawing.Font("Siemens Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Apply.Location = new System.Drawing.Point(137, 129);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(153, 41);
            this.btn_Apply.TabIndex = 0;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // fld_EngVersion
            // 
            this.fld_EngVersion.Font = new System.Drawing.Font("Siemens Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_EngVersion.FormattingEnabled = true;
            this.fld_EngVersion.Location = new System.Drawing.Point(238, 22);
            this.fld_EngVersion.Name = "fld_EngVersion";
            this.fld_EngVersion.Size = new System.Drawing.Size(159, 30);
            this.fld_EngVersion.TabIndex = 1;
            this.fld_EngVersion.DropDown += new System.EventHandler(this.fld_EngVersion_DropDown);
            this.fld_EngVersion.SelectedIndexChanged += new System.EventHandler(this.fld_EngVersion_SelectedIndexChanged);
            // 
            // txt_EngVersion
            // 
            this.txt_EngVersion.AutoSize = true;
            this.txt_EngVersion.Font = new System.Drawing.Font("Siemens Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EngVersion.Location = new System.Drawing.Point(26, 18);
            this.txt_EngVersion.Name = "txt_EngVersion";
            this.txt_EngVersion.Size = new System.Drawing.Size(190, 38);
            this.txt_EngVersion.TabIndex = 2;
            this.txt_EngVersion.Text = "Engineering version\r\n(TIA version)";
            // 
            // txt_AssmVersion
            // 
            this.txt_AssmVersion.AutoSize = true;
            this.txt_AssmVersion.Font = new System.Drawing.Font("Siemens Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AssmVersion.Location = new System.Drawing.Point(26, 70);
            this.txt_AssmVersion.Name = "txt_AssmVersion";
            this.txt_AssmVersion.Size = new System.Drawing.Size(177, 38);
            this.txt_AssmVersion.TabIndex = 4;
            this.txt_AssmVersion.Text = "Assembly version\r\n(Openness version)";
            this.txt_AssmVersion.Click += new System.EventHandler(this.label1_Click);
            // 
            // fld_AssmVersion
            // 
            this.fld_AssmVersion.Font = new System.Drawing.Font("Siemens Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_AssmVersion.FormattingEnabled = true;
            this.fld_AssmVersion.Location = new System.Drawing.Point(238, 74);
            this.fld_AssmVersion.Name = "fld_AssmVersion";
            this.fld_AssmVersion.Size = new System.Drawing.Size(159, 30);
            this.fld_AssmVersion.TabIndex = 3;
            this.fld_AssmVersion.DropDown += new System.EventHandler(this.fld_AssmVersion_DropDown);
            this.fld_AssmVersion.SelectedIndexChanged += new System.EventHandler(this.fld_AssmVersion_SelectedIndexChanged);
            // 
            // assemblySelectionBindingSource
            // 
            this.assemblySelectionBindingSource.DataSource = typeof(TestOpenessVS.AssemblySelection);
            // 
            // assemblySelectionBindingSource1
            // 
            this.assemblySelectionBindingSource1.DataSource = typeof(TestOpenessVS.AssemblySelection);
            // 
            // AssemblySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(446, 197);
            this.Controls.Add(this.txt_AssmVersion);
            this.Controls.Add(this.fld_AssmVersion);
            this.Controls.Add(this.txt_EngVersion);
            this.Controls.Add(this.fld_EngVersion);
            this.Controls.Add(this.btn_Apply);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssemblySelection";
            this.Text = "AssemblySelection";
            ((System.ComponentModel.ISupportInitialize)(this.assemblySelectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblySelectionBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.ComboBox fld_EngVersion;
        private System.Windows.Forms.Label txt_EngVersion;
        private System.Windows.Forms.Label txt_AssmVersion;
        private System.Windows.Forms.ComboBox fld_AssmVersion;
        private System.Windows.Forms.BindingSource assemblySelectionBindingSource;
        private System.Windows.Forms.BindingSource assemblySelectionBindingSource1;
    }
}