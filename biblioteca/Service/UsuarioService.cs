namespace biblioteca.Service;
using biblioteca.Enums;
using biblioteca.Models;

    public class UsuarioService
    {
        public List<Usuario> usuarios = new List<Usuario>();

        public void CadastrarUsuario(string nome, string email, string telefone)
        {
            Usuario usuario = new Usuario(nome, email, telefone);
            usuarios.Add(usuario);
            Console.WriteLine($"Usuário cadastrado: {usuario}");
        }

        public void ListarUsuarios()
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            Console.WriteLine("Usuários cadastrados:");
            
            foreach (var usuario in usuarios)
                Console.WriteLine(usuario);   
        }

        public void RemoverUsuario(int id)
        {
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            if (usuario.TotalEmprestimos > 0)
            {
                Console.WriteLine("Não é possível remover um usuário com empréstimos ativos.");
                return;
            }

            usuarios.Remove(usuario);
            Console.WriteLine($"Usuário removido: {usuario}");
        }

    }
