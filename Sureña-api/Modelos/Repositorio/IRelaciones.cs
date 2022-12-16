namespace Sureña_api.Modelos.Repositorio
{
    public interface IRelaciones
    {
        Task<Relacione> CreateRelacioneAsync(Relacione relacione);
        Task<bool> DeleteRelacioneAsync(Relacione relacione);
        Relacione GetRelacioneById(int id);
        IEnumerable<Relacione> GetRelacione();
        Task<bool> UpdateRelacioneAsync(Relacione relacione);
    }
}
