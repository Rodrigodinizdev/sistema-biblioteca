# sistema-biblioteca

Gente vou passar para voces uma atividade de Poo que o Tales tinha me passado semana passada e Danyel me informou que era pra liberar para voces 

Projeto: Sistema de Biblioteca "Leia Mais"
Contexto
O sistema deve gerenciar Livros, Usuários e Empréstimos. Como ainda não há banco de dados, os dados devem ser mantidos em List<T> na memória durante a execução.

Regras de Negócio (O "Desafio")
Status de Disponibilidade:

Um livro só pode ser emprestado se o seu status for Disponível.

Ao realizar um empréstimo, o status do livro deve mudar automaticamente para Emprestado.

Limite de Empréstimos por Usuário:

Um Usuário não pode ter mais de 3 livros emprestados simultaneamente.

Se ele tentar pegar o 4º livro, o sistema deve exibir uma mensagem de erro e impedir a operação.

Regra de Devolução e Multa (Simulada):

Ao devolver um livro, o usuário deve informar quantos dias ficou com ele.

Se o prazo (ex: 7 dias) for excedido, o sistema deve calcular uma multa de R$ 2,00 por dia de atraso e exibir o valor na tela.

O livro só volta a ficar Disponível após a confirmação da devolução.

Restrição de Exclusão:

Um Livro nunca pode ser excluído do sistema se ele estiver com o status Emprestado.

Um Usuário só pode ser removido se não possuir nenhum livro pendente de devolução.
tenta fazer essa regra ai
