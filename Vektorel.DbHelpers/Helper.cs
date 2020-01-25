using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.DbHelpers
{
    public class Helper
    {
        protected static readonly string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public static int ExecuteNonQuery(string sqlstr,CommandType cType, SqlParameter[] parameters=null)
        /// <summary>
        /// <param name="cType">Command type</param>
        /// <returns>numRows</returns>
        public static int ExecuteNonQuery(string sqlstr, CommandType cType, SqlParameter[] parameters = null)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            cmd.CommandType = cType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            int numRows = 0;
            try
            {
                con.Open();
                numRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            return numRows;
        } 
        #endregion

        public static SqlDataReader ExecuteReader(string sqlstr, CommandType cType, SqlParameter[] parameters=null)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            cmd.CommandType = cType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            SqlDataReader reader=null;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                throw ex;
            }
            return reader;
        }

        //public static List<T> ExecuteReader<T>(string sqlstr, CommandType cType, SqlParameter[] parameters = null)
        //{
        //    SqlConnection con = new SqlConnection(constr);
        //    SqlCommand cmd = new SqlCommand(sqlstr, con);
        //    cmd.CommandType = cType;
        //    if (parameters != null)
        //        cmd.Parameters.AddRange(parameters);
        //    List<T> items = new List<T>();
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (con.State != ConnectionState.Closed)
        //            con.Close();
        //        throw ex;
        //    }
        //  //  return reader;
        //}

        public static object ExecuteScalar(string sqlstr, CommandType cType,SqlParameter[] parameters=null)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            cmd.CommandType = cType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            object result = null;
            try
            {
                con.Open();
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            return result;
        }
    }
}
