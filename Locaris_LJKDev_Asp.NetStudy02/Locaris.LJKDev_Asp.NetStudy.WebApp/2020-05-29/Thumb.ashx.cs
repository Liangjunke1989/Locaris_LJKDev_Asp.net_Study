using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Locaris.LJKDev_Asp.NetStudy.Common;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_29
{
    /// <summary>
    /// Thumb 的摘要说明
    /// </summary>
    public class Thumb : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //创建缩略图，定义一个小的画布，将图片画到画布上，最后保存。 案例二

            //拿到文件的物理路径
            string filePath = context.Request.MapPath("/ImageUpload/" + "001.jpg");
            //固定尺寸的缩略图
            //using (Bitmap bitmap=new Bitmap(50,50))
            //{
            //    using (Image image=Image.FromFile(filePath))
            //    {
            //        using (Graphics graphics=Graphics.FromImage(bitmap))
            //        {
            //            graphics.DrawImage(bitmap,0,0,bitmap.Width, bitmap.Height);
            //            string fileName = Guid.NewGuid().ToString();
            //            bitmap.Save(context.Request.MapPath("/ImageUpload/" + fileName + ".jpg"),
            //                System.Drawing.Imaging.ImageFormat.Jpeg);
            //        }
            //    }
            //}

            //等比的缩略图
            string thumb = "/ImageUpload/"+Guid.NewGuid().ToString()+".jpg";
            string thumbPath = context.Request.MapPath(thumb);
            ImageClass.MakeThumbnail(filePath, thumbPath,50,50,"W");
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