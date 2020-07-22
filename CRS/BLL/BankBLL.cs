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
        /// <summary>
        /// 检测用户是否重复卡号
        /// </summary>
        /// <param name="Card_Number"></param>
        /// <returns></returns>
        public bool RegistNumber(string Card_Number)
        {
            bool result = bankdal.RegistNumber(Card_Number);
            return result;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userInfo1">卡号和密码</param>
        /// <returns></returns>
        public bool UserRegist(UserInfo userInfo1)
        {
            bool result = bankdal.UserRegist(userInfo1);
            return result;
        }
        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="Card_Number">当前用户卡号</param>
        /// <returns></returns>
        public bool UserNumber(UserInfo userInfo)
        {
            bool result = bankdal.UserNumber(userInfo);
            return result;
        }
        /// <summary>
        /// 验证用户输入的旧密码
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UseroldPwd(UserInfo userInfo)
        {
            bool result = bankdal.UseroldPwd(userInfo);
            return result;
        }
        /// <summary>
        /// 用户存入金额
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string AmountNumbers(string Card_Number, string Amount_Number)
        {
            string result = bankdal.AmountNumbers(Card_Number,Amount_Number);
            return result;
        }
        /// <summary>
        /// 用户存入的金额和已存的金额相加
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool AmountNumber(UserInfo userInfo)
        {
            bool result = bankdal.AmountNumber(userInfo);
            return result;
        }
    }
}
