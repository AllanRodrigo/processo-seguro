# Processo Seguros

## Descrição

Este repositório contém a implementação de uma aplicação de cálculo de seguros que utiliza C# (.NET) para o backend e Angular para o frontendarmazenando os dados em um banco de dados SQL Server.

## Estrutura do Projeto
```
processo-seguro/
├── JsonServer/
│   └── db.json
│   └── Dockerfile
├── SegurosAllanAPI/
│   └── SegurosAllanAPI/
│       └── Dockerfile
├── seguro-allan-app/
│   └── Dockerfile
│   └── nginx.conf
│   └── package.json
│   └── src/
└── docker-compose.yml
```

- `JsonServer`: Contém um Json Server para simular a chamada de Consulta Cpfs
- `SegurosAllanAPI`: Contém a API em .NET
- `seguro-allan-app`: Contém a aplicação Angular
- `processo-seguro`: Contém o arquivo `docker-compose.yml` e `README`

## Pré-requisitos

- .NET SDK 8.0
- Node.js
- Angular CLI
- Docker

## Configuração do Ambiente

0. Configurar a Connection String
    **Antes de executar a aplicação, é necessário configurar a connection string no arquivo appsettings.json do backend. Substitua IP_MAQUINA pelo IP da máquina onde o Docker está sendo executado. A connection string deve ficar no seguinte formato:**
 ```
"ConnectionStrings": {
  "DefaultConnection": "Server=IP_MAQUINA,1433;Database=WeatherForecastDb;User Id=sa;Password=SuperPassword@23;"
}
```

 **Alterar também no mesmo arquivo, o item ConnectionJsonServer**
 ```
"ConnectionStrings": {
  "ConnectionJsonServer": "http://IP_MAQUINA:3000"
}
```

1. Clonar o Repositório:
**Clone o repositório em sua máquina local:**
   ```sh
   git clone https://github.com/AllanRodrigo/processo-seguro.git
   cd processo-seguro
   ```

2. Configurar e Executar o ambiente com Docker
**No diretório raiz do projeto, execute os seguintes comandos para iniciar os containers**
   ```sh
   docker-compose up --build
   ```

Isso irá:

- Construir e iniciar um container para o SQL Server.
- Construir e iniciar um container para a API .NET Core.
- Construir e iniciar um container para a API JSoon Server.
- Construir e iniciar um container para a aplicação Angular.

4. Uso da Collection Postman
**Deixei junto ao arquvos a collection utilizada para as chamadas das APIs. Será importante utilizar a chamada para a inclusão de novos seguros antes de exibir os dados na aplicação.**

5. Uso da Aplicação
**Abra o navegador e acesse http://localhost:4200. A interface exibe apenas a lista das médias de seguros.**

6. Notas Finais
- Certifique-se de que as portas 1433 (SQL Server), 5000 (API) e 4200 (Frontend) estão disponíveis em sua máquina.
- Para parar os containers, use docker-compose down.

Este README foi criado para fornecer todas as informações necessárias para configurar e executar a aplicação de forma fácil e rápida.
