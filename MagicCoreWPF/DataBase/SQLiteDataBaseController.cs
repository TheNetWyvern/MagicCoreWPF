using MagicCoreWPF.DataBase.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCoreWPF.DataBase
{
    public class SQLiteDataBaseController : IDataBaseController
    {
        SqliteConnection connection;
        SqliteCommand command;

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
            Directory.CreateDirectory(Path.Combine(Configurator.Instance.folderPath, Configurator.Instance.folderName));

            connection = new SqliteConnection($"Data Source = {Path.Combine(Configurator.Instance.folderPath, Configurator.Instance.folderName,Configurator.Instance.dataBaseName,".sqlite3")}");
            connection.Open();
        }

        public void LoadDataBase()
        {

        }

        public void ReleaseBase()
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
