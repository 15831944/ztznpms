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

namespace ztznpms.UI.查询项目
{
    public partial class Formchengpinruku : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public Formchengpinruku()
        {
            InitializeComponent();
        }

        private void Formchengpinruku_Load(object sender, EventArgs e)
        {
            reload2();

            DrawRowIndicator(gridView1, 35);
            DrawRowIndicator1(gridView2, 35);
        }
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,名称,型号,制造类型,单位,实际采购数量,成品入库数量 from tb_caigouliaodan where [工作令号] like '%" + toolStripTextBox1.Text.Trim() + "%' ";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            this.gridControl1.DataSource = dt;
            this.gridView1.Columns["id"].Visible = false;
        }

        private void reload()
        {
            string sql = "select id,工作令号,项目名称,名称,型号,制造类型,单位,实际采购数量,成品入库数量 from tb_caigouliaodan where [工作令号] like '%" + toolStripTextBox1.Text.Trim() + "%' ";
            DataTable dt = SQLhelp.GetDataTable1(sql, CommandType.Text);
            this.gridControl1.DataSource = dt;
            this.gridView1.Columns["id"].Visible = false;
        }

        private void reload2()
        {
            string sql = "select id,工作令号,项目名称,名称,型号,制造类型,单位,实际采购数量,成品入库数量 from db_chengpinku";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.gridControl2.DataSource = dt;
            this.gridView2.Columns["id"].Visible = false;
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
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            foreach (int i in a)
            {
                string id = gridView1.GetRowCellValue(i, "id").ToString();
                string shuliangStr1 = gridView1.GetRowCellValue(i, "实际采购数量").ToString();
                string shuliangStr2 = gridView1.GetRowCellValue(i, "成品入库数量").ToString();
                string mingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                string gongzuolinghao= gridView1.GetRowCellValue(i, "工作令号").ToString();
                string danwei= gridView1.GetRowCellValue(i, "单位").ToString();
                string xinghao= gridView1.GetRowCellValue(i, "型号").ToString();
                string xiangmumingcheng= gridView1.GetRowCellValue(i, "项目名称").ToString();
                string zhizaoleiixng= gridView1.GetRowCellValue(i, "制造类型").ToString();

                if (shuliangStr1 != "" && shuliangStr2 != "")//只有当实际采购数量和成品入库数量不为空时
                {
                    string sql1 = "select * from db_chengpinku where 序号='" + id + "'";
                    string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                    if (ret1 == "")//还没有插入db_chengpinku表
                    {
                        if(Convert.ToDouble( shuliangStr2) <= Convert.ToDouble( shuliangStr1))
                        {
                            string sql2 = "update tb_caigouliaodan set 成品入库数量='" + shuliangStr2 + "' where id='" + id + "'";
                            SQLhelp.ExecuteNonquery1(sql2, CommandType.Text);

                            string sql3 = "insert into db_chengpinku(工作令号,项目名称,名称,型号,制造类型,单位,实际采购数量,成品入库数量,序号) values('" + gongzuolinghao + "','" + xiangmumingcheng + "','" + mingcheng + "','" + xinghao + "','" + zhizaoleiixng + "','" + danwei + "','" + shuliangStr1 + "','" + shuliangStr2 + "','" + id + "')";
                            SQLhelp.ExecuteNonquery(sql3, CommandType.Text);
                        }
                        else
                        {
                            MessageBox.Show("'" + mingcheng + "' 入库数量不得大于加工数量！", "提示");
                            reload();
                            return;
                        }

                    }
                    else//曾经入过库了
                    {
                        string sql4 = "select 成品入库数量 from tb_caigouliaodan where id='"+ id +"'";
                        double ret4 = Convert.ToDouble(SQLhelp.ExecuteScalar1(sql4, CommandType.Text));//查出入库数量

                        double shuliang = ret4 + Convert.ToDouble(shuliangStr2);
                        if(shuliang <= Convert.ToDouble(shuliangStr1))
                        {
                            string sql2 = "update tb_caigouliaodan set 成品入库数量='" + shuliang + "' where id='" + id + "'";
                            SQLhelp.ExecuteNonquery1(sql2, CommandType.Text);

                            string sql5 = "update db_chengpinku set 成品入库数量='"+ shuliang +"' where 序号='"+ id +"'";
                            SQLhelp.ExecuteNonquery(sql5, CommandType.Text);
                        }
                        else
                        {
                            MessageBox.Show("'" + mingcheng + "' 入库数量不得大于加工数量！", "提示");
                            reload();
                            return;
                        }
                    }
                }


            }
            MessageBox.Show("入库成功！");
            this.gridView1.Columns.Clear();
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
    }
}