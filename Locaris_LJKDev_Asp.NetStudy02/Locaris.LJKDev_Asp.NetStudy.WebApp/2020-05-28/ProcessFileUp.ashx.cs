using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.IO;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_05_28
{
    /// <summary>
    /// ProcessFileUp 的摘要说明
    /// </summary>
    public class ProcessFileUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html ";
            //接收用requeset, 此时为非单纯的form表单数据
            HttpPostedFile file = context.Request.Files[0];//获取上传的文件
            if (file.ContentLength > 0)
            {
                //对上传的文件类型进行校验（病毒文件容易找到漏洞）
                string fileName = Path.GetFileName(file.FileName);//获取上传文件的名称，包含扩展名
                // string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);//获取上传文件的名称
                string fileExtension = Path.GetExtension(file.FileName);//获取上传文件的扩展名
                if (fileExtension.Equals(".jpg"))
                {
                    //AAA.模拟图片上传，保存到“服务器”中
                    //file.SaveAs(context.Request.MapPath("/ImageUpload/" + fileName));//完成文件的保存

                    //01.对上传文件重命名？（文件的重名问题，会覆盖掉的问题）“GUID”的值作为上传文件的名称；文件流的MD5值作为新文件的名称
                    string newFileName = Guid.NewGuid().ToString();

                    //02.同一文件夹下的文件过多，不好管理？ 根据日期创建文件夹，每天更新一个文件夹
                    string dir = "/ImageUpload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" +
                                  DateTime.Now.Day + "/";

                    //02.01创建文件夹--------文件流操作知识加强理解
                    if (!Directory.Exists(context.Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(context.Request.MapPath(dir));      //"Directory"目录//"context.Request.MapPath(dir)"获取物理路径
                    }
                    string fullDir = dir + newFileName + fileExtension;   // 文件的完整路径
                    file.SaveAs(context.Request.MapPath(fullDir));//将原始图片备份，将用户上传的图片先保存一下

                    //创建图片的水印
                    //Image.FromFile(context.Request.MapPath(fullDir)
                    //Image image = Image.FromStream(file.InputStream)
                    //根据上传成功的图片创建一个Image实例
                    using (Image image=Image.FromStream(file.InputStream))
                    {
                        //根据画布的高度与宽度创建画布
                        using (Bitmap bitmap=new Bitmap(image.Width,image.Height))
                        {
                            //为画布创建画笔(graphics图形)
                            using (Graphics graphics=Graphics.FromImage(bitmap))
                            {
                                //从画布的左上角开始画，高度宽度为上传的image图片，布满画布  
                                graphics.DrawImage(image,0,0,image.Width,image.Height);
                                //在画布上书写水印
                                graphics.DrawString("LJK",new Font("微软雅黑",48.0f,FontStyle.Bold), Brushes.Bisque,new PointF(bitmap.Width-240,bitmap.Height-150));
                                //保存修改后的图片
                                string waterFileName = "water"+Guid.NewGuid().ToString();
                                string waterDir = "/ImageUpload/" + waterFileName + ".jpg";
                                bitmap.Save(context.Request.MapPath(waterDir),System.Drawing.Imaging.ImageFormat.Jpeg);

                                //03.显示出来进行校验一下，看看结果
                                string fileDisplayByHtml = "<html><body><img src= '" + waterDir + "'/></body></html>";
                                context.Response.Write(fileDisplayByHtml);
                            }
                            
                        }
                    }


                   
                }
                else
                {
                    context.Response.Write("只能上传图片文件！！！");
                }
            }
            else
            {
                context.Response.Write("请选择要上传的文件，不能为空！！！");
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