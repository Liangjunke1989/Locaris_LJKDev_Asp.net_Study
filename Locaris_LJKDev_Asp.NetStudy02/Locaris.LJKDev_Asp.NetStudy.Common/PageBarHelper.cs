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
            //00_如果数据页数只有一页的情况下，不需要使用PageBar
            if (pageCount == 1)
            {
                return string.Empty;
            }
            //01_计算起始位置,pageIndex在中间，作为中位数，往前数两个，作为显示的起始数字
            int start = pageIndex - 2;
            if (start < 1)
            {
                start = 1;
            }

            //02_计算出当前显示的末尾页面，当前显示的终止页面
            int end = start + 5;
            if (end > pageCount)
            {
                //end的最大值不超过pageCount
                end = pageCount;
                start = end - 5 < 1 ? 1 : end - 5;
            }

            //03_为页面添加超链接
            StringBuilder stringBuilder = new StringBuilder();
            //03_01为页面添加"上一页"超链接
            if (pageIndex > 1)
            {
                stringBuilder.AppendFormat("<a href='NewList.aspx?pageIndex={0}'>上一页</a>", pageIndex - 1);
            }
            //03_02为页面添加<a></a>超链接
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    //03_02_01如果是当前页，当前页不用添加超链接
                    stringBuilder.Append(" " + i + " ");
                }
                else
                {
                    //03_02_02把其他页都添加上超链接<a></a>标签
                    stringBuilder.AppendFormat("<a href='NewList.aspx?pageIndex={0}'> {0} </a>  ", i);
                }
            }
            //03_03为页面添加"下一页"超链接
            if (pageIndex < pageCount)
            {
                stringBuilder.AppendFormat("<a href='NewList.aspx?pageIndex={0}'>下一页</a>", pageIndex + 1);
            }

            //04_返回字符串
            return stringBuilder.ToString();
        }
    }
}

