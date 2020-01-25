using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.DbHelpers;
using WpfCrud.Context;
using WpfCrud.Models;

namespace WpfCrud.BLL
{
    public class CategoryBLL
    {
        public static List<Category> GetAll()
        {
            SqlContext context = new SqlContext();
            return context.GetAll<Category>
                ("GetAllCategories",CommandType.StoredProcedure,null);
        }

        public static int AddCategory(Category category)
        {
            string sqlstr=string.Format("insert into Categories(CategoryName,Description) values('{0}','{1}')",category.CategoryName,category.Description);
            SqlContext context = new SqlContext();
            return context.ExecuteNonQuery(sqlstr, CommandType.Text,null);
        }
        /// <summary>
        /// Güncelleme metodu
        /// </summary>
        /// <param name="category">Catgory </param>
        /// <returns>ExecuteNonQuery() döndürür </returns>
        public static int UpdateCategory(Category category)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CategoryID",category.CategoryID),
                new SqlParameter("@CategoryName",category.CategoryName),
                new SqlParameter("@Description",category.Description)
            };
            SqlContext context = new SqlContext();
            return context.ExecuteNonQuery("UpdateCategory", CommandType.StoredProcedure, parameters);
        }

        public static int DeleteCategory(Category category)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CategoryID",category.CategoryID),
                new SqlParameter("@ProductCount",SqlDbType.Int)
            };
            parameters[1].Direction = ParameterDirection.Output;
            SqlContext context = new SqlContext();
            return context.ExecuteNonQuery("DeleteCategory", CommandType.StoredProcedure, parameters);
        }

    }
}
