using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp
{
    //Global：文件名称不能改，并且要放在网站的根目录下。
    //全局文件是对Web应用生命周期的一个事件响应的地方
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Web应用程序第一次启动时调用该方法，并且该方法只被调用一次。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        { 
            //类似于Main()方法，Web应用程序的入口
            //一般是完成Web应用程序的初始化配置
            //定时任务框架
        }
        /// <summary>
        /// 开始会话（用户通过浏览器第一次访问我们网站中的页面，这时建立会话，
        /// 但是当该用户通过浏览器再次访问其他页面时，该方法不会被执行。通过sessionId判断）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        { 
            //浏览器和服务器的会话
            //Application：服务端的状态保持机制！放在该对象中的数据是共享的！与Cache类似
            Application.Lock();  //加锁
            int count = Convert.ToInt32(Application["count"]);
            count++;
            Application["count"] = count;
            Application.UnLock();//解锁
        } 


        /// <summary>
        /// 请求管道中的第一个事件，处理的开始。当一个用户的请求来的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 验证请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 全局的异常处理点。（当应用出现异常时）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception error = HttpContext.Current.Server.GetLastError();
            //开源的日志记录组件 Log4Net 
        }
        /// <summary>
        /// 会话结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_End(object sender, EventArgs e)
        {

        }

         
        /// <summary>
        /// 应用关闭时调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}