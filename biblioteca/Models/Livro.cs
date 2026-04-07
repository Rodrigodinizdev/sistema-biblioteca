using biblioteca.Enums;
namespace biblioteca.Models;

public class Livro
{
    public Livro(string titulo, string autor, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
        Id = ++ContadorId;
        StatusLivro = StatusLivroEnum.Disponível;   
    }
    private static int ContadorId = 0;
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public int AnoPublicacao { get; private set; }
    public StatusLivroEnum StatusLivro { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} | Título: {Titulo} | Autor: {Autor} | Ano: {AnoPublicacao} | Status: {StatusLivro}";
    }
}
