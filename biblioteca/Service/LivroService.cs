namespace biblioteca.Service;
using biblioteca.Enums;
using biblioteca.Models;

    public class LivroService
    {
        public List<Livro> livros = new List<Livro>();

        public void CadastrarLivro(string titulo, string autor, int anoPublicacao)
        {
            Livro livro = new Livro(titulo, autor, anoPublicacao);
            livros.Add(livro);
            Console.WriteLine($"Livro cadastrado!: {livro}");
        }

        public void ListarLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            Console.WriteLine("Livros cadastrados:");
            
            foreach (var livro in livros)
                Console.WriteLine(livro);   
        }

        public void RemoverLivro(int id)
        {
            Livro livro = livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (livro.StatusLivro == StatusLivroEnum.Emprestado)
            {
                Console.WriteLine("Não é possível remover um livro que está emprestado.");
                return;
            }

            livros.Remove(livro);
            Console.WriteLine($"Livro removido: {livro}");
        }
    }
