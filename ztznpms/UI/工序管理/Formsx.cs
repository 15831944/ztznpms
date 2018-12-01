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
    public partial class Formsx : Form
    {
        public string name2;
        public string lieming2;
        public Formsx()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;

            //设置自动调整高度
            //this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Formsx_Load(object sender, EventArgs e)
        {
            string sql = "select * from db_gongxu1 where " + lieming2 + " = '" + name2 + "'";

            reload(sql);
        }

        private void reload(string sql)
        {
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;
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
        /// 按时间查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_chaxun1_Click(object sender, EventArgs e)
        {
            DateTime date1 = Convert.ToDateTime(dateTimePickerstart1.Value.Date.ToLongDateString());
            DateTime date2 = Convert.ToDateTime(dateTimePickerend1.Value.Date.ToLongDateString());

            if (date1 > date2)
            {
                MessageBox.Show("请重新设置查询时间！", "提示");
                return;
            }

            string sql1 = "select * from db_gongxu1 where 开始时间 >= '" + date1 + "' and 结束时间 <= '" + date2 + "' and " + lieming2 + " = '" + name2 + "'";
            reload(sql1);
        }
    }
}
