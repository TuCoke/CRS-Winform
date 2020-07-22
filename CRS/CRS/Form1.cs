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
        /// <summary>
        /// 传递当前用户注册完成后的卡号
        /// </summary>
        /// <param name="str"></param>
        public Form1(string str)
        {
            InitializeComponent();
            textBox1.Text = str;
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
        /// <summary>
        /// 用户点击登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //1、显示index窗体  2、传递当前用户卡号到index窗体
                Index home = new Index(this.textBox1.Text);
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
        /// <summary>
        /// 点击显示注册窗体，隐藏登录窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registered_Click(object sender, EventArgs e)
        {
            Registered regist = new Registered();
            regist.Owner = this;
            regist.Show();
            this.Hide();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
    }
}
