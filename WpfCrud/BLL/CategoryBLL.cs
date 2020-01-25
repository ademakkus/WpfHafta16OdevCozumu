using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.DbHelpers;
using WpfCrud.Models;

namespace WpfCrud.BLL
{
    public class CategoryBLL
    {
        public static List<Category> GetAll()
        {
            SqlDataReader reader= Helper.ExecuteReader("GetAllCategories", CommandType.StoredProcedure);
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                categories.Add(new Category(reader.GetInt32(0),reader.GetString(1),reader.GetString(2)));
            }
            reader.Close();
            return categories;
        }

        public static int AddCategory(Category category)
        {
            string sqlstr=string.Format("insert into Categories(CategoryName,Description) values('{0}','{1}')",category.Name,category.Description);
            return Helper.ExecuteNonQuery(sqlstr, CommandType.Text);
        }

        public static int UpdateCategory(Category category)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CategoryID",category.Id),
                new SqlParameter("@CategoryName",category.Name),
                new SqlParameter("@Description",category.Description)
            };
            return Helper.ExecuteNonQuery("UpdateCategory", CommandType.StoredProcedure, parameters);
        }

        public static int DeleteCategory(Category category)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@CategoryID",category.Id),
                new SqlParameter("@ProductCount",SqlDbType.Int)
            };
            parameters[1].Direction = ParameterDirection.Output;
            return Helper.ExecuteNonQuery("DeleteCategory", CommandType.StoredProcedure, parameters);
        }

    }
}
