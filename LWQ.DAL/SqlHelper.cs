using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using LWQ.Framework;

namespace LWQ.DAL
{
    public class SqlHelper
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["LWQ"].ConnectionString;

        public T Get<T>(int id)
        {
            Type type = typeof(T);
            string columnsString = string.Join(",",type.GetProperties().Select(x => $"[{x.GetMappingName()}]")); 
            //string sql = $@"SELECT {columnsString} FROM [{type.Name}] WHERE Id = {id}";
            string sql = $@"SELECT {columnsString} FROM [{type.GetMappingName()}] WHERE Id = {id}";
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T t = (T)Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t,reader[prop.GetMappingName()] is DBNull ? null:reader[prop.GetMappingName()]);
                    }
                    return t;
                }
                return default(T);
            }
        }

        public List<T> GetAll<T>()
        {
            Type type = typeof(T);
            string columnsString = string.Join(",", type.GetProperties().Select(x => $"[{x.GetMappingName()}]"));
            //string sql = $@"SELECT {columnsString} FROM [{type.Name}]";
            string sql = $@"SELECT {columnsString} FROM [{type.GetMappingName()}]";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql,conn);
                conn.Open();
                var reader = command.ExecuteReader();
                List<T> list = new List<T>();
                while (reader.Read())
                {
                    T t = (T)Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t, reader[prop.GetMappingName()] is DBNull ? null : reader[prop.GetMappingName()]);
                    }
                    list.Add(t);
                }
                return list;
            }
        }
    }
}
