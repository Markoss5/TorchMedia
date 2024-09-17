using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorchMedia.Models; // Asegúrate de que esto esté aquí


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
        model.Disponibilidad = repo.ObtenerDisponibilidad().ToList();
        return View(model);
    }
   
        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
