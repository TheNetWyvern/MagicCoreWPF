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
    /// Логика взаимодействия для EditInfoBlock.xaml
    /// </summary>
    public partial class EditInfoBlock : Window
    {
        private bool isChanged;
        private InfoBlock tempInfoBlock;

        public EditInfoBlock()
        {
            InitializeComponent();
            InitializeCategoryIdBox(-1);
            isChanged = false;
        }

        public EditInfoBlock(long id)
        {
            InitializeComponent();
            InitializeCategoryIdBox(id);
            isChanged = false;
        }

        public EditInfoBlock(InfoBlock infoBlock)
        {
            InitializeComponent();
            InitializeCategoryIdBox(infoBlock.CategoryId);
            TitleText.Text = infoBlock.Title;
            ContentText.Text = infoBlock.Content;
            tempInfoBlock = infoBlock;
            isChanged = true;
        }

        private void InitializeCategoryIdBox(long id)
        {
            CategoryIdBox.ItemsSource = Storage.Instance.Categories;
            if (id >= 0)
            {
                for (int i = 0; i < CategoryIdBox.Items.Count; i++)
                {
                    if ((CategoryIdBox.Items[i] as Category).Id == id)
                    {
                        CategoryIdBox.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                CategoryIdBox.SelectedIndex = 0;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryIdBox.SelectedIndex >= 0 && TitleText.Text.Length > 0 && ContentText.Text.Length > 0)
            {
                if (isChanged)
                {
                    MainDataBaseController.Instance.ChangeInfoBlock(tempInfoBlock.Id, TitleText.Text, ContentText.Text);
                }
                else
                {
                    MainDataBaseController.Instance.AddInfoBlock(((Category)CategoryIdBox.SelectedItem).Id, TitleText.Text,ContentText.Text);
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
