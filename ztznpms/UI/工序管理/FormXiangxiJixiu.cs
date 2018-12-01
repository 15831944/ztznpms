using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.工序管理
{
    public partial class FormXiangxiJixiu : Form
    {
        public string gxkehuming;
        public string gxmingcheng;
        public string gxneirong;
        public string gxjiedanbianhao;
        public string gxxuhao;
        public FormXiangxiJixiu()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void FormXiangxiJixiu_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {

            string s1 = "select * from db_gongxu111 where 序号='"+ gxxuhao +"' order by 工序顺序 asc";
            DataTable dtgx = SQLhelp.GetDataTable(s1, CommandType.Text);

            this.dataGridView1.DataSource = dtgx;
        }

        /// <summary>
        /// 工序设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("请选择行！,若没数据请重新添加");
                return;
            }

            FormShezhijixiujiangongxu shezhi = new FormShezhijixiujiangongxu();

            shezhi.kehumingcheng = dataGridView1.CurrentRow.Cells["客户名称"].Value.ToString();
            shezhi.jiagongneirong = dataGridView1.CurrentRow.Cells["加工内容"].Value.ToString();
            shezhi.jiedanbianhao = dataGridView1.CurrentRow.Cells["接单编号"].Value.ToString();
            shezhi.gongjianmingcheng = dataGridView1.CurrentRow.Cells["工件名称"].Value.ToString();
            shezhi.shunxu1 = dataGridView1.CurrentRow.Cells["工序顺序"].Value.ToString();
            shezhi.gongxuming1 = dataGridView1.CurrentRow.Cells["工序名称"].Value.ToString();
            shezhi.neirong1 = dataGridView1.CurrentRow.Cells["工序内容"].Value.ToString();
            shezhi.fuzeren1 = dataGridView1.CurrentRow.Cells["负责人"].Value.ToString();
            shezhi.jiage1 = dataGridView1.CurrentRow.Cells["价格"].Value.ToString();
            shezhi.gxID = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            shezhi.xuhao = dataGridView1.CurrentRow.Cells["序号"].Value.ToString();
            shezhi.cailiao1 = dataGridView1.CurrentRow.Cells["材料"].Value.ToString();
            shezhi.zhongliang1 = dataGridView1.CurrentRow.Cells["重量"].Value.ToString();
            shezhi.zhuyidian = dataGridView1.CurrentRow.Cells["工艺注意点"].Value.ToString();
            shezhi.shuliang1 = dataGridView1.CurrentRow.Cells["机修件数量"].Value.ToString();
            shezhi.ShowDialog();

            if (shezhi.DialogResult == DialogResult.OK)
            {
                this.reload();//重新绑定
            }
        }

        /// <summary>
        /// 插入工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("请选择行！,若没数据请重新添加");
                return;
            }

            FormCharujixiujiangongxu charu = new FormCharujixiujiangongxu();
            charu.kehumingcheng2 = dataGridView1.CurrentRow.Cells["客户名称"].Value.ToString();
            charu.jiagongneirong2 = dataGridView1.CurrentRow.Cells["加工内容"].Value.ToString();
            charu.jiedanbianhao2 = dataGridView1.CurrentRow.Cells["接单编号"].Value.ToString();
            charu.gongjianmingcheng2 = dataGridView1.CurrentRow.Cells["工件名称"].Value.ToString();
            charu.bumen2 = dataGridView1.CurrentRow.Cells["部门"].Value.ToString();

            charu.shunxu2 = dataGridView1.CurrentRow.Cells["工序顺序"].Value.ToString();
            charu.shuliang2 = dataGridView1.CurrentRow.Cells["机修件数量"].Value.ToString();
            charu.xuhao = dataGridView1.CurrentRow.Cells["序号"].Value.ToString();
            charu.leixingming = dataGridView1.CurrentRow.Cells["类型"].Value.ToString();

            charu.ShowDialog();

            if (charu.DialogResult == DialogResult.OK)
            {
                this.reload();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("请选择行！,若没数据请重新添加");
                return;
            }

            FormWaixiejixiujian waixie = new FormWaixiejixiujian();

            waixie.wkehumingcheng = dataGridView1.CurrentRow.Cells["客户名称"].Value.ToString();
            waixie.wjiagongneirong = dataGridView1.CurrentRow.Cells["加工内容"].Value.ToString();
            waixie.wjiedanbianhao = dataGridView1.CurrentRow.Cells["接单编号"].Value.ToString();
            waixie.wgongjianmingcheng = dataGridView1.CurrentRow.Cells["工件名称"].Value.ToString();

            waixie.wshunxu = dataGridView1.CurrentRow.Cells["工序顺序"].Value.ToString();
            waixie.wgxming = dataGridView1.CurrentRow.Cells["工序名称"].Value.ToString();
            waixie.waixieStart = dataGridView1.CurrentRow.Cells["工序外协开始"].Value.ToString();
            waixie.waixieEnd = dataGridView1.CurrentRow.Cells["工序外协结束"].Value.ToString();

            waixie.ShowDialog();

            if (waixie.DialogResult == DialogResult.OK)
            {
                this.reload();
            }
        }

        /// <summary>
        /// 删除工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult RSS = MessageBox.Show(this, "确定要删除选中行数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                    {

                        int ID = Convert.ToInt32(dataGridView1.SelectedRows[i - 1].Cells[0].Value);//删除的ID
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i - 1].Index);

                        if (ID > 0)
                        {
                            string sql1 = "select 工序顺序 from db_gongxu111 where id='" + ID.ToString() + "'";
                            string r1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));//查到删除的工序顺序


                            //删除选中的工序
                            string sql = "delete from db_gongxu111 where id='" + ID.ToString() + "'";
                            int s = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

                            string sql6 = "delete from db_Paichan where 工序顺序='" + r1 + "' and 项目名称='" + gxmingcheng + "' and 工作令号='" + gxjiedanbianhao + "'";
                            int s6 = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql6, CommandType.Text));

                            string sql4 = "delete from db_shunxu111 where 工序顺序='" + r1 + "' and 工件名称='" + gxmingcheng + "' and 加工内容='" + gxneirong + "' and 接单编号='" + gxjiedanbianhao + "'";
                            string r4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));

                            string sql5 = "update db_shunxu111 set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 工件名称='" + gxmingcheng + "' and 加工内容='" + gxneirong + "' and 接单编号='" + gxjiedanbianhao + "'";
                            string r5 = Convert.ToString(SQLhelp.ExecuteNonquery(sql5, CommandType.Text));

                            //string sql2 = "select 工序顺序 from db_gongxu where 工序顺序 > '"+ r1 +"' and 名称 = '" + gxmingcheng1 + "' ";
                            //string r2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                            string sql3 = "update db_gongxu111 set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 工件名称='" + gxmingcheng + "' and 加工内容='" + gxneirong + "' and 接单编号='" + gxjiedanbianhao + "'";
                            string r3 = Convert.ToString(SQLhelp.ExecuteNonquery(sql3, CommandType.Text));

                            string sql7 = "update db_Paichan set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 项目名称='" + gxmingcheng + "' and 工作令号='" + gxjiedanbianhao + "'";
                            string r7 = Convert.ToString(SQLhelp.ExecuteNonquery(sql7, CommandType.Text));
                        }
                        else
                        {
                            return;
                        }


                    }
                    MessageBox.Show("成功删除选中行数据！", "提示");
                    break;
                case DialogResult.No:
                    MessageBox.Show("删除数据失败！", "提示");
                    break;
            }

            reload();

            string SQL1 = "select * from db_gongxu111 where 序号='" + gxxuhao + "' order by 工序顺序 asc";
            DataTable table = SQLhelp.GetDataTable(SQL1, CommandType.Text);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];

                string gongxstr = dr["工序名称"].ToString() + dr["结束时间"].ToString();

                string SQL2 = "update db_jixiujian set 工序" + (i + 1) + "='" + gongxstr + "' where 序号='" + gxxuhao + "'";
                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
            }

            string SQL3 = "select max(工序顺序) from db_gongxu111 where 序号='"+ gxxuhao +"'";
            string RET3 = Convert.ToString(SQLhelp.ExecuteScalar(SQL3, CommandType.Text));
            if(RET3 != "")
            {
                int shun3 = Convert.ToInt32(RET3);
                for (int i = shun3+1; i <= 25; i++)
                {
                    string SQL13 = "update db_jixiujian set 工序" + i + "=NULL where 序号='" + gxxuhao + "'";
                    SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                }

            }
            else//全删除了
            {
                for (int i = 1; i <= 25; i++)
                {
                    string SQL13 = "update db_jixiujian set 工序" + i + "=NULL where 序号='" + gxxuhao + "'";
                    SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                }

                string SQL4 = "update db_jixiujian set 目前到达工序=NULL where 序号='" + gxxuhao + "'";
                SQLhelp.ExecuteNonquery(SQL4, CommandType.Text);
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
