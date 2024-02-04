using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.Data;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.Data
{
    public class BaseRepo<T> : IBaseRepo<T> where T : Tabledata, new()
    {
        SQLiteConnection connection;
        public string? statusMessage { get; set; }

        public BaseRepo()
        {
            connection = new SQLiteConnection(Constants.DBPath, Constants.flags);
            connection.CreateTable<T>();
        }
        public void DeleteEntity(T entity)
        {
            try
            {
                var result = connection.Delete(entity);
                statusMessage = $"{result} Row(s) Deleted";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public List<T>? GetEntities()
        {
            try
            {
                var table = connection.Table<T>().ToList();
                if (table == null)
                {
                    statusMessage = $"Error: Table is empty";
                    return null;
                }
                else
                    return table;
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public T? GetSpecificEntity(int id)
        {
            try
            {
                var table = connection.Table<T>().ToList();
                if (table == null)
                {
                    statusMessage = $"Error: Table is empty";
                    return null;
                }
                else
                    return connection.Table<T>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void SaveEntity(T entity)
        {
            try
            {
                if (entity.Id != 0)
                {
                    var result = connection.Update(entity);
                    statusMessage = $"{result} Row(s) updated;";
                }
                else
                {
                    var result = connection.Insert(entity);
                    statusMessage = $"{result} Row(s) added";
                }
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }
        public bool Checkifempty()
        {
            var result = false;
            try
            {
                var table = connection.Table<T>().ToList();
                if (table.Count == 0)
                {
                    statusMessage = $"Table is empty";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
                result = false;
            }
            return result;
        }
        public void SaveEntityWithChildren(T entity, bool recursive = false) 
        {
            try
            {
                if(entity.Id != 0)
                {
                    connection.UpdateWithChildren(entity);
                }
                else
                {
                    connection.InsertWithChildren(entity, recursive);
                }
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }
        public void DeleteEntityWithChildren(T entity)
        {
            try
            {
                connection.Delete(entity, true);
            }
            catch(Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
        }
        public List<T> GetEntitiesWithChildren()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
    }
}
