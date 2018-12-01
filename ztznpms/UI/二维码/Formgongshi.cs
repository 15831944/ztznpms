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

namespace ztznpms.UI.二维码
{
    public partial class Formgongshi : DevExpress.XtraEditors.XtraForm
    {
        double jiagexichaung1 = 0;
        double jiagexichuang2 = 0;

        double jiagetangchuang1 = 0;
        double jiagetangchuang2 = 0;
        double jiagetangchuang = 0;

        double jiagelongmenxi1 = 0;
        double jiagelongmenxi2 = 0;
        double jiagelongmenxi = 0;

        double jiagejiagongzhongxin1 = 0;
        double jiagejiagongzhongxin2 = 0;
        double jiagejiagongzhongxin = 0;

        double jiagehanjie = 0;

        double jiageshuche = 0;
        double jiagepuche = 0;
        public Formgongshi()
        {
            InitializeComponent();
        }

        private void Formgongshi_Load(object sender, EventArgs e)
        {
            reload();

            com_xichuangcaizhi1.Properties.Items.Add("0.5");
            com_xichuangcaizhi1.Properties.Items.Add("0.6");
            com_xichuangcaizhi1.Properties.Items.Add("0.7");
            com_xichuangcaizhi1.Properties.Items.Add("1");
            com_xichuangcaizhi1.Properties.Items.Add("1.1");
            com_xichuangcaizhi1.Properties.Items.Add("1.2");

            com_xichuangcaizhi2.Properties.Items.Add("0.5");
            com_xichuangcaizhi2.Properties.Items.Add("0.6");
            com_xichuangcaizhi2.Properties.Items.Add("0.7");
            com_xichuangcaizhi2.Properties.Items.Add("1");
            com_xichuangcaizhi2.Properties.Items.Add("1.1");
            com_xichuangcaizhi2.Properties.Items.Add("1.2");

            com_tiaojian.Properties.Items.Add("≤0.8");
            com_tiaojian.Properties.Items.Add("＞0.8");

            com_caizhitangchuang.Properties.Items.Add("0.5");
            com_caizhitangchuang.Properties.Items.Add("0.6");
            com_caizhitangchuang.Properties.Items.Add("0.7");
            com_caizhitangchuang.Properties.Items.Add("1");
            com_caizhitangchuang.Properties.Items.Add("1.1");
            com_caizhitangchuang.Properties.Items.Add("1.2");

            com_caizhilongmenxi.Properties.Items.Add("0.5");
            com_caizhilongmenxi.Properties.Items.Add("0.6");
            com_caizhilongmenxi.Properties.Items.Add("0.7");
            com_caizhilongmenxi.Properties.Items.Add("1");
            com_caizhilongmenxi.Properties.Items.Add("1.1");
            com_caizhilongmenxi.Properties.Items.Add("1.2");

            com_caizhizhongxin.Properties.Items.Add("0.5");
            com_caizhizhongxin.Properties.Items.Add("0.6");
            com_caizhizhongxin.Properties.Items.Add("0.7");
            com_caizhizhongxin.Properties.Items.Add("1");
            com_caizhizhongxin.Properties.Items.Add("1.1");
            com_caizhizhongxin.Properties.Items.Add("1.2");

            com_caizhishuche.Properties.Items.Add("0.5");
            com_caizhishuche.Properties.Items.Add("0.6");
            com_caizhishuche.Properties.Items.Add("0.7");
            com_caizhishuche.Properties.Items.Add("1");
            com_caizhishuche.Properties.Items.Add("1.1");
            com_caizhishuche.Properties.Items.Add("1.2");

            com_caizhipuche.Properties.Items.Add("0.5");
            com_caizhipuche.Properties.Items.Add("0.6");
            com_caizhipuche.Properties.Items.Add("0.7");
            com_caizhipuche.Properties.Items.Add("1");
            com_caizhipuche.Properties.Items.Add("1.1");
            com_caizhipuche.Properties.Items.Add("1.2");

            com_jingdushuche.Properties.Items.Add("1.4");
            com_jingdushuche.Properties.Items.Add("1.2");
            com_jingdushuche.Properties.Items.Add("1");

            com_jingdupuche.Properties.Items.Add("1.4");
            com_jingdupuche.Properties.Items.Add("1.2");
            com_jingdupuche.Properties.Items.Add("1");
        }

        private void reload()
        {
            string sql = "select * from db_xishubiao";
            DataTable dt = SQLhelp.GetDataTable(sql, CommandType.Text);

            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
        }

        /// <summary>
        /// 铣床（外形）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiagexichuang1_Click(object sender, EventArgs e)
        {
            txt_jiagexichuang1.Text = "";
            if(com_xichuangcaizhi1.Text.Trim() != "" && txt_zhongliang1.Text.Trim() != "" && txt_mianshu1.Text.Trim() != "")
            {
                double zhongliang = Convert.ToDouble(txt_zhongliang1.Text.Trim());
                double mianshu = Convert.ToDouble(txt_mianshu1.Text.Trim());
                double caizhi = Convert.ToDouble(com_xichuangcaizhi1.Text.Trim());
                jiagexichaung1 = Math.Round((Math.Pow(zhongliang, 0.15) * 7 + 2 * mianshu) * caizhi, 1);
                txt_jiagexichuang1.Text = Convert.ToString(jiagexichaung1);
            }
        }
        /// <summary>
        /// 铣床键槽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiagexichuang2_Click(object sender, EventArgs e)
        {
            txt_jiagexichuang2.Text = "";
            if (com_xichuangcaizhi2.Text.Trim() != "" && txt_zhongliang2.Text.Trim() != "" && com_tiaojian.Text.Trim() != "")
            {
                if(com_tiaojian.SelectedIndex == 0)
                {
                    double zhongliang = Convert.ToDouble(txt_zhongliang2.Text.Trim());
                    double caizhi = Convert.ToDouble(com_xichuangcaizhi2.Text.Trim());
                    jiagexichuang2 = Math.Round((5 * Math.Pow(4, (1.1 * zhongliang))) * caizhi, 1);
                }
                if(com_tiaojian.SelectedIndex == 1)
                {
                    double zhongliang = Convert.ToDouble(txt_zhongliang2.Text.Trim());
                    double caizhi = Convert.ToDouble(com_xichuangcaizhi2.Text.Trim());
                    jiagexichuang2 = Math.Round((Math.Log10(zhongliang) * 100 + 30) * caizhi, 1);
                }
                txt_jiagexichuang2.Text = Convert.ToString(jiagexichuang2);
            }
        }
        /// <summary>
        /// 镗床
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiagetangchuang_Click(object sender, EventArgs e)
        {
            txt_jiagetangchuang.Text = "";
            txt_jiagetangchuang1.Text = "";
            txt_jiagetangchuang2.Text = "";
            if(com_caizhitangchuang.Text.Trim() != "" && txt_zhongliangtangchuang1.Text.Trim() != "" && txt_zhongliangtangchuang2.Text.Trim() != "")
            {
                double caizhi = Convert.ToDouble(com_caizhitangchuang.Text.Trim());
                double zhongliang1 = Convert.ToDouble(txt_zhongliangtangchuang1.Text.Trim());
                double zhongliang2 = Convert.ToDouble(txt_zhongliangtangchuang2.Text.Trim());
                jiagetangchuang1 = (Math.Pow(zhongliang2, 0.28) + 0.3) * 15;
                txt_jiagetangchuang1.Text = Convert.ToString(jiagetangchuang1);

                if(zhongliang1 < 100)
                {
                    jiagetangchuang2 = 0.27 * zhongliang1;
                }
                else
                {
                    jiagetangchuang2 = 0.22 * zhongliang1;
                }
                txt_jiagetangchuang2.Text = Convert.ToString(jiagetangchuang2);

                jiagetangchuang = Math.Round((jiagetangchuang1 + jiagetangchuang2) * caizhi, 1);
                txt_jiagetangchuang.Text = Convert.ToString(jiagetangchuang);              
                
            }
        }
        /// <summary>
        /// 龙门铣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiagelongmenxi_Click(object sender, EventArgs e)
        {
            txt_jiagelongmenxi.Text = "";
            txt_jiagelongmenxi1.Text = "";
            txt_jiagelongmenxi2.Text = "";
            if(com_caizhilongmenxi.Text.Trim() != "" && txt_zhonglianglongmenxi1.Text.Trim() != "" && txt_zhonglianglongmenxi2.Text.Trim() != "")
            {
                double caizhi = Convert.ToDouble(com_caizhilongmenxi.Text.Trim());
                double zhongliang1 = Convert.ToDouble(txt_zhonglianglongmenxi1.Text.Trim());
                double zhongliang2 = Convert.ToDouble(txt_zhonglianglongmenxi2.Text.Trim());
                jiagelongmenxi1 = (Math.Pow(zhongliang2, 0.28) + 0.3) * 18;
                txt_jiagelongmenxi1.Text = Convert.ToString(jiagelongmenxi1);

                jiagelongmenxi2 = zhongliang1 * 0.18;
                txt_jiagelongmenxi2.Text = Convert.ToString(jiagelongmenxi2);

                jiagelongmenxi = Math.Round((jiagelongmenxi1 + jiagelongmenxi2) * caizhi, 1);
                txt_jiagelongmenxi.Text = Convert.ToString(jiagelongmenxi);
            }
        }
        /// <summary>
        /// 加工中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiagezhongxin_Click(object sender, EventArgs e)
        {
            txt_jiagezhongxin.Text = "";
            txt_jiagezhongxin1.Text = "";
            txt_jiagezhongxin2.Text = "";
            if(com_caizhizhongxin.Text.Trim() != "" && txt_zhongliangzhongxin1.Text.Trim() != "" && txt_zhongliangzhongxin2.Text.Trim() != "")
            {
                double caizhi = Convert.ToDouble(com_caizhizhongxin.Text.Trim());
                double zhongliang1 = Convert.ToDouble(txt_zhongliangzhongxin1.Text.Trim());
                double zhongliang2 = Convert.ToDouble(txt_zhongliangzhongxin2.Text.Trim());
                jiagejiagongzhongxin1 = (Math.Pow(zhongliang2, 0.28) + 0.3) * 15;
                txt_jiagezhongxin1.Text = Convert.ToString(jiagejiagongzhongxin1);

                jiagejiagongzhongxin2 = zhongliang1 * 0.22;
                txt_jiagezhongxin2.Text = Convert.ToString(jiagejiagongzhongxin2);

                jiagejiagongzhongxin = Math.Round((jiagejiagongzhongxin1 + jiagejiagongzhongxin2) * caizhi, 1);
                txt_jiagezhongxin.Text = Convert.ToString(jiagejiagongzhongxin);
            }
        }

        /// <summary>
        /// 焊接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiagehanjie_Click(object sender, EventArgs e)
        {
            txt_jiagehanjie.Text = "";
            if(txt_jianshuhanjie.Text.Trim() != "" && txt_zhonglianghanjie.Text.Trim() != "")
            {
                double jianshu = Convert.ToDouble(txt_jianshuhanjie.Text.Trim());
                double zhongliang1 = Convert.ToDouble(txt_zhonglianghanjie.Text.Trim());
                jiagehanjie = Math.Round((zhongliang1 * 0.3 + (jianshu - 1) * 4), 1);
                txt_jiagehanjie.Text = Convert.ToString(jiagehanjie);
            }
        }
        /// <summary>
        /// 数车价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiageshuche_Click(object sender, EventArgs e)
        {
            txt_zhongliangshuche.Text = "";
            txt_mianjishuche.Text = "";
            txt_tijishuche.Text = "";
            txt_tijiquchushuche.Text = "";
            txt_jiagedangweishuche.Text = "";
            txt_jiagechexueshuche.Text = "";
            txt_jiageshuche.Text = "";
            if(txt_zhijing1.Text.Trim() != "" && txt_gao1.Text.Trim() != "" && com_caizhishuche.Text.Trim() != "" && txt_dangwei1.Text.Trim() != "" && com_jingdushuche.Text.Trim() != "" && txt_qiexueshuche.Text.Trim() != "" && txt_zhongliangtuzhishuche.Text.Trim() != "")
            {
                double zhijing = Convert.ToDouble(txt_zhijing1.Text.Trim());
                double gao = Convert.ToDouble(txt_gao1.Text.Trim());
                double caizhi = Convert.ToDouble(com_caizhishuche.Text.Trim());
                double dangwei = Convert.ToDouble(txt_dangwei1.Text.Trim());
                double jingdu = Convert.ToDouble(com_jingdushuche.Text.Trim());
                double qiexuetiji = Convert.ToDouble(txt_qiexueshuche.Text.Trim());
                double tuzhizhongliang = Convert.ToDouble(txt_zhongliangtuzhishuche.Text.Trim());

                txt_zhongliangshuche.Text = Convert.ToString((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900);
                txt_mianjishuche.Text = Convert.ToString((3.14 * zhijing * zhijing / 2 + 3.14 * zhijing * gao) / 100);
                txt_tijishuche.Text = Convert.ToString(zhijing / 2 * zhijing / 2 * gao * 3.14);
                txt_tijiquchushuche.Text = Convert.ToString((((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900) - tuzhizhongliang) / ((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900) * (zhijing / 2 * zhijing / 2 * gao * 3.14));

                txt_jiagedangweishuche.Text = Convert.ToString(0.8 * dangwei);
                txt_jiagezhongliangshuche.Text = Convert.ToString(0.3 * ((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900));
                if(zhijing < 16)
                {
                    txt_jiagechexueshuche.Text = Convert.ToString((Convert.ToDouble(txt_tijiquchushuche.Text.Trim()) / qiexuetiji) / 60 * 10 * caizhi * jingdu + 2);
                }
                else
                {
                    txt_jiagechexueshuche.Text = Convert.ToString((Convert.ToDouble(txt_tijiquchushuche.Text.Trim()) / qiexuetiji) / 60 * 10 * caizhi * jingdu);
                }
                jiageshuche = Math.Round(Convert.ToDouble(txt_jiagedangweishuche.Text.Trim()) + Convert.ToDouble(txt_jiagezhongliangshuche.Text.Trim()) + Convert.ToDouble(txt_jiagechexueshuche.Text.Trim()), 1);
                txt_jiageshuche.Text = Convert.ToString(jiageshuche);
            }
        }

        /// <summary>
        /// 普车价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_jiagepuche_Click(object sender, EventArgs e)
        {
            txt_zhongliangpuche.Text = "";
            txt_mianjipuche.Text = "";
            txt_tijipuche.Text = "";
            txt_tijiquchupuche.Text = "";
            txt_jiagedangweipuche.Text = "";
            txt_jiagezhongliangpuche.Text = "";
            txt_jiagechexuepuche.Text = "";
            if(txt_zhijing2.Text.Trim() != "" && txt_gao2.Text.Trim() != "" && com_caizhipuche.Text.Trim() != "" && txt_dangwei2.Text.Trim() != "" && com_jingdupuche.Text.Trim() != "" && txt_qiexuepuche.Text.Trim() != "" && txt_tuzhizhongliangpuche.Text.Trim() != "")
            {
                double zhijing = Convert.ToDouble(txt_zhijing2.Text.Trim());
                double gao = Convert.ToDouble(txt_gao2.Text.Trim());
                double caizhi = Convert.ToDouble(com_caizhipuche.Text.Trim());
                double dangwei = Convert.ToDouble(txt_dangwei2.Text.Trim());
                double jingdu = Convert.ToDouble(com_jingdupuche.Text.Trim());
                double qiexuetiji = Convert.ToDouble(txt_qiexuepuche.Text.Trim());
                double tuzhizhongliang = Convert.ToDouble(txt_tuzhizhongliangpuche.Text.Trim());

                txt_zhongliangpuche.Text = Convert.ToString((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900);
                txt_mianjipuche.Text = Convert.ToString((3.14 * zhijing * zhijing / 2 + 3.14 * zhijing * gao) / 100);
                txt_tijipuche.Text = Convert.ToString(zhijing / 2 * zhijing / 2 * gao * 3.14);
                txt_tijiquchupuche.Text = Convert.ToString((((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900) - tuzhizhongliang) / ((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900) * (zhijing / 2 * zhijing / 2 * gao * 3.14));

                txt_jiagedangweipuche.Text = Convert.ToString(1.5 * dangwei);
                txt_jiagezhongliangpuche.Text = Convert.ToString(0.3 * ((3.14 * zhijing * zhijing * gao / 4 / 1000000000) * 7900));
                if(zhijing < 16)
                {
                    txt_jiagechexuepuche.Text= Convert.ToString((Convert.ToDouble(txt_tijiquchupuche.Text.Trim()) / qiexuetiji) / 60 * 10 * caizhi * jingdu + 2);
                }
                else
                {
                    txt_jiagechexuepuche.Text = Convert.ToString((Convert.ToDouble(txt_tijiquchupuche.Text.Trim()) / qiexuetiji) / 60 * 10 * caizhi * jingdu);
                }

                jiagepuche = Math.Round(Convert.ToDouble(txt_jiagedangweipuche.Text.Trim()) + Convert.ToDouble(txt_jiagezhongliangpuche.Text.Trim()) + Convert.ToDouble(txt_jiagechexuepuche.Text.Trim()), 1);
                txt_jiagepuche.Text = Convert.ToString(jiagepuche);
            }
        }
    }
}