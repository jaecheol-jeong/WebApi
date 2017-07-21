using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApi.Core;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SearchController : Controller
    {

        [HttpGet]
        public IActionResult GetAuthList(string searchName)
        {
            var reqData = new {
                query = new {
                    match = new {
                        auth = searchName
                    }
                }
            };

            var res = ESApiCall.Call<ESResResponse>("/_search", "POST", reqData);
            return Json(res);
        }

        [HttpGet]
        public IActionResult GetDomain(string searchName)
        {
            var reqData = new {
                query = new {
                    match = new {
                        domain = searchName
                    }
                }
            };

            var res = ESApiCall.Call<ESResResponse>("/_search", "POST", reqData);
            return Json(res);
        }

        [HttpGet]
        public IActionResult GetLog(string searchName = "local")
        {
            var reqData = new {
                query = new {
                    match = new {
                        _type = searchName
                    }
                }
            };

            var res = ESApiCall.Call<ESResResponse>("/weblog/_search", "POST", reqData);
            return Json(res);
        }

        [HttpGet]
        public IActionResult Error()
        {
            throw new Exception("error throw");
            return null;
        }

    }
}