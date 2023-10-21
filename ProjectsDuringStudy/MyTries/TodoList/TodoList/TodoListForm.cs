namespace TodoList
{
    public partial class TodoListForm : Form
    {
        public TodoListForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTodo.Text))
                return;

            checkedListBoxTodos.Items.Add(textBoxTodo.Text);
            textBoxTodo.ResetText();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTodo.ResetText();
        }

        private void buttonClearChecked_Click(object sender, EventArgs e)
        {
           for (int i = 0; i < checkedListBoxTodos.Items.Count; i ++)
            {
                if(checkedListBoxTodos.GetItemChecked(i))
                {
                    checkedListBoxTodos.Items.RemoveAt(i);
                }
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            checkedListBoxTodos.Items.Clear();
        }
    }
}