﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MannariEnterprises.Models;

namespace MannariEnterprises.Controllers;

[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext=dbContext;
    }

    public IActionResult Index()
    {
        ViewData["IsLoginPage"] = false;
        var products= _dbContext.Products.ToList();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
