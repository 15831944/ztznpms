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
    public partial class FormCharujixiujiangongxu : Form
    {
        public string kehumingcheng2;
        public string jiagongneirong2;
        public string jiedanbianhao2;
        public string gongjianmingcheng2;
        public string bumen2;

        public string shunxu2;
        public string shuliang2;

        public string tag;
        public string xuhao;

        public string leixingming;
        public FormCharujixiujiangongxu()
        {
            InitializeComponent();
        }

        private void FormCharujixiujiangongxu_Load(object sender, EventArgs e)
        {
            string s1 = "select * from db_chejianrenyuan";
            DataTable cr = SQLhelp.GetDataTable(s1, CommandType.Text);

            foreach (DataRow dr in cr.Rows)
            {
                //this.com_fuzeren.Items.Add(dr["机加车间人员"].ToString());

                string a = dr["机加车间人员"].ToString();
                if (com_fuzeren.Items.Cast<object>().All(x => x.ToString() != a))
                    com_fuzeren.Items.Add(a);
            }

            string s2 = "select * from db_gongxumingcheng";
            DataTable cr2 = SQLhelp.GetDataTable(s2, CommandType.Text);

            foreach (DataRow dr in cr2.Rows)
            {
                this.com_mingcheng.Items.Add(dr["工序名称"].ToString());
            }

            txt_xiangmumingcheng.Text = kehumingcheng2;
            txt_tuhao.Text = jiagongneirong2;
            txt_mingcheng.Text = gongjianmingcheng2;
            txt_gonglinghao.Text = jiedanbianhao2;
            txt_bumen.Text = bumen2;

            txt_shunxu.Text = shunxu2;
            txt_shuliang.Text = shuliang2;
            
            btn_save.Enabled = false;
        }

        /// <summary>
        /// 保存插入的工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Now;
            string time2 = Convert.ToString(time1);

            if (com_mingcheng.Text.Trim() == "")
            {
                MessageBox.Show("请输入工序名称！", "提示");
                return;
            }
            if (com_shebeiming.Text.Trim() == "")
            {
                MessageBox.Show("请选择设备！", "提示");
                return;
            }
            //if (txt_neirong.Text == "")
            //{
            //    MessageBox.Show("请输入工序内容！", "提示");
            //    return;
            //}
            //if (txt_jiage.Text == "")
            //{
            //    MessageBox.Show("请输入工序价格!", "提示");
            //    return;
            //}
            if(txt_jiage.Text == "")
            {
                txt_jiage.Text = "0";
            }

            if (tag == "选择")
            {
                string charugongxu = time2 + "插入了工序";

                string s5 = "update db_shunxu111 set 工序顺序 = 工序顺序 + 1 where 序号='"+ xuhao +"' and 加工内容 = '" + txt_tuhao.Text + "' and 工件名称 = '" + txt_mingcheng.Text + "' and 接单编号 = '" + txt_gonglinghao.Text + "' and 工序顺序 >= '" + txt_shunxu.Text + "'";
                string r5 = Convert.ToString(SQLhelp.ExecuteNonquery(s5, CommandType.Text));

                string s6 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_xiangmumingcheng.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "', '" + txt_gonglinghao.Text + "', '" + com_mingcheng.Text + "', '" + textBox1.Text + "','"+ xuhao +"')";
                string r6 = Convert.ToString(SQLhelp.ExecuteNonquery(s6, CommandType.Text));

                if (com_shebeiming.Text.Trim() != "")
                {
                    string str1 = "update db_Paichan set 工序顺序=工序顺序+1 where 序号='" + xuhao + "' and 工序顺序 >='" + txt_shunxu.Text + "'";
                    SQLhelp.ExecuteNonquery(str1, CommandType.Text);

                    string str11 = "select 预交时间 from db_jixiujian where 序号='" + xuhao + "'";
                    string ret11 = Convert.ToString(SQLhelp.ExecuteScalar(str11, CommandType.Text));

                    string str2 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_xiangmumingcheng.Text + "','" + txt_shuliang.Text + "','" + txt_jiage.Text + "','" + xuhao + "','" + com_shebeiming.Text + "','" + textBox1.Text + "','" + com_mingcheng.Text + "','" + time1 + "','" + com_fuzeren.Text + "','" + txt_mingcheng.Text + "','机修','" + ret11 + "')";
                    SQLhelp.ExecuteNonquery(str2, CommandType.Text);
                }

                string s1 = "update db_gongxu111 set 工序顺序 = 工序顺序 + 1 where 序号='" + xuhao + "' and  加工内容 = '" + txt_tuhao.Text + "' and 工件名称 = '" + txt_mingcheng.Text + "' and 接单编号 = '" + txt_gonglinghao.Text + "' and 工序顺序 >= '" + txt_shunxu.Text + "'";
                int r1 = SQLhelp.ExecuteNonquery(s1, CommandType.Text);

                if(textBox1.Text.Trim() == "1")
                {
                    string s2 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,标记,部门,序号,材料,重量,工艺注意点,工序设备,状态,label,类型) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shuliang.Text.Trim() + "','" + com_mingcheng.Text.Trim() + "', '" + textBox1.Text + "', '" + txt_neirong.Text + "','" + txt_jiage.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu + "','" + txt_bumen.Text + "','" + xuhao + "', '" + txt_cailiao.Text + "', '" + txt_zhongliang.Text + "','" + richTextBox1.Text + "','" + com_shebeiming.Text + "','0','显示','"+ leixingming +"')";
                    int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);

                    string s3 = "update db_gongxu111 set label='不显示' where 序号='" + xuhao + "' and 工序顺序 > '" + txt_shunxu.Text + "'";
                    SQLhelp.ExecuteNonquery(s3, CommandType.Text);

                    if (r2 > 0)
                    {
                        MessageBox.Show("插入工序成功!", "提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("插入工序失败！", "提示");
                    }
                }

                if(textBox1.Text.Trim() != "1")
                {
                    string s2 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,标记,部门,序号,材料,重量,工艺注意点,工序设备,状态,label,类型) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "','" + txt_shuliang.Text.Trim() + "','" + com_mingcheng.Text.Trim() + "', '" + textBox1.Text + "', '" + txt_neirong.Text + "','" + txt_jiage.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu + "','" + txt_bumen.Text + "','" + xuhao + "', '" + txt_cailiao.Text + "', '" + txt_zhongliang.Text + "','" + richTextBox1.Text + "','" + com_shebeiming.Text + "','0','不显示','"+ leixingming +"')";
                    int r2 = SQLhelp.ExecuteNonquery(s2, CommandType.Text);
                    if (r2 > 0)
                    {
                        MessageBox.Show("插入工序成功!", "提示");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("插入工序失败！", "提示");
                    }
                }

            }

            if (tag == "最后")
            {
                string charugongxu2 = time2 + "插入了工序";

                string s3 = "select max(工序顺序)from db_gongxu111 where 序号='" + xuhao + "' and  加工内容 = '" + txt_tuhao.Text + "' and 工件名称 = '" + txt_mingcheng.Text + "' and 接单编号 = '" + txt_gonglinghao.Text + "' and 工序顺序 >= '" + txt_shunxu.Text + "'";
                int r3 = Convert.ToInt32(SQLhelp.ExecuteScalar(s3, CommandType.Text));
                int gongxushunxu = r3 + 1;

                string s7 = "insert into db_shunxu111(客户名称,工件名称,加工内容,接单编号,工序名称,工序顺序,序号) values('" + txt_xiangmumingcheng.Text + "','" + txt_mingcheng.Text + "','" + txt_tuhao.Text + "', '" + txt_gonglinghao.Text + "', '" + com_mingcheng.Text + "', '" + gongxushunxu + "','"+ xuhao +"')";
                string r7 = Convert.ToString(SQLhelp.ExecuteNonquery(s7, CommandType.Text));

                if (com_shebeiming.Text.Trim() != "")
                {

                    string str11 = "select 预交时间 from db_jixiujian where 序号='" + xuhao + "'";
                    string ret11 = Convert.ToString(SQLhelp.ExecuteScalar(str11, CommandType.Text));

                    string str2 = "insert into db_Paichan(项目名称,工作令号,设备名称,数量,价格,序号,工序设备,工序顺序,工序名称,工艺制定时间,负责人,零件名称,类型,交货日期) values('" + txt_mingcheng.Text + "','" + txt_gonglinghao.Text + "','" + txt_xiangmumingcheng.Text + "','" + txt_shuliang.Text + "','" + txt_jiage.Text + "','" + xuhao + "','" + com_shebeiming.Text + "','" + gongxushunxu + "','" + com_mingcheng.Text + "','" + time1 + "','" + com_fuzeren.Text + "','" + txt_mingcheng.Text + "','机修','" + ret11 + "')";
                    SQLhelp.ExecuteNonquery(str2, CommandType.Text);
                }

                string s4 = "insert into db_gongxu111(客户名称,加工内容,工件名称,接单编号,机修件数量,工序名称,工序顺序,工序内容,价格,负责人,标记,部门,序号,材料,重量,工艺注意点,工序设备,状态,label,类型) values('" + txt_xiangmumingcheng.Text + "', '" + txt_tuhao.Text + "', '" + txt_mingcheng.Text + "', '" + txt_gonglinghao.Text + "', '" + txt_shuliang.Text + "','" + com_mingcheng.Text.Trim() + "', '" + gongxushunxu + "', '" + txt_neirong.Text + "','" + txt_jiage.Text + "', '" + com_fuzeren.Text.Trim() + "','" + charugongxu2 + "','"+ txt_bumen.Text +"','"+ xuhao +"','"+ txt_cailiao.Text +"','"+ txt_zhongliang.Text +"','"+ richTextBox1.Text +"','"+ com_shebeiming.Text +"','0','不显示','"+ leixingming +"')";
                int r4 = SQLhelp.ExecuteNonquery(s4, CommandType.Text);
                if (r4 > 0)
                {
                    MessageBox.Show("插入工序成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("插入工序失败！", "提示");
                }
            }

            string SQL1 = "select * from db_gongxu111 where 序号='" + xuhao + "' order by 工序顺序 asc";
            DataTable table = SQLhelp.GetDataTable(SQL1, CommandType.Text);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];

                string gongxstr = dr["工序名称"].ToString() + dr["结束时间"].ToString();
                string SQL2 = "update db_jixiujian set 工序" + (i + 1) + "='" + gongxstr + "' where 序号='" + xuhao + "'";
                SQLhelp.ExecuteNonquery(SQL2, CommandType.Text);
            }

            string SQL3 = "select max(工序顺序) from db_gongxu111 where 序号='" + xuhao + "'";
            string RET3 = Convert.ToString(SQLhelp.ExecuteScalar(SQL3, CommandType.Text));
            if (RET3 != "")
            {
                int shun3 = Convert.ToInt32(RET3);
                for (int i = shun3 + 1; i <= 25; i++)
                {
                    string SQL13 = "update db_jixiujian set 工序" + i + "=NULL where 序号='" + xuhao + "'";
                    SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                }

            }
            else//全删除了
            {
                for (int i = 1; i <= 25; i++)
                {
                    string SQL13 = "update db_jixiujian set 工序" + i + "=NULL where 序号='" + xuhao + "'";
                    SQLhelp.ExecuteNonquery(SQL13, CommandType.Text);
                }

            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbt_xuanze1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_xuanze1.Checked == true)
            {
                textBox1.Text = "";
                btn_save.Enabled = true;
            }
            int a = Convert.ToInt32(txt_shunxu.Text);//当前的工序顺序
                                                     //a=1,2,3,4...

            int b = a;//选择插入时，插入的工序为当前顺序
            string c = Convert.ToString(b);
            textBox1.Text = c;

            tag = "选择";
        }

        private void rbt_zuihou_CheckedChanged(object sender, EventArgs e)
        {
            if (rbt_zuihou.Checked == true)
            {
                textBox1.Text = "";
                btn_save.Enabled = true;
            }

            tag = "最后";
        }

        private void com_shebeiming_Click(object sender, EventArgs e)
        {
            com_shebeiming.Text = "";
            com_shebeiming.Items.Clear();
            string sql = "select 设备名 from db_chejianrenyuan where 机加车间人员='" + com_fuzeren.Text.Trim() + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["设备名"].ToString();
                    if (com_shebeiming.Items.Cast<object>().All(x => x.ToString() != a))
                        com_shebeiming.Items.Add(a);
                    com_shebeiming.SelectedIndex = 0;
                }
            }
        }

        private void txt_jiage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (txt_jiage.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(txt_jiage.Text, out oldf);

                    b2 = float.TryParse(txt_jiage.Text + e.KeyChar.ToString(), out f);

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
