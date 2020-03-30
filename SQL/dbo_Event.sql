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

INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'11_1FM', N'Ouse Marathon', N'FM', 1, '2011-09-08 09:00:00.000', 135.00, 500)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'11_1FR', N'Humber Fun Run', N'FR', 1, '2011-10-08 10:00:00.000', 15.00, 800)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'11_1HM', N'Foss Half Marathon', N'HM', 1, '2011-09-08 14:00:00.000', 70.00, 650)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'14_4FM', N'Honshu Marathon', N'FM', 4, '2014-07-05 09:00:00.000', 160.00, 2680)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'14_4FR', N'Honshu Fun Run', N'FR', 4, '2014-08-05 11:00:00.000', 20.00, 1500)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'14_4HM', N'Honshu Half Marathon', N'HM', 4, '2014-08-05 09:00:00.000', 60.00, 2680)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'15_5FM', N'Samba Full Marathon', N'FM', 5, '2015-05-09 06:00:00.000', 145.00, 2200)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'15_5FR', N'Capoeira 5km Fun Run', N'FR', 5, '2015-06-09 15:00:00.000', 20.00, 5000)
INSERT [marathon-se].dbo.Event(EventId, EventName, EventTypeId, MarathonId, StartDateTime, Cost, MaxParticipants) VALUES (N'15_5HM', N'Jongo Half Marathon', N'HM', 5, '2015-06-09 07:00:00.000', 75.00, 2500)
GO