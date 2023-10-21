namespace TodoListPlus
{
    partial class ConfirmForm
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
            labelQuestion = new Label();
            labelListName = new Label();
            labelItemsCount = new Label();
            SuspendLayout();
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new Point(65, 21);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(214, 15);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = "Are you sure you want to delete this list";
            // 
            // labelListName
            // 
            labelListName.AutoSize = true;
            labelListName.Location = new Point(65, 64);
            labelListName.Name = "labelListName";
            labelListName.Size = new Size(111, 15);
            labelListName.TabIndex = 1;
            labelListName.Text = "List: <Name of list>";
            // 
            // labelItemsCount
            // 
            labelItemsCount.AutoSize = true;
            labelItemsCount.Location = new Point(65, 110);
            labelItemsCount.Name = "labelItemsCount";
            labelItemsCount.Size = new Size(74, 15);
            labelItemsCount.TabIndex = 2;
            labelItemsCount.Text = "Items: <No>";
            // 
            // ConfirmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 210);
            Controls.Add(labelItemsCount);
            Controls.Add(labelListName);
            Controls.Add(labelQuestion);
            Name = "ConfirmForm";
            Text = "Confirm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelQuestion;
        private Label labelListName;
        private Label labelItemsCount;
    }
}