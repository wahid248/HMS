using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Wahid.HMS.Presentation.Admin.Controllers
{
    [Route("[controller]")]
    public class DashBoardController : Controller
    {
        [Route("[action]")]
        [HttpGet]
        public string Index()
        {
            return "this is a text";
        }
    }
}