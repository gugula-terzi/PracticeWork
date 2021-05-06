using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void NavPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private async void Close_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 1;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            NavPanel.BeginAnimation(OpacityProperty, da);
            await Task.Delay(500);
            this.Close();
        }

        public class HashSalt
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }

        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 1000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(80));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }

        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            bool isItEmail = Regex.IsMatch(EmailBox.Text, emailPattern);
            string db_login = "_";
            string db_email = "_";
            var connectionString = ConfigurationManager.ConnectionStrings["HerokuDB"].ConnectionString; // getting connection string from "App.config" file
            MySqlConnection connection = new MySqlConnection(connectionString); // creating connection with database

            WrongLoginLabel.Visibility = Visibility.Hidden;
            WrongPasswordLabel.Visibility = Visibility.Hidden;
            WrongEmailLabel.Visibility = Visibility.Hidden;

            try
            {
                connection.Open();
                string get_login = $"SELECT user_login FROM Users WHERE user_login = \"{LoginBox.Text}\"";
                string get_email = $"SELECT email FROM users WHERE email = \"{EmailBox.Text}\"";

                using (MySqlCommand cmd = new MySqlCommand(get_login, connection))
                {
                    MySqlDataReader read_id = cmd.ExecuteReader();

                    while (read_id.Read())
                    {
                        db_login = read_id.GetString(0);
                    }
                }
                connection.Close();

                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(get_email, connection))
                {
                    MySqlDataReader read_id = cmd.ExecuteReader();

                    while (read_id.Read())
                    {
                        db_email = read_id.GetString(0); // writing email from Users table to string variable
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




            if (LoginBox.Text == "" || PasswordBox.Password == "" || NameBox.Text == "" || EmailBox.Text == "" || LastNameBox.Text == "")
            {
                MessageWindow message = new MessageWindow("You didn't fill in all the fields", "error");
                message.Show();
                return;
            }
            if (LoginBox.Text == db_login)
            {
                WrongLoginLabel.Visibility = Visibility.Visible;
                return;
            }
            if (EmailBox.Text == db_email)
            {
                WrongEmailLabel.Content = "This email already exists";
                WrongEmailLabel.Visibility = Visibility.Visible;
                return;
            }
            if (PasswordBox.Password.Length < 8)
            {
                WrongPasswordLabel.Visibility = Visibility.Visible;
                return;
            }
            if (!isItEmail)
            {
                WrongEmailLabel.Content = "Email is invalid";
                WrongEmailLabel.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                WrongPasswordLabel.Visibility = Visibility.Hidden;
                WrongEmailLabel.Visibility = Visibility.Hidden;
                try
                {                   
                    
                    string password = PasswordBox.Password.ToString();
                    DateTime date = DateTime.Now;
                    string curdate = date.ToString("yyyy.MM.dd hh:mm:ss");
                    string email = EmailBox.Text;
                    string name = NameBox.Text;
                    string last_name = LastNameBox.Text;
                    string login = LoginBox.Text;
                    string previous_id = "SELECT max(user_id) FROM Users;";
                    int new_id = 0;

                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(previous_id, connection))
                    {
                        MySqlDataReader read_id = cmd.ExecuteReader();

                        while (read_id.Read())
                        {
                            new_id = read_id.GetInt32(0) + 1; // writing maximum id from Users tabl to string variable
                        }
                    }
                    connection.Close();

                    connection.Open();
                    HashSalt hashSalt = GenerateSaltedHash(10, password);
                    string slq_query = $"INSERT INTO Users VALUES ({new_id}, '{login}', '{hashSalt.Hash}', '{hashSalt.Salt}', '{name}', '{last_name}', '{email}', 3, '{curdate}', '{curdate}')";

                    using (var cmd = new MySqlCommand(slq_query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();

                    //MainWindow.AuthData.registered_login = login;
                    //MainWindow.AuthData.registered_password = password;
                    Storyboard success_login = Resources["ChangingWindowClose"] as Storyboard;
                    success_login.Begin();
                    await Task.Delay(700);
                    MainWindow login_window = new MainWindow();
                    this.Close();
                    login_window.Show();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
