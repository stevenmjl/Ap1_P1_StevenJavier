using Ap1_P1_StevenJavier.DAL;
using Ap1_P1_StevenJavier.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ap1_P1_StevenJavier.Services
{
    public class ArticulosService
    {
        private readonly Contexto _contexto;
        public ArticulosService(Contexto contexto)
        {
            _contexto = contexto;
        }

        private async Task<bool> Existe(int id)
        {
            return await _contexto.Articulos
                .AnyAsync(e => e.ArticulosId == id);
        }

        public async Task<bool> Guardar(Articulos articulo)
        {
            if (!await Existe(articulo.ArticulosId))
                return await Insertar(articulo);
            else
                return await Modificar(articulo);
        }
        private async Task<bool> Insertar(Articulos articulo)
        {
            _contexto.Articulos.Add(articulo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Articulos articulo)
        {
            _contexto.Articulos.Update(articulo);
            var modificado = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(articulo).State = EntityState.Detached;
            return modificado;
        }

        public async Task<bool> Eliminar(int id)
        {
            var articulos = await _contexto.Articulos
                .Where(e => e.ArticulosId == id)
                .ExecuteDeleteAsync();
            return articulos > 0;
        }

        public async Task<Articulos?> BuscarId(int id)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.ArticulosId == id);
        }

        public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
