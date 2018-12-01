using System;
using System.Data;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.项目管理
{
    public partial class FormZengjiaxiangmu : Form
    {
        public string ming;
        public string ling;
        public string cheng;
        public FormZengjiaxiangmu()
        {
            InitializeComponent();
        }

        private void FormZengjiaxiangmu_Load(object sender, EventArgs e)
        {
            t_xiangmuming.Text = ming;
            t_gonglinghao.Text = ling;
            t_shebeimingcheng.Text = cheng;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            if(t_tuhao.Text.Trim() == "")
            {
                MessageBox.Show("请输入项目图号！");
                return;
            }
            if(t_mingcheng.Text.Trim() == "")
            {
                MessageBox.Show("请输入项目工件名称！");
                return;
            }
            if(t_jiagongshuliang.Text.Trim() == "")
            {
                MessageBox.Show("请输入加工数量");
                return;
            }

            if(t_shebeimingcheng.Text.Trim() == "")
            {
                MessageBox.Show("请输入设备名称！");
                return;
            }

            if(t_gonglinghao.Text.Trim() == "")
            {
                MessageBox.Show("请输入工令号！");
                return;
            }
            //if(dateTimePicker1.Text == "")
            //{
            //    MessageBox.Show("请选择下单日期！");
            //    return;
            //}
            if(dateTimePicker2.Text == "")
            {
                MessageBox.Show("请选择要求完成的日期！");
                return;
            }

            //if(dateTimePicker1.Value >= dateTimePicker2.Value)
            //{
            //    MessageBox.Show("请重新设置下单或完成时间！", "提示");
            //    return;
            //}

            //DateTime time1 = DateTime.Now;
            //DateTime time2 = dateTimePicker2.Value;
            //TimeSpan t = time2 - time1;
            //double t1 = t.TotalDays;
            //int t2 = Convert.ToInt32(t1);//时间差额

            string sql1 = "insert into db_xiangmu(项目名称,工作令号,设备名称,编码,图号,名称,单位,数量,类型,要求到货日期,制造类型) values('"+ t_xiangmuming.Text.Trim() +
                "','"+ t_gonglinghao.Text.Trim()+"','"+ t_shebeimingcheng.Text.Trim() +"','"+ t_bianma.Text.Trim() +"','"+t_tuhao.Text.Trim()+"','"+t_mingcheng.Text.Trim()+"','"+t_danwei.Text.Trim()
                +"','"+t_jiagongshuliang.Text.Trim()+"','"+t_leixing.Text.Trim()+"','"+dateTimePicker2.Text.Trim()+"','"+t_zhizaoleixing.Text.Trim()+"')";

            string r1 = Convert.ToString(SQLhelp.ExecuteNonquery(sql1, CommandType.Text));
            if(r1 != "")
            {
                MessageBox.Show("成功增加项目！", "提示");

            }


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
