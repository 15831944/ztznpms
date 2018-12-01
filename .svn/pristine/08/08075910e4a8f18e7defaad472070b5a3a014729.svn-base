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
using ztznpms.UI.人员管理;
using ztznpms.UI.工序管理;

namespace ztznpms.UI.工序管理
{
    public partial class FormGxgl : Form
    {
        public FormGxgl()
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

        private void FormGxgl_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            string s4 = "select * from db_gongxu1 ";
            DataTable dt1 = SQLhelp.GetDataTable(s4, CommandType.Text);
            this.dataGridView1.DataSource = dt1;
        }

        /// <summary>
        /// 设置工序名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormAddmingchen a = new FormAddmingchen();
            a.Show();
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
        /// 删除工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult RSS = MessageBox.Show(this, "确定要删除选中行数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                    {
                        int ID = Convert.ToInt32(dataGridView1.SelectedRows[i - 1].Cells[0].Value);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i - 1].Index);

                        string s1 = "select 图号 from db_gongxu1 where id='" + ID.ToString() + "'";
                        string r1 = Convert.ToString(SQLhelp.ExecuteScalar(s1, CommandType.Text));

                        string s2 = "select 工序名称 from db_gongxu1 where id='" + ID.ToString() + "'";
                        string r2 = Convert.ToString(SQLhelp.ExecuteScalar(s2, CommandType.Text));

                        string s3 = "select 工序顺序 from db_gongxu1 where id='" + ID.ToString() + "'";
                        string r3 = Convert.ToString(SQLhelp.ExecuteScalar(s3, CommandType.Text));

                        string sql = "delete from db_gongxu1 where id='" + ID.ToString() + "' ";
                        int s = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

                        string s4 = "delete from db_shunxu where 图号='"+ r1 +"' and 工序名称='"+ r2 +"' and 工序顺序='"+ r3 +"'";
                        int r4 = Convert.ToInt32(SQLhelp.ExecuteNonquery(s4, CommandType.Text));

                    }
                    MessageBox.Show("成功删除选中行数据！", "提示");
                    break;
                case DialogResult.No:
                    MessageBox.Show("删除数据失败！", "提示");
                    break;
            }

            reload();
        }

        /// <summary>
        /// 车间人员管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Formchejianrenyuan aa = new Formchejianrenyuan();
            aa.Show();
        }

        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 筛选数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formgxsx fs = new Formgxsx();
            string a = dataGridView1.CurrentCell.Value.ToString();
            string b = this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();
            fs.name1 = a;
            fs.lieming1 = b;
            fs.Show();
        }
    }
}
