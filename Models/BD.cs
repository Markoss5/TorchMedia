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
                connection.Execute(sql, content);
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
                var sql = "UPDATE QuienesSomosContent SET Titulo = @Titulo, Descripcion = @Descripcion, ImagenUrl = @ImagenUrl WHERE QuienesSomosID = @QuienesSomosID";
                connection.Execute(sql, content);
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
    }
