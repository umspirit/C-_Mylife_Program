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

/*
 * 미션 5 - (3) : 원래는 멀티폼이었던 가계부를 새로운 Form_Financial에 포함시켰습니다.
 */


namespace 비프
{
    public partial class Form_Financial : Form
    {
        int now_year;
        int now_month;
        int now_day;
        public string image_storepath = "", ofd_path = "", file_extend = "";
        public string pro_str = "";

        private int proper_cnt = 0;
        List<int> num_list = new List<int> { }; // 탭의 중복생성을 막아주는 List 클래스
        public List<string> str_list = new List<string> { };

        public Form_Financial()
        {
            InitializeComponent();

            for (int i = 1; i < tabctl_menu.TabCount; i++) // 홈 tabpage빼고 나머지는 없앤다.
            {
                tabctl_menu.TabPages.RemoveAt(i--);
            }
        }

        struct Property_list
        {
            public int id;
            public int price;
        }

        private void DateTime_set()
        {
            now_year = int.Parse(DateTime.Now.ToString("yyyy"));
            now_month = int.Parse(DateTime.Now.ToString("MM"));
            now_day = int.Parse(DateTime.Now.ToString("dd"));
        }

        private void CheckBox_Setting()
        {
            for (int i = 0; i < 60; i++)
            {
                cbo_acc_year.Items.Add(now_year--.ToString());
                cbo_acc_year.SelectedIndex = 0;
            }
            cbo_acc_month.SelectedIndex = now_month - 1;
            cbo_acc_day.SelectedIndex = now_day - 1;
            cbo_acc_how.SelectedIndex = 0;

            cbo_acc_year.Enabled = false;
            cbo_acc_month.Enabled = false;
            cbo_acc_day.Enabled = false;

            rbtn_acc_today.Checked = true;
        }

        private void btn_proregister_Click(object sender, EventArgs e)
        {
            Class_Property_Add c1 = new Class_Property_Add(this, proper_cnt);
            Button btn = (Button)sender;

            if (btn == btn_proregister)
            {
                pnl_property_add.Visible = true;

                Proper_Count();
                Property_ListSetting();
            }
            else if (btn == btn_store)
            {
                image_storepath = c1.Path_Get;
            }
        }

        private void Proper_Count() // 재산목록의 수를 센다.
        {
            string path = Application.StartupPath + "\\재산\\재산사진";
            string[] s;
            int max = 0, tmp_num = 0;

            DirectoryInfo direc = new DirectoryInfo(path);
            direc.Create();
            foreach (var str in direc.GetFiles())
            {
                s = str.Name.Split('$');
                int.TryParse(s[0], out tmp_num);
                if (tmp_num > max)
                {
                    max = int.Parse(s[0]);
                }
            }
            proper_cnt = max;
        }

        private void Property_ListSetting() // 재산관리 - ListView를 세팅하는 함수
        {
            lvw_property.Items.Clear();
            str_list.Clear();

            int tmp_num = 0;
            string line, path = Application.StartupPath + "\\재산\\재산메모";
            List<Property_list> property_list = new List<Property_list> { };

            if (Directory.Exists(path) == false) // 폴더가 있는지 확인하고 생성
            {
                Directory.CreateDirectory(path);
            }
            path += "\\property.txt";
            if (File.Exists(path) == false) //파일이 있는지 확인하고 생성
            {
                File.Create(path).Close();
            }

            if (File.Exists(path) == true)
            {
                string[] s;
                StreamReader sr = new StreamReader(path);
                while ((line = sr.ReadLine()) != null)
                {
                    Property_list p;
                    str_list.Add(line);
                    s = line.Split('$');
                    int.TryParse(s[2], out tmp_num);

                    if (property_list.Count != 0)
                    {
                        for (int i = 0; i < property_list.Count; i++) // 금액순으로 Property_list를 정렬한다.
                        {
                            if (tmp_num <= property_list[i].price)
                            {
                                p.price = tmp_num;
                                p.id = int.Parse(s[0]);
                                property_list.Insert(i, p);
                                break;
                            }
                            else if (i == property_list.Count - 1)
                            {
                                p.price = tmp_num;
                                p.id = int.Parse(s[0]);
                                property_list.Insert(property_list.Count, p);
                                break;
                            }
                        }
                    }
                    else if (property_list.Count == 0)
                    {
                        p.price = tmp_num;
                        p.id = int.Parse(s[0]);
                        property_list.Insert(0, p);
                    }
                }
                sr.Close();

                // ListView 세팅시작
                for (int i = property_list.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < str_list.Count; j++)
                    {
                        s = str_list[j].Split('$');
                        if (property_list[i].id.ToString() == s[0])
                        {
                            ListViewItem listitem = new ListViewItem(new String[] { s[1], s[2], s[3] });
                            //listitem.SubItems.Add(s[2]);
                            //listitem.SubItems.Add(s[3]);
                            lvw_property.Items.Add(listitem);
                            lvw_property.FullRowSelect = true;
                        }
                    }
                }
                if (lvw_property.Items.Count > 0)
                {
                    lvw_property.Items[0].Selected = true;
                    lvw_property.Items[0].Focused = true;
                }
            }
        }

        // Financil Form에 있는 8개의 탭중 하나가 눌렸을 때
        private void tabctl_menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tab = (TabControl)sender;

            str_list.Clear();

            if (tab.SelectedTab == tabPage2) // TabPage2이 눌렀을 때
            {
                Property_ListSetting();
                Proper_Count();
            }
            else if (tab.SelectedTab == tabPage3) // TabPage3이 눌렀을 때
            {
                string path = Application.StartupPath + "\\통장관리";

                lbl_accountname.Text = "- " + tabp_deposit.Text + " 계좌 리스트";
                TabPage3_ListView_Setting(3, path, "\\예금.txt");
            }
            else if (tab.SelectedTab == tabPage4)
            {

            }
            else if (tab.SelectedTab == tabPage7)
            {
                Class_Kookmin class_k = new Class_Kookmin(this);
                class_k.Control_Setting();
            }
            else if (tab.SelectedTab == tabPage8)
            {
                Form_Financial_Futrue f = new Form_Financial_Futrue(this);
                f.LeftView_Setting();
            }
        }

        // 재산관리 - 재산삭제 버튼을 클릭했을 때
        private void btn_prodelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lvw_sel = lvw_property.SelectedItems;

            if (lvw_sel.Count > 0)
            {
                if (MessageBox.Show(lvw_property.SelectedItems[0].Text + "을 정말 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string[] s;
                    string str = "", exten = "", path = Application.StartupPath + "\\재산\\재산메모\\property.txt";
                    List<string> pic_list = new List<string> { };
                    List<string> file_list = new List<string> { };

                    foreach (ListViewItem row in lvw_property.SelectedItems)
                    {
                        int index = row.Index;
                        lvw_property.Items.Remove(row);
                    }

                    File.Delete(path);
                    FileInfo file_info = new FileInfo(path);

                    if (file_info.Exists == false) // 파일이 존재하는지 검사
                    {
                        FileStream fs = file_info.Create();
                        fs.Close();
                    }

                    for (int i = 0; i < lvw_property.Items.Count; i++)
                    {
                        for (int j = 0; j < lvw_property.Items[0].SubItems.Count; j++)
                        {
                            for (int k = 0; j == 0 && k < str_list.Count; k++)
                            {
                                s = str_list[k].Split('$');
                                if (lvw_property.Items[i].SubItems[0].Text == s[1] && lvw_property.Items[i].SubItems[2].Text == s[3])
                                {
                                    str = s[0] + "$" + s[1] + "$" + s[2] + "$" + s[3] + "$" + s[4] + "\r\n";
                                    file_list.Add(s[0]);
                                    break;
                                }
                            }
                        }
                        File.AppendAllText(path, str);
                    }

                    path = Application.StartupPath + "\\재산\\재산사진\\";
                    DirectoryInfo direc = new DirectoryInfo(path);

                    foreach (var item in direc.GetFiles())
                    {
                        s = item.Name.Split('$');
                        pic_list.Add(s[0]);
                        exten = item.Extension;
                    }

                    for (int i = 0; i < pic_list.Count; i++)
                    {
                        bool check = false;
                        for (int j = 0; j < file_list.Count; j++)
                        {
                            if (pic_list[i] == file_list[j])
                            {
                                check = true;
                            }
                        }
                        if (check == false)
                        {
                            File.Delete(path + pic_list[i] + "$property" + exten);
                        }
                    }

                    lbl_proper_name.Text = "";
                    lbl_proper_price.Text = "";
                    lbl_proper_purchaseday.Text = "";
                    lbl_proper_sn.Text = "";

                    pic_properimage.Image = null;
                }
            }
        }

        // 메인화면 왼쪽버튼에 들어갈 때
        private void btn_salarymanage_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.ForeColor = Color.LightCyan;
            b.Width += 7;
            b.Font = new Font(b.Font.FontFamily, b.Font.Size, FontStyle.Bold);
        }

        // 메인화면 왼쪽버튼에서 나올 때
        private void btn_salarymanage_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.ForeColor = Color.Cyan;
            b.Width -= 7;
            b.Font = new Font(b.Font.FontFamily, b.Font.Size, FontStyle.Regular);
        }

        private void 재산등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_Property_Add c1 = new Class_Property_Add(this, proper_cnt);

            pnl_property_add.Visible = true;

            Proper_Count();
            Property_ListSetting();
        }

        // 계좌 관리탭에서 <계좌 등록> 버튼을 눌렀을 때
        private void btn_account_add_Click(object sender, EventArgs e)
        {
            cbo_banklist.SelectedIndex = 0;

            lbl_account_name.Visible = false;
            lbl_account_bank.Visible = false;
            lbl_account_number.Visible = false;
            lbl_account_rate.Visible = false;
            lbl_account_makeday.Visible = false;
            lbl_account_money.Visible = false;

            txt_account_money.Visible = true;
            txt_account_makeday.Visible = true;
            txt_account_name.Visible = true;
            txt_account_number.Visible = true;
            txt_account_rate.Visible = true;
            cbo_banklist.Visible = true;

            btn_account_register.Visible = true;
            btn_account_cancel.Visible = true;

            btn_account_add.Enabled = false;
            btn_account_delete.Enabled = false;
        }

        // 재산관리 탭에서 등록 button을 눌렀을 때
        private void btn_account_register_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Label 비활성화
            txt_account_money.Visible = false;
            txt_account_makeday.Visible = false;
            txt_account_name.Visible = false;
            txt_account_number.Visible = false;
            txt_account_rate.Visible = false;
            cbo_banklist.Visible = false;
            // TextBox 활성화
            lbl_account_name.Visible = true;
            lbl_account_bank.Visible = true;
            lbl_account_number.Visible = true;
            lbl_account_rate.Visible = true;
            lbl_account_makeday.Visible = true;
            lbl_account_money.Visible = true;

            btn_account_register.Visible = false;
            btn_account_cancel.Visible = false;

            btn_account_add.Enabled = true;
            btn_account_delete.Enabled = true;

            if (btn == btn_account_register)
            {
                string path = Application.StartupPath + "\\통장관리";

                if (tab_Account.SelectedTab == tabp_deposit)
                {
                    TabPage3_Register(path, "\\예금.txt");
                }
                else if (tab_Account.SelectedTab == tabp_installment)
                {
                    TabPage3_Register(path, "\\적금.txt");
                }
                TabPage3_ListView_Setting(3, path, "\\" + tab_Account.SelectedTab.Text + ".txt");
            }
        }

        // TabPage3에서 파일로 저장하는 함수
        private void TabPage3_Register(string path, string filename)
        {
            string tmp_path = path + filename;
            FileInfo file_info = new FileInfo(tmp_path);

            if (!file_info.Exists)
            {
                FileStream file = file_info.Create();
                file.Close();
            }

            string tmp_str = txt_account_number.Text + "$" + cbo_banklist.SelectedItem + "$" + txt_account_name.Text +
                "$" + txt_account_money.Text + "$" + txt_account_makeday.Text + "$" + txt_account_rate.Text;

            File.AppendAllText(tmp_path, tmp_str + "\r\n");

            txt_account_money.Clear();
            txt_account_makeday.Clear();
            txt_account_name.Clear();
            txt_account_number.Clear();
            txt_account_rate.Clear();

            cbo_banklist.SelectedIndex = 0;
        }

        // TabPage3에 있는 예금, 적금 탭클릭
        private void tab_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tab = (TabControl)sender;
            string path = Application.StartupPath + "\\통장관리";

            lbl_account_name.Text = "";
            lbl_account_number.Text = "";
            lbl_account_money.Text = "";
            lbl_account_makeday.Text = "";
            lbl_account_bank.Text = "";
            lbl_account_rate.Text = "";

            if (tab.SelectedTab == tabp_deposit)
            {
                lbl_accountname.Text = "- " + tabp_deposit.Text + " 계좌 리스트";
                TabPage3_ListView_Setting(3, path, "\\예금.txt");
            }
            else if (tab.SelectedTab == tabp_installment)
            {
                lbl_accountname.Text = "- " + tabp_installment.Text + " 계좌 리스트";
                TabPage3_ListView_Setting(3, path, "\\적금.txt");
            }
        }

        // 파일을 불러와서 TabPage3에 있는 ListView에 세팅
        private void TabPage3_ListView_Setting(int tabindex, string path, string filename)
        {
            str_list.Clear();

            string line;

            if (Directory.Exists(path) == false) // 폴더가 있는지 확인하고 생성
            {
                Directory.CreateDirectory(path); // 디렉터리를 생성
            }
            path += filename;
            if (File.Exists(path) == false) //파일이 있는지 확인하고 생성
            {
                File.Create(path).Close(); // 파일을 생성
            }

            if (File.Exists(path) == true)
            {
                StreamReader sr = new StreamReader(path);
                while ((line = sr.ReadLine()) != null)
                {
                    str_list.Add(line); // string List에 값을 저장한다.
                }
                sr.Close();

                switch (tabindex)
                {
                    case 3:
                        TabPage3_ListView();
                        break;
                }
            }
        }

        // Tabpage3에 있는 Listview를 세팅
        private void TabPage3_ListView()
        {
            lvw_Account_manage.Items.Clear();
            string[] tmp_s;

            for (int i = 0; i < str_list.Count; i++)
            {
                tmp_s = str_list[i].Split('$');
                ListViewItem listitem = new ListViewItem(tmp_s[1]);
                listitem.SubItems.Add(tmp_s[0]);
                lvw_Account_manage.Items.Add(listitem);
                lvw_Account_manage.FullRowSelect = true;
            }

            if (lvw_Account_manage.Items.Count > 0)
            {
                lvw_Account_manage.Items[0].Selected = true;
            }
        }

        // 통장관리 Tab의 Listview 아이템을 선택했을 때
        private void lvw_Account_manage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection listitem = lvw_Account_manage.SelectedItems;
            string str = "";
            string[] tmps;

            // Listitem에서 Subitem의 아이템을 가져옴
            foreach (ListViewItem item in listitem)
            {
                str = item.SubItems[1].Text;
            }

            for (int i = 0; i < str_list.Count; i++)
            {
                tmps = str_list[i].Split('$');

                if (tmps[0] == str)
                {
                    lbl_account_name.Text = tmps[2];
                    lbl_account_bank.Text = tmps[1];
                    lbl_account_number.Text = tmps[0];
                    lbl_account_rate.Text = tmps[5] + " %";
                    lbl_account_makeday.Text = tmps[4];
                    lbl_account_money.Text = tmps[3] + " 원";

                    break;
                }
            }
            btn_account_delete.Enabled = true;
        }

        // 재산관리 Tab의 Listview 아이템을 선택했을 때
        private void lvw_property_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection listitem = lvw_property.SelectedItems;
            string[] str = new string[3];
            string[] tmps;

            foreach (ListViewItem item in listitem)
            {
                str[0] = item.SubItems[0].Text;
                str[1] = item.SubItems[1].Text;
                str[2] = item.SubItems[2].Text;
            }

            for (int i = 0; i < str_list.Count; i++)
            {
                tmps = str_list[i].Split('$');
                if (str[0] == tmps[1] && str[1] == tmps[2] && str[2] == tmps[3])
                {
                    lbl_proper_name.Text = tmps[1];
                    lbl_proper_price.Text = tmps[2] + " 원";
                    lbl_proper_purchaseday.Text = tmps[3];
                    lbl_proper_sn.Text = tmps[4];

                    string path = Application.StartupPath + "\\재산\\재산사진\\";
                    DirectoryInfo direcinfo = new DirectoryInfo(path);

                    foreach (var item in direcinfo.GetFiles())
                    {
                        string[] s = item.Name.Split('$');

                        if (tmps[0] == s[0])
                        {
                            using (FileStream fsin = new FileStream(item.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                Image so = Image.FromStream(fsin);
                                Bitmap bmp = new Bitmap(so);

                                pic_properimage.Image = bmp;
                            }
                            break;
                        }
                    }
                }
            }
        }

        // 통장관리 Tab에서 통장 삭제버튼을 클릭했을 때
        private void btn_account_delete_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                ListView.SelectedListViewItemCollection listitem = lvw_Account_manage.SelectedItems;
                string path = Application.StartupPath + "\\통장관리\\" + tab_Account.SelectedTab.Text + ".txt", str_num = "";
                string[] tmps;


                foreach (ListViewItem item in listitem)
                {
                    str_num = item.SubItems[1].Text;
                }

                for (int i = 0; i < str_list.Count; i++)
                {
                    tmps = str_list[i].Split('$');
                    if (str_num == tmps[0])
                    {
                        str_list.RemoveAt(i);
                        break;
                    }
                }

                FileInfo file = new FileInfo(path);
                FileStream f = file.Create();
                f.Close();

                for (int i = 0; i < str_list.Count; i++)
                {
                    File.AppendAllText(path, str_list[i] + "\r\n");
                }

                TabPage3_ListView();
                btn_account_delete.Enabled = false;

                lbl_accountname.Text = "";
                lbl_account_name.Text = "";
                lbl_account_number.Text = "";
                lbl_account_rate.Text = "";
                lbl_account_makeday.Text = "";
                lbl_account_money.Text = "";
                lbl_account_bank.Text = "";
            }
        }

        private void btn_tabclose_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Red;
            btn.ForeColor = Color.White;
        }

        private void btn_tabclose_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Chartreuse;
            btn.ForeColor = Color.Black;
        }

        private void btn_tabclose_Click(object sender, EventArgs e)
        {
            if (tabctl_menu.SelectedTab != tabPage1)
            {
                string[] tmps = tabctl_menu.SelectedTab.Name.ToString().Split('e');
                tabctl_menu.TabPages.Remove(tabctl_menu.SelectedTab);

                for (int i = 0; i < num_list.Count; i++)
                {
                    if (int.Parse(tmps[1]) == num_list[i])
                    {
                        num_list.RemoveAt(i);
                        break;
                    }
                }
                tabctl_menu.SelectedIndex = tabctl_menu.TabPages.Count - 1;
            }
        }

        private void btn_pension_add_Click(object sender, EventArgs e)
        {
            {
                Class_Kookmin c1 = new Class_Kookmin(this);
                c1.File_Make();

                dtp_pension_birth.Visible = false;
                dtp_pension_first.Visible = false;
                dtp_pension_last.Visible = false;
                dtp_pension_salaryfirst.Visible = false;
                dtp_pension_salarylast.Visible = false;

                txt_pension_salary.Visible = false;

                cbo_pension_expect.Visible = false;

                btn_pension_add.Visible = false;
                btn_pension_cancel.Visible = false;

                txt_pension_salary.Clear();

                c1.Control_Setting();
            }
        }

        // 재산관리 Tabpage의 메뉴중에서 정보수정 메뉴를 클릭했을 때
        private void 정보수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtp_pension_birth.Visible = true;
            dtp_pension_first.Visible = true;
            dtp_pension_last.Visible = true;
            dtp_pension_salaryfirst.Visible = true;
            dtp_pension_salarylast.Visible = true;

            txt_pension_salary.Visible = true;

            cbo_pension_expect.Visible = true;
            cbo_pension_expect.SelectedIndex = 0;

            btn_pension_add.Visible = true;
            btn_pension_cancel.Visible = true;
        }

        // 재산관리 Tabpage에서 취소 버튼을 클릭했을 때
        private void btn_pension_cancel_Click(object sender, EventArgs e)
        {
            dtp_pension_birth.Visible = false;
            dtp_pension_first.Visible = false;
            dtp_pension_last.Visible = false;
            dtp_pension_salaryfirst.Visible = false;
            dtp_pension_salarylast.Visible = false;

            txt_pension_salary.Visible = false;
            txt_pension_salary.Clear();

            cbo_pension_expect.Visible = false;

            btn_pension_add.Visible = false;
            btn_pension_cancel.Visible = false;
        }

        private void rbtn_acc_today_CheckedChanged(object sender, EventArgs e)
        {
            cbo_acc_year.Enabled = false;
            cbo_acc_month.Enabled = false;
            cbo_acc_day.Enabled = false;

            cbo_acc_year.Text = now_year.ToString();
            cbo_acc_month.Text = now_month.ToString();
            cbo_acc_day.Text = now_day.ToString();
        }

        private void rbtn_acc_another_CheckedChanged(object sender, EventArgs e)
        {
            cbo_acc_year.Enabled = true;
            cbo_acc_month.Enabled = true;
            cbo_acc_day.Enabled = true;
        }

        private void btn_account_MouseClick(object sender, MouseEventArgs e)
        {
            {
                Control ctl = (Control)sender;
                TabPage tp = null;
                bool exist = false;

                switch (ctl.Text)
                {
                    case "재산 관리":
                        tp = tabPage2;
                        tabctl_menu.SelectedTab = tabPage2;

                        Property_ListSetting();
                        Proper_Count();
                        break;

                    case "통장 관리":
                        tp = tabPage3;
                        tabctl_menu.SelectedTab = tabPage3;

                        string path = Application.StartupPath + "\\통장관리";

                        lbl_accountname.Text = "- " + tabp_deposit.Text + " 계좌 리스트";
                        TabPage3_ListView_Setting(3, path, "\\예금.txt");
                        break;

                    case "월급 관리":
                        tp = tabPage4;
                        tabctl_menu.SelectedTab = tabPage4;

                        Class_Salary_Control c1 = new Class_Salary_Control(this);

                        c1.Label_Setting();
                        c1.IncomeList_Setting();
                        break;

                    case "국민연금":
                        tp = tabPage7;
                        tabctl_menu.SelectedTab = tabPage7;

                        Class_Kookmin class_k = new Class_Kookmin(this);
                        class_k.Control_Setting();
                        break;

                    case "미래 자금":
                        tp = tabPage8;
                        tabctl_menu.SelectedTab = tabPage8;

                        Form_Financial_Futrue form = new Form_Financial_Futrue(this);
                        form.LeftView_Setting();

                        break;

                    case "가계부":
                        tp = tabPage9;
                        tabctl_menu.SelectedTab = tabPage9;
                        DateTime_set();
                        CheckBox_Setting();
                        break;
                }
                string[] s = tp.Name.Split('e');
                int num = int.Parse(s[1]);

                for (int j = 0; j < num_list.Count; j++)
                {
                    if (num == num_list[j])
                        exist = true;
                }

                if (!exist)
                {
                    tabctl_menu.TabPages.Add(tp);
                    tabctl_menu.SelectedIndex = tabctl_menu.TabCount - 1; // 가장 최근에 생긴 탭을 선택
                    tabctl_menu.SelectedTab = tp;
                    num_list.Add(num);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form_Financial_Futrue f = new Form_Financial_Futrue(this);
            f.Select_Listview();
        }

        private void 목록추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Financial_Futrue form_future = new Form_Financial_Futrue(this);
            form_future.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 정보수정ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_Salary_Control c1 = new Class_Salary_Control(this);
            c1.Control_Show();
        }

        private void btn_sal_cancel_MouseClick(object sender, MouseEventArgs e)
        {
            Class_Salary_Control c1 = new Class_Salary_Control(this);
            c1.Control_Hide();
        }

        private void btn_sal_register_Click(object sender, EventArgs e)
        {
            Class_Salary_Control c1 = new Class_Salary_Control(this);
            c1.Inforamtion_Revise();
            c1.Label_Setting();
        }

        private void 월급등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Finalcial_incomeAdd form1 = new Form_Finalcial_incomeAdd();
            Class_Salary_Control c1 = new Class_Salary_Control(this);
            form1.ShowDialog();

            c1.IncomeList_Setting();
        }

        private void lvw_sal_income_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection listitem = lvw_sal_income.SelectedItems;
            Class_Salary_Control c1 = new Class_Salary_Control(this);
            string str = "";

            // Listitem에서 Subitem의 아이템을 가져옴
            foreach (ListViewItem item in listitem)
            {
                str = item.SubItems[0].Text;
            }
            c1.Incomeinfo_setting(str + ".txt");
        }

        private void btn_account_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvw_Futrue_left.SelectedIndices.Count > 0)
                pnl_future_addmoney.Visible = true;
        }

        private void btn_futrue_cancel_Click(object sender, EventArgs e)
        {
            pnl_future_addmoney.Visible = false;
        }

        private void btn_futrue_addmoney_Click(object sender, EventArgs e)
        {
            Form_Financial_Futrue f = new Form_Financial_Futrue(this);
            f.Addmoney();
            pnl_future_addmoney.Visible = false;
        }

        private void btn_acc_outmoney_Click(object sender, EventArgs e)
        {

        }

        private void cbo_acc_how_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedItem.ToString() == "카드")
            {
                cbo_account_acclist.Enabled = true;
                Class_AccountBook c = new Class_AccountBook(this);
                c.Card_Select();
            }
            else
            {
                cbo_account_acclist.Enabled = false;
            }
        }

        private void cbo_account_acclist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class_AccountBook c = new Class_AccountBook(this);
            c.Acclist_Selected();
        }

        private void btn_acc_searchmon_Click(object sender, EventArgs e)
        {
            Class_AccountBook c = new Class_AccountBook(this);
            c.cboitems_add();
            pnl_acc_searchmon.Visible = true;
            panel8.Visible = true;
        }

        private void btn_acc_yearsearch_Click(object sender, EventArgs e)
        {
            Class_AccountBook c = new Class_AccountBook(this);
            panel8.Controls.Clear();
            c.Dinamic_Create();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel8.Controls.Clear();
            pnl_acc_searchmon.Visible = false;
            panel8.Visible = false;
        }

        private void 재산삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lvw_sel = lvw_property.SelectedItems;

            if (lvw_sel.Count > 0)
                btn_prodelete.PerformClick();
        }

        private void 목록삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lvw_select = lvw_Futrue_left.SelectedItems;

            if (lvw_select[0].Text != null)
            {
                Form_Financial_Futrue f = new Form_Financial_Futrue(this);
                f.List_Delete();
            }
        }

        private void btn_proper_regicancel_Click(object sender, EventArgs e)
        {
            pnl_property_add.Visible = false;
            txt_properName.Clear();
            txt_properPrice.Clear();
            txt_properserial.Clear();
            txt_proper_purchaseday.Clear();
            la_path.Text = "사진을 등록하세요.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Note7 f = new Form_Note7();
            f.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Schedule f = new 비프.Form_Schedule();
            f.ShowDialog();
            this.Show();
        }

        private void mcd_acc_search_DateSelected(object sender, DateRangeEventArgs e)
        {
            Class_AccountBook c = new Class_AccountBook(this);
            c.Monthcalendar_Sel();
        }

        private void btn_acc_inmoney_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Class_AccountBook c = new Class_AccountBook(this);

            if (btn == btn_acc_outmoney)
            {
                c.File_Save("지출");
            }
            else if (btn == btn_acc_inmoney)
            {
                c.File_Save("입금");
            }
            c.Monthcalendar_Sel();
        }

        private void btn_acc_outmoney_Click_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Class_AccountBook c = new Class_AccountBook(this);

            if (btn == btn_acc_outmoney)
            {
                c.File_Save("지출");
            }
            else if (btn == btn_acc_inmoney)
            {
                c.File_Save("입금");
            }
            c.Monthcalendar_Sel();
        }

        private void btn_acc_searchmon_Click_1(object sender, EventArgs e)
        {
            Class_AccountBook c = new Class_AccountBook(this);

            pnl_acc_searchmon.Visible = true;
            panel8.Visible = true;
            c.cboitems_add();
        }

        private void btn_picture_Click(object sender, EventArgs e)
        {
            Class_Property_Add c1 = new Class_Property_Add(this, proper_cnt);
            c1.Open_Image();
            image_storepath = c1.Path_Get;
            ofd_path = c1.str_arr;
            file_extend = c1.File_extend;
        }

        private void btn_store_MouseClick(object sender, MouseEventArgs e)
        {
            Class_Property_Add c1 = new Class_Property_Add(this, proper_cnt);
            Button btn = (Button)sender;

            if (btn == btn_proregister) // 재산 등록버튼일 때
            {
                txt_properName.Select();
                pnl_property_add.Visible = true;

            }
            else if (btn == btn_store) // 등록 버튼일 때
            {
                c1.btn_store_Click();

                Proper_Count();
                Property_ListSetting();
                pnl_property_add.Visible = false;
            }
        }
    }
}