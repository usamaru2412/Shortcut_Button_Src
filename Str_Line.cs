using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCreate;

namespace MyCreate
{
  public class Str_Line
  {
    public static  List<string> String_Add_Line(string moji) 
    {
           // System.Windows.Forms.MessageBox.Show("文字:"+moji);

            List<string> mojiretu = new List<string>();

            //TextBox1に入力されている文字列から一行ずつ読み込む
            //文字列(TextBox1に入力された文字列)からStringReaderインスタンスを作成
            System.IO.StringReader rs = new System.IO.StringReader(moji);

            //StreamReaderを使うと次のようになる
            //System.IO.MemoryStream ms = new System.IO.MemoryStream
            //    (System.Text.Encoding.UTF8.GetBytes(TextBox1.Text));
            //System.IO.StreamReader rs = new System.IO.StreamReader(ms);

            //ストリームの末端まで繰り返す
            while (rs.Peek() > -1)
            {
                //一行読み込んで表示する
                mojiretu.Add(rs.ReadLine());
            }

            return mojiretu;
    }


        public static string NormalizeNewLine(string s) {
            return s.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
        }

        public static  string List_Joint_ListBox(ListBox list) 
        {
            // System.Windows.Forms.MessageBox.Show("文字:"+moji);

            string moji = "";

            string[] strLine;
            strLine=list.Items.Cast<string>().ToList().ToArray();


            if (strLine.Length <= 0) { return moji; }

            moji += strLine[0];
            for (int i = 1; i < strLine.Length; i++) {
                moji += (System.Environment.NewLine + strLine[i]);
            }

            return moji;
     }

        public static List<string> ListBox_To_Lists(ListBox list) {

            List<string> listString = new List<string>();
            listString.AddRange(list.Items.Cast<string>().ToList());
            return listString;
        }

        public static List<string> ComboBox_To_Lists(ComboBox list) {

            List<string> listString = new List<string>();
            listString.AddRange(list.Items.Cast<string>().ToList());
            return listString;
        }

        public static string List_Joint_ComboBox(ComboBox list) {
            // System.Windows.Forms.MessageBox.Show("文字:"+moji);

            string moji = "";

            string[] strLine;
            strLine = list.Items.Cast<string>().ToList().ToArray();


            if (strLine.Length <= 0) { return moji; }

            moji += strLine[0];
            for (int i = 1; i < strLine.Length; i++) {
                moji += (System.Environment.NewLine + strLine[i]);
            }

            return moji;
        }

        public static string List_Joint_moji(List<string> list) {
            // System.Windows.Forms.MessageBox.Show("文字:"+moji);

            string moji = "";

            string[] strLine;
            strLine = list.ToArray();


            if (strLine.Length <= 0) { return moji; }

            moji += strLine[0];
            for (int i = 1; i < strLine.Length; i++) {
                moji += (System.Environment.NewLine + strLine[i]);
            }

            return moji;
        }
        public static string DataGrid_Joint_moji(DataGridView data) {
            // System.Windows.Forms.MessageBox.Show("文字:"+moji);

            string moji = "";

            if (data.RowCount <= 0) { return moji; }

            moji += data.Rows[0].Cells[2].Value.ToString();
            for (int i = 1; i < data.RowCount; i++) {
                moji += (System.Environment.NewLine + data.Rows[i].Cells[2].Value.ToString());
            }

            return moji;
        }
        public static string StringLine_Joint(string[] strLine) 
        {
            string moji = "";

            if (strLine.Length <= 0) { return moji; }

            moji += strLine[0];
            for (int i=1;i<strLine.Length;i++) 
            {
                moji += (System.Environment.NewLine +strLine[i]);
            }

            return moji;
        }

        #region --------------【指定文字が含まれているか判定】------------------------------------------------------
        public static bool IS_notExists(string checkpath, List<string> dumpList) {

            foreach (string d in dumpList) {
                if (checkpath.EndsWith(d)) {
                    return false;
                }
            }

            return true;
        }
        //------------    【   末尾  】     ----------------//
#endregion

    }
}
//https://dobon.net/vb/dotnet/string/readline.html#google_vignette