CREATE TABLE Produto (
  id_produto INT NOT NULL identity,
  codigo_produto int not null,
  nome_produto VARCHAR(100) NOT NULL,  
  valor_produto money not null,
  id_categoria int not null,
   deletado bit,
   constraint I_PRIMARY_id_produto PRIMARY KEY (id_produto),  
  constraint II_FOREIGN_id_categoria FOREIGN KEY (id_categoria) REFERENCES categoria(id_categoria)
);

insert into produto (codigo_produto, nome_produto, valor_produto, id_categoria) Values
(102031, 'Detergente', 1.50 , 1),
(102031, 'Sabão em pó', 25.00 , 1),
(102031, 'Desinfetante', 5.00 , 1)