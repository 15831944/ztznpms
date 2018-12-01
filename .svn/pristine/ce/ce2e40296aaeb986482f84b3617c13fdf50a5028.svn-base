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
    public partial class Formjixiugxgl : DevExpress.XtraEditors.XtraForm
    {
        public Formjixiugxgl()
        {
            InitializeComponent();
        }

        private void Formjixiugxgl_Load(object sender, EventArgs e)
        {
            reload();
            DrawRowIndicator(gridView1, 60);
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
            string sql = "select id,接单编号,客户名称,部门,工件名称,加工内容,机修件数量,目前到达工序,工序1,工序2,工序3,工序4,工序5,工序6,工序7,工序8,工序9,工序10,工序11,工序12,工序13,工序14,工序15,工序16,工序17,工序18,工序19,工序20,工序21,工序22,工序23,工序24,工序25 from db_jixiujian ";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);

            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{
            //    string gonglinghao = dt1.Rows[i]["项目名称"].ToString();
            //    string aaaaa = dt1.Rows[i]["工作令号"].ToString().Trim();
            //    dt1.Rows[i]["工作令号"] = aaaaa + "                " + "项目名称：" + gonglinghao + "               ";
            //}

            gridControl1.DataSource = dt1;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 导出Excel表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl1.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 导入机修件工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select * from db_jixiujian";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string sql1 = "select 工序名称 from db_gongxu111 where 序号='" + dr["序号"] + "'";
                string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                if (ret1 != "")
                {
                    DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt1.Rows.Count == 1)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 2)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 3)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 4)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 5)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 6)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 7)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 8)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 9)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 10)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 11)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 12)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 13)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 14)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 15)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 16)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 17)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 18)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 19)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 20)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 21)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 22)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 23)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序23 ='" + dt1.Rows[22]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 24)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 25)
                    {
                        string sql4 = "update db_jixiujian set 工序1 ='" + dt1.Rows[0]["工序名称"].ToString() + "', 工序2 ='" + dt1.Rows[1]["工序名称"].ToString() + "', 工序3 ='" + dt1.Rows[2]["工序名称"].ToString() + "', 工序4 ='" + dt1.Rows[3]["工序名称"].ToString() + "', 工序5 ='" + dt1.Rows[4]["工序名称"].ToString() + "', 工序6 ='" + dt1.Rows[5]["工序名称"].ToString() + "', 工序7 ='" + dt1.Rows[6]["工序名称"].ToString() + "', 工序8 ='" + dt1.Rows[7]["工序名称"].ToString() + "', 工序9 ='" + dt1.Rows[8]["工序名称"].ToString() + "', 工序10 ='" + dt1.Rows[9]["工序名称"].ToString() + "', 工序11 ='" + dt1.Rows[10]["工序名称"].ToString() + "', 工序12 ='" + dt1.Rows[11]["工序名称"].ToString() + "', 工序13 ='" + dt1.Rows[12]["工序名称"].ToString() + "', 工序14 ='" + dt1.Rows[13]["工序名称"].ToString() + "', 工序15 ='" + dt1.Rows[14]["工序名称"].ToString() + "', 工序16 ='" + dt1.Rows[15]["工序名称"].ToString() + "', 工序17 ='" + dt1.Rows[16]["工序名称"].ToString() + "', 工序18 ='" + dt1.Rows[17]["工序名称"].ToString() + "', 工序19 ='" + dt1.Rows[18]["工序名称"].ToString() + "', 工序20 ='" + dt1.Rows[19]["工序名称"].ToString() + "', 工序21 ='" + dt1.Rows[20]["工序名称"].ToString() + "', 工序22 ='" + dt1.Rows[21]["工序名称"].ToString() + "', 工序24 ='" + dt1.Rows[23]["工序名称"].ToString() + "', 工序25 ='" + dt1.Rows[24]["工序名称"].ToString() + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery1(sql4, CommandType.Text));
                    }
                }
            }
        }
    }
}