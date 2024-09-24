using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using System;

namespace TorchMedia.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly string connectionString = "Server=localhost;Database=TorchMediaDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
public IActionResult NuevoUsuario(string Nombre, string Correo, string Password)
        {
            try
            {
                using SqlConnection con = new SqlConnection(connectionString);
                string query = "INSERT INTO Usuarios (Nombre, Correo, Password, EsAdmin) VALUES (@Nombre, @Correo, @Password, 0)";
                
                int rowsAffected = con.Execute(query, new { Nombre, Correo, Password });

                if (rowsAffected > 0)
                {
                    // Si la inserción fue exitosa, autenticamos al usuario
                    Response.Cookies.Append("Correo", Correo);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "No se pudo registrar el usuario. Inténtalo nuevamente.";
                    return View("Registrarse");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Ocurrió un error: {ex.Message}";
                return View("Registrarse");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(string Correo, string Password)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo AND Password = @Password";
            
            int count = con.ExecuteScalar<int>(query, new { Correo, Password });
            
            if (count > 0)
            {
                // Si las credenciales son correctas, establecer una cookie de autenticación
                Response.Cookies.Append("Correo", Correo);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Si las credenciales no son correctas, mostrar mensaje de error
                ViewBag.Error = "Correo o contraseña incorrectos";
                return View("Login");
            }
        }

        public IActionResult CerrarSesion()
        {
            Response.Cookies.Delete("Correo");
            return RedirectToAction("Login", "Usuarios");
        }
    }
}
