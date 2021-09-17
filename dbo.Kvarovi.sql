CREATE TABLE [dbo].[Kvarovi] (
    [Id]                   VARCHAR (50)  NOT NULL,
    [datumKvara]           DATETIME      NULL,
    [status]               VARCHAR (50)  NULL,
    [datumZatvaranjaKvara] DATETIME      NULL,
    [kratakOpis]           VARCHAR (50)  NULL,
    [uzrok]                VARCHAR (MAX) NULL,
    [detaljanOpis]         VARCHAR (MAX) NULL,
    [opisAkcije]           VARCHAR (MAX) NULL,
    [vremeAkcije]          DATETIME      NULL,
    [elektricniElement]    VARCHAR (50)  NULL,
    [idElement]            INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Kvarovi_ElektricniElementi] FOREIGN KEY ([idElement]) REFERENCES [dbo].[ElektricniElementi] ([idElement])
);