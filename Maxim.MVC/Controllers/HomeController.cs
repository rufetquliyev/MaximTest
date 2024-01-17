using Maxim.Business.Services.Interfaces;
using Maxim.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maxim.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeatureService _featureService;

        public HomeController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Feature> features = await _featureService.GetAllAsync();
            return View(features);
        }
    }
}