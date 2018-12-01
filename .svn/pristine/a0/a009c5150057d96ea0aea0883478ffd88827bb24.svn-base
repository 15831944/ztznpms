using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.工序管理
{
    public partial class Formjixiujiantizhigongxu : Form
    {
        public string gongjianmingcheng;

        public string a1, b1, c1, d1, h1, a2, b2, c2, d2, h2, a3, b3, c3, d3, h3, a4, b4, c4, d4, h4, a5, b5, c5, d5, h5, a6, b6, c6, d6, h6, a7, b7, c7, d7, h7, a8, b8, c8, d8, h8, a9, b9, c9, d9, h9, a10, b10, c10, d10
    , h10, a11, b11, c11, d11, h11, a12, b12, c12, d12, h12, a13, b13, c13, d13, h13, a14, b14, c14, d14, h14, a15, b15, c15, d15, h15, a16, b16, c16, d16, h16, a17, b17, c17, d17, h17, a18, b18, c18, d18, h18, a19, b19, c19, d19, h19, a20, b20, c20, d20, h20, a21, b21, c21, d21, h21, a22, b22, c22, d22, h22, a23, b23, c23, d23, h23, a24, b24, c24, d24, h24, a25, b25, c25, d25, h25, f1, f2, f3, f4, g1, g2, g3, g4;

        /// <summary>
        /// 导入机修件工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = GetDgvToTable(dataGridView1);
            int j = 0;
            string[] a = new string[dt.Rows.Count];
            string[] b = new string[dt.Rows.Count];
            string[] c = new string[dt.Rows.Count];
            string[] d = new string[dt.Rows.Count];

            string[] f = new string[dt.Rows.Count];
            string[] g = new string[dt.Rows.Count];
            string[] h = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drg = dt.Rows[i];
                if (drg["工序名称"].ToString() != "")//i=1,i=3,i=6.....
                {
                    if ((bool)dataGridView1.Rows[i].Cells["工序选择"].EditedFormattedValue == true)
                    {

                        a[j] = drg["工序名称"].ToString();
                        b[j] = drg["工序内容"].ToString();
                        c[j] = drg["价格"].ToString();
                        d[j] = drg["负责人"].ToString();

                        f[j] = drg["材料"].ToString();
                        g[j] = drg["重量"].ToString();
                        h[j] = drg["工艺注意点"].ToString();

                        j++;//j=4

                        #region
                        //this.DialogResult = DialogResult.OK;
                        //if(i == 0)
                        //{
                        //    a1 = drg["工序名称"].ToString();
                        //    b1 = drg["工序内容"].ToString();
                        //    c1 = drg["价格"].ToString();
                        //    d1 = drg["负责人"].ToString();
                        //}
                        //if(i == 1)
                        //{
                        //    a2 = drg["工序名称"].ToString();
                        //    b2 = drg["工序内容"].ToString();
                        //    c2 = drg["价格"].ToString();
                        //    d2 = drg["负责人"].ToString();
                        //}
                        //if (i == 2)
                        //{
                        //    a3 = drg["工序名称"].ToString();
                        //    b3 = drg["工序内容"].ToString();
                        //    c3 = drg["价格"].ToString();
                        //    d3 = drg["负责人"].ToString();
                        //}
                        //if (i == 3)
                        //{
                        //    a4 = drg["工序名称"].ToString();
                        //    b4 = drg["工序内容"].ToString();
                        //    c4 = drg["价格"].ToString();
                        //    d4 = drg["负责人"].ToString();
                        //}
                        //if (i == 4)
                        //{
                        //    a5 = drg["工序名称"].ToString();
                        //    b5 = drg["工序内容"].ToString();
                        //    c5 = drg["价格"].ToString();
                        //    d5 = drg["负责人"].ToString();
                        //}
                        //if (i == 5)
                        //{
                        //    a6 = drg["工序名称"].ToString();
                        //    b6 = drg["工序内容"].ToString();
                        //    c6 = drg["价格"].ToString();
                        //    d6 = drg["负责人"].ToString();
                        //}
                        //if (i == 6)
                        //{
                        //    a7 = drg["工序名称"].ToString();
                        //    b7 = drg["工序内容"].ToString();
                        //    c7 = drg["价格"].ToString();
                        //    d7 = drg["负责人"].ToString();
                        //}
                        //if (i == 7)
                        //{
                        //    a8 = drg["工序名称"].ToString();
                        //    b8 = drg["工序内容"].ToString();
                        //    c8 = drg["价格"].ToString();
                        //    d8 = drg["负责人"].ToString();
                        //}
                        //if (i == 8)
                        //{
                        //    a9 = drg["工序名称"].ToString();
                        //    b9 = drg["工序内容"].ToString();
                        //    c9 = drg["价格"].ToString();
                        //    d9 = drg["负责人"].ToString();
                        //}
                        //if (i == 9)
                        //{
                        //    a10 = drg["工序名称"].ToString();
                        //    b10 = drg["工序内容"].ToString();
                        //    c10 = drg["价格"].ToString();
                        //    d10 = drg["负责人"].ToString();
                        //}
                        //if (i == 10)
                        //{
                        //    a11 = drg["工序名称"].ToString();
                        //    b11 = drg["工序内容"].ToString();
                        //    c11 = drg["价格"].ToString();
                        //    d11 = drg["负责人"].ToString();
                        //}
                        //if (i == 11)
                        //{
                        //    a12 = drg["工序名称"].ToString();
                        //    b12 = drg["工序内容"].ToString();
                        //    c12 = drg["价格"].ToString();
                        //    d12 = drg["负责人"].ToString();
                        //}
                        //if (i == 12)
                        //{
                        //    a13 = drg["工序名称"].ToString();
                        //    b13 = drg["工序内容"].ToString();
                        //    c13 = drg["价格"].ToString();
                        //    d13 = drg["负责人"].ToString();
                        //}
                        //if (i == 13)
                        //{
                        //    a14 = drg["工序名称"].ToString();
                        //    b14 = drg["工序内容"].ToString();
                        //    c14 = drg["价格"].ToString();
                        //    d14 = drg["负责人"].ToString();
                        //}
                        //if (i == 14)
                        //{
                        //    a15 = drg["工序名称"].ToString();
                        //    b15 = drg["工序内容"].ToString();
                        //    c15 = drg["价格"].ToString();
                        //    d15 = drg["负责人"].ToString();
                        //}
                        //if (i == 15)
                        //{
                        //    a16= drg["工序名称"].ToString();
                        //    b16 = drg["工序内容"].ToString();
                        //    c16 = drg["价格"].ToString();
                        //    d16 = drg["负责人"].ToString();
                        //}
                        //if (i == 16)
                        //{
                        //    a17 = drg["工序名称"].ToString();
                        //    b17 = drg["工序内容"].ToString();
                        //    c17 = drg["价格"].ToString();
                        //    d17 = drg["负责人"].ToString();
                        //}
                        //if (i == 17)
                        //{
                        //    a18 = drg["工序名称"].ToString();
                        //    b18 = drg["工序内容"].ToString();
                        //    c18 = drg["价格"].ToString();
                        //    d18 = drg["负责人"].ToString();
                        //}
                        //if (i == 18)
                        //{
                        //    a19 = drg["工序名称"].ToString();
                        //    b19 = drg["工序内容"].ToString();
                        //    c19 = drg["价格"].ToString();
                        //    d19 = drg["负责人"].ToString();
                        //}
                        //if (i == 19)
                        //{
                        //    a20 = drg["工序名称"].ToString();
                        //    b20 = drg["工序内容"].ToString();
                        //    c20 = drg["价格"].ToString();
                        //    d20 = drg["负责人"].ToString();
                        //}
                        #endregion

                    }
                }

                if (j >= dt.Rows.Count)
                    break;
            }

            this.DialogResult = DialogResult.OK;
            try
            {
                a1 = a[0].ToString();
                b1 = b[0].ToString();
                c1 = c[0].ToString();
                d1 = d[0].ToString();
                f1 = f[0].ToString();
                g1 = g[0].ToString();
                h1 = h[0].ToString();

                a2 = a[1].ToString();
                b2 = b[1].ToString();
                c2 = c[1].ToString();
                d2 = d[1].ToString();
                f2 = f[1].ToString();
                g2 = g[1].ToString();
                h2 = h[1].ToString();

                a3 = a[2].ToString();
                b3 = b[2].ToString();
                c3 = c[2].ToString();
                d3 = d[2].ToString();
                f3 = f[2].ToString();
                g3 = g[2].ToString();
                h3 = h[2].ToString();

                a4 = a[3].ToString();
                b4 = b[3].ToString();
                c4 = c[3].ToString();
                d4 = d[3].ToString();
                h4 = h[3].ToString();
                f4 = f[3].ToString();
                g4 = g[3].ToString();

                a5 = a[4].ToString();
                b5 = b[4].ToString();
                c5 = c[4].ToString();
                d5 = d[4].ToString();
                h5 = h[4].ToString();

                a6 = a[5].ToString();
                b6 = b[5].ToString();
                c6 = c[5].ToString();
                d6 = d[5].ToString();
                h6 = h[5].ToString();

                a7 = a[6].ToString();
                b7 = b[6].ToString();
                c7 = c[6].ToString();
                d7 = d[6].ToString();
                h7 = h[6].ToString();

                a8 = a[7].ToString();
                b8 = b[7].ToString();
                c8 = c[7].ToString();
                d8 = d[7].ToString();
                h8 = h[7].ToString();

                a9 = a[8].ToString();
                b9 = b[8].ToString();
                c9 = c[8].ToString();
                d9 = d[8].ToString();
                h9 = h[8].ToString();

                a10 = a[9].ToString();
                b10 = b[9].ToString();
                c10 = c[9].ToString();
                d10 = d[9].ToString();
                h10 = h[9].ToString();

                a11 = a[10].ToString();
                b11 = b[10].ToString();
                c11 = c[10].ToString();
                d11 = d[10].ToString();
                h11 = h[10].ToString();

                a12 = a[11].ToString();
                b12 = b[11].ToString();
                c12 = c[11].ToString();
                d12 = d[11].ToString();
                h12 = h[11].ToString();

                a13 = a[12].ToString();
                b13 = b[12].ToString();
                c13 = c[12].ToString();
                d13 = d[12].ToString();
                h13 = h[12].ToString();

                a14 = a[13].ToString();
                b14 = b[13].ToString();
                c14 = c[13].ToString();
                d14 = d[13].ToString();
                h14 = h[13].ToString();

                a15 = a[14].ToString();
                b15 = b[14].ToString();
                c15 = c[14].ToString();
                d15 = d[14].ToString();
                h15 = h[14].ToString();

                a16 = a[15].ToString();
                b16 = b[15].ToString();
                c16 = c[15].ToString();
                d16 = d[15].ToString();
                h16 = h[15].ToString();

                a17 = a[16].ToString();
                b17 = b[16].ToString();
                c17 = c[16].ToString();
                d17 = d[16].ToString();
                h17 = h[16].ToString();

                a18 = a[17].ToString();
                b18 = b[17].ToString();
                c18 = c[17].ToString();
                d18 = d[17].ToString();
                h18 = h[17].ToString();

                a19 = a[18].ToString();
                b19 = b[18].ToString();
                c19 = c[18].ToString();
                d19 = d[18].ToString();
                h19 = h[18].ToString();

                a20 = a[19].ToString();
                b20 = b[19].ToString();
                c20 = c[19].ToString();
                d20 = d[19].ToString();
                h20 = h[19].ToString();

                a21 = a[20].ToString();
                b21 = b[20].ToString();
                c21 = c[20].ToString();
                d21 = d[20].ToString();
                h21 = h[20].ToString();

                a22 = a[21].ToString();
                b22 = b[21].ToString();
                c22 = c[21].ToString();
                d22 = d[21].ToString();
                h22 = h[21].ToString();

                a23 = a[22].ToString();
                b23 = b[22].ToString();
                c23 = c[22].ToString();
                d23 = d[22].ToString();
                h23 = h[22].ToString();

                a24 = a[23].ToString();
                b24 = b[23].ToString();
                c24 = c[23].ToString();
                d24 = d[23].ToString();
                h24 = h[23].ToString();

                a25 = a[24].ToString();
                b25 = b[24].ToString();
                c25 = c[24].ToString();
                d25 = d[24].ToString();
                h25 = h[24].ToString();
            }
            catch
            {

            }
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

        public Formjixiujiantizhigongxu()
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

        private void Formjixiujiantizhigongxu_Load(object sender, EventArgs e)
        {
            string sql = "select id,客户名称,部门,工件名称,加工内容,接单编号,机修件数量,工序名称,价格,材料,重量,工序顺序,工序内容,负责人 from db_gongxu111 where 工件名称='" + gongjianmingcheng + "' ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            this.dataGridView1.DataSource = dt;
        }

        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
