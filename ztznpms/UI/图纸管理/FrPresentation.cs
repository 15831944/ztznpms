using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.Common;

namespace ztznpms.UI.图纸管理
{
    public partial class FrPresentation : Form
    {
        public string tuzhihao;
        public string mingchenghao;
        public string shebeiming;
        public string shangchuanshijian;

        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private string fileType = null;//文件类型
        private byte[] files;//文件
        private BinaryReader read = null;//二进制读取
        public FrPresentation()
        {
            InitializeComponent();
        }

        private void FrPresentation_Load(object sender, EventArgs e)
        {

        }

        private void btn_xztz_Click(object sender, EventArgs e)
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择文件时候发生了　　" + ex.Message);
            }
        }

        private void btn_sctz_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认提交吗？","提示",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    string shijian = DateTime.Now.ToString();

                    //string ConStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";

                    ////string ConStr = "Data Source=DESKTOP-ABRIFKO; Initial Catalog=db_ShengChanBu; Integrated Security=True";

                    //SqlConnection con = new SqlConnection(ConStr);
                    //con.Open();
                    //SqlCommand cmd = new SqlCommand("", con);
                    //cmd = con.CreateCommand();

                    if (shangchuanshijian == "")
                    {
                        //cmd.CommandText = "insert into db_tuzhi(图号,名称,设备名称,文件,图纸上传时间,文件类型) values('" + tuzhihao + "','" + mingchenghao + "','" + shebeiming + "',@pic,'" + shijian + "','" + fileType + "')";
                        string sqlsql = "insert into db_tuzhi(图号,名称,设备名称,文件,图纸上传时间,文件类型) values('" + tuzhihao + "','" + mingchenghao + "','" + shebeiming + "',@pic,'" + shijian + "','" + fileType + "')";
                        string retret = Convert.ToString(SQLhelp.ExecuteNonqueryByte(sqlsql, CommandType.Text, files));
                    }
                    else
                    {
                        //cmd.CommandText = "update db_tuzhi set 图纸上传时间='" + shijian + "', 文件=@pic, 文件类型='"+ fileType +"' where 图号='" + tuzhihao + "' and 名称='" + mingchenghao + "' and 设备名称='" + shebeiming + "'";

                        string sqlsql = "update db_tuzhi set 图纸上传时间='" + shijian + "', 文件=@pic, 文件类型='" + fileType + "' where 图号='" + tuzhihao + "' and 名称='" + mingchenghao + "' and 设备名称='" + shebeiming + "'";
                        string retret = Convert.ToString(SQLhelp.ExecuteNonqueryByte(sqlsql, CommandType.Text, files));
                    }


                    //cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@pic", files);
                    //cmd.ExecuteNonQuery();

                    string sql = "update db_jihuadan set 图纸上传时间='"+ shijian +"' where 图号='"+ tuzhihao +"' and 名称='"+ mingchenghao +"' and 设备名称='"+ shebeiming +"'";
                    int r1 = SQLhelp.ExecuteNonquery(sql, CommandType.Text);


                    if(r1 > 0)
                    {
                        MessageBox.Show("图纸提交成功！", "提示");
                        DialogResult = DialogResult.OK;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("提交" + fileName + "时候发生了" + ex.Message);
                }
            }
        }

    }
}
