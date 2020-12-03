-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Dec 03. 23:26
-- Kiszolgáló verziója: 10.4.14-MariaDB
-- PHP verzió: 7.2.34

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
  `unit_size` double NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `products`
--

INSERT INTO `products` (`name`, `itemnum`, `stock`, `discount`, `price`, `category`, `unit`, `unit_size`, `id`) VALUES
('Alma', '1', 200, 0, 35, 'Élelmiszer', 'db', 1, 2),
('Arany ászok 0,33l fémdobozos', 'AASZK033001', 1, 0, 289, 'Szeszesital', 'ml', 330, 3),
('Alma ', 'Alma123', 300, 0, 246, 'Élelmiszer', 'kg', 1, 4),
('Csirkecomb', 'CSC00000123', 10, 0, 500, 'Élelmiszer', 'kg', 1, 5),
('*Dreher Gold', 'DR000000502', 9, 0, 260, 'Szeszesital', 'ml', 500, 6),
('*Dreher Bak', 'DR000000501', 9900, 0, 280, 'Szeszesital', 'ml', 500, 7),
('Fehér búzakenyér', 'FBK001', 30, 0, 234, 'Élelmiszer', 'kg', 1, 8),
('Hmmm', 'HMM123456789', 100, 0, 10000, 'Kozmetikum', 'g', 100, 9),
('Kacsamell', 'KCSML001', 500, 0, 1453, 'Élelmiszer', 'kg', 1, 10);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `pass` text NOT NULL,
  `username` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `pass`, `username`) VALUES
(1, '21232f297a57a5a743894a0e4a801fc3', 'admin');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
