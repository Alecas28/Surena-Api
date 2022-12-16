using Microsoft.EntityFrameworkCore;
using Sureña_api.Modelos;

namespace Sureña_api.Modelos.Repositorio
{
    public class CargoRepositorio : ICargo
    {
        protected readonly SureñaContext _context;
        public CargoRepositorio(SureñaContext context) => _context = context;

        public IEnumerable<Cargo> GetCargo()
        {
            return _context.Cargos.ToList();
        }

        public Cargo GetCargoById(int id)
        {
            return _context.Cargos.Find(id);
        }
        
        public async Task<Cargo> CreateCargoAsync(Cargo cargo)
        {
            await _context.Set<Cargo>().AddAsync(cargo);
            await _context.SaveChangesAsync();
            return cargo;
        }

        public async Task<bool> UpdateCargoAsync(Cargo cargo)
        {
            _context.Entry(cargo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCargoAsync(Cargo cargo)
        {
            //var entity = await GetByIdAsync(id);
            if (cargo is null)
            {
                return false;
            }
            _context.Set<Cargo>().Remove(cargo);
            await _context.SaveChangesAsync();

            return true;
        }

       
    }
}
