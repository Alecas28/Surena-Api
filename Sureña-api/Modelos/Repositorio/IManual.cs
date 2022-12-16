namespace Sureña_api.Modelos.Repositorio
{
    public interface IManual
    {
        Task<Manual> CreateManualAsync(Manual manual);
        Task<bool> DeleteManualAsync(Manual manual);
        Manual GetManualById(int id);
        IEnumerable<Manual> GetManual();
        Task<bool> UpdateManualAsync(Manual manual);
    }
}
