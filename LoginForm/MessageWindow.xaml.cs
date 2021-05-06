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

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string error_text, string icon)
        {
            // Icon types: (the following string must be entered)
            //    1. error
            //    2. warning
            //    3. information
            InitializeComponent();

            ErrorMessage.Text = error_text;

            if (icon == "")
                ErrorImage.Source = null;
            if (icon == "error")
                ErrorImage.Source = new BitmapImage(new Uri(@"Images/message_icons/error.png", UriKind.Relative));
            if (icon == "warning")
                ErrorImage.Source = new BitmapImage(new Uri(@"Images/message_icons/warning.png", UriKind.Relative));
            if (icon == "information")
                ErrorImage.Source = new BitmapImage(new Uri(@"Images/message_icons/info.png", UriKind.Relative));
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NavPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
