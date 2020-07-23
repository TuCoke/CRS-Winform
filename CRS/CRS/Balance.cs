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
    public partial class Balance : Form
    {
        BankBLL bankbll = new BankBLL();
        public Balance()
        {
            InitializeComponent();
        }
        public Balance(string usernumber)
        {
            InitializeComponent();
            label2.Text = usernumber;
        }

        private void Balance_Load(object sender, EventArgs e)
        {
           string Card_Number = label2.Text;
            //返回一用户余额
           string number = bankbll.Balance(Card_Number);
           label2.Text = number;

        }
        /// <summary>
        /// 退出查询余额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
