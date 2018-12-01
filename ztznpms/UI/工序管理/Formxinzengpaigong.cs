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
using ThoughtWorks.QRCode.Codec;

namespace ztznpms.UI.工序管理
{
    public partial class Formxinzengpaigong : DevExpress.XtraEditors.XtraForm
    {
        public string yonghu;
        public Formxinzengpaigong()
        {
            InitializeComponent();
        }

        private void Formxinzengpaigong_Load(object sender, EventArgs e)
        {
            com_paigongxingzhi.Properties.Items.Add("机修");
            com_paigongxingzhi.Properties.Items.Add("技术更改");
            com_paigongxingzhi.Properties.Items.Add("外协返修");
            com_paigongxingzhi.Properties.Items.Add("自制返修");
            com_paigongxingzhi.Properties.Items.Add("工装夹具");
            com_paigongxingzhi.Properties.Items.Add("车间维护");
            com_paigongxingzhi.Properties.Items.Add("装配配焊");

            com_zhizaoleixing.Properties.Items.Add("自制零部件");


            
        }


        private void simpleButton6_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;

            if(text_gongzuolinghao.Text.Trim() == "")
            {
                MessageBox.Show("请输入工令号！", "提示");
                return;
            }
            if(text_shebeimingcheng.Text.Trim() == "")
            {
                MessageBox.Show("请输入设备名！", "提示");
                return;
            }
            if(text_xiangmumingcheng.Text.Trim() == "")
            {
                MessageBox.Show("请输入项目名！", "提示");
                return;
            }
            if(txt_lingjianbianhao.Text.Trim() == "")
            {
                MessageBox.Show("请输入序号！", "提示");
                return;
            }
            if(txt_bianma.Text.Trim() == "")
            {
                MessageBox.Show("请输入编码！", "提示");
                return;
            }
            if(txt_leixing.Text.Trim() == "")
            {
                MessageBox.Show("请输入类型！", "提示");
                return;
            }
            if(text_lingjianmingcheng.Text.Trim() == "")
            {
                MessageBox.Show("请输入零件名称！", "提示");
                return;
            }
            if(text_tuhao.Text.Trim() == "")
            {
                MessageBox.Show("请输入图号！", "提示");
                return;
            }
            if(com_paigongxingzhi.Text == "")
            {
                MessageBox.Show("请输入派工性质！", "提示");
                return;
            }
            if(text_danwei.Text.Trim() == "")
            {
                MessageBox.Show("请输入单位！", "提示");
                return;
            }
            if(text_shuliang.Text.Trim() == "")
            {
                MessageBox.Show("请输入数量！", "提示");
                return;
            }
            if(com_paigongxingzhi.Text == "")
            {
                MessageBox.Show("请输入派工性质！", "提示");
                return;
            }

            Random ra = new Random();
            string racount = ra.Next(100000000, 999999999).ToString();

            string sql = "insert into tb_Paigongdan (工作令号,项目名称,设备名称,序号,编码,型号,名称,单位,数量,类型,时间,制造类型,下达时间,下达人,状态,number,派工性质) values('"+ text_gongzuolinghao.Text +"','"+ text_xiangmumingcheng.Text +"','"+ text_shebeimingcheng.Text +"','"+ txt_lingjianbianhao.Text +"','"+ txt_bianma.Text +"','"+ text_tuhao.Text +"','"+ text_lingjianmingcheng.Text +"','"+ text_danwei.Text +"','"+ text_shuliang.Text +"','"+ txt_leixing.Text +"','"+ time+"','"+ com_zhizaoleixing.Text +"','"+ time +"','"+ yonghu +"','0','"+ racount+"','"+ com_paigongxingzhi.Text +"')";
            string ret = Convert.ToString(SQLhelp.ExecuteNonquery1(sql, CommandType.Text));
            if(ret != "")
            {
                MessageBox.Show("新增派工单成功！", "提示");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txt_lingjianbianhao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_lingjianbianhao.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_lingjianbianhao.Text, out oldf);

                    b2 = float.TryParse(txt_lingjianbianhao.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }

        }

        private void text_shuliang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (text_shuliang.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(text_shuliang.Text, out oldf);

                    b2 = float.TryParse(text_shuliang.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }
    }
}