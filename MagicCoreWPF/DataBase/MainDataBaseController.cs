using MagicCoreWPF.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCoreWPF.DataBase
{
    //TODO: NotSetControllerException
    public class MainDataBaseController : IDataBaseController
    {
        private IDataBaseController currentController;

        private static readonly Lazy<MainDataBaseController>
        lazy =
            new Lazy<MainDataBaseController>
                (() => new MainDataBaseController());

        private MainDataBaseController() { }
        public static MainDataBaseController Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void SetController(IDataBaseController baseController) 
        {
            currentController = baseController;
        }

        public void AddCategory(string name, long parentCategoryId)
        {
            if (currentController != null)
            {
                currentController.AddCategory(name, parentCategoryId);
            }
        }

        public void AddInfoBlock(long categoryId, string title, string content)
        {
            if (currentController != null)
            {
                currentController.AddInfoBlock(categoryId, title, content);
            }
        }

        public void ChangeCategory(long categoryId, string newName, long newParentCategoryId)
        {
            if (currentController != null)
            {
                currentController.ChangeCategory(categoryId, newName, newParentCategoryId);
            }
        }

        public void ChangeInfoBlock(long infoBlockId, string newTitle, string newContent)
        {
            if (currentController != null)
            {
                currentController.ChangeInfoBlock(infoBlockId, newTitle, newContent);
            }
        }

        public void InitDataBase()
        {
            if (currentController != null)
            {
                currentController.InitDataBase();
            }
        }

        public void ReleaseBase()
        {
            if (currentController != null)
            {
                currentController.ReleaseBase();
            }
        }

        public void RemoveCategory(long categoryId)
        {
            if (currentController != null)
            {
                currentController.RemoveCategory(categoryId);
            }
        }

        public void RemoveInfoBlock(long infoBlockId)
        {
            if (currentController != null)
            {
                currentController.RemoveInfoBlock(infoBlockId);
            }
        }

        public void ReloadDataBase()
        {
            if (currentController != null)
            {
                currentController.ReloadDataBase();
            }
        }
    }
}