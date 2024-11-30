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
    /// Логика взаимодействия для Pay.xaml
    /// </summary>
    public partial class Pay : Window
    {
        
        public Pay()
        {
            InitializeComponent();
                        
            
            var user = ConectDB.cone.Fines.Where(x => x.UserID == UserData.Id).ToList();        
            FineListBox.ItemsSource = user;
            
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = ConectDB.cone.Fines.FirstOrDefault(x => x.UserID == UserData.Id);
            user.Paid = true;

        }

        private void FineListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = ConectDB.cone.Fines.FirstOrDefault(x => x.UserID == UserData.Id);
            if (FineListBox.SelectedItem is ListBoxItem selectedItem)
            {
                if(selectedItem.Content.ToString() == user.Id.ToString())
                {
                    Sum.Text = $"Стоимость трафа: {user.Amount.ToString()} рублей";
                }
            }
        }
    }
}
