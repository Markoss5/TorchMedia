using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Torchmedia.Models;
using Microsoft.AspNetCore.Authorization;
using Dapper;
using TorchMedia.Models;
[Authorize]
public class AdminController : Controller
{
    private BD repo = new BD();

    public IActionResult Index()
    {
        var heroContent = repo.ObtenerHeroContent();
        var quienesSomosContent = repo.ObtenerQuienesSomosContent();
        var serviciosContent = repo.ObtenerServiciosContent();
        var proyectosContent = repo.ObtenerProyectosContent();
        var testimoniosContent = repo.ObtenerTestimoniosContent();
        var footerContent = repo.ObtenerFooterContent();

        var model = new AdminViewModel
        {
            HeroContent = heroContent,
            QuienesSomosContent = quienesSomosContent,
            ServiciosContent = serviciosContent,
            ProyectosContent = proyectosContent,
            TestimoniosContent = testimoniosContent,
            FooterContent = footerContent
        };

        return View(model);
    }

    [HttpPost]
public IActionResult ActualizarHeroContent(HeroContent content)
{
    // Verifica si el contenido llega con los valores correctos
    Console.WriteLine($"Titulo: {content.Titulo}, Descripcion: {content.Descripcion}, VideoUrl: {content.VideoUrl}");

    if (ModelState.IsValid)
    {
        repo.ActualizarHeroContent(content);
    }
    
    return RedirectToAction("Index");
}


[HttpPost]
public IActionResult ActualizarQuienesSomosContent(QuienesSomosContent content)
{
    // Verifica si el contenido llega con los valores correctos
    Console.WriteLine($"Titulo: {content.Titulo}, Descripcion: {content.Descripcion}, ImagenUrl: {content.ImagenUrl}");
    
    // Si el modelo es válido, actualiza la base de datos
    if (ModelState.IsValid)
    {
        repo.ActualizarQuienesSomosContent(content);
    }
    
    return RedirectToAction("Index");
}

    [HttpPost]
    public IActionResult ActualizarServiciosContent(ServiciosContent content)
    {
        repo.ActualizarServiciosContent(content);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ActualizarTestimoniosContent(TestimoniosContent content)
    {
        repo.ActualizarTestimoniosContent(content);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ActualizarFooterContent(FooterContent content)
    {
        repo.ActualizarFooterContent(content);
        return RedirectToAction("Index");
    }
}
