using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.DAL
{
    public partial class UserInfoDal
    {
        #region 查询展示用户数据
        public List<UserInfoEntity> GetUserInfoList()
        {
            string sql = "select * from User_Info";
            //CommandType type = CommandType.Text;
            DataTable dataTable = SqlHelper.LJK_GetDataTable(sql);
            List<UserInfoEntity> userInfoList = null;
            if (dataTable.Rows.Count > 0)
            {
                userInfoList = new List<UserInfoEntity>();
                UserInfoEntity userInfoEntity = null;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    userInfoEntity = new UserInfoEntity();
                    LoadEntity(userInfoEntity, dataRow);
                    userInfoList.Add(userInfoEntity);
                }
            }
            return userInfoList;
        }
        #endregion

        #region 将DataRow的数据转换成userInfoEntiy实体类的数据
        //查询数据库中的值，赋值给实体类的值！目的是更加严谨，数据库中有些字段允许为空的情况！
        private void LoadEntity(UserInfoEntity userInfoEntity, DataRow dataRow)
        {
            userInfoEntity.UserId = int.Parse(dataRow["User_Id"].ToString());
            userInfoEntity.UserAge = dataRow["User_Age"] != DBNull.Value
                ? int.Parse(dataRow["User_Age"].ToString()) : 0;
            userInfoEntity.UserName = dataRow["User_Name"] != DBNull.Value
                ? dataRow["User_Name"].ToString() : string.Empty;
            userInfoEntity.UserPwd = dataRow["User_Pwd"] != DBNull.Value
                ? dataRow["User_Pwd"].ToString() : string.Empty;
        }
        #endregion

        #region 添加用户信息
        //添加用户数据
        public int InsertUserInfo(UserInfoEntity userInfoEntity)
        {
            string sql = "insert into User_Info(User_Name,User_Age,User_Pwd)values(@UserName,@UserAge,@UserPwd)";
            SqlParameter[] parameters =
            {
                //new SqlParameter("@UserName", userInfoEntity.UserName),
                //new SqlParameter("@UserAge", userInfoEntity.UserAge),
                //new SqlParameter("@UserPwd", userInfoEntity.UserPwd),
                new SqlParameter("@UserName", SqlDbType.NVarChar,32),
                new SqlParameter("@UserAge", SqlDbType.Int),
                new SqlParameter("@UserPwd", SqlDbType.Int),
            };
            parameters[0].Value = userInfoEntity.UserName;
            parameters[1].Value = userInfoEntity.UserAge;
            parameters[2].Value = userInfoEntity.UserPwd;
            return SqlHelper.LJK_ExecuteNonQuery(sql, CommandType.Text, parameters);
        }
        #endregion

        #region 删除用户信息
        public int DeleteUserInfo(int userId)
        {
            string sql = "delete from User_Info where User_Id=@UserId";
            SqlParameter parameter = new SqlParameter("@UserId", userId);
            return SqlHelper.LJK_ExecuteNonQuery(sql, CommandType.Text, parameter);
        }
        #endregion

        #region  根据用户的id编号，查询用户的信息
        /// <summary>
        /// 根据用户ID,查询出用户信息
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>用户信息</returns>
        public UserInfoEntity GetUserInfoEntity(int id)
        {
            string sql = "select * from User_Info where User_Id=@UserId";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserId", SqlDbType.Int),
            };
            parameters[0].Value = id;
            DataTable dataTable = SqlHelper.LJK_GetDataTable(sql, parameters);
            UserInfoEntity userInfoEntity = null;
            if (dataTable.Rows.Count > 0)
            {
                userInfoEntity = new UserInfoEntity();
                LoadEntity(userInfoEntity, dataTable.Rows[0]);//根据主键Id查询只能查询到一条数据
            }
            return userInfoEntity;
        }
        #endregion

        #region  根据用户名，查询用户的信息
        /// <summary>
        /// 根据用户名称，查询返回用户信息，目前认为用户名不会重复，只能查询出单个用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息</returns>
        public UserInfoEntity GetUserInfoEntity(string userName)
        {
            string sql = "select * from User_Info where User_Name=@UserName";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserName", SqlDbType.Char),
            };
            parameters[0].Value = userName;
            DataTable dataTable = SqlHelper.LJK_GetDataTable(sql, parameters);
            UserInfoEntity userInfoEntity = null;
            if (dataTable.Rows.Count > 0)
            {
                userInfoEntity = new UserInfoEntity();
                LoadEntity(userInfoEntity, dataTable.Rows[0]);//目前只能认为根据userName查询只能查询到一条数据
            }
            return userInfoEntity;
        }
        #endregion

        #region 修改用户信息
        public int EditUserInfo(UserInfoEntity userInfoEntity)
        {
            string sql = "update User_Info set User_Name=@UserName,User_Age=@UserAge where User_Id=@UserId";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserName", SqlDbType.NVarChar,32),
                new SqlParameter("@UserAge", SqlDbType.Int),
                new SqlParameter("@UserPwd", SqlDbType.Int),
                new SqlParameter("@UserId",SqlDbType.Int),
            };
            parameters[0].Value = userInfoEntity.UserName;
            parameters[1].Value = userInfoEntity.UserAge;
            parameters[2].Value = userInfoEntity.UserPwd;
            parameters[3].Value = userInfoEntity.UserId;
            return SqlHelper.LJK_ExecuteNonQuery(sql, CommandType.Text, parameters);
        }
        #endregion

        #region 查询，分页查询用户数据信息
        /// <summary>
        ///  根据指定的范围，获取指定的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<UserInfoEntity> GetPageList(int start, int end)
        {
            //通过子查询来实现
            string sql = "select * from (select * , row_number() over( order by User_Id ) as num from User_Info ) as t " +
                         "where t.num >=@start and t.num<=@end";
            SqlParameter[] parameters =
            {
                new SqlParameter("@start", SqlDbType.Int),
                new SqlParameter("@end", SqlDbType.Int),
            };
            parameters[0].Value = start;
            parameters[1].Value = end;
            DataTable dataTable = SqlHelper.LJK_GetDataTable(sql, parameters);
            List<UserInfoEntity> userInfoEntitieList = null; ;
            if (dataTable.Rows.Count > 0)
            {
                userInfoEntitieList = new List<UserInfoEntity>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    UserInfoEntity userInfo = new UserInfoEntity();
                    LoadEntity(userInfo, dataRow);
                    userInfoEntitieList.Add(userInfo);
                }
            }
            return userInfoEntitieList;
        }
        #endregion

        #region 获取总的记录数
        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count (*) from User_Info";
            object executeScalar = SqlHelper.ExecuteScalar(sql, CommandType.Text);
            return Convert.ToInt32(executeScalar);
        }
        #endregion
    }
}
