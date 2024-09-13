using Microsoft.AspNetCore.Mvc;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TorchMedia.Models;


[Authorize]
public class TurnosController : Controller
{
    private BD repo = new BD();

    // Mostrar disponibilidad de turnos para el administrador
    public IActionResult VerDisponibilidad()
    {
        var disponibilidad = repo.ObtenerDisponibilidad();
        return View(disponibilidad);
    }

    // Establecer la disponibilidad de turnos (para el administrador)
    [HttpPost]
    public IActionResult EstablecerDisponibilidad(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
    {
        var disponibilidad = new Disponibilidad
        {
            Fecha = fecha,
            HoraInicio = horaInicio,
            HoraFin = horaFin,
            Disponible = true
        };
        
        repo.EstablecerDisponibilidad(disponibilidad);
        return RedirectToAction("VerDisponibilidad");
    }

    // Mostrar los turnos reservados
    public IActionResult VerTurnosAgendados()
    {
        var turnos = repo.ObtenerTurnos();
        return View(turnos);
    }

    // Reservar un turno (para los usuarios)
    [HttpPost]
    public IActionResult ReservarTurno(int usuarioID, DateTime fecha)
    {
        var turno = new Turno
        {
            UsuarioID = usuarioID,
            FechaAgendada = fecha,
            Estado = "Reservado"
        };
        
        repo.ReservarTurno(turno);
        return RedirectToAction("Index", "Home");
    }

    // Cancelar un turno
    [HttpPost]
    public IActionResult CancelarTurno(int turnoID)
    {
        repo.CancelarTurno(turnoID);
        return RedirectToAction("VerTurnosAgendados");
    }
}
