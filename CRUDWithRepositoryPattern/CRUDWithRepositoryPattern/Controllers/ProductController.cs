using Microsoft.AspNetCore.Mvc;
using CRUDWithRepository.Infrastructure.Interfaces;
using CRUDWithRepository.Core;

namespace CRUDWithRepositoryPatternUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;   
        }
        public async Task<IActionResult> Index()
        {
            var products = await _repository.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        { 
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.Add(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Invalid Product.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = $"Invalid Product. Exception = {ex}";
                throw;
            }
        }
    }
}
