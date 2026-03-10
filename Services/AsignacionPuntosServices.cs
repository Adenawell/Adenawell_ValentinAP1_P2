using System.Linq.Expressions;
using Adenawell_ValentinAP1_P2.DAL;
using Adenawell_ValentinAP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Adenawell_ValentinAP1_P2.Services;

public class AsignacionPuntosServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(AsignacionesPuntos asign)
    {
        if(!await Existe(asign)){
            return await Insertar(asign);
        }
        else return await Modificar(asign);


    }

    private async Task<bool> Insertar(AsignacionesPuntos asign)
    {
        await using var Contexto = DbFactory.CreateDbContext();

        var estudiante = Contexto.Estudiantes.FirstOrDefault(e=> e.EstudianteId == asign.EstudianteId );
        estudiante.BalancePuntos += asign.TotalPuntos;
        Contexto.AsignacionPuntos.Add(asign);
        return await Contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(AsignacionesPuntos a)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var EntradaAnterior = await contexto.AsignacionPuntos.Include(e => e.Estudiantes).Include(e => e.ListadoDetalles).FirstOrDefaultAsync(e => e.IdAsignacion == a.IdAsignacion);
        var StudentEntradaAnt = await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudianteId == a.EstudianteId);
        StudentEntradaAnt.BalancePuntos -= EntradaAnterior.TotalPuntos;
        contexto.Detalles.RemoveRange(EntradaAnterior.ListadoDetalles);
        foreach (var item in a.ListadoDetalles)
        {
            EntradaAnterior.ListadoDetalles.Add(
                new AsignacionPuntosDetalles
                {
                    IdAsignacion = a.IdAsignacion,
                    TipoPuntoId = item.TipoPuntoId,
                    CantidadPuntos = item.CantidadPuntos
                }
            );
        }
        EntradaAnterior.EstudianteId = a.EstudianteId;
        EntradaAnterior.Fecha = a.Fecha;
        EntradaAnterior.TotalPuntos = a.TotalPuntos;
        StudentEntradaAnt.BalancePuntos += a.TotalPuntos;
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(AsignacionesPuntos asign)
    {
        await using var Contexto = DbFactory.CreateDbContext();
        return await Contexto.AsignacionPuntos.AnyAsync(e=> e.IdAsignacion == asign.IdAsignacion);
    }



    public async Task<bool> ExisteHuacalRegistrado(string nombre, int tipoId)
    {
        return true;
    }

    public async Task<bool> Eliminar(int id)
    {
        return true;
    }

    public async Task<AsignacionesPuntos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.AsignacionPuntos.FindAsync(id);
    }
    

    public async Task<List<AsignacionesPuntos>> Listar(Expression<Func<AsignacionesPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.AsignacionPuntos.Include(e => e.ListadoDetalles).Include(e => e.Estudiantes).Where(criterio).AsNoTracking().ToListAsync();
    }

    public async Task<AsignacionesPuntos?> Busqueda(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.AsignacionPuntos.Include(e => e.ListadoDetalles).Include(e => e.Estudiantes).FirstOrDefaultAsync(e => e.IdAsignacion == id);
    }

}
