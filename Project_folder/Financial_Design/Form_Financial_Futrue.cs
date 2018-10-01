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
    public partial class Form_Financial_Futrue : Form
    {
        Form_Financial form = null;
        List<string> right_list = new List<string> { };

        public Form_Financial_Futrue(Form_Financial f)
        {
            InitializeComponent();
            form = f;
        }

        private void btn_Futrue_add_register_Click(object sender, EventArgs e)
        {
            int a;

            if(txt_Futrue_add_name.Text != null || int.TryParse(txt_Futrue_add_object.Text, out a))
            {
                FileSave();
                this.Close();
            }
            else
            {
                MessageBox.Show("잘못 입력되었습니다.", "오류");
            }
        }

        private void FileSave()
        {
            string path = Application.StartupPath + "\\미래자금\\", filename = txt_Futrue_add_name.Text + ".txt";

            if(!File_Check(path, filename))
            {
                File.AppendAllText(path + filename, txt_Futrue_add_object.Text + "$0\r\n");
            }
            LeftView_Setting();
        }

        private bool File_Check(string path, string file)
        {
            if (Directory.Exists(path))
            {
                if (File.Exists(path + file))
                    return true;
                else
                    return false;
            }
            else
            {
                Directory.CreateDirectory(path);
                return false;
            }
        }
        
        public void LeftView_Setting()
        {
            form.lvw_Futrue_left.Items.Clear();

            string path = Application.StartupPath + "\\미래자금\\", line;
            DirectoryInfo direcinfo = new DirectoryInfo(path);

            if (direcinfo.Exists)
            {
                foreach (var item in direcinfo.GetFiles())
                {
                    string[] tmp_s = item.Name.Split('.'); // 파일명과 확장자를 분리
                    string filename = tmp_s[0]; // 파일의 이름만 저장

                    StreamReader sr = new StreamReader(path + item.Name);
                    ListViewItem list_item = new ListViewItem(filename);

                    if ((line = sr.ReadLine()) != null)
                    {
                        tmp_s = line.Split('$');
                        list_item.SubItems.Add(tmp_s[0]);
                    }
                    form.lvw_Futrue_left.Items.Add(list_item);
                    sr.Close();
                }
                if(form.lvw_Futrue_left.Items.Count > 0)
                {
                    form.lvw_Futrue_left.Items[0].Selected = true;
                }
            }
        }

        // 자금 등록 버튼을 눌렀을 때
        public void Addmoney()
        {
            int tmp_num = 0;

            if (int.TryParse(form.txt_futrue_addmoney.Text, out tmp_num)) {
                string today_s = DateTime.Now.ToString("yy-MM-dd");
                string path = Application.StartupPath + "\\미래자금\\";

                ListView.SelectedListViewItemCollection listitem = form.lvw_Futrue_left.SelectedItems;
                string str = "";

                // Listitem에서 Subitem의 아이템을 가져옴
                foreach (ListViewItem item in listitem)
                {
                    str = item.SubItems[0].Text; // 자금명을 가져온다.
                    str += ".txt";
                }
                File.AppendAllText(path + str, today_s + "$" + tmp_num.ToString() + "\r\n");
            }
            Select_Listview();
            form.txt_futrue_addmoney.Text = "";
        }

        // Listview에서 아이템을 선택했을 때
        public void Select_Listview()
        {
            form.lvw_Future_right.Items.Clear();

            string path = Application.StartupPath + "\\미래자금\\", line = "", str = "";
            string[] tmp_s;
            ListView.SelectedListViewItemCollection listitem = form.lvw_Futrue_left.SelectedItems;
            int count = 0, obj_money = 0; ;

            if (listitem.Count > 0)
            {

                // Listitem에서 Subitem의 아이템을 가져옴
                foreach (ListViewItem item in listitem)
                {
                    str = item.SubItems[0].Text;
                    int.TryParse(item.SubItems[1].Text, out obj_money);
                }

                StreamReader sr = new StreamReader(path + str + ".txt");

                while ((line = sr.ReadLine()) != null)
                {
                    if (count > 0)
                    {
                        tmp_s = line.Split('$');

                        ListViewItem list_item = new ListViewItem(tmp_s[0]);
                        list_item.SubItems.Add(tmp_s[1]);
                        right_list.Add(line);
                        form.lvw_Future_right.Items.Add(list_item);
                    }
                    else
                    {
                        right_list.Add(line);
                    }
                    count++;
                }
                sr.Close();

                int sum = 0;

                for(int i = 0; i< form.lvw_Future_right.Items.Count; i++)
                {
                    sum += int.Parse(form.lvw_Future_right.Items[i].SubItems[1].Text);
                }

                if (sum < obj_money)
                {
                    form.lbl_future_storemoney.Text = sum.ToString() + " 원";
                    form.pbr_Futrue.Maximum = obj_money;
                    form.pbr_Futrue.Value = sum;
                    form.lbl_Futrue_percent.Text = ((sum * 100) / obj_money).ToString();
                }
                else
                {
                    MessageBox.Show("목표를 달성했으므로 삭제합니다.");
                    ListView.SelectedListViewItemCollection lvw_select = form.lvw_Futrue_left.SelectedItems;

                    if (lvw_select[0].Text != null)
                    {
                        List_Delete();
                    }
                    form.lvw_Future_right.Items.Clear();
                }
            }
        }

        private void Form_Financial_Futrue_Load(object sender, EventArgs e)
        {

        }

        public void List_Delete()
        {
            ListView.SelectedListViewItemCollection lvw_item = form.lvw_Futrue_left.SelectedItems;

            string path = Application.StartupPath + "\\미래자금\\";
            DirectoryInfo direcinfo = new DirectoryInfo(path);

            foreach(var item in direcinfo.GetFiles())
            {
                string[] s = item.Name.Split('.'); // 확장자를 분리
                if(s[0] == lvw_item[0].Text)
                {
                    File.Delete(item.FullName);
                    LeftView_Setting();
                    break;
                } 
            }
        }
    }
}
