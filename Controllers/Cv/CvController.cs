using CvManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CvManager.Controllers.Cv
{
    public class CvController : Controller
    {
        private readonly ICvService _cvService;

        public CvController(ICvService cvService)
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