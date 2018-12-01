using DevExpress.DXCore.Controls.LookAndFeel;
using NetWork.util;
using NetWorkLib.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ztznpms.UI.二维码;

namespace ztznpms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            getData getData = new getData();
            getData.getiprouter();
           
               
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Formgongshi());
            UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            Application.Run(new newFormMain());
           
           

        }
    }
}
