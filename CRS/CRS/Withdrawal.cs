using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace CRS
{
    public partial class Withdrawal : Form
    {
        BankBLL bankbll = new BankBLL();
        
        RecordingBLL recordingbll = new RecordingBLL();
        public Withdrawal()
        {
            InitializeComponent();
        }
        public Withdrawal(string usernumber)
        {
            InitializeComponent();
            //传递当前登录卡号
            label1.Text = usernumber;
        }
        /// <summary>
        /// 退出取款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Withdrawal_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 卡号
        /// </summary>
        /// <returns></returns>
        public string sum()
        {
            string number= label1.Text ;
            return number;
        }
        /// <summary>
        /// 50
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            int number =Convert.ToInt32(btn1.Text);
            number = 50;
            //返回用户当前总余额
            int usernum= bankbll.Withdrawal(sum(), number);
            if (usernum>=0)
            {
                int SumNumber = usernum - number;
                if (SumNumber<0)
                {
                    MessageBox.Show("取款失败，卡内余额不足！");

                }
                else
                {
                    bool usernumber = bankbll.Withdrawals(sum(), SumNumber);
                    if (usernumber == true)
                    {
                        //1、用户表记录
                        string time = DateTime.Now.ToString();
                        //2、如果操作成功则在记录表中记录当前卡号的操作
                        RecordingInfo recordingInfo = new RecordingInfo();
                        recordingInfo.Timet = time;
                        recordingInfo.Details = "取款"+ number.ToString()+ "金额";
                        recordingInfo.Card_Number = sum().ToString();
                        bool record = recordingbll.WithdrawalRecord(recordingInfo);
                        MessageBox.Show("取款:" + number.ToString() + "取款时间：" + time + "成功");
                    }
                }
            }
        }
        /// <summary>
        /// 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(btn1.Text);
            number = 100;
            //返回用户当前总余额
            int usernum = bankbll.Withdrawal(sum(), number);
            if (usernum >= 0)
            {
                int SumNumber = usernum - number;
                if (SumNumber < 0)
                {
                    MessageBox.Show("取款失败，卡内余额不足！");

                }
                else
                {
                    bool usernumber = bankbll.Withdrawals(sum(), SumNumber);
                    if (usernumber == true)
                    {
                        //1、用户表记录
                        string time = DateTime.Now.ToString();
                        //2、如果操作成功则在记录表中记录当前卡号的操作
                        RecordingInfo recordingInfo = new RecordingInfo();
                        recordingInfo.Timet = time;
                        recordingInfo.Details = "取款" + number.ToString() + "金额";
                        recordingInfo.Card_Number = sum().ToString();
                        bool record = recordingbll.WithdrawalRecord(recordingInfo);
                        MessageBox.Show("取款:" + number.ToString() + "取款时间：" + time + "成功");
                    }
                }
            }

        }
        /// <summary>
        /// 500
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn3_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(btn1.Text);
            number = 500;
            //返回用户当前总余额
            int usernum = bankbll.Withdrawal(sum(), number);
            if (usernum >= 0)
            {
                int SumNumber = usernum - number;
                if (SumNumber < 0)
                {
                    MessageBox.Show("取款失败，卡内余额不足！");

                }
                else
                {
                    bool usernumber = bankbll.Withdrawals(sum(), SumNumber);
                    if (usernumber == true)
                    {
                        //1、用户表记录
                        string time = DateTime.Now.ToString();
                        //2、如果操作成功则在记录表中记录当前卡号的操作
                        RecordingInfo recordingInfo = new RecordingInfo();
                        recordingInfo.Timet = time;
                        recordingInfo.Details = "取款" + number.ToString() + "金额";
                        recordingInfo.Card_Number = sum().ToString();
                        bool record = recordingbll.WithdrawalRecord(recordingInfo);
                        MessageBox.Show("取款:" + number.ToString() + "取款时间：" + time + "成功");
                    }
                }
            }
        }
        /// <summary>
        /// 1000
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn4_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(btn1.Text);
            number = 1000;
            //返回用户当前总余额
            int usernum = bankbll.Withdrawal(sum(), number);
            if (usernum >= 0)
            {
                int SumNumber = usernum - number;
                if (SumNumber < 0)
                {
                    MessageBox.Show("取款失败，卡内余额不足！");

                }
                else
                {
                    bool usernumber = bankbll.Withdrawals(sum(), SumNumber);
                    if (usernumber == true)
                    {
                        //1、用户表记录
                        string time = DateTime.Now.ToString();
                        //2、如果操作成功则在记录表中记录当前卡号的操作
                        RecordingInfo recordingInfo = new RecordingInfo();
                        recordingInfo.Timet = time;
                        recordingInfo.Details = "取款" + number.ToString() + "金额";
                        recordingInfo.Card_Number = sum().ToString();
                        bool record = recordingbll.WithdrawalRecord(recordingInfo);
                        MessageBox.Show("取款:" + number.ToString() + "取款时间：" + time + "成功");
                    }
                }
            }
        }
        /// <summary>
        /// 3000
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn5_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(btn1.Text);
            number = 3000;
            //返回用户当前总余额
            int usernum = bankbll.Withdrawal(sum(), number);
            if (usernum >= 0)
            {
                int SumNumber = usernum - number;
                if (SumNumber < 0)
                {
                    MessageBox.Show("取款失败，卡内余额不足！");

                }
                else
                {
                    bool usernumber = bankbll.Withdrawals(sum(), SumNumber);
                    if (usernumber == true)
                    {
                        //1、用户表记录
                        string time = DateTime.Now.ToString();
                        //2、如果操作成功则在记录表中记录当前卡号的操作
                        RecordingInfo recordingInfo = new RecordingInfo();
                        recordingInfo.Timet = time;
                        recordingInfo.Details = "取款" + number.ToString() + "金额";
                        recordingInfo.Card_Number = sum().ToString();
                        bool record = recordingbll.WithdrawalRecord(recordingInfo);
                        MessageBox.Show("取款:" + number.ToString() + "取款时间：" + time + "成功");
                    }
                }
            }
        }
        /// <summary>
        /// 5000
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn6_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(btn1.Text);
            number = 5000;
            //返回用户当前总余额
            int usernum = bankbll.Withdrawal(sum(), number);
            if (usernum >= 0)
            {
                int SumNumber = usernum - number;
                if (SumNumber < 0)
                {
                    MessageBox.Show("取款失败，卡内余额不足！");

                }
                else
                {
                    bool usernumber = bankbll.Withdrawals(sum(), SumNumber);
                    if (usernumber == true)
                    {
                        //1、用户表记录
                        string time = DateTime.Now.ToString();
                        //2、如果操作成功则在记录表中记录当前卡号的操作
                        RecordingInfo recordingInfo = new RecordingInfo();
                        recordingInfo.Timet = time;
                        recordingInfo.Details = "取款" + number.ToString() + "金额";
                        recordingInfo.Card_Number = sum().ToString();
                        bool record = recordingbll.WithdrawalRecord(recordingInfo);
                        MessageBox.Show("取款:" + number.ToString() + "取款时间：" + time + "成功");
                    }
                }
            }
        }

    }
}
