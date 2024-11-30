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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
            var loans = ConectDB.cone.Loans.ToList();
            listReqests.ItemsSource = loans.ToList();

        }

        private void StaticExtension_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        private void btnShowPopup_Click(object sender, RoutedEventArgs e)
        {
            listBoxItems.Items.Clear();
            if (authorization.authorz == true)
            {
                if(UserData.Position == "Рабочий")
                {
                    Requests.Visibility = Visibility.Visible;
                }
                else
                {
                    Requests.Visibility= Visibility.Collapsed;
                }

                TextAkaunt.Text = $"{UserData._login}";
                
                listBoxItems.Items.Add(new ListBoxItem { Content = "Выйти из аккаунта" });

            }
            else
            {                
                listBoxItems.Items.Add(new ListBoxItem { Content = "Авторизация" });
                listBoxItems.Items.Add(new ListBoxItem { Content = "Регистрация" });
                TextAkaunt.Text = "Войти в аккаун";
            }
            akaunt.IsOpen = !akaunt.IsOpen;
        }


        private void listBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            if (listBoxItems.SelectedItem is ListBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Авторизация")
                {
                    AuthorizationWindow secondWindow = new AuthorizationWindow();
                    secondWindow.Show();
                }
                else if (selectedItem.Content.ToString() == "Регистрация")
                {
                    Registrations registrations = new Registrations();
                    registrations.Show();
                }

                if (selectedItem.Content.ToString() == "Выйти из аккаунта")
                {
                    MessageBoxResult result = MessageBox.Show("Вы хотите выйти из аккаунта?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        authorization.authorz = false;
                    }
                }


                    akaunt.IsOpen = false;
                
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if (authorization.authorz == true)
            {
                Pay pay = new Pay();
                pay.Show();
            }
            else
            {
                MessageBox.Show("Войдите в аккаунт", "доступ ограничен", MessageBoxButton.OK, MessageBoxImage.Error);
            }
               
        }

        private void Arenda_Click(object sender, RoutedEventArgs e)
        {
            if (authorization.authorz == true)
            {
                ArendaWindow arenda = new ArendaWindow();
                arenda.Show();
            }
            else
            {
                MessageBox.Show("Войдите в аккаунт", "доступ ограничен", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Reqests_Click(object sender, RoutedEventArgs e)
        {
            
            ListReqests.IsOpen = !ListReqests.IsOpen;
        }

        private void listReqestsBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
