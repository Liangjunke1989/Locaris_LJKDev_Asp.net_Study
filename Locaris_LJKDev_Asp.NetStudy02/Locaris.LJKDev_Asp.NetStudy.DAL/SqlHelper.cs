using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Locaris.LJKDev_Asp.NetStudy.DAL
{

    public static class SqlHelper
    {

        #region 获取连接字符串
        private static string GetConnetionSqlString()
        {
            return ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        }
        #endregion

        #region 从数据库里获取到，生成内存表DataTable
        public static DataTable LJK_GetDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnetionSqlString()))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    if (parameters != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    }
                    //adapter.SelectCommand.CommandType = type;   //传的可能不是sql语句，可能是存储过程的名字
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        #endregion

        #region 执行SQL语句，返回受影响的行数
        public static int LJK_ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnetionSqlString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.CommandType = type;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion


    }

}
