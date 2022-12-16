using Microsoft.EntityFrameworkCore;

namespace Sureña_api.Modelos.Repositorio
{
    public class ManualRepositorio : IManual
    {
        protected readonly SureñaContext _context;
        public ManualRepositorio(SureñaContext context) => _context = context;

        public IEnumerable<Manual> GetManual()
        {
            return _context.Manuals.ToList();
        }

        public Manual GetManualById(int id)
        {
            return _context.Manuals.Find(id);
        }

        public async Task<Manual> CreateManualAsync(Manual manual)
        {
            await _context.Set<Manual>().AddAsync(manual);
            await _context.SaveChangesAsync();
            return manual;
        }

        public async Task<bool> UpdateManualAsync(Manual manual)
        {
            _context.Entry(manual).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteManualAsync(Manual manual)
        {
            //var entity = await GetByIdAsync(id);
            if (manual is null)
            {
                return false;
            }
            _context.Set<Manual>().Remove(manual);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
