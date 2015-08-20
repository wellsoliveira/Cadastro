create database [dbTeste];
use dbTeste;
create table tb_cadastro
(
	id_empresa int primary key not null identity,
	nm_empresa varchar(500),
	ds_endereco varchar(500),
	nm_contato varchar(500)
);