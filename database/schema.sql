-- phpMyAdmin SQL Dump
CREATE DATABASE spark
CHARACTER SET utf8mb4
	COLLATE utf8mb4_unicode_ci;
--
-- Set default database
--
USE spark;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


--
-- Estrutura da tabela `logs`
--

CREATE TABLE `logs` (
  `id` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
)