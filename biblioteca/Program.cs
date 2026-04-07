using biblioteca.Service;
using biblioteca.Models;
using biblioteca.Enums;

EmprestimoService Emprestimoservice = new EmprestimoService();
LivroService livroService = new LivroService();
UsuarioService usuarioService = new UsuarioService();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
    Console.WriteLine("1 - Cadastrar Livro");
    Console.WriteLine("2 - Cadastrar Usuário");
    Console.WriteLine("3 - Realizar Empréstimo");
    Console.WriteLine("4 - Devolver Livro");
    Console.WriteLine("5 - Listar Livros");
    Console.WriteLine("6 - Listar Usuários");
    Console.WriteLine("0 - Sair");

    Console.Write("\nEscolha: ");
    string opcao = Console.ReadLine();

    Console.Clear();

    switch (opcao)
    {
        case "1":
            CadastrarLivro(livroService);
            break;

        case "2":
            CadastrarUsuario(usuarioService);
            break;

        case "3":
            RealizarEmprestimo(Emprestimoservice, livroService, usuarioService);
            break;

        case "4":
            DevolverLivro(Emprestimoservice, usuarioService, livroService);
            break;

        case "5":
            ListarLivros(livroService);
            break;

        case "6":
            ListarUsuarios(usuarioService);
            break;

        case "0":
            Console.WriteLine("Saindo...");
            return;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla...");
    Console.ReadKey();
}

static void CadastrarLivro(LivroService service)
{
    Console.Write("Título: ");
    string titulo = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(titulo))
    {
        Console.WriteLine("ERRO! O título do livro não pode ser vazio. Tente novamente.");
        Console.Write("Título: ");
        titulo = Console.ReadLine();
    }

    Console.Write("Autor: ");
    string autor = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(autor))
    {
        Console.WriteLine("ERRO! O autor do livro não pode ser vazio. Tente novamente.");
        Console.Write("Autor: ");
        autor = Console.ReadLine();
    }

    Console.Write("Ano: ");
    string anoInput = Console.ReadLine();
    while (!int.TryParse(anoInput, out int ano) || ano <= 0 || DateTime.Now.Year < ano)
    {
        Console.WriteLine("ERRO! O ano de publicação deve ser um número inteiro positivo e menor ou igual ao ano atual. Tente novamente.");
        Console.Write("Ano: ");
        anoInput = Console.ReadLine();
    }

    service.CadastrarLivro(titulo, autor, int.Parse(anoInput));
    Console.WriteLine("Livro cadastrado!");
}

static void CadastrarUsuario(UsuarioService service)
{
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("ERRO! O nome do usuário não pode ser vazio. Tente novamente.");
        Console.Write("Nome: ");
        nome = Console.ReadLine();
    }

    Console.Write("Email: ");
    string email = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(email))
    {
        Console.WriteLine("ERRO! O email do usuário não pode ser vazio. Tente novamente.");
        Console.Write("Email: ");
        email = Console.ReadLine();
    }

    Console.Write("Telefone: ");
    string telefone = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 11)
    {
        Console.WriteLine("ERRO! O telefone do usuário não pode ser vazio e deve ter 11 caracteres. Tente novamente.");
        Console.Write("Telefone: ");
        telefone = Console.ReadLine();
    }

    service.CadastrarUsuario(nome, email, telefone);

    Console.WriteLine("Usuário cadastrado!");
}

static void RealizarEmprestimo(EmprestimoService service, LivroService livroService, UsuarioService usuarioService)
{
    if (usuarioService.usuarios.Count == 0 || livroService.livros.Count == 0)
    {
        Console.WriteLine("Cadastre pelo menos um usuário e um livro.");
        return;
    }

    Console.WriteLine("Usuários:");
    foreach (var usuarios in usuarioService.usuarios)
        Console.WriteLine(usuarios);

    int idUsuario;

    Console.Write("\nID do usuário: ");
    while (!int.TryParse(Console.ReadLine(), out idUsuario))
    {
        Console.WriteLine("ID inválido.");
        Console.Write("\nID do usuário: ");
    }

    Console.WriteLine("\nLivros:");
    foreach (var livros in livroService.livros)
        Console.WriteLine($"[{livros.Id}] {livros.Titulo} - {(livros.StatusLivro == StatusLivroEnum.Disponível ? "Disponível" : "Emprestado")}");

    int idLivro;

    Console.Write("\nID do livro: ");
    while (!int.TryParse(Console.ReadLine(), out idLivro))
    {
        Console.WriteLine("ID inválido.");
        Console.Write("\nID do livro: ");
    }

    var usuario = usuarioService.usuarios.FirstOrDefault(u => u.Id == idUsuario);
    var livro = livroService.livros.FirstOrDefault(l => l.Id == idLivro);

    if (usuario == null || livro == null)
    {
        Console.WriteLine("Usuário ou livro não encontrado!");
        return;
    }

    service.RealizarEmprestimo(usuario, livro);
}

static void DevolverLivro(EmprestimoService service, UsuarioService usuarioService, LivroService livroService)
{
    Console.Write("ID do usuário: ");
    int idUser = int.Parse(Console.ReadLine());

    var usuario = usuarioService.usuarios.FirstOrDefault(u => u.Id == idUser);

    if (usuario == null)
    {
        Console.WriteLine("Usuário não encontrado!");
        return;
    }

    var emprestimos = usuario.Emprestimos.Where(e => !e.Devolvido).ToList();

    if (emprestimos.Count == 0)
    {
        Console.WriteLine("Nenhum empréstimo ativo.");
        return;
    }

    Console.WriteLine("\nEmpréstimos:");
    foreach (var e in emprestimos)
    {
        Console.WriteLine($"ID: {e.Id} | Livro: {e.Livro.Titulo}");
    }

    Console.Write("\nID do empréstimo: ");
    int idEmp = int.Parse(Console.ReadLine());

    var emprestimo = emprestimos.FirstOrDefault(e => e.Id == idEmp);

    if (emprestimo == null)
    {
        Console.WriteLine("Empréstimo não encontrado!");
        return;
    }

    Console.Write("Quantos dias ficou com o livro? ");
    int dias = int.Parse(Console.ReadLine());

    service.DevolverLivro(emprestimo, dias);
}

static void ListarLivros(LivroService service)
{
    foreach (var l in service.livros)
    {
        Console.WriteLine($"[{l.Id}] {l.Titulo} - {(l.StatusLivro == StatusLivroEnum.Disponível ? "Disponível" : "Emprestado")}");
    }
}
static void ListarUsuarios(UsuarioService service)
{
    foreach (var u in service.usuarios)
    {
        Console.WriteLine(u);
    }
}