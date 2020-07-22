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

        }
        /// <summary>
        /// 点击退出返回login窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //调用生成卡号
            string account= CreateAccountNum();
            RegistName.Text = account;
           //RegistName.Text = "621288100105810458";
           //1、验证数据库是否存在当前生成的卡号
            UserInfo userInfo = new UserInfo();
            userInfo.Card_Number = this.RegistName.Text.ToString();
           //2、调用BLL
            BankBLL bankbll = new BankBLL();
            bool result = bankbll.RegistNumber(userInfo.Card_Number);
          //3、如果result返回true的结果，则重新调用生成卡号
            while (result!=false)
            {
                //2、重新验证卡号是否存在
                MessageBox.Show("已经存在卡号");
                account = CreateAccountNum();
                result = bankbll.RegistNumber(userInfo.Card_Number);
            }
        }
        /// <summary>
        /// 生成卡号
        /// </summary>
        /// <returns></returns>
        public string CreateAccountNum()
        {
            //生成卡号
            string account = "621288";
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                account += rand.Next(0, 11);
            }
            return account;
        }
        /// <summary>
        /// 注册完成关闭注册窗体，返回Login窗体，并传递注册后的卡号到login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //获取用户注册的账号和密码
            if (registRpwd.Text != registpwd.Text)
            {
                MessageBox.Show("两次密码输入不一致！请重新输入！");
                registpwd.Text = "";
                registRpwd.Text = "";
            }
            else
            {
                BankBLL bankbll = new BankBLL();
                UserInfo userInfo1 = new UserInfo();
                userInfo1.Card_Number = this.RegistName.Text.ToString();
                userInfo1.Card_Password = this.registpwd.Text.ToString();
                //返回true表示注册成功，false表示注册失败
                bool result= bankbll.UserRegist(userInfo1);
                if (result==true)
                {
                    MessageBox.Show("开卡成功！");
                    //1、把当前注册的账号传递给登录窗口并跳转
                    Form1 login = new Form1(RegistName.Text);
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("开卡失败，请重新输入");
                }
            }
          
        }
    }
}
