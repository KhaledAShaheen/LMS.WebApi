CREATE TABLE [dbo].[BookEntities] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Publisher] NVARCHAR (MAX) NOT NULL,
    [Copies]    INT            NOT NULL,
    CONSTRAINT [PK_BookEntities] PRIMARY KEY CLUSTERED ([Id] ASC)
);

