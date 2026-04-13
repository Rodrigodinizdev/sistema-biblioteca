using teste_biblioteca.Helpers;
using teste_biblioteca.Interfaces.IRepositories;
using teste_biblioteca.DTOs;
using teste_biblioteca.Models;
using teste_biblioteca.Repositories;
namespace teste_biblioteca.Services;

public class LivroService
{
    public LivroService(ILivroRepository livroRepository, Notification notification)
    {
        _livroRepository = livroRepository;
        _notification = notification;
    }
    private ILivroRepository _livroRepository;
    private readonly Notification _notification;

    public void AdicionarLivro(LivroDto livroDto)
    {
        if(string.IsNullOrWhiteSpace(livroDto.Nome))
            _notification.AdicionarErros("Nome do livro não pode ser vazio");
        
        if(string.IsNullOrWhiteSpace(livroDto.Autor))
            _notification.AdicionarErros("Nome do autor não pode ser vazio");

        if(livroDto.AnoPublicacao <= 0 || livroDto.AnoPublicacao > DateTime.Now.Year)
            _notification.AdicionarErros("Ano não pode ser menor que zero e não pode ser maior que o ano atual");

        if (_notification.TemErros())
        {
            _notification.ExibirErros();
            return;
        }

        Livro livro = new Livro(livroDto.Nome, livroDto.Autor, livroDto.AnoPublicacao);
        _livroRepository.AdicionarLivro(livro);
        Console.WriteLine($"{livro} adicionado com sucesso");
    }

    public void ListarLivros()
    {
        var livros = _livroRepository.ListarLivros();

        if(livros.Count == 0)
        {
            _notification.AdicionarErros("Não existem Livros Cadastrados");
            _notification.ExibirErros();
            return;
        }

        Console.WriteLine("=== Livros ===");
        foreach ( var livro in livros)
            Console.WriteLine(livro);
    }
}
