namespace biblioteca.Models;

public class Emprestimo
{
    public Emprestimo(Livro livro, Usuario usuario)
    {
        Id = ++ContadorId;
        Livro = livro;
        Usuario = usuario;
        DataEmprestimo = DateTime.Now;
        Devolvido = false;
    }
    private static int PrazoDias = 7;
    private static decimal MultaPorDia = 2.00m;
    public static int ContadorId = 0;
    public int Id { get; private set; }
    public Livro Livro { get; private set; }
    public Usuario Usuario { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucao { get; set; }
    public bool Devolvido { get;  set; }
    public decimal MultaGerada { get; private set; }


    public decimal CalcularMulta(int diasComLivro)
    {
        int diasAtraso = diasComLivro - PrazoDias;
        if (diasAtraso <= 0) return 0;
        MultaGerada = diasAtraso * MultaPorDia;
        return MultaGerada;

    }
    public override string ToString()
    {
        string status = Devolvido? $"Devolvido em {DataDevolucao:dd/MM/yyyy}" : "Em aberto";
        string multa = MultaGerada > 0? $" | Multa: R$ {MultaGerada:F2}": "";
        return $"[{Id}] Livro: \"{Livro.Titulo}\" | Usuário: {Usuario.Nome} | Empréstimo: {DataEmprestimo:dd/MM/yyyy} | {status}{multa}";
    }
}


