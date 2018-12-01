using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ztznpms.Common;
using ztznpms.UI.检验;

namespace ztznpms.UI.图纸管理
{
    public partial class Formpaichan : DevExpress.XtraEditors.XtraForm
    {
        public Formpaichan()
        {
            InitializeComponent();
        }

        private void Formpaichan_Load(object sender, EventArgs e)
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
            //string strSQL = "select id,序号,工作令号,项目名称,设备名称,工序设备,图号,名称,工序名称,价格,工序顺序,工序内容,负责人,设定开始时间,设定结束时间 from db_gongxu1 where 设定开始时间 IS NOT NULL and 设定结束时间 IS NOT NULL order by 设定开始时间 asc";//and 设定开始时间 < 设定结束时间
            //DataTable dt = SQLhelp.GetDataTable(strSQL, CommandType.Text);

            string strSQL = "select * from db_Paichan where 设定开始时间 IS NOT NULL and 设定结束时间 IS NOT NULL and 工序设备 IS NOT NULL order by 设定开始时间 asc";//and 设定开始时间 < 设定结束时间
            DataTable dt = SQLhelp.GetDataTable(strSQL, CommandType.Text);


            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string gonglinghao = dt.Rows[i]["设备名称"].ToString();
            //    string aaaaa = dt.Rows[i]["工作令号"].ToString().Trim();
            //    dt.Rows[i]["工作令号"] = aaaaa + "                " + "设备名称：" + gonglinghao + "               ";
            //}

            gridControl1.DataSource = dt;
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            //{
            //    string a = "";
            //    string b = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号"));
            //    if (b.Length > 5)
            //    {
            //        string bb = b.Substring(0, 20);
            //        a = bb.Trim();
            //    }
            //    if (a != "")
            //    {
            //        Formmingxi form1 = new Formmingxi();
            //        form1.gongzuolinghao = a;

            //        form1.shebeimincgheng = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
            //        form1.ShowDialog();
            //    }

            //}

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Formmingxi form = new Formmingxi();
                form.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();//this.gridView1.Columns[]
                form.shebeimincgheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                form.xiangmumingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.Show();
            }
            catch
            {

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void 信息大厅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Formmingxi form = new Formmingxi();
                form.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();//this.gridView1.Columns[]
                form.shebeimincgheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                form.xiangmumingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.flag = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "类型").ToString();
                form.Show();
            }
            catch
            {

            }
        }

        private void 数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Formtongji form = new Formtongji();
                form.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();//this.gridView1.Columns[]
                form.shebeimincgheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                form.xiangmumingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.flag = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "类型").ToString();
                form.Show();
            }
            catch
            {

            }
        }
    }
}