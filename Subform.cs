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
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyCreate
{
    public partial class subForm : Form
    {
        public static string filename;
        MyCreate.TableNum TableType;
        List<Object> Tboxs = new List<Object>();
        string StampTableName = null;

        #region -------------【  Lineトークン  】---------------------------------------//
        string[] LineToken_moji= null;
        string FolderPath = @"List\Line_item\";
        string TokentxtName = @".env";
        string TokenPath;
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 　　フォントサイズ変更   】---------------------------------------//
        // マウスホイールイベント  
        private void textBox1_MouseWheel(object sender, MouseEventArgs e) {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                Console.WriteLine("Ctrlキーが押されています。");
                System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
                // スクロール量（方向）の表示
                int num = (e.Delta * SystemInformation.MouseWheelScrollLines / 120);

                num += (int)textBox.Font.Size;

                if (num < 1) {
                    num = 1;
                }

                Font font = new System.Drawing.Font("MS UI Gothic", num, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
                textBox.Font = font;

            } else {

                //どの修飾子キー(Shift、Ctrl、およびAlt)が押されているか
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
                    //   Console.WriteLine("Shiftキーが押されています。");
                }

                if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt) {
                    // Console.WriteLine("Altキーが押されています。");
                }
            }

        }
        //------------    【   末尾  】     ----------------//
        #endregion

        public subForm(string ID,string[] InsertStr,TableNum tableNum)
        {
            InitializeComponent();

            TableType = tableNum;

            if (ShortCutButton3.Form1.Update_Flg) {

                Tboxs.Add(textBox1);
                Tboxs.Add(richTextBox1);
                Tboxs.Add(textBox3);
                Tboxs.Add(textBox4);
                lbl_ID.Text = ID;
                for (int i = 0; i < InsertStr.Length; i++) {
                    if(Tboxs[i] is System.Windows.Forms.TextBox) {
                        System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)Tboxs[i];
                        t.Text = InsertStr[i];
                    }else if (Tboxs[i] is RichTextBox) {
                        RichTextBox r = (RichTextBox)Tboxs[i];
                        r.Text = InsertStr[i];
                    }
                }
                this.Text = "更新入力画面";
            } else { 
            
            }
            //ホイールイベントの追加  
            this.richTextBox1.MouseWheel
                += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseWheel);
            this.richTextBox1.AllowDrop = true;
            richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.DragEnter += richTextBox1_DragEnter;
            this.richTextBox1.DragDrop += richTextBox1_DragDrop;
        }

        public subForm(TableNum tableNum) {
            InitializeComponent();

            //ホイールイベントの追加  
            this.richTextBox1.MouseWheel
                += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseWheel);

            TableType = tableNum;
            if (tableNum == TableNum.LineTokun) {
                LineToken_moji = null;

            } else {
                this.Text = "新規追加画面";
            }

            this.richTextBox1.AllowDrop = true;
            richTextBox1.AllowDrop = true;
            richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.DragEnter += richTextBox1_DragEnter;
            this.richTextBox1.DragDrop += richTextBox1_DragDrop;
        }

        public subForm(string ID, string[] InsertStr, string tableName) {
            InitializeComponent();

            if (ShortCutButton3.Form1.Update_Flg) {

                TableType = TableNum.strStanp;
                Tboxs.Add(textBox1);
                Tboxs.Add(richTextBox1);
                Tboxs.Add(textBox3);
                Tboxs.Add(textBox4);
                lbl_ID.Text = ID;
                for (int i = 0; i < InsertStr.Length; i++) {

                    if (Tboxs[i] is System.Windows.Forms.TextBox) {
                        System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)Tboxs[i];
                        t.Text = InsertStr[i];
                    } else if (Tboxs[i] is RichTextBox) {
                        RichTextBox r = (RichTextBox)Tboxs[i];
                        r.Text = InsertStr[i];
                    }

                }
                this.Text = "更新入力画面";
            } else { 
                this.Text = "新規追加画面";
                TableType = TableNum.strStanp;
            }
            StampTableName = tableName;
            //ホイールイベントの追加  
            this.richTextBox1.MouseWheel
                += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseWheel);
            this.richTextBox1.AllowDrop = true;
            richTextBox1.AllowDrop = true;
            richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.DragEnter += richTextBox1_DragEnter;
            this.richTextBox1.DragDrop += richTextBox1_DragDrop;
        }

        public subForm(TableNum tableNum,string[] ary) {
            InitializeComponent();

            if(tableNum == TableNum.LineTokun) {
                TableType = tableNum;
                this.Text = "Lineトークン";
                LineToken_moji = ary;
                this.richTextBox1.ReadOnly = true;
               // this.textBox1.Enabled = false;
            }
            //ホイールイベントの追加  
            this.richTextBox1.MouseWheel
                += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseWheel);
            this.richTextBox1.AllowDrop = true;
            richTextBox1.AllowDrop = true;
            richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.DragEnter += richTextBox1_DragEnter;
            this.richTextBox1.DragDrop += richTextBox1_DragDrop;
        }

        #region //-------------------【リッチテキストボックスのドラッグ＆ドロップ】----------------------------------------//

        private void richTextBox1_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private void richTextBox1_DragDrop(object sender, DragEventArgs e) {

            //ドロップされたファイルの一覧を取得
             string[] sFileName = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);
            richTextBox1.Text = sFileName[0];
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            switch (TableType) {

                case TableNum.URL:
                    TableLabal.Text = "URL";
                    label1.Text = "移動先名";
                    label2.Text = "URL文字列";
                    richTextBox1.Multiline = false;

                    label3.Text = "アカウントのID";
                    label4.Text = "Password";
                    textBox4.Multiline = false;
                    this.Size = new Size(786, 610);
                    break;

                case TableNum.PassWord:
                    TableLabal.Text = "Password";
                    
                    label1.Text = "IDやメールアドレス";
                    textBox1.Multiline = false;
                    label2.Text = "Password";
                    richTextBox1.Multiline = false;

                    label3.Text = "使う場所";
                    label4.Text = "使用ウェブサイトのURLなど";
                    textBox4.Multiline = false;
                    this.panel4.Size = new Size(700, 10);
                    this.Size = new Size(786, 610);
                    break;

                case TableNum.strStanp:
                    TableLabal.Text = "StrngStanp";
                    label1.Text = "登録名";
                    textBox1.Multiline = false;
                    label2.Text = "コピー文字";
                    panel3.Size = new Size(650, 100);

                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;

                    label3.Visible = false;
                    label4.Visible = false;
                    label6.Visible = false;
                    this.Size = new Size(620, 400);
                    break;

                case TableNum.LineTokun:
                    TokenPath = Exe_Path.exe_Path() + FolderPath+TokentxtName;
                    this.Text = "";
                    TableLabal.Text = "トークンの更新";

                    label1.Text = "トークンの文字列";
                    textBox1.Multiline = false;
                    label2.Text = "表示名";

                    if (LineToken_moji == null) {
                      
                    } else {
                        textBox1.Text = LineToken_moji[0];
                        richTextBox1.Text = LineToken_moji[1];
                    }


                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    label3.Enabled = false;
                    label4.Enabled = false;
                    this.Size = new Size(670, 290);
                    this.FormBorderStyle = FormBorderStyle.FixedDialog;
                    
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string memo;

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null)
            {

                if (data.GetDataPresent(typeof(string)))
                {
                    textBox1.Text = Clipboard.GetText();//クリップボードゲット
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string memo;

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null) {

                if (data.GetDataPresent(typeof(string))) {
                    richTextBox1.Text = Clipboard.GetText();//クリップボードゲット
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string memo;

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null)
            {

                if (data.GetDataPresent(typeof(string)))
                {
                    textBox3.Text = Clipboard.GetText();//クリップボードゲット
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            string memo;

            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null) {

                if (data.GetDataPresent(typeof(string))) {
                    textBox4.Text = Clipboard.GetText();//クリップボードゲット
                }
            }
        }


        Dictionary<string, string> InsertSet() {

            Dictionary<string, string> valset = new Dictionary<string, string>();

            valset.Add("text1", textBox1.Text);
            valset.Add("text2", richTextBox1.Text);

            if (textBox3.Text != "") {
                valset.Add("text3", textBox3.Text);
            }
            if (textBox4.Text != "") {
                valset.Add("text4", textBox4.Text);
            }

            return valset;
        }



        private void button_Click(object sender, EventArgs e)
        {
           // Sub.Moveing(textBox3.Text, richTextBox1.Text + @"\" + filename);//どちらにも移動させたいファイルの名前が必要

            string path = Application.ExecutablePath;
            string folderPath1 = Path.GetDirectoryName(path);
            string folderPath2 = Path.GetDirectoryName(folderPath1);

            //エクスプローラでフォルダ"C:\My Documents\My Pictures"を開く
            System.Diagnostics.Process.Start("EXPLORER.EXE", folderPath1 + @"\");
        }

        private void button6_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) {
            if (richTextBox1.Text == "" || textBox1.Text == "") {
                MessageBox.Show("未入力");
                return;
            } else {

                string sql = "";
                if (ShortCutButton3.Form1.Update_Flg && TableType == TableNum.strStanp) {
                    MessageBox.Show("更新クエリ");
                    if (ShortCutButton3.Form1.subData.UpData_Query(StampTableName, lbl_ID.Text, InsertSet(), ref sql)) {
                        ShortCutButton3.Program.form1.OK_Path(InsertSet());
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    } else { textBox4.Text = sql; }
                    ShortCutButton3.Form1.Update_Flg = false;

                } else if (StampTableName != null) {
                    MessageBox.Show("追加クエリ");
                    if (ShortCutButton3.Form1.subData.INSERT_SQL(InsertSet(), StampTableName, ref sql)) {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    } else { textBox4.Text = sql; }
                } else if (ShortCutButton3.Form1.Update_Flg && TableType != TableNum.strStanp) {
                    MessageBox.Show("更新クエリ");
                } else if (ShortCutButton3.Form1.subData.UpData_Query(TableType, lbl_ID.Text, InsertSet(), ref sql)) {
                    this.DialogResult = DialogResult.OK;

                    this.Close();
                } else if (TableType != TableNum.strStanp) {
                    MessageBox.Show("追加クエリ");
                    if (ShortCutButton3.Form1.subData.INSERT_SQL(InsertSet(), TableType, ref sql)) {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    } else { textBox4.Text = sql; }


                } else { textBox4.Text = sql; }
                ShortCutButton3.Form1.Update_Flg = false;

            }
        }

        private void formSub_FormClosing(object sender, FormClosingEventArgs e) {
            //string_stamp1.Program.mainForm.Show();
            //string_stamp1.MainForm1.Select_ResetData(ref string_stamp1.Program.mainForm.dataGridView1,);
            ShortCutButton3.Program.form1.Get_Table = ShortCutButton3.Program.form1.Get_Table;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e) {
            //ドロップされたファイルの一覧を取得
            string[] sFileName = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);
            string path = sFileName[0];
            textBox1.Text = System.IO.Path.GetFileNameWithoutExtension(path);
        }
    }
}
