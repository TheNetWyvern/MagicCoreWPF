using MagicCoreWPF.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCoreWPF.DataBase
{
    public class SQLiteDataBaseController : IDataBaseController
    {
        public void AddCategory(string name, long parentCategoryId)
        {
            throw new NotImplementedException();
        }

        public void AddInfoBlock(long categoryId, string name, string content)
        {
            throw new NotImplementedException();
        }

        public void ChangeCategory(long categoryId, string newName, long newParentCategoryId)
        {
            throw new NotImplementedException();
        }

        public void ChangeInfoBlock(long infoBlockId, string newName, string newContent)
        {
            throw new NotImplementedException();
        }

        public void InitDataBase()
        {
            throw new NotImplementedException();
        }

        public void LoadDataBase()
        {
            throw new NotImplementedException();
        }

        public void ReadContent()
        {
            throw new NotImplementedException();
        }

        public void RemoveCategory(long categoryId)
        {
            throw new NotImplementedException();
        }

        public void RemoveInfoBlock(long infoBlockId)
        {
            throw new NotImplementedException();
        }
    }
}
