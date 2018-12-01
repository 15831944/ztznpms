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

namespace ztznpms.UI.工序管理
{
    public partial class FormPaigongdan : DevExpress.XtraEditors.XtraForm
    {
        public string yonghuming;
        private string t1;
        private string t2;
        private string t3;
        private string t4;

        DateTime time11;
        DateTime time22;
        public FormPaigongdan()
        {
            InitializeComponent();
        }

        private void FormPaigongdan_Load(object sender, EventArgs e)
        {
            reload();
            reload1();

            DrawRowIndicator(gridView1, 50);
            DrawRowIndicator1(gridView2, 50);
            DrawRowIndicator2(gridView4, 50);
        }

        private void reload()
        {
            string sql1 = "select * from tb_Paigongdan where 状态=1";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);
            this.gridControl1.DataSource = dt1;

            string sql2 = "select * from tb_Paigongdan where 状态=0";
            DataTable dt2 = SQLhelp.GetDataTable1(sql2, CommandType.Text);
            this.gridControl2.DataSource = dt2;
        }

        private void reload1()
        {
            string sql = "select * from tb_Paigongdan";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            this.gridControl3.DataSource = dt;
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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        public void DrawRowIndicator1(DevExpress.XtraGrid.Views.Grid.GridView gv, int width)
        {
            gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView2_CustomDrawRowIndicator);
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

        private void 设置派工单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.Columns["id"]).ToString();
            string bianma = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.Columns["编码"]).ToString();
            string bianhao = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.Columns["序号"]).ToString();
            string number = gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.Columns["number"]).ToString();

            Formgongdan form = new Formgongdan();
            form.id = id;
            form.yonghu = yonghuming;
            form.bianma = bianma;
            form.bianhao = bianhao;
            form.number = number;
            form.ShowDialog();

        }

        private void 新增派工单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formxinzengpaigong form = new Formxinzengpaigong();
            form.yonghu = yonghuming;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                reload();
            }
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        public void DrawRowIndicator2(DevExpress.XtraGrid.Views.Grid.GridView gv, int width)
        {
            gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView4_CustomDrawRowIndicator);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (dateTimeInput1.Text == "" || dateTimeInput2.Text == "")
            {
                MessageBox.Show("请筛选出时间！", "提示");
                return;
            }

            DateTime time1 = dateTimeInput1.Value;
            DateTime time2 = dateTimeInput2.Value;

            if (time1 > time2)
            {
                MessageBox.Show("请重新选择时间！", "提示");
                return;
            }

            if (dateTimeInput1.Text != "" || dateTimeInput2.Text != "")
            {
                t3 = dateTimeInput1.Value.ToString("yyyy/MM/dd 00:00:00");
                t4 = dateTimeInput2.Value.ToString("yyyy/MM/dd 23:59:59");
            }

            time11 = Convert.ToDateTime(t3);
            time22 = Convert.ToDateTime(t4);

            string sql = "select * from tb_Paigongdan where 下达时间>='" + time11 + "' and 下达时间<='" + time22 + "'";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            this.gridControl3.DataSource = dt;
        }

        private void 数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dateTimeInput1.Text == "" || dateTimeInput2.Text == "")
            {
                MessageBox.Show("请筛选出时间！", "提示");
                return;
            }

            DateTime time1 = dateTimeInput1.Value;
            DateTime time2 = dateTimeInput2.Value;

            if (time1 > time2)
            {
                MessageBox.Show("请重新选择时间！", "提示");
                return;
            }

            if(dateTimeInput1.Text != "" || dateTimeInput2.Text != "")
            {
                t1 = dateTimeInput1.Value.ToString("yyyy/MM/dd 00:00:00");
                t2 = dateTimeInput2.Value.ToString("yyyy/MM/dd 23:59:59");
            }

            FormPaigongdanData form = new FormPaigongdanData();
            form.flag = "全部";
            form.t1 = t1;
            form.t2 = t2;
            form.Show();
        }

        private void 导出Excel表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dateTimeInput1.Text == "" || dateTimeInput2.Text == "")
            {
                MessageBox.Show("请筛选出时间！", "提示");
                return;
            }

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl3.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}