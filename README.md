# 🚀 Nome do Projeto

---

## 📦 Instalação

### Rodando localmente (Visual Studio)

As **Secrets** necessárias serão disponibilizadas em um arquivo `.txt` na plataforma da **FIAP**.

> ⚠️ **Pré-requisitos:** É necessário ter **PostgreSQL**, **RabbitMQ** e **Prometheus** instalados localmente, ou redirecioná-los via tunnel.  
> As secrets foram configuradas com tunnel SSH apontando para uma cloud privada.

### Arquivos de configuração (`.yaml`)

Os arquivos de deploy da aplicação estão disponíveis no repositório abaixo — solicite acesso:

🔗 [FIAP.FCG.Documentos](https://github.com/FelipeTrosi/FIAP.FCG.Documentos)

---

## 🔐 Autenticação

A aplicação utiliza **JWT Token**. Todos os endpoints são protegidos conforme documentação.

### Usuário gestor padrão

Para acessar todos os endpoints, utilize as credenciais abaixo:

**`POST /User/Login`**

```json
{
  "email": "admin@fiap.com.br",
  "password": "4Dm1n@Fiap"
}
```

**Response `HTTP 200`**

```json
{
  "token": "<jwt_token>"
}
```

---

## 🧩 Microsserviços

| Serviço | Repositório |
|--------|-------------|
| Campaign | [FIAP.Hackathon.OES.Campaign](https://github.com/FelipeTrosi/FIAP.Hackathon.OES.Campaign) |
| User | [FIAP.Hackaton.OES.User](https://github.com/FelipeTrosi/FIAP.Hackaton.OES.User) |
| Worker | [FIAP.Hackathon.OES.Worker](https://github.com/FelipeTrosi/FIAP.Hackathon.OES.Worker) |

---

## 👥 Grupo 10

| Nome | Discord |
|------|---------|
| Felipe da Silva Fonseca Trosi | `FelipeT` — `felipet9311` |
