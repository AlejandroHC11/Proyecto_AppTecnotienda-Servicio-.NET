create database BDTecnotienda
go

use BDTecnotienda

create table UserTable(
idUser int primary key identity(1,1),
userData varchar(255),
passwordData varchar(255)
)
go

create table Product(
idProduct int primary key identity(1,1),
nombre varchar(255),
img varchar(255),
precio varchar(255),
stock varchar(255)
)
go

select * from UserTable
go

select * from Product
go