using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_28
{
    /// <summary>
    /// MakeImage 的摘要说明
    /// </summary>
    public class MakeImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //给用户创建一张图片，并且把这张图片保存的案例。
            //01_创建一张画布
            using (Bitmap bitmap=new Bitmap(500,800))
            {
                //02_给画布创建一个画笔
                using (Graphics graphics=Graphics.FromImage(bitmap))
                {
                    //03_为画布填充一个背景色
                    graphics.Clear(Color.AntiqueWhite);
                    //04_在画布上写字(指定字体样式，字体大小等)
                    graphics.DrawString("LJK",new Font("黑体", 14.0f,FontStyle.Bold),
                        Brushes.Aqua,new PointF(200,500));
                    //05_将画布以GUID的规则重命名
                    string fileName = Guid.NewGuid().ToString();
                    //06_将画布保存成一张jpg的图片
                    string fileDir = "/ImageUpload/" + fileName + ".jpg";
                    bitmap.Save(context.Request.MapPath(fileDir),System.Drawing.Imaging.ImageFormat.Jpeg);
                    //07_将最终结果呈现到html中
                    string bitmapDisplayWithHtml = "<html><body><img src='"+ fileDir + "'/></body></html>";
                    context.Response.Write(bitmapDisplayWithHtml);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}