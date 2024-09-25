namespace TorchMedia.Models
{
    public class ContactanosViewModel
    {
        public List<Disponibilidad> Disponibilidad { get; set; }

        // Aseguramos que la lista esté siempre inicializada al crear el objeto.
        public ContactanosViewModel()
        {
            Disponibilidad = new List<Disponibilidad>();
        }
    }

    // public class Disponibilidad
    // {
    //     public DateTime Fecha { get; set; }
    //     public TimeSpan HoraInicio { get; set; }
    //     public TimeSpan HoraFin { get; set; }
    //     public bool Disponible { get; set; }
    // }
}
