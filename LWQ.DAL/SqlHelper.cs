using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace LWQ.DAL
{
    public class SqlHelper
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["LWQ"].ConnectionString;

        public T Get<T>(int id)
        {
            Type type = typeof(T);
            string columnsString = string.Join(",",type.GetProperties().Select(x => $"[{x.Name}]")); 
            string sql = $@"SELECT {columnsString} FROM [{type.Name}] WHERE Id = {id}";
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
                        prop.SetValue(t,reader[prop.Name] is DBNull ? null:reader[prop.Name]);
                    }
                    return t;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public List<T> GetAll<T>()
        {
            Type type = typeof(T);
            string columnsString = string.Join(",", type.GetProperties().Select(x => $"[{x.Name}]"));
            string sql = $@"SELECT {columnsString} FROM [{type.Name}]";
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
                        prop.SetValue(t, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                    list.Add(t);
                }
                return list;
            }
        }
    }
}
