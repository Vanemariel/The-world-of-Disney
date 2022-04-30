USE [Locacion]
GO

/****** Objeto: Table [dbo].[usuarios] Fecha del script: 29/4/2022 18:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[usuarios];


GO
CREATE TABLE [dbo].[usuarios] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (MAX) NULL,
    [Email]    NVARCHAR (MAX) NULL,
    [Lastname] NVARCHAR (MAX) NULL,
    [Pasword]  NVARCHAR (MAX) NULL
);


