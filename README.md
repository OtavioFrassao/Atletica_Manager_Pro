# 🏆 Atlética Manager Pro

Sistema completo de gerenciamento de atlética universitária desenvolvido em .NET 8.0 com Windows Forms, aplicando arquitetura DDD (Domain-Driven Design) e padrão MVP (Model-View-Presenter).

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Arquitetura](#arquitetura)
- [Tecnologias](#tecnologias)
- [Funcionalidades](#funcionalidades)
- [Setup Inicial](#setup-inicial)
- [Estrutura do Banco de Dados](#estrutura-do-banco-de-dados)
- [Como Usar](#como-usar)
- [Módulos do Sistema](#módulos-do-sistema)
- [Convenções Git e Commits](#convenções-git-e-commits)

## 🎯 Sobre o Projeto

O **Atlética Manager Pro** é um sistema desktop para gerenciar todas as atividades de uma atlética universitária, incluindo:

- 👥 **Gestão de Membros**: Cadastro completo de membros com cargos, cursos e contatos
- 🏅 **Cargos**: Definição de funções e responsabilidades
- 🧹 **Cronograma de Limpeza**: Agendamento e acompanhamento de tarefas
- 📅 **Eventos**: Planejamento e gerenciamento de eventos da atlética

## 🏗️ Arquitetura

O projeto segue os princípios de **Domain-Driven Design (DDD)** com quatro camadas bem definidas:

```
Atletica_Manager_Pro/
│
├── Atletica.Domain/           # Camada de Domínio
│   ├── Entities/              # Entidades com regras de negócio
│   │   ├── Cargo.cs
│   │   ├── Membro.cs
│   │   ├── TarefaLimpeza.cs
│   │   └── Evento.cs
│   └── Repositories/          # Interfaces de repositório
│
├── Atletica.Application/      # Camada de Aplicação
│   ├── DTOs/                  # Data Transfer Objects
│   ├── Services/              # Serviços de caso de uso
│   │   ├── CargoService.cs
│   │   ├── MembroService.cs
│   │   ├── TarefaLimpezaService.cs
│   │   └── EventoService.cs
│   └── Mappings/
│
├── Atletica.Infrastructure/   # Camada de Infraestrutura
│   ├── Data/
│   │   └── AtleticaDbContext.cs
│   ├── Repositories/          # Implementações concretas
│   └── Migrations/            # Migrations do EF Core
│
└── Atletica.Presentation/     # Camada de Apresentação (MVP)
    ├── Views/                 # Formulários Windows Forms
    ├── Presenters/            # Lógica de apresentação
    └── Config/                # Dependency Injection
```

### Padrões Aplicados

- ✅ **DDD** - Domain-Driven Design com entidades ricas
- ✅ **MVP** - Model-View-Presenter para desacoplamento da UI
- ✅ **Repository Pattern** - Abstração de acesso a dados
- ✅ **Dependency Injection** - Inversão de controle e injeção de dependências
- ✅ **SOLID** - Princípios de design orientado a objetos

## 🛠️ Tecnologias

- **Framework**: .NET 8.0
- **UI**: Windows Forms
- **ORM**: Entity Framework Core 8.0.0
- **Banco de Dados**: MySQL 8.0
- **Provider MySQL**: Pomelo.EntityFrameworkCore.MySql 8.0.0
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection 8.0.0
- **Containerização**: Docker (MySQL)

## ✨ Funcionalidades

### 📊 Gestão de Cargos

- Criar, editar e excluir cargos
- Definir nome e descrição de cada cargo
- Visualização em lista completa

### 👥 Gestão de Membros

- Cadastro completo de membros (nome, curso, matrícula, turma)
- Associação a cargos
- Contato com máscara de telefone: (00) 00000-0000
- Registro de data de entrada
- Listagem com filtros

### 🧹 Cronograma de Limpeza

- Agendamento de tarefas de limpeza
- Atribuição de responsáveis (membros)
- Status de conclusão (pendente/concluída)
- **Visualização dupla**: Lista e Calendário
- **Calendário interativo**:
  - Navegação por mês (anterior/próximo)
  - Cores por status: Verde (concluído), Vermelho (pendente), Amarelo (hoje)
  - Clique no dia para visualizar/adicionar tarefas
  - Exibe responsável e horário em cada célula
- Validação: não permite tarefas duplicadas na mesma data

### 📅 Eventos

- Cadastro de eventos com título, descrição, local e datas
- Definição de membro responsável
- Período do evento (data início e fim)
- **Visualização dupla**: Lista e Calendário
- **Calendário de eventos**:
  - Exibição de título e local
  - Fonte maior (8F Bold) para melhor leitura
  - Indicador de múltiplos eventos no mesmo dia
  - Clique para visualizar detalhes ou adicionar novos eventos

## 🚀 Setup Inicial

### Pré-requisitos

- .NET 8.0 SDK instalado
- MySQL 8.0 (pode usar Docker)
- MySQL Workbench (opcional, para gerenciar o banco)

### 1. Clonar e Restaurar Pacotes

```powershell
cd "c:\Users\ze\Desktop\FACULDADe\OITAVO E DECIMO SEM\otavio\Atletica_Manager_Pro"
dotnet restore
```

### 2. Configurar MySQL com Docker (Recomendado)

#### Primeira vez - Criar e iniciar o container:

```powershell
# Baixar a imagem do MySQL 8.0
docker pull mysql:8.0

# Criar e iniciar o container (comando multi-linha para melhor legibilidade)
docker run --name atletica-mysql `
  -e MYSQL_ROOT_PASSWORD=root `
  -e MYSQL_DATABASE=atletica_db `
  -p 3306:3306 `
  -d mysql:8.0

# OU comando inline (uma linha só)
docker run --name atletica-mysql -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=atletica_db -p 3306:3306 -d mysql:8.0

# Verificar se está rodando
docker ps
```

#### Comandos para gerenciar o container:

```powershell
# Verificar containers em execução
docker ps

# Verificar todos os containers (incluindo parados)
docker ps -a

# Parar o container
docker stop atletica-mysql

# Iniciar o container (se já foi criado)
docker start atletica-mysql

# Reiniciar o container
docker restart atletica-mysql

# Ver logs do container
docker logs atletica-mysql

# Remover o container (se precisar recriar)
docker rm atletica-mysql

# Acessar o MySQL dentro do container
docker exec -it atletica-mysql mysql -u root -p
# Senha: root
```

#### Verificar se o MySQL está pronto:

```powershell
# Aguardar até o MySQL estar pronto (pode levar alguns segundos)
docker logs atletica-mysql

# Quando ver esta mensagem, está pronto:
# "ready for connections. Version: '8.0.x'"
```

**Nota**: Se você já tem MySQL instalado localmente na porta 3306, ou já possui o container criado, use `docker start atletica-mysql` para iniciar o container existente.

### 3. Configurar Connection String

Edite `Atletica.Presentation\Config\DependencyInjection.cs`:

```csharp
var connectionString = "Server=localhost;Database=atletica_db;User=root;Password=root;";
```

### 4. Criar Banco de Dados via Migrations

```powershell
# Instalar ferramentas EF Core (apenas uma vez)
dotnet tool install --global dotnet-ef

# Verificar migrations existentes
cd Atletica.Infrastructure
dotnet ef migrations list --startup-project ..\Atletica.Presentation\Atletica.Presentation.csproj

# Aplicar migrations ao banco
dotnet ef database update --startup-project ..\Atletica.Presentation\Atletica.Presentation.csproj
```

### 5. Compilar e Executar

```powershell
cd ..
dotnet build

cd Atletica.Presentation
dotnet run
```

## 📊 Estrutura do Banco de Dados

### Tabelas e Relacionamentos

```sql
Cargos
├── Id (PK)
├── Nome
└── Descricao

Membros
├── Id (PK)
├── Nome
├── Curso
├── Matricula
├── Turma
├── Contato
├── DataEntrada
└── CargoId (FK → Cargos)

TarefasLimpeza
├── Id (PK)
├── Data
├── Descricao
├── Concluido
└── MembroResponsavelId (FK → Membros)

Eventos
├── Id (PK)
├── Titulo
├── Descricao
├── DataInicio
├── DataFim (nullable)
├── Local (nullable)
└── MembroResponsavelId (nullable FK → Membros)
```

### Migrations Aplicadas

1. **InitialCreate**: Criação inicial de Cargos, Membros e TarefasLimpeza
2. **AddTurmaToMembros**: Adição do campo Turma à tabela Membros
3. **AddEventos**: Criação da tabela Eventos

### Dados Iniciais (Seeds)

O sistema cria automaticamente os seguintes cargos:

- Presidente
- Vice-Presidente
- Tesoureiro
- Secretário
- Diretor de Eventos
- Membro

## 📖 Como Usar

### Menu Principal

Ao iniciar o sistema, você verá o menu principal com botões para:

- **Cargos**: Gerenciar funções da atlética
- **Membros**: Cadastrar e gerenciar membros
- **Limpezas**: Cronograma de limpeza
- **Eventos**: Planejamento de eventos

### Gerenciar Cargos

1. Clique em **Cargos** no menu principal
2. Use os botões:
   - **Novo**: Criar novo cargo
   - **Editar**: Modificar cargo selecionado
   - **Excluir**: Remover cargo (valida se há membros associados)

### Gerenciar Membros

1. Clique em **Membros** no menu principal
2. Funcionalidades disponíveis:
   - Adicionar novo membro com dados completos
   - Editar informações de membros existentes
   - Visualizar lista completa
   - Campo de contato com máscara automática: (00) 00000-0000

### Cronograma de Limpeza

1. Clique em **Limpezas** no menu principal
2. Escolha a visualização:
   - **Lista**: Visualização em grade com todas as tarefas
   - **Calendário**: Visualização mensal interativa
3. No calendário:
   - Use as setas para navegar entre meses
   - Clique em um dia para ver tarefas ou adicionar nova
   - Cores indicam status: Verde (concluído), Vermelho (pendente)
4. Marque tarefas como concluídas diretamente da lista

### Eventos

1. Clique em **Eventos** no menu principal
2. Alterne entre Lista e Calendário
3. Cadastre eventos com:
   - Título e descrição
   - Data de início e fim (opcional)
   - Local do evento (opcional)
   - Responsável (membro)
4. No calendário:
   - Eventos aparecem com título em negrito
   - Local é exibido abaixo do título
   - Clique no dia para adicionar ou ver detalhes

## 🔧 Comandos Úteis

### Verificar Instalação

```powershell
# Versão do .NET
dotnet --version

# Listar pacotes instalados
dotnet list package

# Verificar projetos na solution
dotnet sln list
```

### Migrations

```powershell
# Criar nova migration
dotnet ef migrations add NomeDaMigration --startup-project ..\Atletica.Presentation\Atletica.Presentation.csproj

# Aplicar migrations
dotnet ef database update --startup-project ..\Atletica.Presentation\Atletica.Presentation.csproj

# Reverter última migration
dotnet ef migrations remove --startup-project ..\Atletica.Presentation\Atletica.Presentation.csproj

# Listar migrations
dotnet ef migrations list --startup-project ..\Atletica.Presentation\Atletica.Presentation.csproj
```

### Limpeza e Rebuild

```powershell
# Limpar build
dotnet clean

# Restaurar pacotes
dotnet restore

# Rebuild completo
dotnet clean
dotnet restore
dotnet build
```

## 🐛 Resolução de Problemas Comuns

### Erro: "Cannot connect to MySQL"

1. Verifique se o MySQL está rodando: `docker ps` ou `services.msc`
2. Confirme usuário/senha na connection string
3. Teste conexão: `mysql -u root -p`

### Erro: "dotnet ef not found"

```powershell
dotnet tool install --global dotnet-ef
```

### Erro: "The type or namespace name 'MySql' could not be found"

```powershell
cd Atletica.Infrastructure
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0
```

### Calendário trava ao clicar

- Já corrigido! Todos os event handlers agora usam `async`/`await`
- Se ocorrer novamente, verifique se há algum `.Wait()` nos presenters

### Status não atualiza ao editar

- Já corrigido! O método `AtualizarDados` agora aceita o parâmetro `Concluido`
- Certifique-se de que o checkbox `chkConcluido` está marcado/desmarcado antes de salvar

## 📚 Módulos do Sistema

### 1. Domínio (Atletica.Domain)

**Entidades principais:**

```csharp
// Cargo.cs - Funções na atlética
public class Cargo
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }

    public void AtualizarDados(string nome, string descricao)
}

// Membro.cs - Membros associados
public class Membro
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Curso { get; private set; }
    public string Turma { get; private set; }
    public int CargoId { get; private set; }

    public void AtualizarDados(...)
}

// TarefaLimpeza.cs - Tarefas do cronograma
public class TarefaLimpeza
{
    public int Id { get; private set; }
    public DateTime Data { get; private set; }
    public bool Concluido { get; private set; }

    public void MarcarComoConcluido()
    public void MarcarComoPendente()
}

// Evento.cs - Eventos da atlética
public class Evento
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime? DataFim { get; private set; }
    public string Local { get; private set; }
}
```

### 2. Aplicação (Atletica.Application)

**Serviços disponíveis:**

- `CargoService`: CRUD completo de cargos
- `MembroService`: CRUD completo de membros
- `TarefaLimpezaService`: Gerenciamento de limpezas + marcação de status
- `EventoService`: CRUD completo de eventos

**Padrão de DTOs:**

- `XxxDto`: Para leitura/exibição
- `CreateXxxDto`: Para criação (sem Id)
- `UpdateXxxDto`: Para atualização (com Id)

### 3. Infraestrutura (Atletica.Infrastructure)

**Repositórios implementados:**

- `CargoRepository`: Acesso a dados de cargos
- `MembroRepository`: Acesso a dados de membros com cargos
- `TarefaLimpezaRepository`: Acesso a tarefas com membros responsáveis
- `EventoRepository`: Acesso a eventos com relacionamentos

**DbContext:**

```csharp
public class AtleticaDbContext : DbContext
{
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Membro> Membros { get; set; }
    public DbSet<TarefaLimpeza> TarefasLimpeza { get; set; }
    public DbSet<Evento> Eventos { get; set; }
}
```

### 4. Apresentação (Atletica.Presentation)

**Padrão MVP:**

- **Views** (Formulários): Apenas UI, sem lógica
- **Presenters**: Toda a lógica de apresentação
- **Services**: Injetados via DI nos presenters

**Formulários principais:**

- `FormMenuPrincipal`: Menu inicial
- `FormListaCargos`, `FormCadastroCargo`: Gestão de cargos
- `FormListaMembros`, `FormCadastroMembro`: Gestão de membros
- `FormListaLimpezas`, `FormAgendarLimpeza`: Cronograma
- `FormListaEventos`, `FormCadastroEvento`: Eventos

## 🎓 Conceitos Acadêmicos Aplicados

Este projeto foi desenvolvido como projeto acadêmico aplicando:

- **Engenharia de Software**: Arquitetura em camadas, separação de responsabilidades
- **Padrões de Projeto**: DDD, MVP, Repository, Dependency Injection
- **Boas Práticas**: SOLID, Clean Code, validações de domínio
- **Persistência**: ORM (Entity Framework Core), Migrations
- **Banco de Dados**: Modelagem relacional, chaves estrangeiras, integridade referencial

---

**Atlética Manager Pro** - Sistema completo de gestão para atléticas universitárias 🏆
