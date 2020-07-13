using MagicCoreWPF.Extensions;
using MagicCoreWPF.InternalClasses.Models;
using System.Linq;

namespace MagicCoreWPF.InternalClasses.ViewModels
{
    public sealed class MainWindowViewModel : BaseViewModel
    {
        private CategoryTreeItem _rootCategoryTreeItem;

        public CategoryTreeItem RootCategory
        {
            get => _rootCategoryTreeItem;
            set
            {
                _rootCategoryTreeItem = value;
                OnPropertyChanged(nameof(RootCategory));
            }
        }

        public MainWindowViewModel()
        {
            
        }

        public void LoadRootCategory()
        {
            var databaseCategories = Storage.Instance.Categories;
            var root = new CategoryTreeItem(databaseCategories[0]);          
            RootCategory = SetChildCategories(root);
        }

        private CategoryTreeItem SetChildCategories(CategoryTreeItem root)
        {

            for (int i = 0; i < Storage.Instance.Categories.Count; i++) 
            {
                if (Storage.Instance.Categories[i].ParentId == root.Id) 
                {
                    root.Items.Add(SetChildCategories(new CategoryTreeItem(Storage.Instance.Categories[i])));
                }
            }
            return root;
        }
    }
}