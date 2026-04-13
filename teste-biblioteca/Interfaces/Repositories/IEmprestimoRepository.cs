using teste_biblioteca.Models;

namespace teste_biblioteca.Interfaces;

public interface IEmprestimoRepository
{
    void AdicionarEmprestimo(Emprestimo emprestimo);
    List<Emprestimo> ListarEmprestimos();
    void BuscarEmprestimoPorId(int id);
}
