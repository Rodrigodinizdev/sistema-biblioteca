using biblioteca.Service;
using biblioteca.Models;


// List<Usuario> usuarios = new List<Usuario>();
// List<Livro> livros = new List<Livro>();
// EmprestimoService emprestimo = new EmprestimoService();

//  Usuario usuario1 = new Usuario("Rodrigo", "rodrigo@example.com", "123456789");
// usuarios.Add(usuario1);

// Livro livro1 = new Livro ("abcde", "pessoa", 2006);
// livros.Add(livro1);

// System.Console.WriteLine($"{livro1.Autor}, {usuario1}");

// emprestimo.RealizarEmprestimo(usuario1, livro1);

// emprestimo.DevolverLivro(usuario1.Emprestimos[0], 2);
 EmprestimoService service = new EmprestimoService();
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
                    CadastrarLivro(service);
                    break;

                case "2":
                    CadastrarUsuario(service);
                    break;

                case "3":
                    RealizarEmprestimo(service);
                    break;

                case "4":
                    DevolverLivro(service);
                    break;

                case "5":
                    ListarLivros(service);
                    break;

                case "6":
                    ListarUsuarios(service);
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

static void CadastrarLivro(EmprestimoService service)
{
    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    Console.Write("Autor: ");
    string autor = Console.ReadLine();

    Console.Write("Ano: ");
    int ano = int.Parse(Console.ReadLine());

    service.Livros.Add(new Livro(titulo, autor, ano));

    Console.WriteLine("Livro cadastrado!");
}

static void CadastrarUsuario(EmprestimoService service)
{
    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    Console.Write("Telefone: ");
    string telefone = Console.ReadLine();

    service.Usuarios.Add(new Usuario(nome, email, telefone));

    Console.WriteLine("Usuário cadastrado!");
}
static void RealizarEmprestimo(EmprestimoService service)
{
    if (service.Usuarios.Count == 0 || service.Livros.Count == 0)
    {
        Console.WriteLine("Cadastre pelo menos um usuário e um livro.");
        return;
    }

    Console.WriteLine("Usuários:");
    foreach (var u in service.Usuarios)
        Console.WriteLine(u);

    Console.Write("\nID do usuário: ");
    int idUser = int.Parse(Console.ReadLine());

    Console.WriteLine("\nLivros:");
    foreach (var l in service.Livros)
        Console.WriteLine($"[{l.Id}] {l.Titulo} - {(l.Disponivel ? "Disponível" : "Emprestado")}");

    Console.Write("\nID do livro: ");
    int idLivro = int.Parse(Console.ReadLine());

    var usuario = service.Usuarios.FirstOrDefault(u => u.Id == idUser);
    var livro = service.Livros.FirstOrDefault(l => l.Id == idLivro);

    if (usuario == null || livro == null)
    {
        Console.WriteLine("Usuário ou livro não encontrado!");
        return;
    }

    service.RealizarEmprestimo(usuario, livro);
}
static void DevolverLivro(EmprestimoService service)
{
    Console.Write("ID do usuário: ");
    int idUser = int.Parse(Console.ReadLine());

    var usuario = service.Usuarios.FirstOrDefault(u => u.Id == idUser);

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
static void ListarLivros(EmprestimoService service)
{
    foreach (var l in service.Livros)
    {
        Console.WriteLine($"[{l.Id}] {l.Titulo} - {(l.Disponivel ? "Disponível" : "Emprestado")}");
    }
}
static void ListarUsuarios(EmprestimoService service)
{
    foreach (var u in service.Usuarios)
    {
        Console.WriteLine(u);
    }
}