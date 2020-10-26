# Projeto

Backend-test é uma **API RESTFul** utilizada como um dos critérios de avaliação para back-end developer do grupo rovema e feita por Ariel Veras.

Desenvolvi o projeto em asp .net core Web Api. Utilizei para trabalhar o banco de dados Sqlq Server que é um banco relacional da microsoft (https://www.microsoft.com/pt-br/sql-server/sql-server-2017). A maior parte do tempo foi fazendo a api e tentando implementar o Docker, porém não consegui e em padronizar os commits.

# Tecnologias

 - [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/) - Linguagem de programação
    interpretada utilizada no desenvolvimento do aplicativo 
 - [Asp Net Core](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-3.1) - Framework utilizado para criar
   aplicações web
 - [Sql Server](https://docs.microsoft.com/pt-br/sql/?view=sql-server-ver15) - Banco de dados utilizado
   para  persistir os dados processados pela API
 - [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) - Geração de migrations,ORM   
 - [VisualStudio Code](https://code.visualstudio.com/) - Editor de texto
   utilizado para codificar a aplicação
 - [Sql Server](https://docs.microsoft.com/pt-br/sql/?view=sql-server-ver15) - Aplicativo utilizado para criação
   do diagrama de entidade-relacionamento
 - [GitFlow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)
 - Padrão de branches utilizado para administrar projetos de maneira clara no git.
 - [Swagger](https://swagger.io/) - Ferramenta para design de API's.

## Como rodar

abra o projeto com o visual studio code e na aba terminal  escolha 'new terminal' ou o atalho ctrl + shift + '
1.  dotnet ef migrations add nomeMigracao (criacao da migration)
2.  uma pasta com o nome Migrations será criada
3.  dotnet ef database update (subir o schema do banco de dados)

para subir a aplicação

1. dotnet restore (para baixar todos os pacotes)
2. dotnet run

acessar o design swagger api e testá-la a api
 
http://localhost:5000/swagger
https://localhost:5001/swagger
