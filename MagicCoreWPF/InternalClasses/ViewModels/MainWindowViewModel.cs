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
            SetChildCategories(root);
            RootCategory = root;
        }

        private void SetChildCategories(CategoryTreeItem root)
        {
            //Skip root category
            var categories = Storage.Instance.Categories.Skip(1).ToList();
            while (categories.Count > 0)
            {
                var newTreeViewCategory = new CategoryTreeItem(categories[0]);
                var childCategories = Storage.Instance.Categories
                    .Where(c => c.ParentId == newTreeViewCategory.Id)
                    .Select(c => new CategoryTreeItem(c));
                newTreeViewCategory.Items.AddRange(childCategories);
                root.Items.Add(newTreeViewCategory);
                categories.RemoveAt(0);
                categories.RemoveAll(c => c.ParentId == newTreeViewCategory.Id);
            }
        }
    }
}