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
using DevExpress.XtraPrinting;

namespace ztznpms.UI.查询项目
{
    public partial class Formdayinyulan : DevExpress.XtraEditors.XtraForm
    {

        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shebeimingcheng;
        public string shijian;

        private int b1 = 0, b2 = 0, b3 = 0, b4 = 0, b5 = 0, b6 = 0, b7 = 0, b8 = 0, b9 = 0, b10 = 0, b11 = 0, b12 = 0, b13 = 0, b14 = 0, b15 = 0, b16 = 0, b17 = 0, b18 = 0, b19 = 0, b20 = 0, b21 = 0, b22 = 0, b23 = 0, b24 = 0, b25 = 0; 
        public Formdayinyulan()
        {
            InitializeComponent();
        }

        private void Formdayinyulan_Load(object sender, EventArgs e)
        {
            reload();

            DrawRowIndicator(gridView4, 40);
        }

        private void reload()
        {
            string sql = "select number1,图号,名称,数量,目前到达工序,工序1,工序2,工序3,工序4,工序5,工序6,工序7,工序8,工序9,工序10,工序11,工序12,工序13,工序14,工序15,工序16,工序17,工序18,工序19,工序20,工序21,工序22,工序23,工序24,工序25 from db_xiangmu where 项目名称='" + xiangmumingcheng + "' and 设备名称='" + shebeimingcheng + "' and 工作令号='" + gongzuolinghao + "' and 时间='" + shijian + "' order by number1 asc";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                DataRow dr = dt.Rows[i];

                if (dr["工序25"].ToString() == "")
                    b1 += 1;

                if (dr["工序24"].ToString() == "")
                    b2 += 1;
                if (dr["工序23"].ToString() == "")
                    b3 += 1;
                if (dr["工序22"].ToString() == "")
                    b4 += 1;
                if (dr["工序21"].ToString() == "")
                    b5 += 1;
                if (dr["工序20"].ToString() == "")
                    b6 += 1;
                if (dr["工序19"].ToString() == "")
                    b7 += 1;
                if (dr["工序18"].ToString() == "")
                    b8 += 1;
                if (dr["工序17"].ToString() == "")
                    b9 += 1;
                if (dr["工序16"].ToString() == "")
                    b10 += 1;
                if (dr["工序15"].ToString() == "")
                    b11 += 1;
                if (dr["工序14"].ToString() == "")
                    b12 += 1;
                if (dr["工序13"].ToString() == "")
                    b13 += 1;
                if (dr["工序12"].ToString() == "")
                    b14 += 1;
                if (dr["工序11"].ToString() == "")
                    b15 += 1;
                if (dr["工序10"].ToString() == "")
                    b16 += 1;
                if (dr["工序9"].ToString() == "")
                    b17 += 1;
                if (dr["工序8"].ToString() == "")
                    b18 += 1;
                if (dr["工序7"].ToString() == "")
                    b19 += 1;
                if (dr["工序6"].ToString() == "")
                    b20 += 1;
                if (dr["工序5"].ToString() == "")
                    b21 += 1;
                if (dr["工序4"].ToString() == "")
                    b22 += 1;
                if (dr["工序3"].ToString() == "")
                    b23 += 1;
                if (dr["工序2"].ToString() == "")
                    b24 += 1;
                if (dr["工序1"].ToString() == "")
                    b25 += 1;

            }

            if (b1 == dt.Rows.Count)
            {
                gridView4.Columns["工序25"].Visible = false;
            }
            if (b2 == dt.Rows.Count)
            {
                gridView4.Columns["工序24"].Visible = false;
            }
            if (b3 == dt.Rows.Count)
            {
                gridView4.Columns["工序23"].Visible = false;
            }
            if (b4 == dt.Rows.Count)
            {
                gridView4.Columns["工序22"].Visible = false;
            }
            if (b5 == dt.Rows.Count)
            {
                gridView4.Columns["工序21"].Visible = false;
            }
            if (b6 == dt.Rows.Count)
            {
                gridView4.Columns["工序20"].Visible = false;
            }
            if (b7 == dt.Rows.Count)
            {
                gridView4.Columns["工序19"].Visible = false;
            }
            if (b8 == dt.Rows.Count)
            {
                gridView4.Columns["工序18"].Visible = false;
            }
            if (b9 == dt.Rows.Count)
            {
                gridView4.Columns["工序17"].Visible = false;
            }
            if (b10 == dt.Rows.Count)
            {
                gridView4.Columns["工序16"].Visible = false;
            }
            if (b11 == dt.Rows.Count)
            {
                gridView4.Columns["工序15"].Visible = false;
            }
            if (b12 == dt.Rows.Count)
            {
                gridView4.Columns["工序14"].Visible = false;
            }
            if (b13 == dt.Rows.Count)
            {
                gridView4.Columns["工序13"].Visible = false;
            }
            if (b14 == dt.Rows.Count)
            {
                gridView4.Columns["工序12"].Visible = false;
            }
            if (b15 == dt.Rows.Count)
            {
                gridView4.Columns["工序11"].Visible = false;
            }
            if (b16 == dt.Rows.Count)
            {
                gridView4.Columns["工序10"].Visible = false;
            }
            if (b17 == dt.Rows.Count)
            {
                gridView4.Columns["工序9"].Visible = false;
            }
            if (b18 == dt.Rows.Count)
            {
                gridView4.Columns["工序8"].Visible = false;
            }
            if (b19 == dt.Rows.Count)
            {
                gridView4.Columns["工序7"].Visible = false;
            }
            if (b20 == dt.Rows.Count)
            {
                gridView4.Columns["工序6"].Visible = false;
            }
            if (b21 == dt.Rows.Count)
            {
                gridView4.Columns["工序5"].Visible = false;
            }
            if (b22 == dt.Rows.Count)
            {
                gridView4.Columns["工序4"].Visible = false;
            }
            if (b23 == dt.Rows.Count)
            {
                gridView4.Columns["工序3"].Visible = false;
            }
            if (b24 == dt.Rows.Count)
            {
                gridView4.Columns["工序2"].Visible = false;
            }
            if (b25 == dt.Rows.Count)
            {
                gridView4.Columns["工序1"].Visible = false;
            }



            gridControl4.DataSource = dt;
            
        }
        public void DrawRowIndicator(DevExpress.XtraGrid.Views.Grid.GridView gv, int width)
        {
            gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView4_CustomDrawRowIndicator);
            if (width != 0)
            {
                if (width != 0)
                {
                    gv.IndicatorWidth = width;
                }
                else
                {
                    gv.IndicatorWidth = 30;
                }
            }
            else
            {
                gv.IndicatorWidth = 30;
            }

        }
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gridView4.OptionsPrint.AutoWidth = false;
            //PrintPreview(this.gridControl4);

            ////if (gridControl1.DataSource != null)
            ////{
            ////    PrintingSystem ps = new PrintingSystem();
            ////    PrintableComponentLink link = null;
            ////    link = new PrintableComponentLink(ps);
            ////    ps.Links.Add(link);
            ////    link.Component = gridControl1;
            ////    link.CreateDocument();
            ////    ps.PageSettings.PaperKind = PaperKind.A4;                        //纸张大小
            ////    ps.PageSettings.Landscape = true;                                   //是否为横向打印
            ////    ps.PageSettings.TopMargin = 76;                                     //上边距
            ////    ps.PageSettings.BottomMargin = 76;                                //下边距
            ////    ps.PageSettings.LeftMargin = 44;                                   //左边距
            ////    ps.PageSettings.RightMargin = 44;                                     //右边距
            ////    ps.Watermark.Image = Bitmap.FromFile("dabiao.png");              //设置水印图片
            ////    ps.Watermark.ImageAlign = ContentAlignment.MiddleCenter;      //水印对齐方式
            ////    ps.Watermark.ImageTiling = false;                                            //是否平铺图片
            ////    ps.Watermark.ImageViewMode = ImageViewMode.Stretch;         //设置图片显示方式
            ////    ps.Watermark.ImageTransparency = 200;                                  //设置水印图片的深浅度
            ////    ps.Watermark.ShowBehind = false;                                           //设置水印在打印内容的前面显示
            ////    ps.Print();                                       //直接打印，不显示打印预览

            ////}


            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = this.gridControl4;
            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            link.CreateDocument();
            link.ShowPreview();
        }
        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string a = gongzuolinghao + " " + xiangmumingcheng + " " + shebeimingcheng;
            //string title = string.Format("用户表-({0}年度)", "2016");
            string title = a;
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, title, Color.DarkBlue,
               new RectangleF(0, 0, 500, 40), BorderSide.None);

            brick.LineAlignment = BrickAlignment.Center;
            brick.Alignment = BrickAlignment.Center;
            brick.AutoWidth = true;
            brick.Font = new System.Drawing.Font("宋体", 11f, FontStyle.Bold);

        }

        private void PrintPreview(DevExpress.XtraPrinting.IPrintable gridControlPrint)
        {
            DevExpress.XtraPrintingLinks.CompositeLink compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink();
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();

            compositeLink.PrintingSystem = ps;
            compositeLink.Landscape = true;
            compositeLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
            DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

            ps.PageSettings.Landscape = true;
            
            link.Component = gridControlPrint;
            compositeLink.Links.Add(link);

            link.CreateDocument();  //建立文档
            ps.PreviewFormEx.Show();//进行预览  

        }

    }
}