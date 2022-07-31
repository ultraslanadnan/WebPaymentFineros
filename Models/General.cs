using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Configuration;
namespace WebPaymentFineros.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class General
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        public static string SendJSonData(string strURL, string strData)
        {
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.Accept = "application/json";
            byte[] byteArray = Encoding.UTF8.GetBytes(strData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer.ToString();
        }
        public static string GetJSonData(string strURL)
        {
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json";

            Stream dataStream = request.GetRequestStream();

            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer.ToString();
        }
        public static bool NotGreatherThan(double val1,double val2)
        {
            if (val1 > val2) { return true; }
            return false;
        }
        public static bool getBoolFromInt(int i)
        {
            if (i == 0) { return false; }
            return true;
        }
        public static string GetDomain()
        {
         return   ConfigurationManager.AppSettings["AppDomain"].ToString();
        }
    }
}