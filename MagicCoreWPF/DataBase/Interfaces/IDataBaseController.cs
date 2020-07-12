using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCoreWPF.DataBase.Interfaces
{
    public interface IDataBaseController
    {
        void LoadDataBase();
        void InitDataBase();
        void AddCategory(string name, long parentCategoryId);
        void ChangeCategory(long categoryId, string newName, long newParentCategoryId);
        void RemoveCategory(long categoryId);

        void AddInfoBlock(long categoryId, string name, string content);
        void ChangeInfoBlock(long infoBlockId, string newName, string newContent);
        void RemoveInfoBlock(long infoBlockId);
        void ReleaseBase();
    }
}
