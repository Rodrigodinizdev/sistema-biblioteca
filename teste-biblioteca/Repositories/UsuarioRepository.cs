using teste_biblioteca.Interfaces.Repositories;
using teste_biblioteca.Models;

namespace teste_biblioteca.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly List<Usuario> _usuarios = [];
    public Usuario BuscarUsuarioPorId(int id) => _usuarios.FirstOrDefault(u => u.Id == id);
  
    public void CadastrarUsuario(Usuario usuario) => _usuarios.Add(usuario);
  
    public List<Usuario> ListarUsuarios() => _usuarios; 
}
