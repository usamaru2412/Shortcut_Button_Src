using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.IO;

namespace MyCreate {

    public enum Msg_Enm {
        DEFAULT =0,
        YES_NO_yes = 1,
        YES_NO_CANCEL =2,
        YES_NO_no = 3,
    }

    public class MsgBoxs {

        public static bool Messge_OK_NO(Msg_Enm ms_num,string moji1,string moji2="") {
            
            switch (ms_num){

                case Msg_Enm.DEFAULT:
                    DialogResult dr = MessageBox.Show(moji1, moji2);
                    return true;

                case Msg_Enm.YES_NO_yes:
                    dr = MessageBox.Show(moji1, moji2, MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes) {
                        MessageBox.Show("Cancelを押しました。");
                        return true;
                    }else{
                        return false;
                    }

                    
                case Msg_Enm.YES_NO_CANCEL:
                    dr  = MessageBox.Show(moji1, moji2, MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes) {
                        MessageBox.Show("Cancelを押しました。");
                        return true;
                    } else {
                        return false;
                    }

                case Msg_Enm.YES_NO_no:
                    dr = MessageBox.Show(moji1, moji2, MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes) {
                        MessageBox.Show("Cancelを押しました。");
                        return true;
                    } else {
                        return false;
                    }

                default:return false;
            }

        }

    }
}
