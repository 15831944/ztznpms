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

namespace ztznpms.UI.人员管理
{
    public partial class Formchaxunlingjian : DevExpress.XtraEditors.XtraForm
    {
        public Formchaxunlingjian()
        {
            InitializeComponent();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 项目名称,工作令号,设备名称,图号,名称,数量,工序名称,价格,工序顺序,工序内容,负责人,实际操作人,实际操作人2,开始时间,结束时间,序号 FROM db_gongxu1 where [图号] like '%" + textBoxItem1.Text.Trim() + "%' or [名称] like '%" + textBoxItem1.Text.Trim() + "%' or [项目名称] like '%" + textBoxItem1.Text.Trim() + "%'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
        }

        private void Formchaxunlingjian_Load(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 客户名称,部门,工件名称,加工内容,接单编号,机修件数量,工序名称,价格,工序顺序,工序内容,负责人,实际操作人,实际操作人2,开始时间,结束时间,序号 FROM db_gongxu111 where [加工内容] like '%" + textBoxItem2.Text.Trim() + "%' or [工件名称] like '%" + textBoxItem2.Text.Trim() + "%' or [部门] like '%" + textBoxItem2.Text.Trim() + "%' or [客户名称] like '%" + textBoxItem2.Text.Trim() + "%' or [接单编号] like '%" + textBoxItem2.Text.Trim() + "%'";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);
            gridControl1.DataSource = dt;
        }
    }
}