using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace LoginForm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public struct AuthorizationData
    {
        public string registered_login;
        public string registered_password;
    }

    public partial class MainWindow : Window
    {
        static public AuthorizationData AuthData;
        

        public MainWindow()
        {
            InitializeComponent();
            ///LoginBox.Text = AuthData.registered_login;
            //PasswordBox.Password = AuthData.registered_password;
            ////=========================== [got focus loginbox] ==============================
            //Storyboard text_start = this.Resources["TextSizingStart"] as Storyboard;

            //if (LoginBox.Text.Length != 0)
            //    text_start.Begin();
            //else
            //    return;
            ////=========================== [got focus passwordbox] ==============================
            //Storyboard text_start_password = this.Resources["TextSizingStartPassword"] as Storyboard;

            //if (PasswordBox.Password.Length != 0)
            //    text_start_password.Begin();
            //else
            //    return;
        }

        private void NavPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Storyboard text_start = this.Resources["TextSizingStartPassword"] as Storyboard;

            if (PasswordBox.Password.Length == 0)
                text_start.Begin();
            else
                return;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Storyboard text_start = this.Resources["TextSizingEndPassword"] as Storyboard;

            if (PasswordBox.Password.Length == 0)
                text_start.Begin();
            else
                return;
        }

        private void LoginBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Storyboard text_start = this.Resources["TextSizingStart"] as Storyboard;

            if (LoginBox.Text.Length == 0)
                text_start.Begin();
            else
                return;
        }

        private void LoginBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Storyboard text_start = this.Resources["TextSizingEnd"] as Storyboard;

            if (LoginBox.Text.Length == 0)
                text_start.Begin();
            else
                return;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 1000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(80)) == storedHash;
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {                                 
            if (LoginBox.Text == "" || PasswordBox.Password == "")
            {
                MessageWindow message = new MessageWindow("You didn't filled in login or password", "error");
                message.Show();
            }
            else
            {
                try
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["HerokuDB"].ConnectionString; // getting connection string from "App.config" file

                    MySqlConnection connection = new MySqlConnection(connectionString); // creating connection with database
                    connection.Open();

                    string user_login = LoginBox.Text;
                    string user_password = PasswordBox.Password;
                    string userDB_login = "_";
                    string salt = "_";
                    string hash = "_";

                    string check_auth = $"SELECT user_login, password_hash, password_salt FROM users WHERE user_login = '{user_login}'";

                    var cmd = new MySqlCommand(check_auth, connection); // executes query on database

                    MySqlDataReader rdr = cmd.ExecuteReader(); // getting all rows from the users table

                    while (rdr.Read())
                    {
                        userDB_login = rdr.GetString(0); // writing user_name from database to string variable
                        hash = rdr.GetString(1); // writing password_hash from database to string variable
                        salt = rdr.GetString(2); // writing password_salt from database to string variable
                    }
                    connection.Close();
                    bool isPasswordMatched = VerifyPassword(user_password, hash, salt);

                    if (isPasswordMatched && userDB_login == user_login)
                    {
                        // Login Successfull
                        // if password is correct this animation will be played
                        DateTime date = DateTime.Now;
                        string curdate = date.ToString("yyyy.MM.dd hh:mm:ss");
                        string update_date = $"UPDATE users SET last_login = \"{curdate}\"  WHERE user_login = \"{userDB_login}\";";

                        connection.Open();
                        var sql_command_udate = new MySqlCommand(update_date, connection);
                        sql_command_udate.ExecuteNonQuery();
                        connection.Close();

                        Storyboard success_login = Resources["SuccessLoginAnimation"] as Storyboard;
                        success_login.Begin();
                        await Task.Delay(1000);
                        Storyboard window_change = Resources["ChangingWindowClose"] as Storyboard;
                        window_change.Begin();
                        await Task.Delay(700);
                        StoreWindow store = new StoreWindow();
                        this.Close();
                        store.Show();
                    }
                    else
                    {
                        // Login Failed
                        // if password is wrong this animation will be played
                        Storyboard wrong_pass = Resources["WrongPassword"] as Storyboard;
                        wrong_pass.Begin();
                        PasswordBox.Clear();
                    }

                }
                catch (MySqlException ex)
                {
                    //When handling errors, you can your application's response based on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server. Contact administrator");
                            break;
                        default:
                            MessageBox.Show(ex.Message);
                            break;
                    }
                }
                catch (FormatException)
                {
                    // Login Failed
                    // if password is wrong this animation will be played
                    Storyboard wrong_pass = Resources["WrongPassword"] as Storyboard;
                    wrong_pass.Begin();
                    LoginBox.Clear();
                    PasswordBox.Clear();
                }
            }
        }

        private async void Close_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 1;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            NavPanel.BeginAnimation(OpacityProperty, da);
            await Task.Delay(500);
            Close();
        }

        private async void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Storyboard success_login = Resources["ChangingWindowClose"] as Storyboard;
            success_login.Begin();
            await Task.Delay(700);
            RegistrationWindow registration = new RegistrationWindow();
            this.Close();
            registration.Show();
        }
    }
}
