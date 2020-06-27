-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Gazdă: 127.0.0.1:3306
-- Timp de generare: iun. 27, 2020 la 07:20 PM
-- Versiune server: 8.0.18
-- Versiune PHP: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Bază de date: `romania_roleplay_ragemp`
--
CREATE DATABASE IF NOT EXISTS `romania_roleplay_ragemp` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `romania_roleplay_ragemp`;

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `characters`
--

DROP TABLE IF EXISTS `characters`;
CREATE TABLE IF NOT EXISTS `characters` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `Name` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `NameTag` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Level` int(11) NOT NULL,
  `SkinId` int(11) NOT NULL,
  `Money` bigint(20) NOT NULL,
  `BankMoney` bigint(20) NOT NULL,
  `LastActiveDate` datetime NOT NULL,
  `TimePlayed` double NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UNIQUE` (`Name`)
) ENGINE=MyISAM AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Eliminarea datelor din tabel `characters`
--

INSERT INTO `characters` (`Id`, `UserId`, `Name`, `NameTag`, `Level`, `SkinId`, `Money`, `BankMoney`, `LastActiveDate`, `TimePlayed`) VALUES
(31, 2, 'Don', 'Don', 1, 34, 50000, 100000, '0001-01-01 00:00:00', 0),
(30, 2, 'Antonela', 'Antonela', 1, 33, 50000, 100000, '0001-01-01 00:00:00', 0),
(29, 2, 'Ricardo', 'Ricardo', 1, 32, 50000, 100000, '0001-01-01 00:00:00', 0),
(28, 2, 'Robert', 'Robert', 1, 31, 50000, 100000, '0001-01-01 00:00:00', 0),
(27, 2, 'Johnuta', 'Johnuta', 1, 30, 50000, 100000, '0001-01-01 00:00:00', 0),
(26, 2, 'Roxanne', 'Roxanne', 1, 29, 50000, 100000, '0001-01-01 00:00:00', 0),
(25, 4, 'Arez_Test', 'Arez_Test', 1, 28, 50000, 100000, '0001-01-01 00:00:00', 0),
(24, 5, 'Bubysoft_2', 'Bubysoft_2', 1, 27, 50000, 100000, '0001-01-01 00:00:00', 0),
(23, 4, 'Lewis_Flagstaff', 'Lewis_Flagstaff', 1, 26, 50000, 100000, '0001-01-01 00:00:00', 0),
(22, 2, 'Hatz', 'Hatz', 1, 25, 50000, 100000, '0001-01-01 00:00:00', 0),
(21, 5, 'Bubysoft_1', 'Bubysoft_1', 1, 24, 50000, 100000, '0001-01-01 00:00:00', 0),
(32, 2, 'Bruno', 'Bruno', 1, 35, 50000, 100000, '0001-01-01 00:00:00', 0),
(33, 4, 'Arez_Test2', 'Arez_Test2', 1, 36, 50000, 100000, '0001-01-01 00:00:00', 46000),
(34, 2, 'Mircea', 'Mircea', 1, 37, 50000, 100000, '0001-01-01 00:00:00', 0),
(35, 2, 'Costel', 'Costel', 1, 38, 50000, 100000, '0001-01-01 00:00:00', 0),
(36, 4, 'Arez_Test3', 'Arez_Test3', 1, 40, 50000, 100000, '0001-01-01 00:00:00', 0),
(37, 2, 'Cartus', 'Cartus', 1, 41, 50000, 100000, '0001-01-01 00:00:00', 0),
(38, 4, 'Suzana', 'Suzana', 1, 42, 50000, 100000, '0001-01-01 00:00:00', 0);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `skins`
--

DROP TABLE IF EXISTS `skins`;
CREATE TABLE IF NOT EXISTS `skins` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Model` bigint(20) NOT NULL,
  `FirstHeadShape` int(11) NOT NULL,
  `SecondHeadShape` int(11) NOT NULL,
  `FirstSkinTone` int(11) NOT NULL,
  `SecondSkinTone` int(11) NOT NULL,
  `HeadMix` float NOT NULL,
  `SkinMix` float NOT NULL,
  `Hair` int(11) NOT NULL,
  `FirstHairColor` int(11) NOT NULL,
  `SecondHairColor` int(11) NOT NULL,
  `Beard` int(11) NOT NULL,
  `BeardColor` int(11) NOT NULL,
  `Chest` int(11) NOT NULL,
  `ChestColor` int(11) NOT NULL,
  `Blemishes` int(11) NOT NULL,
  `Ageing` int(11) NOT NULL,
  `Complexion` int(11) NOT NULL,
  `Sundamage` int(11) NOT NULL,
  `Freckles` int(11) NOT NULL,
  `EyesColor` int(11) NOT NULL,
  `Eyebrows` int(11) NOT NULL,
  `EyebrowsColor` int(11) NOT NULL,
  `Makeup` int(11) NOT NULL,
  `Blush` int(11) NOT NULL,
  `BlushColor` int(11) NOT NULL,
  `Lipstick` int(11) NOT NULL,
  `LipstickColor` int(11) NOT NULL,
  `NoseWidth` float NOT NULL,
  `NoseHeight` float NOT NULL,
  `NoseLength` float NOT NULL,
  `NoseBridge` float NOT NULL,
  `NoseTip` float NOT NULL,
  `NoseShift` float NOT NULL,
  `BrowHeight` float NOT NULL,
  `BrowWidth` float NOT NULL,
  `CheekboneHeight` float NOT NULL,
  `CheekboneWidth` float NOT NULL,
  `CheeksWidth` float NOT NULL,
  `Eyes` float NOT NULL,
  `Lips` float NOT NULL,
  `JawWidth` float NOT NULL,
  `JawHeight` float NOT NULL,
  `ChinLength` float NOT NULL,
  `ChinPosition` float NOT NULL,
  `ChinWidth` float NOT NULL,
  `ChinShape` float NOT NULL,
  `NeckWidth` float NOT NULL,
  `Clothes_Torsos` int(11) NOT NULL DEFAULT '0',
  `Clothes_Legs` int(11) NOT NULL DEFAULT '0',
  `Clothes_BagsAndParachutes` int(11) NOT NULL DEFAULT '0',
  `Clothes_Shoes` int(11) NOT NULL DEFAULT '0',
  `Clothes_Accessories` int(11) NOT NULL DEFAULT '0',
  `Clothes_Undershirts` int(11) NOT NULL DEFAULT '0',
  `Clothes_BodyArmors` int(11) NOT NULL DEFAULT '0',
  `Clothes_Decals` int(11) NOT NULL DEFAULT '0',
  `Clothes_Tops` int(11) NOT NULL DEFAULT '0',
  `Clothes_TorsosColor` int(11) NOT NULL DEFAULT '0',
  `Clothes_LegsColor` int(11) NOT NULL DEFAULT '0',
  `Clothes_BagsAndParachutesColor` int(11) NOT NULL DEFAULT '0',
  `Clothes_ShoesColor` int(11) NOT NULL DEFAULT '0',
  `Clothes_AccessoriesColor` int(11) NOT NULL DEFAULT '0',
  `Clothes_UndershirtsColor` int(11) NOT NULL DEFAULT '0',
  `Clothes_BodyArmorsColor` int(11) DEFAULT '0',
  `Clothes_DecalsColor` int(11) NOT NULL DEFAULT '0',
  `Clothes_TopsColor` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Eliminarea datelor din tabel `skins`
--

INSERT INTO `skins` (`Id`, `Model`, `FirstHeadShape`, `SecondHeadShape`, `FirstSkinTone`, `SecondSkinTone`, `HeadMix`, `SkinMix`, `Hair`, `FirstHairColor`, `SecondHairColor`, `Beard`, `BeardColor`, `Chest`, `ChestColor`, `Blemishes`, `Ageing`, `Complexion`, `Sundamage`, `Freckles`, `EyesColor`, `Eyebrows`, `EyebrowsColor`, `Makeup`, `Blush`, `BlushColor`, `Lipstick`, `LipstickColor`, `NoseWidth`, `NoseHeight`, `NoseLength`, `NoseBridge`, `NoseTip`, `NoseShift`, `BrowHeight`, `BrowWidth`, `CheekboneHeight`, `CheekboneWidth`, `CheeksWidth`, `Eyes`, `Lips`, `JawWidth`, `JawHeight`, `ChinLength`, `ChinPosition`, `ChinWidth`, `ChinShape`, `NeckWidth`, `Clothes_Torsos`, `Clothes_Legs`, `Clothes_BagsAndParachutes`, `Clothes_Shoes`, `Clothes_Accessories`, `Clothes_Undershirts`, `Clothes_BodyArmors`, `Clothes_Decals`, `Clothes_Tops`, `Clothes_TorsosColor`, `Clothes_LegsColor`, `Clothes_BagsAndParachutesColor`, `Clothes_ShoesColor`, `Clothes_AccessoriesColor`, `Clothes_UndershirtsColor`, `Clothes_BodyArmorsColor`, `Clothes_DecalsColor`, `Clothes_TopsColor`) VALUES
(31, 1885233650, 11, 3, 42, 25, 0.7, 0.7, 11, 6, 53, 27, 9, 14, 45, 14, 12, 4, 3, 3, 16, 7, 8, 6, 3, 3, 2, 24, 0.97, 0.84, 0.45, 0.2, 0.91, 0.71, 0.29, 0.57, 0.98, 0.22, 0.95, 0.62, 0.59, 0.54, 0.93, 0.39, 0.96, 0.08, 0.95, 0.77, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(30, 2627665880, 24, 21, 10, 24, 0.48, 0.03, 4, 24, 50, 22, 14, 10, 43, 23, 5, 1, 2, 3, 23, 22, 27, 59, 5, 61, 6, 8, 0.15, 0.63, 0.84, 0.61, 0.89, 0.14, 0.26, 0.53, 0.26, 0.39, 0.54, 0.83, 0.32, 0.17, 0.58, 0.55, 0.62, 0.42, 0.87, 0.9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(29, 2627665880, 29, 33, 31, 31, 0.48, 0.81, 71, 48, 56, 17, 22, 15, 38, 3, 9, 10, 9, 6, 24, 25, 28, 28, 1, 34, 8, 54, 0.15, 0.94, 0.36, 0.62, 0.29, 0.82, 0.99, 0.75, 0.39, 0.45, 0.41, 0.62, 0.7, 0.95, 0.04, 0.33, 0.53, 0.11, 0.34, 0.07, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(28, 1885233650, 26, 6, 36, 27, 0.82, 0.51, 69, 39, 46, 21, 56, 9, 33, 18, 4, 2, 1, 14, 11, 11, 38, 7, 6, 17, 9, 57, 0.04, 0.29, 0.38, 0.67, 0.34, 0.54, 0.37, 0.76, 0.86, 0.18, 0.48, 0.34, 0.17, 0.54, 0.18, 0.33, 0.24, 0.75, 0.36, 0.39, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(27, 2627665880, 21, 38, 17, 10, 0.34, 0.33, 62, 23, 19, 17, 29, 6, 33, 6, 5, 2, 7, 14, 24, 3, 26, 66, 4, 58, 8, 60, 0.59, 0.23, 0.39, 0.39, 0.84, 0.3, 0.01, 0.47, 0.66, 0.84, 0.7, 0.9, 0.58, 0.57, 0.92, 0.62, 0.64, 0.05, 0.83, 0.13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(26, 1885233650, 31, 17, 30, 27, 0.23, 0.03, 36, 2, 30, 23, 2, 4, 22, 9, 0, 8, 9, 0, 12, 28, 55, 73, 0, 61, 6, 27, 0.67, 0.19, 0.19, 0.75, 0.01, 0.41, 0.47, 0.82, 0.15, 0.77, 0.04, 0.65, 0.13, 0.17, 0.51, 0.31, 0.88, 0.09, 0.96, 0.22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(25, 1885233650, 27, 14, 40, 11, 0.42, 0, 33, 6, 16, 9, 56, 10, 9, 14, 14, 11, 9, 16, 14, 6, 12, 11, 5, 1, 3, 44, 0.69, 1, 0.93, 0.27, 0.74, 0.95, 0.04, 0.98, 0.86, 0.89, 0.68, 0.2, 0.23, 0.9, 0.36, 0.34, 0.88, 0.76, 0.55, 0.89, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(24, 1885233650, 4, 26, 33, 27, 0.83, 0.7, 13, 58, 43, 24, 5, 12, 10, 14, 10, 6, 10, 8, 20, 27, 42, 68, 3, 54, 1, 37, 0.22, 0.49, 0.22, 0.82, 0.68, 0.83, 0.26, 0.25, 0.93, 0.39, 0.07, 0.64, 0.68, 0.35, 0.6, 0.21, 0.17, 0.44, 0.02, 0.35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(32, 1885233650, 4, 8, 1, 15, 0.4, 0.42, 3, 2, 21, 7, 32, 14, 60, 23, 10, 5, 9, 3, 10, 21, 24, 20, 1, 24, 3, 53, 0.57, 0.44, 0.29, 0.82, 0.63, 0.53, 0.54, 0.5, 0.25, 0.87, 0.55, 0.53, 0.88, 0.36, 0.01, 0.31, 0.19, 0.76, 0.61, 0.93, 49, 33, 58, 12, 21, 100, 54, 70, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(33, 2627665880, 2, 16, 33, 25, 0.04, 0.54, 49, 61, 34, 10, 16, 1, 63, 7, 4, 8, 7, 6, 4, 28, 14, 12, 6, 53, 6, 62, 0.28, 0.91, 0.85, 0.45, 0.23, 0.31, 0.32, 0.02, 0.82, 0.56, 0.99, 0.46, 0.55, 0.39, 0.92, 0.85, 0.53, 0.9, 0.37, 0.29, 86, 25, 11, 23, 70, 46, 32, 37, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(34, 1885233650, 36, 20, 18, 5, 0.2, 0.17, 32, 63, 57, 4, 13, 4, 35, 1, 14, 4, 8, 2, 25, 22, 23, 68, 6, 56, 4, 61, 0.69, 0.12, 0.91, 0.55, 0.55, 0.7, 0.05, 0.7, 0.99, 0.19, 0.58, 0.94, 0.6, 0.74, 0.51, 0.74, 0.81, 0.33, 0.3, 0.36, 85, 27, 30, 32, 85, 90, 13, 28, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(35, 1885233650, 42, 4, 38, 16, 0.73, 0.01, 38, 51, 36, 3, 15, 4, 4, 10, 7, 3, 1, 4, 29, 8, 59, 37, 4, 40, 4, 17, 0.31, 0.26, 0.58, 0.04, 0.21, 0.88, 0.34, 0.5, 0.09, 0.13, 0.95, 0.62, 0.49, 0.7, 0.9, 0.24, 0.76, 0.49, 0.75, 0.75, 73, 15, 32, 50, 100, 20, 19, 15, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(36, 1885233650, 28, 39, 36, 37, 0.39, 0.97, 18, 0, 0, 9, 0, 9, 33, 0, 0, 10, 5, 0, 24, 23, 14, 2, 2, 16, 5, 16, 0.96, 0.04, 0.85, 0.46, 0.85, 0.91, 0, 0.84, 0.08, 0.87, 0.3, 0.76, 0.12, 0.14, 0.24, 0.34, 0.6, 0.06, 0.54, 0.44, 11, 9, 84, 12, 100, 15, 44, 70, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(37, 1885233650, 7, 24, 12, 4, 0.84, 0.26, 31, 63, 62, 27, 27, 4, 21, 8, 2, 5, 4, 2, 4, 2, 46, 29, 4, 47, 3, 7, 0.26, 0.42, 0.84, 0.28, 0.46, 0.01, 0.62, 0.32, 0.5, 0.17, 0.36, 0.09, 0.21, 0.59, 0.23, 0.91, 0.4, 0.83, 0.33, 0.73, 86, 100, 43, 50, 79, 45, 54, 28, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(38, 1885233650, 27, 38, 14, 45, 0.1, 0.34, 42, 62, 6, 8, 48, 6, 19, 16, 10, 8, 7, 14, 19, 17, 10, 14, 6, 18, 3, 22, 0.68, 0.53, 0.09, 0.36, 0.62, 0.07, 0.91, 0.16, 0.06, 0.63, 0.23, 0.15, 0.84, 0.86, 0.29, 0.15, 0.98, 0.98, 0.1, 0.46, 99, 100, 61, 31, 69, 100, 28, 71, 56, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(39, 1885233650, 2, 12, 42, 17, 0.84, 0.33, 15, 48, 52, 21, 17, 3, 10, 4, 6, 6, 10, 17, 30, 13, 32, 3, 3, 11, 4, 55, 0.81, 0.63, 0.79, 0.02, 0.23, 0.12, 0.18, 0.96, 0.54, 0.4, 0.49, 0.71, 0.24, 0.46, 0.73, 0.11, 0.02, 0.57, 0.55, 0.16, 0, 61, 93, 64, 90, 15, 0, 76, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(40, 1885233650, 25, 19, 40, 25, 0.38, 0.44, 69, 35, 27, 6, 17, 7, 13, 23, 8, 8, 2, 12, 19, 31, 28, 62, 4, 40, 3, 45, 0.13, 0.8, 0.53, 0, 0.79, 0.79, 0.33, 0.12, 0.85, 0.23, 0.96, 0.72, 0.97, 0.63, 0.72, 0.36, 0.63, 0.91, 0.98, 0.08, 11, 24, 3, 22, 100, 100, 35, 5, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(41, 1885233650, 43, 35, 44, 6, 0, 0.47, 70, 20, 18, 22, 19, 3, 60, 9, 7, 11, 10, 14, 13, 6, 53, 72, 6, 47, 3, 60, 0.74, 0.89, 0.4, 0.42, 0.49, 0.55, 0.89, 0.91, 0.03, 0.78, 0.4, 0.8, 0.5, 0.84, 0.7, 0.84, 0.38, 0.31, 0.73, 0.54, 100, 100, 0, 3, 92, 100, 0, 7, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(42, 2627665880, 29, 29, 16, 21, 0.37, 0.08, 53, 31, 7, 18, 40, 14, 63, 12, 7, 6, 2, 0, 10, 31, 56, 0, 1, 58, 1, 28, 0.59, 0.76, 0.46, 0.19, 0.57, 0.51, 1, 0.06, 0.95, 0.08, 0.44, 0.17, 0.2, 0.83, 0.21, 0.25, 0.47, 0.84, 0.33, 0.08, 16, 67, 0, 63, 93, 44, 0, 34, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(16) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email` varchar(250) COLLATE utf8mb4_unicode_ci NOT NULL,
  `RegisterDate` datetime NOT NULL,
  `LastActiveDate` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Unique_Username` (`Username`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Eliminarea datelor din tabel `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`, `Email`, `RegisterDate`, `LastActiveDate`) VALUES
(2, 'DFR', '869254ccefb6671392f185ae7f280c7bb60cdc6797ee976a03a3c68e2ff00d670780ad6e9d3ec390a69645bc18ec0b8acea8269fff8aa8277bed2064e0a2db6b', 'dfr@gmail.com', '2020-06-11 13:27:10', '2020-06-24 17:11:23'),
(3, 'dnn966', '5a2c3ac9bc54a9f8eccee3d1730f7c18948b05e2c8ab4a220cdb38624b88e384097d8b81205e0bf53e52aaa71d37a25bef56d5b533da2188afcaa2558dd20bf9', 'dnn966@gmail.com', '2020-06-11 17:35:38', '0001-01-01 00:00:00'),
(4, 'Arez', '333b54cb161b5993efe1ec37beffabc576a3d253612efdde18391dfb7082b3d19b97ba982d8501a45df1b1fb1e0360541c7e2748650f8377968af1eb64cc6205', 'arez@gmail.com', '2020-06-11 17:35:56', '2020-06-27 15:29:59'),
(5, 'Alex', '7bc722ba30d475d5845607c8d06d13f298411edda8183ffbb56131d3897a1658abf20402c0bdf9b779a31ffbb4ff162ff1c217ab7464706d0ba635e9d15d7e54', 'alex@gmail.com', '2020-06-11 17:36:11', '2020-06-11 19:18:54'),
(6, 'ace', 'ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff', 'ace@gmail.com', '2020-06-25 17:47:48', '0001-01-01 00:00:00');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
