using Library.Class;
using Library.Model;
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

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для Registrations.xaml
    /// </summary>
    public partial class Registrations : Window
    {

        private string position;

        public Registrations()
        {
            InitializeComponent();
        }

        private void Worker_Checked(object sender, RoutedEventArgs e)
        {
            if (Worker.IsChecked == true) 
            {
                position = "Рабочий";
            }
            else if (User.IsChecked == true)
            {
                position = "Пользователь";
            }
           
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            if (string.IsNullOrWhiteSpace(Login.Text) || string.IsNullOrWhiteSpace(Password.Text) || string.IsNullOrWhiteSpace(FerstName.Text) || string.IsNullOrWhiteSpace(Email.Text) || string.IsNullOrWhiteSpace(LastName.Text) || string.IsNullOrWhiteSpace(DateOfBirth.Text) || string.IsNullOrWhiteSpace(PhoneNumber.Text))
            {
                MessageBox.Show("Заполните пустые троки","Не правельное оформление",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Login.Text.Length < 3)
            {
                MessageBox.Show("Логин не может иметь меньше трёх символов", "Не правельное оформление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Password.Text.Length < 8)
            {
                MessageBox.Show("Пароль не может иметь меньше Восьми символов", "Не правельное оформление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (user.Login == Login.Text)
            {
                MessageBox.Show("Такой логин уже сушествует","Аккаунт сушествует", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string input = DateOfBirth.Text;

                if(DateTime.TryParse(input, out DateTime date))
                {
                    User userData = new User()
                    {
                        Login = Login.Text,
                        Password = Password.Text,
                        FirstName = FerstName.Text,
                        LastName = LastName.Text,
                        DateOfBirth = date,
                        Email = Email.Text,
                        PhoneNumber = PhoneNumber.Text,
                        PositionName = position,
                        RegistrationDate = DateTime.Now,
                    };
                    ConectDB.cone.User.Add(userData);
                    ConectDB.cone.SaveChanges();


                    authorization.authorz = true;

                    UserData.Id = user.Id;
                    UserData._password = Password.Text;
                    UserData._login = Login.Text;
                    UserData.Position = position;
                    Close();
                }
                else
                {
                    MessageBox.Show("Не коретный формат даты","Не коретная информация",MessageBoxButton.OK, MessageBoxImage.Error);
                }               
            }
        }

        

        private void DateOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FerstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
