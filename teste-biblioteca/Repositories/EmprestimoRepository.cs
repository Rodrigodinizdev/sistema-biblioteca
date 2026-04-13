using teste_biblioteca.Interfaces;
using teste_biblioteca.Models;

namespace teste_biblioteca.Repositories;

public class EmprestimoRepository : IEmprestimoRepository
{   
    private readonly List<Emprestimo> _emprestimos = [];
    public void AdicionarEmprestimo(Emprestimo emprestimo) => _emprestimos.Add(emprestimo);
  
    public Emprestimo BuscarEmprestimoPorId(int id) => _emprestimos.FirstOrDefault(e => e.Id == id);
 
    public List<Emprestimo> ListarEmprestimos() => _emprestimos;
      
}
