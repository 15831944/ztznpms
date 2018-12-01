using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.工序管理
{
    public partial class Formgxsx : Form
    {
        public string name1;
        public string lieming1;
        public Formgxsx()
        {
            InitializeComponent();
            //dataGridView样式
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;

            //设置自动调整高度
            //this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Formgxsx_Load(object sender, EventArgs e)
        {
            string sql = "select * from db_gongxu1 where " + lieming1 + " = '" + name1 + "'";

            reload(sql);
        }

        private void reload(string sql)
        {
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_chaxun_Click(object sender, EventArgs e)
        {
            DateTime time1 = Convert.ToDateTime(dateTimePickerstart.Value.Date.ToLongDateString());
            DateTime time2 = Convert.ToDateTime(dateTimePickerend.Value.Date.AddDays(1).AddSeconds(-1));
            if (time1 > time2)
            {
                MessageBox.Show("请重新设置查询时间！", "提示");
                return;
            }

            string sql1 = "select * from db_gongxu1 where 开始时间 >= '"+ time1 +"' and 结束时间 <= '"+ time2 + "' and " + lieming1 + " = '" + name1 + "'";
            reload(sql1);
        }


        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                System.Drawing.Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_daochu_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            Excel._Workbook wk = excel.Workbooks.Add(Type.Missing);
            excel.Visible = true;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            //填充内容
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value == null)
                    {
                        excel.Cells[i + 2, j + 1] = "";
                    }
                    else if (dataGridView1[j, i].ValueType == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                    }
                }
            }

            MessageBox.Show("导出Excel成功！", "提示");


        }




    }
}
