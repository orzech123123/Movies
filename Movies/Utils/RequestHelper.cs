using System.IO;
using System.Net;
using System.Text;

namespace Movies.Utils
{
    public class RequestHelper
    {
        public static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}