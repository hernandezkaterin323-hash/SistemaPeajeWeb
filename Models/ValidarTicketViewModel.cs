using System.ComponentModel.DataAnnotations;

namespace SistemaPeajeWeb.Models;

public class ValidarTicketViewModel
{
    [Required(ErrorMessage = "Ingrese el código del ticket.")]
    [Display(Name = "Código del ticket")]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Punto de control")]
    public string Punto { get; set; } = "Entrada";

    public string? Mensaje { get; set; }
    public bool Exito { get; set; }
}
