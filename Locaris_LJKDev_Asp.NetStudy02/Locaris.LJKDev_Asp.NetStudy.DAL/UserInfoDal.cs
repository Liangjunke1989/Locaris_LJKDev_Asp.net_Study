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
            CommandType type = CommandType.Text;
            DataTable dataTable = SqlHelper.LJK_GetDataTable(sql, type);
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
    }
}
