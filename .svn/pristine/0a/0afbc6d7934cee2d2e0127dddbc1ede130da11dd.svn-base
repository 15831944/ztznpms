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

namespace ztznpms.UI.工序管理
{
    public partial class Formgxwaixie : Form
    {
        public string wxiangmumingcheng;
        public string wtuhao;
        public string wmingcheng;
        public string wgonglinghao;
        public string wshebeimingcheng;
        public string wshunxu;
        public string wgxming;

        public string waixieStart;
        public string waixieEnd;

        public string flag3;

        public Formgxwaixie()
        {
            InitializeComponent();
        }

        private void Formgxwaixie_Load(object sender, EventArgs e)
        {
            txt_xiangmumingcheng.Text = wxiangmumingcheng;
            txt_tuhao.Text = wtuhao;
            txt_mingcheng.Text = wmingcheng;
            txt_gonglinghao.Text = wgonglinghao;
            txt_shebeimingcheng.Text = wshebeimingcheng;
            txt_shunxu.Text = wshunxu;
            txt_gxmingcheng.Text = wgxming;

            richTextBox1.Text = waixieStart;
            richTextBox2.Text = waixieEnd;

            //if(waixieStart != "")
            //{
            //    richTextBox1.ReadOnly = true;
            //    richTextBox1.Text = waixieStart;
            //}

            //if(waixieEnd != "")
            //{
            //    richTextBox2.ReadOnly = true;
            //    richTextBox2.Text = waixieEnd;
            //}

            //if(waixieStart != ""&& waixieEnd != "")
            //{
            //    btn_bc.Enabled = false;
            //}
            btn_bc.Enabled = false;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bc_Click(object sender, EventArgs e)
        {
            if(flag3 == "自制加工")
            {
                string sql = "update db_gongxu1 set 工序外协开始='" + richTextBox1.Text + "', 工序外协结束='" + richTextBox2.Text + "' where 图号='" + wtuhao + "' and 名称='" + wmingcheng + "' and 项目名称='" + wxiangmumingcheng + "' and 工序名称='" + wgxming + "'";
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
            if(flag3 == "技术更改")
            {
                string sql = "update db_gongxu11 set 工序外协开始='" + richTextBox1.Text + "', 工序外协结束='" + richTextBox2.Text + "' where 图号='" + wtuhao + "' and 名称='" + wmingcheng + "' and 项目名称='" + wxiangmumingcheng + "' and 工序名称='" + wgxming + "'";
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

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_qx_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_timeNow_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            richTextBox1.Text = Convert.ToString(time);
        }

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
