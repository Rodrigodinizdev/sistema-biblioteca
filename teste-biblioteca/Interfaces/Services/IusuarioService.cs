using teste_biblioteca.DTOs;
namespace teste_biblioteca.Interfaces.Services;

    public interface IUsuarioService
    {
        public void CadastrarUsuario(UsuarioDTO usuarioDTO);
        public void ListarUsuarios();
    }
