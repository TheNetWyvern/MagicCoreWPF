using MagicCoreWPF.DataBase;
using MagicCoreWPF.InternalClasses.ViewModels;
using System;
using System.Windows;

namespace MagicCoreWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            MainDataBaseController.Instance.SetController(new SQLiteDataBaseController());
            MainDataBaseController.Instance.InitDataBase();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
            Categories.Items.Add(_viewModel.RootCategory);
            //UpdateCategories();
        }

        private void UpdateCategories()
        {
            //Categories.Items.Clear();
            //Categories.Items.Add(new CategoryTreeItem(Storage.Instance.Categories[0]));
            //foreach (var category in Storage.Instance.Categories)
            //{
            //    for (int i = 0; i < Categories.Items.Count; i++)
            //    {
            //        CategoryTreeItem newCategory = (CategoryTreeItem)Categories.Items[i];
            //        if (category.ParentId == newCategory.Id)
            //        {
            //            newCategory.Items.Add(new CategoryTreeItem(category));
            //            break;
            //        }
            //    }
            //}
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainDataBaseController.Instance.ReleaseBase();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            EditCategory categoryForm = new EditCategory();
            if (categoryForm.ShowDialog() == true)
            {
                _viewModel.LoadRootCategory();
                Categories.Items.Clear();
                Categories.Items.Add(_viewModel.RootCategory);
            }
        }
    }
}