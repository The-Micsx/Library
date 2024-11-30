using Library.Class;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        
        private string _login;
        private string _password;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        public void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Пожалуйста, заполните поле ввода.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Login.Text.Length < 3)
            {
                MessageBox.Show("Логин не может содержать меньше трёх символов.", "Длина логина", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Password.Text.Length < 8)
            {
                MessageBox.Show("Пароль не может содержать меньше восьми символов.", "Длина пароля", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _login = Login.Text;
                _password = Password.Text;

                

                var user = ConectDB.cone.User.FirstOrDefault(x => x.Login == _login && x.Password == _password);

                if (user == null)
                {                    
                    MessageBox.Show("Такого аккаунта нет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    UserData.Id = user.Id;
                    UserData._password = user.Password;
                    UserData.Position = user.PositionName;
                    UserData._login = user.Login;
                    authorization.authorz = true;

                    Close();
                                        
                }
            }
        }
    }
}
