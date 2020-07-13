using MagicCoreClasses.InfoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MagicCoreWPF.InternalClasses
{
    public class CategoryTreeItem : TreeViewItem
    {
        public long id { get; set; }

        public long parentId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public CategoryTreeItem(long _id, long _parentId, string _name, string _description)
        {
            id = _id;
            parentId = _parentId;
            name = _name;
            description = _description;
        }

        public CategoryTreeItem(Category category) 
        {
            id = category.id;
            parentId = category.parentId;
            name = category.name;
            description = category.description;
        }
    }
}
