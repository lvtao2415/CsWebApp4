﻿using CsWebApp4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace CsWebApp4.Global
{
    public class Helper
    {
        /// <summary> 
        /// 获取链接返回数据 
        /// </summary> 
        /// <param name="Url">链接</param> 
        /// <param name="type">请求类型</param> 
        /// <returns></returns> 
        public string GetUrltoHtml(string Url, string type)
        {
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                // Get the response instance. 
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream) 
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.GetEncoding(type)))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
        #region 微信小程序用户数据解密 

        public static string AesKey;
        public static string AesIV;

        /// <summary> 
        /// AES解密 
        /// </summary> 
        /// <param name="inputdata">输入的数据encryptedData</param> 
        /// <param name="AesKey">key</param> 
        /// <param name="AesIV">向量128</param> 
        /// <returns name="result">解密后的字符串</returns> 
        public string AESDecrypt(string inputdata)
        {
            try
            {
                AesIV = AesIV.Replace(" ", "+");
                AesKey = AesKey.Replace(" ", "+");
                inputdata = inputdata.Replace(" ", "+");
                byte[] encryptedData = Convert.FromBase64String(inputdata);

                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.Key = Convert.FromBase64String(AesKey); // Encoding.UTF8.GetBytes(AesKey); 
                rijndaelCipher.IV = Convert.FromBase64String(AesIV);// Encoding.UTF8.GetBytes(AesIV); 
                rijndaelCipher.Mode = CipherMode.CBC;
                rijndaelCipher.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = rijndaelCipher.CreateDecryptor();
                byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                string result = Encoding.UTF8.GetString(plainText);

                return result;
            }
            catch (Exception)
            {
                return null;

            }
        }
        #endregion

        #region
        private static string wxAppid = ConfigurationManager.AppSettings.Get("wxAppid");
        private static string wxSecret = ConfigurationManager.AppSettings.Get("wxSecret");
        public static WeChatInfo GetOpenId(string code)
        {
            //接口地址
            string url = "https://api.weixin.qq.com/sns/jscode2session?appid="+ wxAppid + "&secret="+ wxSecret + "&js_code="+ code + "&grant_type=authorization_code";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string respHtml = sr.ReadToEnd();
            //反序列化
            WeChatInfo wechatInfo = new JavaScriptSerializer().Deserialize<WeChatInfo>(respHtml);

            return wechatInfo;

        }

        #endregion
         

    }
}