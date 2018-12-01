using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ztznpms.UI.工序管理;
using ztznpms.UI.人员管理;
using ztznpms.Common;
using ztznpms.UI.查询项目;
using ztznpms.UI.图纸管理;

namespace ztznpms.UI.二维码
{
    public partial class FormGXgl : DevExpress.XtraEditors.XtraForm
    {
        public FormGXgl()
        {
            InitializeComponent();
        }

        private void FormGXgl_Load(object sender, EventArgs e)
        {
            reload();


            DrawRowIndicator(gridView1, 60);
        }

        private void reload()
        {
            string sql = "select id,工作令号,项目名称,设备名称,图号,名称,数量,生产部确认,时间,目前到达工序,工序1,工序2,工序3,工序4,工序5,工序6,工序7,工序8,工序9,工序10,工序11,工序12,工序13,工序14,工序15,工序16,工序17,工序18,工序19,工序20,工序21,工序22,工序23,工序24,工序25,number1 from db_xiangmu ";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);


            gridControl1.DataSource = dt1;


            toolStripComboBox1.Items.Clear();
            string SQL1 = "select 设备名称 from db_xiangmu";
            DataTable DT1 = SQLhelp.GetDataTable(SQL1, CommandType.Text);

            foreach (DataRow row in DT1.Rows)
            {
                string a = row["设备名称"].ToString();
                if (toolStripComboBox1.Items.Cast<object>().All(x => x.ToString() != a))
                    toolStripComboBox1.Items.Add(a);
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
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Formchejianrenyuan aa = new Formchejianrenyuan();
            aa.Show();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormAddmingchen a = new FormAddmingchen();
            a.Show();
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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void reloadTime()
        {
            string sql = "select 序号 from db_xiangmu";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                string sql1 = "select 工序名称,工序顺序,结束时间 from db_gongxu1 where 序号='" + dr["序号"] + "' order by 工序顺序 asc";
                string ret3 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));
                if (ret3 != "")//db_gongxu1有工序设置好了
                {
                    DataTable dt1 = SQLhelp.GetDataTable(sql1, CommandType.Text);

                    if (dt1.Rows.Count == 1)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 2)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 3)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 4)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 5)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 6)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 7)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 8)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 9)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 10)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 11)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 12)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 13)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 14)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "' where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 15)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 16)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 17)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 18)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 19)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "', 工序19 ='" + (dt1.Rows[18]["工序名称"].ToString() + dt1.Rows[18]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 20)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "', 工序19 ='" + (dt1.Rows[18]["工序名称"].ToString() + dt1.Rows[18]["结束时间"].ToString()) + "', 工序20 ='" + (dt1.Rows[19]["工序名称"].ToString() + dt1.Rows[19]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 21)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "', 工序19 ='" + (dt1.Rows[18]["工序名称"].ToString() + dt1.Rows[18]["结束时间"].ToString()) + "', 工序20 ='" + (dt1.Rows[19]["工序名称"].ToString() + dt1.Rows[19]["结束时间"].ToString()) + "', 工序21 ='" + (dt1.Rows[20]["工序名称"].ToString() + dt1.Rows[20]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 22)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "', 工序19 ='" + (dt1.Rows[18]["工序名称"].ToString() + dt1.Rows[18]["结束时间"].ToString()) + "', 工序20 ='" + (dt1.Rows[19]["工序名称"].ToString() + dt1.Rows[19]["结束时间"].ToString()) + "', 工序21 ='" + (dt1.Rows[20]["工序名称"].ToString() + dt1.Rows[20]["结束时间"].ToString()) + "', 工序22 ='" + (dt1.Rows[21]["工序名称"].ToString() + dt1.Rows[21]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 23)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "', 工序19 ='" + (dt1.Rows[18]["工序名称"].ToString() + dt1.Rows[18]["结束时间"].ToString()) + "', 工序20 ='" + (dt1.Rows[19]["工序名称"].ToString() + dt1.Rows[19]["结束时间"].ToString()) + "', 工序21 ='" + (dt1.Rows[20]["工序名称"].ToString() + dt1.Rows[20]["结束时间"].ToString()) + "', 工序22 ='" + (dt1.Rows[21]["工序名称"].ToString() + dt1.Rows[21]["结束时间"].ToString()) + "', 工序23 ='" + (dt1.Rows[22]["工序名称"].ToString() + dt1.Rows[22]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 24)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "', 工序19 ='" + (dt1.Rows[18]["工序名称"].ToString() + dt1.Rows[18]["结束时间"].ToString()) + "', 工序20 ='" + (dt1.Rows[19]["工序名称"].ToString() + dt1.Rows[19]["结束时间"].ToString()) + "', 工序21 ='" + (dt1.Rows[20]["工序名称"].ToString() + dt1.Rows[20]["结束时间"].ToString()) + "', 工序22 ='" + (dt1.Rows[21]["工序名称"].ToString() + dt1.Rows[21]["结束时间"].ToString()) + "', 工序23 ='" + (dt1.Rows[22]["工序名称"].ToString() + dt1.Rows[22]["结束时间"].ToString()) + "', 工序24 ='" + (dt1.Rows[23]["工序名称"].ToString() + dt1.Rows[23]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                    if (dt1.Rows.Count == 25)
                    {
                        string sql4 = "update db_xiangmu set 工序1 ='" + (dt1.Rows[0]["工序名称"].ToString() + dt1.Rows[0]["结束时间"].ToString()) + "', 工序2 ='" + (dt1.Rows[1]["工序名称"].ToString() + dt1.Rows[1]["结束时间"].ToString()) + "', 工序3 ='" + (dt1.Rows[2]["工序名称"].ToString() + dt1.Rows[2]["结束时间"].ToString()) + "', 工序4 ='" + (dt1.Rows[3]["工序名称"].ToString() + dt1.Rows[3]["结束时间"].ToString()) + "', 工序5 ='" + (dt1.Rows[4]["工序名称"].ToString() + dt1.Rows[4]["结束时间"].ToString()) + "', 工序6 ='" + (dt1.Rows[5]["工序名称"].ToString() + dt1.Rows[5]["结束时间"].ToString()) + "', 工序7 ='" + (dt1.Rows[6]["工序名称"].ToString() + dt1.Rows[6]["结束时间"].ToString()) + "', 工序8 ='" + (dt1.Rows[7]["工序名称"].ToString() + dt1.Rows[7]["结束时间"].ToString()) + "', 工序9 ='" + (dt1.Rows[8]["工序名称"].ToString() + dt1.Rows[8]["结束时间"].ToString()) + "', 工序10 ='" + (dt1.Rows[9]["工序名称"].ToString() + dt1.Rows[9]["结束时间"].ToString()) + "', 工序11 ='" + (dt1.Rows[10]["工序名称"].ToString() + dt1.Rows[10]["结束时间"].ToString()) + "', 工序12 ='" + (dt1.Rows[11]["工序名称"].ToString() + dt1.Rows[11]["结束时间"].ToString()) + "', 工序13 ='" + (dt1.Rows[12]["工序名称"].ToString() + dt1.Rows[12]["结束时间"].ToString()) + "', 工序14 ='" + (dt1.Rows[13]["工序名称"].ToString() + dt1.Rows[13]["结束时间"].ToString()) + "', 工序15 ='" + (dt1.Rows[14]["工序名称"].ToString() + dt1.Rows[14]["结束时间"].ToString()) + "', 工序16 ='" + (dt1.Rows[15]["工序名称"].ToString() + dt1.Rows[15]["结束时间"].ToString()) + "', 工序17 ='" + (dt1.Rows[16]["工序名称"].ToString() + dt1.Rows[16]["结束时间"].ToString()) + "', 工序18 ='" + (dt1.Rows[17]["工序名称"].ToString() + dt1.Rows[17]["结束时间"].ToString()) + "', 工序19 ='" + (dt1.Rows[18]["工序名称"].ToString() + dt1.Rows[18]["结束时间"].ToString()) + "', 工序20 ='" + (dt1.Rows[19]["工序名称"].ToString() + dt1.Rows[19]["结束时间"].ToString()) + "', 工序21 ='" + (dt1.Rows[20]["工序名称"].ToString() + dt1.Rows[20]["结束时间"].ToString()) + "', 工序22 ='" + (dt1.Rows[21]["工序名称"].ToString() + dt1.Rows[21]["结束时间"].ToString()) + "', 工序23 ='" + (dt1.Rows[22]["工序名称"].ToString() + dt1.Rows[22]["结束时间"].ToString()) + "', 工序24 ='" + (dt1.Rows[23]["工序名称"].ToString() + dt1.Rows[23]["结束时间"].ToString()) + "', 工序25 ='" + (dt1.Rows[24]["工序名称"].ToString() + dt1.Rows[24]["结束时间"].ToString()) + "'  where 序号='" + dr["序号"].ToString() + "'";
                        string ret4 = Convert.ToString(SQLhelp.ExecuteNonquery(sql4, CommandType.Text));
                    }
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            reloadTime();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            //toolStripComboBox1.Items.Clear();
            //string sql = "select 设备名称 from db_xiangmu ";
            //DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //foreach (DataRow row in dt.Rows)
            //{
            //    string a = row["设备名称"].ToString();
            //    if (toolStripComboBox1.Items.Cast<object>().All(x => x.ToString() != a))
            //        toolStripComboBox1.Items.Add(a);
            //}
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select id,工作令号,项目名称,设备名称,图号,名称,数量,生产部确认,时间,工序1,工序2,工序3,工序4,工序5,工序6,工序7,工序8,工序9,工序10,工序11,工序12,工序13,工序14,工序15,工序16,工序17,工序18,工序19,工序20,工序21,工序22,工序23,工序24,工序25,number1,目前到达工序 from db_xiangmu where [设备名称] like '%" + toolStripComboBox1.Text.Trim() + "%' ";
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);

            gridControl1.DataSource = dt1;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(toolStripComboBox1.Text.Trim() == "")
            {
                MessageBox.Show("设备名称不能为空！", "提示");
                return;
            }

            string sql = "select id,工作令号,项目名称,设备名称,图号,名称,数量,生产部确认,时间,工序1,工序2,工序3,工序4,工序5,工序6,工序7,工序8,工序9,工序10,工序11,工序12,工序13,工序14,工序15,工序16,工序17,工序18,工序19,工序20,工序21,工序22,工序23,工序24,工序25,number1 from db_xiangmu where 设备名称='" + toolStripComboBox1.Text.Trim() + "' ";//[设备名称] like '% " + toolStripComboBox1.Text.Trim() + " %'
            DataTable dt1 = SQLhelp.GetDataTable(sql, CommandType.Text);

            gridControl1.DataSource = dt1;
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formdayinyulan form1 = new Formdayinyulan();
            form1.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();
            form1.xiangmumingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
            form1.shebeimingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
            form1.shijian = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "时间").ToString();
            form1.ShowDialog();
        }

        private void 数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Formtongji form = new Formtongji();

                form.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();//this.gridView1.Columns[]
                form.shebeimincgheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                form.xiangmumingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.flag = "项目";
                form.Show();
            }
            catch
            {

            }
        }

        private void 信息大厅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Formmingxi form = new Formmingxi();

                form.gongzuolinghao = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "工作令号").ToString();
                form.shebeimincgheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "设备名称").ToString();
                form.xiangmumingcheng = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "项目名称").ToString();
                form.flag = "项目";
                form.Show();
            }
            catch
            {

            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow row = this.gridView1.GetDataRow(e.RowHandle);
            if (row == null) return;

            //string Status = row["is_enabled"].ToString();
            //if (Status == "0")
            //{
            //    e.Appearance.ForeColor = Color.Red;
            //    Font font = new Font(e.Appearance.Font, FontStyle.Italic | FontStyle.Strikeout);
            //    e.Appearance.Font = font;
            //}
        }


    }
}