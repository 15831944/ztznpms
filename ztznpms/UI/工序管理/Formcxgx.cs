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
    public partial class Formcxgx : Form
    {
        public Formcxgx()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;

            //设置自动调整高度
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Formcxgx_Load(object sender, EventArgs e)
        {

            string s4 = "select * from db_gongxu1";
            reload(s4);
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

        private void 筛选数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formsx fs = new Formsx();
            string a = dataGridView1.CurrentCell.Value.ToString();
            string b = this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();
            fs.name2 = a;
            fs.lieming2 = b;
            fs.Show();
        }

        /// <summary>
        /// 按照名称、图号、负责人查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_chaxun_Click(object sender, EventArgs e)
        {
            if (txt_chaxun.Text == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }
            else
            {
                string s1 = "select * from db_gongxu1 where [名称] like '%" + txt_chaxun.Text.Trim() + "%' or [图号] like '%" + txt_chaxun.Text.Trim() + "%' or [负责人] like '%" + txt_chaxun.Text.Trim() + "%'";

                reload(s1);

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string s4 = "select * from db_gongxu1";
            DataTable dt = SQLhelp.GetDataTable(s4, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }
    }
}
