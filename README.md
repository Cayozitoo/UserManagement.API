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

### 🔧 Pré-requisitos
- .NET SDK (compatível com o TargetFramework do projeto)
- SQL Server LocalDB (Windows)

---

### 1️⃣ Restaurar dependências
```bash
dotnet restore
```

### 2️⃣ Aplicar migrations
```bash
dotnet ef database update
```

### 3️⃣ Configurar JWT (variável de ambiente)
No Windows (PowerShell):
```bash
setx Jwt__Key "SUA_CHAVE_SEGURA_COM_32+_CARACTERES"
```

### 4️⃣ Executar a aplicação
```bash
dotnet run
```

### 5️⃣ Acessar o Swagger
```bash
[dotnet restore](http://localhost:5288/swagger)
```
## 🔐 Fluxo de Autenticação

- Criar usuário (POST /api/Users)
- Realizar login (POST /api/Auth/login)
- Copiar o token JWT
- Autorizar no Swagger usando:
```nginx
Bearer SEU_TOKEN_AQUI
```
- Acessar endpoints protegidos

---
 
## 📌 Observações

- Endpoints sensíveis protegidos com [Authorize]
- Endpoint de cadastro público usando [AllowAnonymous]
- Projeto desenvolvido para fins de estudo e portfólio

---

## 👤 Autor

- Cayo Fellipe
- Fascinado por tecnologia
- Engenheiro de software quase formado

