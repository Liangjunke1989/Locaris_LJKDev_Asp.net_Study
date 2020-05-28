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
            userInfoDal=new UserInfoDal();
        }

        public  List<UserInfoEntity> GetUserInfoList()
        {
            return userInfoDal.GetUserInfoList();
        }

        public bool AddUserInfo(UserInfoEntity userInfoEntity)
        {
            return userInfoDal.InsertUserInfo(userInfoEntity)>0;
        }

        public bool RemoveUserInfo(int userId)
        {
            return userInfoDal.DeleteUserInfo(userId) > 0;
        }

        public UserInfoEntity GetUserInfoByUserId(int userId)
        {
            return userInfoDal.GetUserInfoEntity(userId);
        }

        public bool EditUserInfo(UserInfoEntity userInfoEntity)
        {
            return userInfoDal.EditUserInfo(userInfoEntity)>0;
        }

    }
}
