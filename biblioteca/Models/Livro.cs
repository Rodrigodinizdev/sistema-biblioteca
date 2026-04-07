namespace biblioteca.Models;

public class Livro
{
    public Livro(string titulo, string autor, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
        Id = ++ContadorId;
        Disponivel = true;   
    }
    public static int ContadorId = 0;
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public int AnoPublicacao { get; private set; }
    public bool Disponivel { get; set; }

    public void ExcluirLivro(Emprestimo emprestimo)
    {
        if(emprestimo.Devolvido)
        {
            System.Console.WriteLine("Livro não pode ser excluído, pois está emprestado.");
            return;
        }

            System.Console.WriteLine($"Livro \"{Titulo}\" excluído com sucesso."); 
    }
}
