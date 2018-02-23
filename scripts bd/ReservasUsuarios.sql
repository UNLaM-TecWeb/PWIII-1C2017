select * from [dbo].[Reservas]


INSERT INTO [dbo].[Reservas] (IdSede, IdVersion,IdPelicula,FechaHoraInicio,Email,IdTipoDocumento,NumeroDocumento,CantidadEntradas,FechaCarga)
VALUES (1,1,3,'12-05-2017','Briankuz.l',1,33397855,3,'01-08-2017');

select * from [dbo].[Versiones]
select * from [dbo].[Peliculas]


INSERT INTO Peliculas (Nombre, Descripcion,Imagen,IdCalificacion,IdGenero,Duracion,FechaCarga)
VALUES ('Batman','dsaas','dasa','1','1','121','01-08-2017');

select * from [dbo].[Calificaciones]

select * from [dbo].[TiposDocumentos]

INSERT INTO [TiposDocumentos] 
VALUES ('DNI');

INSERT INTO Calificaciones (Nombre)
VALUES ('Muy Buena');

select * from [dbo].[Generos]

INSERT INTO Generos(Nombre)
VALUES ('Accion');

select * from [dbo].[Sedes]

INSERT INTO Sedes(Nombre,Direccion,PrecioGeneral)
VALUES ('DotBaires','Capital',200.0);
       ('NineShopping','Moreno',200.0);
       ('PlazaOeste','Moron',200.0);

	   delete from Sedes
	   where IdSede ='3'

select * from [dbo].[Carteleras]

INSERT INTO Carteleras(IdSede,IdPelicula,HoraInicio,FechaInicio,FechaFin,NumeroSala,IdVersion,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaCarga)
VALUES (2,3,12.00,18-06-12 ,19-06-12 ,1,1,8,2,3,4,5,6,7,'12/05/2018');
       ('NineShopping','Moreno',200.0);
       ('PlazaOeste','Moron',200.0);


Insert into Usuarios (NombreUsuario,Password)
values ('Admin','123')



