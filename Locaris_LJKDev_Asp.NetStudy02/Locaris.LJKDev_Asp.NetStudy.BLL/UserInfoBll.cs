using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Locaris.LJKDev_Asp.NetStudy.DAL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.BLL
{
    public partial class UserInfoBll
    {
        private UserInfoDal userInfoDal;

        public UserInfoBll()
        {
            userInfoDal=new UserInfoDal();
        }

        public  List<UserInfo> GetUserInfoList()
        {
            return userInfoDal.GetUserInfoList();
        }

        public bool AddUserInfo(UserInfo userInfo)
        {
            return userInfoDal.InsertUserInfo(userInfo)>0;
        }

        public bool RemoveUserInfo(int userId)
        {
            return userInfoDal.DeleteUserInfo(userId) > 0;
        }

    }
}
