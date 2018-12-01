using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.UI;
using ztznpms.UI.项目管理;
using ztznpms.UI.工序管理;
using ztznpms.UI.查询项目;
using ztznpms.UI.二维码;
using ztznpms.UI.检验;
using ztznpms.Common;
using DevComponents.DotNetBar;

namespace ztznpms
{
    public partial class FormMain : Office2007Form
    {
        public string renyuanguanli;
        public string xiangmuguanli;
        public string gongxuguanli;
        public string tuhaochaxun;
        public string jianyan;
        public string saoma;

        public string yonghuming;

        public FormMain()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {

            #region 权限管理

            string sql = "select * from db_operator where OperatorName = '" + yonghuming + "'";
            string ret = Convert.ToString(SQLhelp.ExecuteScalar(sql, CommandType.Text));

            //if (ret != "")
            //{
            //    //toolStripButton2.Enabled = true;
            //    //toolStripButton3.Enabled = true;
            //    //toolStripButton7.Enabled = true;
            //    //toolStripButton8.Enabled = true;
            //    //toolStripButton9.Enabled = true;
            //    //toolStripButton10.Enabled = true;
            //    expandablePanel2.Enabled = true;
            //    expandablePanel3.Enabled = true;
            //    expandablePanel4.Enabled = true;
            //}
            //else
            //{
            //    //toolStripButton2.Enabled = false;
            //    //toolStripButton3.Enabled = false;
            //    //toolStripButton7.Enabled = false;
            //    //toolStripButton8.Enabled = false;
            //    //toolStripButton9.Enabled = false;
            //    //toolStripButton10.Enabled = false;
            //    expandablePanel2.Enabled = false;
            //    expandablePanel3.Enabled = false;
            //    expandablePanel4.Enabled = false;
            //}

            #endregion


        }

        #region 以往版本
        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    FormPeople a = new FormPeople();
        //    a.Show();
        //}

        //private void toolStripButton2_Click(object sender, EventArgs e)
        //{
        //    FormXiangmu a = new FormXiangmu();
        //    a.Show();
        //}

        //private void toolStripButton3_Click(object sender, EventArgs e)
        //{
        //    FormGxgl a = new FormGxgl();
        //    a.Show();
        //}

        //private void toolStripButton4_Click(object sender, EventArgs e)
        //{
        //    //Formcxxm a = new Formcxxm();
        //    //a.Show();
        //    FormChaxunXiangmu form = new FormChaxunXiangmu();
        //    form.Show();
        //}

        //private void toolStripButton5_Click(object sender, EventArgs e)
        //{
        //    Formcxgx a = new Formcxgx();
        //    a.Show();
        //}

        //private void toolStripButton6_Click(object sender, EventArgs e)
        //{
        //    FormSaoma a = new FormSaoma();
        //    a.ShowDialog();
        //}

        //private void toolStripButton7_Click(object sender, EventArgs e)
        //{
        //    FormAllxiangmu form = new FormAllxiangmu();
        //    form.Show();
        //}

        //private void toolStripButton2_Click(object sender, EventArgs e)
        //{
        //    FormXiangtongtuhao form = new FormXiangtongtuhao();
        //    form.ShowDialog();
        //}

        //private void toolStripButton8_Click(object sender, EventArgs e)
        //{
        //    FormTest form = new FormTest();
        //    form.Show();
        //}

        //private void toolStripButton1_Click_1(object sender, EventArgs e)
        //{
        //    FormShixiang form = new FormShixiang();
        //    form.yonghu = yonghuming;
        //    form.Show();
        //}

        //private void toolStripButton9_Click(object sender, EventArgs e)
        //{
        //    FormJixiu form = new FormJixiu();
        //    form.Show();
        //}

        //private void toolStripButton10_Click(object sender, EventArgs e)
        //{
        //    FormJishugenggai form = new FormJishugenggai();
        //    form.Show();
        //}

        //private void toolStripButton11_Click(object sender, EventArgs e)
        //{
        //    FormjixiujianSaoma form = new FormjixiujianSaoma();
        //    form.Show();
        //}
        #endregion

        /// <summary>
        /// 项目管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            FormAllxiangmu form = new FormAllxiangmu();
            form.Show();
        }
        /// <summary>
        /// 工序管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            DXFormgxgl a = new DXFormgxgl();
            a.Show();
        }
        /// <summary>
        /// 图号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            FormXiangtongtuhao form = new FormXiangtongtuhao();
            form.ShowDialog();
        }
        /// <summary>
        /// 技术更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            FormJishugenggai form = new FormJishugenggai();
            form.Show();
        }
        /// <summary>
        /// 机修业务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            FormJixiu form = new FormJixiu();
            form.Show();
        }
        /// <summary>
        /// 自制件检验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            FormTest form = new FormTest();
            form.Show();
        }
        /// <summary>
        /// 自制件扫码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            FormSaoma a = new FormSaoma();
            a.ShowDialog();
        }
        /// <summary>
        /// 机修件扫码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem8_Click(object sender, EventArgs e)
        {
            FormjixiujianSaoma form = new FormjixiujianSaoma();
            form.Show();
        }
        /// <summary>
        /// 查看项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem9_Click(object sender, EventArgs e)
        {
            FormChaxunXiangmu form = new FormChaxunXiangmu();
            form.Show();
        }
        /// <summary>
        /// 查看工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem10_Click(object sender, EventArgs e)
        {
            Formcxgx a = new Formcxgx();
            a.Show();
        }
        /// <summary>
        /// 个人事项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem11_Click(object sender, EventArgs e)
        {
            FormShixiang form = new FormShixiang();
            form.yonghu = yonghuming;
            form.Show();
        }

    }
}
