namespace TodoList
{
    partial class TodoListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHeader = new Label();
            textBoxTodo = new TextBox();
            buttonAdd = new Button();
            buttonClear = new Button();
            checkedListBoxTodos = new CheckedListBox();
            buttonClearChecked = new Button();
            buttonClearAll = new Button();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = SystemColors.ActiveCaption;
            lblHeader.Location = new Point(94, 1);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(200, 45);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "What to do?";
            // 
            // textBoxTodo
            // 
            textBoxTodo.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTodo.Location = new Point(12, 56);
            textBoxTodo.Multiline = true;
            textBoxTodo.Name = "textBoxTodo";
            textBoxTodo.Size = new Size(402, 85);
            textBoxTodo.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdd.ForeColor = Color.Green;
            buttonAdd.Location = new Point(12, 147);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(198, 46);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonClear
            // 
            buttonClear.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClear.ForeColor = Color.FromArgb(192, 0, 0);
            buttonClear.Location = new Point(216, 147);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(198, 46);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // checkedListBoxTodos
            // 
            checkedListBoxTodos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBoxTodos.FormattingEnabled = true;
            checkedListBoxTodos.Location = new Point(12, 199);
            checkedListBoxTodos.Name = "checkedListBoxTodos";
            checkedListBoxTodos.Size = new Size(402, 274);
            checkedListBoxTodos.TabIndex = 4;
            // 
            // buttonClearChecked
            // 
            buttonClearChecked.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClearChecked.ForeColor = Color.FromArgb(64, 64, 0);
            buttonClearChecked.Location = new Point(12, 478);
            buttonClearChecked.Name = "buttonClearChecked";
            buttonClearChecked.Size = new Size(198, 46);
            buttonClearChecked.TabIndex = 5;
            buttonClearChecked.Text = "Clear checked";
            buttonClearChecked.UseVisualStyleBackColor = true;
            buttonClearChecked.Click += buttonClearChecked_Click;
            // 
            // buttonClearAll
            // 
            buttonClearAll.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClearAll.ForeColor = Color.FromArgb(192, 0, 0);
            buttonClearAll.Location = new Point(216, 478);
            buttonClearAll.Name = "buttonClearAll";
            buttonClearAll.Size = new Size(198, 46);
            buttonClearAll.TabIndex = 6;
            buttonClearAll.Text = "Clear all";
            buttonClearAll.UseVisualStyleBackColor = true;
            buttonClearAll.Click += buttonClearAll_Click;
            // 
            // TodoListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 534);
            Controls.Add(buttonClearAll);
            Controls.Add(buttonClearChecked);
            Controls.Add(checkedListBoxTodos);
            Controls.Add(buttonClear);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxTodo);
            Controls.Add(lblHeader);
            Name = "TodoListForm";
            Text = "Todo list";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private TextBox textBoxTodo;
        private Button buttonAdd;
        private Button buttonClear;
        private CheckedListBox checkedListBoxTodos;
        private Button buttonClearChecked;
        private Button buttonClearAll;
    }
}