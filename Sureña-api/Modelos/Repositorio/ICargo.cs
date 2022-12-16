using Sureña_api.Modelos;
namespace Sureña_api.Modelos.Repositorio

{
    public interface ICargo
    {
        Task<Cargo> CreateCargoAsync(Cargo cargo);
        Task<bool> DeleteCargoAsync(Cargo cargo);
        Cargo GetCargoById(int id);
        IEnumerable<Cargo> GetCargo();
        Task<bool> UpdateCargoAsync(Cargo cargo);
    }
}
