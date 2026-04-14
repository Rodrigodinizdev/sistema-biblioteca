using teste_biblioteca.DTOs;
namespace teste_biblioteca.Interfaces.Services;

    public interface ILivroService
    {
        public void AdicionarLivro(LivroDto livroDto);
        public void ListarLivros();
    }
