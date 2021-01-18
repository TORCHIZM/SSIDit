-- --------------------------------------------------------
-- Sunucu:                       127.0.0.1
-- Sunucu sürümü:                10.1.38-MariaDB - mariadb.org binary distribution
-- Sunucu İşletim Sistemi:       Win64
-- HeidiSQL Sürüm:               10.1.0.5464
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- ssidit için veritabanı yapısı dökülüyor
CREATE DATABASE IF NOT EXISTS `ssidit` /*!40100 DEFAULT CHARACTER SET utf16 COLLATE utf16_turkish_ci */;
USE `ssidit`;

-- tablo yapısı dökülüyor ssidit.comments
CREATE TABLE IF NOT EXISTS `comments` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `identity` int(11) NOT NULL DEFAULT '0',
  `ssid` int(11) NOT NULL DEFAULT '0',
  `content` text COLLATE utf16_turkish_ci,
  `createdat` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedat` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf16 COLLATE=utf16_turkish_ci;

-- Veri çıktısı seçilmemişti
-- tablo yapısı dökülüyor ssidit.ssids
CREATE TABLE IF NOT EXISTS `ssids` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) COLLATE utf16_turkish_ci NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf16 COLLATE=utf16_turkish_ci;

-- Veri çıktısı seçilmemişti
-- tablo yapısı dökülüyor ssidit.votes
CREATE TABLE IF NOT EXISTS `votes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Identity` int(11) NOT NULL DEFAULT '0',
  `Ssid` int(11) NOT NULL DEFAULT '0',
  `Type` int(11) NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf16 COLLATE=utf16_turkish_ci;

-- Veri çıktısı seçilmemişti
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
