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

-- tablo yapısı dökülüyor ssidit.ssid
CREATE TABLE IF NOT EXISTS `ssid` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) COLLATE utf16_turkish_ci NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf16 COLLATE=utf16_turkish_ci;

-- ssidit.ssid: ~5 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `ssid` DISABLE KEYS */;
INSERT INTO `ssid` (`ID`, `Name`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'test', '2020-12-25 23:22:21', '2020-12-26 02:07:01'),
	(2, 'lol', '2020-12-25 23:21:21', '2020-12-26 20:14:06'),
	(3, 'helluuu', '2020-12-26 00:26:25', '2020-12-26 01:18:02'),
	(12, 'qwe', '2020-12-26 02:01:37', '2020-12-26 02:01:37'),
	(13, 'qwer', '2020-12-26 02:01:51', '2020-12-26 02:01:51'),
	(14, 'Torchizm', '2020-12-26 19:58:58', '2020-12-26 19:58:58'),
	(15, 'iPhone X', '2020-12-26 19:59:29', '2020-12-26 19:59:29'),
	(16, 'galaxy s5', '2020-12-26 19:59:29', '2020-12-26 19:59:29'),
	(17, 'note', '2020-12-26 19:59:29', '2020-12-26 19:59:29'),
	(18, 'TurkTelekom_ZY9JT', '2020-12-26 19:59:29', '2020-12-26 19:59:29'),
	(19, 'Torchizm_5G', '2020-12-26 19:59:29', '2020-12-26 19:59:29'),
	(20, 'FiberHGW_ZTPG42_2.4GHz', '2020-12-26 20:03:18', '2020-12-26 20:03:18'),
	(21, 'VODAFONENET_WiFi_5G_3799', '2020-12-26 20:03:18', '2020-12-26 20:03:18'),
	(22, 'VODAFONENET_WiFi_3799', '2020-12-26 20:03:18', '2020-12-26 20:03:18'),
	(24, 'Sait', '2020-12-26 20:03:18', '2020-12-26 20:03:18'),
	(25, 'SUPERONLINE_WiFi_3852', '2020-12-26 20:03:18', '2020-12-26 20:03:18'),
	(26, 'SUPERONLINE_WiFi_0866', '2020-12-26 20:03:18', '2020-12-26 20:03:18'),
	(27, 'SUPERONLINERAY', '2020-12-26 20:03:18', '2020-12-26 20:03:18'),
	(32, 'duru', '2020-12-26 20:05:47', '2020-12-26 20:05:47'),
	(34, 'CALISIR', '2020-12-26 20:05:48', '2020-12-26 20:05:48');
/*!40000 ALTER TABLE `ssid` ENABLE KEYS */;

-- tablo yapısı dökülüyor ssidit.votes
CREATE TABLE IF NOT EXISTS `votes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Identity` int(11) NOT NULL DEFAULT '0',
  `Ssid` int(11) NOT NULL DEFAULT '0',
  `Type` int(11) NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf16 COLLATE=utf16_turkish_ci;

-- ssidit.votes: ~6 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `votes` DISABLE KEYS */;
INSERT INTO `votes` (`ID`, `Identity`, `Ssid`, `Type`, `CreatedAt`, `UpdatedAt`) VALUES
	(47, 2, 2, 1, '2020-12-26 18:24:04', '2020-12-26 18:24:08'),
	(48, 3, 1, 1, '2020-12-26 18:24:22', '2020-12-26 18:24:22'),
	(49, 2, 1, 1, '2020-12-26 18:48:07', '2020-12-26 18:48:07'),
	(50, 2, 3, 0, '2020-12-26 18:48:51', '2020-12-26 18:49:12'),
	(51, 4, 3, 0, '2020-12-26 18:48:53', '2020-12-26 18:49:12'),
	(52, 6, 3, 0, '2020-12-26 18:48:55', '2020-12-26 18:49:13'),
	(55, 35, 3, 1, '2020-12-26 19:14:26', '2020-12-26 19:14:26'),
	(56, 35, 2, 1, '2020-12-26 19:14:33', '2020-12-26 19:14:33'),
	(57, 35, 12, 0, '2020-12-26 19:14:46', '2020-12-26 19:14:46'),
	(58, 35, 13, 0, '2020-12-26 19:14:48', '2020-12-26 19:14:48'),
	(59, 1, 13, 1, '2020-12-26 19:19:49', '2020-12-26 19:19:49'),
	(60, 1, 12, 1, '2020-12-26 19:19:49', '2020-12-26 19:19:49'),
	(61, 1, 3, 1, '2020-12-26 19:19:50', '2020-12-26 19:19:50'),
	(62, 1, 1, 1, '2020-12-26 19:19:51', '2020-12-26 19:19:51'),
	(63, 1, 2, 1, '2020-12-26 19:19:52', '2020-12-26 19:19:52');
/*!40000 ALTER TABLE `votes` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
