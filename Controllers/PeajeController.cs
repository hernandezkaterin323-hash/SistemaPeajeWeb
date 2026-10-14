using Microsoft.AspNetCore.Mvc;
using SistemaPeajeWeb.Models;
using SistemaPeajeWeb.Services;

namespace SistemaPeajeWeb.Controllers;

public class PeajeController : Controller
{
    private readonly TicketService _tickets;

    public PeajeController(TicketService tickets)
    {
        _tickets = tickets;
    }

    [HttpGet]
    public IActionResult Comprar() => View(new ComprarTicketViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Comprar(ComprarTicketViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var ticket = _tickets.Crear(model.Placa, model.TipoVehiculo, model.FormaPago);
        return RedirectToAction(nameof(Ticket), new { id = ticket.Id });
    }

    [HttpGet]
    public IActionResult Ticket(Guid id)
    {
        var ticket = _tickets.Buscar(id);
        return ticket is null ? NotFound() : View(ticket);
    }

    [HttpGet]
    public IActionResult ValidarEntrada() => View("Validar", new ValidarTicketViewModel { Punto = "Entrada" });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ValidarEntrada(ValidarTicketViewModel model)
    {
        model.Punto = "Entrada";
        return ProcesarValidacion(model);
    }

    [HttpGet]
    public IActionResult ValidarSalida() => View("Validar", new ValidarTicketViewModel { Punto = "Salida" });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ValidarSalida(ValidarTicketViewModel model)
    {
        model.Punto = "Salida";
        return ProcesarValidacion(model);
    }

    [HttpGet]
    public IActionResult Validar() => RedirectToAction(nameof(ValidarEntrada));

    [HttpGet]
    public IActionResult Admin() => View(_tickets.Dashboard());

    private IActionResult ProcesarValidacion(ValidarTicketViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Validar", model);

        var resultado = _tickets.Validar(model.Codigo, model.Punto);
        model.Exito = resultado.Exito;
        model.Mensaje = resultado.Mensaje;
        return View("Validar", model);
    }
}
