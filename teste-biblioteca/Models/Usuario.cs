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
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }

    public override string ToString()
    {
        return $"Nome: {Nome} | Telefone: {Telefone} | Email: {Email}";
    }
}
