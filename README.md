# UserManagement.API 🚀

API REST para gerenciamento de usuários desenvolvida em **ASP.NET Core**, com autenticação **JWT**, persistência com **Entity Framework Core** e documentação via **Swagger**.

Projeto criado com foco em **boas práticas**, **segurança** e **padrões utilizados em ambientes profissionais**.

---

## 🧠 Funcionalidades

- Cadastro de usuários
- Autenticação com JWT (Login)
- Proteção de endpoints com `[Authorize]`
- Hash de senha com BCrypt
- CRUD de usuários
- Migrations com Entity Framework Core
- Documentação interativa com Swagger

---

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server (LocalDB)**
- **JWT Bearer Authentication**
- **BCrypt**
- **Swagger / OpenAPI**
- **Git & GitHub**

---

## 🏗️ Arquitetura do Projeto

UserManagement.API
│
├── Controllers
├── Application
│ └── DTOs
├── Domain
│ └── Entities
├── Infrastructure
│ └── Data
└── Program.cs


Separação clara de responsabilidades seguindo boas práticas de backend.

---

## ▶️ Como executar o projeto

### Pré-requisitos
- .NET SDK (compatível com o TargetFramework do projeto)
- SQL Server LocalDB (Windows)

---

### 1️⃣ Restaurar dependências
```bash
dotnet restore

2️⃣ Restaurar dependências
dotnet restore

3️⃣ Aplicar as migrations
dotnet ef database update


Isso criará automaticamente o banco de dados e as tabelas necessárias.

4️⃣ Configurar a chave JWT (variável de ambiente)

Por segurança, a chave JWT não fica versionada no repositório.

No Windows (PowerShell):

setx Jwt__Key "SUA_CHAVE_SEGURA_COM_32_OU_MAIS_CARACTERES"


O .NET lê variáveis de ambiente no formato Jwt__Key para mapear Jwt:Key.

5️⃣ Executar a aplicação
dotnet run

6️⃣ Acessar o Swagger
http://localhost:5288/swagger

🔐 Fluxo de Autenticação

Criar um usuário
POST /api/Users

Realizar login
POST /api/Auth/login

Copiar o token JWT retornado

No Swagger, clicar em Authorize e informar:

Bearer SEU_TOKEN_AQUI


Acessar endpoints protegidos

🔒 Controle de Acesso

Endpoints sensíveis protegidos com [Authorize]

Endpoint de cadastro (POST /api/Users) liberado com [AllowAnonymous]

Tokens JWT validados por:

Issuer

Audience

Assinatura

Tempo de expiração

📌 Boas Práticas Aplicadas

Não armazenamento de senha em texto puro

Uso de DTOs para entrada e saída de dados

Separação de responsabilidades

Configuração segura de autenticação

Exclusão de arquivos sensíveis via .gitignore

📈 Próximos Passos (Evoluções Planejadas)

Service Layer (Services + Interfaces)

Autorização por Roles (Admin / User)

Refresh Token

Logs estruturados com Serilog

Testes unitários

Dockerização e deploy

👤 Autor

Cayo Fellipe
Estudante de Engenharia de Software
Backend Developer (.NET)
Apaixonado por arquitetura, segurança e desenvolvimento de APIs


