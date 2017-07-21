using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class JobController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Echo(string msg)
        {
            return msg;
        }

        [HttpGet]
        public IActionResult Weather(string area = "Seoul,KR")
        {
            string apiUrl = 
                string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID=fb5764a177e028ca5677d8b3498cd8ba&units=metric", area);
            
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(apiUrl);
            req.ContentType = "application/json";
            req.Method = "GET";
            req.ContinueTimeout = 5000;

            var data = Task.Run( ()=> req.GetResponseAsync() );
            
            Task.WaitAny(data);

            String json = string.Empty;

            if(data.Result != null)
            {
                Stream stream = data.Result.GetResponseStream();
                StreamReader readStream = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
			    json = readStream.ReadToEnd();
            }
			
            return Json(json);
        } 
    }
}
