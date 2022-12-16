using Microsoft.EntityFrameworkCore;

namespace Sureña_api.Modelos.Repositorio
{
    public class RelacionesRepositorio : IRelaciones
    {
        protected readonly SureñaContext _context;
        public RelacionesRepositorio(SureñaContext context) => _context = context;

        public IEnumerable<Relacione> GetRelacione()
        {
            return _context.Relaciones.ToList();
        }

        public Relacione GetRelacioneById(int id)
        {
            return _context.Relaciones.Find(id);
        }

        public async Task<Relacione> CreateRelacioneAsync(Relacione relacione)
        {
            await _context.Set<Relacione>().AddAsync(relacione);
            await _context.SaveChangesAsync();
            return relacione;
        }

        public async Task<bool> UpdateRelacioneAsync(Relacione relacione)
        {
            _context.Entry(relacione).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRelacioneAsync(Relacione relacione)
        {
            //var entity = await GetByIdAsync(id);
            if (relacione is null)
            {
                return false;
            }
            _context.Set<Relacione>().Remove(relacione);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
