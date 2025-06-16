# 🚀 Teste CredutPay

API desenvolvida em .NET 8 utilizando arquitetura Clean Architecture com CQRS + MediatR, autenticação via JWT e persistência em banco de dados PostgreSQL. O projeto permite gerenciamento de usuários e suas carteiras digitais, com funcionalidades de saldo e transferência entre usuários.

---

## Informações Adicionais:
-Foi criado uma api de Autenticação apenas para fins de como ficaria a implementação, implementei a autenticação apenas na Api de adicionar saldo a carteira(AddBalance) onde implementei um data annotations [Authorize], para ser autenticado basta gerar um token na Api de Auth e passar como parametro na chamada via parametro Authorization Bearer Token.
-Por conta de serem 2 dias de desenvolvimento não consegui implementar os testes e linter.
-Usei uma abordagem de cqrs e MediatR pensando no desacoplamento dos serviços e na escalabilidade do projeto.
-A parte de autenticação acabou ficando mal distribuido pelo pouco tempo também de desenvolvimento.

---

## 📌 Funcionalidades

- 🔐 Autenticação com JWT Bearer
- 👤 Cadastro de usuários
- 💰 Consulta de saldo da carteira de um usuário
- ➕ Adição de saldo à carteira
- 🔁 Transferência de saldo entre usuários
- 📜 Listagem de transferências de um usuário, com filtro opcional por data

---

## 🛠️ Tecnologias Utilizadas

- .NET 8
- CQRS com MediatR
- Autenticação JWT
- PostgreSQL
- Docker + Docker Compose

---

## 📦 Estrutura do Projeto

```bash
/TesteCredutPay
├── WebApi/               # API principal (camada de apresentação)
├── Application/          # Camada de aplicação (commands, queries, handlers)
├── Domain/               # Entidades e regras de domínio
├── Infrastructure/       # Acesso a dados, autenticação, serviços externos
├── docker-compose.yml    # Orquestração com PostgreSQL
├── README.md             # Este arquivo

---

## Populando a tabela de usuários
- Possuimos 3 tabelas, deixarei a seguir o script para popular a tabela de usuarios, através dela conseguirá criar uma carteira aos usuarios e criar transferencias


INSERT INTO users (id, name, phone, login, password, dt_birth) VALUES
('a1111111-1111-1111-1111-111111111111', 'Alice Fernandes', '11987654321', 'alicef', 'senha123', '1990-05-15'),
('b2222222-2222-2222-2222-222222222222', 'Bruno Souza',     '21998765432', 'brunos', '12345678', '1985-08-22'),
('c3333333-3333-3333-3333-333333333333', 'Carla Dias',      '31991234567', 'carlad', 'qwerty12', '1992-03-10'),
('d4444444-4444-4444-4444-444444444444', 'Daniel Lima',     '41999887766', 'daniell', 'abc12345', '1988-11-30');


