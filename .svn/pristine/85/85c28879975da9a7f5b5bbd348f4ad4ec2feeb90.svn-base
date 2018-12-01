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

namespace ztznpms.UI.工序管理
{
    public partial class FormPaigongdanData : DevExpress.XtraEditors.XtraForm
    {
        public string flag;

        DataTable dt = new DataTable();
        public string t1;
        public string t2;
        public FormPaigongdanData()
        {
            InitializeComponent();
        }

        private void FormPaigongdanData_Load(object sender, EventArgs e)
        {
            if(flag == "全部")
            {
                DateTime time1 = Convert.ToDateTime(t1);
                DateTime time2 = Convert.ToDateTime(t2);

                string SQL1 = "select 设备名称,总价格 from tb_Paigongdan where 下达时间>='" + time1 + "' and 下达时间<='" + time2 + "'";// group by 设备名称 order by sum(价格*数量) asc";
                dt = SQLhelp.GetDataTable1(SQL1, CommandType.Text);

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    DataRow dr = dt.Rows[i];
                //    dt.Rows[i]["工时"] = Math.Round(((double)dr[1] / 27), 2).ToString() + "小时";//算出每道工序的工时
                //    dt.Rows[i]["总价格"] = dr[1].ToString();
                //}

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

                chartControl2.Series.Add(Series1);

                gridControl2.DataSource = dt;
                //gridView2.Columns[1].Visible = false;


                DrawRowIndicator(gridView2, 50);

                string sql1 = "select sum(总价格) from tb_Paigongdan where 下达时间>='" + time1 + "' and 下达时间<='" + time2 + "'";
                string ret1 = Convert.ToString(SQLhelp.ExecuteScalar1(sql1, CommandType.Text));

                tileItem7.Text = time1.ToString("yyyy/MM/dd") + " 到 " + "\n" + time2.ToString("yyyy/MM/dd") + " 的 " + "\n" + tileItem7.Text + ret1 + '元';
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        public void DrawRowIndicator(DevExpress.XtraGrid.Views.Grid.GridView gv, int width)
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