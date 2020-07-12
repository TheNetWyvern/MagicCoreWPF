﻿using MagicCoreClasses.InfoRepository;
using MagicCoreWPF.DataBase.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace MagicCoreWPF.DataBase
{
    //TODO: Добавить безопасные команды
    public class SQLiteDataBaseController : IDataBaseController
    {
        SqliteConnection connection;
        SqliteCommand command;
        SqliteDataReader reader;

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

            connection = new SqliteConnection($"Data Source = {Path.Combine(Configurator.Instance.folderPath, Configurator.Instance.folderName,$"{Configurator.Instance.dataBaseName}.sqlite3")}");
            connection.Open();
            command = new SqliteCommand("CREATE TABLE IF NOT EXISTS categories" +
                "(" +
                    "id INTEGER," +
                    "parentId INTEGER," +
                    "name TEXT," +
                    "description TEXT," +
                    "PRIMARY KEY(id ASC)" +
                ")",connection);
            command.ExecuteNonQuery();

            command = new SqliteCommand("CREATE TABLE IF NOT EXISTS infoblocks" +
                "(" +
                    "id INTEGER," +
                    "categoryId INTEGER," +
                    "title TEXT," +
                    "content TEXT," +
                    "PRIMARY KEY(id ASC)" +
                ")",connection);
            command.ExecuteNonQuery();
            LoadDataBase();
        }

        private void LoadDataBase()
        {
            command = new SqliteCommand("SELECT id,parentId,name,description FROM categories",connection);
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Storage.Instance.categories.Add(new Category(reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3)));               
                }
            }

            command = new SqliteCommand("SELECT id,categoryId,title,content FROM infoblocks",connection);
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Storage.Instance.infoBlocks.Add(new InfoBlock(reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3)));
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
            throw new NotImplementedException();
        }

        public void RemoveInfoBlock(long infoBlockId)
        {
           // if()
        }


    }
}
