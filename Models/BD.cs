    using System.Data.SqlClient;
    using Dapper;
    using System.Collections.Generic;
    using TorchMedia.Models;
    using Microsoft.Data.SqlClient;

    public class BD
    {
        private string connectionString = @"Server=localhost;Database=TorchMediaDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Métodos para la sección Hero
        public HeroContent ObtenerHeroContent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<HeroContent>("SELECT * FROM HeroContent");
            }
        }

public void ActualizarHeroContent(HeroContent content)
{
    using (var connection = new SqlConnection(connectionString))
    {
        var sql = "UPDATE HeroContent SET Titulo = @Titulo, Descripcion = @Descripcion, VideoUrl = @VideoUrl WHERE HeroContentID = @HeroContentID";
        var rowsAffected = connection.Execute(sql, content);
        Console.WriteLine($"Filas actualizadas: {rowsAffected}");
    }
}


        // Métodos para la sección Quiénes Somos
        public QuienesSomosContent ObtenerQuienesSomosContent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<QuienesSomosContent>("SELECT * FROM QuienesSomosContent");
            }
        }

public void ActualizarQuienesSomosContent(QuienesSomosContent content)
{
    using (var connection = new SqlConnection(connectionString))
    {
        // Consulta SQL para actualizar el contenido
        var sql = "UPDATE QuienesSomosContent SET Titulo = @Titulo, Descripcion = @Descripcion, ImagenUrl = @ImagenUrl WHERE QuienesSomosID = @QuienesSomosID";
        
        // Ejecuta la consulta
        var rowsAffected = connection.Execute(sql, content);
        Console.WriteLine($"Filas actualizadas: {rowsAffected}");
    }
}

        // Métodos para la sección Servicios
        public IEnumerable<ServiciosContent> ObtenerServiciosContent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<ServiciosContent>("SELECT * FROM ServiciosContent");
            }
        }

        public void ActualizarServiciosContent(ServiciosContent content)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "UPDATE ServiciosContent SET Titulo = @Titulo, Descripcion = @Descripcion, IconoUrl = @IconoUrl WHERE ServicioID = @ServicioID";
                connection.Execute(sql, content);
            }
        }

        // Métodos para la sección Proyectos
        public IEnumerable<ProyectosContent> ObtenerProyectosContent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<ProyectosContent>("SELECT * FROM ProyectosContent");
            }
        }

        // Métodos para la sección Testimonios
        public TestimoniosContent ObtenerTestimoniosContent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<TestimoniosContent>("SELECT * FROM TestimoniosContent");
            }
        }

        public void ActualizarTestimoniosContent(TestimoniosContent content)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "UPDATE TestimoniosContent SET VideoUrl = @VideoUrl, ImagenUrl = @ImagenUrl WHERE TestimonioID = @TestimonioID";
                connection.Execute(sql, content);
            }
        }

        // Métodos para la sección Footer
        public FooterContent ObtenerFooterContent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<FooterContent>("SELECT * FROM FooterContent");
            }
        }

        public void ActualizarFooterContent(FooterContent content)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "UPDATE FooterContent SET Texto = @Texto, Correo = @Correo, InstagramUrl = @InstagramUrl WHERE FooterID = @FooterID";
                connection.Execute(sql, content);
            }
        }

        public IEnumerable<Disponibilidad> ObtenerDisponibilidad()
{
    using (var connection = new SqlConnection(connectionString))
    {
        return connection.Query<Disponibilidad>("SELECT * FROM Disponibilidad WHERE Disponible = 1");
    }
}

// Establecer disponibilidad de turnos (para el administrador)
public void EstablecerDisponibilidad(Disponibilidad disponibilidad)
{
    using (var connection = new SqlConnection(connectionString))
    {
        var sql = "INSERT INTO Disponibilidad (Fecha, HoraInicio, HoraFin, Disponible) VALUES (@Fecha, @HoraInicio, @HoraFin, @Disponible)";
        connection.Execute(sql, disponibilidad);
    }
}

// Reservar un turno
public void ReservarTurno(Turno turno)
{
    using (var connection = new SqlConnection(connectionString))
    {
        var sql = "INSERT INTO Turnos (UsuarioID, FechaAgendada, Estado) VALUES (@UsuarioID, @FechaAgendada, 'Reservado')";
        connection.Execute(sql, turno);

        // Actualizar la disponibilidad a no disponible
        var updateDisponibilidad = "UPDATE Disponibilidad SET Disponible = 0 WHERE Fecha = @FechaAgendada";
        connection.Execute(updateDisponibilidad, new { FechaAgendada = turno.FechaAgendada });
    }
}


    }
