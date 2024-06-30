using MyCreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace ShortCutButton3 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

         Size NomalSIZE = new Size(200, 172);
        Size ChangeSIZE;
        //プライマリディスプレイの作業領域の高さと幅を取得
        int work_height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
        int work_Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;

        #region -------------【 ディスプレイによって高さの調整   】---------------------------------------//    
        public void DisplaySize(System.Drawing.Point p) {
            //https://dobon.net/vb/dotnet/system/displaysize.html
            //private SQLiteConnection conn = new SQLiteConnection(@"Data Source = C:\work\SQLite.db"); // 「●●.db」でデータベースファイルが作成される.  絶対パスで置き場所指定もできる。

            //プライマリディスプレイの作業領域の高さと幅を取得
            int h = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int w = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;

            Console.WriteLine("コンソール２");
            if ((p.X > 0 && p.X<(w-this.Size.Width)) && (p.Y >0 && p.Y < (h-this.Height))) {
                this.Location = p;
            }

            //結果表示
            Console.WriteLine("ディスプレイの高さ:{0}ピクセル", h);
            Console.WriteLine("ディスプレイの幅:{0}ピクセル", w);
            //ディスプレイの高さ: 1040ピクセル

        }
        //------------    【   末尾  】     ----------------//
        #endregion


        // List<System.Windows.Forms.HorizontalAlignment> TextAlignList = new List<HorizontalAlignment> { HorizontalAlignment.Left, HorizontalAlignment.Right };

        List<string> strList;
        int List_INDEX;
        Dictionary<string, string> SpPathList;
        string SELECTPath;
        string SELECTName;
        public static SQLite_URL_Pass subData;
        public static bool Update_Flg = false;
        private string Select_Table_Name;

        public string Get_Table {
            get { return Select_Table_Name; }
            set {

                Select_Table_Name = value;
                Select_ResetData(ref dataGridView1, Select_Table_Name);
            }
        }

        public bool OK_Path(string name,string path) {
            if(System.IO.File.Exists(path)|| System.IO.Directory.Exists(path)) {
                button1.Enabled = true;
                return true;
            } else {
                return false;
            }
        }

        public bool OK_Path(Dictionary<string,string> txtData) {
            if (System.IO.File.Exists(txtData["text1"]) || System.IO.Directory.Exists(txtData["text2"])) {
                button1.Enabled = true;
                return true;
            } else {
                return false;
            }
        }

        public static void Select_ResetData(ref DataGridView dgv, string Select_Table_Name) {
            dgv.Rows.Clear();
            #region -------------【  SELECT文 】---------------------------------------//
            if (subData.Get_SELECT_ALL(Select_Table_Name)) {

              //  DebugUtils.DumpDataTable(subData.strStanpSrc);

                for (int i = 0; i < subData.strStanpSrc.Rows.Count; i++) {
                    dgv.Rows.Add();
                    DataGridViewRow newRow = dgv.Rows[i];
                    DataRow row = subData.strStanpSrc.Rows[i];
                    for (int j = 0; j < row.ItemArray.Length; j++) {

                        var item = row.ItemArray[j];
                        newRow.Cells[j + 1].Value = item.ToString();
                    }
                }

                //dataGridView1.DataSource = subData.strStanpSrc;//データソース
                if (dgv.ColumnCount > 0) {
                    dgv.Columns[0].FillWeight = 10;
                }
            }
            //------------    【   末尾  】     ----------------//
            #endregion
        }

        #region -------------【 ロードイベント   】---------------------------------------//
        private void Form1_Load(object sender, EventArgs e) {

            SpPathList = new Dictionary<string, string> { { "ダウンロード",Exe_Path.DownLoad_path() },
                                                      { "Desktop",Exe_Path.Desktop_path() },
                                                      { "スクリーンショット",Exe_Path.ScreenShot_path() },
                                                      { "Document",Exe_Path.Document_path() },
                                                      { "Picture",Exe_Path.Picter_path() },
                                                      { "お気に入り",Exe_Path.Favorites_path() },
                                                      { "スタートメニュー",Exe_Path.ScreenShot_path() },
                                                      { "システム",Exe_Path.System_path() }
            };

            this.MaximizeBox = false;
            dataGridView1.AllowDrop = true;

            //-------------------------------------------------------------------//
            //CheckBox列を追加する
            DataGridViewCheckBoxColumn columnCheckBox = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(columnCheckBox);
            //--------------------------------------------------------------------//
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }


        private void Form1_Shown(object sender, EventArgs e) {


            // アプリケーションの設定を読み込む
            Properties.Settings.Default.Reload();

            try {
                SELECTPath = Properties.Settings.Default.テキストパス;//【設定した名前が"Name"】
                SELECTName = Properties.Settings.Default.テキスト名;
                comboBox.Text = Properties.Settings.Default.テキスト名;//【設定した名前が"Name"】

                Console.WriteLine("コンソール１");

                //strList.AddRange(Str_Line.String_Add_Line(Properties.Settings.Default.Listパス).ToArray());


                Size s = Properties.Settings.Default.サイズ;
                System.Drawing.Point p = Properties.Settings.Default.位置;

                DisplaySize(p);

                List_INDEX = Properties.Settings.Default.List_INDEX;

                comboBox.SelectedIndex = List_INDEX;

                Console.WriteLine("コンソール３");
                if (s.Width > NomalSIZE.Width && s.Height > NomalSIZE.Height) {
                    this.Size = s;
                }


            } catch (Exception) {
                button1.Enabled = false;
            }

            comboBox.AllowDrop = true;
            ChangeSIZE = this.Size;

            if (dataGridView1.RowCount > 0) {
                DataGrid_Wide(ref dataGridView1);
            }

            //----------------------------------------------------------------------------//

            subData = new SQLite_URL_Pass(Exe_Path.exe_Path() + @"SubDataList\subdata.db");
            dataGridView1.ColumnCount = 4;
            Select_Table_Name = "strstanp";

            Select_ResetData(ref dataGridView1, Select_Table_Name);
            // ReSet_dataGrid2();
            OK_Path(SELECTName,SELECTPath);

        }
        #endregion  ------------【　Loadイベントの末尾 】


        #region -------------【 Closeイベント   】---------------------------------------//
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if(SELECTName!="" && SELECTPath != "") {
                    Properties.Settings.Default.テキストパス = SELECTPath;
                    Properties.Settings.Default.テキスト名 = comboBox.Text;
                }


                Properties.Settings.Default.位置 = this.Location;
                Properties.Settings.Default.サイズ = this.Size;
                if (dataGridView1.RowCount>0) {
                    Properties.Settings.Default.List_INDEX = comboBox.SelectedIndex;
                }
 
            } catch (Exception) {

            }

            // アプリケーションの設定を保存する
            Properties.Settings.Default.Save();
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 データグリッドのチェックボックスのサイズ変更 とクリック判定の拡張  】---------------------------------------//

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) {
                e.PaintBackground(e.CellBounds, true);
                ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 2, e.CellBounds.Height - 2, (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Normal);

                e.Handled = true;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            Console.WriteLine("クリック");

            // チェック列だったら
            if (e.ColumnIndex == 0) {
                // null/true/false のいづれかなので、現在値が null だったら その逆の？ true、現在値がどちらかだったら、逆のどちらかをセット
                var cell = dataGridView1.CurrentCell as DataGridViewCheckBoxCell;
                var isChecked = cell.Value is null ? true : (bool)cell.Value ? false : true;
                cell.Value = isChecked;

                dataGridView1.RefreshEdit();
                dataGridView1.NotifyCurrentCellDirty(true);
            }
            // チェック列だったら
            if (e.ColumnIndex == 1) {
                //Console.WriteLine("クリック");
                if (dataGridView1.CurrentRow.Index >= 0) {

                    comboBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    SELECTName = comboBox.Text;
                    SELECTPath = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    OK_Path(comboBox.Text, SELECTPath);
                    toolTip1.SetToolTip(dataGridView1, Path.GetFileNameWithoutExtension(dataGridView1.CurrentRow.Cells[1].ToString()));
                }
            }
        }        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //Console.WriteLine("クリック");
            if (dataGridView1.CurrentRow.Index >= 0) {

                comboBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                SELECTName = comboBox.Text;
                SELECTPath = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                OK_Path(comboBox.Text, SELECTPath);
                toolTip1.SetToolTip(dataGridView1, Path.GetFileNameWithoutExtension(dataGridView1.CurrentRow.Cells[1].ToString()));
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion



        private static void DataGrid_Wide(ref DataGridView data1) {
            //data1.RowTemplate.Height = 30;
            data1.Columns[0].Width = 50;//AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            data1.Columns[1].AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
            data1.Columns[2].Width = 100;
        }

        #region    ------------    【  実行ボタン  】     ----------------//
        private void button1_Click(object sender, EventArgs e) {

            // 選択項目があるかどうかを確認する
            if (comboBox.Text ==""||SELECTPath=="") {
                // 選択項目がないので処理をせず抜ける
                return;
            }

            string exepath;

            if (comboBox.SelectedIndex>=0 && SpPathList.ContainsKey(comboBox.Text)) {
                exepath = SpPathList[comboBox.Text];
                if (Exe_Example(exepath)) {
                    this.WindowState = FormWindowState.Minimized;
                }
            } else {
                if(dataGridView1.SelectedRows.Count > 0 && SELECTPath!="") {
                    exepath = SELECTPath;
                    if (Exe_Example(exepath)) {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
            }


        }

        private bool Exe_Example(string exepath) {

            bool Flg = false;

            try {

                if (System.IO.Directory.Exists(exepath)) {
                    //this.Size = size2;//縮小化
                    Exe_Path.Explorer_Open(exepath);
                    //自分自身のフォームを最小化
                    this.WindowState = FormWindowState.Minimized;
                } else if (System.IO.File.Exists(exepath)) {
                    Regular_Expression reg = new Regular_Expression();

                    int num = reg.Is_String_int(exepath);
                    switch (num) {
                        case 5:
                            Out_Side_.File_Start(exepath);

                            break;
                        case 6:
                            Out_Side_.File_Start(exepath);
                            break;
                        default:
                            Out_Side_.Proglam_Start(exepath);
                            break;
                    }
                }
                Flg = true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return Flg;
            //起動する
           // System.Diagnostics.Process p =System.Diagnostics.Process.Start(textBox1.Text);
        }

        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 ダイアログボックス   】---------------------------------------//
        private void ダイアログからの選択ToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = Exe_Path.DownLoad_path();

            ofDialog.Filter = "実行ファイル(*.exe)|*.exe|すべてのファイル(*)|*|すべてのファイル(*.*)|*.*";

            //ダイアログのタイトルを指定する
            ofDialog.Title = "実行ファイルの選択";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK) {
                // ListBoxドラックされた文字列を設定
                string paths = ofDialog.FileName; // 配列の先頭文字列を設定
            
                string fname = Path.GetFileName(paths);
                string[] newVal = new string[] { fname, paths };

                dataGridView1.Rows.Insert(0, newVal);
                string sql = "";
                subData.INSERT_SQL(InsertSet(paths), Select_Table_Name, ref sql);

                Console.WriteLine(ofDialog.FileName);
            } else {
                Console.WriteLine("キャンセルされました");
            }

            if (dataGridView1.Rows.Count > 0) {
                DataGrid_Wide(ref dataGridView1);

            }
            // オブジェクトを破棄する
            ofDialog.Dispose();
        }
        //------------    【   末尾  】     ----------------//
        #endregion


        private void ドライブの選択ToolStripMenuItem_Click(object sender, EventArgs e) {
            // 論理ドライブ名をすべて取得する
            string[] stDrives = System.IO.Directory.GetLogicalDrives();

            // 取得した論理ドライブ名をすべて表示する
            foreach (string stDrive in stDrives) {
                MessageBox.Show(stDrive);
            }
        }

        private void comboBox1_MouseHover(object sender, EventArgs e) {
            //https://dobon.net/vb/dotnet/control/showtooltip.html

            toolTip1.SetToolTip(comboBox, Path.GetFileNameWithoutExtension(comboBox.Text));
        }

        private void 項目のToolStripMenuItem_Click(object sender, EventArgs e) {
 
            if (dataGridView1.RowCount <= 0|| dataGridView1.CurrentRow.Cells[2].Value.ToString()=="") {
                return;
            }

            string folderpath = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            if (System.IO.Directory.Exists(folderpath)) {
                //this.Size = size2;//縮小化
                Exe_Path.Explorer_Open(folderpath);
                //自分自身のフォームを最小化
                this.WindowState = FormWindowState.Minimized;
            } else if (System.IO.File.Exists(folderpath)) {
               string parentPath= Exe_Path.Parent_Folder(folderpath);
                Exe_Path.Explorer_Open(parentPath);
            }
        }


        private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void サイズ変更ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (NomalSIZE == this.Size) {
                this.Size = ChangeSIZE;
            } else {
                ChangeSIZE = this.Size;
                this.Size = NomalSIZE;
            }
        }

        private void FormMenuItem2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FormMenuItem1_Click(object sender, EventArgs e) {
            if (NomalSIZE == this.Size) {
                this.Size = ChangeSIZE;
            } else {
                ChangeSIZE = this.Size;
                this.Size = NomalSIZE;
            }
        }



        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox.SelectedIndex >= 0) {

                if (SpPathList.ContainsKey(comboBox.Items[comboBox.SelectedIndex].ToString())) {
                    for (int i = 0; i < dataGridView1.RowCount; i++) {
                        dataGridView1.Rows[i].Cells[0].Value = false;
                    }
                    dataGridView1.ClearSelection();
                    button1.Enabled = true;
                }
            }
        }


        #region -------------【 ドラッグ ＆ ドロップ   】---------------------------------------//
        private void dataGridView1_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e) {
            System.Windows.Forms.DataGridView box = (System.Windows.Forms.DataGridView)sender;

            //ドロップされたファイルの一覧を取得
            string[] sFileName = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);

            if (sFileName.Length <= 0) {
                return;
            }

            // ドロップ先が指定コントロールであるかチェック
            System.Windows.Forms.DataGridView TargetBox = sender as System.Windows.Forms.DataGridView;

            if (TargetBox == null) {
                // TextBox以外のためイベントを何もせずイベントを抜ける。
                return;
            }
            // TextBoxドラックされた文字列を設定
            string paths = sFileName[0]; // 配列の先頭文字列を設定

            if (System.IO.File.Exists(paths)) {
                comboBox.Text = paths;
                string fname = Path.GetFileName(paths);

                string sql = "";
                subData.INSERT_SQL(InsertSet(paths), Select_Table_Name, ref sql);
                button1.Enabled = true;
            } else if (System.IO.Directory.Exists(paths)) {
                comboBox.Text = paths;
                string fname = Path.GetFileName(paths);
                string sql = "";
                subData.INSERT_SQL(InsertSet(paths), Select_Table_Name, ref sql);
                button1.Enabled = true;
            } else {
                button1.Enabled = false;
            }

            if (dataGridView1.Rows.Count > 0) {
                DataGrid_Wide(ref dataGridView1);
            }
            Get_Table = Get_Table;
        }
        //------------    【   末尾  】     ----------------//
        #endregion
        


    private void comboBox_TextChanged(object sender, EventArgs e) {
            if (System.IO.File.Exists(comboBox.Text)) 
            {
                toolTip1.SetToolTip(comboBox, Path.GetFileNameWithoutExtension(comboBox.Text));
                button1.Enabled = true; 
            }
            else if (System.IO.Directory.Exists(comboBox.Text)) 
            {
                toolTip1.SetToolTip(comboBox, Path.GetFileNameWithoutExtension(comboBox.Text));
                button1.Enabled = true; 
            } else {

                if (SpPathList.ContainsKey(comboBox.Text)) {
                    button1.Enabled = true;
                }
                button1.Enabled = false;
            }
        }

        private void チェック項目を全て実行ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (dataGridView_CheckBox_Cheked_Counter() > 0) {

                List<string> idList = new List<string>();

                for (int i = 0; i < dataGridView1.RowCount; i++) {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                        idList.Add("\t" + dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                }


                string idary = Str_Line.List_Joint_moji(idList);
                DialogResult dr = MessageBox.Show($"「id＝\n{idary}」\n" +
                    $"を実行します。\n本当によろしいですか？\n", "確認", MessageBoxButtons.OKCancel);
                if (dr == System.Windows.Forms.DialogResult.OK) {

                    for (int i = 0; i < dataGridView1.RowCount; i++) {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                            string exepath = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            if (Exe_Example(exepath)) {
                                
                            }

                        }
                    }
             

                } else//OK以外の動作
                { return; }

            } else {
                MessageBox.Show("チェックされた項目がありません");
            }

            this.WindowState = FormWindowState.Minimized;
        }

        private void チェック項目をすべて削除ToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (dataGridView_CheckBox_Cheked_Counter() > 0) {

                List<string> idList = new List<string>();

                for (int i = 0; i < dataGridView1.RowCount; i++) {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                        idList.Add("\t" + dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                }


                string idary = Str_Line.List_Joint_moji(idList);
                DialogResult dr = MessageBox.Show($"「id＝\n{idary}」\n" +
                    $"を削除します。\n本当によろしいですか？\n", "確認", MessageBoxButtons.OKCancel);
                if (dr == System.Windows.Forms.DialogResult.OK) {

                    for (int i = 0; i < dataGridView1.RowCount; i++) {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                                dataGridView1.Rows.RemoveAt(i);
                        }
                    }


                } else//OK以外の動作
                { return; }

            } else {
                MessageBox.Show("チェックされた項目がありません");
            }
        }

        private int dataGridView_CheckBox_Cheked_Counter() {
            // カウンタ変数を初期化する
            int cnt = 0;

    
            // datagridviewの行数分処理を繰り返すForeach文
            for (int i = 0; i < dataGridView1.RowCount; i++) {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                    cnt++;
                }
            }
            return cnt;
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e) {
            if (dataGridView1.RowCount > 0) {

                toolTip1.SetToolTip(dataGridView1, Path.GetFileNameWithoutExtension(dataGridView1.CurrentRow.Cells[1].ToString()));
            }
        }

        private void チェック項目を全て実行ToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (dataGridView_CheckBox_Cheked_Counter() > 0) {

                List<string> idList = new List<string>();

                for (int i = 0; i < dataGridView1.RowCount; i++) {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                        idList.Add("\t" + dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                }


                string idary = Str_Line.List_Joint_moji(idList);
                DialogResult dr = MessageBox.Show($"「id＝\n{idary}」\n" +
                    $"を実行します。\n本当によろしいですか？\n", "確認", MessageBoxButtons.OKCancel);
                if (dr == System.Windows.Forms.DialogResult.OK) {

                    for (int i = 0; i < dataGridView1.RowCount; i++) {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                            string exepath = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            if (Exe_Example(exepath)) {

                            }

                        }
                    }


                } else//OK以外の動作
                { return; }

            } else {
                MessageBox.Show("チェックされた項目がありません");
            }

            this.WindowState = FormWindowState.Minimized;
        }

        private void チェック項目を全て削除ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (dataGridView_CheckBox_Cheked_Counter() > 0) {

                List<string> idList = new List<string>();

                for (int i = 0; i < dataGridView1.RowCount; i++) {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                        idList.Add("\t" + dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                }


                string idary = Str_Line.List_Joint_moji(idList);
                DialogResult dr = MessageBox.Show($"「id＝\n{idary}」\n" +
                    $"を削除します。\n本当によろしいですか？\n", "確認", MessageBoxButtons.OKCancel);
                if (dr == System.Windows.Forms.DialogResult.OK) {

                    for (int i = 0; i < dataGridView1.RowCount; i++) {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value)) {
                            // dataGridView1.Rows.RemoveAt(i);
                            subData.Delete_Query(Select_Table_Name, dataGridView1.Rows[i].Cells[3].Value.ToString());
                        }
                    }
                    Get_Table = Get_Table;

                } else//OK以外の動作
                { return; }

            } else {
                MessageBox.Show("チェックされた項目がありません");
            }
        }

        private void パス入力追加ToolStripMenuItem1_Click(object sender, EventArgs e) {
            string ID = "";
            string[] InsertStr = new string[] { };

            MyCreate.subForm subForm = new subForm(ID, InsertStr, Select_Table_Name);
            subForm.Show();
        }

        private void テーブルの変更ToolStripMenuItem_Click(object sender, EventArgs e) {
            MyCreate.SelectForm1 selectForm1 = new SelectForm1();
            selectForm1.Show();
        }

        private void 簡単追加toolStripMenuItem_Click(object sender, EventArgs e) {
            string moji = Interaction.InputBox("追加したいパスを入力してください", "パス追加");
            if (moji=="") {
                return;
            }
            string sql = "";
            subData.INSERT_SQL(InsertSet(moji), Select_Table_Name, ref sql);
            ShortCutButton3.Program.form1.Get_Table = ShortCutButton3.Program.form1.Get_Table;
        }

        private void 簡単更新ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0 && SELECTPath != "") {
                if (dataGridView1.CurrentRow.Index >= 0) {

                    string moji = Interaction.InputBox("追加したいパスを入力してください", "パス追加");
                    if (moji == "") {
                        return;
                    }
                    string sql = "";
                    subData.UpData_Query(Select_Table_Name, dataGridView1.CurrentRow.Cells[3].Value.ToString(), InsertSet(moji), ref sql);
                    ShortCutButton3.Program.form1.Get_Table = ShortCutButton3.Program.form1.Get_Table;
                }
            }

        }

        Dictionary<string, string> InsertSet(string moji) {

            Dictionary<string, string> valset = new Dictionary<string, string>();
            string name = System.IO.Path.GetFileNameWithoutExtension(moji);
            valset.Add("text1", name);
            valset.Add("text2", moji);

            return valset;
        }

        private void パス更新toolStripMenuItem_Click(object sender, EventArgs e) {
            int row = dataGridView1.CurrentCell.RowIndex;
            string ID = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string[] InsertStr = new string[] { dataGridView1.Rows[row].Cells[1].Value.ToString(), dataGridView1.Rows[row].Cells[2].Value.ToString() };
            Update_Flg = true;
            MyCreate.subForm subForm = new subForm(ID, InsertStr, Select_Table_Name);
            subForm.Show();
        }

        private void パス入力追加ToolStripMenuItem_Click(object sender, EventArgs e) {
            string ID = "";
            string[] InsertStr = new string[] { };

            MyCreate.subForm subForm = new subForm(ID, InsertStr, Select_Table_Name);
            subForm.Show();
        }

        private void パス更新ToolStripMenuItem1_Click(object sender, EventArgs e) {
            int row = dataGridView1.CurrentCell.RowIndex;
            string ID = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string[] InsertStr = new string[] { dataGridView1.Rows[row].Cells[1].Value.ToString(), dataGridView1.Rows[row].Cells[2].Value.ToString() };
            Update_Flg = true;
            MyCreate.subForm subForm = new subForm(ID, InsertStr, Select_Table_Name);
            subForm.Show();
        }

        private void テーブルの変更ToolStripMenuItem1_Click(object sender, EventArgs e) {
            MyCreate.SelectForm1 selectForm1 = new SelectForm1();
            selectForm1.Show();
        }


    }
}
