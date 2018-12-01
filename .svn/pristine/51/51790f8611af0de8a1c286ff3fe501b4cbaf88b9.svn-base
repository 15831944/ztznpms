using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using ztznpms.Common;
using System.Data.SqlClient;

namespace ztznpms.UI.图纸管理
{
    public partial class Formmingxi : DevExpress.XtraEditors.XtraForm
    {
        public string gongzuolinghao;
        public string shebeimincgheng;
        public string xiangmumingcheng;
        public string flag;
        public Formmingxi()
        {
            InitializeComponent();
        }

        private void Formmingxi_Load(object sender, EventArgs e)
        {
            try
            {
                if(flag == "项目")
                {
                    string sql = "select 工序名称,数量 from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 设备名称='" + shebeimincgheng + "' and 项目名称='" + xiangmumingcheng + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    Series Series1 = new Series(dtt.Rows[0][0].ToString(), ViewType.Bar);
                    Series1.ArgumentScaleType = ScaleType.Qualitative;
                    for (int j = 0; j < dtt.Rows.Count; j++)
                    {
                        string b = Convert.ToString(dtt.Rows[j]["数量"]);
                        if (b == "")
                        {
                            dtt.Rows[j]["数量"] = 0;
                        }
                    }
                    DataTable table = new DataTable();
                    table.Columns.Add("Name", typeof(String));
                    table.Columns.Add("Value", typeof(Double));
                    foreach (DataRow item in dtt.Rows)
                    {
                        var array = new object[] { item["工序名称"], item["数量"] };
                        table.Rows.Add(array);
                    }


                    Series1.ArgumentDataMember = "Name";
                    Series1.ValueDataMembers[0] = "Value";
                    Series1.DataSource = table;

                    chartControl1.Series.Add(Series1);



                    string WeiwanchengCount = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=0 ";
                    string weiwancheng = SQLhelp.ExecuteScalar1(WeiwanchengCount, CommandType.Text).ToString();

                    string WanchengCount = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=1 ";
                    string wancheng = SQLhelp.ExecuteScalar1(WanchengCount, CommandType.Text).ToString();

                    DataTable bing = new DataTable();
                    bing.Columns.Add("name", typeof(string));
                    bing.Columns.Add("value", typeof(double));
                    DataRow newRow;
                    newRow = bing.NewRow();
                    newRow["name"] = "未完成";
                    newRow["value"] = weiwancheng;
                    bing.Rows.Add(newRow);

                    DataRow newRow1;
                    newRow1 = bing.NewRow();
                    newRow1["name"] = "完成";
                    newRow1["value"] = wancheng;
                    bing.Rows.Add(newRow1);

                    Series Series2 = new Series("种类分布", ViewType.Pie);
                    Series2.ArgumentScaleType = ScaleType.Qualitative;
                    Series2.ArgumentDataMember = "name";
                    Series2.ValueDataMembers[0] = "value";
                    Series2.DataSource = bing;

                    chartControl3.Series.Add(Series2);

                    chartControl3.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;

                    string jiagongzongshu = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' ";
                    tileItem7.Text = tileItem7.Text + " " + SQLhelp.ExecuteScalar1(jiagongzongshu, CommandType.Text).ToString();

                    string jiagongwancheng = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=1";
                    tileItem5.Text = tileItem5.Text + " " + SQLhelp.ExecuteScalar1(jiagongwancheng, CommandType.Text).ToString();

                    string jiagongweiwancheng = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=0";
                    tileItem9.Text = tileItem9.Text + " " + SQLhelp.ExecuteScalar1(jiagongweiwancheng, CommandType.Text).ToString();
                }

                if(flag == "机修")
                {
                    string sql = "select 工序名称,机修件数量 from db_gongxu111 where 接单编号='" + gongzuolinghao + "' and 客户名称='" + shebeimincgheng + "' and 工件名称='" + xiangmumingcheng + "'";
                    DataTable dtt = SQLhelp.GetDataTable(sql, CommandType.Text);
                    Series Series1 = new Series(dtt.Rows[0][0].ToString(), ViewType.Bar);
                    Series1.ArgumentScaleType = ScaleType.Qualitative;
                    for (int j = 0; j < dtt.Rows.Count; j++)
                    {
                        string b = Convert.ToString(dtt.Rows[j]["机修件数量"]);
                        if (b == "")
                        {
                            dtt.Rows[j]["机修件数量"] = 0;
                        }
                    }
                    DataTable table = new DataTable();
                    table.Columns.Add("Name", typeof(String));
                    table.Columns.Add("Value", typeof(Double));
                    foreach (DataRow item in dtt.Rows)
                    {
                        var array = new object[] { item["工序名称"], item["机修件数量"] };
                        table.Rows.Add(array);
                    }


                    Series1.ArgumentDataMember = "Name";
                    Series1.ValueDataMembers[0] = "Value";
                    Series1.DataSource = table;

                    chartControl1.Series.Add(Series1);



                    //string WeiwanchengCount = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=0 ";
                    //string weiwancheng = SQLhelp.ExecuteScalar1(WeiwanchengCount, CommandType.Text).ToString();

                    //string WanchengCount = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=1 ";
                    //string wancheng = SQLhelp.ExecuteScalar1(WanchengCount, CommandType.Text).ToString();

                    //DataTable bing = new DataTable();
                    //bing.Columns.Add("name", typeof(string));
                    //bing.Columns.Add("value", typeof(double));
                    //DataRow newRow;
                    //newRow = bing.NewRow();
                    //newRow["name"] = "未完成";
                    //newRow["value"] = weiwancheng;
                    //bing.Rows.Add(newRow);

                    //DataRow newRow1;
                    //newRow1 = bing.NewRow();
                    //newRow1["name"] = "完成";
                    //newRow1["value"] = wancheng;
                    //bing.Rows.Add(newRow1);

                    //Series Series2 = new Series("种类分布", ViewType.Pie);
                    //Series2.ArgumentScaleType = ScaleType.Qualitative;
                    //Series2.ArgumentDataMember = "name";
                    //Series2.ValueDataMembers[0] = "value";
                    //Series2.DataSource = bing;

                    //chartControl3.Series.Add(Series2);

                    //chartControl3.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;

                    //string jiagongzongshu = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' ";
                    //tileItem7.Text = tileItem7.Text + " " + SQLhelp.ExecuteScalar1(jiagongzongshu, CommandType.Text).ToString();

                    //string jiagongwancheng = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=1";
                    //tileItem5.Text = tileItem5.Text + " " + SQLhelp.ExecuteScalar1(jiagongwancheng, CommandType.Text).ToString();

                    //string jiagongweiwancheng = "select count(*) from tb_caigouliaodan where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimincgheng + "' and  制造类型='自制零部件' and 生产部确认=0";
                    //tileItem9.Text = tileItem9.Text + " " + SQLhelp.ExecuteScalar1(jiagongweiwancheng, CommandType.Text).ToString();
                }
                
            }
            catch
            {

            }
           
        }
    }
}