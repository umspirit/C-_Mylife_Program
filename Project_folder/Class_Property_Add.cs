using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


/*

    미션 5 - (1) : 미션4의 클래스를 프로퍼티 구조를 변경하거나, 새로운 클래스에 포함시키시오.
    미션 5 - (2) : (1)의 자료구조를 리스트로 변경 또는 추가히시오.
    미션 5 - (3) : 멀티윈도우였던 가계부 Form을 Form_Financial에 있는 Tabpage에 편입시켰습니다.


// 미션 5 - (1) : Form_Financial에 있는 재관 관리 Tabpage에 대한 기능 함수들을 새로운 클래스인 Class_Property_Add를 생성해서
// 포함시켰고, 자료구조를 Property를 이용하여서 클래스객체제엇 사용하였던 값들을 Form_Financial에 보내서 또 다시 객체를 생성하였을 때
// 그 값을 사용할 수 있도록 구조를 변경하였습니다.

    */

namespace 비프
{
    class Class_Property_Add
    {
        Form_Financial form;

        private string ofd_path = "", store_path = "", extends = "";
        private string[] s;
        private int pro_cnt = 0;

        public Class_Property_Add(Form_Financial f, int pro_cnt)
        {
            form = f;
            this.pro_cnt = ++pro_cnt;
        }

        public string Path_Get
        {
            get
            {
                return store_path;
            }
        }

        public string str_arr
        {
            get
            {
                return ofd_path;
            }
        }

        public string File_extend
        {
            get
            {
                return s[s.Length - 1];
            }
        }

        public void Open_Image()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "이미지파일(*)|*.JPG;*.BMP;*.ICO;*.GIF;*.PNG";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                s = ofd.SafeFileName.Split('.');
                ofd_path = ofd.FileName;
                store_path = Application.StartupPath + "\\재산\\재산사진\\";
                form.la_path.Text = ofd_path;
            }
        }

        public void btn_store_Click()
        {
            store_path = form.image_storepath;
            ofd_path = form.ofd_path;
            extends = form.file_extend;

            if (form.txt_properName.Text != null && form.txt_properPrice.Text != null && form.txt_proper_purchaseday.Text != null 
                && form.txt_properserial.Text != null && store_path.Length > 0 && ofd_path.Length > 0)
            {

                Picture_save();
                File_save();

                form.pnl_property_add.Visible = false;
                form.txt_properName.Clear();
                form.txt_properPrice.Clear();
                form.txt_properserial.Clear();
                form.txt_proper_purchaseday.Clear();
                form.la_path.Text = "";
            }
            else
            {
                MessageBox.Show("모두 입력해주세요.", "입력 오류");
            }
        }

        private void Picture_save()
        {
            if (form.la_path.Text != null)
            {
                if (Directory.Exists(form.image_storepath) && ofd_path != null) // 폴더가 존재하면
                {
                    store_path += pro_cnt.ToString() + "$property." + form.file_extend;
                    File.Copy(ofd_path, store_path);
                }
                else if (!Directory.Exists(form.image_storepath) && ofd_path != null)
                {
                    Directory.CreateDirectory(form.image_storepath); // 폴더가 존재 안하면
                    store_path += pro_cnt.ToString() + "$property." + form.file_extend;
                    File.Copy(ofd_path, store_path);
                }
            }
        }

        private void File_save()
        {
            string path = Application.StartupPath + "\\재산\\재산메모\\property.txt";
            string tmp_str = "";

            FileInfo file_info = new FileInfo(path);

            if (file_info.Exists == false) // 파일이 존재하는지 검사
            {
                FileStream fs = file_info.Create();
                fs.Close();
            }
            tmp_str = pro_cnt.ToString() + "$" + form.txt_properName.Text + "$" + form.txt_properPrice.Text + "$" + form.txt_proper_purchaseday.Text + "$" + form.txt_properserial.Text;
            File.AppendAllText(path, tmp_str + "\r\n");
        }
    }
}


/* 이 아래는 From_Financial에 있는 재산관리 탭에서 수행하는 함수들을 새로운 클래스 Class_property_Add를 생성하여 함수의 기능들을 
   포함시켰고, 프로펄티 구조였던 것을 List<string> 을 사용하여서 자료구조를 재구성을 하였습니다.

*/
/*
namespace 비프
{
    class Class_Property_Add
    {
        Form_Financial form;
        public List<string> path_list = new List<string> { };

        private string ofd_path = "", store_path = "", extends = "";
        private string[] s;
        private int pro_cnt = 0;

        public Class_Property_Add(Form_Financial f, int pro_cnt)
        {
            form = f;
            this.pro_cnt = ++pro_cnt;
        }

        public void Open_Image()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "이미지파일(*)|*.JPG;*.BMP;*.ICO;*.GIF;*.PNG";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                s = ofd.SafeFileName.Split('.');
                //ofd_path = ofd.FileName;
                path_list.Add(ofd.FileName);
                //store_path = Application.StartupPath + "\\재산\\재산사진\\";
                path_list.Add(Application.StartupPath + "\\재산\\재산사진\\");
                path_list.Add(s[s.Length - 1]);

                form.la_path.Text = path_list[0];
            }
        }

        public void btn_store_Click()
        {
            //store_path = form.image_storepath;
            //ofd_path = form.ofd_path;
            //extends = form.file_extend;
            path_list.Add(form.ofd_path);
            path_list.Add(form.image_storepath);
            path_list.Add(form.file_extend);

            if (form.txt_properName.Text != null && form.txt_properPrice.Text != null && form.txt_proper_purchaseday.Text != null)
            {
                Picture_save();
                File_save();
                form.pnl_property_add.Visible = false;
                form.txt_properName.Clear();
                form.txt_properPrice.Clear();
                form.txt_properserial.Clear();
                form.la_path.Text = "";
            }
            else
            {
                MessageBox.Show("모두 입력해주세요.", "입력 오류");
            }
        }

        private void Picture_save()
        {
            if (Directory.Exists(form.image_storepath)) // 폴더가 존재하면
            {
                store_path += pro_cnt.ToString() + "$property." + path_list[2];
                File.Copy(path_list[0], path_list[1] + store_path);
            }
            else
            {
                Directory.CreateDirectory(form.image_storepath); // 폴더가 존재 안하면
                store_path += pro_cnt.ToString() + "$property." + path_list[2];
                File.Copy(path_list[0], path_list[1] + store_path);
            }
        }

        private void File_save()
        {
            string path = Application.StartupPath + "\\재산\\재산메모\\property.txt";
            string tmp_str = "";

            FileInfo file_info = new FileInfo(path);

            if (file_info.Exists == false) // 파일이 존재하는지 검사
            {
                FileStream fs = file_info.Create();
                fs.Close();
            }
            tmp_str = pro_cnt.ToString() + "$" + form.txt_properName.Text + "$" + form.txt_properPrice.Text + "$" + form.txt_proper_purchaseday.Text + "$" + form.txt_properserial.Text;
            File.AppendAllText(path, tmp_str + "\r\n");
        }
    }
}


    */