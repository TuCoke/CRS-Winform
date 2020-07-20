using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Model; //引入model

namespace DAL
{
   public class BankDAL
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool UserLogin(UserInfo userInfo)
        {

                //拼接sql语句
                string constr = @"server=(localdb)\MSSQLLocalDB;database=Bank;uid=sa;pwd=123456";//sql server身份验证
                SqlConnection conn = new SqlConnection(constr);
                //打开数据库对象
                conn.Open();
                //查询是否
                String sql = String.Format(@"Select * from [User] where Card_Number={0} and Card_Password={1}", userInfo.Card_Number, userInfo.Card_Password);
                SqlCommand cmd = new SqlCommand(sql, conn);
              //查询的对象对应ID
              int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
              if (rs>=0)
              {
                conn.Close();
                return true;
              }
              //关闭连接
                conn.Close();
                return false;
       }
        /// <summary>
        /// 用户开卡检测卡号是否存在
        /// </summary>
        /// <param name="Card_Number">当前传递卡号</param>
        /// <returns></returns>
        public bool RegistNumber(string Card_Number)
        {
            //拼接sql语句
            string constr = @"server=(localdb)\MSSQLLocalDB;database=Bank;uid=sa;pwd=123456";//sql server身份验证
            SqlConnection conn = new SqlConnection(constr);
            //打开数据库对象
            conn.Open();
            String sql = String.Format(@"select * from [User] where Card_Number={0}", Card_Number);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //查询的对象对应ID
            int rs = cmd.ExecuteNonQuery();
            if (rs >= 0)
            {
                conn.Close();
                return true;
            }
            //关闭连接
            conn.Close();
            return false;
        }


    }
}
