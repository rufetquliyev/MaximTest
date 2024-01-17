using AutoMapper;
using Maxim.Business.Services.Interfaces;
using Maxim.Business.ViewModels.Feature;
using Maxim.Business.ViewModels.User;
using Maxim.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Maxim.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Feature> features = await _featureService.GetAllAsync();
            return View(features);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureVm vm)
        {
            CreateFeatureValidator validationRes = new CreateFeatureValidator();
            var result = validationRes.Validate(vm);
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _featureService.CreateAsync(vm);
            return RedirectToAction("Index");
        } 
        public async Task<IActionResult> Update(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            UpdateFeatureVm vm = _mapper.Map<UpdateFeatureVm>(feature);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureVm vm)
        {
            UpdateFeatureValidator validationRes = new UpdateFeatureValidator();
            var result = validationRes.Validate(vm);
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _featureService.UpdateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _featureService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
