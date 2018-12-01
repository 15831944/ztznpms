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
    public partial class FormShezhijixiujiangongxu : Form
    {
        public string kehumingcheng;
        public string jiagongneirong;
        public string jiedanbianhao;
        public string gongjianmingcheng;

        public string shunxu1;
        public string gongxuming1;
        public string neirong1;
        public string fuzeren1;
        public string jiage1;
        public string shuliang1;

        public string cailiao1;
        public string zhongliang1;

        public string gxID;//id

        public string xuhao;

        public string zhuyidian;
        public FormShezhijixiujiangongxu()
        {
            InitializeComponent();
        }

        private void FormShezhijixiujiangongxu_Load(object sender, EventArgs e)
        {
            string s1 = "select * from db_chejianrenyuan";
            DataTable sz = SQLhelp.GetDataTable(s1, CommandType.Text);

            foreach (DataRow dr in sz.Rows)
            {
                this.comboBox1.Items.Add(dr["机加车间人员"].ToString());
            }

            string s2 = "select * from db_gongxumingcheng";
            DataTable sz2 = SQLhelp.GetDataTable(s2, CommandType.Text);

            foreach (DataRow dr in sz2.Rows)
            {
                this.comboBox2.Items.Add(dr["工序名称"].ToString());
            }

            txt_xiangmumingcheng.Text = kehumingcheng;
            txt_tuhao.Text = jiagongneirong;
            txt_mingcheng.Text = gongjianmingcheng;
            txt_gonglinghao.Text = jiedanbianhao;
            
            txt_shunxu.Text = shunxu1;
            comboBox2.Text = gongxuming1;
            txt_neirong.Text = neirong1;
            comboBox1.Text = fuzeren1;
            txt_gxjiage.Text = jiage1;
            txt_cailiao.Text = cailiao1;
            txt_zhongliang.Text = zhongliang1;
            richTextBox1.Text = zhuyidian;
            txt_shuliang.Text = shuliang1;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string a = "";//记录工序名称
            string b = "";//记录工序负责人
            string c = "";//记录工序价格
            string d = "";//记录工序内容
            string txt = "";//以前的标记内容
            string xiugaigongxu = "";

            DateTime time1 = DateTime.Now;
            string time2 = Convert.ToString(time1);

            if (comboBox2.Text.Trim() == "")
            {
                MessageBox.Show("工序名称不能为空!", "提示");
                return;
            }
            if (txt_neirong.Text == "")
            {
                MessageBox.Show("工序内容不能为空！", "提示");
                return;
            }

            string sql3 = "select 标记 from db_gongxu111 where 加工内容='" + txt_tuhao.Text + "' and 工序顺序='" + txt_shunxu.Text + "' and 客户名称='" + txt_xiangmumingcheng.Text + "' and 工件名称='" + txt_mingcheng.Text + "' and 接单编号='"+ txt_gonglinghao.Text +"'";
            string ret3 = Convert.ToString(SQLhelp.ExecuteScalar(sql3, CommandType.Text));

            txt = ret3;

            //增加判断修改了哪些工序
            //1、修改了工序名称
            if (comboBox2.Text.Trim() != gongxuming1)
            {
                a = time2 + "修改了工序名称" + '(' + gongxuming1 + ')';
            }
            //2、修改了工序负责人
            if (comboBox1.Text.Trim() != fuzeren1)
            {
                b = time2 + "修改了操作人" + '(' + fuzeren1 + ')';
            }
            //3、修改了价格
            if (txt_gxjiage.Text.Trim() != jiage1)
            {
                c = time2 + "修改了工序价格" + '(' + jiage1 + ')';
            }
            //4、修改了内容
            if (txt_neirong.Text != neirong1)
            {
                d = time2 + "修改了工序内容" + '(' + neirong1 + ')';
            }

            if (txt != "" && a != "" && b != "" && c != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + '\n' + d;
            }
            if (txt != "" && a != "" && b != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + d;
            }
            if (txt != "" && a != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + c + d;
            }
            if (txt != "")
            {
                xiugaigongxu = txt + '\n' + a + b + c + d;
            }

            if (a != "")
            {
                xiugaigongxu = txt + a + '\n' + b + c + d;
            }
            if (a != "" && txt != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + c + d;
            }
            if (a != "" && txt != "" && b != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + d;
            }
            if (a != "" && txt != "" && b != "" && c != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + '\n' + d;
            }

            if (b != "")
            {
                xiugaigongxu = txt + a + b + '\n' + c + d;
            }
            if (b != "" && txt != "")
            {
                xiugaigongxu = txt + '\n' + a + b + '\n' + c + d;
            }
            if (b != "" && txt != "" && a != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + d;
            }
            if (b != "" && txt != "" && a != "" && c != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + '\n' + d;
            }

            if (c != "")
            {
                xiugaigongxu = txt + a + b + c + '\n' + d;
            }
            if (c != "" && txt != "")
            {
                xiugaigongxu = txt + '\n' + a + b + c + '\n' + d;
            }
            if (c != "" && txt != "" && a != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + c + '\n' + d;
            }
            if (c != "" && txt != "" && a != "" && b != "")
            {
                xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + '\n' + d;
            }

            //xiugaigongxu = txt + '\n' + a + '\n' + b + '\n' + c + '\n' + d;

            string s1 = "update db_shunxu111 set 工序名称='" + comboBox2.Text + "' where 加工内容='" + txt_tuhao.Text + "' and 工序顺序='" + txt_shunxu.Text + "' and 接单编号='"+ txt_gonglinghao.Text + "' and 客户名称='" + txt_xiangmumingcheng.Text + "' and 工件名称='" + txt_mingcheng.Text + "'";
            string r1 = Convert.ToString(SQLhelp.ExecuteNonquery(s1, CommandType.Text));

            string sql = "update db_gongxu111 set 工序名称='" + comboBox2.Text + "',机修件数量='"+ txt_shuliang.Text +"',负责人='" + comboBox1.Text + "', 工序内容='" + txt_neirong.Text + "', 价格='" + txt_gxjiage.Text + "', 标记='" + xiugaigongxu + "',材料='"+ txt_cailiao.Text +"', 重量='"+ txt_zhongliang.Text +"',工艺注意点='"+ richTextBox1.Text +"' where id = '"+ gxID +"'";

            string SQL1 = "select 结束时间 from db_gongxu111 where 序号='"+ xuhao +"' and 工序顺序='"+ txt_shunxu.Text +"'";
            string RET1 = Convert.ToString(SQLhelp.ExecuteScalar(SQL1, CommandType.Text));
            string xiugaistr = comboBox2.Text.Trim() + RET1;

            string sql1 = "update db_jixiujian set 工序" + txt_shunxu.Text + "='" + xiugaistr + "' where 序号='" + xuhao + "'";
            SQLhelp.ExecuteNonquery(sql1, CommandType.Text);

            string r = Convert.ToString(SQLhelp.ExecuteNonquery(sql, CommandType.Text));
            if (r != "")
            {
                MessageBox.Show("设置工序成功！", "提示");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("设置工序失败！", "提示");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
