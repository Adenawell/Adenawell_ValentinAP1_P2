using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Adenawell_ValentinAP1_P2.Models;

public class AsignacionesPuntos
{
    [Key]
    public int IdAsignacion { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;

    public int EstudianteId { get; set; }

    public int TotalPuntos { get; set; }

    public ICollection<AsignacionPuntosDetalles> ListadoDetalles { get; set; } = new List<AsignacionPuntosDetalles>();

    [ForeignKey("EstudianteId")]
    public Estudiantes? Estudiantes { get; set; }




}
