using System.Linq.Expressions;
using Adenawell_ValentinAP1_P2.DAL;
using Adenawell_ValentinAP1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace Adenawell_ValentinAP1_P2.Services;

public class TiposPuntosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.Where(criterio).AsNoTracking().ToListAsync();
    }
}
