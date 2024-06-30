using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace MyCreate {

    #region -------------【  データベース操作クラス  】---------------------------------------//
    internal class Sqlite_sub {

        #region -------------【 プロパティ  】---------------------------------------//
        static string[] Query_value = { "@a", "@b", "@c", "@d", "@e", "@f", "@g", "@h", "@i", "@j", "@k", "@l", "@m", "@n", "@o", "@p", "@q", "@r", "@s", "@t", "@u", "@v", "@w", "@x", "@y", "@z" };

        private string DBpath;
        //DB作成
        private SQLiteConnection DB_CONNECT;


        internal string subDataFolder = @"SubDataList\";

        #endregion -------------【　末尾　】---------------------------------------//

        #region -------------【 SQLの OPEN と Close 】---------------------------------------//

        #region -------------【 コンストラクタ 】----------//
        internal Sqlite_sub(string DBpath) {
            this.DBpath = DBpath;
            DB_CONNECT = new SQLiteConnection("Data Source = " + DBpath);
            DB_CONNECT.Open();
        }
        #endregion -------------【  コンストラクタ末尾  】---//


        internal void Sqlite_Close() {
            DB_CONNECT.Close();
        }
        #endregion -------------【  末尾  】---------------------------------------//


        #region -------------【  テーブル名一覧取得  】---------------------------------------//
        internal bool GetTablesName(ref List<string> list) {

            bool result = false;
            //! テーブル一覧取得SQL
            string ListTableSql = $"SELECT name FROM sqlite_master WHERE type = 'table'";

            try {
                // 接続文字列を構築します。
                SQLiteConnectionStringBuilder connectionSb = new SQLiteConnectionStringBuilder() { DataSource = DBpath };

                // コネクションオブジェクトを生成します。
                using (var connection = new SQLiteConnection(connectionSb.ToString())) {
                    // コネクションをオープンします。
                    connection.Open();

                    // コマンドオブジェクトを生成します。
                    using (var command = connection.CreateCommand()) {
                        // テーブル一覧取得SQLを実行します。
                        command.CommandText = ListTableSql;
                        using (var reader = command.ExecuteReader()) {
                            // 取得した結果がある場合
                            if (reader.HasRows) {
                                // 取得した行数分繰り返します。
                                while (reader.Read()) {
                                    // テーブル名を表示します。
                                    var name = reader["name"] as string;
                                    // MessageBox.Show(name);

                                    // "CREATE TABLE sqlite_sequence(name,seq)"
                                    if (name != "sqlite_sequence") {
                                        list.Add(name);
                                    }
                                }
                            }
                        }
                    }
                }
                result = true;
            }//try

            // 例外が発生した場合
            catch (Exception e) {
                // 例外の内容を表示します。
                MessageBox.Show(e.Message);
                result = false;
            }

            return result;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  SELECT文  】---------------------------------------//
        /// <summary>
        /// データ取得ボタンクリックイベント SELECT文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal bool SELECT_Stamp(string TableName, ref DataTable datatb) {

            //private SQLiteConnection conn = new SQLiteConnection(@"Data Source = C:\work\SQLite.db"); // 「●●.db」でデータベースファイルが作成される.  絶対パスで置き場所指定もできる。
            bool Flg = false;
            if (TableName == "") { return Flg; }

            try {

                //DBを開く
                // DB_CONNECT.Open();//開いている状態で.Open()を使うとObjectが不安定になるから注意

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                // command.CommandText = "select * from " + TableName;
                // command.CommandText = "SELECT id,lang AS 'gengo',name AS '名前',samplecode AS 'サンプル' FROM " + TableName;
                //MessageBox.Show(TableName);

                //クエリ実行
                // SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT text1 AS 'テキスト1',text2 AS 'テキスト2',text3 AS 'テキスト3',text4 AS 'テキスト4',subid AS '番号' FROM " + TableName, DB_CONNECT);
                //SQLiteDataAdapter adapter = new SQLiteDataAdapter("select * from " + TableName, DB_CONNECT);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT text1 AS 'テキスト1',text2 AS 'テキスト2',subid AS '番号' FROM " + TableName, DB_CONNECT);

                DataSet Ds = new DataSet();      //データセットインスタンス作成
                DataTable dt = new DataTable();  //データテーブルインスタンス作成
                adapter.Fill(dt);                //データテーブルに代入
                Ds.Tables.Add(dt);               //データセットに追加

                // dataGridView1.DataSource = Ds.Tables[0]; //グリッドビューにデータ表示

                datatb = Ds.Tables[0]; //グリッドビューにデータ表示

                //結果表示
                //  MessageBox.Show("データ取得完了.");
                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  SELECT文  】---------------------------------------//
        /// <summary>
        /// データ取得ボタンクリックイベント SELECT文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal bool SELECT_Password(string TableName, ref DataTable datatb) {

            //private SQLiteConnection conn = new SQLiteConnection(@"Data Source = C:\work\SQLite.db"); // 「●●.db」でデータベースファイルが作成される.  絶対パスで置き場所指定もできる。
            bool Flg = false;
            if (TableName == "") { return Flg; }

            try {

                //DBを開く
                // DB_CONNECT.Open();//開いている状態で.Open()を使うとObjectが不安定になるから注意

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                // command.CommandText = "select * from " + TableName;
                // command.CommandText = "SELECT id,lang AS 'gengo',name AS '名前',samplecode AS 'サンプル' FROM " + TableName;
                //MessageBox.Show(TableName);

                //クエリ実行
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT subid AS '番号', text1 AS 'テキスト1',text2 AS 'テキスト2',text3 AS 'テキスト3',text4 AS 'テキスト4' FROM " + TableName, DB_CONNECT);
                //SQLiteDataAdapter adapter = new SQLiteDataAdapter("select * from " + TableName, DB_CONNECT);
                //SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT text1 AS 'テキスト1',text2 AS 'テキスト2',subid AS '番号' FROM " + TableName, DB_CONNECT);

                DataSet Ds = new DataSet();      //データセットインスタンス作成
                DataTable dt = new DataTable();  //データテーブルインスタンス作成
                adapter.Fill(dt);                //データテーブルに代入
                Ds.Tables.Add(dt);               //データセットに追加

                // dataGridView1.DataSource = Ds.Tables[0]; //グリッドビューにデータ表示

                datatb = Ds.Tables[0]; //グリッドビューにデータ表示

                //結果表示
                //  MessageBox.Show("データ取得完了.");
                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  SELECT文  】---------------------------------------//
        /// <summary>
        /// データ取得ボタンクリックイベント SELECT文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal bool SELECT_URL(string TableName, ref DataTable datatb) {

            //private SQLiteConnection conn = new SQLiteConnection(@"Data Source = C:\work\SQLite.db"); // 「●●.db」でデータベースファイルが作成される.  絶対パスで置き場所指定もできる。
            bool Flg = false;
            if (TableName == "") { return Flg; }

            try {

                //DBを開く
                // DB_CONNECT.Open();//開いている状態で.Open()を使うとObjectが不安定になるから注意

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                // command.CommandText = "select * from " + TableName;
                // command.CommandText = "SELECT id,lang AS 'gengo',name AS '名前',samplecode AS 'サンプル' FROM " + TableName;
                //MessageBox.Show(TableName);

                //クエリ実行
                // SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT text1 AS 'テキスト1',text2 AS 'テキスト2',text3 AS 'テキスト3',text4 AS 'テキスト4',subid AS '番号' FROM " + TableName, DB_CONNECT);
                //SQLiteDataAdapter adapter = new SQLiteDataAdapter("select * from " + TableName, DB_CONNECT);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT subid AS '番号', text1 AS 'テキスト1',text2 AS 'テキスト2',text3 AS 'テキスト3',text4 AS 'テキスト4' FROM " + TableName, DB_CONNECT);

                DataSet Ds = new DataSet();      //データセットインスタンス作成
                DataTable dt = new DataTable();  //データテーブルインスタンス作成
                adapter.Fill(dt);                //データテーブルに代入
                Ds.Tables.Add(dt);               //データセットに追加

                // dataGridView1.DataSource = Ds.Tables[0]; //グリッドビューにデータ表示

                datatb = Ds.Tables[0]; //グリッドビューにデータ表示

                //結果表示
                //  MessageBox.Show("データ取得完了.");
                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 DELETE文 削除  】---------------------------------------//
        internal bool Delete_SQL(string TableName, string id) {

            bool Flg = false;
            //DBを開く
            //  DB_CONNECT.Open();

            try {
                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();


                //SQL文作成　テーブル作成
                command.CommandText = "DELETE FROM " + TableName + " WHERE subid = @subid";
                int ID = int.Parse(id);
                command.Parameters.Add(new SQLiteParameter("@subid", ID));

                if (command.ExecuteNonQuery() != 1) {
                    Console.WriteLine("■トランザクション失敗はロールバック");
                    tran.Rollback();
                    return false;
                }
                Console.WriteLine("■コミット");
                tran.Commit();

               // MessageBox.Show("データ削除完了.");

                Flg = true;

            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 UPDATE文  更新 】---------------------------------------//
        internal bool UPDATE_SQL(string TableName, string id, Dictionary<string, string> valus, ref string sql) {

            bool Flg = false;
            //DBを開く
            //  DB_CONNECT.Open();

            try {
                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                string setValue = "";
                List<string> setParam = new List<string>();

                //SQL文作成　テーブル作成
           
                int ID = int.Parse(id);
                int i = 0;
                //DictionaryのForEach文
                foreach (KeyValuePair<string, string> s in valus) {

                    string key = s.Key;
                    string val = s.Value;

                    if (i < valus.Count - 1) {
                        setValue += (s.Key+" = "+Query_value[i] + ", ");
                    } else {
                     
                        setValue += (s.Key + " = " + Query_value[i] + " ");
                    }
                    setParam.Add(s.Value);
                    i++;
                }

                setValue += " WHERE subid = @subid ";
               
                command.CommandText = "UPDATE " + TableName + " SET " + setValue;
                sql = ("UPDATE " + TableName + " SET " + setValue+"\n\n");

                for (int j = 0; j < i; j++) {
                    command.Parameters.Add(new SQLiteParameter(Query_value[j], setParam[j]));
                    sql += "\n\tcommand.Parameters.Add(new SQLiteParameter(Query_value[" + j + "], setParam[" + j + "]));";
                }

                command.Parameters.Add(new SQLiteParameter(@"subid", ID));
                sql += "\n\tcommand.Parameters.Add(new SQLiteParameter(@subid, ID));";

                if (command.ExecuteNonQuery() != 1) {
                    Console.WriteLine("■トランザクション失敗はロールバック");
                    tran.Rollback();
                    return false;
                }
                Console.WriteLine("■コミット");
                tran.Commit();

               // MessageBox.Show("データ更新完了.");

                Flg = true;

            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 INSERT文   】---------------------------------------//
        internal bool INSERT_SQL(Dictionary<string, string> insertValue, string Tablename, ref string Sql) {

            bool Flg = false;

            //DBを開く
            //  DB_CONNECT.Open();
            try {
                var tran = DB_CONNECT.BeginTransaction();
                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                string setName= " ( subid,";
                string setValue="";
                List<string> setParam = new List<string>();
                int i = 0;
                //DictionaryのForEach文
                foreach (KeyValuePair<string, string> s in insertValue) {

                    string id = s.Key;
                    string val = s.Value;

                    if( i < insertValue.Count - 1) {
                        setName += s.Key + ", ";
                        setValue += Query_value[i] + ",";
                    } else {
                        setName += s.Key+ ") VALUES(NULL ,";
                        setValue += Query_value[i]+")" ;

                    }
                    setParam.Add(s.Value);
                    i++;
                }
                Sql="INSERT INTO " + Tablename + setName + setValue;
                command.CommandText = "INSERT INTO " + Tablename + setName + setValue;
                //SQL文作成　テーブル作成
                // command.CommandText = "INSERT INTO " + Tablename + " ( subid, lang , name , samplecode ) VALUES(NULL , @lang, @name, @samplecode)";
               
                for(int j = 0; j < i; j++) {
                    command.Parameters.Add(new SQLiteParameter(Query_value[j], setParam[j]));
                    Sql += "\n\tcommand.Parameters.Add(new SQLiteParameter(Query_value[" + j + "], setParam[" + j + "]));";
                }

                //command.Parameters.Add(new SQLiteParameter("@lang", insertValue["lang"]));
                //command.Parameters.Add(new SQLiteParameter("@name", insertValue["name"]));
                //command.Parameters.Add(new SQLiteParameter("@samplecode", insertValue["samplecode"]));


                if (command.ExecuteNonQuery() != 1) {
                    Console.WriteLine("■トランザクション失敗はロールバック");
                    tran.Rollback();
                    return false;
                }
                Console.WriteLine("■コミット");
                tran.Commit();


                //結果表示
              //  MessageBox.Show("データ登録完了.");

                Flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                //  DB_CONNECT.Close();
            }
            return Flg;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 テーブルの新規作成   】---------------------------------------//
        internal bool CreateTable(string newTablename) {
            bool flg = false;
            try {
                //DBを開く
                //  DB_CONNECT.Open();

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "create table " + newTablename + " (subid INTEGER PRIMARY KEY AUTOINCREMENT,text1 TEXT,text2 TEXT,text3 TEXT,text4 TEXT)";

                //クエリ実行
                command.ExecuteNonQuery();

                //結果表示
                //  MessageBox.Show("データ登録完了.");
                flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                // DB_CONNECT.Close();
            }

            return flg;
        }

        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 テーブル名の変更   】---------------------------------------//
        internal bool ChangeTableName(string nowTableName, string newTablename) {
            bool flg = false;
            try {
                //DBを開く
                //  DB_CONNECT.Open();

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //SQL文作成　テーブル作成
                command.CommandText = "ALTER TABLE " + nowTableName + " RENAME TO " + newTablename;

                //クエリ実行
                command.ExecuteNonQuery();

                //結果表示
                //  MessageBox.Show("データ登録完了.");
                flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            } finally {
                //DB閉じる
                // DB_CONNECT.Close();
            }

            return flg;
        }

        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 テーブルの削除   】---------------------------------------//
        internal bool Delete_Table(string Tablename) {
            bool flg = false;
            try {
                //DBを開く
                //  DB_CONNECT.Open();

                //SQL文作成
                SQLiteCommand command = DB_CONNECT.CreateCommand();

                //! テーブル削除SQL
                string CreateTableSql = $"DROP TABLE IF EXISTS {Tablename}";



                //SQL文作成　テーブル作成
                command.CommandText = CreateTableSql;

                //クエリ実行
                command.ExecuteNonQuery();


                //結果表示
                //  MessageBox.Show("データ登録完了.");
                flg = true;
            } catch (Exception ex) {
                //エラーをテキストボックスに表示
                MessageBox.Show(ex.Message);
            }

            return flg;
        }

        //------------    【   末尾  】     ----------------//
        #endregion


    }//------------------クラスの末尾
    #endregion

    public enum TableNum {
        URL = 0,
        PassWord = 1,
        LineTokun = 2,
        strStanp = 9,
    }

    #region    //------------    【   URLとパスワード用クラス  】     ----------------//
    public class SQLite_URL_Pass {


        private Sqlite_sub subData;
        public string FolderPath;

        public DataTable URLsrc = new DataTable();
        public DataTable PassWordSrc = new DataTable();
        public DataTable strStanpSrc = new DataTable();

        string DBpath;

        public string url_TableName = "urltb";
        public string password_TBname = "passtb";
        // public string strStanp_Table;

        #region -------------【  テーブル名取得  】---------------------------------------//
        public bool Get_TableList(ref List<string> list) {
            
            if (subData.GetTablesName(ref list)) {
                return true;
            } else {
                return false;
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  テーブル　1個 への　SQL文 】---------------------------------------//

        #region -------------【  SELEC文 URL Password　取得  】---------------------------------------//
        public bool Get_SELECT_ALL(TableNum tableNum) {

            switch (tableNum) {
                case TableNum.URL:
                    URLsrc = new DataTable();
                    if (subData.SELECT_URL(url_TableName, ref URLsrc)) {

                        return true;
                    } else {
                        return false;
                    }

                case TableNum.PassWord:
                    PassWordSrc = new DataTable();
                    if (subData.SELECT_Password(password_TBname, ref PassWordSrc)) {

                        return true;
                    } else {
                        return false;
                    }       
            }
            return false;

        }
        #endregion -------------------------------//

        #region -------------【  SELEC文 Stamp　取得  】---------------------------------------//
        public bool Get_SELECT_ALL(string table) {

            
            strStanpSrc = new DataTable();
            if (subData.SELECT_Stamp(table, ref strStanpSrc)) {

                return true;
            } else {
                return false;
            }
        }
        #endregion -------------------------------//


        #region -------------【 追加 SQL   】---------------------------------------//
        public bool INSERT_SQL(Dictionary<string, string> InsertValue, TableNum tableNum, ref string sql) {

            switch (tableNum) {
                case TableNum.URL:
                 
                    if (subData.INSERT_SQL(InsertValue, url_TableName, ref sql)) {
                   //     MessageBox.Show("追加　成功!!");
                        return true;
                    } else {
                        MessageBox.Show("追加 失敗");
                        return false;
                    }

                case TableNum.PassWord:

                    if (subData.INSERT_SQL(InsertValue, password_TBname, ref sql)) {
                 //       MessageBox.Show("追加　成功!!");
                        return true;
                    } else {
                        MessageBox.Show("追加 失敗");
                        return false;
                    }
            }
            return false;



        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【 追加 SQL Stamp  】---------------------------------------//
        public bool INSERT_SQL(Dictionary<string, string> InsertValue, string table, ref string sql) {

                    if (subData.INSERT_SQL(InsertValue, table, ref sql)) {
                    //    MessageBox.Show("追加　成功!!");
                        return true;
                    } else {
                        MessageBox.Show("追加 失敗");
                        return false;
                    }
        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region -------------【  項目の削除 URL Password 】---------------------------------------//
        public bool Delete_Query(TableNum tableNum, string id) {

            switch (tableNum) {
                case TableNum.URL:

                    if (subData.Delete_SQL(url_TableName, id)) {
                      //  MessageBox.Show("削除完了(≧ω≦)");
                        return true;
                    } else {
                        MessageBox.Show("削除失敗(´；ω；`)ｳｩｩ");
                        return false;
                    }

                case TableNum.PassWord:

                    if (subData.Delete_SQL(password_TBname, id)) {
                      //  MessageBox.Show("削除完了(≧ω≦)");
                        return true;
                    } else {
                        MessageBox.Show("削除失敗(´；ω；`)ｳｩｩ");
                        return false;
                    }
            }
            return false;
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  項目の削除 Stamp 】---------------------------------------//
        public bool Delete_Query(string table, string id) {


                    if (subData.Delete_SQL(table, id)) {
                      //  MessageBox.Show("削除完了(≧ω≦)");
                        return true;
                    } else {
                        MessageBox.Show("削除失敗(´；ω；`)ｳｩｩ");
                        return false;
                    }
        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region -------------【  項目の更新 URL Password 】---------------------------------------//
        public bool UpData_Query(TableNum tableNum, string id, Dictionary<string, string> valus, ref string sql) {
            switch (tableNum) {
                case TableNum.URL:

                    if (subData.UPDATE_SQL(url_TableName, id, valus, ref sql)) {
                      //  MessageBox.Show("更新完了(≧ω≦)");
                        return true;
                    } else {
                        MessageBox.Show("更新失敗(´；ω；`)ｳｩｩ");
                        return false;
                    }

                case TableNum.PassWord:

                    if (subData.UPDATE_SQL(password_TBname, id, valus, ref sql)) {
                       // MessageBox.Show("更新完了(≧ω≦)");
                        return true;
                    } else {
                        MessageBox.Show("更新失敗(´；ω；`)ｳｩｩ");
                        return false;
                    }
            }
            return false;

        }
        //------------    【  UPDATE 末尾  】     ----------------//
        #endregion

        #region -------------【  項目の更新 Stamp 】---------------------------------------//
        public bool UpData_Query(string table, string id, Dictionary<string, string> valus, ref string sql) {

                    if (subData.UPDATE_SQL(table, id, valus, ref sql)) {
                      //  MessageBox.Show("更新完了(≧ω≦)");
                        return true;
                    } else {
                        MessageBox.Show("更新失敗(´；ω；`)ｳｩｩ");
                        return false;
                    }
        }
        //------------    【  UPDATE 末尾  】     ----------------//
        #endregion


        #region //-------------------------//
        public bool New_Table(string newTable) {
            if (subData.CreateTable(newTable)) {
                return true;
            }
            return false;
        }
        #endregion //------------------------//


        #region -------------【  テーブル名の変更  】---------------------------------------//
        public bool Change_Table_Query(string nowTableName, string newTableName, ref string sql) {


            if (subData.ChangeTableName(nowTableName, newTableName)) {
               // MessageBox.Show("更新完了(≧ω≦)");
                return true;
            } else {
                MessageBox.Show("更新失敗(´；ω；`)ｳｩｩ");
                return false;
            }
        }
        //------------    【   末尾  】     ----------------//
        #endregion

        #region -------------【  テーブルの削除  】---------------------------------------//
        public bool Delete_Table_Query( string TBname, ref string sql) {


            if (subData.Delete_Table(TBname)) {
              //  MessageBox.Show("テーブルの削除完了(≧ω≦)");
                return true;
            } else {
                MessageBox.Show("テーブル削除失敗(´；ω；`)ｳｩｩ");
                return false;
            }
        }
        //------------    【 テーブル削除  末尾  】     ----------------//
        #endregion
        #endregion ------------  テーブル１つへのSQL　末尾  -----------------------//



        #region -------------【  コンストラクタ取得  】---------------------------------------//
        public SQLite_URL_Pass(string DBpath) {
            subData = new Sqlite_sub(DBpath);
            this.DBpath = DBpath;

        }
        //------------    【   末尾  】     ----------------//
        #endregion


        #region -------------【  データベースの接続終了  】---------------------------------------//
        public void DataBaseListCloseing() {

            subData.Sqlite_Close();
            
        }
        //------------    【   末尾  】     ----------------//
        #endregion


    }
    //------------    【   末尾  】     ----------------//
    #endregion

    }

