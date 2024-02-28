using Astrow.Shared.DTO;
using Astrow_Domain.Models;
using Astrow_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Astrow.Server.Controllers
{
    public class TeacherController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

    }
}
