using teste_biblioteca.Models;
namespace teste_biblioteca.Interfaces.IRepositories;

    public interface ILivroRepository
    {
        void AdicionarLivro(Livro livro);
        List<Livro> ListarLivros();
        Livro BuscarLivroPorId(int id);
    }
