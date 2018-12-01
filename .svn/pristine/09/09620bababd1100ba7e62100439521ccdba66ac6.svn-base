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
    public partial class Formgongyi : DevExpress.XtraEditors.XtraForm
    {
        public Formgongyi()
        {
            InitializeComponent();
        }

        private void Formgongyi_Load(object sender, EventArgs e)
        {

            //reload1();
            DrawRowIndicator(gridView1, 40);
        }

        private void reload1()
        {
            string sql = " select a.id,a.number,a.工作令号,a.项目名称,a.设备名称,a.项目主管,a.设备负责人,a.数量,a.时间 from db_xiangmujinxing a, db_xiangmu b where b.工作令号 = a.工作令号 and b.项目名称 = b.项目名称 and b.设备名称 = a.设备名称 and b.时间 = a.时间 and b.工序1 IS NOT NULL";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            //将dt中的重复数据过滤掉  
            DataView myDataView = new DataView(dt);
            //此处可加任意数据项组合  
            string[] strComuns = { "id", "number", "工作令号", "项目名称", "设备名称", "项目主管", "设备负责人", "数量", "时间" };
            dt = myDataView.ToTable(true, strComuns);

            gridControl1.DataSource = dt;
        }

        private void reload2()
        {

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
    }
}