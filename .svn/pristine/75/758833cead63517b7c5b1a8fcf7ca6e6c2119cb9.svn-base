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
    public partial class FormAddmingchen : Form
    {
        public FormAddmingchen()
        {
            InitializeComponent();
            //dataGridView样式
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
        }

        private void FormAddmingchen_Load(object sender, EventArgs e)
        {
            reload();
        }

        public void reload()
        {
            string s1 = "select * from db_gongxumingcheng";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 增加工序名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormAdd a = new FormAdd();
            a.tagAdd = "增加工序名称";
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                this.reload();//重新绑定
            }
        }
        /// <summary>
        /// 删除工序名称
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
                        string sql = "delete from db_gongxumingcheng where id='" + ID.ToString() + "' ";
                        int s = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));
                        if (s != 0)
                        {
                            ;
                        }
                    }
                    MessageBox.Show("成功删除选中行数据！", "提示");
                    break;
                case DialogResult.No:
                    MessageBox.Show("删除数据失败！", "提示");
                    break;
            }

            reload();
        }

        private void dgv1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        /// 保存修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            for(int i=0; i<dataGridView1.Rows.Count; i++)
            {
                string a1 = dataGridView1.Rows[i].Cells["id"].EditedFormattedValue.ToString();
                string a2 = dataGridView1.Rows[i].Cells["工序名称"].EditedFormattedValue.ToString();
                string a3 = dataGridView1.Rows[i].Cells["科学单价"].EditedFormattedValue.ToString();

                string sql = "update db_gongxumingcheng set 工序名称='"+ a2 +"', 科学单价='"+ a3 +"' where id='"+ a1 +"'";
                int r = SQLhelp.ExecuteNonquery(sql, CommandType.Text);
            }
            MessageBox.Show("修改数据成功！", "提示");
            reload();
        }


    }
}
