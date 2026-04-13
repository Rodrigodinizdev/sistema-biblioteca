using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_biblioteca.Models;

namespace teste_biblioteca.Interfaces.Services;

    public interface IusuarioService
    {
        public void CadastrarUsuario(Usuario usuario);
        public void ListarUsuarios();
    }
