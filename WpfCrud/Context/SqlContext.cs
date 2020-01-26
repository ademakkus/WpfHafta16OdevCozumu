using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vektorel.DbHelpers;
namespace WpfCrud.Context
{
    class SqlContext
    {

        public int ExecuteNonQuery(string sqlstr, CommandType cmdType, SqlParameter[] parameters)
        {

            return Helper.ExecuteNonQuery(sqlstr,cmdType,parameters);
        }
        public List<T> GetAll<T>(string sqlstr, CommandType cmdType, SqlParameter[] parameters)where T:new()
        {

            SqlDataReader reader = Helper.ExecuteReader(sqlstr, cmdType, parameters);
            List<T> items = new List<T>(); //items generic liste
            Type type = typeof(T);
            //var properties=type.GetProperties(BindingFlags.Instance|BindingFlags.Public);
            while (reader.Read())
            {

                T item = new T();
                Type objType = item.GetType();
                var properties = objType.GetProperties(BindingFlags.Instance|BindingFlags.Public);
                foreach (var property in properties)
                {
                    if (reader.HasRows!=null)
                    {
                        //while (reader.Read())
                        //{
                            property.SetValue(item, reader[property.Name]); 
                        //}
                    }
                }
                items.Add(item);

            }
            reader.Close();
            return items;
        }

    }
}
