# aec-brasil-api

Projeto contruido para atender um processo seletivo:

-> Implementação dos seguintes endpoints:
* Aeroportos
* POST /aeroportos: Este endpoint inclui um novo clima de um aeroporto no banco de dados.
* PUT /aeroportos/{id}: Este endpoint atualiza um clima de um aeroporto baseado em seu ID no banco de dados.
* DELETE /aeroportos/{id}: Este endpoint exclui um clima de um aeroporto baseado em seu ID no banco de dados.
* GET /aeroportos: Este endpoint deve retornar todos os climas de um aeroporto do banco de dados.
* GET /aeroportos/{codigoIcao}: Este endpoint deve retornar todos os climas de um aeroporto baseado em seu CodigoIcao do banco de dados.
* POST /aeroportos/integracao/codigo-icao: Este endpoint busca na integracao com BrasilAPI um clima de um aeroporto baseado em seu CodigoIcao e o inclui no banco de dados.

* Cidades
* POST /cidades: Este endpoint inclui uma nova cidade no banco de dados.
* PUT /cidades/{id}: Este endpoint atualiza uma cidade baseado em seu ID no banco de dados.
* DELETE /cidades/{id}: Este endpoint exclui uma cidade baseado em seu ID no banco de dados.
* GET /cidades: Este endpoint deve retornar todas as cidades com seus respectivos climas do banco de dados.
* GET /cidades/{idIntegracao}: Este endpoint deve retornar todos os climas de um aeroporto baseado em seu IdIntegracao no banco de dados.
* POST /cidades/integracao/id-integracao: Este endpoint busca na integracao com BrasilAPI um clima de uma cidade baseado em seu IdIntegracao e inclui a cidade e o clima no banco de dados.

* Logs
* POST /logs: Este endpoint inclui um novo log no banco de dados.
* GET /logs: Este endpoint deve retornar todos os logs do banco de dados ordenados.

-> Estilos e Padrões de arquitetura utilizados
* Domain-Driven Design (DDD)
* Clean Architecture
* SOLID
* Repository Pattern
* Unit Of Work Pattern
* CQRS Pattern
* Anti Corruption Layer Pattern (Services)
* Documentação com Swagger
* TDD: XUnit
* Dapper (Micro ORM): Leitura de dados críticos - Logs
* EF Core: Escrita e leitura de dados menos críticos

-> DevOps
* CI/CD com GitHub Actions
* Imagem docker da api: Net Core 8.0
* Imagem docker do banco de dados: Sql Server 2019
* Docker Compose
* Hospedagem no Servidor Digital Ocean

-> Bancos de dados
* SQL Server (In-Memory) para simular os testes unitários
* SQL Server (Contêiner docker) para persistência

-> Links úteis
* Pipeline GitHub Actions: https://github.com/samuelfsantos/aec-brasil-api/actions
* Link do projeto já com o deploy realizado na digital ocean: http://104.248.228.214:5020/swagger/index.html

  


