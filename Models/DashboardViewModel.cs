namespace SistemaPeajeWeb.Models;

public class DashboardViewModel
{
    public int TicketsVendidos { get; set; }
    public int VehiculosDentro { get; set; }
    public int SalidasCompletadas { get; set; }
    public decimal Recaudacion { get; set; }
    public IReadOnlyList<Ticket> Tickets { get; set; } = Array.Empty<Ticket>();
}
