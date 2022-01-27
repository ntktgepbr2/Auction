using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet()]
        public IActionResult Get()
        {
        //    IEnumerable enumka = new int{1,23,42,3,1,42,1};
        //    IQueryable;
        //    IList;
        //    IReadOnlyCollection;
        //    ICollection<int>;
        //        Array
        //var enumeratior = enumka.GetEnumerator();
            return Ok(new {name = "Daniel"});
        }
    }
}
