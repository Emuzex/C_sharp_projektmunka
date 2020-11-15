-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Nov 15. 18:29
-- Kiszolgáló verziója: 10.4.11-MariaDB
-- PHP verzió: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `csharpprojekt`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `products`
--

CREATE TABLE `products` (
  `name` varchar(100) NOT NULL,
  `itemnum` varchar(30) NOT NULL,
  `stock` int(11) NOT NULL DEFAULT 0,
  `discount` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `category` varchar(50) NOT NULL,
  `unit` varchar(2) NOT NULL,
  `unit_size` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `products`
--

INSERT INTO `products` (`name`, `itemnum`, `stock`, `discount`, `price`, `category`, `unit`, `unit_size`) VALUES
('', '', 0, 0, 0, 'Élelmiszer', 'db', 0),
('Alma', '1', 200, 0, 35, 'Élelmiszer', 'db', 1),
('Arany ászok 0,33l fémdobozos', 'AASZK033001', 1000, 0, 289, 'Szeszesital', 'ml', 330),
('Alma ', 'Alma123', 300, 0, 246, 'Élelmiszer', 'kg', 1),
('Csirkecomb', 'CSC00000123', 10, 0, 500, 'Élelmiszer', 'kg', 1),
('Dreher Gold', 'DR000000502', 10, 0, 260, 'Szeszesital', 'ml', 500),
('Dreher Bak', 'DR00000501', 10, 0, 280, 'Szeszesital', 'ml', 500),
('Fehér búzakenyér', 'FBK001', 30, 0, 234, 'Élelmiszer', 'kg', 1),
('Hmmm', 'HMM123456789', 100, 0, 10000, 'Kozmetikum', 'g', 100),
('Kacsamell', 'KCSML001', 500, 0, 1453, 'Élelmiszer', 'kg', 1),
('Kékeres lőcs', 'KL100', 1, 0, 200000, 'Kozmetikum', 'kg', 20);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`itemnum`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
