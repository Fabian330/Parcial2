
create database TiendaUH

use TiendaUH

create table Cajeros
(
	codigoCajero int identity(1,1),
	nombreCajero nvarchar(50) not null,
	apellidoCajero nvarchar(50) not null,
	constraint PK_codigoCajero primary key(codigoCajero)
)

create table MaquinasRegistradoras
(
	codigoMaquina int identity(1,1),
	piso int,
	constraint PK_codigoMaquina primary key(codigoMaquina)
)

create table Productos
(
	codigoProducto int identity(5,5),
	nombreProducto nvarchar(100) not null,
	precio float,
	constraint PK_codigoProducto primary key(codigoProducto),
)

create table Venta
(
	codigoVenta int identity(1000,5),
	cajero int,
	maquina int,
	producto int,
	--Fecha date constraint def_fecha default getdate(),
	constraint PK_codigoVenta primary key(codigoVenta),
	constraint FK_cajero foreign key(cajero) references Cajeros(codigoCajero),
	constraint FK_maquina foreign key(maquina) references MaquinasRegistradoras(codigoMaquina),
	constraint FK_producto foreign key(producto) references Productos(codigoProducto)
)

insert into Cajeros values ('Adrian', 'Hernandez'), ('Maria', 'Solis')

insert into Productos values ('Arroz', '3000'), ('Atun', '1500'), ('Tortillas', '1000')

insert into MaquinasRegistradoras values ('2'), ('1')

insert into Venta values (1, 1, 5)
insert into Venta values (2, 2, 10)
insert into Venta values (1, 1, 15)
insert into Venta values (1, 1, 15)

update Productos set nombreProducto = 'Frijoles', precio = '2000' where codigoProducto = '10'

select v.codigoVenta, c.codigoCajero, c.nombreCajero, p.codigoProducto, p.nombreProducto, p.precio, m.codigoMaquina, m.piso
from Venta v
inner join Cajeros c on c.codigoCajero = v.cajero
inner join Productos p on p.codigoProducto = v.producto
inner join MaquinasRegistradoras m on m.codigoMaquina = v.maquina

select * from Cajeros
select * from MaquinasRegistradoras
select * from Productos
select * from Venta