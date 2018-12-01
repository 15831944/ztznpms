using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ztznpms.UI.项目管理;
using DevExpress.XtraTab;
using ztznpms.UI.查询项目;
using DevExpress.XtraTab.ViewInfo;
using ztznpms.UI.二维码;
using ztznpms.UI.工序管理;
using ztznpms.Common;
using ztznpms.UI.图纸管理;
using 项目管理系统.生产部;
using 项目管理系统;
using 项目管理系统.个人管理;
using DevExpress.DXCore.Controls.LookAndFeel;
using ztznpms.UI.检验;
using ztznpms.UI.人员管理;

namespace ztznpms
{
    public partial class newFormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string yonghu;
        public newFormMain()
        {
            InitializeComponent();
            this.xtraTabControl1.CloseButtonClick += new EventHandler(xtraTabControl1_CloseButtonClick);
           
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).PageVisible = false;
        }

        /// <summary>
        /// 项目总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "项目件自制";
            FormAllxiangmu form1 = new FormAllxiangmu();
            form1.yonghu = yonghu;
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        /// <summary>
        /// 机修自制件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 自制件工序管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "项目件工序";
            //DXFormgxgl form1 = new DXFormgxgl();
            FormGXgl form1 = new FormGXgl();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        /// <summary>
        /// 图号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FormXiangtongtuhao form = new FormXiangtongtuhao();
            //form.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //XtraTabPage newPage = new XtraTabPage();
            //newPage.Text = "技术更改";
            //FormJishugenggai form1 = new FormJishugenggai();
            //form1.TopLevel = false;
            //newPage.Controls.Add(form1);
            //form1.Show();
            //form1.Dock = DockStyle.Fill;
            //xtraTabControl1.TabPages.Add(newPage);
            //xtraTabControl1.SelectedTabPage = newPage;
        }

        /// <summary>
        /// 自制件扫码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FormSaoma a = new FormSaoma();
            //a.ShowDialog();
        }

        /// <summary>
        /// 机修件扫码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FormjixiujianSaoma form = new FormjixiujianSaoma();
            //form.Show();
        }

        /// <summary>
        /// 查看项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "查询项目自制件";
            FormChaxunXiangmu form1 = new FormChaxunXiangmu();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        /// <summary>
        /// 查看工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "查询项目工序";
            FormChaxungongxu form1 = new FormChaxungongxu();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void newFormMain_Load(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
        }



       

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormXiangtongtuhao form = new FormXiangtongtuhao();
            form.ShowDialog();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "技术更改件";
            FormJishugenggai form1 = new FormJishugenggai();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "排产时间表";
            Formshijianbiao form1 = new Formshijianbiao();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "排产计划";
            Formpaichan form1 = new Formpaichan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "选择排产";
            Formchadan form1 = new Formchadan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "机修件自制";
            FormJixiu form1 = new FormJixiu();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "机修件工序";
            Formjixiugxgl form1 = new Formjixiugxgl();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "项目总览";
            Formzonglan form1 = new Formzonglan();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }
        /// <summary>
        /// 机加工日报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "工资表统计";
            Frjijiagongtongji form1 = new Frjijiagongtongji();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;

            
        }
        /// <summary>
        /// 工艺已编写项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            //newPage.Name = "jixiu";
            newPage.Text = "工艺已编写项目";
            Formgongyi form1 = new Formgongyi();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        /// <summary>
        /// 装配管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "装配管理";
            FrZhuangpeiguanli form1 = new FrZhuangpeiguanli();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
            
        }

        /// <summary>
        /// 项目零件管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "加工管理";
                FrJiagongguanli form1 = new FrJiagongguanli();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }

        }

        /// <summary>
        /// 机修零件管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "机修业务";
                FrJixiuyewu form1 = new FrJixiuyewu();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        /// <summary>
        /// 工序外协管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "工序外协";
                Frgongxuwaixie form1 = new Frgongxuwaixie();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        /// <summary>
        /// 技术更改管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "技术更改";
                Frjishugenggai form1 = new Frjishugenggai();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        /// <summary>
        /// 备料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "备料";
                Frbeiliao form1 = new Frbeiliao();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        /// <summary>
        /// 排产计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "最高权限" && bummen != "生产")
            {
                MessageBox.Show("无权限！");
                return;
            }
            else
            {

                XtraTabPage newPage = new XtraTabPage();
                //newPage.Name = "jixiu";
                newPage.Text = "排产计划";
                Frpaichanjihua form1 = new Frpaichanjihua();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                //form1.yonghu = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            }
        }

        /// <summary>
        /// 物资领用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql = "select 物资领用 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "物料领用";
            Frwuzilingyong form1 = new Frwuzilingyong(yonghu);
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem8_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql = "select ERP生号 from tb_operator where 用户名='" + yonghu + "'";
            string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            if (bummen != "1")
            {
                MessageBox.Show("无权限!");
                return;
            }
            Frerpcreat form1 = new Frerpcreat();
            form1.yonghu = yonghu;
            form1.Show();
        }

        /// <summary>
        /// 项目总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "项目状态";
            Formxiangmuzhuangtai form1 = new Formxiangmuzhuangtai();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            //form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        /// <summary>
        /// 机加工日报审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "机加工日报审核";
            Formribaoshenhe form1 = new Formribaoshenhe();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }
        /// <summary>
        /// 装配日报表审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //string sql = "select 权限 from tb_operator where 用户名='" + yonghu + "'";
            //string bummen = sqlhelp111.ExecuteScalar(sql, CommandType.Text).ToString();
            //if (bummen != "最高权限" && bummen != "生产")
            //{
            //    MessageBox.Show("无权限！");
            //    return;
            //}
            //else
            //{

                XtraTabPage newPage = new XtraTabPage();
                newPage.Text = "派工单管理";
                FormPaigongdan form1 = new FormPaigongdan();
                form1.TopLevel = false;
                newPage.Controls.Add(form1);
                form1.Show();
                form1.yonghuming = yonghu;
                form1.Dock = DockStyle.Fill;
                xtraTabControl1.TabPages.Add(newPage);
                xtraTabControl1.SelectedTabPage = newPage;
            //}
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "成品入库";
            Formchengpinruku form1 = new Formchengpinruku();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.yonghu = yonghu;
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "工艺排产状态";
            FormPaichanzhuangtai form1 = new FormPaichanzhuangtai();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "项目工艺状态";
            Formtuzhigongyizhuangtai form1 = new Formtuzhigongyizhuangtai();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        /// <summary>
        /// 机修件组件工艺编制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem25_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "机修件组件工艺编制";
            Formjixiuzujian form1 = new Formjixiuzujian();
            form1.TopLevel = false;
            form1.yonghu = yonghu;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "查询零件";
            Formchaxunlingjian form1 = new Formchaxunlingjian();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }
    }
}