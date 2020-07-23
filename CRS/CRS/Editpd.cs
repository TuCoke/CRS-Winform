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
    public partial class Editpd : Form
    {
        BankBLL bankbll = new BankBLL();
        public Editpd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取当前修改用户的卡号id
        /// </summary>
        public Editpd(string usernumber)
        {
            InitializeComponent();
               //当前登录的用户卡号
                label1.Text = usernumber;
        }
        /// <summary>
        /// 用户修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editpwd_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次密码不一致请重新输入！");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                if (textBox2.Text == ""&& textBox3.Text==""&& textBox1.Text=="")
                {
                    //bool result=bankbll.
                    MessageBox.Show("请按要求输入！");
                }
                else
                {
                    //1、验证当前用户输入的旧密码是否与原有一致
                    UserInfo userInfo1 = new UserInfo();
                    userInfo1.Card_Number = label1.Text;
                    userInfo1.Card_Password = textBox1.Text;
                    bool result1 = bankbll.UseroldPwd(userInfo1);
                    //2、如果result1为false 则表示为查询到当前用户输入的密码
                    if (result1 != true)
                    {
                        MessageBox.Show("原密码错误，请重新输入！");
                        this.textBox1.Text = "";
                        this.Show();
                    }
                    else
                    {
                        //3、如果旧密码正确则修改密码
                        UserInfo userInfo = new UserInfo();
                        userInfo.Card_Number = label1.Text;
                        userInfo.Card_Password = this.textBox2.Text;
                        bool result = bankbll.UserNumber(userInfo);
                        if (result == true)
                        {
                            MessageBox.Show("修改成功");
                            //4、修改成功后返回index窗体
                            this.Owner.Show();
                            this.Close();
                        }
                    }

                  
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 退出修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, EventArgs e)
        {
            //关闭当前窗体
            this.Owner.Show();
            this.Close();
        }
    }
}
