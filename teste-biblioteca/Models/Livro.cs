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
    public string Nome { get; }
    public string Autor { get; }
    public int AnoPublicacao { get; init; }
    public StatusLivroEnum StatusLivro { get; private set; }

    public void AlterarStatus(StatusLivroEnum status) => StatusLivro = status;

    public override string ToString()
    {
        return $"Livro: {Nome} | Autor> {Autor} | Ano: {AnoPublicacao}";
    }   
}
