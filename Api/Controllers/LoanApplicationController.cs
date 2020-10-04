using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class LoanApplicationController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult GetApplicationDecision()
        {
            return View();
        }

    }
}
