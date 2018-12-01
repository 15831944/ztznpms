using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.二维码
{
    public partial class Formerweima : Form
    {
        //public string gxming;
        //public string gxshunxu;
        //public string gxstarttime;
        //public string gxendtime;

        //public string a1;
        //public string b1;
        //public string c1;
        //public string d1;
        //public string f1;

        public SerialPort sp1 = new SerialPort("COM3", 115200, Parity.None);

        public Formerweima()
        {
            InitializeComponent();
            //事件注册
            //sp1.DataReceived += ReceiveData;
        }

        ////代理
        //private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        //{

        //        //int n = sp1.BytesToRead;
        //        //byte[] buf = new byte[n];
        //        //sp1.Read(buf, 0, n);
        //        //this.Invoke
        //        //    (
        //        //    new EventHandler(
        //        //        delegate
        //        //        {
        //        //            string str = Encoding.GetEncoding("UTF-8").GetString(buf);
        //        //            //string[] sArray = str.Split(new char[2] { '\r', '\n' });
        //        //            string[] sArray = str.Split(new char[1] { '\n' });

        //        //            try
        //        //            {
        //        //                //if (a1 == sArray[0] && b1 == sArray[1] && c1 == sArray[2] && d1 == sArray[3] && f1 == sArray[4])//判断扫出的二维码中的数据是否与当前零件信息相同
        //        //                //if ( b1 == sArray[1] && c1 == sArray[2] )//判断扫出的二维码中的数据是否与当前零件信息相同
        //        //                //{
        //        //                txt_jiagong.Text = sArray[0];
        //        //                txt_tuhao.Text = sArray[1];
        //        //                txt_mingcheng.Text = sArray[2];
        //        //                txt_shebeiming.Text = sArray[3];
        //        //                txt_gonglinghao.Text = sArray[4];
        //        //                //}
        //        //                //else
        //        //                //{
        //        //                //    MessageBox.Show("二维码信息与当前项目零件信息不符！", "提示");
        //        //                //    return;
        //        //                //}

        //        //                if (txt_tuhao.Text != b1 || txt_jiagong.Text != a1 || txt_mingcheng.Text != c1 || txt_shebeiming.Text != d1 || txt_gonglinghao.Text != f1)
        //        //                {
        //        //                    MessageBox.Show("二维码信息与当前项目信息不符合！", "提示");
        //        //                    txt_tuhao.Text = null;
        //        //                    txt_jiagong.Text = null;
        //        //                    txt_mingcheng.Text = null;
        //        //                    txt_shebeiming.Text = null;
        //        //                    txt_gonglinghao.Text = null;

        //        //                    return;
        //        //                }

        //        //            }
        //        //            catch
        //        //            {

        //        //            }


        //        //        }
        //        //        )
        //        //    );

            
        //}

        private void Formerweima_Load(object sender, EventArgs e)
        {
            //gx_ming.Text = gxming;
            //gx_shunxu.Text = gxshunxu;
            //txt_Starttime.Text = gxstarttime;
            //txt_Endtime.Text = gxendtime;

            //if(txt_Starttime.Text == "" && txt_Endtime.Text == "")
            //{
            //    btn_SZend.Enabled = false;
            //}
            //if(txt_Starttime.Text != "" && txt_Endtime.Text == "")
            //{
            //    btn_SZstart.Enabled = false;
            //}

            ////if(txt_jiagong.Text == "" && txt_mingcheng.Text == "" && txt_tuhao.Text == "" && txt_shebeiming.Text == "" && txt_gonglinghao.Text == "")
            ////{
            //    btn_BC.Enabled = false;
            ////}

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打开扫描枪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_Open_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (sp1.IsOpen)
        //        {
        //            MessageBox.Show("端口打开成功！");
        //        }
        //        else
        //        {
        //            sp1.Open();
        //        }
        //    }

        //    catch
        //    {
        //        MessageBox.Show("请先连接扫码枪！");
        //        return;
        //    }
        //}

        /// <summary>
        /// 关闭扫描枪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_Close_Click(object sender, EventArgs e)
        //{
        //    if (sp1.IsOpen)
        //    {
        //        sp1.Close();
        //        MessageBox.Show("端口关闭！");
        //    }
        //    else
        //    {
        //        MessageBox.Show("端口还没打开！");
        //    }
        //}

        /// <summary>
        /// 设置开始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_SZstart_Click(object sender, EventArgs e)
        //{
        //    DateTime time = DateTime.Now;
        //    txt_Starttime.Text = Convert.ToString(time);
        //    btn_BC.Enabled = true;
        //}

        /// <summary>
        /// 设置结束时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_SZend_Click(object sender, EventArgs e)
        //{
        //    DateTime time = DateTime.Now;
        //    txt_Endtime.Text = Convert.ToString(time);
        //    btn_BC.Enabled = true;
        //}

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_BC_Click(object sender, EventArgs e)
        //{
        //if(txt_Endtime.Text == "")
        //{
        //    string sql1 = "update db_gongxu set 开始时间='" + txt_Starttime.Text + "' where 加工单位='" + txt_jiagong.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "' and 工序顺序='" + gx_shunxu.Text + "'";
        //    string ret1 = Convert.ToString(SQLhelp.ExecuteNonquery(sql1, CommandType.Text));
        //    if (ret1 != "")
        //    {
        //        MessageBox.Show("时间记录成功!", "提示");
        //        this.DialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("时间记录失败!", "提示");
        //    }
        //}
        //if(txt_Starttime.Text != "" && txt_Endtime.Text != "")
        //{
        //    string sql = "update db_gongxu set 开始时间='" + txt_Starttime.Text + "', 结束时间='" + txt_Endtime.Text + "' where 加工单位='" + txt_jiagong.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "' and 工序顺序='" + gx_shunxu.Text + "'";
        //    string ret = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));
        //    if (ret != "")
        //    {
        //        MessageBox.Show("时间记录成功!", "提示");
        //        if (sp1.IsOpen)
        //        {
        //            sp1.Close();
        //        }

        //        this.DialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("时间记录失败!", "提示");
        //    }
        //}

        //}

        //private void btn_QX_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

    }
}
