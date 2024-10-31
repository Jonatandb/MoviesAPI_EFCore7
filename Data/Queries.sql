SELECT * FROM "__EFMigrationsHistory"
ORDER BY "MigrationId" ASC;

select * from "Generos";

/*
delete from "Generos" 
where "Id" = 14
*/

select * from "Actores";

select * from "Peliculas";

select * from "Comentarios";

select * from "PeliculasActores";

select * from "GeneroPelicula";

select 
	"p"."Titulo" as "Película",
	"p"."EnCines",
	"p"."FechaEstreno",
	STRING_AGG( "g"."Nombre", ', ') as "Generos",
	CONCAT("a"."Nombre", ' as ', "pa"."Personaje") as "Actor",
	STRING_AGG("c"."Contenido", ' / ') as "Comentarios"
from "Peliculas" as "p" 
	left join "GeneroPelicula" as "gp" on "p"."Id" = "gp"."PeliculasId"
	left join "Generos" as "g" on "g"."Id" = "gp"."GenerosId"
	left join "PeliculasActores" as "pa" on "pa"."PeliculaId" = "p"."Id"
	left join "Actores" as "a" on "a"."Id" = "pa"."ActorId"
	left join "Comentarios" as "c" on "c"."PeliculaId" = "p"."Id"
group by 	"p"."Titulo", 	"p"."EnCines",	"p"."FechaEstreno", "a"."Nombre", "pa"."Personaje"
