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

INSERT [marathon-se].dbo.EventType(EventTypeId, EventTypeName) VALUES (N'FM', N'Full Marathon')
INSERT [marathon-se].dbo.EventType(EventTypeId, EventTypeName) VALUES (N'FR', N'5km Fun Run')
INSERT [marathon-se].dbo.EventType(EventTypeId, EventTypeName) VALUES (N'HM', N'Half Marathon')
GO