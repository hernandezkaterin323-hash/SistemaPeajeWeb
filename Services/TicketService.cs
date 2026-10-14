using SistemaPeajeWeb.Models;

namespace SistemaPeajeWeb.Services;

public class TicketService
{
    private readonly List<Ticket> _tickets = new();
    private readonly object _sync = new();

    public Ticket Crear(string placa, string tipoVehiculo, string formaPago)
    {
        var ticket = new Ticket
        {
            Placa = placa.Trim().ToUpperInvariant(),
            TipoVehiculo = tipoVehiculo,
            FormaPago = formaPago,
            Precio = CalcularTarifa(tipoVehiculo),
            FechaCompra = DateTime.Now,
            Estado = EstadoTicket.Comprado
        };

        ticket.Codigo = GenerarCodigo(ticket);

        lock (_sync)
        {
            _tickets.Insert(0, ticket);
        }

        return ticket;
    }

    public (bool Exito, string Mensaje, Ticket? Ticket) Validar(string codigo, string punto)
    {
        lock (_sync)
        {
            var ticket = _tickets.FirstOrDefault(t =>
                string.Equals(t.Codigo, codigo.Trim(), StringComparison.OrdinalIgnoreCase));

            if (ticket is null)
                return (false, "Código no encontrado. La barrera permanece cerrada.", null);

            if (string.Equals(punto, "Entrada", StringComparison.OrdinalIgnoreCase))
            {
                if (ticket.Estado != EstadoTicket.Comprado)
                    return (false, "Este ticket ya fue utilizado para entrar.", ticket);

                ticket.Estado = EstadoTicket.DentroDePlaza;
                ticket.FechaEntrada = DateTime.Now;
                return (true, "Ticket válido. AUTORIZAR APERTURA DE LA BARRERA DE ENTRADA.", ticket);
            }

            if (ticket.Estado == EstadoTicket.Comprado)
                return (false, "El vehículo todavía no registra entrada a la plaza.", ticket);

            if (ticket.Estado == EstadoTicket.Finalizado)
                return (false, "Este ticket ya completó su salida y no puede reutilizarse.", ticket);

            ticket.Estado = EstadoTicket.Finalizado;
            ticket.FechaSalida = DateTime.Now;
            return (true, "Ticket válido. AUTORIZAR APERTURA DE LA BARRERA DE SALIDA.", ticket);
        }
    }

    public DashboardViewModel Dashboard()
    {
        lock (_sync)
        {
            return new DashboardViewModel
            {
                TicketsVendidos = _tickets.Count,
                VehiculosDentro = _tickets.Count(t => t.Estado == EstadoTicket.DentroDePlaza),
                SalidasCompletadas = _tickets.Count(t => t.Estado == EstadoTicket.Finalizado),
                Recaudacion = _tickets.Sum(t => t.Precio),
                Tickets = _tickets.ToList()
            };
        }
    }

    public Ticket? Buscar(Guid id)
    {
        lock (_sync)
            return _tickets.FirstOrDefault(t => t.Id == id);
    }

    public static decimal CalcularTarifa(string tipoVehiculo) => tipoVehiculo switch
    {
        "Motocicleta" => 10m,
        "Automóvil" => 20m,
        "Pickup" => 30m,
        "Camión" => 50m,
        _ => 20m
    };

    private static string GenerarCodigo(Ticket ticket)
    {
        var fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
        var id = Guid.NewGuid().ToString("N")[..8].ToUpperInvariant();
        return $"PG-{ticket.Placa}-{fecha}-{id}";
    }
}
