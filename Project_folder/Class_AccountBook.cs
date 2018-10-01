using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 비프
{
    class Class_AccountBook
    {
        Form_Financial f = null;

        public Class_AccountBook(Form_Financial form)
        {
            f = form;
        }

        public void File_Save(string howstr)
        {
            string path = Application.StartupPath + "\\가계부\\" + f.cbo_acc_year.Text + "\\" + f.cbo_acc_month.Text + "\\";
            string filename = f.cbo_acc_day.Text + ".txt";

            File_Exist(path, filename);

            if(Value_Exception() && Account_Check(howstr))
            {// howstr은 지출이냐 입금인지
                string tmp_str = howstr + "$" + f.cbo_acc_how.Text + "$" + f.txt_acc_context.Text + "$" + f.txt_acc_money.Text;
                File.AppendAllText(path + filename, tmp_str + "\r\n");

                f.txt_acc_context.Clear();
                f.txt_acc_money.Clear();
            }
            else
            {
                MessageBox.Show("정확하게 수치를 입력하세요.", "입력 오류");
            }
        }

        public void Acclist_Selected()
        {
            string path = Application.StartupPath + "\\통장관리\\", filename = "예금.txt", line = "";

            if(File.Exists(path + filename))
            {
                StreamReader sr = new StreamReader(path + filename);
                string[] s;

                while ((line = sr.ReadLine()) != null)
                {
                    s = line.Split('$');
                    if(f.cbo_account_acclist.SelectedItem.ToString() == s[0] + " " + s[1])
                    {
                        f.lbl_acc_earlymoney.Text = s[3] + " 원";
                    }
                }
                sr.Close();
            }
        }

        public void File_Exist(string path, string filename)
        {
            Directory.CreateDirectory(path); // 디렉터리 경로가 없으면 새로 만듦

            if(!File.Exists(path + filename)) // 파일이 존재하지 않으면 새로 만듬
            {
                File.Create(path + filename).Close();
            }
        }

        private bool Value_Exception()
        {
            int num = 0;

            if(f.txt_acc_context.Text != null && int.TryParse(f.txt_acc_money.Text, out num) && f.cbo_acc_how.Text != null)
            {
                return true;
            }
            return false;
        }

        public void Card_Select()
        {
            f.cbo_account_acclist.Items.Clear();

            string path = Application.StartupPath + "\\통장관리\\", filename = "예금.txt", line = "";

            if(File.Exists(path + filename))
            {
                StreamReader sr = new StreamReader(path + filename);
                string[] s;

                while ((line = sr.ReadLine()) != null)
                {
                    s = line.Split('$');
                    f.cbo_account_acclist.Items.Add(s[0] + " " + s[1]);
                    f.lbl_acc_earlymoney.Text = s[3];
                }
                sr.Close();

                if (f.cbo_account_acclist.Items.Count > 0)
                    f.cbo_account_acclist.SelectedIndex = 0;
            }
        }

        public void cboitems_add()
        {
            string path = Application.StartupPath + "\\가계부\\";
            DirectoryInfo direcinfo = new DirectoryInfo(path);

            foreach(var item in direcinfo.GetDirectories())
            {
                f.comboBox1.Items.Add(item.Name);
            }
            f.comboBox1.SelectedIndex = 0;

        }

        public void Dinamic_Create()
        {
            string path = Application.StartupPath + "\\가계부\\" + f.comboBox1.SelectedItem.ToString() + "\\", line = ""; // 년
            DirectoryInfo direcinfo = new DirectoryInfo(path);
            List<int> list = new List<int> {};
            int total = 0, max = 340;

            for (int i = 1; i < 13; i++)
            {
                DirectoryInfo dinfo = new DirectoryInfo(path + i.ToString() + "\\"); // 월
                list.Add(0);

                if (dinfo.Exists)
                {
                    foreach (var file in dinfo.GetFiles()) // 일
                    {
                        StreamReader sr = new StreamReader(file.FullName);
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] s = line.Split('$');

                            if (s[0] == "지출")
                            {
                                list[list.Count - 1] += int.Parse(s[3]);
                                total += int.Parse(s[3]);
                            }
                        }
                    }
                }
            }
            Label[] la = new Label[list.Count];
            Label[] la2 = new Label[list.Count];
            Label[] la3 = new Label[list.Count];

            for (int i = 0; i<list.Count; i++)
            {
                la[i] = new Label();
                f.panel8.Controls.Add(la[i]);
                if (list[i] > 0 && total > 0)
                    la[i].Text = (list[i] * 100 / total).ToString();
                else
                    la[i].Text = "0";
                la[i].Location = new System.Drawing.Point(41 *(i+1), 10);
                la[i].Size = new System.Drawing.Size(35, 30);

                la2[i] = new Label();
                f.panel8.Controls.Add(la2[i]);
                la2[i].Location = new System.Drawing.Point(41 * (i + 1), max - (list[i] * 300 / total));
                la2[i].Size = new System.Drawing.Size(18, (list[i] * 300 / total));
                la2[i].BackColor = System.Drawing.Color.Black;

                la3[i] = new Label();
                f.panel8.Controls.Add(la3[i]);
                la3[i].Text = (i+1).ToString() + " 월";
                la3[i].Location = new System.Drawing.Point(40 * (i + 1), 345);
                la3[i].Size = new System.Drawing.Size(35, 12);
            }
        }

        public bool Account_Check(string howstr)
        {
            string path = Application.StartupPath + "\\통장관리\\", filename = "예금.txt", line = "";
            List<string> list = new List<string> { };

            if (File.Exists(path + filename) && f.cbo_account_acclist.Items.Count > 0)
            {
                StreamReader sr = new StreamReader(path + filename);
                string[] s = null;
                string[] acclist = f.cbo_account_acclist.SelectedItem.ToString().Split(' ');

                while ((line = sr.ReadLine()) != null)
                { // List에 파일의 모든 텍스트를 저장
                    list.Add(line);
                }
                sr.Close();

                if (howstr == "지출")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        s = list[i].Split('$');
                        if (s[0] == acclist[0])
                        {
                            int accnum = int.Parse(s[3]), inputnum = int.Parse(f.txt_acc_money.Text);
                            if (accnum >= inputnum)
                            {
                                string str = "";
                                // 계좌정보에서 돈을 차감한다.
                                accnum -= inputnum;
                                s[3] = accnum.ToString();

                                for (int j = 0; j < s.Length; j++)
                                {
                                    if (j < (s.Length - 1))
                                        str += s[j] + "$";
                                    else
                                        str += s[j];
                                }
                                list.RemoveAt(i); // 요소를 삭제하고 다시 삽입한다.
                                list.Insert(i, str);

                                File.Delete(path + filename);
                                for (int k = 0; k < list.Count; k++)
                                {
                                    File.AppendAllText(path + filename, list[k] + "\r\n");
                                }

                                MessageBox.Show(acclist[0] +  "계좌에서 지출처리 되었습니다.", "지출 완료");
                                Acclist_Selected();

                                return true;
                            }
                            else
                            {
                                MessageBox.Show("선택한 계좌의 잔액이 부족합니다.", "잔액 부족");
                                return false;
                            }
                        }
                    }
                }
                else if (howstr == "입금")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        s = list[i].Split('$');
                        if (s[0] == acclist[0])
                        {
                            int accnum = int.Parse(s[3]), inputnum = int.Parse(f.txt_acc_money.Text);
                            string str = "";
                            // 계좌정보에서 돈을 차감한다.
                            accnum += inputnum;
                            s[3] = accnum.ToString();

                            for (int j = 0; j < s.Length; j++)
                            {
                                if (j < (s.Length - 1))
                                    str += s[j] + "$";
                                else
                                    str += s[j];
                            }
                            list.RemoveAt(i); // 요소를 삭제하고 다시 삽입한다.
                            list.Insert(i, str);

                            File.Delete(path + filename);
                            for (int k = 0; k < list.Count; k++)
                            {
                                File.AppendAllText(path + filename, list[k] + "\r\n");
                            }
                            MessageBox.Show(acclist[0] + " 계좌에 정상 입금처리 되었습니다.", "입금 완료");
                            Acclist_Selected();

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Monthcalendar_Sel()
        {
            f.lvw_acc_daysearch.Items.Clear();

            int num = 0;
            string path = Application.StartupPath + "\\가계부\\", filename;
            string[] s = f.mcd_acc_search.SelectionStart.ToShortDateString().Split('-');

            num = int.Parse(s[1]);
            path += s[0] + "\\" + num.ToString();
            num = int.Parse(s[2]);
            filename = "\\" + num.ToString() + ".txt";

            if(Directory.Exists(path) == true)
            {
                if(File.Exists(path + filename)) {
                    StreamReader sr = new StreamReader(path + filename);
                    string line;


                    while ((line = sr.ReadLine()) != null)
                    {
                        s = line.Split('$');

                        ListViewItem li = new ListViewItem(s[0]);
                        li.SubItems.Add(s[1]);
                        li.SubItems.Add(s[3]);
                        li.SubItems.Add(s[2]);

                        f.lvw_acc_daysearch.Items.Add(li);
                    }
                }
            }
        }
    }
}