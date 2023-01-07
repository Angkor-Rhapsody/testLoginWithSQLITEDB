using System;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;

namespace testLoginWithSQLITEDB
{
    public static class DBModule
    {
        private static string connectionString =
            Path.Combine("Data Source=" + Environment.CurrentDirectory, "Database\\testLoginDB.db");
        public static SQLiteConnection Conn = new SQLiteConnection(connectionString);
        public static SQLiteCommand Cmd;

        public static string ExecuteScalarQuery(string query)
        {
            string str = string.Empty;
            try
            {
                Conn.Open();
                Cmd = new SQLiteCommand(query, Conn);
                var result = Cmd.ExecuteScalar();
                if (result != null)
                    str = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            finally
            {
                if (Cmd != null)
                    Cmd.Dispose();
                if (Conn != null)
                    Conn.Close();
            }
            return str;
        }

    }
}
