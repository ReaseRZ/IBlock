using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IBlock
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listBox1.SelectedIndices.Count > 0)
                MessageBox.Show("Selected Index is " + listBox1.SelectedIndices[0]);
            else
                MessageBox.Show("No item selected");
        }

    }
}
