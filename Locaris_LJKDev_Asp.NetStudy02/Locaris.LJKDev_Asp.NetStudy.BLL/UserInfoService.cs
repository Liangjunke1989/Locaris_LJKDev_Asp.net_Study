using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Locaris.LJKDev_Asp.NetStudy.DAL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.BLL
{
    public partial class UserInfoService
    {
        private UserInfoDal userInfoDal;

        public UserInfoService()
        {
            userInfoDal = new UserInfoDal();
        }

        #region 查询
        /// <summary>
        /// 查询展示所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfoEntity> GetUserInfoList()
        {
            return userInfoDal.GetUserInfoList();
        }
        #endregion

        #region 增加
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="userInfoEntity"></param>
        /// <returns></returns>
        public bool AddUserInfo(UserInfoEntity userInfoEntity)
        {
            return userInfoDal.InsertUserInfo(userInfoEntity) > 0;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool RemoveUserInfo(int userId)
        {
            return userInfoDal.DeleteUserInfo(userId) > 0;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据用户对象删除用户信息
        /// </summary>
        /// <param name="userInfo">用户对象</param>
        /// <returns></returns>
        public bool RemoveUserInfo(UserInfoEntity userInfo)
        {
            return userInfoDal.DeleteUserInfo(userInfo.UserId) > 0;
        }

        #endregion

        #region 根据Id，查询单条用户信息
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfoEntity GetUserInfoByUserId(int userId)
        {
            return userInfoDal.GetUserInfoEntity(userId);
        }


        #endregion

        #region 根据Name，查询用户信息
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        public UserInfoEntity GetUserInfoByUserName(string userName)
        {
            return userInfoDal.GetUserInfoEntity(userName);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改用户信息，用户id不变
        /// </summary>
        /// <param name="userInfoEntity"></param>
        /// <returns></returns>
        public bool EditUserInfo(UserInfoEntity userInfoEntity)
        {
            return userInfoDal.EditUserInfo(userInfoEntity) > 0;
        }
        #endregion

        #region 分页查询
        /// <summary>
        /// 获取数据的范围，完成分页
        /// </summary>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="pageSize">每页显示的记录数据</param>
        /// <returns></returns>
        public List<UserInfoEntity> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return userInfoDal.GetPageList(start, end);
        }
        #endregion

        #region 获取总的记录数
        /// <summary>
        /// 获取总的页数，根据数据库的数据可以分多少页
        /// </summary>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recoredCount = userInfoDal.GetRecordCount();//获取总的记录数
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recoredCount / pageSize));
            return pageCount;
        }

        public int GetRecordCount()
        {
            return userInfoDal.GetRecordCount();//获取总的记录数
        }
        #endregion

        #region 通过用户名查询用户信息，完成用户信息的校验
        /// <summary>
        /// 完成用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">用户密码</param>
        /// <param name="msg">登录信息</param>
        /// <param name="userInfo">登录用户的信息</param>
        public bool ValidateUserInfo(string userName, string userPwd, out string msg, out UserInfoEntity userInfo)
        {
            //01_通过用户名查询用户信息！
            userInfo = userInfoDal.GetUserInfoEntity(userName);
            //02_01如果查询有用户信息
            if (userInfo != null)
            {
                //02_01_01如果查询有用户信息,比较输入的用户密码和数据库中的用户密码是否一致，如果一致的话，执行
                if (userInfo.UserPwd.Equals(userPwd))
                {
                    msg = "登录成功！！";
                    return true;
                }
                //02_01_02如果不一致的话，执行
                else
                {
                    msg = "用户名/密码错误！！";
                    return false;
                }
            }
            //02_02如果查询没有用户信息
            else
            {
                msg = "未查询出此用户！！";
                return false;
            }
        }
        #endregion


        #region 获取ListView的分页
        /// <summary>
        /// 获取ListView的分页数据
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<UserInfoEntity> GetPageListView(int startRowIndex, int maximumRows)
        {
            return userInfoDal.GetPageListView(startRowIndex, maximumRows);
        }
        #endregion
    }
}
