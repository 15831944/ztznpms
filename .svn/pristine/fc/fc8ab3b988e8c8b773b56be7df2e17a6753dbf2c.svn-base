using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using ztznpms.Common;
using DevExpress.XtraCharts;

namespace ztznpms.UI.图纸管理
{
    public partial class Formjiagongqingkuang : DevExpress.XtraEditors.XtraForm
    {

        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string gongzuolinghao;
        public string shijian; 
        public Formjiagongqingkuang()
        {
            InitializeComponent();
        }


        private void Formjiagongqingkuang_Load(object sender, EventArgs e)
        {
            //string jiagongweiwancheng = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 制造类型='自制' and 生产部确认=1 and 加工确认=1  ";
            //tileItem1.Text = tileItem1.Text + " " + ExecuteScalar(jiagongweiwancheng, CommandType.Text).ToString();

            //string jiagongwancheng = "select count(*) from tb_jishubumen where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 技术部通过=1  and 制造类型='自制' and 生产部确认=1 and 加工确认=0  ";
            //tileItem2.Text = tileItem2.Text + " " + ExecuteScalar(jiagongwancheng, CommandType.Text).ToString();


            string a1 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='"+ shebeimingcheng + "'  and  工序名称='剪折'";
            string b1 = SQLhelp.ExecuteScalar(a1, CommandType.Text).ToString();
            string a2 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='水切割'";
            string b2 = SQLhelp.ExecuteScalar(a2, CommandType.Text).ToString();
            string a3 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='火焰切割'";
            string b3 = SQLhelp.ExecuteScalar(a3, CommandType.Text).ToString();
            string a4 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='车铣复合'";
            string b4 = SQLhelp.ExecuteScalar(a4, CommandType.Text).ToString();
            string a5 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='加工中心'";
            string b5 = SQLhelp.ExecuteScalar(a5, CommandType.Text).ToString();
            string a6 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='铣'";
            string b6 = SQLhelp.ExecuteScalar(a6, CommandType.Text).ToString();
            string a7 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='钻孔'";
            string b7 = SQLhelp.ExecuteScalar(a7, CommandType.Text).ToString();
            string a8 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='钻孔攻丝'";
            string b8 = SQLhelp.ExecuteScalar(a8, CommandType.Text).ToString();
            string a9 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='平磨'";
            string b9 = SQLhelp.ExecuteScalar(a9, CommandType.Text).ToString();
            string a10 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='外圆磨'";
            string b10 = SQLhelp.ExecuteScalar(a10, CommandType.Text).ToString();
            string a11 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='二保焊'";
            string b11 = SQLhelp.ExecuteScalar(a11, CommandType.Text).ToString();
            string a12 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='锯'";
            string b12 = SQLhelp.ExecuteScalar(a12, CommandType.Text).ToString();
            string a13 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='攻丝'";
            string b13 = SQLhelp.ExecuteScalar(a13, CommandType.Text).ToString();
            string a14 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='普车'";
            string b14 = SQLhelp.ExecuteScalar(a14, CommandType.Text).ToString();
            string a15 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='数车'";
            string b15 = SQLhelp.ExecuteScalar(a15, CommandType.Text).ToString();
            string a16 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='炮塔铣（键槽类）'";
            string b16 = SQLhelp.ExecuteScalar(a16, CommandType.Text).ToString();
            string a17 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='焊接（常规）'";
            string b17 = SQLhelp.ExecuteScalar(a17, CommandType.Text).ToString();
            string a18 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='氩弧焊'";
            string b18 = SQLhelp.ExecuteScalar(a18, CommandType.Text).ToString();
            string a19 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='焊接（不锈钢）'";
            string b19 = SQLhelp.ExecuteScalar(a19, CommandType.Text).ToString();
            string a20 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='外协'";
            string b20 = SQLhelp.ExecuteScalar(a20, CommandType.Text).ToString();
            string a21 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='漆'";
            string b21 = SQLhelp.ExecuteScalar(a21, CommandType.Text).ToString();
            string a22 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='线切割'";
            string b22 = SQLhelp.ExecuteScalar(a22, CommandType.Text).ToString();
            string a23 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='刻字'";
            string b23 = SQLhelp.ExecuteScalar(a23, CommandType.Text).ToString();
            string a24 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='立车'";
            string b24 = SQLhelp.ExecuteScalar(a24, CommandType.Text).ToString();
            string a25 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='龙门铣'";
            string b25 = SQLhelp.ExecuteScalar(a25, CommandType.Text).ToString();
            string a26 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='电火花'";
            string b26 = SQLhelp.ExecuteScalar(a26, CommandType.Text).ToString();
            string a27 = "select count(*) from db_gongxu1 where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "'  and  工序名称='镗床'";
            string b27 = SQLhelp.ExecuteScalar(a27, CommandType.Text).ToString();

            DataTable bing1 = new DataTable();
            bing1.Columns.Add("name", typeof(string));
            bing1.Columns.Add("value", typeof(double));
            DataRow newRoww;
            newRoww = bing1.NewRow();
            newRoww["name"] = "剪折";
            newRoww["value"] = b1;
            bing1.Rows.Add(newRoww);

            DataRow newRoww1;
            newRoww1 = bing1.NewRow();
            newRoww1["name"] = "水切割";
            newRoww1["value"] = b2;
            bing1.Rows.Add(newRoww1);

            DataRow newRoww2;
            newRoww2 = bing1.NewRow();
            newRoww2["name"] = "火焰切割";
            newRoww2["value"] = b3;
            bing1.Rows.Add(newRoww2);

            DataRow newRoww3;
            newRoww3 = bing1.NewRow();
            newRoww3["name"] = "车铣复合";
            newRoww3["value"] = b4;
            bing1.Rows.Add(newRoww3);

            DataRow newRoww4;
            newRoww4 = bing1.NewRow();
            newRoww4["name"] = "加工中心";
            newRoww4["value"] = b5;
            bing1.Rows.Add(newRoww4);

            DataRow newRoww5;
            newRoww5 = bing1.NewRow();
            newRoww5["name"] = "铣";
            newRoww5["value"] = b6;
            bing1.Rows.Add(newRoww5);

            DataRow newRoww6;
            newRoww6 = bing1.NewRow();
            newRoww6["name"] = "钻孔";
            newRoww6["value"] = b7;
            bing1.Rows.Add(newRoww6);

            DataRow newRoww7;
            newRoww7 = bing1.NewRow();
            newRoww7["name"] = "钻孔攻丝";
            newRoww7["value"] = b8;
            bing1.Rows.Add(newRoww7);

            DataRow newRoww8;
            newRoww8 = bing1.NewRow();
            newRoww8["name"] = "平磨";
            newRoww8["value"] = b9;
            bing1.Rows.Add(newRoww8);

            DataRow newRoww9;
            newRoww9 = bing1.NewRow();
            newRoww9["name"] = "外圆磨";
            newRoww9["value"] = b10;
            bing1.Rows.Add(newRoww9);

            DataRow newRoww10;
            newRoww10 = bing1.NewRow();
            newRoww10["name"] = "二保焊";
            newRoww10["value"] = b11;
            bing1.Rows.Add(newRoww10);

            DataRow newRoww11;
            newRoww11 = bing1.NewRow();
            newRoww11["name"] = "锯";
            newRoww11["value"] = b12;
            bing1.Rows.Add(newRoww11);

            DataRow newRoww12;
            newRoww12 = bing1.NewRow();
            newRoww12["name"] = "攻丝";
            newRoww12["value"] = b13;
            bing1.Rows.Add(newRoww12);

            DataRow newRoww13;
            newRoww13 = bing1.NewRow();
            newRoww13["name"] = "普车";
            newRoww13["value"] = b1;
            bing1.Rows.Add(newRoww13);

            DataRow newRoww14;
            newRoww14 = bing1.NewRow();
            newRoww14["name"] = "数车";
            newRoww14["value"] = b14;
            bing1.Rows.Add(newRoww14);

            DataRow newRoww15;
            newRoww15 = bing1.NewRow();
            newRoww15["name"] = "炮塔铣（键槽类）";
            newRoww15["value"] = b15;
            bing1.Rows.Add(newRoww15);

            DataRow newRoww16;
            newRoww16 = bing1.NewRow();
            newRoww16["name"] = "焊接（常规）";
            newRoww16["value"] = b16;
            bing1.Rows.Add(newRoww16);

            DataRow newRoww17;
            newRoww17 = bing1.NewRow();
            newRoww17["name"] = "氩弧焊";
            newRoww17["value"] = b17;
            bing1.Rows.Add(newRoww17);

            DataRow newRoww18;
            newRoww18 = bing1.NewRow();
            newRoww18["name"] = "焊接（不锈钢）";
            newRoww18["value"] = b18;
            bing1.Rows.Add(newRoww18);

            DataRow newRoww19;
            newRoww19 = bing1.NewRow();
            newRoww19["name"] = "外协";
            newRoww19["value"] = b19;
            bing1.Rows.Add(newRoww19);

            DataRow newRoww20;
            newRoww20 = bing1.NewRow();
            newRoww20["name"] = "漆";
            newRoww20["value"] = b20;
            bing1.Rows.Add(newRoww20);

            DataRow newRoww21;
            newRoww21 = bing1.NewRow();
            newRoww21["name"] = "线切割";
            newRoww21["value"] = b21;
            bing1.Rows.Add(newRoww21);

            DataRow newRoww22;
            newRoww22 = bing1.NewRow();
            newRoww22["name"] = "刻字";
            newRoww22["value"] = b22;
            bing1.Rows.Add(newRoww22);

            DataRow newRoww23;
            newRoww23 = bing1.NewRow();
            newRoww23["name"] = "立车";
            newRoww23["value"] = b23;
            bing1.Rows.Add(newRoww23);


            DataRow newRoww24;
            newRoww24 = bing1.NewRow();
            newRoww24["name"] = "龙门铣";
            newRoww24["value"] = b24;
            bing1.Rows.Add(newRoww24);

            DataRow newRoww25;
            newRoww25 = bing1.NewRow();
            newRoww25["name"] = "电火花";
            newRoww25["value"] = b25;
            bing1.Rows.Add(newRoww25);

            DataRow newRoww26;
            newRoww26 = bing1.NewRow();
            newRoww26["name"] = "镗床";
            newRoww26["value"] = b26;
            bing1.Rows.Add(newRoww26);

            Series Seriess2 = new Series("种类分布", ViewType.Doughnut);
            Seriess2.ArgumentScaleType = ScaleType.Qualitative;
            Seriess2.ArgumentDataMember = "name";
            Seriess2.ValueDataMembers[0] = "value";
            Seriess2.DataSource = bing1;

            chartControl1.Series.Add(Seriess2);

            chartControl1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;

        }

    }
}