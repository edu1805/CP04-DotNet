# 🚘 Sistema de Gestão de Frotas
 
A aplicação é um sistema de gestão de frotas, desenvolvida em **ASP.NET Core Web API**, que permite gerenciar frotas de veículos, motoristas e seus relacionamentos.  
 
O projeto está organizado em camadas seguindo o **DDD (Domain-Driven Design)**, com separação clara entre **Application**, **Domain** e **Infrastructure**.
 
---
 
## 👥 Integrantes
- **Eduardo do Nascimento Barriviera** - RM555309  
- **Thiago Lima de Freitas** - RM556795  
 
---
 
## 🚀 Funcionalidades 
- **API RESTful** com endpoints organizados  
- **Documentação Swagger** integrada  
- **Acesso e persistência** de dados em banco Oracle via EF Core  
 
---
 
## 🛠️ Tecnologias utilizadas
- [.NET 8](https://dotnet.microsoft.com/)  
- ASP.NET Core Web API  
- Entity Framework Core + `Oracle.EntityFrameworkCore`  
- AutoMapper (mapeamento entre entidades e DTOs)  
- Swagger / Swashbuckle (documentação da API)  
- Oracle Database (banco de dados relacional)  
 
---
 
## ⚙️ Como rodar o projeto
 
### ✅ Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- Banco de dados **Oracle** acessível  
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou superior (recomendado)  
 
---
 
### 📦 1. Clonar o repositório
```bash
git clone https://github.com/edu1805/CP04-DotNet.git
cd CP04-DotNet
```
 
---
 
### 🔧 2. Configurar o banco de dados Oracle
No arquivo **`appsettings.json`**, configure a sua string de conexão:
 
```json
"ConnectionStrings": {
  "Oracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=SEU_ID;Password=SUA_PASSWORD"
}
```
 
---
 
### 🧱 3. Gerar as Migrations (se necessário)
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate -p Infrastructure -s API
dotnet ef database update -p Infrastructure -s API
```
 
---
 
### ▶️ 4. Executar a aplicação
```bash
dotnet run
```
Ou direto pelo **Visual Studio** com `F5`.  
 
---
 
## 📖 Documentação da API
Após rodar a aplicação, acesse a documentação Swagger em:  
👉 [https://localhost:port/swagger](https://localhost:port/swagger)  
