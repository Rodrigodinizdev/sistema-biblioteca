using teste_biblioteca.DTOs;
using teste_biblioteca.Enums;
using teste_biblioteca.Interfaces;
using teste_biblioteca.Interfaces.IRepositories;
using teste_biblioteca.Interfaces.Repositories;
using teste_biblioteca.Interfaces.Services;
using teste_biblioteca.Models;
using teste_biblioteca.Notification;
namespace teste_biblioteca.Services;

public class EmprestimoService(IEmprestimoRepository emprestimoRepository, IUsuarioRepository usuarioRepository, ILivroRepository livroRepository, Notificacao notificacao) : IEmprestimoService
{
    private readonly IEmprestimoRepository _emprestimoRepository = emprestimoRepository;
    private readonly ILivroRepository _livroRepository = livroRepository;
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
    private readonly Notificacao _notificacao = notificacao;

    public void AdicionarEmprestimo(EmprestimoDTO emprestimoDTO)
    {
        _notificacao.Limpar();

        Usuario usuario = _usuarioRepository.BuscarUsuarioPorId(emprestimoDTO.IdUsuario);
        if (usuario == null)
        {
            _notificacao.AdicionarErro("Usuário não encontrado");
            _notificacao.ExibirMensagens();
            return;
        }

        Livro livro = _livroRepository.BuscarLivroPorId(emprestimoDTO.IdLivro);
        if (livro == null)
        {
            _notificacao.AdicionarErro("Livro não encontrado");
            _notificacao.ExibirMensagens();
            return;
        }

        if (livro.StatusLivro == StatusLivroEnum.Emprestado)
        {
            _notificacao.AdicionarErro("Livro não está disponível");
            _notificacao.ExibirMensagens();
            return;
        }

        int totalEmprestimos = _emprestimoRepository.ListarEmprestimos().Count(e => e.Usuario.Id == usuario.Id && !e.Devolvido);

        if (totalEmprestimos >= 3)
        {
            _notificacao.AdicionarErro("Usuário já atingiu o limite de 3 empréstimos");
            _notificacao.ExibirMensagens();
            return;
        }

        Emprestimo emprestimo = new Emprestimo(livro, usuario);
        _emprestimoRepository.AdicionarEmprestimo(emprestimo);
        livro.AlterarStatus(StatusLivroEnum.Emprestado);
        _notificacao.AdicionarSucesso("Empréstimo realizado com sucesso");
        _notificacao.ExibirMensagens();
    }

    public void Devolver(int idEmprestimo, int diasComLivro)
    {
        _notificacao.Limpar();

        Emprestimo emprestimo = _emprestimoRepository.BuscarEmprestimoPorId(idEmprestimo);
        if (emprestimo == null)
        {
            _notificacao.AdicionarErro("Empréstimo não encontrado");
            _notificacao.ExibirMensagens();
            return;
        }

        if (emprestimo.Devolvido)
        {
            _notificacao.AdicionarErro("Este empréstimo já foi devolvido");
            _notificacao.ExibirMensagens();
            return;
        }

        emprestimo.CalcularMulta(diasComLivro);
        emprestimo.Devolver(DateTime.Now);
        emprestimo.Livro.AlterarStatus(StatusLivroEnum.Disponivel);
        _notificacao.AdicionarSucesso($"{emprestimo}");
        _notificacao.ExibirMensagens();
    }

    public void ListarEmprestimos()
    {
        _notificacao.Limpar();

        var emprestimos = _emprestimoRepository.ListarEmprestimos();

        if (emprestimos.Count == 0)
        {
            _notificacao.AdicionarErro("Não existem empréstimos cadastrados");
            _notificacao.ExibirMensagens();
            return;
        }

        Console.WriteLine("=== Empréstimos ===");
        foreach (var emprestimo in emprestimos)
        {
            _notificacao.AdicionarSucesso($"{emprestimo}");
            _notificacao.ExibirMensagens();
        }
    }
}
