using teste_biblioteca.Notification;
using teste_biblioteca.Interfaces.IRepositories;
using teste_biblioteca.DTOs;
using teste_biblioteca.Models;
using teste_biblioteca.Repositories;
using teste_biblioteca.Interfaces.Services;
namespace teste_biblioteca.Services;

public class LivroService(ILivroRepository livroRepository, Notificacao notificacao) : ILivroService
{
    private readonly ILivroRepository _livroRepository = livroRepository;
    private readonly Notificacao _notificacao = notificacao;

    public void AdicionarLivro(LivroDto livroDto)
    {
        _notificacao.Limpar();

        Livro livro = new Livro(livroDto.Nome, livroDto.Autor, livroDto.AnoPublicacao);
        _livroRepository.AdicionarLivro(livro);
        _notificacao.AdicionarSucesso($"{livro}");
        _notificacao.ExibirMensagens();  
    }

    public void ListarLivros()
    {
        _notificacao.Limpar();

        var livros = _livroRepository.ListarLivros();

        if (livros.Count == 0)
        {
            _notificacao.AdicionarErro("Não existem Livros Cadastrados");
            _notificacao.ExibirMensagens();
            return;
        }

        Console.WriteLine("=== Livros ===");
        foreach (var livro in livros)
        {
            _notificacao.AdicionarSucesso($"{livro}");
            _notificacao.ExibirMensagens();   
        }

    }
}
