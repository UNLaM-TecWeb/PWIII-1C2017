use [20171C_TP] 

/* Inserts para el correcto funcionamiento */
 
/* Generos */
insert into dbo.Generos (Nombre) values
('Terror'),
('Thriller'),
('Accion'),
('Comedia'),
('Comedia Romantica'),
('Drama'),
('Ciencia Ficcion'),
('Fantasia'),
('Romance'),
('Musical');

/* Calificaciones */
insert into dbo.Calificaciones (Nombre) values
('ATP'),
('Mayores de 13'),
('Mayores de 13 con reservas'),
('Mayores de 16'),
('Mayores de 16 con reservas');

/* Sedes */
insert into dbo.Sedes (Nombre, Direccion, PrecioGeneral) values
('Shopping DOT', 'Vedia 3626 Dot Shopping', 175),
('Alto Palermo','Antonio Beruti 3399', 170),
('Liniers Shopping','Coronel Ramón L. Falcón 7145',150),
('Cinema Devoto','Quevedo 3365', 175),
('Abasto Shopping','Av. Corrientes 3247', 180),
('Unicenter','Paraná 3475', 175),
('Norcenter','Colectora Panamericana 3750', 190);

/* Peliculas */
insert into dbo.Peliculas (Nombre, Descripcion, Imagen, IdCalificacion, IdGenero, Duracion, FechaCarga) values
('BayWatch','Adaptación cinematográfica de la serie de televisión que narrará la historia del esforzado socorrista Mitch Buchannon (Johnson) y su choque de personalidades con un socorrista novato (Efron).','baywatch.png',3,4,90,GETDATE()),
('Mujer Maravilla','La Mujer Maravilla es la Princesa Diana de las amazonas. Tomó su nombre de la diosa de la caza. Fue formada en un principio por su madre en una figura de arcilla. Se le concedió vida por la súplica de su madre (Hipólita) a la diosa Afrodita.','mujermaravilla.png',2,7,88,GETDATE()),
('La Momia','Tom Cruise encabeza la espectacular, y completamente nueva versión cinematográfica de la leyenda que ha fascinado a distintas culturas en todo el mundo desde los comienzos de la civilización: La Momia.','lamomia.png',3,7,90,GETDATE()),
('Guardianes de la Galaxia 2','Ambientada en el nuevo contexto sonoro de “Awesome Mixtape #2”, GUARDIANES DE LA GALAXIA VOL. 2, de Marvel, continúa las aventuras del equipo en su travesía por los confines del cosmos.','guardianesgalaxia.png',2,8,85,GETDATE()),
('Atomica','Un thriller de acción cargado de adrenalina. En una ciudad llena de traidores y dividida por una revolución, una bomba de tiempo está a punto de estallar mientras ella persigue a uno de los asesinos más peligrosos del MI6.','atomica.png',5,3,90,GETDATE()),
('Kingsman: El circulo dorado','Kingsman es una agencia de inteligencia internacional independiente que opera con la máxima discreción con el objetivo final de mantener el mundo seguro. Nuestros héroes se enfrentan a un nuevo desafío.','kingsman.png',3,2,90,GETDATE()),
('SAW 8: Legado','Cuando multiples cuerpos empiezan a aparecer a lo largo de toda la ciudad, los investigadores comienzan a sospechar al asesino John Kramer a quién creían muerto.','saw8.png',4,1,90,GETDATE()),
('Cars 3','Sorprendido por una nueva generación de corredores ultrarrápidos, el legendario Rayo McQueen (voz de Owen Wilson) queda relegado repentinamente del deporte que tanto ama.','cars3.png',1,8,90,GETDATE());

/* Versiones */
insert into dbo.Versiones (Nombre) values
('Castellano'),
('Subtitulada'),
('3D Castellano'),
('3D Subtitulada');

/* Carteleras */
insert into dbo.Carteleras (IdSede, IdPelicula, HoraInicio, FechaInicio, FechaFin, NumeroSala, IdVersion, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, FechaCarga) values
(1,4,10,'20170625 00:00:00','20170629 00:00:00',							1,			1,		1,		1,		0,			1,		0,		1,		0,		GETDATE()),
(1,5,12,'20170623 00:00:00','20170630 00:00:00',							2,			1,		0,		0,		1,			0,		0,		1,		1,		GETDATE()),
(2,4,9,'20170720 00:00:00','20170730 00:00:00',								1,			3,		1,		0,		0,			1,		1,		1,		1,		GETDATE()),
(3,6,13,'20170805 00:00:00','20170812 00:00:00',							3,			3,		0,		1,		1,			0,		0,		1,		1,		GETDATE()),
(3,7,15,'20170714 00:00:00','20170729 00:00:00',							2,			4,		1,		0,		0,			1,		1,		1,		1,		GETDATE()),
(2,8,10,'20170720 00:00:00','20170730 00:00:00',							3,			2,		1,		0,		1,			0,		0,		0,		1,		GETDATE()),
(2,8,10,'20170801 00:00:00','20170807 00:00:00',							3,			1,		1,		1,		0,			0,		1,		1,		0,		GETDATE());

/* Tipo de documento */
insert into dbo.TiposDocumentos (Descripcion) values
('DNI'),
('LC'),
('OTRO')

/* Reservas */
insert into dbo.Reservas (IdSede, IdVersion, IdPelicula, FechaHoraInicio, Email, IdTipoDocumento, NumeroDocumento, CantidadEntradas, FechaCarga) values
(7, 1, 1, '20170619 00:00:00', 'dir1@dominio.com.ar', 1, 31526329, 3, GETDATE()),
(6, 2, 2, '20170615 14:23:50', 'dir2@dominio.com.ar', 1, 31526330, 4, GETDATE()),
(5, 3, 3, '20170616 12:00:32', 'dir3@dominio.com.ar', 2, 31526331, 1, GETDATE()),
(4, 4, 4, '20170617 19:06:09', 'dir4@dominio.com.ar', 1, 31526332, 2, GETDATE()),
(4, 1, 5, '20170618 01:06:59', 'dir5@dominio.com.ar', 3, 31526333, 2, GETDATE())

/* Usuarios */
INSERT INTO dbo.Usuarios (NombreUsuario, Password) VALUES
('admin',123);
