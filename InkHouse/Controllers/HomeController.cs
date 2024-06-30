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
        ViewBag.Countries = await paintingService.GetAllCountriesAsync();
        ViewBag.Paintings = await paintingService.GetAllPaintingsAsync();
        ViewBag.Painters = await paintingService.GetAllPaintersAsync();
        return View();
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

    [HttpPost]
    [Route("[controller]/edit")]
    public async Task<IActionResult> ChangePrice(Guid id, [FromForm] string newPrice)
    {
        var painting = await paintingService.GetPaintingByIdAsync(id);
        if (painting == null)
        {
            return NotFound();
        }

        var priceString = newPrice.Replace(" руб", "").Trim();
        if (double.TryParse(priceString, out var num))
        {
            painting.Price = num;
            await paintingService.UpdatePaintingAsync(painting);
        }
        else
        {
            
            ModelState.AddModelError("", "Invalid price format");
        }

        return RedirectToAction("Index");
    }



    [HttpPost]
    [Route("[controller]/remove", Name = "DeletePainting")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await paintingService.DeletePaintingById(id);
        return RedirectToAction(controllerName: "Home", actionName: "Index");
    }


    [HttpPost]
    [Route("[controller]/add", Name = "AddPainting")]
    public async Task<IActionResult> AddNewPainting([FromForm] Painting newPainting, IFormFile image)
    {

        await paintingService.CreateNewPaintingAsync(newPainting, image);
        return RedirectToAction(controllerName: "Home", actionName: "Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
