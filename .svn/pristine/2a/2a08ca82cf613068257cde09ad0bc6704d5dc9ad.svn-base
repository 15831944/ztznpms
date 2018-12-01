using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;
using ztznpms.UI.图纸管理;

namespace ztznpms.UI.项目管理
{
    public partial class FormAllxiangmu : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public FormAllxiangmu()
        {
            InitializeComponent();
            //dataGridView样式
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
        }

        private void FormAllxiangmu_Load(object sender, EventArgs e)
        {

            reload();
            DrawRowIndicator(gridView1, 40);

        }

        public void DrawRowIndicator(DevExpress.XtraGrid.Views.Grid.GridView gv, int width)
        {
            gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
            if (width != 0)
            {
                if (width != 0)
                {
                    gv.IndicatorWidth = width;
                }
                else
                {
                    gv.IndicatorWidth = 30;
                }
            }
            else
            {
                gv.IndicatorWidth = 30;
            }

        }
        private void reload()
        {
            //string sql1 = "select a.id,a.工作令号,a.项目名称,a.设备名称,a.项目主管,a.设备负责人,a.数量,a.时间,b.交货日期 from tb_jishubumen a,tb_xiangmu b where a.制造类型='自制' and a.是否提交=1 and a.技术部通过=1  and a.生产部确认=1 and a.加工确认=0 and a.项目名称=b.项目名称 and a.工作令号=b.工作令号 order by a.id";

            string sql1 = "select id,工作令号,项目名称,设备名称,项目主管,设备负责人,数量,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=0";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);


            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{
            //    string gonglinghao = dt1.Rows[i]["项目名称"].ToString();
            //    string jikuhumingcheng = dt1.Rows[i]["时间"].ToString();
            //    string riqi = Convert.ToDateTime(jikuhumingcheng).ToString("yyyy-MM-dd");
            //    string aaaaa = dt1.Rows[i]["工作令号"].ToString().Trim();
            //    dt1.Rows[i]["工作令号"] = aaaaa + "                " + "项目名称：" + gonglinghao + "               " + "项目上传时间：" + riqi;
            //}


            gridControl1.DataSource = dt1;
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormZiZhiqingdan aform = new FormZiZhiqingdan();
            aform.xiangmumingcheng1 = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            aform.shebeimingcheng1 = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();
            aform.gongzuolinghao1 = dataGridView1.CurrentRow.Cells["工作令号"].Value.ToString();
            aform.shijian1 = dataGridView1.CurrentRow.Cells["时间"].Value.ToString();
            aform.Show();
        }

        private void 导入加工清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormXiangmuXiangxi form = new FormXiangmuXiangxi();
            //form.xiangmumingcheng = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            //form.shebeimingcheng = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();
            //form.shijian = dataGridView1.CurrentRow.Cells["时间"].Value.ToString();

            form.xiangmumingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
            form.shebeimingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
            form.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
            form.shijian= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["时间"]).ToString();

            form.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }
            else
            {
                string s1 = "select 项目主管,工作令号,项目名称,设备名称,数量 from tb_jishubumen where [项目名称] like '%" + toolStripTextBox1.Text.Trim() + "%' or [工作令号] like '%" + toolStripTextBox1.Text.Trim() + "%' or [设备名称] like '%" + toolStripTextBox1.Text.Trim() + "%' or[项目主管] like '%" + toolStripTextBox1.Text.Trim() + "%'";
                DataTable dt1 = SQLhelp.GetDataTable1(s1, CommandType.Text);
                //this.dataGridView1.DataSource = dt1;

                gridControl1.DataSource = dt1;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void com_xiangmu_Click(object sender, EventArgs e)
        {

            //com_xiangmu.Items.Clear();
            //string sql = "select 项目名称 from tb_xiangmu ";
            //DataTable dt = GetDataTable(sql, CommandType.Text);
            //foreach (DataRow row in dt.Rows)
            //{
            //    string a = row["项目名称"].ToString();
            //    com_xiangmu.Items.Add(a);
            //}

            com_xiangmu.Items.Clear();
            string sql = "select 项目名称 from db_xiangmu ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["项目名称"].ToString();
                if (com_xiangmu.Items.Cast<object>().All(x => x.ToString() != a))
                    com_xiangmu.Items.Add(a);
            }

        }

        private void com_xiangmu_TextChanged(object sender, EventArgs e)
        {
            //string sql1 = "select 项目主管,工作令号,项目名称,设备名称,数量 from tb_jishubumen where 项目名称='"+ com_xiangmu.Text.Trim()+ "' and 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=0";
            string sql1 = "select id,工作令号,项目名称,设备名称,项目主管,设备负责人,数量,时间 from tb_jishubumen where 项目名称='" + com_xiangmu.Text.Trim() + "' and 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=0";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);
            //this.dataGridView1.DataSource = dt1;
            gridControl1.DataSource = dt1;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //if (e.Info.IsRowIndicator)
            //{
            //    if (e.RowHandle >= 0)
            //    {
            //        e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //    }
            //    else if (e.RowHandle < 0 && e.RowHandle > -1000)
            //    {
            //        e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            //        e.Info.DisplayText = "G" + e.RowHandle.ToString();
            //    }
            //}
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormZiZhiqingdan aform = new FormZiZhiqingdan();

                if (gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString() != "")
                {
                    aform.xiangmumingcheng1 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
                }

                aform.shebeimingcheng1 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
                aform.gongzuolinghao1 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
                aform.shijian1 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["时间"]).ToString();
                aform.yonghu = yonghu;

                aform.Show();
            }
            catch
            {

            }
            
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void 加工完成情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formjiagongqingkuang form = new Formjiagongqingkuang();
            if (gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString() != "")
            {
                form.xiangmumingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
            }

            form.shebeimingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
            form.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
            form.shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["时间"]).ToString();
            form.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string sql = "select * from db_gongxu1 where id > 8155 and id < 8179 and 工序设备 IS NOT NULL and 设定开始时间 IS NOT NULL ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string sql1 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,序号,工序设备,设定开始时间,设定结束时间,工序顺序,工序名称,工艺制定时间,负责人,零件名称) values('"+ dr["项目名称"]+"','"+ dr["工作令号"] +"','"+ dr["设备名称"] + "','" + dr["数量"] + "','" + dr["序号"] + "','" + dr["工序设备"] + "','" + dr["设定开始时间"] + "','" + dr["设定结束时间"] + "','" + dr["工序顺序"] + "','" + dr["工序名称"] + "','" + dr["工艺制定时间"] + "','" + dr["负责人"] + "','" + dr["名称"] + "')";
                string ret1 = Convert.ToString(SQLhelp.ExecuteNonquery(sql1, CommandType.Text));
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string s1 = "select 序号 from db_jixiujian where 完成='完成'";
            DataTable dt = SQLhelp.GetDataTable(s1, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string s2 = "update db_gongxu111 set 状态=1 where 序号='" + row["序号"] + "'";
                string ret = Convert.ToString(SQLhelp.ExecuteNonquery(s2, CommandType.Text));
            }
        }

        /// <summary>
        /// 导入项目(db_xiangmujinxing)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
             //string sql1 = "select a.id,a.工作令号,a.项目名称,a.设备名称,a.项目主管,a.设备负责人,a.数量,a.时间,b.交货日期 from tb_jishubumen a,tb_xiangmu b where a.制造类型='自制' and a.是否提交=1 and a.技术部通过=1  and a.生产部确认=1 and a.加工确认=0 and a.项目名称=b.项目名称 and a.工作令号=b.工作令号 order by a.id";

            string sql1 = "select id,工作令号,项目名称,设备名称,项目主管,设备负责人,数量,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=0";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);

            string sql3 = "delete from db_xiangmujinxing";
            SQLhelp.ExecuteNonquery(sql3, CommandType.Text);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dt1.Rows[i];
                string sql2 = "insert into db_xiangmujinxing(number,工作令号,项目名称,设备名称,项目主管,设备负责人,数量,时间) values('"+ dr["id"]+"','"+ dr["工作令号"] + "','" + dr["项目名称"] + "','" + dr["设备名称"] + "','" + dr["项目主管"] + "','" + dr["设备负责人"] + "','" + dr["数量"] + "','" + dr["时间"] + "')";
                string ret2 = Convert.ToString(SQLhelp.ExecuteNonquery(sql2, CommandType.Text));
            }

            //string sql4 = "select * from db_xiangmujinxing";
            //DataTable dt4 = SQLhelp.GetDataTable(sql4, CommandType.Text);

            //for (int i = 0; i < dt4.Rows.Count; i++)
            //{

            //}
        }
    }
}
