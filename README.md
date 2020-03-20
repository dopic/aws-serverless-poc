# aws-serverless-framework

Aplicação Serverless utilizando:

- [Serverless Framework](https://serverless.com/)
- [AWS API Gateway - HTTP API](https://docs.aws.amazon.com/apigateway/latest/developerguide/http-api.html)
- [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.1)
- [Lambda AspNetCoreServer](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.1)

**Importante:** A implementação do AspnetCoreServer é manual. Desta forma, é necessário criar a lambda que será usada como Proxy, e a classe de inicialização, **Startup.cs**.

## Deploy

Para publicar, é necessário obter as credenciais de um usuário na AWS, e configurar o [AWS CLI](https://aws.amazon.com/pt/cli/).

Em seguida, com o Serverless Framework instalado, basta executar os comandos abaixo, dentro do projeto api:

- `build.cmd/build.sh`
- `sls deploy`

## Verificar implantação

Ao final do deploy, o Serverless Framework fornece o endpoint da WebAPI criada na AWS. Basta clicar no link, ou obter o endpoint diretamente da AWS.

Existe apenas um controller (Customers), com dois endpoints:
- GET api/customers/{id}: Obtem um cliente
- POST /api/customers: Persiste um cliente

**Importante**: Os dados estão sendo salvos em memória. O tempo de vida da infraestrutura de uma lambda, é de aproximadamente 5 minutos (em estado ocioso). Se o intervalo entre os testes for muito maior do que isso, os dados salvos serão perdidos.