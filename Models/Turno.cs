namespace TorchMedia.Models

{
    public class Turno
    {
        public int TurnoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaAgendada { get; set; }
        public string Estado { get; set; }
    }
}
