namespace teste_biblioteca.Helpers;

public class Notification
{
    private List<string> _erros = [];

    public void AdicionarErros(string mensagem) => _erros.Add(mensagem);
    public bool TemErros() => _erros.Count > 0;
    public List<string> GetErros() => _erros;

    public void Limpar() => _erros.Clear();

    public void ExibirErros()
    {
        foreach (var erro in _erros)
            Console.WriteLine($"ERRO: {erro}");

        Limpar();
    }
}
