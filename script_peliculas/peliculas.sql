-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 15-03-2023 a las 19:35:24
-- Versión del servidor: 5.7.36
-- Versión de PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `peliculas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `elenco`
--

DROP TABLE IF EXISTS `elenco`;
CREATE TABLE IF NOT EXISTS `elenco` (
  `id_elenco` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `id_rol` bigint(20) DEFAULT NULL,
  `id_persona` bigint(20) DEFAULT NULL,
  `id_pelicula` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id_elenco`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_clase`
--

DROP TABLE IF EXISTS `estado_clase`;
CREATE TABLE IF NOT EXISTS `estado_clase` (
  `id_estado_clase` bigint(20) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(250) DEFAULT NULL,
  `codigo_sistema` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id_estado_clase`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `estado_clase`
--

INSERT INTO `estado_clase` (`id_estado_clase`, `descripcion`, `codigo_sistema`) VALUES
(1, 'activo', 1),
(2, 'baja', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `genero`
--

DROP TABLE IF EXISTS `genero`;
CREATE TABLE IF NOT EXISTS `genero` (
  `id_genero` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_genero`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `genero`
--

INSERT INTO `genero` (`id_genero`, `id_estado_clase`, `descripcion`) VALUES
(1, 1, 'Acción'),
(2, 1, 'Fantasia');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `imagen`
--

DROP TABLE IF EXISTS `imagen`;
CREATE TABLE IF NOT EXISTS `imagen` (
  `id_imagen` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `nombre_imagen` varchar(250) DEFAULT NULL,
  `path` varchar(250) DEFAULT NULL,
  `url` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id_imagen`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pelicula`
--

DROP TABLE IF EXISTS `pelicula`;
CREATE TABLE IF NOT EXISTS `pelicula` (
  `id_pelicula` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `titulo` varchar(255) DEFAULT NULL,
  `anio_estreno` bigint(20) DEFAULT NULL,
  `sinopsis` varchar(255) DEFAULT NULL,
  `id_genero` bigint(20) DEFAULT NULL,
  `id_imagen` bigint(20) DEFAULT NULL,
  `director` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_pelicula`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `pelicula`
--

INSERT INTO `pelicula` (`id_pelicula`, `id_estado_clase`, `titulo`, `anio_estreno`, `sinopsis`, `id_genero`, `id_imagen`, `director`) VALUES
(1, 2, 'Thor', 2022, 'LOVE AND Thunder', 1, NULL, 'Celeste Cordoba'),
(2, 2, 'Blancanieves', 2023, 'Princesas', 2, NULL, 'Fernando Heredia'),
(3, 1, 'IT', 2021, 'Payaso', NULL, NULL, 'Steven Spielberg'),
(4, 1, 'Superman', 2020, 'Superheroe', 1, NULL, 'Tim Burton'),
(5, 1, 'Avengers', 2021, 'Superheroes', 1, NULL, 'Tom Cruise');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

DROP TABLE IF EXISTS `persona`;
CREATE TABLE IF NOT EXISTS `persona` (
  `id_persona` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `nombre_completo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_persona`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

DROP TABLE IF EXISTS `rol`;
CREATE TABLE IF NOT EXISTS `rol` (
  `id_rol` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE IF NOT EXISTS `usuario` (
  `id_usuario` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `nombre_completo` varchar(255) DEFAULT NULL,
  `nombre_usuario` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id_usuario`, `id_estado_clase`, `nombre_completo`, `nombre_usuario`, `password`) VALUES
(1, 1, 'Celeste Cordoba', 'cele', 'cele'),
(2, 2, 'Jessica', 'jessi', 'jessi');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `valoracion`
--

DROP TABLE IF EXISTS `valoracion`;
CREATE TABLE IF NOT EXISTS `valoracion` (
  `id_valoracion` bigint(20) NOT NULL AUTO_INCREMENT,
  `id_estado_clase` bigint(20) DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `puntaje` int(11) DEFAULT NULL,
  `visto` bit(1) DEFAULT NULL,
  `id_pelicula` bigint(20) DEFAULT NULL,
  `id_usuario` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id_valoracion`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
