using MagicCoreClasses.InfoRepository;
using MagicCoreWPF.Annotations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MagicCoreWPF.InternalClasses.Models
{
    public sealed class CategoryTreeItem : Category, INotifyPropertyChanged
    {
        private ObservableCollection<CategoryTreeItem> _items;

        public ObservableCollection<CategoryTreeItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public CategoryTreeItem(long id, long parentId, string name, string description)
            : base(id, parentId, name, description)
        {
            Items = new ObservableCollection<CategoryTreeItem>();
        }

        public CategoryTreeItem(Category dbCategory)
            : base(dbCategory.Id, dbCategory.ParentId, dbCategory.Name, dbCategory.Description)
        {
            Items = new ObservableCollection<CategoryTreeItem>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}