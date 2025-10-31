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
- **Persistência de dados** em banco NoSQL MongoDB
- Versionamento de API (v1 e v2)
- Health Checks para monitoramento da aplicação e banco de dados  
 
---
 
## 🛠️ Tecnologias utilizadas
- [.NET 8](https://dotnet.microsoft.com/)  
- ASP.NET Core Web API  
- MongoDB.Driver (acesso ao banco de dados MongoDB)
- AutoMapper (mapeamento entre entidades e DTOs)  
- Swagger / Swashbuckle (documentação da API)  
- MongoDB (banco de dados NoSQL orientado a documentos)
- Asp.Versioning (versionamento de API)
- AspNetCore.HealthChecks.MongoDb (monitoramento de saúde da aplicação)
 
---
 
## ⚙️ Como rodar o projeto
 
### ✅ Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- **MongoDB** instalado e rodando localmente ou acesso a um cluster MongoDB
  - [Instalação local do MongoDB](https://www.mongodb.com/try/download/community)
  - Ou use [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (cloud gratuito)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou superior (recomendado)  
 
---
 
### 📦 1. Clonar o repositório
```bash
git clone https://github.com/edu1805/CP04-DotNet.git
cd CP04-DotNet
```
 
---
 
### 🔧 2. Configurar o banco de dados MongoDB
No arquivo **`appsettings.json`**, configure a string de conexão do MongoDB:
```json
{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "FleetDatabase"
  }
}
```

**Para MongoDB Atlas (cloud):**
```json
{
  "MongoDB": {
    "ConnectionString": "mongodb+srv://usuario:senha@cluster.mongodb.net/",
    "DatabaseName": "FleetDatabase"
  }
}
```
 
---
 
### 🗄️ 3. Inicializar o MongoDB (local)
Se estiver usando MongoDB local, certifique-se de que o serviço está rodando:

**Windows:**
```bash
net start MongoDB
```

**Linux/Mac:**
```bash
sudo systemctl start mongod
```

**Ou via Docker:**
```bash
docker run -d -p 27017:27017 --name mongodb mongo:latest
```

> ⚠️ **Nota:** Diferente de bancos relacionais, o MongoDB **não requer migrations**. As collections são criadas automaticamente quando você insere o primeiro documento!

---
 
### ▶️ 4. Executar a aplicação
```bash
dotnet run --project API
```
Ou direto pelo **Visual Studio** com `F5`.  
 
---
 
## 📖 Documentação da API
Após rodar a aplicação, acesse a documentação Swagger em:  
👉 [https://localhost:port/swagger](https://localhost:port/swagger)  

A documentação está disponível em duas versões:
- **v1**: Versão inicial da API
- **v2**: Segunda versão da API

---

## 📊 Health Checks
A aplicação possui endpoints de monitoramento de saúde:

| Método | Endpoint         | Descrição                                                      |
|--------|-----------------|----------------------------------------------------------------|
| GET    | /health          | Verifica se a aplicação está rodando (resposta simples)       |
| GET    | /health-details  | Verifica o status detalhado da aplicação e banco MongoDB (JSON) |

**Exemplo de resposta do `/health-details`:**
```json
{
  "status": "Healthy",
  "totalDuration": "00:00:00.0234567",
  "entries": {
    "mongodb-database": {
      "status": "Healthy",
      "duration": "00:00:00.0123456",
      "tags": ["database", "mongodb"]
    }
  }
}
```

---

## 🏗️ Arquitetura do Projeto
```
📦 CP04-DotNet
├── 📁 API                    # Camada de apresentação (Controllers, Extensions)
│   ├── Controllers/          # Endpoints da API
│   ├── Extensions/           # Configurações (Swagger, Versioning, HealthChecks)
│   └── Program.cs           # Configuração principal da aplicação
├── 📁 Application           # Camada de aplicação (Services, DTOs, Interfaces)
│   ├── Services/            # Lógica de negócio
│   ├── DTOs/                # Objetos de transferência de dados
│   ├── Interfaces/          # Contratos dos serviços
│   └── Configs/             # Configurações (Settings, Swagger)
├── 📁 Domain                # Camada de domínio (Entidades, Regras de negócio)
│   ├── Entities/            # Entidades do domínio
│   └── Interfaces/          # Contratos dos repositórios
└── 📁 Infrastructure        # Camada de infraestrutura (MongoDB, Repositories)
    ├── Persistence/         # Contexto e configuração do MongoDB
    │   ├── FleetDbContext.cs    # Contexto do MongoDB
    │   └── FleetRepository.cs   # Implementação do repositório
    └── DependencyInjection.cs   # Configuração de injeção de dependências
```
