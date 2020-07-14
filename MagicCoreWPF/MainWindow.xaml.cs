using MagicCoreClasses.InfoRepository;
using MagicCoreWPF.DataBase;
using MagicCoreWPF.InternalClasses.Models;
using MagicCoreWPF.InternalClasses.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MagicCoreWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;
        private bool isClicked = false;

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
        }

        private void UpdateInfoBlocks() 
        {
            InfoBlocks.Items.Clear();
            for (int i = 0; i < Storage.Instance.InfoBlocks.Count; i++)
            {
                if (Storage.Instance.InfoBlocks[i].CategoryId == (Categories.SelectedItem  as CategoryTreeItem).Id)
                {
                    InfoBlocks.Items.Add(Storage.Instance.InfoBlocks[i]);
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainDataBaseController.Instance.ReleaseBase();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            EditCategory categoryForm = new EditCategory(Categories.SelectedItem != null ? (Categories.SelectedItem as Category).Id : -1);
            if (categoryForm.ShowDialog() == true)
            {
                UpdateCategories();
            }
        }

        private void ChangeCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (Categories.SelectedItem != null)
            {
                EditCategory categoryForm = new EditCategory(Categories.SelectedItem as Category);
                if (categoryForm.ShowDialog() == true)
                {
                    UpdateCategories();
                }
            }
        }

        private void RemoveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (Categories.SelectedItem != null)
            {
                
                if (MessageBox.Show("Вы уверены?","Удаление категории", MessageBoxButton.OKCancel,MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    MainDataBaseController.Instance.RemoveCategory((Categories.SelectedItem as Category).Id);
                    MainDataBaseController.Instance.ReloadDataBase();
                    RemoveCategoryButton.IsEnabled = false;
                    ChangeCategoryButton.IsEnabled = false;
                    AddInfoBlockButton.IsEnabled = false;
                    ChangeInfoBlockButton.IsEnabled = false;
                    RemoveInfoBlockButton.IsEnabled = false;
                    UpdateCategories();
                }
            }
        }

        private void TreeViewItem_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!isClicked)
            {
                if (((sender as TreeViewItem).DataContext as CategoryTreeItem).Id == 0)
                {
                    RemoveCategoryButton.IsEnabled = false;
                    ChangeCategoryButton.IsEnabled = false;
                }
                else
                {
                    RemoveCategoryButton.IsEnabled = true;
                    ChangeCategoryButton.IsEnabled = true;
                }
                AddInfoBlockButton.IsEnabled = true;
                UpdateInfoBlocks();
                isClicked = true;
                ChangeInfoBlockButton.IsEnabled = false;
                RemoveInfoBlockButton.IsEnabled = false;
            }
            if (((sender as TreeViewItem).DataContext as CategoryTreeItem).Id == 0) 
            {
                isClicked = false;
            }
        }


        private void InfoBlocks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InfoBlocks.SelectedIndex >= 0) 
            {
                AddInfoBlockButton.IsEnabled = true;
                ChangeInfoBlockButton.IsEnabled = true;
                RemoveInfoBlockButton.IsEnabled = true;
            }

        }

        private void RemoveInfoBlockButton_Click(object sender, RoutedEventArgs e)
        {
            if (InfoBlocks.SelectedItem != null)
            {

                if (MessageBox.Show("Вы уверены?", "Удаление инфоблока", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    MainDataBaseController.Instance.RemoveInfoBlock((InfoBlocks.SelectedItem as InfoBlock).Id);
                    MainDataBaseController.Instance.ReloadDataBase();
                    AddInfoBlockButton.IsEnabled = false;
                    ChangeInfoBlockButton.IsEnabled = false;
                    RemoveInfoBlockButton.IsEnabled = false;
                    UpdateInfoBlocks();
                }
            }
        }

        private void AddInfoBlockButton_Click(object sender, RoutedEventArgs e)
        {
            EditInfoBlock infoBlockForm = new EditInfoBlock(Categories.SelectedItem != null ? (Categories.SelectedItem as Category).Id : -1);
            if (infoBlockForm.ShowDialog() == true)
            {
                UpdateInfoBlocks();
            }
        }

        private void ChangeInfoBlockButton_Click(object sender, RoutedEventArgs e)
        {
            if (InfoBlocks.SelectedItem != null)
            {
                EditInfoBlock infoBlockForm = new EditInfoBlock(InfoBlocks.SelectedItem as InfoBlock);
                if (infoBlockForm.ShowDialog() == true)
                {
                    UpdateInfoBlocks();
                }
            }
        }
    }
}