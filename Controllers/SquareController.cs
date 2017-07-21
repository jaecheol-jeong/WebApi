using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Square;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SquareController : Controller
    {
        // GET api/square
        [HttpGet]
        public List<int> Init()
        {
            Points points = Points.Instance();
            var val = points.Init(3);

            return val;
        }

        [HttpGet]
        public List<int> GetVals()
        {
            Points points = Points.Instance();
            return points.GetValues();
        }

        [HttpGet]
        public IActionResult MoveTo(int x1, int y1, int x2, int y2)
        {
            Points points = Points.Instance();
            points.Swap(x1, y1, x2, y2);

            var result = new { IsMatch = points.IsMatch() };
            Console.WriteLine(result);
            
            return Json(result);
        }

        [HttpGet]
        public IActionResult Echo(string message)
        {
            return Json(new { result = message });
        }
    }
}
