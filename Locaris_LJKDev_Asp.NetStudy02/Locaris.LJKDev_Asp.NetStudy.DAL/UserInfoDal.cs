﻿using System;
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


    }
}
