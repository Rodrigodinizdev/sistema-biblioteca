using teste_biblioteca.Enums;

namespace teste_biblioteca.Models;

public class Livro
{
    public Livro(string nome, string autor, int anoPublicacao)
    {
        Id = ++_contadorId;
        Nome = nome;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
        StatusLivro = StatusLivroEnum.Disponivel;
    }
    private static int _contadorId = 0;
    public int Id { get; }
    public string Nome { get; private set; }
    public string Autor { get; private set; }
    public int AnoPublicacao { get; private set; }
    public StatusLivroEnum StatusLivro { get; private set; }

    public override string ToString()
    {
        return $"Livro: {Nome} | Autor> {Autor} | Ano: {AnoPublicacao}";
    }   
}
