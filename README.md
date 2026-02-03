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


