using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MannariEnterprises.Models;
using Microsoft.AspNetCore.Authorization;

public class ProductController: Controller{
    private readonly IProductRepository _productRepo;

    public ProductController(IProductRepository productRepo){
        _productRepo= productRepo;
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id){
        var product= _productRepo.GetById(id);
        if (product==null){
            return NotFound();
        }

        return View(product);
    }

    [HttpGet]
    public IActionResult Create(){
        return View();
    }

    [HttpGet]

    public IActionResult Delete(){
        return View();
    }  

    [HttpGet]
    public IActionResult Edit(){
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
        _productRepo.Add(product);
        return RedirectToAction("Index");
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id)
    {
        var product = _productRepo.GetById(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost("Edit/{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        var existingProduct = _productRepo.GetById(id);
        if (existingProduct == null)
            return NotFound();

        existingProduct.ProductName = product.ProductName;
        existingProduct.Price = product.Price;
        existingProduct.CategoryId = product.CategoryId; // If you want to update the category

        _productRepo.Update(existingProduct);
        return RedirectToAction("Index");
    }
    public IActionResult Index(){
        List<Product> products = _productRepo.GetAll().ToList();
        return View(products);
    }

    [HttpPost("Delete/{id}")]
    public IActionResult DeleteConfirmed(int id)
    {
        _productRepo.Delete(id);
        return RedirectToAction("Index"); // Redirect to the products listing page after successful deletion
    }
}
