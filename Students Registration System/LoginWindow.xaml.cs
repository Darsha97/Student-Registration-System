using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Students_Registration_System
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username == "admin" && password == "password")
            {
                lblResult.Text = "Login successful!";

                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();

                this.Close();
            }
            else
            {
                lblResult.Text = "Invalid username or password!";
            }

            if (username == "user" && password == "password")
            {
                lblResult.Text = "Login successful!";

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                lblResult.Text = "Invalid username or password!";
            }
        }
    }
}

