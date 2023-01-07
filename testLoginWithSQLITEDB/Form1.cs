using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing.Text;

namespace testLoginWithSQLITEDB
{
    public partial class Form1 : Form
    {
        string UserName,Password;
        private LoginFormValidator bv;
        public Form1()
        {
            InitializeComponent();
            bv = new LoginFormValidator(txtUSerName, txtPassword);
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = this.txtUSerName.Text.Trim();
                Password = this.txtPassword.Text.Trim();
                string query = DBModule.ExecuteScalarQuery($"SELECT username,password FROM tbl_user WHERE username = '{UserName}' AND password = '{Password}';");
                if(!string.IsNullOrEmpty(query)) 
                {
                    MessageBox.Show("Message Successful");
                }
                else
                {
                    MessageBox.Show("Wrong Credential");
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"Type Error : {ex.GetType()}\n Error Message : " +
                    $"{ex.Message} \nStack Track : {ex.StackTrace}");
            }
        }
    }
}
