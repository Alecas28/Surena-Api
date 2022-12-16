using Microsoft.EntityFrameworkCore;

namespace Sureña_api.Modelos.Repositorio
{
    public class FuncionesRepositorio : IFunciones
    {
        protected readonly SureñaContext _context;
        public FuncionesRepositorio(SureñaContext context) => _context = context;

        public IEnumerable<Funcione> GetFuncione()
        {
            return _context.Funciones.ToList();
        }

        public Funcione GetFuncioneById(int id)
        {
            return _context.Funciones.Find(id);
        }

        public async Task<Funcione> CreateFuncioneAsync(Funcione funcione)
        {
            await _context.Set<Funcione>().AddAsync(funcione);
            await _context.SaveChangesAsync();
            return funcione;
        }

        public async Task<bool> UpdateFuncioneAsync(Funcione funcione)
        {
            _context.Entry(funcione).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFuncioneAsync(Funcione funcione)
        {
            //var entity = await GetByIdAsync(id);
            if (funcione is null)
            {
                return false;
            }
            _context.Set<Funcione>().Remove(funcione);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
