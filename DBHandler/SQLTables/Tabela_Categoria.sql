create table Categoria (
 id_categoria INT NOT NULL identity,
 nome_categoria VARCHAR(100) NOT NULL, 
 deletado bit,
  constraint I_PRIMARY_id_categoria PRIMARY KEY (id_categoria)
);
insert into Categoria (nome_categoria) values 
('Limpeza'),
('Mercearia'),
('Higiene'),
('Frios'),
('Carnes'),
('Utilitarios');