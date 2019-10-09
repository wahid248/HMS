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
        private readonly IUnitOfWork _unitOfWork;
        public DefaultController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [Route("insert")]
        public IActionResult Test()
        {
            _unitOfWork.PatientRepository.Add(new Core.Entities.Patient
            {
                Serial = "serial",
                Name = "name",
                Sex = Core.Enums.Sex.Male
            });
            _unitOfWork.SaveChanges();
            return Content("sucess");
        }
    }
}