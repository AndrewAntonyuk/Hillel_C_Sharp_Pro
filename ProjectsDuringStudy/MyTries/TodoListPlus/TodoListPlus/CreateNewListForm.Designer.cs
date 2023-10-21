namespace TodoListPlus
{
    partial class CreateNewListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            labelNewList = new Label();
            textBoxNameNewList = new TextBox();
            buttonCreate = new Button();
            labelAlreadyExist = new Label();
            SuspendLayout();
            // 
            // labelNewList
            // 
            labelNewList.AutoSize = true;
            labelNewList.Location = new Point(105, 23);
            labelNewList.Name = "labelNewList";
            labelNewList.Size = new Size(128, 15);
            labelNewList.TabIndex = 0;
            labelNewList.Text = "Enter name for new list";
            // 
            // textBoxNameNewList
            // 
            textBoxNameNewList.Location = new Point(21, 52);
            textBoxNameNewList.Multiline = true;
            textBoxNameNewList.Name = "textBoxNameNewList";
            textBoxNameNewList.Size = new Size(292, 48);
            textBoxNameNewList.TabIndex = 1;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(82, 117);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(151, 42);
            buttonCreate.TabIndex = 2;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            // 
            // labelAlreadyExist
            // 
            labelAlreadyExist.AutoSize = true;
            labelAlreadyExist.ForeColor = Color.Red;
            labelAlreadyExist.Location = new Point(102, 233);
            labelAlreadyExist.Name = "labelAlreadyExist";
            labelAlreadyExist.Size = new Size(131, 15);
            labelAlreadyExist.TabIndex = 3;
            labelAlreadyExist.Text = "That name already exist";
            labelAlreadyExist.Visible = false;
            // 
            // CreateNewListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 292);
            Controls.Add(labelAlreadyExist);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxNameNewList);
            Controls.Add(labelNewList);
            Name = "CreateNewListForm";
            Text = "CreateNewListForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNewList;
        private TextBox textBoxNameNewList;
        private Button buttonCreate;
        private Label labelAlreadyExist;
    }
}