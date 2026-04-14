using teste_biblioteca.DTOs;
using teste_biblioteca.Interfaces.Services;

namespace teste_biblioteca.UI;

public class BibliotecaUI(ILivroService livroService, IUsuarioService usuarioService, IEmprestimoService emprestimoService)
{
    private readonly ILivroService _livroService = livroService;
    private readonly IUsuarioService _usuarioService = usuarioService;
    private readonly IEmprestimoService _emprestimoService = emprestimoService;

    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA BIBLIOTECA ===");
            Console.WriteLine("1 - Cadastrar livro");
            Console.WriteLine("2 - Cadastrar Usuário");
            Console.WriteLine("3 - Realizar Empréstimo ");
            Console.WriteLine("4 - Devolver Livro ");
            Console.WriteLine("5 - Listar Livros");
            Console.WriteLine("6 - Listar Usuários");
            Console.WriteLine("7 - Listar Empréstimos");
            Console.WriteLine("0 - Sair");


            Console.Write("\nEscolha: ");
            string opcao = Console.ReadLine();

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    CadastrarLivro();
                    break;

                case "2":
                    CadastrarUsuario();
                    break;

                case "3":
                    RealizarEmprestimo();
                    break;

                case "4":
                    DevolverLivro();
                    break;

                case "5":
                    _livroService.ListarLivros();
                    break;

                case "6":
                    _usuarioService.ListarUsuarios();
                    break;

                case "7":
                    _emprestimoService.ListarEmprestimos();
                    break;

                case "0":
                    Console.WriteLine("Saindo...");
                    return;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla...");
            Console.ReadKey();
        }
    }

    private void CadastrarLivro()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRAR LIVRO ===\n");

        Console.Write("Digite o nome do Livro: ");
        string nomeLivro = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nomeLivro))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nomeLivro = Console.ReadLine();
        }

        Console.Write("Digite o Autor do Livro: ");
        string nomeAutor = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nomeAutor))
        {
            Console.WriteLine("nome do autor não pode ser vazio");
            nomeAutor = Console.ReadLine();
        }

        Console.Write("Digite o ano de publicação: ");
        int ano;
        while (!int.TryParse(Console.ReadLine(), out ano) || ano <= 0 || ano > DateTime.Now.Year)
            Console.WriteLine("Ano de publicação não pode ser negativo e nem maior que o ano atual");
            
        

        _livroService.AdicionarLivro(new LivroDto(nomeLivro, nomeAutor, ano));
    }

    private void CadastrarUsuario()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRO DE USUÁRIO ===");

        Console.Write("Digite o nome do Usuário: ");
        string nomeUsuário = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nomeUsuário))
        {
            Console.WriteLine("Nome não pode ser vazio");
            nomeUsuário = Console.ReadLine();
        }

        Console.Write("Digite o email do usuário: ");
        string email = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
        {
            Console.WriteLine("Email não pode ser vazio e deve conter '@' e '.'");
            email = Console.ReadLine();
        }

        Console.Write("Digite o Telefone do usuário: ");
        string telefone = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 11)
        {
            Console.WriteLine("telefone não pode ser vazio e deve conter 11 dígitos");
            telefone = Console.ReadLine();
        }

        _usuarioService.CadastrarUsuario(new UsuarioDTO(nomeUsuário, telefone, email));
    }

    private void RealizarEmprestimo()
    {
        Console.Clear();
        Console.WriteLine("=== REALIZAR EMPRÉSTIMO ===\n");

        _usuarioService.ListarUsuarios();

        int idUsuario;
        Console.Write("Digite o Id do usuário: ");
        while (!int.TryParse(Console.ReadLine(), out idUsuario) || idUsuario <= 0)
            Console.WriteLine("Id do usuário não pode ser menor ou igual a zero");
            
        _livroService.ListarLivros();

        int idLivro;
        Console.Write("Digite o Id do Livro: ");
        while (!int.TryParse(Console.ReadLine(), out idLivro) || idLivro <= 0)
            Console.WriteLine("Id do Livro não pode ser menor ou igual a zero");
            
        _emprestimoService.AdicionarEmprestimo(new EmprestimoDTO(idLivro, idUsuario));
    }

    private void DevolverLivro()
    {
        Console.Clear();
        Console.WriteLine("=== DEVOLVER EMPRÉSTIMO ===\n");

        _emprestimoService.ListarEmprestimos();

        int idEmprestimo;
        Console.Write("Digite o Id do Empréstimo: ");
        while (!int.TryParse(Console.ReadLine(), out idEmprestimo) || idEmprestimo <= 0)
            Console.WriteLine("Id do Empréstimo não pode ser menor ou igual a zero");
            
        int diasComLivro;
        Console.Write("Digite quantos dias o livro ficou emprestado: ");
        while (!int.TryParse(Console.ReadLine(), out diasComLivro) || diasComLivro <= 0)
            Console.WriteLine("A quantidade de dias não pode ser menor ou igual a zero");
            
        _emprestimoService.Devolver(idEmprestimo, diasComLivro);
    }

}
