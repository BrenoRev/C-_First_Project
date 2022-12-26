using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project_First.Models;
using Project_First.Service;

namespace Project_First.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HomeHelper _homeHelper;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _homeHelper = new HomeHelper();
        _logger = logger;
    }

    public IActionResult Index()
    {
        UserModel userModel = new UserModel();
        
        userModel.Name = "Breno";
        userModel.Email = "silvabreno462@gmail.com";
        const string PASSWORD = "breno@123";
        
        _logger.Log(LogLevel.Debug, "Password before encrypt: ${PASSWORD}");
        userModel.Password = _homeHelper.hashPassword(PASSWORD);
        _logger.Log(LogLevel.Debug, "Password after encrypt: ${userModel.Password}");
        
        return View(userModel);
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