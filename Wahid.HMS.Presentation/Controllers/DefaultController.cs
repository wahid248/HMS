using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wahid.HMS.Core.Abstract;

namespace Wahid.HMS.Presentation.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public DefaultController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Route("test")]
        public string Index()
        {
            return unitOfWork.ReturnString("ttt");
        }

        [Route("test2")]
        public string Index2()
        {
            return unitOfWork.ReturnString("yyy");
        }
    }
}