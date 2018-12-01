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

namespace ztznpms.UI
{
    public partial class FormPeople : Form
    {
        public FormPeople()
        {
            InitializeComponent();
        }

        private void FormPeople_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            string sql = "select * from db_operator";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;

            //dataGridView样式
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
        }

        /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormAddPeople newForm = new FormAddPeople();
            newForm.tag = "add";
            newForm.ShowDialog();

            if (newForm.DialogResult == DialogResult.OK)
            {
                this.reload();//重新绑定
            }

        }

        /// <summary>
        /// 修改人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormAddPeople newForm = new FormAddPeople();
            newForm.tag = "update";
            newForm.operatorname = dataGridView1.CurrentRow.Cells["OperatorName"].Value.ToString();
            newForm.ShowDialog();

            if (newForm.DialogResult == DialogResult.OK)
            {
                this.reload();//重新绑定
            }
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult RSS = MessageBox.Show(this, "确定要删除选中行数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                    {
                        int ID = Convert.ToInt32(dataGridView1.SelectedRows[i - 1].Cells[0].Value);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i - 1].Index);
                        string sql = "delete from db_Operator where ID='" + ID.ToString() + "' ";
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
    }
}
