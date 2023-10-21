namespace TodoListPlus
{
    public partial class TodoListMainForm : Form
    {
        public List<string> TodoLists = new();
        public List<string> TodoItems = new();
        public List<bool> IsComplete = new();

        private string TodoListPath = "../../../lists/todo-lists.txt";
        private string TodoItemsPath;

        public TodoListMainForm()
        {
            InitializeComponent();

            if(!Directory.Exists(Path.GetDirectoryName(TodoListPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(TodoListPath));
            }

            listBoxTodoLists.DataSource = TodoLists;
            listBoxTodoLists.SelectedIndex = -1;
            NoTodoListSelected();
        }

        private void NoTodoListSelected()
        {
            labelCurrentList.Text = "Choose or create new Todo list";
            buttonAdd.Enabled = false;
            buttonRemove.Enabled = false;
            buttonRename.Enabled = false;
            buttonDeleteList.Enabled = false;
            buttonRenameList.Enabled = false;
        }
    }
}