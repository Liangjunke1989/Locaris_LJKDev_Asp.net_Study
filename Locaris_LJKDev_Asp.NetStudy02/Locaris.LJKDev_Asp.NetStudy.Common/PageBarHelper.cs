using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locaris.LJKDev_Asp.NetStudy.Common
{
    public class PageBarHelper
    {
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount==1)
            {
                return string.Empty;
            }
            int start = pageIndex - 3;//计算起始位置，要求页面上显示6个数字页码

            if (start<1)
            {
                start = 1;
            }
            int end = start + 6;//计算终止位置

            if (end>pageCount)
            {
                end = pageCount;
                start = end - 6 < 1 ? 1 : end - 6;
            }
            StringBuilder stringBuilder=new StringBuilder();
            if (pageIndex>1)
            {
                stringBuilder.AppendFormat("<a href='NewList.aspx?pageIndex={0}'>上一页</a>",pageIndex-1);
            }
            for (int i = start; i <=end; i++)
            {
                if (i==pageIndex)
                {
                    stringBuilder.Append(i);
                }
                else
                {
                    stringBuilder.AppendFormat("<a href='NewList.aspx?pageIndex={0}'> {0} </a>  ", i);
                }
            }

            if (pageIndex<pageCount)
            {
                stringBuilder.AppendFormat("<a href='NewList.aspx?pageIndex={0}'>下一页</a>", pageIndex + 1);
            }
            return stringBuilder.ToString();
        }
    }
}
