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
    public partial class Deposit : Form
    {
        BankBLL bankbll = new BankBLL();
        RecordingBLL recordingbll = new RecordingBLL();
        public Deposit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取当前存入用户的卡号
        /// </summary>
        public Deposit(string usernumber)
        {
            InitializeComponent();
            //传递当前登录卡号
            label2.Text = usernumber;
        }
        private void Withdrawal_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 用户存入金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //1、检查当前用户卡号
            UserInfo userInfo = new UserInfo();
            //userInfo.Card_Number = label2.Text.ToString();
            //userInfo.Amount_Number= Amount.Text.ToString();
            string Card_Number = label2.Text.ToString();
            string Amount_Number = Amount.Text.ToString();
            //2、获取存入金额加上原有金额
            string result = bankbll.AmountNumbers(Card_Number, Amount_Number);
            if (result!=null)
            {
                //3、重新修改用户金额,存入后的金额加上用户之前的金额
                userInfo.Card_Number = label2.Text.ToString();
                userInfo.Amount_Number = result;
                bool result2 = bankbll.AmountNumber(userInfo);
                if (result2 == true)
                {
                    //4、如果存入金额成功则存入记录表
                    RecordingInfo recordingInfo = new RecordingInfo();
                    recordingInfo.Timet = DateTime.Now.ToString();
                    recordingInfo.Details = "存款" + Amount.Text.ToString() + "金额";
                    recordingInfo.Card_Number = sum().ToString();
                    bool record = recordingbll.Deposit(recordingInfo);
                    MessageBox.Show("存款:'"+ Amount.Text.ToString() + "'成功");
                    this.Owner.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("存款失败，请重新输入");
                }
            }
        }
        /// <summary>
        /// 退出存入金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
        /// <summary>
        /// 当前用户卡号
        /// </summary>
        /// <returns></returns>
        public string sum()
        {
            string number = label2.Text;
            return number;
        }
    }
}
