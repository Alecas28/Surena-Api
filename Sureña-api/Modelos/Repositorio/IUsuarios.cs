namespace Sureña_api.Modelos.Repositorio
{
    public interface IUsuarios
    {
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<bool> DeleteUsuarioAsync(Usuario usuario);
        Usuario GetUsuarioById(int id);
        IEnumerable<Usuario> GetUsuario();
        Task<bool> UpdateUsuarioAsync(Usuario usuario);
    }
}
