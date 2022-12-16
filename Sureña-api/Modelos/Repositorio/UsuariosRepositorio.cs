using Microsoft.EntityFrameworkCore;

namespace Sureña_api.Modelos.Repositorio
{
    public class UsuariosRepositorio : IUsuarios
    {
        protected readonly SureñaContext _context;
        public UsuariosRepositorio(SureñaContext context) => _context = context;

        public IEnumerable<Usuario> GetUsuario()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsuarioAsync(Usuario usuario)
        {
            //var entity = await GetByIdAsync(id);
            if (usuario is null)
            {
                return false;
            }
            _context.Set<Usuario>().Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
