namespace TodoListPlus
{
    partial class AddTodoItemsForm
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
            labelNameNewItem = new Label();
            labelErrorEmpty = new Label();
            textBoxNameNewItem = new TextBox();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // labelNameNewItem
            // 
            labelNameNewItem.AutoSize = true;
            labelNameNewItem.Location = new Point(122, 18);
            labelNameNewItem.Name = "labelNameNewItem";
            labelNameNewItem.Size = new Size(136, 15);
            labelNameNewItem.TabIndex = 0;
            labelNameNewItem.Text = "Enter name of new item:";
            // 
            // labelErrorEmpty
            // 
            labelErrorEmpty.AutoSize = true;
            labelErrorEmpty.ForeColor = Color.Red;
            labelErrorEmpty.Location = new Point(146, 253);
            labelErrorEmpty.Name = "labelErrorEmpty";
            labelErrorEmpty.Size = new Size(146, 15);
            labelErrorEmpty.TabIndex = 1;
            labelErrorEmpty.Text = "Item name can't be empty";
            labelErrorEmpty.Visible = false;
            // 
            // textBoxNameNewItem
            // 
            textBoxNameNewItem.Location = new Point(58, 70);
            textBoxNameNewItem.Name = "textBoxNameNewItem";
            textBoxNameNewItem.Size = new Size(303, 23);
            textBoxNameNewItem.TabIndex = 2;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(161, 150);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // AddTodoItemsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 324);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxNameNewItem);
            Controls.Add(labelErrorEmpty);
            Controls.Add(labelNameNewItem);
            Name = "AddTodoItemsForm";
            Text = "Add todo items";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNameNewItem;
        private Label labelErrorEmpty;
        private TextBox textBoxNameNewItem;
        private Button buttonAdd;
    }
}