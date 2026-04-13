using teste_biblioteca.DTOs;
using teste_biblioteca.Helpers;
using teste_biblioteca.Interfaces.Repositories;
using teste_biblioteca.Models;

namespace teste_biblioteca.Services;

public class UsuarioService
{
    public UsuarioService(IUsuarioRepository usuarioRepository, Notification notification)
    {
        _usuarioRepository = usuarioRepository;
        _notification = notification;
    }
    private IUsuarioRepository _usuarioRepository;
    private readonly Notification _notification;

    public void CadastrarUsuario(UsuarioDTO usuarioDTO)
    {
        if(string.IsNullOrWhiteSpace(usuarioDTO.Nome))
            _notification.AdicionarErros("Nome é obrigatório");
        
        if(string.IsNullOrWhiteSpace(usuarioDTO.Telefone) || usuarioDTO.Telefone.Length != 11)
            _notification.AdicionarErros("Telefone não pode ser vazio e deve ter 11 dígitos");

        if(string.IsNullOrWhiteSpace(usuarioDTO.Email) || !usuarioDTO.Email.Contains("@"))
            _notification.AdicionarErros("Email não pode ser vazio e deve conter @");

        if (_notification.TemErros())
        {
            _notification.ExibirErros();
            return;
        }

        Usuario usuario = new Usuario(usuarioDTO.Nome, usuarioDTO.Telefone, usuarioDTO.Email);
        _usuarioRepository.CadastrarUsuario(usuario);
        Console.WriteLine($"Usuário cadastrado com Sucesso: {usuario}");
    }

    public void ListarUsuarios()
    {
        var usuarios = _usuarioRepository.ListarUsuarios();

        if(usuarios.Count == 0)
        {
            _notification.AdicionarErros("Nenhum produto cadastrado");
            return;
        }

        Console.WriteLine("=== USUÁRIOS ===");
        foreach (var usuario in usuarios)
            Console.WriteLine(usuario);
    }
}
