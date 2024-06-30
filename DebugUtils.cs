using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyCreate {
    public static class DebugUtils {
        public static void Dump(object obj) {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine("Type: " + type.FullName);
            foreach (PropertyInfo property in properties) {
                try {
                    object value = property.GetValue(obj, null);
                    Console.WriteLine(property.Name + ": " + value);
                } catch (Exception ex) {
                    Console.WriteLine(property.Name + ": " + ex.Message);
                }
            }
        }

        //--------------------------------------------------------------//

        public static void DumpDataTable(DataTable dataTable) {
            // テーブルの列名を表示
            Console.WriteLine("Columns:");
            foreach (DataColumn column in dataTable.Columns) {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();

            // 各行のデータを表示
            System.Diagnostics.Debug.WriteLine("Data:");
            System.Diagnostics.Debug.WriteLine(" foreach (DataRow row in dataTable.Rows){");
            foreach (DataRow row in dataTable.Rows) {
                System.Diagnostics.Debug.Write("[");
                foreach (var item in row.ItemArray) {
                    System.Diagnostics.Debug.Write("\t"+item.ToString() + " , ");
                }
                System.Diagnostics.Debug.Write("\t]\n");
            }
            System.Diagnostics.Debug.WriteLine("}");
        }

    }
}
