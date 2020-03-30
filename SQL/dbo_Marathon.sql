--
-- Скрипт сгенерирован Devart dbForge Studio 2019 for SQL Server, Версия 5.7.99.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/sql/studio
-- Дата скрипта: 31.03.2020 0:48:00
-- Версия сервера: 14.00.1000
--

SET DATEFORMAT ymd
SET ARITHABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS, XACT_ABORT OFF
GO

SET IDENTITY_INSERT [marathon-se].dbo.Marathon ON
GO
INSERT [marathon-se].dbo.Marathon(MarathonId, MarathonName, CityName, CountryCode, YearHeld) VALUES (1, N'Marathon Skills 2011', N'York', N'GBR', 2011)
INSERT [marathon-se].dbo.Marathon(MarathonId, MarathonName, CityName, CountryCode, YearHeld) VALUES (2, N'Marathon Skills 2012', N'Hanoi', N'VIE', 2012)
INSERT [marathon-se].dbo.Marathon(MarathonId, MarathonName, CityName, CountryCode, YearHeld) VALUES (3, N'Marathon Skills 2013', N'Leipzig', N'GER', 2013)
INSERT [marathon-se].dbo.Marathon(MarathonId, MarathonName, CityName, CountryCode, YearHeld) VALUES (4, N'Marathon Skills 2014', N'Osaka', N'JPN', 2014)
INSERT [marathon-se].dbo.Marathon(MarathonId, MarathonName, CityName, CountryCode, YearHeld) VALUES (5, N'Marathon Skills 2015', N'Sao Paulo', N'BRA', 2015)
GO
SET IDENTITY_INSERT [marathon-se].dbo.Marathon OFF
GO