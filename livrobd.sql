CREATE DATABASE livrobd;

USE livrobd;


CREATE TABLE Livro(
	codigo int primary key auto_increment,
    nomelivro char (50),
    nomeautor char (50),
    genero char (50),
    qtpaginas int,
    editora char (50),
    anopublicacao int
    );
     
    SELECT * FROM  Livro
    
    
    
    