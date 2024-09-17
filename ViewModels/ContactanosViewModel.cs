namespace TorchMedia.Models
{
    public class ContactanosViewModel
    {
        // Lista que almacenará las disponibilidades que se muestran en el formulario
        public List<Disponibilidad> Disponibilidad { get; set; }

        // Puedes agregar más propiedades si lo necesitas
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Mensaje { get; set; }

        // Constructor para inicializar la lista de disponibilidad
        public ContactanosViewModel()
        {
            Disponibilidad = new List<Disponibilidad>();
        }
    }
}
