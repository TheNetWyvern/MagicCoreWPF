using MagicCoreClasses.InfoRepository;
using MagicCoreWPF.DataBase.Interfaces;
using Microsoft.Data.Sqlite;
using System.IO;

namespace MagicCoreWPF.DataBase
{
    //TODO: Добавить безопасные команды
    //TODO: Добавить MVVM
    public class SQLiteDataBaseController : IDataBaseController
    {
        private SqliteConnection connection;
        private SqliteCommand command;
        private SqliteDataReader reader;

        public void AddCategory(string name, long parentCategoryId)
        {
            command = new SqliteCommand("INSERT INTO categories (parentId,name) VALUES ($parentId,$name)", connection);
            command.Parameters.AddWithValue("$name", name);
            command.Parameters.AddWithValue("$parentId", parentCategoryId);
            command.ExecuteNonQuery();
        }

        public void AddInfoBlock(long categoryId, string title, string content)
        {
            command = new SqliteCommand("INSERT INTO infoblocks (categoryId,title,content) VALUES ($categoryId,$title,$content)", connection);
            command.Parameters.AddWithValue("$categoryId", categoryId);
            command.Parameters.AddWithValue("$title", title);
            command.Parameters.AddWithValue("$content", content);
            command.ExecuteNonQuery();
        }

        public void ChangeCategory(long categoryId, string newName, long newParentCategoryId)
        {
            command = new SqliteCommand("UPDATE categories SET name = $name, parentId = $parentId WHERE id = $id", connection);
            command.Parameters.AddWithValue("$name", newName);
            command.Parameters.AddWithValue("$parentId", newParentCategoryId);
            command.Parameters.AddWithValue("$id", categoryId);
            command.ExecuteNonQuery();
        }

        public void ChangeInfoBlock(long infoBlockId, string newTitle, string newContent)
        {
            command = new SqliteCommand("UPDATE infoblocks SET title = $title, content = $content WHERE id = $id", connection);
            command.Parameters.AddWithValue("$title", newTitle);
            command.Parameters.AddWithValue("$content", newContent);
            command.Parameters.AddWithValue("$id", infoBlockId);
            command.ExecuteNonQuery();
        }

        public void InitDataBase()
        {
            Directory.CreateDirectory(Path.Combine(Configurator.Instance.folderPath, Configurator.Instance.folderName));

            connection = new SqliteConnection($"Data Source = {Path.Combine(Configurator.Instance.folderPath, Configurator.Instance.folderName, $"{Configurator.Instance.dataBaseName}.sqlite3")}");
            connection.Open();
            command = new SqliteCommand("CREATE TABLE IF NOT EXISTS categories" +
                "(" +
                    "id INTEGER," +
                    "parentId INTEGER," +
                    "name TEXT," +
                    "description TEXT DEFAULT desc," +
                    "PRIMARY KEY(id ASC)" +
                ")", connection);
            command.ExecuteNonQuery();

            command = new SqliteCommand("CREATE TABLE IF NOT EXISTS infoblocks" +
                "(" +
                    "id INTEGER," +
                    "categoryId INTEGER," +
                    "title TEXT," +
                    "content TEXT," +
                    "PRIMARY KEY(id ASC)" +
                ")", connection);
            command.ExecuteNonQuery();
            LoadDataBase();
        }

        private void LoadDataBase()
        {
            Storage.Instance.Categories.Clear();

            Storage.Instance.Categories.Add(new Category(0, -1, "Корень", "Описание"));
            command = new SqliteCommand("SELECT id,parentId,name,description FROM categories ORDER BY parentId ASC", connection);
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Storage.Instance.Categories.Add(new Category(reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3)));
                }
            }

            Storage.Instance.InfoBlocks.Clear();

            command = new SqliteCommand("SELECT id,categoryId,title,content FROM infoblocks", connection);
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Storage.Instance.InfoBlocks.Add(new InfoBlock(reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3)));
                }
            }
        }

        public void ReleaseBase()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
            connection = null;
            if (command != null)
            {
                command.Dispose();
            }
            command = null;
        }

        public void ReloadDataBase()
        {
            LoadDataBase();
        }

        public void RemoveCategory(long categoryId)
        {
            command = new SqliteCommand("DELETE FROM categories WHERE id = $id", connection);
            command.Parameters.AddWithValue("$id", categoryId);
            command.ExecuteNonQuery();
            //TODO: Recursively remove infoblock of deleted category
        }

        public void RemoveInfoBlock(long infoBlockId)
        {
            command = new SqliteCommand("DELETE FROM infoblocks WHERE id = $id", connection);
            command.Parameters.AddWithValue("$id", infoBlockId);
            command.ExecuteNonQuery();
        }
    }
}