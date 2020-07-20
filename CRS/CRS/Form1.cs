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
    public partial class Form1 : Form
    {
        BankBLL bankbll = new BankBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// 动态文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string pwd = password.Text;
            //实例化model user
            UserInfo userInfo = new UserInfo();
            userInfo.Card_Number = name;
            userInfo.Card_Password = pwd;
            bool result = bankbll.UserLogin(userInfo);
            if (result == true)
            {
                MessageBox.Show("登录成功！");
                //显示index窗体
                Index home = new Index();
                home.Owner = this;
                home.Show();
                //隐藏当前窗体
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户或密码错误请重新输入！");
                this.textBox1.Text = "";
                this.password.Text = "";
            }
        }

        private void Registered_Click(object sender, EventArgs e)
        {
            Registered regist = new Registered();
            regist.Owner = this;
            regist.Show();
            this.Hide();
        }
    }
}
