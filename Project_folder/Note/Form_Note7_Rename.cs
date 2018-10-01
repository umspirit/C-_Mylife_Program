using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 비프
{
    public partial class Form_Note7_Rename : Form
    {
        private string oldname;
        private string newname;

        public Form_Note7_Rename(string old)
        {
            oldname = old;
            InitializeComponent();
        }

        public string New_Name {
            set
            {
                newname = value;
            }
            get
            {
                return newname;
            }
        }


        private int File_Check()
        {
            string oldpath = Application.StartupPath + "\\Note\\" + oldname + ".txt";
            newname = textBox_filename.Text;
            string newpath = Application.StartupPath + "\\Note\\" + newname + ".txt";

            if (File.Exists(newpath) == false)
            {
                File.Move(oldpath, newpath);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void button_rename_Click(object sender, EventArgs e)
        {
            if(File_Check() == 1)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("이미 존재하는 파일입니다.", "파일 중복");
                textBox_filename.Clear();
                textBox_filename.Select();
            }
        }
    }
}