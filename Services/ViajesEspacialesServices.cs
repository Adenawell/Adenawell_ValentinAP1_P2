using System.Linq.Expressions;
using Adenawell_ValentinAP1_P2.DAL;
using Adenawell_ValentinAP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Adenawell_ValentinAP1_P2.Services;

public class ViajesEspacialesServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(ViajesEspaciales viajesEspaciales)
    {
        return true;
    }

    private async Task<bool> Insertar(ViajesEspaciales viajesEspaciales)
    {
        return true;
    }

    private async Task<bool> Modificar(ViajesEspaciales viajesEspaciales)
    {
        return true;
    }

    public async Task<bool> Existe(ViajesEspaciales viajesEspaciales)
    {
        return true;
    }



    public async Task<bool> ExisteHuacalRegistrado(string nombre, int tipoId)
    {
        return true;
    }

    public async Task<bool> Eliminar(int id)
    {
        return true;
    }

    public async Task<List<ViajesEspaciales>> GetTipos()
    {
        return null;
    }

    public async Task<ViajesEspaciales?> Buscar(int id)
    {
        return null;
    }

    public async Task<List<ViajesEspaciales>> Listar(Expression<Func<ViajesEspaciales, bool>> criterio)
    {
        //await using var contexto = await DbFactory.CreateDbContextAsync();
        //return await contexto.ViajesEspaciales
        //    .Include(e => e.ViajesEspacialesDetalle)
        //    .Where(criterio)
        //    .AsNoTracking()
        //    .ToListAsync();

        return null;
    }

}
