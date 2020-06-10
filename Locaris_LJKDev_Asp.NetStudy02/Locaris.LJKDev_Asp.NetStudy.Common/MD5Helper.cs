using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Locaris.LJKDev_Asp.NetStudy.Common
{
    public class MD5Helper
    {
        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMd5String(string str)
        {
            MD5 md5=MD5.Create();
            byte[] bufferBytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Bytes = md5.ComputeHash(bufferBytes);
            StringBuilder stringBuilder=new StringBuilder();
            foreach (byte b in md5Bytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
