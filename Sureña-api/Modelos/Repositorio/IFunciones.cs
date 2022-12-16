namespace Sureña_api.Modelos.Repositorio
{
    public interface IFunciones
    {
        Task<Funcione> CreateFuncioneAsync(Funcione funcione);
        Task<bool> DeleteFuncioneAsync(Funcione funcione);
        Funcione GetFuncioneById(int id);
        IEnumerable<Funcione> GetFuncione();
        Task<bool> UpdateFuncioneAsync(Funcione funcione);
    }
}
