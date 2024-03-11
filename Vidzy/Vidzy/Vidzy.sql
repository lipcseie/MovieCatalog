IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Genres] (
    [Id] tinyint NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Videos] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [RealeaseDate] datetime2 NOT NULL,
    [GenreId] tinyint NOT NULL,
    CONSTRAINT [PK_Videos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [VideoGenres] (
    [GenresId] tinyint NOT NULL,
    [VideosId] int NOT NULL,
    CONSTRAINT [PK_VideoGenres] PRIMARY KEY ([GenresId], [VideosId]),
    CONSTRAINT [FK_VideoGenres_Genres_GenresId] FOREIGN KEY ([GenresId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_VideoGenres_Videos_VideosId] FOREIGN KEY ([VideosId]) REFERENCES [Videos] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] ON;
INSERT INTO [Genres] ([Id], [Name])
VALUES (CAST(1 AS tinyint), N'Action'),
(CAST(2 AS tinyint), N'Fantasy');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] OFF;
GO

CREATE INDEX [IX_VideoGenres_VideosId] ON [VideoGenres] ([VideosId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240311114304_InitialModel', N'8.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240311133254_InitialCreate', N'8.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [VideoGenres];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Videos]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Videos] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Videos] ALTER COLUMN [Name] nvarchar(max) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Genres]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Genres] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Genres] ALTER COLUMN [Name] nvarchar(max) NULL;
GO

CREATE INDEX [IX_Videos_GenreId] ON [Videos] ([GenreId]);
GO

ALTER TABLE [Videos] ADD CONSTRAINT [FK_Videos_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240311134718_ChangeRelationshipVideoGenreToOneToMany', N'8.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Videos] ADD [Classification] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240311135622_AddClassificationToVideo', N'8.0.2');
GO

COMMIT;
GO

