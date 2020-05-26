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
 public List<UserInfo> GetUserInfoList()
        {
            string sql = "select * from User_Info";
            CommandType type = CommandType.Text;
            DataTable dataTable = SqlHelper.LJK_GetDataTable(sql, type);
            List<UserInfo> userInfoList = null;
            if (dataTable.Rows.Count>0)
            {
                userInfoList=new List<UserInfo>();
                UserInfo userInfo=null;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    userInfo=new UserInfo();
                    LoadEntity(userInfo,dataRow);
                    userInfoList.Add(userInfo);
                }
            }
            return userInfoList;
        }

        private void LoadEntity(UserInfo userInfo, DataRow dataRow)
        {

            userInfo.UserId = int.Parse(dataRow["User_Id"].ToString());
            userInfo.UserAge = dataRow["User_Age"] != DBNull.Value 
                ? int.Parse(dataRow["User_Age"].ToString()) : 0;
            userInfo.UserName = dataRow["User_Name"]!=DBNull.Value
                ?dataRow["User_Name"].ToString():string.Empty;
            userInfo.UserPwd = dataRow["User_Pwd"] != DBNull.Value
                ? dataRow["User_Pwd"].ToString() :string.Empty;

        }
 #endregion

        #region 添加用户信息
//添加用户数据
        public int InsertUserInfo(UserInfo userInfo)
        {
            string sql = "insert into User_Info(User_Name,User_Age,User_Pwd)values(@UserName,@UserAge,@UserPwd)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserName", userInfo.UserName),
                new SqlParameter("@UserAge", userInfo.UserAge),
                new SqlParameter("@UserPwd", userInfo.UserPwd),
            };
            return SqlHelper.LJK_ExecuteNonQuery(sql, CommandType.Text, parameters);
        }
        #endregion

        public int DeleteUserInfo(int userId)
        {
            string sql = "delete from User_Info where User_Id=@UserId";
            SqlParameter parameter=new SqlParameter("@UserId",userId);
            return SqlHelper.LJK_ExecuteNonQuery(sql,CommandType.Text, parameter);
        }
    }
}
