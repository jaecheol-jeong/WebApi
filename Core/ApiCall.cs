using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;

namespace WebApi.Core
{
    public static class ESApiCall
    {
        private static string _elasticsearchUrl = "http://localhost:9200";

        public static T Call<T>(string url, string method, object param) where T : new()
        {
            try{
                var taskResult = CallApi(url, method, param);
                
                return JsonConvert.DeserializeObject<T>(taskResult.Result);
            }catch(Exception ex){
                var log = new EsWebLog(){
                    domain = "local",
                    logDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    auth = Environment.MachineName,
                    log_level = "error"
                };
                log.errLog = new ErrLog {
                    Error_Code = "500",
                    Trace = ex.StackTrace,
                    Source = ex.Source
                };

                var _ = CallApi("/weblog/local", "POST", log);

                return new T();
            }
        }

        private async static Task<string> CallApi( string funcName, string method, object param)
        {
            string url = _elasticsearchUrl + funcName;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = method;
            request.ContinueTimeout = 5000;
            request.ContentType = "application/json";
            
            string json = JsonConvert.SerializeObject(param);
            json = json.ToLower();
            byte[] postBytes = Encoding.UTF8.GetBytes(json);

            var requestTask = Task.Run(() => request.GetRequestStreamAsync());
            
            await Task.WhenAny(requestTask);
            requestTask.Result.Write(postBytes, 0, postBytes.Length);
            
            var data = Task.Run( () => request.GetResponseAsync());
            await Task.WhenAny(data);

            string szResult = string.Empty;
            if(data != null)
            {
                Stream responseStream = data.Result.GetResponseStream();
                if(responseStream.CanRead)
                {
                    StreamReader readStream = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
			        szResult = readStream.ReadToEnd();
                }
            }

            return szResult;
        }

    }
}