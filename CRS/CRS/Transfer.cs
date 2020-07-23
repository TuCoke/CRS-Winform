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
    public partial class Transfer : Form
    {
        BankBLL bankbll = new BankBLL();
        RecordingBLL recordingbll = new RecordingBLL();
        public Transfer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 卡号
        /// </summary>
        /// <param name="usernumber"></param>
        public Transfer(string usernumber)
        {
            InitializeComponent();
            label3.Text = usernumber;
        }
        /// <summary>
        /// 转账提示输入当前用户密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //1、首先验证转账的账号是否存在
            string otherNumbers = otherNumber.Text.ToString();
            bool result = bankbll.Transfer(otherNumbers);
            if (result!=true)
            {
                MessageBox.Show("转账卡号不存在，请重新输入！");
                this.otherNumber.Text = "";
            }
            else
            {
                //2、如果账号存在需要当前用户输入 支付密码 把当前输入的卡号
                //和密码都传递到ConfirmPwd 窗体
                int Numbers =Convert.ToInt32(Number.Text);
                if (Numbers<=0)
                {
                    MessageBox.Show("转账金额必须大于0！");
                }
                else
                {
                 string usernumber =label3.Text ; //当前用户卡号
                 ConfirmPwd confirmPwd = new ConfirmPwd(otherNumber.Text,Number.Text, usernumber);
                 confirmPwd.Owner = this;
                 confirmPwd.Show();
                 this.Hide();
                }
            }
        }
        /// <summary>
        /// 退出转账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
