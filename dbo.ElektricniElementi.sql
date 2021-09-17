CREATE TABLE [dbo].[ElektricniElementi] (
    [idElement]    INT          NOT NULL,
    [naziv]        VARCHAR (50) NULL,
    [lokacija]     VARCHAR (50) NULL,
    [tip]          VARCHAR (50) NULL,
    [yKoordinata]  FLOAT (53)   NULL,
    [xKoordinata]  FLOAT (53)   NULL,
    [naponskiNivo] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([idElement] ASC)
);
