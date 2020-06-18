using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_12
{
    public partial class Index : System.Web.UI.Page
    {
        public string SelectStr { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Asp.net 窗体控件
            //内网系统（OA），使用服务端控件比较好; 可以提高开发效率

            //01_ClientID\Visible\CssClass\Attributes（属性）
            /*
             ClientID,控件在客户端的Id，控件在服务端的Id不一定等于客户端HTML中的id，
             比如说在ListView等控件的模板中。因此如果要在客户端通过JavaScript Dom、
             JQuery的getElementById、$('#id')来操作控件的话，最好不要直接写服务端Id，
             而是$('#<% = txt1.ClientID %')。
             用JQurey事件设置鼠标移到控件上和从控件移开的不同样式。在用户控件中就可以看到ClientID和id的不同。
             UserControl、母版、ListView推荐使用ClientID.
             */
            Button1.Attributes.Add("onclick", "alert('按钮添加了额外的点击事件！！！')"); //Attributes获取控件额外的属性


            UserInfoService userInfoService=new UserInfoService();
            List<UserInfoEntity> userInfoList = userInfoService.GetUserInfoList();
            this.DropDownList1.DataSource = userInfoList;
            this.DropDownList1.DataTextField = "UserName";
            this.DropDownList1.DataValueField = "UserId";
            this.DropDownList1.DataBind();//数据绑定，不要忘记！！！

            StringBuilder stringBuilder=new StringBuilder();
            foreach (UserInfoEntity userInfo in userInfoList)
            {
                stringBuilder.AppendFormat("<option value={0}>{1}</option>",userInfo.UserId,userInfo.UserName);
            }
            SelectStr = stringBuilder.ToString();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Response.Write("text提交了！！");
        }
    }
}