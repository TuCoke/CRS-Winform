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
        /// <summary>
        /// 用户查询余额
        /// </summary>
        /// <param name="Card_Number">用户卡号</param>
        /// <returns></returns>
        public string Balance(string Card_Number)
        {
            string result = bankdal.Balance(Card_Number);
            return result;
        }
        /// <summary>
        /// 获取当前取款
        /// </summary>
        /// <param name="Card_Number"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public int Withdrawal(string Card_Number, int number)
        {
            int result = bankdal.Withdrawal(Card_Number, number);
            return result;
        }
        /// <summary>
        /// 获取用户取款后的值
        /// </summary>
        /// <param name="Card_Number">卡号</param>
        /// <param name="SumNumber">余额</param>
        /// <returns></returns>
        public bool Withdrawals(string Card_Number, int SumNumber)
        {
            bool result = bankdal.Withdrawals(Card_Number, SumNumber);
            return result;
        }
        /// <summary>
        /// 转账验证用户输入的转账卡号是否存中
        /// </summary>
        /// <param name="otherNumbers"></param>
        /// <returns></returns>
        public bool Transfer(string otherNumbers)
        {
            return bankdal.Transfer(otherNumbers);
        }
        /// <summary>
        /// 验证当前用户输入的确认转账的密码是否正确
        /// </summary>
        /// <param name="Card_Number">卡号</param>
        /// <param name="UserPwd">密码</param>
        /// <returns></returns>
        public bool VerifyPwd(string Card_Number, string UserPwd)
        {

            return bankdal.VerifyPwd(Card_Number, UserPwd);
        }
        /// <summary>
        /// 用户转账之前的余额
        /// </summary>
        /// <param name="usercard"></param>
        /// <returns></returns>
        public string UserBalance(string usercard)
        {
            return bankdal.UserBalance(usercard);
           // return result;
        }
        /// <summary>
        /// 用户转账完毕后的余额
        /// </summary>
        /// <param name="Card_Number"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool TransferBalance(string Card_Number, string TotalNumber)
        {
            return bankdal.TransferBalance(Card_Number, TotalNumber);
        }
        /// <summary>
        /// 查询转账目标卡号的余额
        /// </summary>
        /// <param name="Card_Number">卡号</param>
        /// <returns></returns>
        public string TransferBalances(string Card_Number)
        {
            return bankdal.TransferBalances(Card_Number);
        }
        /// <summary>
        /// 转账目标修改余额，转账成功
        /// </summary>
        /// <param name="Card_Number">转账目标卡号</param>
        /// <param name="Number">金额</param>
        /// <returns></returns>
        public bool TransferBalancesSuccess(string Card_Number,string Number)
        {
            return bankdal.TransferBalancesSuccess(Card_Number, Number);
        }

    }
}
