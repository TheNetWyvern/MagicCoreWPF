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
        private bool isChanged = false;
        private Category tempCategory;
        public EditCategory()
        {
            InitializeComponent();
            InitializeParentIdBox(-1);
            isChanged = false;
        }

        public EditCategory(long id)
        {
            InitializeComponent();
            InitializeParentIdBox(id);
            isChanged = false;
        }

        public EditCategory( Category category)
        {
            InitializeComponent();
            InitializeParentIdBox(category.ParentId);
            NameText.Text = category.Name;
            tempCategory = category;
            isChanged = true;
        }

        private void InitializeParentIdBox(long id) 
        {
            ParentIdBox.ItemsSource = Storage.Instance.Categories;
            if (id >= 0)
            {
                for (int i = 0; i < ParentIdBox.Items.Count; i++) 
                {
                    if ((ParentIdBox.Items[i] as Category).Id == id) 
                    {
                        ParentIdBox.SelectedIndex = i;
                        break;
                    }
                }
            }
            else 
            {
                ParentIdBox.SelectedIndex = 0;
            }
           
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ParentIdBox.SelectedIndex >= 0 && NameText.Text.Length > 0)
            {
                if (isChanged)
                {
                    MainDataBaseController.Instance.ChangeCategory(tempCategory.Id, NameText.Text, ((Category)ParentIdBox.SelectedItem).Id);
                }
                else
                { 
                    MainDataBaseController.Instance.AddCategory(NameText.Text, ((Category)ParentIdBox.SelectedItem).Id);
                }
                MainDataBaseController.Instance.ReloadDataBase();
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Не заполнены все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}