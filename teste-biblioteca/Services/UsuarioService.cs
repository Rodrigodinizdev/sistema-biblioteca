using teste_biblioteca.DTOs;
using teste_biblioteca.Notification;
using teste_biblioteca.Interfaces.Repositories;
using teste_biblioteca.Interfaces.Services;
using teste_biblioteca.Models;

namespace teste_biblioteca.Services;

public class UsuarioService(IUsuarioRepository usuarioRepository, Notificacao notificacao) : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
    private readonly Notificacao _notificacao = notificacao;

    public void CadastrarUsuario(UsuarioDTO usuarioDTO)
    {
        _notificacao.Limpar();

        Usuario usuario = new Usuario(usuarioDTO.Nome, usuarioDTO.Telefone, usuarioDTO.Email);
        _usuarioRepository.CadastrarUsuario(usuario);
        _notificacao.AdicionarErro($"Usuário cadastrado com Sucesso: {usuario}");
        _notificacao.ExibirMensagens();
    }

    public void ListarUsuarios()
    {
        _notificacao.Limpar();

        var usuarios = _usuarioRepository.ListarUsuarios();

        if(usuarios.Count == 0)
        {
            _notificacao.AdicionarErro("Nenhum Usuário cadastrado");
            _notificacao.ExibirMensagens();
            return;
        }

        Console.WriteLine("=== USUÁRIOS ===");
        foreach (var usuario in usuarios)
        {
            _notificacao.AdicionarSucesso($"{usuario}");
            _notificacao.ExibirMensagens();
        }
            
    }
}
