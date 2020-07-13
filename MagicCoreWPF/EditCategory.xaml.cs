using MagicCoreClasses.InfoRepository;
using MagicCoreWPF.DataBase;
using System.Windows;

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
            ParentIdBox.ItemsSource = Storage.Instance.Categories;
            ParentIdBox.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ParentIdBox.SelectedIndex >= 0 && NameText.Text.Length > 0)
            {
                MainDataBaseController.Instance.AddCategory(NameText.Text, ((Category)ParentIdBox.SelectedItem).Id);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Не заполнены все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}