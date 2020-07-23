using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class RecordingBLL
    {
        RecordingDAL recording = new RecordingDAL();
        /// <summary>
        /// 用户取款记录
        /// </summary>
        /// <param name="recordingInfo"></param>
        /// <returns></returns>
        public bool WithdrawalRecord(RecordingInfo recordingInfo)
        {
            return recording.WithdrawalRecord(recordingInfo);
        }
        /// <summary>
        /// 用户查询操作记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUser(string Card_Number)
        {
            return recording.SelectUser(Card_Number);
        }
        /// <summary>
        /// 用户存入金额记录
        /// </summary>
        /// <returns></returns>
        public bool Deposit(RecordingInfo recordingInfo)
        {
            return recording.Deposit(recordingInfo);
        }
        /// <summary>
        /// 转账成功记录操作
        /// </summary>
        /// <param name="recordingInfo"></param>
        /// <returns></returns>
        public bool TransferRecord(RecordingInfo recordingInfo)
        {
            return recording.TransferRecord(recordingInfo);
        }
    }
}
