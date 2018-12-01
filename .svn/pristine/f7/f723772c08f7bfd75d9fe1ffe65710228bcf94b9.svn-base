using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;
using ztznpms.UI.项目管理;
using ztznpms.UI.二维码;

namespace ztznpms.UI.查询项目
{
    public partial class Formchaxunxiangxi : DevExpress.XtraEditors.XtraForm
    {
        public string gxtuhao;
        public string gxmingcheng1;
        public string gxxiangmumingcheng;
        public Formchaxunxiangxi()
        {
            InitializeComponent();
            //dataGridView样式
            //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void Formchaxunxiangxi_Load(object sender, EventArgs e)
        {
            reload();
        }
        private void reload()
        {
            //string s1 = "select * from db_gongxu where 图号='" + gxtuhao + "'";
            string s1 = "select* from db_gongxu1 where 图号 = '" + gxtuhao + "' and 名称='"+ gxmingcheng1 +"' order by 工序顺序 asc";
            DataTable dtgx = SQLhelp.GetDataTable(s1, CommandType.Text);
            
            this.dataGridView1.DataSource = dtgx;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                System.Drawing.Rectangle rectangle = e.CellBounds;
                rectangle.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, rectangle, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                e.Handled = true;
            }
        }

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{

        //    if (dataGridView1.Rows.Count <= 0)
        //    {
        //        MessageBox.Show("请选择行！","提示");
        //        return;
        //    }

        //    string a = dataGridView1.CurrentRow.Cells["加工单位"].Value.ToString();
        //    string b = dataGridView1.CurrentRow.Cells["图号"].Value.ToString();
        //    string c = dataGridView1.CurrentRow.Cells["名称"].Value.ToString();
        //    string d = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();
        //    string f = dataGridView1.CurrentRow.Cells["工令号"].Value.ToString();


        //    string sql1 = "select min(工序顺序) from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "' and 开始时间 is null";//查询开始时间为空
        //    string ret1 = Convert.ToString(SQLhelp.ExecuteScalar(sql1, CommandType.Text));

        //    if(ret1 == "")//开始时间都不为空
        //    {
        //        //1、都结束了
        //        string sql = "select max(工序顺序) from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "'";
        //        string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

        //        string sql2 = "select 结束时间 from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "' and 工序顺序='"+ ret +"'";
        //        string ret2 = Convert.ToString(SQLhelp.ExecuteScalar(sql2, CommandType.Text));
        //        if(ret2 != "")
        //        {
        //            MessageBox.Show("该项目工序已经全部结束！", "提示");
        //            return;
        //        }
        //        //2、还剩下最后一道工序没有结束
        //        else
        //        {
        //            Formerweima form = new Formerweima();

        //            form.a1 = a;
        //            form.b1 = b;
        //            form.c1 = c;
        //            form.d1 = d;
        //            form.f1 = f;

        //            string sql3 = "select * from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "' and  工序顺序='" + ret + "'";
        //            DataTable dt = SQLhelp.GetDataTable(sql3, CommandType.Text);

        //            DataRow row = dt.Rows[0];

        //            form.gxming = row["工序名称"].ToString();
        //            form.gxshunxu = row["工序顺序"].ToString();
        //            form.gxstarttime = row["开始时间"].ToString();
        //            form.gxendtime = row["结束时间"].ToString();

        //            form.ShowDialog();
        //            if (form.DialogResult == DialogResult.OK)
        //            {
        //                this.reload();
        //            }
        //        }

        //    }
        //    else//查到开始时间有为空的
        //    {
        //        if (ret1 == "1")//查到开始时间为null的工序顺序为"1"时，表示该工序还未开始
        //        {
        //            Formerweima form = new Formerweima();

        //            form.a1 = a;
        //            form.b1 = b;
        //            form.c1 = c;
        //            form.d1 = d;
        //            form.f1 = f;

        //            string sql3 = "select * from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "' and  工序顺序='" + 1 + "'";
        //            DataTable dt = SQLhelp.GetDataTable(sql3, CommandType.Text);

        //            DataRow row = dt.Rows[0];

        //            form.gxming = row["工序名称"].ToString();
        //            form.gxshunxu = row["工序顺序"].ToString();
        //            form.gxstarttime = row["开始时间"].ToString();
        //            form.gxendtime = row["结束时间"].ToString();

        //            form.ShowDialog();
        //            if (form.DialogResult == DialogResult.OK)
        //            {
        //                this.reload();
        //            }
        //        }
        //        else//最小顺序不为1，即工序已经开始,再判断上一道工序是否结束
        //        {
        //            int shunxu1 = Convert.ToInt32(ret1);
        //            int shunxu2 = shunxu1 - 1;
        //            string sql4 = "select 结束时间 from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "' and  工序顺序='" + shunxu2 + "'";
        //            string ret4 = Convert.ToString(SQLhelp.ExecuteScalar(sql4, CommandType.Text));

        //            if (ret4 != "")//上一道工序结束
        //            {
        //                Formerweima form = new Formerweima();

        //                form.a1 = a;
        //                form.b1 = b;
        //                form.c1 = c;
        //                form.d1 = d;
        //                form.f1 = f;

        //                string sql5 = "select * from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "' and  工序顺序='" + shunxu1 + "'";
        //                DataTable dt = SQLhelp.GetDataTable(sql5, CommandType.Text);

        //                DataRow row = dt.Rows[0];

        //                form.gxming = row["工序名称"].ToString();
        //                form.gxshunxu = row["工序顺序"].ToString();
        //                form.gxstarttime = row["开始时间"].ToString();
        //                form.gxendtime = row["结束时间"].ToString();

        //                form.ShowDialog();
        //                if (form.DialogResult == DialogResult.OK)
        //                {
        //                    this.reload();
        //                }
        //            }
        //            else//上一道工序没有结束
        //            {
        //                Formerweima form = new Formerweima();

        //                form.a1 = a;
        //                form.b1 = b;
        //                form.c1 = c;
        //                form.d1 = d;
        //                form.f1 = f;

        //                string sql6 = "select * from db_gongxu where 图号 = '" + b + "' and 名称 = '" + c + "' and 加工单位 = '" + a + "' and  工序顺序='" + shunxu2 + "'";
        //                DataTable dt = SQLhelp.GetDataTable(sql6, CommandType.Text);

        //                DataRow row = dt.Rows[0];

        //                form.gxming = row["工序名称"].ToString();
        //                form.gxshunxu = row["工序顺序"].ToString();
        //                form.gxstarttime = row["开始时间"].ToString();
        //                form.gxendtime = row["结束时间"].ToString();

        //                form.ShowDialog();
        //                if (form.DialogResult == DialogResult.OK)
        //                {
        //                    this.reload();
        //                }
        //            }
        //        }
        //    }
        //}


    }
}
