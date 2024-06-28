using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InkHouse.Models;
using InkHouse.Services.Base;

namespace InkHouse.Controllers;

public class HomeController : Controller
{
    private readonly IPaintingService paintingService;

    public HomeController(IPaintingService paintingService)
    {
        this.paintingService = paintingService;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var paintings = await paintingService.GetAllPaintingsAsync();
        return View(paintings);
    }

    [HttpGet("[controller]/[action]/{id}")]
    public async Task<IActionResult> Image(Guid id)
    {
        var painting = await paintingService.GetPaintingByIdAsync(id);
        if (painting == null || string.IsNullOrEmpty(painting.Image))
        {
            return NotFound("Painting or image not found.");
        }
        var fileStream = System.IO.File.Open(painting.Image!, FileMode.Open);
        return File(fileStream, "image/jpeg");
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
