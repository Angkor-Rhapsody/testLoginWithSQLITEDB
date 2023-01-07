using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testLoginWithSQLITEDB
{
    public class LoginFormValidator
    {
        private ErrorProvider ep = new ErrorProvider();
        private TextBox username;
        private TextBox password;

        public LoginFormValidator(TextBox username, TextBox password)
        {
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            this.username = username;
            this.password = password;
            this.username.Validating += Username_Validating;
            this.password.Validating += Password_Validating;
        }
        private void Username_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                ep.SetError(username, "Username must be greater than 0!");
                e.Cancel = true;
            }
            else if (username.Text.Length < 2)
            {
                ep.SetError(username, "Username must be greater than 2!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(username, null);
            }
        }
        private void Password_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text))
            {
                ep.SetError(password, "Password must be greater than 0!");
                e.Cancel = true;
            }
            else if (password.Text.Length < 8)
            {
                ep.SetError(password, "Password must be at least 8 characters!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(password, null);
            }
        }
    }
}
