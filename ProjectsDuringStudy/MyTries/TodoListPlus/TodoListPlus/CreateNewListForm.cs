using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoListPlus
{
    public partial class CreateNewListForm : Form
    {
        public string name;
        Size size1 = new Size(250, 150);
        Size size2 = new Size(250, 170);
        Size size3 = new Size(50, 110);
        Size size4 = new Size(49, 110);
        List<string> lists = new List<string>();

        public CreateNewListForm(List<string> list, int mode = 0, string? currentName = null)
        {
            InitializeComponent();

            this.Size = size1;
            labelAlreadyExist.Hide();

            if (mode == 1)
            {

            }
        }
    }
}
