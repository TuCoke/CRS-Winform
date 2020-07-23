using BLL;
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
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }
        public Transaction(string usernumber)
        {
            InitializeComponent();
            label1.Text = usernumber;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// 退出操作记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //关闭当前窗体
            this.Owner.Show();
            this.Close();
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void DataBind()
        {
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Transaction_Load(object sender, EventArgs e)
        {
            RecordingBLL recordingBLL = new RecordingBLL();
            DataTable dt = recordingBLL.GetAllUser(this.label1.Text);
            //1、绑定
            // DataSet ds = new DataSet();
            //  this.dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = dt;
            //2、当前数据不可编辑
            dataGridView1.ReadOnly = true;
            //3、设置随窗体大小自适应
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewTextBoxColumn subTitleColumn =
                new DataGridViewTextBoxColumn();
            subTitleColumn.HeaderText = "Subtitle";
            subTitleColumn.MinimumWidth = 50;
            subTitleColumn.FillWeight = 90;
            //4、设置数据列名
            dataGridView1.Columns[0].HeaderCell.Value = "编号";
            dataGridView1.Columns[1].HeaderCell.Value = "操作时间";
            dataGridView1.Columns[2].HeaderCell.Value = "操作内容";
            dataGridView1.Columns[3].HeaderCell.Value = "卡号";
        }
    }
}
