using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi.Core
{
    public class ESResResponse
    {
        public int Took {get; set; }
        public bool Timed_out { get; set; }

        public Shards _Shards { get; set; }

        public ESHits Hits { get; set; }
    }

    public class ESHits
    {
        public int Total { get; set; }
        public long Max_score { get; set; }
        public List<ESHit> Hits { get; set; }
    }

    public class ESHit
    {
        public string _Index { get; set; }
        public string _Type { get; set; }
        public string _id { get; set; }
        public long _Score { get; set; }
        public Source _Source { get; set; }
    }

    public class Source
    {
        public string Domain { get; set; }
        public string LogTime { get; set; }
        public string Auth { get; set; }
        public ErrLog Log { get; set; }
        public string Log_Level { get; set; }
    }

    public class ErrLog
    {
        public string Error_Code { get; set; }
        public string Trace { get; set; }
        public string Source { get; set; }
    }
}