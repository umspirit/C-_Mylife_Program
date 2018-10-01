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
    public partial class Form_Note7 : Form
    {
        private string str_topic = "", edit_str = "";
        int n_control = 0, combo_start = 0;
        float now_fontsize = 0;

        // Form 생성자
        public Form_Note7()
        {
            InitializeComponent();
            List_add("", 1);
            comboBox_fontsize.SelectedIndex = 4;
            radioButton_readmode.Checked = true;
        }

        // 제목을 반환한다 properties
        public string Topic
        {
            get { return str_topic; }
        }

        // 폴더내의 파일을 검색하여 리스트에 추가
        private void List_add(string str, int list_set)
        {
            string path = Application.StartupPath + "\\Note";
            List<string> list = new List<string> { };

            DirectoryInfo direc = new DirectoryInfo(path);

            if(direc.Exists)
            {
                if (list_set == 1)
                {
                    foreach (var item in direc.GetFiles())
                    {
                        string[] s = item.Name.Split('.');
                        list.Add(s[0]);
                    }
                    listBox_topic.Items.Clear();

                    for (int i = 0; i < list.Count; i++)
                    {
                        listBox_topic.Items.Insert(0, "- " + list[i]);
                    }
                    if(listBox_topic.Items.Count > 0)
                        listBox_topic.SelectedIndex = 0;
                }
                else
                {
                    listBox_topic.Items.Insert(0, "- " + str);
                    listBox_topic.SelectedIndex = 0;
                }
            }
        }

        // 리스트 박스에 아이템을 추가한다.
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                e.DrawBackground();
                e.Graphics.DrawString(this.listBox_topic.Items[e.Index].ToString(),
                    e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        // 파일 리스트중에 하나를 선택했을 때
        private void listBox_topic_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] s = listBox_topic.SelectedItem.ToString().Split('-');
            string tmp_str = "", path;

            for (int i = 1; i < s.Length; i++)
            {
                if (i == 1)
                    tmp_str += s[i].TrimStart();
                else
                    tmp_str += s[i];
            }
            path = Application.StartupPath + "\\Note\\" + tmp_str + ".txt";

            if (File.Exists(path))
            {
                StreamReader sw = new StreamReader(path, Encoding.Default);

                richTextBox_body.Text = sw.ReadToEnd();
                sw.Close();
            }
        }

        // 읽기모드 Radiobutton을 클릭했을 때
        private void radioButton_readmode_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox_body.ReadOnly = true;
            richTextBox_body.AcceptsTab = false;
            richTextBox_body.BackColor = SystemColors.Window;
        }

        // 쓰기모드 Radiobutton을 클릭했을 때
        private void radioButton_writemode_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox_body.ReadOnly = false;
            richTextBox_body.AcceptsTab = true;
            richTextBox_body.BackColor = Color.White;
        }

        // Regular 버튼을 클릭했을 때
        private void btn_Regular_Click(object sender, EventArgs e)
        {
            if (richTextBox_body.SelectedText != null)
            {
                comboBox_fontsize.Items.Insert(0, richTextBox_body.Font.Size.ToString() + " pt");

                richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont, FontStyle.Regular);
                richTextBox_body.Select();
            }
        }

        // Bold 버튼을 클릭했을 때
        private void btn_bold_Click(object sender, EventArgs e)
        {
            if (richTextBox_body.SelectedText != null)
            {
                comboBox_fontsize.Items.Insert(0, richTextBox_body.Font.Size.ToString() + " pt");

                richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont, FontStyle.Bold);
                richTextBox_body.Select();
            }
        }

        // Italic 버튼을 클릭했을 때
        private void btn_italic_Click(object sender, EventArgs e)
        {
            if (richTextBox_body.SelectedText != null)
            {
                comboBox_fontsize.Items.Insert(0, richTextBox_body.Font.Size.ToString() + " pt");

                richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont, FontStyle.Italic);
                richTextBox_body.Select();
            }
        }

        // richTextBox의 선택된 값이 변경될 때
        private void richTextBox_body_SelectionChanged(object sender, EventArgs e)
        {
            if (combo_start == 0)
                combo_start++;
            else
                comboBox_fontsize.Items.RemoveAt(0);

            string str = "";

            now_fontsize = richTextBox_body.SelectionFont.Size;
            str += now_fontsize.ToString() + " pt";

            comboBox_fontsize.Items.Insert(0, str);
            comboBox_fontsize.SelectedIndex = 0;
        }

        // Font Combobox가 item이 선택되었을 때
        private void comboBox_fontsize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] s = comboBox_fontsize.SelectedItem.ToString().Split(' ');
            float size = float.Parse(s[0]);

            if (richTextBox_body.SelectionFont.Bold)
            {
                richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont.FontFamily, size, FontStyle.Bold);
            }
            else if (richTextBox_body.SelectionFont.Italic)
            {
                richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont.FontFamily, size, FontStyle.Italic);
            }
            else
            {
                richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont.FontFamily, size, FontStyle.Regular);
            }
            richTextBox_body.Select();
        }

        // 저장 Button을을 눌렀을 때
        private void btn_save_Click(object sender, EventArgs e)
        {
            Save_file();
        }

        // 새 노트 button을 클릭했을 때 이벤트
        private void btn_newnote_Click(object sender, EventArgs e)
        {
            Form_Note7_Addnote form_note_add = new Form_Note7_Addnote(0);
            form_note_add.ShowDialog();

            if (form_note_add.Btn_click == 1)
            {
                str_topic = form_note_add.Topic;
                List_add(str_topic, 0);
            }
        }

        // 노트 삭제 Button을 클릭했을 때
        private void btn_delnote_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("파일을 삭제하시겠습니까 ?", "파일 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] s = listBox_topic.SelectedItem.ToString().Split('-');
                string tmp_str = "", path;

                for (int i = 1; i < s.Length; i++)
                {
                    if (i == 1)
                        tmp_str += s[i].TrimStart();
                    else
                        tmp_str += s[i];
                }
                path = @Application.StartupPath + "\\Note\\" + tmp_str + ".txt";

                if (File.Exists(path) == true)
                {
                    File.Delete(path);
                    List_add("", 1);
                }
            }
        }

        // 노트 복사 Button을을 클릭했을 때
        private void btn_copy_Click(object sender, EventArgs e)
        {
            int index = listBox_topic.SelectedIndex + 1;

            string[] s = listBox_topic.SelectedItem.ToString().Split('-');
            string tmp_str = "", path = "", copy_path = "";
            bool check = true;
            int count_num = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (i == 1)
                    tmp_str += s[i].TrimStart();
                else
                    tmp_str += s[i];
            }
            path = @Application.StartupPath + "\\Note\\" + tmp_str + ".txt"; // 복사할 파일 경로

            while (check)
            {
                copy_path = @Application.StartupPath + "\\Note\\" + tmp_str + "(" + (count_num).ToString() + ")" + ".txt";

                if (File.Exists(copy_path) == false)
                {
                    File.Copy(path, copy_path);
                    check = false;
                }
                else
                {
                    count_num++;
                }
            }
            List_add(tmp_str + "(" + (count_num).ToString() + ")", 0);
            listBox_topic.SelectedIndex = index;
        }

        // ListBox에서 키가 눌러졌을 때
        private void listBox_topic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift) // Ctrl + Shift가 눌러졌을 때
                n_control = 1;

            if (e.KeyCode == Keys.D) // D키가 눌러졌을 때
            {
                btn_delnote.PerformClick(); // 노트 삭제버튼을 누른 것같은 효과 발생
            }
        }

        // ListBox에서 키가 떼어졌을 때
        private void listBox_topic_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == false || e.Shift == false)
                n_control = 0;
        }

        // 파일을 저장한다.
        private void Save_file() // 파일을 저장
        {
            this.Cursor = Cursors.WaitCursor;

            string[] s = listBox_topic.SelectedItem.ToString().Split('-');
            string tmp_str = "", path;

            for (int i = 1; i < s.Length; i++)
            {
                if (i == 1)
                    tmp_str += s[i].TrimStart();
                else
                    tmp_str += s[i];
            }
            path = @Application.StartupPath + "\\Note\\" + tmp_str + ".txt";

            if (File.Exists(path) == true)
            {
                FileStream fs = null;
                try
                {
                    File.Delete(path);
                    fs = new FileStream(path, FileMode.CreateNew);
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                    {
                        writer.Write(richTextBox_body.Text);
                    }
                }
                finally
                {
                    if (fs != null)
                        fs.Dispose();
                }
            }
            this.Cursor = Cursors.Default;
        }

        // RichTextBox에서 키가 눌러졌을 때
        private void richTextBox_body_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift)
                n_control = 1;

            if (n_control == 1) // Alt + Shift + B 가 눌러졌을 때
            {
                if (e.KeyCode == Keys.B)
                {
                    if (richTextBox_body.SelectionFont.Bold)
                    {
                        richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont, FontStyle.Regular);
                    }
                    else
                    {
                        richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont, FontStyle.Bold);
                    }
                }
                else if (e.KeyCode == Keys.E)
                {
                    richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont.FontFamily, richTextBox_body.SelectionFont.Size + 1, richTextBox_body.Font.Bold ? FontStyle.Bold : FontStyle.Regular);
                }
                else if (e.KeyCode == Keys.R)
                {
                    richTextBox_body.SelectionFont = new Font(richTextBox_body.SelectionFont.FontFamily, richTextBox_body.SelectionFont.Size - 1, richTextBox_body.Font.Bold ? FontStyle.Bold : FontStyle.Regular);
                }
                else if (e.KeyCode == Keys.S)
                {
                    Save_file();
                }
                else if (e.KeyCode == Keys.N)
                {
                    btn_newnote.PerformClick();
                }
                else if (e.KeyCode == Keys.D)
                {
                    btn_delnote.PerformClick();
                }
                else if (e.KeyCode == Keys.C)
                {
                    btn_copy.PerformClick();
                }
            }
        }

        private void 복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_str = richTextBox_body.SelectedText;
        }

        private void 붙여넣기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_body.SelectedText += edit_str;
        }

        private void 잘라내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit_str = richTextBox_body.SelectedText;
            richTextBox_body.SelectedText = "";
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_save.PerformClick();
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_delnote.PerformClick();
        }

        private void dToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by 엄정기", "만든이");
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Note\\", tmp_path;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] s = ofd.FileName.Split('.');
                if (s[s.Length - 1] == "txt")
                {
                    StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    tmp_path = path;
                    path += ofd.SafeFileName;

                    if (File.Exists(path) == false)
                    {
                        FileStream fs = new FileStream(path, FileMode.CreateNew);
                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                        sw.WriteLine(str);
                        sw.Close();
                    }
                    else
                    {
                        s = ofd.SafeFileName.Split('.');
                        tmp_path += s[0] + "_복사본.txt";
                        FileStream fs = new FileStream(tmp_path, FileMode.CreateNew);
                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                        sw.WriteLine(str);
                        sw.Close();
                    }
                }
                List_add("", 1);
            }
            else
            {
                MessageBox.Show("텍스트파일이 아닙니다.", "파일 읽기 오류", MessageBoxButtons.OK);
            }
        }

        private void Form_Note7_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Note\\";
            Directory.CreateDirectory(path);
        }

        // ListBox 를 더블클릭 했을 때 발생
        private void listBox_topic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string[] s = listBox_topic.SelectedItem.ToString().Split('-');
            string tmp_str = "";

            for (int i = 1; i < s.Length; i++)
            {
                if (i == 1)
                    tmp_str += s[i].TrimStart();
                else
                    tmp_str += s[i];
            }

            Form_Note7_Rename form = new Form_Note7_Rename(tmp_str);
            form.ShowDialog();

            List_add("", 1);
        }

        // RichTextBox에서 키에서 손을 뗐을 때
        private void richTextBox_body_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == false || e.Shift == false)
                n_control = 0;
        }
    }
}