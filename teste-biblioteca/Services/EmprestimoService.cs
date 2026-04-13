using teste_biblioteca.DTOs;
using teste_biblioteca.Enums;
using teste_biblioteca.Helpers;
using teste_biblioteca.Interfaces;
using teste_biblioteca.Interfaces.IRepositories;
using teste_biblioteca.Interfaces.Repositories;
using teste_biblioteca.Models;
using teste_biblioteca.Repositories;
namespace teste_biblioteca.Services;

public class EmprestimoService
{
    public EmprestimoService(IEmprestimoRepository emprestimoRepository, IUsuarioRepository usuarioRepository, ILivroRepository livroRepository, Notification notification)
    {
        _emprestimoRepository = emprestimoRepository;
        _usuarioRepository = usuarioRepository;
        _livroRepository = livroRepository;
        _notification = notification;
    }
    private readonly IEmprestimoRepository _emprestimoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILivroRepository _livroRepository;
    private readonly Notification _notification;

    public void AdicionarEmprestimo(EmprestimoDTO emprestimoDTO)
    {
        Usuario usuario = _usuarioRepository.BuscarUsuarioPorId(emprestimoDTO.IdUsuario);
        if (usuario == null)
        {
            _notification.AdicionarErros("Usuário não encontrado");
            _notification.ExibirErros();
            return;
        }

        Livro livro = _livroRepository.BuscarLivroPorId(emprestimoDTO.IdLivro);
        if (livro == null)
        {
            _notification.AdicionarErros("Livro não encontrado");
            _notification.ExibirErros();
            return;
        }

        if (livro.StatusLivro == StatusLivroEnum.Emprestado)
        {
            _notification.AdicionarErros("Livro não está disponível");
            _notification.ExibirErros();
            return;
        }

        int totalEmprestimos = _emprestimoRepository.ListarEmprestimos().Count(e => e.Usuario.Id == usuario.Id && !e.Devolvido);

        if (totalEmprestimos >= 3)
        {
            _notification.AdicionarErros("Usuário já atingiu o limite de 3 empréstimos");
            _notification.ExibirErros();
            return;
        }

        Emprestimo emprestimo = new Emprestimo(livro, usuario);
        _emprestimoRepository.AdicionarEmprestimo(emprestimo);
        livro.AlterarStatus(StatusLivroEnum.Emprestado);
        Console.WriteLine("Empréstimo realizado com sucesso");
    }

    public void Devolver(int idEmprestimo, int diasComLivro)
    {
        Emprestimo emprestimo = _emprestimoRepository.BuscarEmprestimoPorId(idEmprestimo);
        if (emprestimo == null)
        {
            _notification.AdicionarErros("Empréstimo não encontrado");
            _notification.ExibirErros();
            return;
        }

        if (emprestimo.Devolvido)
        {
            _notification.AdicionarErros("Este empréstimo já foi devolvido");
            _notification.ExibirErros();
            return;
        }

        emprestimo.CalcularMulta(diasComLivro);
        emprestimo.Devolver(DateTime.Now);
        emprestimo.Livro.AlterarStatus(StatusLivroEnum.Disponivel);
        Console.WriteLine(emprestimo);
    }

    public void ListarEmprestimos()
    {
        var emprestimos = _emprestimoRepository.ListarEmprestimos();

        if (emprestimos.Count == 0)
        {
            _notification.AdicionarErros("Não existe empréstimos cadastrados");
            _notification.ExibirErros();
            return;
        }

        Console.WriteLine("=== Empréstimos ===");
        foreach (var emprestimo in emprestimos)
            Console.WriteLine(emprestimo);
    }
}
