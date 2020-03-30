--
-- Скрипт сгенерирован Devart dbForge Studio 2019 for SQL Server, Версия 5.7.99.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/sql/studio
-- Дата скрипта: 31.03.2020 0:48:01
-- Версия сервера: 14.00.1000
--

SET DATEFORMAT ymd
SET ARITHABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS, XACT_ABORT OFF
GO

SET IDENTITY_INSERT [marathon-se].dbo.RegistrationStatus ON
GO
INSERT [marathon-se].dbo.RegistrationStatus(RegistrationStatusId, RegistrationStatus) VALUES (1, N'Registered')
INSERT [marathon-se].dbo.RegistrationStatus(RegistrationStatusId, RegistrationStatus) VALUES (2, N'Payment Confirmed')
INSERT [marathon-se].dbo.RegistrationStatus(RegistrationStatusId, RegistrationStatus) VALUES (3, N'Race Kit Sent')
INSERT [marathon-se].dbo.RegistrationStatus(RegistrationStatusId, RegistrationStatus) VALUES (4, N'Race Attended')
GO
SET IDENTITY_INSERT [marathon-se].dbo.RegistrationStatus OFF
GO