namespace TodoListPlus
{
    partial class TodoListMainForm
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
            buttonRename = new Button();
            buttonRemove = new Button();
            buttonAdd = new Button();
            buttonDeleteList = new Button();
            buttonRenameList = new Button();
            checkedListBoxTodoItems = new CheckedListBox();
            labelCurrentList = new Label();
            buttonAddList = new Button();
            listBoxTodoLists = new ListBox();
            SuspendLayout();
            // 
            // buttonRename
            // 
            buttonRename.Location = new Point(680, 314);
            buttonRename.Name = "buttonRename";
            buttonRename.Size = new Size(130, 49);
            buttonRename.TabIndex = 26;
            buttonRename.Text = "Rename";
            buttonRename.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(477, 314);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(130, 49);
            buttonRemove.TabIndex = 25;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(274, 314);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(130, 49);
            buttonAdd.TabIndex = 24;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteList
            // 
            buttonDeleteList.Location = new Point(612, 418);
            buttonDeleteList.Name = "buttonDeleteList";
            buttonDeleteList.Size = new Size(198, 69);
            buttonDeleteList.TabIndex = 23;
            buttonDeleteList.Text = "Delete list";
            buttonDeleteList.UseVisualStyleBackColor = true;
            // 
            // buttonRenameList
            // 
            buttonRenameList.Location = new Point(274, 418);
            buttonRenameList.Name = "buttonRenameList";
            buttonRenameList.Size = new Size(198, 69);
            buttonRenameList.TabIndex = 22;
            buttonRenameList.Text = "Rename list";
            buttonRenameList.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxTodoItems
            // 
            checkedListBoxTodoItems.FormattingEnabled = true;
            checkedListBoxTodoItems.Location = new Point(274, 52);
            checkedListBoxTodoItems.Name = "checkedListBoxTodoItems";
            checkedListBoxTodoItems.Size = new Size(536, 256);
            checkedListBoxTodoItems.TabIndex = 21;
            // 
            // labelCurrentList
            // 
            labelCurrentList.AutoSize = true;
            labelCurrentList.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelCurrentList.Location = new Point(372, 11);
            labelCurrentList.Name = "labelCurrentList";
            labelCurrentList.Size = new Size(142, 30);
            labelCurrentList.TabIndex = 20;
            labelCurrentList.Text = "<Current list>";
            // 
            // buttonAddList
            // 
            buttonAddList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddList.Location = new Point(28, 439);
            buttonAddList.Name = "buttonAddList";
            buttonAddList.Size = new Size(222, 48);
            buttonAddList.TabIndex = 19;
            buttonAddList.Text = "Add new list";
            buttonAddList.UseVisualStyleBackColor = true;
            // 
            // listBoxTodoLists
            // 
            listBoxTodoLists.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxTodoLists.FormattingEnabled = true;
            listBoxTodoLists.ItemHeight = 21;
            listBoxTodoLists.Location = new Point(28, 43);
            listBoxTodoLists.Name = "listBoxTodoLists";
            listBoxTodoLists.Size = new Size(222, 382);
            listBoxTodoLists.TabIndex = 18;
            // 
            // TodoListMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(838, 548);
            Controls.Add(buttonRename);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(buttonDeleteList);
            Controls.Add(buttonRenameList);
            Controls.Add(checkedListBoxTodoItems);
            Controls.Add(labelCurrentList);
            Controls.Add(buttonAddList);
            Controls.Add(listBoxTodoLists);
            MaximizeBox = false;
            Name = "TodoListMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todo list";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonRename;
        private Button buttonRemove;
        private Button buttonAdd;
        private Button buttonDeleteList;
        private Button buttonRenameList;
        private CheckedListBox checkedListBoxTodoItems;
        private Label labelCurrentList;
        private Button buttonAddList;
        private ListBox listBoxTodoLists;
    }
}