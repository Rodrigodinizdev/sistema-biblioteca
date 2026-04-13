namespace teste_biblioteca.Models;

public class Usuario
{
    public Usuario(string nome, string telefone, string email)
    {
        Id = ++_contadorId;
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
    private static int _contadorId = 0;
    public int Id { get; }
    public string Nome { get; }
    public string Telefone { get; }
    public string Email { get; }

    public override string ToString()
    {
        return $"Nome: {Nome} | Telefone: {Telefone} | Email: {Email}";
    }
}
