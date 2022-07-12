using Microsoft.EntityFrameworkCore;
using Nebulosa.Facturacion.AccesoADatos.CategoriasDeProducto;

namespace Nebulosa.Facturacion.Repositorio
{
    public class CategoriaDeProductoRepositorio : ICategoriaDeProductoRepositorio
    {
        private readonly Contexto _db;

        public CategoriaDeProductoRepositorio(Contexto db)
        {
            this._db = db;
        }

        public async Task AgregueLaCategoria(CategoriaDeProducto categoriaDeProducto)
        {
            await _db.CategoriasDeProducto.AddAsync(categoriaDeProducto);
            await _db.SaveChangesAsync();
        }

        public async Task ActualiceLaCategoria(CategoriaDeProducto categoriaDeProducto)
        {
            _db.CategoriasDeProducto.Attach(categoriaDeProducto).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task ElimineLaCategoria(int categoriaDeProductoId)
        {
            CategoriaDeProducto categoriaDeProducto = await ObtengaLaCategoria(categoriaDeProductoId);
            categoriaDeProducto.Borrado = true;
            await ActualiceLaCategoria(categoriaDeProducto);
        }

        public async Task<CategoriaDeProducto> ObtengaLaCategoria(int categoriaDeProductoId)
        {
            CategoriaDeProducto categoriaDeProducto = await _db.CategoriasDeProducto.FindAsync(categoriaDeProductoId);

            if (categoriaDeProducto == null)
            {
                throw new Exception("No se encontro la categoria");
            }

            return categoriaDeProducto;
        }

        public async Task<bool> VerifiqueLaCategoria(string nombre)
        {
            CategoriaDeProducto categoriaDeProducto = await _db.CategoriasDeProducto.FirstOrDefaultAsync(x => x.Nombre.ToLower() == nombre.ToLower());

            if (categoriaDeProducto == null)
            {
                return false;
            }

            categoriaDeProducto.Borrado = false;
            await ActualiceLaCategoria(categoriaDeProducto);
            return true;
        }


        public async Task<List<CategoriaDeProducto>> ObtengaLaListaDeCategorias()
        {
            List<CategoriaDeProducto> categoriasDeProducto = await _db.CategoriasDeProducto.Where(x => !x.Borrado).ToListAsync();

            return categoriasDeProducto;
        }

    }
}
