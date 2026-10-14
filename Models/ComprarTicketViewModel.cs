using System.ComponentModel.DataAnnotations;

namespace SistemaPeajeWeb.Models;

public class ComprarTicketViewModel
{
    [Required(ErrorMessage = "Ingrese la placa del vehículo.")]
    [Display(Name = "Placa del vehículo")]
    public string Placa { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Tipo de vehículo")]
    public string TipoVehiculo { get; set; } = "Automóvil";

    [Required]
    [Display(Name = "Forma de pago (simulada)")]
    public string FormaPago { get; set; } = "Tarjeta de crédito/débito";
}
