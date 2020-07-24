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
    public partial class ConfirmPwd : Form
    {
        BankBLL bankbll = new BankBLL();
        RecordingBLL recordingbll = new RecordingBLL();
        public ConfirmPwd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 转账的卡号和转账的金额
        /// </summary>
        /// <param name="Card_Number"></param>
        /// <param name="Number"></param>
        public ConfirmPwd(string Card_Number,string Number,string userNumber)
        {
            InitializeComponent();
            label2.Text = Card_Number; //转账的卡号
            label3.Text = Number; //转账的金额
            label4.Text = userNumber;  //当前用户卡号
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 当前用户输入确认密码执行转账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //1、用户输入的密码
            string UserPwd = textBox1.Text;
            string usernumber = label4.Text;
            bool result = bankbll.VerifyPwd(usernumber, UserPwd);
            //2、如果返回true表示当前用户输入密码正确
            if (result!=true)
            {
                MessageBox.Show("密码输入错误，请重新输入");
                this.textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("操作进行中");
            //1、判断当前用户余额
            string usercard = label4.Text;
            string resutl3 = bankbll.UserBalance(usercard);
            int resu =Convert.ToInt32(resutl3);
            int TransferNumber = Convert.ToInt32(label3.Text);
                //1、1判断当前用户的余额是否小于转账金额
                if (resu > TransferNumber)
                {
                //2、当前用户余额减去转账的数字
                int TotalNumber = resu - TransferNumber;
                //1、延迟两秒执行用户转账

                //2、先把当前卡号下的余额减去转走的金额 Number
                 bool result2 = bankbll.TransferBalance(usernumber,TotalNumber.ToString());
                //3、查询转账的账号中的余额
                string result4 = bankbll.TransferBalances(label2.Text.ToString());
                //3.1转账的账号余额
                int TranNumber = Convert.ToInt32(result4) + TransferNumber;
                //3.2 修改转账目标的余额 
                bool result5 = bankbll.TransferBalancesSuccess(label2.Text.ToString(), TranNumber.ToString());
                if (result5 != true)
                {
                    MessageBox.Show("转账失败，请重新尝试！");
                }
                else
                {
                    MessageBox.Show("转账成功！");
                    //4、如果转账插入操作记录表
                    RecordingInfo recordingInfo = new RecordingInfo();
                    recordingInfo.Timet = DateTime.Now.ToString();
                    recordingInfo.Details = ""+usernumber+ "转账:"+ TransferNumber.ToString()+ "元，到账号:"+ label2.Text.ToString()+"";
                    recordingInfo.Card_Number = label4.Text.ToString();
                    bool resultTransfer = recordingbll.TransferRecord(recordingInfo);
                    if (resultTransfer==true)
                    {
                        this.Owner.Show();
                        this.Close();

                    }
                }

                }
                else
                {
                    MessageBox.Show("转账失败，你的余额不足");
                }
            }
        }
    }
}
