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
using DevExpress.XtraCharts;

namespace ztznpms.UI.图纸管理
{
    public partial class Formtongji : DevExpress.XtraEditors.XtraForm
    {
        public string gongzuolinghao;
        public string shebeimincgheng;
        public string xiangmumingcheng;
        public string flag;

        DataTable dt = new DataTable();
        public Formtongji()
        {
            InitializeComponent();
        }

        private void Formtongji_Load(object sender, EventArgs e)
        {
            try
            {
                ////拿到每个设备的所需要的工序名称
                //string sql = "select 工序名称 from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 设备名称='" + shebeimincgheng + "' and 项目名称='" + xiangmumingcheng + "'";
                //DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);

                //for (int i = 0; i < dtt.Rows.Count; i++)
                //{
                //    DataRow dr = dtt.Rows[i];
                //    string sqltime = "select sum(价格*数量) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 设备名称='" + shebeimincgheng + "' and 项目名称='" + xiangmumingcheng + "' and 工序名称='"+ dr["工序名称"]+"'";
                //    dt = SQLhelp.GetDataTable(sqltime, CommandType.Text);


                //}

                if (flag == "项目")
                {
                    string SQL1 = "select 工序名称,sum(价格*数量) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 设备名称='" + shebeimincgheng + "' and 项目名称='" + xiangmumingcheng + "' group by 工序名称 order by sum(价格*数量) asc";
                    dt = SQLhelp.GetDataTable(SQL1, CommandType.Text);
                    dt.Columns.Add("总价格");
                    dt.Columns.Add("工时");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        dt.Rows[i]["工时"] = Math.Round(((double)dr[1] / 27), 2).ToString() + "小时";//算出每道工序的工时
                        dt.Rows[i]["总价格"] = dr[1].ToString();
                    }

                    Series Series1 = new Series(dt.Rows[0][0].ToString(), ViewType.Bar);
                    Series1.ArgumentScaleType = ScaleType.Qualitative;

                    DataTable table = new DataTable();
                    table.Columns.Add("Name", typeof(String));
                    table.Columns.Add("Value", typeof(Double));
                    foreach (DataRow item in dt.Rows)
                    {
                        var array = new object[] { item[0], item[1] };
                        table.Rows.Add(array);
                    }


                    Series1.ArgumentDataMember = "Name";
                    Series1.ValueDataMembers[0] = "Value";
                    Series1.DataSource = table;

                    chartControl1.Series.Add(Series1);

                    gridControl1.DataSource = dt;
                    gridView1.Columns[1].Visible = false;


                    DrawRowIndicator(gridView1, 35);

                    string sql1 = "select sum(价格*数量) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 设备名称='" + shebeimincgheng + "' and 项目名称='" + xiangmumingcheng + "'";
                    string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                    tileItem7.Text = tileItem7.Text + ret1 + '元';

                }

                if (flag == "机修")
                {
                    string SQL1 = "select 工序名称,sum(价格*机修件数量) from db_gongxu111 where 接单编号='" + gongzuolinghao + "' and 客户名称='" + shebeimincgheng + "' and 工件名称='" + xiangmumingcheng + "' group by 工序名称 order by sum(价格*机修件数量) asc";
                    dt = SQLhelp.GetDataTable(SQL1, CommandType.Text);
                    dt.Columns.Add("总价格");
                    dt.Columns.Add("工时");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        dt.Rows[i]["工时"] = Math.Round(((double)dr[1] / 27), 2).ToString() + "小时";//算出每道工序的工时
                        dt.Rows[i]["总价格"] = dr[1].ToString();
                    }

                    Series Series1 = new Series(dt.Rows[0][0].ToString(), ViewType.Bar);
                    Series1.ArgumentScaleType = ScaleType.Qualitative;

                    DataTable table = new DataTable();
                    table.Columns.Add("Name", typeof(String));
                    table.Columns.Add("Value", typeof(Double));
                    foreach (DataRow item in dt.Rows)
                    {
                        var array = new object[] { item[0], item[1] };
                        table.Rows.Add(array);
                    }


                    Series1.ArgumentDataMember = "Name";
                    Series1.ValueDataMembers[0] = "Value";
                    Series1.DataSource = table;

                    chartControl1.Series.Add(Series1);

                    gridControl1.DataSource = dt;
                    gridView1.Columns[1].Visible = false;


                    DrawRowIndicator(gridView1, 35);

                    string sql1 = "select sum(价格*机修件数量) from db_gongxu111 where 接单编号='" + gongzuolinghao + "' and 客户名称='" + shebeimincgheng + "' and 工件名称='" + xiangmumingcheng + "'";
                    string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

                    tileItem7.Text = tileItem7.Text + ret1 + '元';

                }

            }
            catch
            {

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
            //if (e.Info.IsRowIndicator && e.RowHandle > -1)
            //{
            //    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //}

            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }
    }
}