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

namespace ztznpms.UI.检验
{
    public partial class Formcaigoushenqing : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dt = new DataTable();
        public DataTable dt1 = new DataTable();
        public string[] array;
        public string yonghuming;
        public Formcaigoushenqing()
        {
            InitializeComponent();
        }

        private void Formcaigoushenqing_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            dt1.Columns.Add("项目名称", typeof(string));
            dt1.Columns.Add("设备名称", typeof(string));
            dt1.Columns.Add("工作令号", typeof(string));
            dt1.Columns.Add("材料名称", typeof(string));
            dt1.Columns.Add("型号", typeof(string));
            dt1.Columns.Add("编码", typeof(string));
            dt1.Columns.Add("单位", typeof(string));
            dt1.Columns.Add("数量", typeof(float));
            dt1.Columns.Add("类型", typeof(string));
            dt1.Columns.Add("备注", typeof(string));
            dt1.Columns.Add("要求到货日期", typeof(DateTime));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataRow row = dt1.NewRow();
                row["项目名称"] = dr["项目名称"];
                row["设备名称"] = dr["设备名称"];
                row["工作令号"] = dr["工作令号"];
                row["材料名称"] = dr["材料名称"];
                row["型号"] = dr["型号"];
                row["编码"] = dr["编码"];
                row["单位"] = dr["单位"];
                row["数量"] = dr["数量"];
                row["类型"] = dr["类型"];
                row["备注"] = dr["备注"];
                row["要求到货日期"] = dr["要求到货日期"];

                dt1.Rows.Add(row);
            }

            gridControl1.DataSource = dt;

            DrawRowIndicator(gridView1, 40);
        }

        private void 生成采购单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < this.gridView1.RowCount; i++)
            //{
            //    double Oldshuliang = (Convert.ToDouble(dt1.Rows[i]["数量"])) * 1.2;

            //    DataRow dr = this.gridView1.GetDataRow(i);//遍历每行
            //    double shuliang = Convert.ToDouble(dr["数量"]);//当前行数量
            //    if (shuliang > Oldshuliang || shuliang <= 0)
            //    {
            //        MessageBox.Show("第" + (i + 1) + "行数量超出范围！", "提示");
            //        return;
            //    }
            //}

            if (this.gridView1.RowCount > 0)
            {

                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    float a = 0;
                    if (float.TryParse(gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["数量"]).ToString(), out a) == false)
                    {
                        MessageBox.Show("数量必须是数字！");
                        return;
                    }


                }

                DialogResult RSS = MessageBox.Show(this, "确定提交采购单？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (RSS)
                {
                    case DialogResult.Yes:

                        for (int i = 0; i < this.gridView1.RowCount; i++)
                        {
                            string timeyuancailiao = DateTime.Now.AddDays(3).ToString();

                            string sql = "insert into tb_caigouliaodan (工作令号,编码,新编码,型号,名称,单位,数量,类型,要求到货日期1,备注,申购人,实际采购数量,收到料单日期,料单类型,到货情况,采购类型,采购负责人)  values ('" + gridView1.GetRowCellValue(i, "工作令号").ToString() + "','" + gridView1.GetRowCellValue(i, "编码").ToString() + "','" + gridView1.GetRowCellValue(i, "编码").ToString() + "','" + gridView1.GetRowCellValue(i, "型号").ToString() + "','" + gridView1.GetRowCellValue(i, "材料名称").ToString() + "','" + gridView1.GetRowCellValue(i, "单位").ToString() + "','" + gridView1.GetRowCellValue(i, "数量").ToString() + "','" + gridView1.GetRowCellValue(i, "类型").ToString() + "','" + timeyuancailiao + "','" + gridView1.GetRowCellValue(i, "备注").ToString() + "','" + yonghuming + "','" + gridView1.GetRowCellValue(i, "数量").ToString() + "','" + DateTime.Now + "','原材料',0,'原材料','缪星鑫')  ";
                            SQLhelp.ExecuteNonquery1(sql, CommandType.Text);

                        }

                        MessageBox.Show("采购单生成成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                        break;
                    case DialogResult.No:
                        break;
                }

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
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}