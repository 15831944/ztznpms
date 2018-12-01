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

namespace ztznpms.UI.项目管理
{
    public partial class Formribaoshenhe : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public Formribaoshenhe()
        {
            InitializeComponent();
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
        private void Formribaoshenhe_Load(object sender, EventArgs e)
        {
            reload();

            DrawRowIndicator(gridView1, 50);
        }

        private void reload()
        {
            string sql = "select * from db_jijiagongribao where 标记=0";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;

            string sql1 = "select * from db_jijiagongribao where 标记=1";
            DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);
            gridControl2.DataSource = dt1;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formxiugairibao form = new Formxiugairibao();
            form.xuhao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
            form.zongshuliang= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["总数量"]).ToString();
            form.danjianjiage= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["单件薪酬"]).ToString();
            form.zongjiage= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["总薪酬"]).ToString();
            form.leixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["类型"]).ToString();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                this.reload();
            }
        }

        private void 确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult RSS = MessageBox.Show(this, "确定要审核通过吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:


                    DateTime time = DateTime.Now;

                    string id = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
                    string gonglinghao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
                    string xiangmumingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
                    string shebeimingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
                    string wanchengriqi= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["完成日期"]).ToString();
                    string xinghao= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["型号"]).ToString();
                    string mingcheng= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["名称"]).ToString();
                    string danjianjiage= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["单件薪酬"]).ToString();
                    string zongshuliang= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["总数量"]).ToString();
                    string gongzhong= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工种"]).ToString();
                    string zongjiage= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["总薪酬"]).ToString();
                    string wanchengren= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["完成人"]).ToString();

                    string SQL1 = "insert into tb_yixianbaobiao (工作令号,项目名称,设备名称,完成日期,型号,名称,单件薪酬,总数量,工种,总薪酬,完成人,记录人,记录时间) values('" + gonglinghao + "','" + xiangmumingcheng + "','" + shebeimingcheng + "','" + wanchengriqi + "','" + xinghao + "','" + mingcheng + "','" + danjianjiage + "','" + zongshuliang + "','" + gongzhong + "','" + zongjiage + "','" + wanchengren + "','" + yonghu + "','" + time + "')";
                    string RET1 = Convert.ToString(SQLhelp.ExecuteNonquery1(SQL1, CommandType.Text));
                    if(RET1 != "")
                    {
                        string SQL2 = "update db_jijiagongribao set 标记=1 where id='"+ id +"'";
                        string RET2 = Convert.ToString(SQLhelp.ExecuteNonquery(SQL2, CommandType.Text));
                        if(RET2 != "")
                        {
                            MessageBox.Show("确认成功！", "提示");
                            reload();
                        }
                    }

                    break;
                case DialogResult.No:
                    break;
            }

        }

        private void 分批次通过ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;

            Formfenpici form = new Formfenpici();
            form.xuhao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["id"]).ToString();
            form.zongshuliang = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["总数量"]).ToString();
            form.danjianjiage = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["单件薪酬"]).ToString();
            form.zongjiage = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["总薪酬"]).ToString();
            form.leixing = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["类型"]).ToString();
            form.yonghuming = yonghu;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                this.reload();
            }


        }

        /// <summary>
        /// 工令号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (textBoxItem1.Text == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }
            else
            {
                string sql1 = "select * from db_jijiagongribao where 标记=0 and [工作令号] like '%"+ textBoxItem1.Text.Trim() +"%'";
                DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl1.DataSource = dt1;
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (textBoxItem2.Text == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }
            else
            {
                string sql1 = "select * from db_jijiagongribao where 标记=0 and [名称] like '%" + textBoxItem2.Text.Trim() + "%'";
                DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl1.DataSource = dt1;
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (textBoxItem3.Text == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }
            else
            {
                string sql1 = "select * from db_jijiagongribao where 标记=0 and [型号] like '%" + textBoxItem3.Text.Trim() + "%'";
                DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                gridControl1.DataSource = dt1;
            }
        }

    }
}