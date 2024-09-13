namespace TorchMedia.Models
{
    public class Disponibilidad
    {
        public int DisponibilidadID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Disponible { get; set; }
    }
}
