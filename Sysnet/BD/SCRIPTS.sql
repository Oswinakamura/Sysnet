CREATE DATABASE Sysnet

CREATE TABLE Persona 
(
  id INT IDENTITY (1,1),
  identificacion VARCHAR(20) CONSTRAINT UQ_identificacion UNIQUE NOT NULL,
  tipoIdentificacion VARCHAR(50) NOT NULL,
  primerNombre VARCHAR (50) NOT NULL,
  segundoNombre VARCHAR (50),
  primerApellido VARCHAR (50) NOT NULL,
  segundoApellido VARCHAR (50),
  direccion VARCHAR (50),
  telefono VARCHAR (50) NOT NULL,
  email VARCHAR (50) NOT NULL,
  ocupacion VARCHAR (50),
  fechaNacimiento DATE NOT NULL,
  foto VARCHAR (50),
  CONSTRAINT PK1 PRIMARY KEY(id)
)
GO
Create procedure Sp_Crud(
@id int,
@identificacion varchar(50),
@tipoIdentificacion varchar(50),
@primerNombre varchar(50),
@segundoNombre varchar(50),
@primerApellido varchar(50),
@segundoApellido varchar(50),
@direccion varchar(50),
@telefono varchar(50),
@email varchar(50),
@ocupacion varchar(50),
@fechaNacimiento date,
@foto varchar(50),
@option varchar(50)
)

As
Begin
if(@option='Insert')
Begin
Insert into Persona (identificacion,tipoIdentificacion,primerNombre,segundoNombre,primerApellido,segundoApellido,
direccion,telefono,email,ocupacion,fechaNacimiento,foto) 
Values(@identificacion,@tipoIdentificacion,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,@direccion,
@telefono,@email,@ocupacion,@fechaNacimiento,@foto)
End
if(@option='Update')
Begin
Update Persona Set identificacion=@identificacion,tipoIdentificacion=@tipoIdentificacion,primerNombre=@primerNombre,segundoNombre=@segundoNombre,
primerApellido=@primerApellido,segundoApellido=@segundoApellido,direccion=@direccion,telefono=@telefono,
email=@email,ocupacion=@ocupacion,fechaNacimiento=@fechaNacimiento,foto=@foto Where id=@id
End
if(@option='Delete')
Begin
Delete From Persona Where id=@id
End
if(@option='Getperid')
Begin
Select * From Persona Where id=@id
End
Select * From Persona
End