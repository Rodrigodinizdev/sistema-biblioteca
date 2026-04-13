using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_biblioteca.Models;

namespace teste_biblioteca.Interfaces.Services;

    public interface IEmprestimoService
    {
        public void AdicionarEmprestimo(Emprestimo emprestimo);
        public void Devolver(int idEmprestimo, int livroId, int diasComLivro);
        public void ListarEmprestimos();

    }
