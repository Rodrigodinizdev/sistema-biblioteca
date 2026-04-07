namespace biblioteca.Service;
using biblioteca.Models;
public class EmprestimoService 
{
        public List<Livro> Livros { get; private set; } = new List<Livro>();
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();
        public void RealizarEmprestimo(Usuario usuario, Livro livro)
        {
            if (!livro.Disponivel)
            {
                Console.WriteLine("Livro não está disponível");
                return;
            }

            if (usuario.TotalEmprestimos >= 3)
            {
                Console.WriteLine("ERRO! Usuário não pode ter mais de 3 livros emprestados simultaneamente");
                return;
            }

            Emprestimo emprestimo = new Emprestimo(livro, usuario);

            usuario.Emprestimos.Add(emprestimo);
            livro.Disponivel = false;
            Console.WriteLine($"Empréstimo realizado: {emprestimo}");
        }

        public void DevolverLivro(Emprestimo emprestimo, int diasComLivro)
    {
        if(diasComLivro > 7)
        {
            emprestimo.CalcularMulta(diasComLivro);
            System.Console.WriteLine($"Multa de {emprestimo.MultaGerada:C} gerada por atraso de {diasComLivro - 7} dias.");    
        }
        emprestimo.Devolvido = true;
        emprestimo.DataDevolucao = DateTime.Now;
        emprestimo.Livro.Disponivel = true;
        System.Console.WriteLine($"Livro \"{emprestimo.Livro.Titulo}\" devolvido por {emprestimo.Usuario.Nome} em {emprestimo.DataDevolucao:dd/MM/yyyy}.");

    }
}
