namespace biblioteca.Service;
using biblioteca.Enums;
using biblioteca.Models;
public class EmprestimoService
{
    public void RealizarEmprestimo(Usuario usuario, Livro livro)
    {
        if (livro.StatusLivro == StatusLivroEnum.Emprestado)
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
        livro.StatusLivro = StatusLivroEnum.Emprestado;
        Console.WriteLine($"Empréstimo realizado: {emprestimo}");
    }

    public void DevolverLivro(Emprestimo emprestimo, int diasComLivro)
    {
        if (diasComLivro > 7)
        {
            emprestimo.CalcularMulta(diasComLivro);
            System.Console.WriteLine($"Multa de {emprestimo.MultaGerada:C} gerada por atraso de {diasComLivro - 7} dias.");
        }
        emprestimo.Devolvido = true;
        emprestimo.DataDevolucao = DateTime.Now;
        emprestimo.Livro.StatusLivro = StatusLivroEnum.Disponível;
        System.Console.WriteLine($"Livro \"{emprestimo.Livro.Titulo}\" devolvido por {emprestimo.Usuario.Nome} em {emprestimo.DataDevolucao:dd/MM/yyyy}.");

    }
}
