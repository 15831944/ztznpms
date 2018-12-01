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
using ztznpms.UI.工序管理;

namespace ztznpms.UI.项目管理
{
    public partial class Formxiangxigongxu : Form
    {
        public string flag;

        //public string gxtuhao;
        //public string gxmingcheng1;
        //public string gxxiangmu1;
        //public string gxshebeiming1;

        public string xuhao1;
        public Formxiangxigongxu()
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

        private void Formxiangxigongxu_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            if(flag == "自制加工")
            {
                //string s1 = "select * from db_gongxu1 where 图号 = '" + gxtuhao + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "' order by 工序顺序 asc";
                string s1 = "select * from db_gongxu1 where 序号 = '" + xuhao1 + "' order by 工序顺序 asc";
                DataTable dtgx = SQLhelp.GetDataTable(s1, CommandType.Text);

                this.dataGridView1.DataSource = dtgx;
            }
            if(flag == "技术更改")
            {
                //string s1 = "select * from db_gongxu11 where 图号 = '" + gxtuhao + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "' order by 工序顺序 asc";
                string s1 = "select * from db_gongxu11 where 序号 = '" + xuhao1 + "' order by 工序顺序 asc";
                DataTable dtgx = SQLhelp.GetDataTable(s1, CommandType.Text);

                this.dataGridView1.DataSource = dtgx;
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

            Formshezhigongxu shezhi = new Formshezhigongxu();
            shezhi.tuhao1 = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
            shezhi.xiangmumingcheng1 = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            shezhi.mingcheng1 = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
            shezhi.gonglinghao1 = dataGridView1.CurrentRow.Cells["工作令号"].Value.ToString();
            shezhi.shebeimingcheng1 = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();
            shezhi.shunxu1 = dataGridView1.CurrentRow.Cells["工序顺序"].Value.ToString();
            shezhi.gongxuming1 = dataGridView1.CurrentRow.Cells["工序名称"].Value.ToString();
            shezhi.neirong1 = dataGridView1.CurrentRow.Cells["工序内容"].Value.ToString();
            shezhi.fuzeren1 = dataGridView1.CurrentRow.Cells["负责人"].Value.ToString();
            shezhi.jiage1 = dataGridView1.CurrentRow.Cells["价格"].Value.ToString();
            shezhi.xuhao = dataGridView1.CurrentRow.Cells["序号"].Value.ToString();
            shezhi.cailiao1 = dataGridView1.CurrentRow.Cells["材料"].Value.ToString();
            shezhi.zhongliang1 = dataGridView1.CurrentRow.Cells["重量"].Value.ToString();
            shezhi.zhuyidian = dataGridView1.CurrentRow.Cells["工艺注意点"].Value.ToString();
            shezhi.shuliang1 = dataGridView1.CurrentRow.Cells["数量"].Value.ToString();
            shezhi.flag1 = flag;
            shezhi.ShowDialog();
            //shezhi.Show();

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

            Formcharugongxu charu = new Formcharugongxu();
            charu.xiangmumingcheng2 = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            charu.tuhao2 = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
            charu.mingcheng2 = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
            charu.gonglinghao2 = dataGridView1.CurrentRow.Cells["工作令号"].Value.ToString();
            charu.shunxu2 = dataGridView1.CurrentRow.Cells["工序顺序"].Value.ToString();
            charu.shebeiming2 = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();
            charu.shuliang2 = dataGridView1.CurrentRow.Cells["数量"].Value.ToString();
            charu.xuhao = dataGridView1.CurrentRow.Cells["序号"].Value.ToString();
            charu.leixingmingcheng = dataGridView1.CurrentRow.Cells["类型"].Value.ToString();
            charu.flag2 = flag;

            charu.ShowDialog();

            if(charu.DialogResult == DialogResult.OK)
            {
                this.reload();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(flag == "自制加工")
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
                                string sql1 = "select 工序顺序 from db_gongxu1 where id='" + ID + "'";
                                string r1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));//查到删除的工序顺序


                                //删除选中的工序 db_gongxu1
                                string sql = "delete from db_gongxu1 where id='" + ID + "'";
                                int s = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

                                string sql3 = "update db_gongxu1 set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 序号='" + xuhao1 + "'";// 名称 = '" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r3 = Convert.ToString(SQLhelp.ExecuteNonquery(sql3, CommandType.Text));

                                //更新工序顺序 db_shunxu
                                string sql4 = "delete from db_shunxu where 工序顺序='" + r1 + "' and 序号='" + xuhao1 + "'";//名称='" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));


                                string sql5 = "update db_shunxu set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 序号='" + xuhao1 + "'";//名称 = '" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r5 = Convert.ToString(SQLhelp.ExecuteNonquery(sql5, CommandType.Text));

                                string sql6 = "delete from db_Paichan where 工序顺序='" + r1 + "' and 序号='" + xuhao1 + "'";//零件名称='" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                int s6 = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql6, CommandType.Text));

                          
                                string sql7 = "update db_Paichan set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 序号='" + xuhao1 + "'";//零件名称 = '" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r7 = Convert.ToString(SQLhelp.ExecuteNonquery(sql7, CommandType.Text));


                                string ss5 = "select 工序名称,工序顺序 from db_gongxu1 where 序号='" + xuhao1 + "' order by 工序顺序 asc";
                                DataTable dt5 = SQLhelp.GetDataTable(ss5, CommandType.Text);

                                for (int k = 0; k < 25; k++)
                                {
                                    string gx = "工序" + (k + 1).ToString();
                                    string ss7 = "update db_xiangmu set " + gx + " = NULL where 序号='" + xuhao1 + "'";
                                    SQLhelp.ExecuteNonquery(ss7, CommandType.Text);
                                }
                                for (int j = 0; j < dt5.Rows.Count; j++)
                                {
                                    DataRow dr = dt5.Rows[j];
                                    string gongxu1 = "工序" + (j + 1).ToString();
                                    string ss6 = "update db_xiangmu set  " + gongxu1 + " = '" + dr["工序名称"] + "' where 序号='" + xuhao1 + "'";
                                    SQLhelp.ExecuteNonquery(ss6, CommandType.Text);
                                }

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

                string SQL1 = "select * from db_gongxu1 where 序号='" + xuhao1 + "' order by 工序顺序 asc";
                DataTable table = SQLhelp.GetDataTable(SQL1, CommandType.Text);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow dr = table.Rows[i];

                    string gongxstr = dr["工序名称"].ToString() + dr["结束时间"].ToString();

                    string SQL2 = "update db_xiangmu set 工序" + (i + 1) + "='" + gongxstr + "' where 序号='" + xuhao1 + "'";
                    SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
                }

                string SQL3 = "select max(工序顺序) from db_gongxu1 where 序号='" + xuhao1 + "'";
                string RET3 = Convert.ToString(SQLhelp.ExecuteScalar(SQL3, CommandType.Text));
                if (RET3 != "")
                {
                    int shun3 = Convert.ToInt32(RET3);
                    for (int i = shun3 + 1; i <= 25; i++)
                    {
                        string SQL13 = "update db_xiangmu set 工序" + i + "=NULL where 序号='" + xuhao1 + "'";
                        SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                    }

                }
                else//全删除了
                {
                    for (int i = 1; i <= 25; i++)
                    {
                        string SQL13 = "update db_xiangmu set 工序" + i + "=NULL where 序号='" + xuhao1 + "'";
                        SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                    }

                    string SQL4 = "update db_xiangmu set 目前到达工序=NULL where 序号='"+ xuhao1 +"'";
                    SQLhelp.ExecuteNonquery(SQL4, CommandType.Text);

                }
            }
            if(flag == "技术更改")
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
                                string sql1 = "select 工序顺序 from db_gongxu11 where id='" + ID.ToString() + "'";
                                string r1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));//查到删除的工序顺序


                                //删除选中的工序
                                string sql = "delete from db_gongxu11 where id='" + ID.ToString() + "'";
                                int s = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

                                string sql6 = "delete from db_Paichan where 工序顺序='" + r1 + "' and 序号='" + xuhao1 + "'";//零件名称='" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                int s6 = Convert.ToInt32(SQLhelp.ExecuteNonquery(sql6, CommandType.Text));

                                string sql4 = "delete from db_shunxu11 where 工序顺序='" + r1 + "' and 序号='" + xuhao1 + "'";//名称='" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));

                                string sql5 = "update db_shunxu11 set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 序号='" + xuhao1 + "'";//名称 = '" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r5 = Convert.ToString(SQLhelp.ExecuteNonquery(sql5, CommandType.Text));

                                //string sql2 = "select 工序顺序 from db_gongxu where 工序顺序 > '"+ r1 +"' and 名称 = '" + gxmingcheng1 + "' ";
                                //string r2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));

                                string sql3 = "update db_gongxu11 set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 序号='" + xuhao1 + "'";//名称 = '" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r3 = Convert.ToString(SQLhelp.ExecuteNonquery(sql3, CommandType.Text));

                                string sql7 = "update db_Paichan set 工序顺序 = 工序顺序 - 1 where 工序顺序 > '" + r1 + "' and 序号='" + xuhao1 + "'";//零件名称 = '" + gxmingcheng1 + "' and 项目名称='" + gxxiangmu1 + "' and 设备名称='" + gxshebeiming1 + "'";
                                string r7 = Convert.ToString(SQLhelp.ExecuteNonquery(sql7, CommandType.Text));


                                string ss5 = "select 工序名称,工序顺序 from db_gongxu11 where 序号='" + xuhao1 + "' order by 工序顺序 asc";
                                DataTable dt5 = SQLhelp.GetDataTable(ss5, CommandType.Text);

                                for (int k = 0; k < 25; k++)
                                {
                                    string gx = "工序" + (k + 1).ToString();
                                    string ss7 = "update db_xiangmu set " + gx +" = NULL where 序号='"+ xuhao1 +"'";
                                    SQLhelp.ExecuteNonquery(ss7, CommandType.Text);
                                }
                                for (int j = 0; j < dt5.Rows.Count; j++)
                                {
                                    DataRow dr = dt5.Rows[j];
                                    string gongxu1 = "工序" + (j + 1).ToString();
                                    string ss6 = "update db_xiangmu set  " + gongxu1 + " = '" + dr["工序名称"] + "' where 序号='" + xuhao1 + "'";
                                    SQLhelp.ExecuteNonquery(ss6, CommandType.Text);
                                }
                                
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
            }
            
        }

        /// <summary>
        /// 工序外协
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("请选择行！,若没数据请重新添加");
                return;
            }

            //string str1 = dataGridView1.CurrentRow.Cells["开始时间"].Value.ToString();
            //string str2 = dataGridView1.CurrentRow.Cells["结束时间"].Value.ToString();

            //if (str1 != "" && str2 != "")
            //{
            //    MessageBox.Show("该道工序已结束，无法工序外协！", "提示");
            //    return;
            //}
            //else
            //{
            Formgxwaixie waixie = new 工序管理.Formgxwaixie();

            waixie.wxiangmumingcheng = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            waixie.wtuhao = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
            waixie.wmingcheng = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
            waixie.wgonglinghao = dataGridView1.CurrentRow.Cells["工作令号"].Value.ToString();
            waixie.wshebeimingcheng = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();
            waixie.wshunxu = dataGridView1.CurrentRow.Cells["工序顺序"].Value.ToString();
            waixie.wgxming = dataGridView1.CurrentRow.Cells["工序名称"].Value.ToString();
            waixie.waixieStart = dataGridView1.CurrentRow.Cells["工序外协开始"].Value.ToString();
            waixie.waixieEnd = dataGridView1.CurrentRow.Cells["工序外协结束"].Value.ToString();
            waixie.flag3 = flag;
                
            waixie.ShowDialog();

            if (waixie.DialogResult == DialogResult.OK)
            {
                this.reload();
            }
        //}
        }


    }
}
