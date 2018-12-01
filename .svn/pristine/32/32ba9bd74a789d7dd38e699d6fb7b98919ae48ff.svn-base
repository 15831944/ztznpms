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

namespace ztznpms.UI.检验
{
    public partial class Formjixiuzujian : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public Formjixiuzujian()
        {
            InitializeComponent();
        }

        private void Formjixiuzujian_Load(object sender, EventArgs e)
        {
            reload();
            DrawRowIndicator(gridView1, 50);
        }
        private void reload()
        {
            string sql = "select id,客户名称,部门,工件名称,接单编号,联系人,料单类型 from tb_caigouliaodan where 料单类型='机修件部件'";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            this.gridControl1.DataSource = dt;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Formjixiuzujianshezhi aform = new Formjixiuzujianshezhi();

                aform.dingweiNumber = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
                aform.yonghu = yonghu;
                aform.gongzuolinghao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["接单编号"]).ToString();

                aform.Show();
            }
            catch
            {

            }
        }
    }
}