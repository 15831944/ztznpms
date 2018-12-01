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
using ztznpms.UI.工序管理;

namespace ztznpms.UI.人员管理
{
    public partial class Formchaxuncailiao : DevExpress.XtraEditors.XtraForm
    {
        public string tuhao;
        public string mingcheng;

        public string xiangmumincgheng;
        public string shebeiming;
        public string gongzuolinghao;

        public DataTable dt = new DataTable();

        public Formchaxuncailiao()
        {
            InitializeComponent();
        }

        private void Formchaxuncailiao_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            string sql = "select * from db_caigoucailiao where 图号='"+ tuhao +"' and 名称='"+ mingcheng +"'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            int[] a = gridView1.GetSelectedRows();
            
            dt.Columns.Add("项目名称", typeof(string));
            dt.Columns.Add("设备名称", typeof(string));
            dt.Columns.Add("工作令号", typeof(string));
            dt.Columns.Add("图号", typeof(string));
            dt.Columns.Add("名称", typeof(string));
            dt.Columns.Add("材料名称", typeof(string));
            dt.Columns.Add("型号", typeof(string));
            dt.Columns.Add("编码", typeof(string));
            dt.Columns.Add("单位", typeof(string));
            dt.Columns.Add("数量", typeof(float));

            foreach (int i in a)
            {
                DataRow dr = dt.NewRow();

                //string cailiaoxiangmuming = gridView1.GetRowCellValue(i, "项目名称").ToString();
                //string cailiaogonglinghao = gridView1.GetRowCellValue(i, "工作令号").ToString();
                //string cailiaoshebeiming = gridView1.GetRowCellValue(i, "设备名称").ToString();
                string cailiaotuhao = gridView1.GetRowCellValue(i, "图号").ToString();
                string cailiaomingcheng = gridView1.GetRowCellValue(i, "名称").ToString();
                string cailiaoming = gridView1.GetRowCellValue(i, "材料名称").ToString();
                string cailiaoxinghao = gridView1.GetRowCellValue(i, "型号").ToString();
                string cailiaobianma = gridView1.GetRowCellValue(i, "编码").ToString();
                string cailiaodanwei = gridView1.GetRowCellValue(i, "单位").ToString();
                string cailiaoshuliang = gridView1.GetRowCellValue(i, "数量").ToString();

                dr["项目名称"] = xiangmumincgheng;
                dr["工作令号"] = gongzuolinghao;
                dr["设备名称"] = shebeiming;
                dr["图号"] = cailiaotuhao;
                dr["名称"] = cailiaomingcheng;
                dr["材料名称"] = cailiaoming;
                dr["型号"] = cailiaoxinghao;
                dr["编码"] = cailiaobianma;
                dr["单位"] = cailiaodanwei;
                dr["数量"] = cailiaoshuliang;

                dt.Rows.Add(dr);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }



    }
}