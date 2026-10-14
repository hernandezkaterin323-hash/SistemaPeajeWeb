using System.ComponentModel.DataAnnotations;

namespace SistemaPeajeWeb.Models;

public class Ticket
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Placa { get; set; } = string.Empty;

    [Required]
    public string TipoVehiculo { get; set; } = "Automóvil";

    [Required]
    public string FormaPago { get; set; } = "Tarjeta de crédito/débito";

    public decimal Precio { get; set; }
    public DateTime FechaCompra { get; set; } = DateTime.Now;
    public string Codigo { get; set; } = string.Empty;
    public EstadoTicket Estado { get; set; } = EstadoTicket.Comprado;
    public DateTime? FechaEntrada { get; set; }
    public DateTime? FechaSalida { get; set; }
}

public enum EstadoTicket
{
    Comprado,
    DentroDePlaza,
    Finalizado
}
