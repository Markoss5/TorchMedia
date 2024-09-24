using Microsoft.AspNetCore.Mvc;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TorchMedia.Models;
using Microsoft.Data.SqlClient;


[Authorize]
public class TurnosController : Controller
{
    private string connectionString = "Server=localhost;Database=TorchMediaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    // Validar o registrar usuario desde el formulario de contacto
    [HttpPost]
    public IActionResult ValidarUsuario(string nombre, string email, string mensaje)
    {
        using (var con = new SqlConnection(connectionString))
        {
            // Verificar si el usuario existe
            var usuario = con.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuarios WHERE Correo = @Email", new { Email = email });

            if (usuario == null)
            {
                // Si el usuario no existe, lo creamos
                var query = "INSERT INTO Usuarios (Nombre, Correo, Password, EsAdmin) VALUES (@Nombre, @Correo, @Password, 0)";
                con.Execute(query, new { Nombre = nombre, Correo = email, Password = GenerateRandomPassword() });

                ViewBag.Mensaje = "Se ha creado una cuenta para usted. ¡Gracias por contactarnos!";
            }
            else
            {
                ViewBag.Mensaje = "Usuario validado. ¡Gracias por contactarnos!";
            }

            // Aquí podrías enviar el email utilizando EmailJS si fuera necesario
            return View("Confirmacion");
        }
    }

    // Método para reservar un turno
    [HttpPost]
    public IActionResult ReservarTurno(string email, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
    {
        using (var con = new SqlConnection(connectionString))
        {
            var usuario = con.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuarios WHERE Correo = @Correo", new { Correo = email });

            if (usuario == null)
            {
                ViewBag.Mensaje = "Debe registrarse para poder reservar un turno.";
                return View("Error");
            }

            var query = "INSERT INTO Turnos (UsuarioID, FechaAgendada, Estado) VALUES (@UsuarioID, @FechaAgendada, 'Reservado')";
            con.Execute(query, new { UsuarioID = usuario.UsuarioID, FechaAgendada = fecha });

            ViewBag.Mensaje = "Turno reservado exitosamente.";
            return View("Confirmacion");
        }
    }

    // Listar turnos reservados para el usuario autenticado
    public IActionResult MisTurnos(string email)
    {
        using (var con = new SqlConnection(connectionString))
        {
            var usuario = con.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuarios WHERE Correo = @Correo", new { Correo = email });

            if (usuario == null)
            {
                ViewBag.Mensaje = "Debe iniciar sesión para ver sus turnos.";
                return RedirectToAction("Login", "Usuarios");
            }

            var turnos = con.Query<Reserva>("SELECT * FROM Turnos WHERE UsuarioID = @UsuarioID", new { UsuarioID = usuario.UsuarioID }).ToList();
            return View(turnos);
        }
    }

    // Método auxiliar para generar contraseñas aleatorias
    private string GenerateRandomPassword()
    {
        return "default_password"; // Aquí podrías implementar un generador de contraseñas más seguro
    }
}