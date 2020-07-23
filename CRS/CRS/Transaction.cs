using BLL;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;

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
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {

            RecordingBLL recordingBLL = new RecordingBLL();
            DataTable dt = recordingBLL.GetAllUser(this.label1.Text);
            //下载Nuget包 Microsoft.Office.Interop
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();

            SaveFileDialog savefiledialog = new SaveFileDialog();

            System.Reflection.Missing miss = System.Reflection.Missing.Value;

            appexcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook workbookdata;

            Microsoft.Office.Interop.Excel.Worksheet worksheetdata;

            Microsoft.Office.Interop.Excel.Range rangedata;

            //设置对象不可见

            appexcel.Visible = false;

            System.Globalization.CultureInfo currentci = System.Threading.Thread.CurrentThread.CurrentCulture;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

            workbookdata = appexcel.Workbooks.Add(miss);

            worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets.Add(miss, miss, miss, miss);

            //给工作表赋名称

            worksheetdata.Name = "saved";

            for (int i = 0; i < dt.Columns.Count; i++)

            {

                worksheetdata.Cells[1, i + 1] = dt.Columns[i].ColumnName.ToString();

            }

            //因为第一行已经写了表头，所以所有数据都应该从a2开始

            rangedata = worksheetdata.get_Range("a2", miss);

            Microsoft.Office.Interop.Excel.Range xlrang = null;

            //irowcount为实际行数，最大行

            int irowcount = dt.Rows.Count;

            int iparstedrow = 0, icurrsize = 0;

            //ieachsize为每次写行的数值，可以自己设置

            int ieachsize = 1000;

            //icolumnaccount为实际列数，最大列数

            int icolumnaccount = dt.Columns.Count;

            //在内存中声明一个ieachsize×icolumnaccount的数组，ieachsize是每次最大存储的行数，icolumnaccount就是存储的实际列数

            object[,] objval = new object[ieachsize, icolumnaccount];
            icurrsize = ieachsize;
            while (iparstedrow < irowcount)
            {

                if ((irowcount - iparstedrow) < ieachsize)

                    icurrsize = irowcount - iparstedrow;

                //用for循环给数组赋值

                for (int i = 0; i < icurrsize; i++)

                {

                    for (int j = 0; j < icolumnaccount; j++)

                        objval[i, j] = dt.Rows[i + iparstedrow][j].ToString();

                    System.Windows.Forms.Application.DoEvents();

                }

                string X = "A" + ((int)(iparstedrow + 2)).ToString();
                string col = "";
                if (icolumnaccount <= 26)
                {
                    col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                }

                else

                {

                    col = ((char)('A' + (icolumnaccount / 26 - 1))).ToString() + ((char)('A' + (icolumnaccount % 26 - 1))).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();

                }

                xlrang = worksheetdata.get_Range(X, col);

                // 调用range的value2属性，把内存中的值赋给excel

                xlrang.Value2 = objval;

                iparstedrow = iparstedrow + icurrsize;

            }

            //保存工作表
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlrang);
            xlrang = null;
            //调用方法关闭excel进程
            appexcel.Visible = true;

        }



    }
}
