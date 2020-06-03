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
        /// 获取总的页数
        /// </summary>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recoredCount = userInfoDal.GetRecordCount();//获取总的记录数
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recoredCount / pageSize));
            return pageCount;
        }
        #endregion

    }
}
