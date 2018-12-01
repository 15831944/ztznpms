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
using ztznpms.UI.工序管理;
using System.IO;

namespace ztznpms.UI.检验
{
    public partial class Formjixiuzujianshezhi : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public string dingweiNumber;

        public string gongzuolinghao;
        public string shebeimingcheng;

        string shijian11;
        private string leixing;
        private string lujing;

        public Formjixiuzujianshezhi()
        {
            InitializeComponent();
        }

        private void Formjixiuzujianshezhi_Load(object sender, EventArgs e)
        {
            reload();
            DrawRowIndicator(gridView1, 50);
        }

        private void reload()
        {
            string sql = "select * from tb_caigouliaodan where 定位='"+ dingweiNumber +"'";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            this.gridControl1.DataSource = dt;

            string sql1 = "select 收到料单日期,设备名称 from tb_caigouliaodan where 定位='" + dingweiNumber + "'";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);
            DataRow dr = dt1.Rows[0];
            shijian11 = dr["收到料单日期"].ToString();
            shebeimingcheng = dr["设备名称"].ToString();

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

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            if (e.Column.FieldName == "附件名称")//设背景  
            {
                //int pointID = (gridView1.GetRow(e.RowHandle) as object).BgColor;  
                e.Appearance.ForeColor = Color.Blue;
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Formshezhijixiujian add = new Formshezhijixiujian();

            add.xuhao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
            add.dingweiNumber = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["定位"]).ToString();
            add.shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["收到料单日期"]).ToString();

            add.yonghu = yonghu;
            add.leixing = "机修件组件";

            add.ShowDialog();

            if (add.DialogResult == DialogResult.OK)
            {

                this.reload();

            }
        }

        private void 详细工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormXiangxiJixiu gx = new FormXiangxiJixiu();

            string f = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
            gx.gxxuhao = f;
            gx.Show();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            Formshebeicailiaoshengou form = new Formshebeicailiaoshengou();
            form.yonghu = yonghu;
            form.shijian = shijian11;
            form.gonglinghao = gongzuolinghao;
            form.shebeimingcheng = shebeimingcheng;
            form.dingweishu= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["定位"]).ToString();
            form.liaodanleiixng = "机修件组件";
            form.ShowDialog();
        }

        private void 查看图纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fujian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["附件名称"]).ToString();
                if (fujian != "")
                {
                    string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
                    string b = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();


                    string chaxun11 = "select 附件类型 from tb_caigouliaodan where  附件名称='" + fujian + "' and 名称='" + b + "'and id='" + id + "'";
                    leixing = SQLhelp.ExecuteScalar1(chaxun11, CommandType.Text).ToString();


                    byte[] mypdffile = null;
                    string consql = "select 附件 from tb_caigouliaodan where id='" + id + "'and 名称='" + b + "' and  附件名称='" + fujian + "' ";
                    mypdffile = SQLhelp.duqu1(consql, CommandType.Text);


                    try
                    {
                        string aaaa = System.Environment.CurrentDirectory;
                        lujing = aaaa + "\\" + b + "." + leixing;
                        FileStream fs = new FileStream(lujing, FileMode.Create);
                        fs.Write(mypdffile, 0, mypdffile.Length);
                        fs.Flush();
                        fs.Close();
                    }
                    catch
                    {

                    }
                    this.Cursor = Cursors.Default;

                    System.Diagnostics.Process.Start(lujing);

                }
                if (fujian == "")
                {
                    MessageBox.Show("数据库没有该图纸！");
                    return;
                }
            }
            catch
            {

            }
        }


    }
}