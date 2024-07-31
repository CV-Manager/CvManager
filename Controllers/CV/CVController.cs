using CvManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CvManager.Controllers.CV
{
    public class CVController : Controller
    {
        private readonly ICVService _cvService;

        public CVController(ICVService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
    }
}