using MagicCoreWPF.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCoreWPF.DataBase
{
    public class MainDataBaseController : IDataBaseController
    {
        private IDataBaseController currentController;

        public MainDataBaseController(IDataBaseController baseController) 
        {
            currentController = baseController;
        }

        public void AddCategory(string name, long parentCategoryId)
        {
            currentController.AddCategory(name, parentCategoryId);
        }

        public void AddInfoBlock(long categoryId, string name, string content)
        {
            currentController.AddInfoBlock(categoryId,name,content);
        }

        public void ChangeCategory(long categoryId, string newName, long newParentCategoryId)
        {
            currentController.ChangeCategory(categoryId, newName, newParentCategoryId);
        }

        public void ChangeInfoBlock(long infoBlockId, string newName, string newContent)
        {
            currentController.ChangeInfoBlock(infoBlockId, newName, newContent);
        }

        public void InitDataBase()
        {
            currentController.InitDataBase();
        }

        public void LoadDataBase()
        {
            currentController.LoadDataBase();
        }

        public void ReadContent()
        {
            currentController.ReadContent();
        }

        public void RemoveCategory(long categoryId)
        {
            currentController.RemoveCategory(categoryId);
        }

        public void RemoveInfoBlock(long infoBlockId)
        {
            currentController.RemoveInfoBlock(infoBlockId);
        }
    }
}