using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace 비프
{
    class Class_Salary_Control 
    {
        Form_Financial f;
        private string path = Application.StartupPath + "\\월급관리" , filename = "\\회사정보.txt";
        
        public Class_Salary_Control(Form_Financial form)
        {
            f = form;
        }

        public string Path
        {
            get
            {
                return path;
            }
        }
        public string File_Name
        {
            get
            {
                return filename;
            }
        }

        public void Control_Hide()
        {
            f.txt_sal_company.Visible = false;
            f.dtp_sal_join.Visible = false;
            f.txt_sal_position.Visible = false;
            f.txt_sal_pay.Visible = false;

            f.btn_sal_register.Visible = false;
            f.btn_sal_cancel.Visible = false;

            f.pnl_sal_detailed.Visible = true;

            f.lbl_Futrue_Info.Visible = false;
        }

        public void Control_Show()
        {
            f.txt_sal_company.Visible = true;
            f.dtp_sal_join.Visible = true;
            f.txt_sal_position.Visible = true;
            f.txt_sal_pay.Visible = true;

            f.btn_sal_register.Visible = true;
            f.btn_sal_cancel.Visible = true;

            f.pnl_sal_detailed.Visible = false;

            f.lbl_Futrue_Info.Visible = true;
        }

        public void Inforamtion_Revise()
        {
            string str; 

            if(File_Check(path, filename))
            {
                File.Delete(path + filename);
            }
            File.Create(path + filename).Close();

            str = f.txt_sal_company.Text + "$" + f.txt_sal_position.Text + "$" + f.dtp_sal_join.Text 
                + "$" + f.txt_sal_pay.Text;

            File.AppendAllText(path + filename, str);

            f.txt_sal_company.Clear();
            f.txt_sal_position.Clear();
            f.txt_sal_pay.Clear();
        }

        // 직장정보에 대한 Label을 세팅
        public void Label_Setting()
        {
            if(File_Check(path, filename))
            {
                string line;
                string[] tmp_s = null;
                int annual = 0;

                StreamReader sr = new StreamReader(path + filename);

                while((line = sr.ReadLine()) != null)
                {
                    tmp_s = line.Split('$');
                }
                sr.Close();

                
                {
                    for(int i = 0; i< tmp_s.Length; i++)
                    {
                        if (tmp_s[i].Length > 0)
                        {
                            switch (i)
                            {
                                case 0:
                                    f.lbl_sal_company.Text = tmp_s[0];
                                    break;
                                case 1:
                                    f.lbl_sal_position.Text = tmp_s[1];
                                    break;
                                case 2:
                                    f.lbl_sal_join.Text = tmp_s[2];
                                    DateTime T1 = DateTime.Parse(tmp_s[2]);
                                    DateTime T2 = DateTime.Parse(DateTime.Now.ToString("yy-MM-dd"));

                                    TimeSpan TS = T2 - T1;

                                    f.lbl_sal_workday.Text = TS.Days.ToString() + "일";
                                    break;
                                case 3:
                                    f.lbl_sal_pay.Text = tmp_s[3];
                                    annual = int.Parse(tmp_s[3]) * 12;
                                    f.lbl_sal_annualincome.Text = annual.ToString();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        // 폴더, 파일이 존재하는지 확인
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

        public void IncomeList_Setting()
        {
            f.str_list.Clear();
            f.lvw_sal_income.Items.Clear();

            string income_path = path += "\\급여\\";

            DirectoryInfo direc = new DirectoryInfo(income_path);

            if (direc.Exists)
            {
                string line;

                foreach (var item in direc.GetFiles())
                {
                    f.str_list.Add(item.Name);
                }

                for (int i = 0; i < f.str_list.Count; i++)
                {
                    StreamReader sr = new StreamReader(path + f.str_list[i]);
                    if((line = sr.ReadLine()) != null)
                    {
                        string[] s = line.Split('$');

                        ListViewItem li = new ListViewItem(s[0]);
                        li.SubItems.Add(s[5]);
                        f.lvw_sal_income.Items.Add(li);
                    }
                    sr.Close();
                }
                if (f.lvw_sal_income.Items.Count > 0)
                    f.lvw_sal_income.Items[0].Selected = true;
            }
        }

        public void Incomeinfo_setting(string file_name)
        {
            string income_path = path += "\\급여\\";

            if(File_Check(income_path, file_name))
            {
                StreamReader sr = new StreamReader(income_path + file_name);
                string line1 = "", line2 = "";
                int count = 0;

                while((count < 2))
                {
                    if(count == 0)
                        line1 = sr.ReadLine();
                    else
                        line2 = sr.ReadLine();
                    count++;
                }
                sr.Close();

                string[] s = line1.Split('$');
                f.lbl_sal_t1.Text = s[1];
                f.lbl_sal_t2.Text = s[2];
                f.lbl_sal_t3.Text = s[3];
                f.lbl_sal_t4.Text = s[4];

                s = line2.Split('$');
                f.lbl_sal_b1.Text = s[0];
                f.lbl_sal_b2.Text = s[1];
                f.lbl_sal_b3.Text = s[2];
                f.lbl_sal_b4.Text = s[3];
                f.lbl_sal_b5.Text = s[4];
                f.lbl_sal_b6.Text = s[5];
            }
        }
    }
}