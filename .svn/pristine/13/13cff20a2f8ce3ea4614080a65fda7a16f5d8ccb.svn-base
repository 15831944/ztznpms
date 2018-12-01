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
using System.Threading;

namespace ztznpms.UI.查询项目
{
    public partial class Formzonglan : DevExpress.XtraEditors.XtraForm
    {
        public Formzonglan()
        {
            InitializeComponent(); 
        }

        private void Formzonglan_Load(object sender, EventArgs e)
        {
            reload();


            DrawRowIndicator(gridView1, 40);
        }

        private void reload()
        {
            string sql1 = "select id,工作令号,项目名称,设备名称,项目主管,设备负责人,数量,时间,自制图纸总数量,图纸完成数量,备料总数量 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=0";
            DataTable dt = SQLhelp.GetDataTable1(sql1, CommandType.Text);


            //dt.Columns.Add("项目零件总数量");
            //dt.Columns.Add("自制件数量");
            dt.Columns.Add("自制件数量占比");
            dt.Columns.Add("自制件完成占比");



            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    string gongzuolinghao = dt.Rows[i]["工作令号"].ToString();
            //    string xiangmumingcheng = dt.Rows[i]["项目名称"].ToString();
            //    string shebeimingcheng = dt.Rows[i]["设备名称"].ToString();
            //    string shijian = dt.Rows[i]["时间"].ToString();

            //    string sql2 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "'";
            //    double ret2 = Convert.ToDouble(SQLhelp.ExecuteScalar1(sql2, CommandType.Text));

            //    string sql3 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' and 制造类型='自制零部件'";
            //    double ret3 = Convert.ToDouble(SQLhelp.ExecuteScalar1(sql3, CommandType.Text));

            //    string sql4 = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 时间='" + shijian + "' and 制造类型='自制零部件' and 生产部确认=1";
            //    double ret4 = Convert.ToDouble(SQLhelp.ExecuteScalar1(sql4, CommandType.Text));

            //    double a = Math.Round((ret3 / ret2) * 100, 2);
            //    double b = Math.Round((ret4 / ret3) * 100, 2);

            //    dt.Rows[i]["零件总数量"] = ret2.ToString();
            //    dt.Rows[i]["自制件数量"] = ret3.ToString();

            //    dt.Rows[i]["自制件数量占比"] = a.ToString() + '%';
            //    dt.Rows[i]["自制件完成占比"] = b.ToString() + '%';

            // }



            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string shebeiming = dt.Rows[i]["设备名称"].ToString();
            //    string aaaaa = dt.Rows[i]["工作令号"].ToString().Trim();
            //    dt.Rows[i]["工作令号"] = aaaaa + "                " + "设备名称：" + shebeiming + "               ";
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if(dr["备料总数量"].ToString() != "")
                {
                    dt.Rows[i]["自制件完成占比"] = Math.Round((Convert.ToDouble(dr["图纸完成数量"]) / Convert.ToDouble(dr["自制图纸总数量"])) * 100, 2).ToString() + '%';

                    dt.Rows[i]["自制件数量占比"] = Math.Round((Convert.ToDouble(dr["自制图纸总数量"]) / Convert.ToDouble(dr["备料总数量"])) * 100, 2).ToString() + '%';
                }



            }

            gridControl1.DataSource = dt;
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