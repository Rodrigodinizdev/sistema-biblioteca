using teste_biblioteca.DTOs;
namespace teste_biblioteca.Interfaces.Services;

    public interface IEmprestimoService
    {
        public void AdicionarEmprestimo(EmprestimoDTO emprestimoDTO);
        public void Devolver(int idEmprestimo, int diasComLivro);
        public void ListarEmprestimos();
    }
