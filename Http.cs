namespace WinFormsApp1
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    internal class Http
    {
        public static string GetResponse(string url, string json)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            HttpWebRequest request1 = (HttpWebRequest) WebRequest.Create(new Uri(url));
            request1.ContentType = "application/json";
            request1.Accept = "application/json";
            request1.Method = "POST";
            Stream requestStream = request1.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse) request1.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            char[] buffer = new char[0x100];
            int length = reader.Read(buffer, 0, 0x100);
            string str = "";
            while (length > 0)
            {
                string str2 = new string(buffer, 0, length);
                str = str + str2;
                length = reader.Read(buffer, 0, 0x100);
            }
            response.Close();
            return str;
        }
    }
}

