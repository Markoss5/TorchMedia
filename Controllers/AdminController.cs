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
        repo.ActualizarHeroContent(content);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ActualizarQuienesSomosContent(QuienesSomosContent content)
    {
        repo.ActualizarQuienesSomosContent(content);
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
