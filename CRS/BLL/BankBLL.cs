using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BankBLL
    {
        BankDAL bankdal = new BankDAL();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UserLogin(UserInfo userInfo)
        {
            bool result = bankdal.UserLogin(userInfo);
            return result;
        }
        public bool RegistNumber(string Card_Number)
        {
            bool result = bankdal.RegistNumber(Card_Number);
            return result;
        }
    }
}
