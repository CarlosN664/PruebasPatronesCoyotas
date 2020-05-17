create database Test;

use Test;

create table Cliente(
ID int not null auto_increment,
Nombre varchar(255),
Direccion varchar(255),
Telefono varchar(15),
Email varchar(255),
DomicilioFiscal varchar(255),
primary key (ID)
);

insert into Cliente (Nombre,Direccion,Telefono,Email,DomicilioFiscal) 
values('Carlos Najera','Direccion 123 Tamarindo','6643894578','tamarindo@gmail.com','Domicilio Fiscal xD Calle xd');

select * from Cliente;

Delimiter //
create procedure sp_buscarClientes (IN id int,IN nombre VARCHAR(255),in tel varchar(15))
begin 
if(id is null and nombre is null and tel is null) then
		select * from Cliente;
else
select * from Cliente where Cliente.Id = id or 
								Cliente.Nombre like concat('%',nombre,'%') or 
								Cliente.Telefono like concat('%',tel,'%');
end if;
end //
Delimiter ; 

Delimiter //
create procedure sp_agregarCliente 
(IN nombre VARCHAR(255),
IN direccion VARCHAR(255),
IN telefono VARCHAR(15),
IN email VARCHAR(255),
in domiciliofiscal varchar(255))
begin 
insert into Cliente (Nombre,Direccion,Telefono,Email,DomicilioFiscal) 
values(nombre,direccion,telefono,email,domiciliofiscal);
end //
Delimiter ; 

Delimiter //
create procedure sp_actualizarCliente 
(
IN id int,
IN nombre VARCHAR(255),
IN direccion VARCHAR(255),
IN telefono VARCHAR(15),
IN email VARCHAR(255),
in domiciliofiscal varchar(255))
begin 
update Cliente 
set Cliente.Nombre = nombre , Cliente.Direccion = direccion , Cliente.Telefono = telefono, 
Cliente.Email = email, Cliente.DomicilioFiscal = domiciliofiscal
where Cliente.Id = id;
end //
Delimiter ; 

Delimiter //
create procedure sp_eliminarCliente (IN id int)
begin 
delete from Cliente where Cliente.Id = id;
end //
Delimiter ; 

/*
drop procedure sp_agregarCliente;
drop procedure sp_buscarClientes;
*/
call sp_agregarCliente('Carlos Antonio','dir as fdjlkj asdf ','664 789 12 35','email@gmail.com','dom fiscal xdddd');
call sp_buscarClientes(null,null,null);
call sp_buscarClientes(1,null,null);
call sp_buscarClientes(null,'Carlos',null);
call sp_actualizarCliente(2,'Carlos Antonio','dir as fdjlkj asdf ','664 789 12 35','email@gmail.com','dom fiscal xdddd');
call sp_eliminarCliente(3);



