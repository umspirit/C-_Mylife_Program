using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 비프
{
    public partial class Form_Financial : Form
    {
        public Form_Financial()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void btn_Accountmanage_Click(object sender, EventArgs e)
        {
            Form_Financial_Account f = new Form_Financial_Account(this);
            f.ShowDialog();
             
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
