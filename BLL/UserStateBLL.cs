using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class UserStateBLL
    {
        public UserState GetUserState(UserInfo user)
        {
            return new UserStateDAL().GetUserState(user);
        }
    }
}
