using MagicCoreWPF.DataBase;
using MagicCoreWPF.InternalClasses;
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

namespace MagicCoreWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// 
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainDataBaseController.Instance.SetController(new SQLiteDataBaseController());
            MainDataBaseController.Instance.InitDataBase();
            Update();

        }

        private void Update() 
        {
            Categories.Items.Clear();
            Categories.Items.Add(new CategoryTreeItem(Storage.Instance.categories[0]));
            foreach (MagicCoreClasses.InfoRepository.Category category in Storage.Instance.categories)
            {
                for (int i = 0; i < Categories.Items.Count; i++)
                {
                    if (category.parentId == (Categories.Items[i] as CategoryTreeItem).id)
                    {
                        (Categories.Items[i] as CategoryTreeItem).Header = "123123";
                        (Categories.Items[i] as CategoryTreeItem).Items.Add(new CategoryTreeItem(category));
                        break;
                    }
                }
            }
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
                Update();
            }
        }
    }
}