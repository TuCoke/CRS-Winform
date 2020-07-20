using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS
{
    public partial class Registered : Form
    {
        public Registered()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击产生随机卡号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Change_Click(object sender, EventArgs e)
        {

            Random rand = new Random();
            long randnum = (long)(rand.NextDouble() * 10000000000);
            RegistName.Text = randnum.ToString();
            
        }

        private void Back_Login_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void RegistName_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 窗体加载时产生随机数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registered_Load(object sender, EventArgs e)
        {

            Random rand = new Random();
            long randnum = (long)(rand.NextDouble() * 10000000000);
            RegistName.Text = randnum.ToString();
            //1、验证数据库是否存在当前生成的卡号
            UserInfo userInfo = new UserInfo();
            userInfo.Card_Number = this.RegistName.Text.ToString();
            //2、调用BLL
            BankBLL bankbll = new BankBLL();
            bool result = bankbll.RegistNumber(userInfo.Card_Number);
            if (result!=false)
            {
                //如果返回true证明存在当前生成的卡号，则需要重新给当前账号，随机生成一个其他账号
               this.RegistName.Text = randnum.ToString();

            }
            else
            {

            }
        }
    }
}
