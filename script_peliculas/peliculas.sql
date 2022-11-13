CREATE DATABASE peliculas;
USE `peliculas`;
/****** Object:  Table `peliculas`.`imagen` ******/
CREATE TABLE `peliculas`.`imagen`(
	`id_imagen` bigint NOT NULL AUTO_INCREMENT
	,`id_estado_clase` bigint NULL
	,`nombre_imagen` varchar(250) NULL
	,`path` varchar(250) NULL
	,`url` varchar(250) NULL
	,PRIMARY KEY
	(
		`id_imagen` ASC
	));
	
CREATE TABLE `peliculas`.`rol` (
	`id_rol` BIGINT NOT NULL AUTO_INCREMENT
	,`id_estado_clase` BIGINT NULL
	,`descripcion` VARCHAR(45) NULL
	,PRIMARY KEY 
	(
		`id_rol`
	));

CREATE TABLE `peliculas`.`persona`(
	`id_persona` bigint NOT NULL AUTO_INCREMENT,
    `id_estado_clase` bigint NULL,
    `nombre_completo` varchar(255) NULL,
    PRIMARY KEY (`id_persona`));

CREATE TABLE `peliculas`.`elenco`(
	`id_elenco` bigint NOT NULL AUTO_INCREMENT
	,`id_estado_clase` bigint NULL
	,`id_rol` bigint NULL
	,`id_persona` bigint NULL
	,`id_pelicula` bigint NULL
	,PRIMARY KEY(
		`id_elenco` ASC
	));

CREATE TABLE `peliculas`.`genero`(
	`id_genero` bigint NOT NULL AUTO_INCREMENT
	,`id_estado_clase` bigint NULL
	,`descripcion` varchar(255) NULL
	,PRIMARY KEY (
		`id_genero` ASC
	));

CREATE TABLE `peliculas`.`usuario`(
	`id_usuario` bigint NOT NULL AUTO_INCREMENT
	,`id_estado_clase` bigint NULL
	,`nombre_completo` varchar(255) NULL
	,`nombre_usuario` varchar(255) NULL
	,`password` varchar(255) NULL
	,PRIMARY KEY(
		`id_usuario` ASC
	));

CREATE TABLE `peliculas`.`pelicula`(
	`id_pelicula` bigint NOT NULL AUTO_INCREMENT
	,`id_estado_clase` bigint NULL
	,`titulo` varchar(255) NULL
	,`anio_estreno` bigint NULL
	,`sinopsis` varchar(255) NULL
	,`id_genero` bigint NULL
	,PRIMARY KEY(
		`id_pelicula` ASC
	));

CREATE TABLE `peliculas`.`valoracion`(
	`id_valoracion` bigint NOT NULL AUTO_INCREMENT
	,`id_estado_clase` bigint NULL
	,`fecha` datetime NULL
	,`puntaje` int NULL
	,`visto` bit NULL
	,`id_pelicula` bigint NULL
	,`id_usuario` bigint NULL
	,PRIMARY KEY(
		`id_valoracion` ASC
	));
    
CREATE TABLE `peliculas`.`estado_clase`(
	`id_estado_clase` bigint NOT NULL AUTO_INCREMENT
	,`descripcion` varchar(250) NULL
	,`codigo_sistema` bigint NULL
	,PRIMARY KEY(
		`id_estado_clase` ASC
	));
	

