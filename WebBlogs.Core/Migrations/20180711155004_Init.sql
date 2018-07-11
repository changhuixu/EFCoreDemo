IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Blogs] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(256) NOT NULL,
    [Content] nvarchar(max) NULL,
    [AuthorId] int NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Blogs_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Blogs_AuthorId] ON [Blogs] ([AuthorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180711155004_Init', N'2.1.1-rtm-30846');

GO

