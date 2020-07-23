using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Model; //引入model
using System.Security.Cryptography;

namespace DAL
{
   public class BankDAL
    {
        /// <summary>
        /// sql连接
        /// </summary>
        /// <returns></returns>
        public string GetSqlConnectionString()
        {
            string constr = @"server=(localdb)\MSSQLLocalDB;database=Banks;uid=sa;pwd=123456";//sql server身份验证
            return constr;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UserLogin(UserInfo userInfo)
        {
            try
            {
                //1、拼接sql语句
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            #region Md5验证加密后是否一致
            //2.1 加密用户的密码
            //2.2  创建Md5
            MD5 md5 = MD5.Create();
            //1、将字符串转换成字节数组
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(userInfo.Card_Password);
            //2、加密完后的字节数组
            byte[] md5buffer = md5.ComputeHash(buffer);
            //3、循环转换数组
            string strNew = "";
            for (int i = 0; i < md5buffer.Length; i++)
            {
                //Tostring("X")转换为16进制 
                strNew += md5buffer[i].ToString("x");
            }
            #endregion
            //2、查询是否存在当前用户
            String sql = String.Format("select * from [User] where Card_Number='{0}'AND Card_Password='{1}'", userInfo.Card_Number, strNew);
            //String sql = String.Format(@"Select * from [User] where Card_Number={0} and Card_Password={1}", userInfo.Card_Number, strNew.ToString());
                SqlCommand cmd = new SqlCommand(sql, conn);
              //3、打开数据库对象
              conn.Open();
                //4、
                //int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //string rs = cmd.ExecuteScalar().ToString();
                // int rs = cmd.ExecuteNonQuery();
                object rs = cmd.ExecuteScalar();
                if (rs != null)
              {
                conn.Close();
                return true;
              }
              //关闭连接
                conn.Close();
                return false;

            }
            catch (Exception)
            {
                
                return false;
            }
        }
        /// <summary>
        /// 用户开卡检测卡号是否存在
        /// </summary>
        /// <param name="Card_Number">当前传递卡号</param>
        /// <returns></returns>
        public bool RegistNumber(string Card_Number)
        {
            try
            {
            //1、拼接sql语句
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //String sql = String.Format(@"select * from [User] where Card_Number="'+'Card_Number'+');
            string sql = "select * from [User] where Card_Number='"+Card_Number+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //2、打开数据库对象
            conn.Open();
            //4、返回
            // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            object rs = cmd.ExecuteScalar();
            if (rs !=null)
            {
                conn.Close();
                return true;
            }
            //关闭连接
            conn.Close();
            return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userInfo1">卡号和密码</param>
        /// <returns></returns>
        public bool UserRegist(UserInfo userInfo1)
        {
            try
            {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            conn.Open();
            //2、用户注册默认金额为0；
            userInfo1.Amount_Number = "0";
            #region Md5加密用户密码
            //2.1 加密用户的密码
            //2.2  创建Md5
            MD5 md5 = MD5.Create();
            //1、将字符串转换成字节数组
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(userInfo1.Card_Password);
            //2、加密完后的字节数组
            byte[] md5buffer = md5.ComputeHash(buffer);
            //3、循环转换数组
            string strNew = "";
            for (int i = 0; i < md5buffer.Length; i++)
            {
                //Tostring("X")转换为16进制 
                strNew += md5buffer[i].ToString("x");
            }
            #endregion
            String sql = String.Format("insert into [User] (Card_Number,Card_Password,Amount_Number) values('{0}','{1}','{2}')", userInfo1.Card_Number, strNew, userInfo1.Amount_Number);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //3、如果大于0表示执行成功
           //int a=Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (cmd.ExecuteNonQuery()>0)
            {
                conn.Close();
                return true;
            }
            //4、如果未成功也同时关闭
            conn.Close();
            return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="Card_Number"></param>
        /// <returns></returns>
        public bool UserNumber(UserInfo userInfo)
        {
            try
            {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            #region Md5加密用户密码
            //2.1 加密用户的密码
            //2.2  创建Md5
            MD5 md5 = MD5.Create();
            //1、将字符串转换成字节数组
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(userInfo.Card_Password);
            //2、加密完后的字节数组
            byte[] md5buffer = md5.ComputeHash(buffer);
            //3、循环转换数组
            string strNew = "";
            for (int i = 0; i < md5buffer.Length; i++)
            {
                //Tostring("X")转换为16进制 
                strNew += md5buffer[i].ToString("x");
            }
            #endregion
            String sql = String.Format("Update [User] set Card_Password='{0}' where Card_Number='{1}'", strNew, userInfo.Card_Number);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            //object rs = cmd.ExecuteScalar();
           // int rs = cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery()> 0)
            {
                conn.Close();
                return true;
            }
            //关闭连接
            conn.Close();
            return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 修改密码验证旧密码是否输入一致
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UseroldPwd(UserInfo userInfo1)
        {
            try
            {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            #region Md5加密用户密码
            //2.1 加密用户的密码
            //2.2  创建Md5
            MD5 md5 = MD5.Create();
            //1、将字符串转换成字节数组
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(userInfo1.Card_Password);
            //2、加密完后的字节数组
            byte[] md5buffer = md5.ComputeHash(buffer);
            //3、循环转换数组
            string strNew = "";
            for (int i = 0; i < md5buffer.Length; i++)
            {
                //Tostring("X")转换为16进制 
                strNew += md5buffer[i].ToString("x");
            }
            #endregion
            String sql = String.Format("Select * from [User] where Card_Number='{0}'AND Card_Password='{1}'",userInfo1.Card_Number, strNew);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
           object rs = cmd.ExecuteScalar();
            //如果rs等于-1 表示没有查询到，当前用户输入的密码为错误
            if (rs !=null)
            {
                conn.Close();
                return true;
            }
            //关闭连接
            conn.Close();
            return false;

            }
            catch (Exception)
            {

                return false;
            }

        }
        /// <summary>
        /// 用户存入金额
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool AmountNumber(UserInfo userInfo)
        {
            try
            {
                //AmountNumbers(Card_Number, Amount_Number);
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                //1、打开数据库对象
                //String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", userInfo.Amount_Number,userInfo.Card_Number);
                String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'",userInfo.Amount_Number, userInfo.Card_Number);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                object rss = cmd.ExecuteScalar();
                int rs = cmd.ExecuteNonQuery();
                //如果rs等于-1 表示没有查询到，当前用户输入的密码为错误
                if (cmd.ExecuteNonQuery()>0)
                {
                    conn.Close();
                    return true;
                }
                //关闭连接
                conn.Close();
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 获取当前用户存入的金额和之前的金额相加
        /// </summary>
        /// <param name="Card_Number">卡号</param>
        /// <param name="Amount_Number">存入的金额</param>
        /// <returns></returns>
        public string AmountNumbers(string Card_Number,string Amount_Number)
        {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            //String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", userInfo.Amount_Number,userInfo.Card_Number);
            String sql = String.Format("SELECT * FROM [User] where Card_Number='{0}'", Card_Number);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            object rss = cmd.ExecuteScalar();
            SqlDataReader datareader = cmd.ExecuteReader();
            List<string> listnew = new List<string>();
            while (datareader.Read())
            {
                //string a = datareader[2].ToString();
                //string AmountNumber2 = datareader["Amount_Number"].ToString();
                listnew.Add(datareader["Amount_Number"].ToString());
            }
            //当前用户没存入金额
            int aa =Convert.ToInt32(listnew.First());
            //前台输入的金额
            int number =Convert.ToInt32(Amount_Number);
            int sum = aa + number;
            return sum.ToString();
        }
        /// <summary>
        /// 用户查询余额
        /// </summary>
        /// <param name="Card_Number">卡号</param>
        /// <returns></returns>
        public string Balance(string Card_Number)
        {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            //String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", userInfo.Amount_Number,userInfo.Card_Number);
            String sql = String.Format("SELECT * FROM [User] where Card_Number='{0}'", Card_Number);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            object rss = cmd.ExecuteScalar();
            SqlDataReader datareader = cmd.ExecuteReader();
            List<string> listnew = new List<string>();
            while (datareader.Read())
            {
                //string a = datareader[2].ToString();
                //string AmountNumber2 = datareader["Amount_Number"].ToString();
                listnew.Add(datareader["Amount_Number"].ToString());
            }
            //当前用户没存入金额
            int aa = Convert.ToInt32(listnew.First());
            return  aa.ToString();
        }
        /// <summary>
        /// 用户取款返回一个int到前台计算
        /// </summary>
        /// <param name="Card_Number">卡号</param>
        /// <param name="number">余额</param>
        /// <returns></returns>
        public int Withdrawal(string Card_Number,int number)
        {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            //String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", userInfo.Amount_Number,userInfo.Card_Number);
            String sql = String.Format("SELECT * FROM [User] where Card_Number='{0}'", Card_Number);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            object rss = cmd.ExecuteScalar();
            SqlDataReader datareader = cmd.ExecuteReader();
            List<string> listnew = new List<string>();
            while (datareader.Read())
            {
                //string a = datareader[2].ToString();
                //string AmountNumber2 = datareader["Amount_Number"].ToString();
                listnew.Add(datareader["Amount_Number"].ToString());
            }
            //当前用户没存入金额
            int usnumber = Convert.ToInt32(listnew.First());
            return usnumber;
        }
        /// <summary>
        /// 用户取款后的值
        /// </summary>
        /// <returns></returns>
        public bool Withdrawals(string Card_Number,int SumNumber)
        {

            try
            {
                //AmountNumbers(Card_Number, Amount_Number);
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                //1、打开数据库对象
                //String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", userInfo.Amount_Number,userInfo.Card_Number);
                String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", SumNumber, Card_Number);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                object rss = cmd.ExecuteScalar();
                int rs = cmd.ExecuteNonQuery();
                //如果rs等于-1 表示没有查询到，当前用户输入的密码为错误
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                //关闭连接
                conn.Close();
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 转账验证用户输入的账号是否存在
        /// </summary>
        /// <returns></returns>
        public bool Transfer(string otherNumbers)
        {
            try
            {
                //1、拼接sql语句
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                //String sql = String.Format(@"select * from [User] where Card_Number="'+'Card_Number'+');
                string sql = "select * from [User] where Card_Number='" + otherNumbers + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //2、打开数据库对象
                conn.Open();
                //4、返回
                // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                object rs = cmd.ExecuteScalar();
                if (rs!=null)
                {
                    conn.Close();
                    return true;
                }
                //关闭连接
                conn.Close();
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 用户转账 确认输入密码
        /// </summary>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        public bool VerifyPwd(string Card_Number,string UserPwd)
        {
            try
            {
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                //1、打开数据库对象
                #region Md5加密用户密码
                //2.1 加密用户的密码
                //2.2  创建Md5
                MD5 md5 = MD5.Create();
                //1、将字符串转换成字节数组
                byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(UserPwd);
                //2、加密完后的字节数组
                byte[] md5buffer = md5.ComputeHash(buffer);
                //3、循环转换数组
                string strNew = "";
                for (int i = 0; i < md5buffer.Length; i++)
                {
                    //Tostring("X")转换为16进制 
                    strNew += md5buffer[i].ToString("x");
                }
                #endregion
                String sql = String.Format("Select * from [User] where Card_Number='{0}'AND Card_Password='{1}'",Card_Number, strNew);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                object rs = cmd.ExecuteScalar();
                //如果rs等于-1 表示没有查询到，当前用户输入的密码为错误
                if (rs != null)
                {
                    conn.Close();
                    return true;
                }
                //关闭连接
                conn.Close();
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 查询转账的当前用户的余额度
        /// </summary>
        /// <param name="usercard"></param>
        /// <returns></returns>
        public string UserBalance(string usercard)
        {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            //String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", userInfo.Amount_Number,userInfo.Card_Number);
            String sql = String.Format("SELECT * FROM [User] where Card_Number='{0}'", usercard);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            object rss = cmd.ExecuteScalar();
            SqlDataReader datareader = cmd.ExecuteReader();
            List<string> listnew = new List<string>();
            while (datareader.Read())
            {
                //string a = datareader[2].ToString();
                //string AmountNumber2 = datareader["Amount_Number"].ToString();
                listnew.Add(datareader["Amount_Number"].ToString());
            }
            //当前用户没存入金额
            int aa = Convert.ToInt32(listnew.First());
            return aa.ToString();
        }

        /// <summary>
        /// 用户转账完毕后修改余额
        /// </summary>
        /// <param name="Card_Number">卡号</param>
        /// <param name="TotalNumber">余额</param>
        /// <returns></returns>
        public bool TransferBalance(string Card_Number,string TotalNumber)
        {

            try
            {
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", TotalNumber, Card_Number);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int rs = cmd.ExecuteNonQuery();
                //如果rs等于-1 表示没有查询到，当前用户输入的密码为错误
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                //关闭连接
                conn.Close();
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 查询转账用户当前的余额
        /// </summary>
        /// <param name="Card_Number"></param>
        /// <returns></returns>
        public string TransferBalances(string Card_Number)
        {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //1、打开数据库对象
            //String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", userInfo.Amount_Number,userInfo.Card_Number);
            String sql = String.Format("SELECT * FROM [User] where Card_Number='{0}'", Card_Number);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            // int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            object rss = cmd.ExecuteScalar();
            SqlDataReader datareader = cmd.ExecuteReader();
            List<string> listnew = new List<string>();
            while (datareader.Read())
            {
                //string a = datareader[2].ToString();
                //string AmountNumber2 = datareader["Amount_Number"].ToString();
                listnew.Add(datareader["Amount_Number"].ToString());
            }
            //当前用户没存入金额
            int aa = Convert.ToInt32(listnew.First());
            return aa.ToString();
        }

        /// <summary>
        /// 转账目标修改余额，转账成功
        /// </summary>
        /// <param name="Card_Number">转账目标卡号</param>
        /// <param name="Number">金额</param>
        /// <returns></returns>
        public bool TransferBalancesSuccess(string Card_Number,string Number)
        {
            try
            {
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                String sql = String.Format("Update [User] set Amount_Number='{0}' where Card_Number='{1}'", Number, Card_Number);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int rs = cmd.ExecuteNonQuery();
                //如果rs等于-1 表示没有查询到，当前用户输入的密码为错误
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                //关闭连接
                conn.Close();
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
