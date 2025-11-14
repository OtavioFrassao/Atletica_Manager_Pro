Fluxo Completo do Sistema - Atlética Manager Pro
1. Tela de Login
- Usuário insere login e senha.
- Sistema valida no MySQL.
- Se válido → vai para Agenda.
- Se inválido → mensagem de erro.
2. Tela Agenda (Home)
- Primeira tela após o login.
- Lista de eventos ordenados pela data (mais próximos primeiro).
- Cada evento aparece como um card com título + data.
- Ao clicar em um evento → abre a tela Evento.
- Barra lateral presente com navegação geral.
3. Tela Evento
- Mostra imagem, título, descrição e data do evento selecionado.
- Tela somente para visualização.
- Barra lateral ainda disponível.
4. Cadastrar Evento – Parte 1 (Formulário Inicial)
- Usuário preenche título, descrição, data e seleciona imagem.
- Ao clicar em Continuar, não salva ainda.
- Avança para a pré-visualização.
5. Cadastrar Evento – Parte 2 (Pré-visualização)
- Mostra exatamente como o evento ficará (imagem, título, descrição, data).
- Botões:
• Salvar → grava no banco (INSERT MySQL) e retorna à Agenda.
• Cancelar → volta para edição.
Fluxo Resumido
LOGIN → AGENDA → (clique em card) EVENTO
AGENDA → CADASTRAR EVENTO (Parte 1) → PRÉ-VISUALIZAÇÃO → SALVAR → AGENDA
Banco de Dados
Tabela eventos:
- id INT PK AI
- titulo VARCHAR
- descricao TEXT
- imagem BLOB ou caminho VARCHAR
- data DATE
Telas Envolvidas
FormLogin
FormAgenda
FormEvento
FormCadastroEvento1
FormCadastroEvento2
Resumo Final
Esse PDF descreve o fluxo completo do sistema Atlética Manager Pro conforme o design
apresentado.
