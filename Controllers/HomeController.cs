using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorchMedia.Models;

namespace TorchMedia.Controllers
{
    public class HomeController : Controller
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

            var model = new HomeViewModel
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contactanos()
        {
 var model = new ContactanosViewModel();
    model.Disponibilidad = repo.ObtenerDisponibilidad(); // Asegúrate de que esta función devuelve una lista válida
    return View(model);
        }    
    }
}
