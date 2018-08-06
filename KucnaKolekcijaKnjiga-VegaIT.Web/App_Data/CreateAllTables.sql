CREATE TABLE [dbo].[Nationality] (
    [NationalityId] INT           IDENTITY (1, 1) NOT NULL,
    [Nationality]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([NationalityId] ASC)
);

CREATE TABLE [dbo].[Language] (
    [LanguageId] INT           IDENTITY (1, 1) NOT NULL,
    [Language]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([LanguageId] ASC)
);

CREATE TABLE [dbo].[Genre] (
    [GenreId] INT           IDENTITY (1, 1) NOT NULL,
    [Genre]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([GenreId] ASC)
);

CREATE TABLE [dbo].[Author] (
    [AuthorId]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Nationality] INT           NULL,
    PRIMARY KEY CLUSTERED ([AuthorId] ASC),
    CONSTRAINT [FK_Author_Nationality] FOREIGN KEY ([Nationality]) REFERENCES [dbo].[Nationality] ([NationalityId])
);

CREATE TABLE [dbo].[Book] (
    [BookId]      INT           IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (50) NOT NULL,
    [ISBN]        NVARCHAR (50) NULL,
    [Genre]       INT           NULL,
    [Language]    INT           NOT NULL,
    [Description] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([BookId] ASC),
    CONSTRAINT [FK_Book_Genre] FOREIGN KEY ([Genre]) REFERENCES [dbo].[Genre] ([GenreId]),
    CONSTRAINT [FK_Book_Language] FOREIGN KEY ([Language]) REFERENCES [dbo].[Language] ([LanguageId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [Book_ISBN]
    ON [dbo].[Book]([ISBN] ASC) WHERE ([ISBN] IS NOT NULL);


CREATE TABLE [dbo].[Book_Author] (
    [Book]   INT NOT NULL,
    [Author] INT NOT NULL,
    CONSTRAINT [PK_Book_Author] PRIMARY KEY CLUSTERED ([Book] ASC, [Author] ASC),
    CONSTRAINT [FK_Book_Author_Book] FOREIGN KEY ([Book]) REFERENCES [dbo].[Book] ([BookId]),
    CONSTRAINT [FK_Book_Author_Author] FOREIGN KEY ([Author]) REFERENCES [dbo].[Author] ([AuthorId])
);

