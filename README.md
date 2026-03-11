Projeto de Conclusão de Curso Faculdade IMPACTA – Sistema de Gestão de Produtos

Descrição do Projeto:

Este projeto é um sistema de gestão de produtos desenvolvido em .NET 8.0, utilizando Blazor para o front-end e API REST em .NET para comunicação com o banco de dados (SQL Server).
O sistema permite gerenciar produtos, incluindo operações de criação, leitura, atualização e exclusão (CRUD), com a lógica de acesso a dados organizada em bibliotecas de classes separadas para facilitar manutenção e reutilização.
________________________________________
Arquitetura do Projeto

O projeto é composto por 4 subprojetos:

1.	ProjetoEstoque - Front-end (Blazor)
  o	Responsável pela interface do usuário.
  o	Interage com a API para realizar operações no banco de dados.

2.	ProjetoEstoqueAPI - (.NET API)
  o	Expõe endpoints para que o front-end execute operações CRUD.
  o	Faz a comunicação com as bibliotecas de classes que lidam com os dados.

3.	Biblioteca de classes - DBHandler
  o	Responsável pela conexão com o banco de dados.
  o	Executa consultas e retorna resultados.

4.	Biblioteca de classes - DBServices
  o	Responsável por enviar comandos ao banco de dados.
  o	Faz o tratamento e validação dos dados antes e depois das operações.
________________________________________
Tecnologias Utilizadas:

•	.NET 8.0
•	Blazor (front-end)
•	API REST .NET
•	C#
•	SQL Server
________________________________________
Estrutura de Endpoints da API
Categoria

•	GET /api/Categoria/BuscarCategoria
Retorna todas as categorias cadastradas.
Produto

•	GET /api/Produto/BuscarUmProduto?id={id}
Retorna um produto específico baseado no ID informado na query string.

•	POST /api/Produto/BuscarProdutos
Busca produtos de acordo com os filtros enviados no body em formato JSON:
 {  
    "id_Produto": 0,  
    "codigo_Produto": 0,  
    "nome_Produto": "string",  
    "valor_Produto": 0,  
    "id_Categoria": 0  
 }  

•	POST /api/Produto/InserirProduto
Insere um novo produto usando o body JSON:
 {  
    "codigo_Produto": 0,  
    "nome_Produto": "string",  
    "valor_Produto": 0,  
  	"id_Categoria": 0  
 }  

•	POST /api/Produto/AlterarProduto  
  	Altera um produto existente usando o body JSON:
 {  
  	"id_Produto": 0,  
  	"codigo_Produto": 0,  
  	"nome_Produto": "string",  
  	"valor_Produto": 0,  
  	"id_Categoria": 0  
 }

•	DELETE /api/Produto/DeletarProduto?id={id}  
  	Deleta um produto com base no ID informado na query string.
________________________________________
Como Rodar o Projeto:

1.	Clonar o repositório
2.	git clone https://github.com/GuilhermeMBrito/ProjetoEstoque
3.	Abrir a solução no Visual Studio 2022 ou superior
4.	Configurar a string de conexão no DBHandler
o	Certifique-se de configurar o banco de dados no arquivo de configuração do projeto API.
5.	Rodar a API
o	Definir o projeto API como startup e iniciar.
6.	Rodar o Front-end Blazor
o	Definir o projeto Blazor como startup e iniciar.
o	O front-end se conectará automaticamente à API.
________________________________________
Observações
•	O front-end depende da API para todas as operações de banco de dados.
•	As bibliotecas DBHandler e DBServices podem ser reutilizadas em outros projetos .NET que precisem de acesso estruturado ao banco de dados.
•	A API está preparada para manipulação básica de erros e retornos padronizados.
