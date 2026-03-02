using System.ComponentModel.DataAnnotations;

namespace Adenawell_ValentinAP1_P2.Models;

public class ViajesEspaciales
{
    [Key]
    public int ViajeId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El costo es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a cero")]
    public decimal Costo { get; set; }
}