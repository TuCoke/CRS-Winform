using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Model; //引入model;
using NPOI.SS.Formula.Functions;

namespace DAL
{
   public class RecordingDAL
    {
        /// <summary>
        /// 连接sql语句
        /// </summary>
        /// <returns></returns>
        public string GetSqlConnectionString()
        {
            string constr = @"server=(localdb)\MSSQLLocalDB;database=Banks;uid=sa;pwd=123456";//sql server身份验证
            return constr;
        }
        /// <summary>
        /// 取款记录
        /// </summary>
        /// <param name="recordingInfo"></param>
        /// <returns></returns>
        public bool WithdrawalRecord(RecordingInfo recordingInfo)
        {
            try
            {
                //1、拼接sql语句
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                //2、插入用户取款记录
                String sql = String.Format("insert into Recording(Timet,Details,Card_Number) values('{0}','{1}','{2}')", recordingInfo.Timet, recordingInfo.Details, recordingInfo.Card_Number);
                //String sql = String.Format(@"Select * from [User] where Card_Number={0} and Card_Password={1}", userInfo.Card_Number, strNew.ToString());
                SqlCommand cmd = new SqlCommand(sql, conn);
                //3、打开数据库对象
                conn.Open();
                //int rs = Convert.ToInt32(cmd.ExecuteScalar().ToString());
               //string rs = cmd.ExecuteScalar().ToString();
                 //int rs = cmd.ExecuteNonQuery();
               // object rs = cmd.ExecuteScalar();
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
        /// 查询当前用户操作记录
        /// </summary>
        /// <returns></returns>
        public DataTable SelectUser(string Card_Number)
        {
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());
            //2，实例化适配器对象
            String sql = String.Format("select * from Recording where Card_Number='{0}'", Card_Number);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            sda.Fill(ds);
            return ds.Tables[0];

        }
        /// <summary>
        /// 用户存入金额记录
        /// </summary>
        /// <param name="recordingInfo"></param>
        /// <returns></returns>
        public bool Deposit(RecordingInfo recordingInfo)
        {
            try
            {
                //1、拼接sql语句
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                //2、插入用户存入金额
                String sql = String.Format("insert into Recording(Timet,Details,Card_Number) values('{0}','{1}','{2}')", recordingInfo.Timet, recordingInfo.Details, recordingInfo.Card_Number);
                //String sql = String.Format(@"Select * from [User] where Card_Number={0} and Card_Password={1}", userInfo.Card_Number, strNew.ToString());
                SqlCommand cmd = new SqlCommand(sql, conn);
                //3、打开数据库对象
                conn.Open();
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
        /// 用户转账成功后记录
        /// </summary>
        /// <param name="recordingInfo"></param>
        /// <returns></returns>
        public bool TransferRecord(RecordingInfo recordingInfo)
        {
            try
            {
                //1、拼接sql语句
                SqlConnection conn = new SqlConnection(GetSqlConnectionString());
                //2、插入用户存入金额
                String sql = String.Format("insert into Recording(Timet,Details,Card_Number) values('{0}','{1}','{2}')", recordingInfo.Timet, recordingInfo.Details, recordingInfo.Card_Number);
                //String sql = String.Format(@"Select * from [User] where Card_Number={0} and Card_Password={1}", userInfo.Card_Number, strNew.ToString());
                SqlCommand cmd = new SqlCommand(sql, conn);
                //3、打开数据库对象
                conn.Open();
                //int rss = Convert.ToInt32(cmd.ExecuteScalar().ToString());
               // object rs = cmd.ExecuteScalar();
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
    }
}
