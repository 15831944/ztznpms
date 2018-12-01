using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;
using ztznpms.UI.查询项目;

namespace ztznpms.UI.项目管理
{
    public partial class FormChaxunXiangmu : Form
    {
        public FormChaxunXiangmu()
        {
            InitializeComponent();
            //dataGridView样式
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
        }

        private void FormChaxunXiangmu_Load(object sender, EventArgs e)
        {
            reload();
            DrawRowIndicator(gridView1, 30);
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
            //string sql1 = "select 项目主管,工作令号,项目名称,设备名称,数量 from tb_jishubumen";
            string sql1 = "select id,工作令号,项目名称,设备名称,项目主管,设备负责人,数量,时间 from tb_jishubumen where 制造类型='自制' and 是否提交=1 and 技术部通过=1  and 生产部确认=1 and 加工确认=0";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);
            //this.dataGridView1.Columns["id"].Visible = false;
            //this.dataGridView1.DataSource = dt1;            
            gridControl1.DataSource = dt1;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "")
            {
                MessageBox.Show("查询文本不能为空！", "提示");
                return;
            }
            else
            {
                string s1 = "select 项目主管,工作令号,项目名称,设备名称,数量 from tb_jishubumen where [项目名称] like '%" + toolStripTextBox1.Text.Trim() + "%' or [工作令号] like '%" + toolStripTextBox1.Text.Trim() + "%' or [设备名称] like '%" + toolStripTextBox1.Text.Trim() + "%' or[项目主管] like '%" + toolStripTextBox1.Text.Trim() + "%'";
                DataTable dt1 = SQLhelp.GetDataTable1(s1, CommandType.Text);
                //this.dataGridView1.DataSource = dt1;
                gridControl1.DataSource = dt1;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Formcxxm aform = new Formcxxm();

            //aform.xiangmumingcheng2 = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            //aform.shebeimingcheng2 = dataGridView1.CurrentRow.Cells["设备名称"].Value.ToString();
            //aform.gongzuolinghao2 = dataGridView1.CurrentRow.Cells["工作令号"].Value.ToString();
            //aform.shijian2 = dataGridView1.CurrentRow.Cells["时间"].Value.ToString();

            aform.xiangmumingcheng2= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
            aform.shebeimingcheng2= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
            aform.gongzuolinghao2= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
            aform.shijian2= gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["时间"]).ToString();

            aform.Show();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            //toolStripComboBox1 .Items.Clear();
            //string sql = "select 项目名称 from tb_xiangmu ";
            //DataTable dt = GetDataTable(sql, CommandType.Text);
            //foreach (DataRow row in dt.Rows)
            //{
            //    string a = row["项目名称"].ToString();
            //    toolStripComboBox1.Items.Add(a);
            //}

            toolStripComboBox1.Items.Clear();
            string sql = "select 项目名称 from db_xiangmu ";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["项目名称"].ToString();
                if (toolStripComboBox1.Items.Cast<object>().All(x => x.ToString() != a))
                    toolStripComboBox1.Items.Add(a);
            }
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "select 项目主管,工作令号,项目名称,设备名称,数量 from tb_jishubumen where 项目名称='" + toolStripComboBox1.Text.Trim() + "'";
            DataTable dt1 = SQLhelp.GetDataTable1(sql1, CommandType.Text);
            //this.dataGridView1.DataSource = dt1;
            gridControl1.DataSource = dt1;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "附件名称")//设背景  
            {
                //int pointID = (gridView1.GetRow(e.RowHandle) as object).BgColor;  
                e.Appearance.ForeColor = Color.Blue;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Formcxxm aform = new Formcxxm();

            aform.xiangmumingcheng2 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["项目名称"]).ToString();
            aform.shebeimingcheng2 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["设备名称"]).ToString();
            aform.gongzuolinghao2 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["工作令号"]).ToString();
            aform.shijian2 = gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns["时间"]).ToString();

            aform.Show();
        }
    }
}
