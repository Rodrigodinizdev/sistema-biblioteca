using teste_biblioteca.Notification;
using teste_biblioteca.Repositories;
using teste_biblioteca.Services;
using teste_biblioteca.UI;

var notificacao = new Notificacao();

var livroRepository = new LivroRepository();
var usuarioRepository = new UsuarioRepository();
var emprestimoRepository = new EmprestimoRepository();

var livroService = new LivroService(livroRepository, notificacao);
var usuarioService = new UsuarioService(usuarioRepository, notificacao);
var emprestimoService = new EmprestimoService(emprestimoRepository, usuarioRepository, livroRepository, notificacao);

var ui = new BibliotecaUI(livroService, usuarioService, emprestimoService);

ui.Menu();