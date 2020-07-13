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
            UpdateCategories();
        }

        private void UpdateCategories()
        { 
            _viewModel.LoadRootCategory();
            Categories.Items.Clear();
            Categories.Items.Add(_viewModel.RootCategory);
         //   (Categories.Items[0] as TreeViewItem)
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
                UpdateCategories();
            }
        }
    }
}