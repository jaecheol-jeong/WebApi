using System;

namespace WebApi.Core
{
    public class EsLogResponse
    {        
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set;}
        public int _version { get; set; }
        public string result { get; set; }
        public Shards _shards { get; set; }
        public bool created { get; set; }       
    }

    public class Shards
    {
        public int Total { get; set; }
        public int Successful { get; set; }
        public int Failed { get; set; }
    }

    public class EsWebLog
    {
        public string logDate { get; set; }
        public string insDate { get; set; }
        public string auth { get; set; }
        public int code { get; set; }
        public string log_level { get; set; }
        public string domain { get; set; }
        public ErrLog errLog { get; set; }
    }
}