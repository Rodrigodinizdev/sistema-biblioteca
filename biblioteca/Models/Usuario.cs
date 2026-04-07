namespace biblioteca.Models;

    public class Usuario
    {
          public Usuario(string nome, string email, string telefone)
        {
            Id = ++ContadorId;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Emprestimos = new List<Emprestimo>();
        }
        public static int ContadorId = 0;
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }

        public int TotalEmprestimos => Emprestimos.Count(e => !e.Devolvido);
 
        public override string ToString()
        {
            return $"[{Id}] {Nome} | Email: {Email} | Tel: {Telefone} | Empréstimos ativos: {TotalEmprestimos}";
        }

    }
