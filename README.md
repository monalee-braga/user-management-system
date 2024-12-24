# User Management System

Um sistema de gerenciamento de usuários com backend em C# (.NET) e frontend em Vue.js. Este projeto inclui autenticação via JWT, suporte a níveis de permissão (admin e standard), e funcionalidades de CRUD para usuários.

## Funcionalidades

- Exibir lista de usuários cadastrados
- Tela para cadastrar um novo usuário
- Tela para editar um usuário
- Autenticação com JWT
- Busca de usuários por nome e email
- Níveis de acesso:
  - **Admin**: Gerencia todos os usuários
  - **Standard**: Pode visualizar e editar apenas seu perfil

## Tecnologias Utilizadas

### Backend

- **Linguagem**: C# (.NET 7/8)
- **Banco de Dados**: SQL Server
- **Autenticação**: JWT

### Frontend

- **Framework**: Vue.js

## Pré-requisitos

Certifique-se de ter os seguintes softwares instalados:

- **Git**
- **Node.js** (para o frontend)
- **.NET SDK** (7 ou superior)
- **SQL Server** (ou Docker para rodar o banco)
- **Docker** (opcional, para ambiente de desenvolvimento)

## Como Rodar o Projeto

### Clonar o Repositório

```bash
git clone https://github.com/monalee-braga/user-management-system.git
cd user-management-system
```
