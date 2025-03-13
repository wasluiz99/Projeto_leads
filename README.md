# Sistema de Gerenciamento de Leads e Matrículas

![Badge em Desenvolvimento](https://img.shields.io/badge/Status-Desenvolvimento%20Ativo-brightgreen)

Projeto desenvolvido para gestão de leads educacionais, matrículas de alunos e criação de turmas, utilizando Entity Framework Core com SQL Server.

## ✨ Funcionalidades Principais

- **Cadastro de Leads**
  - Interface intuitiva para registro de novos leads

- **Consulta de Leads**
  - Busca avançada com filtros personalizados
  - Visualização detalhada das informações

- **Matrícula de Alunos**
  - Processo completo de matrícula
  - Vinculação a turmas existentes

- **Gestão de Turmas**
  - Criação e configuração de novas turmas

## 🛠 Tecnologias Utilizadas

- **Backend**
  - Entity Framework Core 8.0
  - SQL Server 2022
  - ASP.NET Core 8.0
  - Repositorios

- **Frontend**
  - HTML5/CSS3
  - JavaScript ES6+
  - Bootstrap 5.2
  - jQuery 3.6

## 🚀 Como Executar o Projeto

### Pré-requisitos
- .NET SDK 7.0
- SQL Server 2019+
- Visual Studio 2022 ou VSCode

### Configuração Inicial
1. Clone o repositório:
```bash
git clone https://github.com/wasluiz99/Projeto_leads.git

📦 Estrutura do Banco de Dados
 Diagrama do Banco de Dados

Principais entidades:

Lead (Id,, Nome, Telefone, Email, CursoInteresse)

Curso(Id, Descricao)

Aluno (Id, CodigoMatricula, Nome, Telefone, Email, CursoId, TurmaId, DataCadastro)

Turma (ID, Descricao, CursoId)
