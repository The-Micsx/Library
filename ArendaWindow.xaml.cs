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
    /// Логика взаимодействия для ArendaWindow.xaml
    /// </summary>
    public partial class ArendaWindow : Window
    {

        public ArendaWindow()
        {
            var book = ConectDB.cone.Books.ToList();
            InitializeComponent();
            BookListItem.ItemsSource = book;
        }

        private void BookListItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {





        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (BookListItem.SelectedItem is Books selectedBooks)
            {
                string input = LoanDate.Text;
                string inp = DueDate.Text;

                if (DateTime.TryParse(input, out DateTime loanDate) && DateTime.TryParse(inp, out DateTime dueDate))
                {

                    Loans loans = new Loans()
                    {
                        UserId = UserData.Id,
                        BookId = selectedBooks.Id,
                        LoanDate = loanDate,
                        DueDate = dueDate


                    };
                    ConectDB.cone.Loans.Add(loans);
                    ConectDB.cone.SaveChanges();

                    Close();
                }
                else
                {
                    MessageBox.Show("Не коретный формат даты", "Не коретная информация", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}
