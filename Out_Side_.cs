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

namespace MyCreate
{
    public class Out_Side_
    {
        public string Folda;

        public Out_Side_() 
        {
            Folda = "";
        }

        public Out_Side_(string Folda_name) {
            Folda = Folda_name;
        }

        #region ------------------------クリップボード--------
        public static string ClipBoard_string()//クリップボードから文字を受け取る
        {
            System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            if (data != null)
            {

                if (data.GetDataPresent(typeof(string)))
                {
                    string Kekka = Clipboard.GetText();//クリップボードゲット
                    return Kekka;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("String型に変換出来ません");
                    return null;
                }
            }
            return null;
        }
        #endregion

        public static void File_Start(string path) 
        {
            Process ps = new Process();

        try { 
            ps.StartInfo.FileName = path;//Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Sample.png";
            ps.Start();

        }catch(Exception e) 
            {
                MessageBox.Show("予想外のエラー"+e.Message);
            }
        }

        public static void Proglam_Start(string path) 
        {
            try
            {
                //プログラムサンプルを起動
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(path);

                //アイドル状態まで待機
                p.WaitForInputIdle();
            }catch(Exception e) 
            {
                MessageBox.Show("予想外のエラー"+e.Message);
            }
        }

        public void Proglam_ShortCut(string path,string savePath) //ショートカット作成
        {
            //try
            //{
            //    // シェルオブジェクトを作成する
            //    IWshRuntimeLibrary.WshShell objShell = new IWshRuntimeLibrary.WshShell();
            //    // ショートカットを作成する
            //    IWshRuntimeLibrary.WshShortcut objShortcut = objShell.CreateShortcut(savePath);//Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Sample.lnk");//ダウンロードフォルダ
            //    // ショートカットで開くファイルを指定する
            //    objShortcut.TargetPath = path;//@"C:\Windows\System32\notepad.exe";
            //    // ショートカットを保存する
            //    objShortcut.Save();
            //}
            //catch (Exception objException)
            //{
            //    Console.WriteLine(objException.Message);
            //}
            //finally
            //{

            //}
        }

        #region メモ帳の起動
        public static void Open_text(string name)
        {
                //メモ帳起動
                System.Diagnostics.Process p = System.Diagnostics.Process.Start("notepad.exe",  name+".txt");
        }
        #endregion

        #region 指定プログラムの起動
        public static void Open_Proglam(string exe_name,string File_name) 
        {

            //指定プログラムを起動
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(exe_name, File_name);

        }
        #endregion

        #region プログラムその２

        public void Open_Proglam2(string exe_name, string File_name,Form f) {


            //メモ帳を起動する// ProcessStartInfo の新しいインスタンスを生成する
            System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo();

            p.FileName = exe_name;       // 起動するアプリケーション
            p.Arguments = File_name;            // 起動パラメータ
            p.UseShellExecute = false;                   // シェルを使用しない
            p.ErrorDialog = true;                        // 起動できなかった時にエラーダイアログを表示する
            p.ErrorDialogParentHandle = f.Handle;     // エラーダイアログを表示する親ハンドル(自フォーム)
            p.WorkingDirectory = Folda; // 多くは実行ファイルのディレクトリ
            p.CreateNoWindow = true;                     // コマンドプロンプトは非表示にする

            // プロセスの起動
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(p);

            // プロセスが終了したときに Exited イベントを発生させる
            proc.EnableRaisingEvents = true;
            // Windows フォームのコンポーネントを設定して、コンポーネントが作成されているスレッドと
            // 同じスレッドで Exited イベントを処理するメソッドが呼び出されるようにする
            proc.SynchronizingObject = f;

            // プロセス終了時に呼び出される Exited イベントハンドラの設定
            proc.Exited += new EventHandler(Process1_Exited);
        }

        #region 自分で定義したイベントその１
        // プロセスの終了を捕捉する Exited イベントハンドラ
        private void Process1_Exited(object sender, EventArgs e) {

            System.Diagnostics.Process proc = (System.Diagnostics.Process)sender;
            //System.Windows.Forms.MessageBox.Show("プロセスが終了しました。プロセスID：" + proc.Id.ToString());
        }
        #endregion


        public string Open_text2(string File_name,Form f) {

            //メモ帳を起動する// ProcessStartInfo の新しいインスタンスを生成する
            System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo();

            p.FileName = "notepad.exe";       // 起動するアプリケーション
            p.Arguments = File_name;            // 起動パラメータ
            p.UseShellExecute = false;                   // シェルを使用しない
            p.ErrorDialog = true;                        // 起動できなかった時にエラーダイアログを表示する
            p.ErrorDialogParentHandle = f.Handle;     // エラーダイアログを表示する親ハンドル(自フォーム)
            p.WorkingDirectory = Folda; // 多くは実行ファイルのディレクトリ
            p.CreateNoWindow = true;                     // コマンドプロンプトは非表示にする

            // プロセスの起動
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(p);

            // プロセスが終了したときに Exited イベントを発生させる
            proc.EnableRaisingEvents = true;
            // Windows フォームのコンポーネントを設定して、コンポーネントが作成されているスレッドと
            // 同じスレッドで Exited イベントを処理するメソッドが呼び出されるようにする
            proc.SynchronizingObject = f;

            // プロセス終了時に呼び出される Exited イベントハンドラの設定
            proc.Exited += new EventHandler(Process2_Exited);

            return "編集したテキストファイルの文字列";
        }

        #region 自分で定義したイベントその2
        // プロセスの終了を捕捉する Exited イベントハンドラ
        private void Process2_Exited(object sender, EventArgs e) {

            System.Diagnostics.Process proc = (System.Diagnostics.Process)sender;
            //System.Windows.Forms.MessageBox.Show("プロセスが終了しました。プロセスID：" + proc.Id.ToString());
        }
        #endregion

        #endregion

    }
}
