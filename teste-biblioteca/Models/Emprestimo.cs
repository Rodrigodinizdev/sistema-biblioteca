namespace teste_biblioteca.Models;

public class Emprestimo
{
    public Emprestimo(Livro livro, Usuario usuario)
    {
        Id = ++_contadorId;
        Livro = livro;
        Usuario = usuario;
        DataEmprestimo = DateTime.Now;
    }
    private static int _contadorId = 0;
    public int Id { get; }
    public Livro Livro { get; }
    public Usuario Usuario { get; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime? DataDevolucao { get; private set; }
    private static int PrazoDias = 7;
    private static decimal MultaPorDia = 2.00m;
    public bool Devolvido { get; private set; }
    public decimal MultaGerada { get; private set; }

    public decimal CalcularMulta(int diasComLivro)
    {
        int diasAtraso = diasComLivro - PrazoDias;
        if (diasAtraso <= 0)
            return 0;

        MultaGerada = diasAtraso * MultaPorDia;
        return MultaGerada;
    }

    public override string ToString()
    {
        string status = Devolvido? $"Devolvido em {DataDevolucao: dd/MM/yyyy}" : "Em aberto";
        string Multa = MultaGerada > 0? $"| Multa: {MultaGerada:C}" : "" ;

        return $"Id: [{Id}] | Livro: {Livro.Nome} | Usuário: {Usuario.Nome} | Empréstimo: {DataEmprestimo} | {status} {Multa}";
    }
}
