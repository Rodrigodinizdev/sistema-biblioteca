using teste_biblioteca.Interfaces.IRepositories;
using teste_biblioteca.Models;

namespace teste_biblioteca.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly List<Livro> _livros = [];
    
    public void AdicionarLivro(Livro livro) => _livros.Add(livro);
   
    public Livro BuscarLivroPorId(int id) => _livros.FirstOrDefault(l => l.Id == id);
    
    public List<Livro> ListarLivros() => _livros;
}
