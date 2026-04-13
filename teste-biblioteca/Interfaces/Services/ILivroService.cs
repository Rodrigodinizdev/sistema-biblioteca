using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_biblioteca.Models;

namespace teste_biblioteca.Interfaces.Services;

    public interface ILivroService
    {
        public void AdicionarLivro(Livro livro);
        public void ListarLivros();
    }
