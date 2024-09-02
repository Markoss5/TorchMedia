using TorchMedia.Models;

namespace TorchMedia.Models
{
public class AdminViewModel
{
    public HeroContent HeroContent { get; set; }
    public QuienesSomosContent QuienesSomosContent { get; set; }
    public IEnumerable<ServiciosContent> ServiciosContent { get; set; }
    public IEnumerable<ProyectosContent> ProyectosContent { get; set; }
    public TestimoniosContent TestimoniosContent { get; set; }
    public FooterContent FooterContent { get; set; }
}
}