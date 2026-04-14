using teste_biblioteca.Enums;
namespace teste_biblioteca.Notification;

public class Notificacao
{
    internal class Mensagem
    {
        public Mensagem(string texto, TipoNotificacaoEnum tipo)
        {
            Texto = texto;
            Tipo = tipo;
        }
        public string Texto { get; }
        public TipoNotificacaoEnum Tipo { get; }
    }

    private List<Mensagem> _mensagens = [];

    public void AdicionarErro(string mensagem) => _mensagens.Add(new Mensagem(mensagem, TipoNotificacaoEnum.Erro));
    public void AdicionarSucesso(string mensagem) => _mensagens.Add(new Mensagem(mensagem, TipoNotificacaoEnum.Sucesso));
    public bool TemErros() => _mensagens.Any(m => m.Tipo == TipoNotificacaoEnum.Erro);
    public void Limpar() => _mensagens.Clear();

    public void ExibirMensagens()
    {
        foreach (var mensagem in _mensagens)
            if(mensagem.Tipo == TipoNotificacaoEnum.Erro)
                Console.WriteLine($"{mensagem.Texto}");
            else 
            Console.WriteLine($"{mensagem.Texto}");

        Limpar();
    }
}
