# aec-brasil-api

Projeto contruido para atender um processo seletivo:

-> Implementação dos seguintes endpoints:
* POST /climas: Este endpoint inclui um novo clima.
* PUT /climas/{id}: Este endpoint atualiza um clima baseado em seu ID.
* DELETE /climas/{id}: Este endpoint exclui um clima baseado em seu ID.
* GET /climas: Este endpoint deve retornar todos os climas no banco de dados.
* GET /climas/{id}: Este endpoint deve retornar um único clima baseada em seu ID.
* GET /climas/cidade/{id}: Este endpoint deve retornar todos os climas de uma determinada cidade baseada em seu ID.
* GET /climas/search/{keyword}: Este endpoint deve retornar todos os climas que contêm a palavra-chave fornecida.

-> Estilos e Padrões de arquitetura utilizados
* Domain-Driven Design (DDD)
* Clean Architecture
* SOLID
* Repository Pattern
* Unit Of Work Pattern
* CQRS Pattern
* Anti Corruption Layer Pattern (Services)
* Documentação com Swagger

-> DevOps
* CI/CD com GitHub Actions
* Imagem docker (Net Core 8.0)
* Docker Compose
* Hospedagem no Servidor Digital Ocean

-> Banco de dados
* NoSQL: Redis para cache
* Relacional: SQL Server para persistência

-> Links úteis
* Pipeline GitHub Actions: https://github.com/samuelfsantos/aec-brasil-api/actions
* Link do projeto já com o deploy realizado na digital ocean: http://104.248.228.214:2020/swagger/index.html
  


