using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.检验
{
    public partial class FormTest : Form
    {
        public SerialPort sp1 = new SerialPort("COM3", 115200, Parity.None);

        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public FormTest()
        {
            InitializeComponent();            
            //事件注册
            sp1.DataReceived += ReceiveData;
        }

        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] m_recvBytes = new byte[sp1.BytesToRead];//定义缓冲区大小
            int result = sp1.Read(m_recvBytes, 0, m_recvBytes.Length);//从串口读取数据
            if (result <= 0)
                return;
            string str1 = Encoding.GetEncoding("UTF-8").GetString(m_recvBytes, 0, m_recvBytes.Length);//对数据进行转换
            this.Invoke
                (
                new EventHandler(
                    delegate
                    {
                        //调用委托，将值传给文本框
                        //string[] sArray = str1.Split(new char[] { '|' });
                        string[] sArray = str1.Split(new char[2] { '\r', '\n' });

                        System.Windows.Forms.Application.DoEvents();
                        Thread.Sleep(1000);

                        try
                        {
                            txt_xiangmumingcheng.Text = sArray[0];//项目名称
                            txt_gonglinghao.Text = sArray[1];//工作令号
                            txt_tuhao.Text = sArray[2];//图号
                            txt_mingcheng.Text = sArray[3];//名称

                            System.Windows.Forms.Application.DoEvents();
                            Thread.Sleep(1000);


                            string ssql = "select * from db_gongxu1 where 项目名称='" + txt_xiangmumingcheng.Text + "' and 图号='" + txt_tuhao.Text + "' and 名称='" + txt_mingcheng.Text + "'";
                            DataTable dtt = SQLhelp.GetDataTable(ssql, CommandType.Text);

                            DataRow roww = dtt.Rows[0];
                            txt_shebeiming.Text = roww["设备名称"].ToString();

                            button1.Enabled = true;
                        }
                        catch
                        {

                        }

                        sp1.DiscardInBuffer();
                    }));
        }


        private void FormTest_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("合格");
            comboBox1.Items.Add("不合格");
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp1.IsOpen)
                {
                    MessageBox.Show("端口打开成功！");
                }
                else
                {
                    sp1.Open();
                }
            }

            catch
            {
                MessageBox.Show("请先连接扫码枪！");
                return;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (sp1.IsOpen)
            {
                sp1.Close();
                MessageBox.Show("端口关闭！");
            }
            else
            {
                MessageBox.Show("端口还没打开！");
            }
        }

        /// <summary>
        /// 上传检验记录表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //打开对话框
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = dialog.FileName;
                    FileInfo info = new FileInfo(@txtName.Text);
                    //获得文件大小
                    fileSize = info.Length;
                    //提取文件名,三步走
                    int index = info.FullName.LastIndexOf(".");
                    fileName = info.FullName.Remove(index);
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                    //txtMingcheng.Text = fileName;
                    //获得文件扩展名
                    fileType = info.Extension.Replace(".", "");
                    //把文件转换成二进制流
                    files = new byte[Convert.ToInt32(fileSize)];
                    FileStream file = new FileStream(txtName.Text, FileMode.Open, FileAccess.Read);
                    read = new BinaryReader(file);
                    read.Read(files, 0, Convert.ToInt32(fileSize));

                    button3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }


        /// <summary>
        /// 保存检测结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Trim() == ""|| richTextBox1.Text == "")
            {
                MessageBox.Show("请将检验结果填写完整！", "提示");
                return;
            }

            if (MessageBox.Show("确认提交吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    string shijian = DateTime.Now.ToString();
                    string sqljianyan= "update db_xiangmu set 生产检验结果='" + comboBox1.Text + "', 检验结果备注='" + richTextBox1.Text + "', 检验记录表上传时间='" + shijian + "', 检验结果附件=@pic, 检验结果附件类型='" + fileType + "' where 图号='" + txt_tuhao.Text.Trim() + "' and 名称='" + txt_mingcheng.Text.Trim() + "' and 设备名称='" + txt_shebeiming.Text.Trim() + "'";
                    string retjianyan = Convert.ToString(SQLhelp.ExecuteNonqueryByte(sqljianyan, CommandType.Text, files));

                    //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";

                    //SqlConnection con = new SqlConnection(ConStr);
                    //con.Open();
                    //SqlCommand cmd = new SqlCommand("", con);
                    //cmd = con.CreateCommand();



                    //cmd.CommandText = "update db_xiangmu set 生产检验结果='"+comboBox1.Text+"', 检验结果备注='"+ richTextBox1.Text +"', 检验记录表上传时间='" + shijian + "', 检验结果附件=@pic, 检验结果附件类型='" + fileType + "' where 图号='" + txt_tuhao.Text.Trim() + "' and 名称='" + txt_mingcheng.Text.Trim() + "' and 设备名称='" + txt_shebeiming.Text.Trim() + "'";

                    //cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@pic", files);
                    //cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("提交" + fileName + "时候发生了" + ex.Message);
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            if (sp1.IsOpen)
            {
                sp1.Close();
            }
        }
    }
}
