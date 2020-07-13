using MagicCoreClasses.InfoRepository;
using MagicCoreWPF.DataBase;
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

namespace MagicCoreWPF
{
    /// <summary>
    /// Логика взаимодействия для EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        public EditCategory()
        {
            InitializeComponent();
            ParentIdBox.ItemsSource = Storage.Instance.categories;
            ParentIdBox.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ParentIdBox.SelectedIndex >= 0 && NameText.Text.Length > 0)
            {
                MainDataBaseController.Instance.AddCategory(NameText.Text, (ParentIdBox.SelectedItem as Category).id);
                this.DialogResult = true;
            }
            else 
            {
                MessageBox.Show("Не заполнены все поля!","Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
