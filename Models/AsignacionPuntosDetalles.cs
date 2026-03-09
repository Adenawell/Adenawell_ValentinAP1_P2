using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adenawell_ValentinAP1_P2.Models;

public class AsignacionPuntosDetalles
{
    [Key]

    public int IdDetalle { get; set; }

    public int IdAsignacion { get; set; }

    public int CantidadPuntos {  get; set; }

    public int TipoPuntoId { get; set; }

    


}
