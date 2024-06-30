using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace MyCreate {

    public enum Expression_Number {
        // Folder = 0,
        txt = 0,
        richTextBox = 1,


        Exe = 2,
        Move = 3,
        Sound = 4,

        PDF = 5,
        Picter = 6,

        Word = 7,
        Access = 8,
        Excel = 9,

        CS = 10,
        C = 11,
        CPP = 12,

        JaSc = 13,
        Html = 14,
        Python = 15,
        CSS = 16,

        Json = 17,
        Xml = 18,
        csv = 19,
        Yaml = 20,

        dll = 21,

        defolte = 22
    }

    public enum icon_Number {
        Folder = 0,
        txt = 1,
        richTextBox = 1,

        Exe = 2,
        Move = 3,
        Sound = 4,

        PDF = 5,
        Picter = 6,

        Word = 7,
        Access = 8,
        Excel = 9,

        CS = 10,
        C = 11,
        CPP = 12,

        JaSc = 13,
        Html = 14,
        Python = 15,
        CSS = 16,

        Json = 17,
        Xml = 18,
        csv = 19,
        Yaml = 20,

        dll = 21,

        defolte = 22
    }

    public class Regular_Expression {
        /// <summary>
        /// 拡張子のenumを渡して拡張子設定用文字列を返す
        /// </summary>
        /// <param name="num">第１引数 拡張子を指定するenum</param>
        /// <returns>関数の結果 拡張子のenumを渡して拡張子設定用文字列を返す</returns>
        static string[] Expression_Str =  { "テキストファイル| *.txt","リッチテキストファイル(*.rtf)| *.rtf", "実行ファイル| *.exe",
            "動画ファイル| *.mp4", "音声ファイル| *.mp3; *.wav", "PDFファイル| *.pdf",
            "画像ファイル| *.png;*.gif;*.jpg;*.jpeg;*.webp",
            "Wordファイル| *.docx","Access|*.accdb","Excel|*.xlsx;*.xlsm",
            "C#|*.cs","C言語|*.c","CPP|*.cpp","JavaScript|*.js",
            "HTML|*.html","Python|*.py","CSS|*.css","ジェイソン|*.json","XML|*.xml","|*.csv","ヤムル|*.yaml","DLL|*.dll", "すべてのファイル(*)|*|すべてのファイル(*.*)|*.*" };
        //|pngファイル(*.png)|*.png|gifファイル(*.gif)|*.gif", ""

        public static string Expression(Expression_Number num) {
            return Expression_Str[(int)num];
        }

        public string Is_String(string Base) {


            ////string path = @"C:\Temp";
            //bool isDirectory = File .GetAttributes(BasePath) .HasFlag(FileAttributes.Directory);

            //if (isDirectory) //フォルダである場合
            //{
            //    return (int)Expression_Number.Folder;
            //}


            //string Base = Path.GetFileNameWithoutExtension(BasePath);//[名前と拡張子]
            //Base = Path.GetExtension(Base);//[拡張子のみ]


            if (Regex.IsMatch(Base, ".exe$")) {
                //MessageBox.Show(Base + "実行ファイル");
                return Expression_Str[(int)Expression_Number.Exe];
            } else if (Regex.IsMatch(Base, ".mp4$")) {
                //MessageBox.Show(Base + "動画");
                return Expression_Str[(int)Expression_Number.Move];
            } else if (Regex.IsMatch(Base, ".pdf$")) {
                return Expression_Str[(int)Expression_Number.richTextBox];
            } else if (Regex.IsMatch(Base, ".rtf$")) {

                return Expression_Str[(int)Expression_Number.PDF];
            } else if (Regex.IsMatch(Base,
                  "(.png$)|(.jpg$)|(.jpeg$)|(.ico$)|(.icns$)|(.gif$)|(.tiff$)|(.tif$)|(.psd$)|(.webp$)|(.heif$)|(.bmp$)|(.dib$)|(.heic$)|(.svg$)|(.jfif$)|(.pjpeg$)|(.jpe$)|(.pjp$)|(.EPS$)|(.pict$)|(.svgz$)",
                  RegexOptions.IgnoreCase)) {
                //MessageBox.Show(Base+"画像判定");
                return Expression_Str[(int)Expression_Number.Picter];
            } else if (Base.EndsWith(".docx")) {
                return Expression_Str[(int)Expression_Number.Word];
            } else if (Base.EndsWith(".txt")) {
                //MessageBox.Show(Base + "テキストファイル");
                return Expression_Str[(int)Expression_Number.txt];
            } else if (Base.EndsWith(".xlsm") || Base.EndsWith(".xlsx")) {
                //MessageBox.Show(Base + "Excel");
                return Expression_Str[(int)Expression_Number.Excel];
            } else if (Base.EndsWith(".accdb")) {
                //MessageBox.Show(Base + "Access");
                return Expression_Str[(int)Expression_Number.Access];
            } else if (Base.EndsWith(".cs")) {
                //MessageBox.Show(Base + "C#");
                return Expression_Str[(int)Expression_Number.CS];
            } else if (Base.EndsWith(".c")) {
                //MessageBox.Show(Base + "C言語");
                return Expression_Str[(int)Expression_Number.C];
            } else if (Base.EndsWith(".cpp")) {
                //MessageBox.Show(Base + "C++言語");
                return Expression_Str[(int)Expression_Number.CPP];
            } else if (Base.EndsWith(".js")) {
                //MessageBox.Show(Base + "JavaScript");
                return Expression_Str[(int)Expression_Number.JaSc];
            } else if (Base.EndsWith(".html")) {
                //MessageBox.Show(Base + "HTML");
                return Expression_Str[(int)Expression_Number.Html];
            } else if (Base.EndsWith(".py")) {
                //MessageBox.Show(Base + "Python");
                return Expression_Str[(int)Expression_Number.Python];
            } else if (Base.EndsWith(".css")) {
                //MessageBox.Show(Base + "CSS");
                return Expression_Str[(int)Expression_Number.CSS];
            } else if (Base.EndsWith(".json")) {
                //MessageBox.Show(Base + "JSON");
                return Expression_Str[(int)Expression_Number.Json];
            } else if (Base.EndsWith(".xml")) {
                //MessageBox.Show(Base + "XML");
                return Expression_Str[(int)Expression_Number.Xml];
            } else if (Base.EndsWith(".csv")) {
                //MessageBox.Show(Base + "CSV");
                return Expression_Str[(int)Expression_Number.csv];
            } else if (Base.EndsWith(".yaml")) {
                //MessageBox.Show(Base + "yaml");
                return Expression_Str[(int)Expression_Number.Yaml];
            } else if (Base.EndsWith(".dll")) {
                //MessageBox.Show(Base + "dll");
                return Expression_Str[(int)Expression_Number.dll];
            } else {
                //MessageBox.Show(Base + "その他不明");
                return Expression_Str[(int)Expression_Number.defolte];
            }

        }


        //-----------------------------

        public int Is_String_int(string Base) {


            //string path = @"C:\Temp";
            bool isDirectory = File.GetAttributes(Base).HasFlag(FileAttributes.Directory);

           // string Base = Path.GetFileNameWithoutExtension(BasePath);//[名前と拡張子]
           // Base = Path.GetExtension(Base);//[拡張子のみ]


            if (Regex.IsMatch(Base, ".exe$")) {
                //MessageBox.Show(Base + "実行ファイル");
                return (int)Expression_Number.Exe;
            } else if (Regex.IsMatch(Base, ".mp4$")) {
                //MessageBox.Show(Base + "動画");
                return (int)Expression_Number.Move;
            } else if (Regex.IsMatch(Base, ".pdf$")) {
                //MessageBox.Show(Base + "PDF");
                return (int)Expression_Number.PDF;
            } else if (Regex.IsMatch(Base,
                  "(.png$)|(.jpg$)|(.jpeg$)|(.ico$)|(.icns$)|(.gif$)|(.tiff$)|(.tif$)|(.psd$)|(.webp$)|(.heif$)|(.bmp$)|(.dib$)|(.heic$)|(.svg$)|(.jfif$)|(.pjpeg$)|(.jpe$)|(.pjp$)|(.EPS$)|(.pict$)|(.svgz$)",
                  RegexOptions.IgnoreCase)) {
                //MessageBox.Show(Base+"画像判定");
                return (int)Expression_Number.Picter;
            } else if (Base.EndsWith(".docx")) {
                return (int)Expression_Number.Word;
            } else if (Base.EndsWith(".txt")) {
                //MessageBox.Show(Base + "テキストファイル");
                return (int)Expression_Number.txt;
            } else if (Base.EndsWith(".xlsm") || Base.EndsWith(".xlsx")) {
                //MessageBox.Show(Base + "Excel");
                return (int)Expression_Number.Excel;
            } else if (Base.EndsWith(".accdb")) {
                //MessageBox.Show(Base + "Access");
                return (int)Expression_Number.Access;
            } else if (Base.EndsWith(".cs")) {
                //MessageBox.Show(Base + "C#");
                return (int)Expression_Number.CS;
            } else if (Base.EndsWith(".c")) {
                //MessageBox.Show(Base + "C言語");
                return (int)Expression_Number.C;
            } else if (Base.EndsWith(".cpp")) {
                //MessageBox.Show(Base + "C++言語");
                return (int)Expression_Number.CPP;
            } else if (Base.EndsWith(".js")) {
                //MessageBox.Show(Base + "JavaScript");
                return (int)Expression_Number.JaSc;
            } else if (Base.EndsWith(".html")) {
                //MessageBox.Show(Base + "HTML");
                return (int)Expression_Number.Html;
            } else if (Base.EndsWith(".py")) {
                //MessageBox.Show(Base + "Python");
                return (int)Expression_Number.Python;
            } else if (Base.EndsWith(".css")) {
                //MessageBox.Show(Base + "CSS");
                return (int)Expression_Number.CSS;
            } else if (Base.EndsWith(".json")) {
                //MessageBox.Show(Base + "JSON");
                return (int)Expression_Number.Json;
            } else if (Base.EndsWith(".xml")) {
                //MessageBox.Show(Base + "XML");
                return (int)Expression_Number.Xml;
            } else if (Base.EndsWith(".csv")) {
                //MessageBox.Show(Base + "CSV");
                return (int)Expression_Number.csv;
            } else if (Base.EndsWith(".yaml")) {
                //MessageBox.Show(Base + "yaml");
                return (int)Expression_Number.Yaml;
            } else if (Base.EndsWith(".dll")) {
                //MessageBox.Show(Base + "dll");
                return (int)Expression_Number.dll;
            } else {
                //MessageBox.Show(Base + "その他不明");
                return (int)Expression_Number.defolte;
            }

        }

        public int Is_String_icon_Index(string Base) {


            //string path = @"C:\Temp";
            bool isDirectory = File.GetAttributes(Base).HasFlag(FileAttributes.Directory);

            if (isDirectory) //フォルダである場合
            {
                return (int)icon_Number.Folder;
            }


            // string Base = Path.GetFileNameWithoutExtension(BasePath);//[名前と拡張子]
            // Base = Path.GetExtension(Base);//[拡張子のみ]


            if (Regex.IsMatch(Base, ".exe$")) {
                //MessageBox.Show(Base + "実行ファイル");
                return (int)icon_Number.Exe;
            } else if (Regex.IsMatch(Base, ".mp4$")) {
                //MessageBox.Show(Base + "動画");
                return (int)icon_Number.Move;
            } else if (Regex.IsMatch(Base, ".pdf$")) {
                //MessageBox.Show(Base + "PDF");
                return (int)icon_Number.PDF;
            } else if (Regex.IsMatch(Base,
                  "(.png$)|(.jpg$)|(.jpeg$)|(.ico$)|(.icns$)|(.gif$)|(.tiff$)|(.tif$)|(.psd$)|(.webp$)|(.heif$)|(.bmp$)|(.dib$)|(.heic$)|(.svg$)|(.jfif$)|(.pjpeg$)|(.jpe$)|(.pjp$)|(.EPS$)|(.pict$)|(.svgz$)",
                  RegexOptions.IgnoreCase)) {
                //MessageBox.Show(Base+"画像判定");
                return (int)icon_Number.Picter;
            } else if (Base.EndsWith(".docx")) {
                return (int)icon_Number.Word;
            } else if (Base.EndsWith(".txt")) {
                //MessageBox.Show(Base + "テキストファイル");
                return (int)icon_Number.txt;
            } else if (Base.EndsWith(".xlsm") || Base.EndsWith(".xlsx")) {
                //MessageBox.Show(Base + "Excel");
                return (int)icon_Number.Excel;
            } else if (Base.EndsWith(".accdb")) {
                //MessageBox.Show(Base + "Access");
                return (int)icon_Number.Access;
            } else if (Base.EndsWith(".cs")) {
                //MessageBox.Show(Base + "C#");
                return (int)icon_Number.CS;
            } else if (Base.EndsWith(".c")) {
                //MessageBox.Show(Base + "C言語");
                return (int)icon_Number.C;
            } else if (Base.EndsWith(".cpp")) {
                //MessageBox.Show(Base + "C++言語");
                return (int)icon_Number.CPP;
            } else if (Base.EndsWith(".js")) {
                //MessageBox.Show(Base + "JavaScript");
                return (int)icon_Number.JaSc;
            } else if (Base.EndsWith(".html")) {
                //MessageBox.Show(Base + "HTML");
                return (int)icon_Number.Html;
            } else if (Base.EndsWith(".py")) {
                //MessageBox.Show(Base + "Python");
                return (int)icon_Number.Python;
            } else if (Base.EndsWith(".css")) {
                //MessageBox.Show(Base + "CSS");
                return (int)icon_Number.CSS;
            } else if (Base.EndsWith(".json")) {
                //MessageBox.Show(Base + "JSON");
                return (int)icon_Number.Json;
            } else if (Base.EndsWith(".xml")) {
                //MessageBox.Show(Base + "XML");
                return (int)icon_Number.Xml;
            } else if (Base.EndsWith(".csv")) {
                //MessageBox.Show(Base + "CSV");
                return (int)icon_Number.csv;
            } else if (Base.EndsWith(".yaml")) {
                //MessageBox.Show(Base + "yaml");
                return (int)icon_Number.Yaml;
            } else if (Base.EndsWith(".dll")) {
                //MessageBox.Show(Base + "dll");
                return (int)icon_Number.dll;
            } else {
                //MessageBox.Show(Base + "その他不明");
                return (int)icon_Number.defolte;
            }

        }
    }
}
