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
    public partial class FormWaixiejixiujian : Form
    {
        public string wkehumingcheng;
        public string wjiagongneirong;
        public string wjiedanbianhao;
        public string wgongjianmingcheng;

        public string wshunxu;
        public string wgxming;

        public string waixieStart;
        public string waixieEnd;
        public FormWaixiejixiujian()
        {
            InitializeComponent();
        }

        private void FormWaixiejixiujian_Load(object sender, EventArgs e)
        {
            txt_xiangmumingcheng.Text = wkehumingcheng;
            txt_tuhao.Text = wjiagongneirong;
            txt_mingcheng.Text = wgongjianmingcheng;
            txt_gonglinghao.Text = wgongjianmingcheng;

            txt_shunxu.Text = wshunxu;
            txt_gxmingcheng.Text = wgxming;

            richTextBox1.Text = waixieStart;
            richTextBox2.Text = waixieEnd;

            btn_bc.Enabled = false;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bc_Click(object sender, EventArgs e)
        {
            string sql = "update db_gongxu111 set 工序外协开始='" + richTextBox1.Text + "', 工序外协结束='" + richTextBox2.Text + "' where 加工内容='" + wjiagongneirong + "' and 工件名称='" + wgongjianmingcheng + "' and 客户名称='" + wkehumingcheng + "' and 接单编号='" + wjiedanbianhao + "' and 工序名称='" + wgxming + "'";
            string r = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));

            if (r != "")
            {
                MessageBox.Show("工序外协修改成功！", "提示");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("工序外协修改失败！", "提示");
            }
        }

        private void btn_qx_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 开始时间记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_timeNow_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            richTextBox1.Text = Convert.ToString(time);
        }

        /// <summary>
        /// 结束时间记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_timeEnd_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            richTextBox2.Text = Convert.ToString(time);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                richTextBox2.Enabled = true;
                btn_timeEnd.Enabled = true;
                btn_bc.Enabled = true;
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox2.Text != "")
            {

                btn_bc.Enabled = true;
            }
        }
    }
}
