using teste_biblioteca.Models;

namespace teste_biblioteca.Interfaces.Repositories;

    public interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario usuario);
        List<Usuario> ListarUsuarios();
        Usuario BuscarUsuarioPorId(int id);
    }
