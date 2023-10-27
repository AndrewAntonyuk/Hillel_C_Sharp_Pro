--<-------------------------------------------------------->--
--Створення таблиць 
--<-------------------------------------------------------->--
USE [master]

IF EXISTS(SELECT *
          FROM [sys].[databases]
          WHERE [name] = 'T12_CinemaDb')
BEGIN
    ALTER DATABASE T12_CinemaDb
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE T12_CinemaDb
END

CREATE DATABASE T12_CinemaDb
GO
USE T12_CinemaDb

--Створюємо загальні функції
--Функція для перевірки довжини
IF EXISTS (SELECT  1
            FROM [INFORMATION_SCHEMA].[ROUTINES]
            WHERE Specific_schema = 'dbo'
              AND specific_name = 'get_checked_len'
              AND Routine_Type = 'FUNCTION')

  DROP FUNCTION [dbo].[get_checked_len]
GO

CREATE FUNCTION [dbo].[get_checked_len]
                (
                    @str NVARCHAR
                )
RETURNS INT
AS
BEGIN
   DECLARE @len INT
   SET @len = LEN(TRIM(@str))
   
   RETURN @len
END
GO

--Створюю таблицю для зберігання жанрів
IF OBJECT_ID(N'Genres', N'U') IS NULL
BEGIN
    CREATE TABLE [T12_CinemaDb].[dbo].[Genres]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(30) NOT NULL,
        [Description] NVARCHAR(500),

        CONSTRAINT [PK_Genre_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_Genre_Name] UNIQUE([Name]),
        CONSTRAINT [CK_Genre_Name] CHECK([dbo].[get_checked_len]([Name]) > 0)
    )
END

IF OBJECT_ID(N'Directors', N'U') IS NULL
BEGIN
    CREATE TABLE [T12_CinemaDb].[dbo].[Directors]
    (
        [Id] INT IDENTITY,
        [FirstName] NVARCHAR(30) NOT NULL,
        [MiddleName] NVARCHAR(30),
        [LastName] NVARCHAR(30),
        [ShortBio] NVARCHAR(1000),

        CONSTRAINT [PK_Director_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_Director_FirstName_MiddleName_LastName] UNIQUE([FirstName], [MiddleName], [LastName]),
        CONSTRAINT [CK_Director_FirstName] CHECK([dbo].[get_checked_len]([FirstName]) > 0)
    )
END

IF OBJECT_ID(N'Films', N'U') IS NULL
BEGIN
    CREATE TABLE [T12_CinemaDb].[dbo].[Films]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(30) NOT NULL,
        [GenreId] INT NOT NULL DEFAULT 0,
        [DirectorId] INT NOT NULL DEFAULT 0,
        [Description] NVARCHAR(1000),

        CONSTRAINT [PK_Film_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_Film_Name] UNIQUE([Name]),
        CONSTRAINT [CK_Film_Name] CHECK([dbo].[get_checked_len]([Name]) > 0),
        CONSTRAINT [FK_Films_To_Genres] FOREIGN KEY([GenreId])
                                        REFERENCES [T12_CinemaDb].[dbo].[Genres]([Id])
                                        ON UPDATE CASCADE
                                        ON DELETE SET DEFAULT,
        CONSTRAINT [FK_Films_To_Directors] FOREIGN KEY([DirectorId])
                                           REFERENCES [T12_CinemaDb].[dbo].[Directors]([Id])
                                           ON UPDATE CASCADE
                                           ON DELETE SET DEFAULT
    )
END

IF OBJECT_ID(N'Sessions', N'U') IS NULL
BEGIN
    CREATE TABLE [T12_CinemaDb].[dbo].[Sessions]
    (
        [Id] INT IDENTITY,
        [EventDateTime] DATETIME NOT NULL DEFAULT GETDATE(),
        [FilmId] INT NOT NULL, 
        
        CONSTRAINT [PK_Session_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_Session_EventDateTime_FilmId] UNIQUE([EventDateTime], [FilmId]),
        --CONSTRAINT [CK_Session_EventDateTime] CHECK(DATEDIFF(DAY, GETDATE(), [EventDateTime]) >= 0),
        CONSTRAINT [FK_Sessions_To_Films] FOREIGN KEY([FilmId])
                                          REFERENCES [T12_CinemaDb].[dbo].[Films]([Id])
                                          ON UPDATE CASCADE
                                          ON DELETE CASCADE
    )
END

--<-------------------------------------------------------->--
--Додавання даних до таблиць
--<-------------------------------------------------------->--
INSERT
INTO [T12_CinemaDb].[dbo].[Genres]
VALUES ('Action', 'Associated with particular types of spectacle (e.g., explosions, chases, combat).'),
       ('Adventure', 'Implies a narrative that is defined by a journey (often including some form of pursuit) and is usually located within a fantasy or exoticized setting.'),
       ('Comedy', 'Defined by events that are primarily intended to make the audience laugh.'),
       ('Drama', 'Focused on emotions and defined by conflict, often looking to reality rather than sensationalism.'),
       ('Fantasy', 'Films defined by situations that transcend natural laws and/or by settings inside a fictional universe, with narratives that are often inspired by or involve human myths.'),
       ('Horror', 'Films that seek to elicit fear or disgust in the audience for entertainment purposes.')

INSERT
INTO [T12_CinemaDb].[dbo].[Directors]
VALUES ('Martin', NULL, 'Scorsese', 'We`re talking about the guy who made Taxi Driver here! No one has more classics than Scorsese,     including directors like James Cameron and David Fincher. His resume includes Raging Bull, Goodfellas, Mean Streets, Cape Fear, Shutter Island, and The Last Waltz. Famously, it took Scorsese a while to win an Oscar, but they eventually gave him one for The Departed.'),
       ('Guillermo', NULL, 'del Toro', 'For the longest time, Guillermo del Toro was one of those under-the-radar directors. Then he made Pan`s Labyrinth, Hellboy, and The Shape of Water. Now you can`t watch a football game without seeing an ad for Nightmare Alley. His success is further proof that good work+hard work will eventually= acclaim.'),
       ('Christopher', NULL, 'Nolan', 'Like Fincher, Nolan is a track-record director. He`s 11 for 11 on feature films. Sure, he`s only made a couple of great films (Dunkirk, The Dark Knight), but he`s never made a movie that isn`t worth watching.'),
       ('James', NULL, 'Cameron', 'Is anyone talking about Apichatapong? Not really. Cameron, on the other hand? He`s a living legend. He`s discussed more than any other director on here. Whether we`re talking about Terminator 2 or The Titanic, Cameron has managed to stay relevant for as long as I`ve been alive. His Avatar films will keep it that way for years to come.'),
       ('Steven', NULL, 'Spielberg', 'Pick an age, any age: Spielberg has the power to make you feel like a kid again. It doesn`t matter if you`re 8 or 88, ET,  Indiana Jones, and Jurassic Park will have you grinning from ear-to-ear. Even at 75, the man is still finding ways to make us smile. ')

INSERT
INTO [T12_CinemaDb].[dbo].[Films]
VALUES ('Killers of the Flower Moon', 4, 1, 'Its plot centers on a series of Oklahoma murders in the Osage Nation during the 1920s, committed after oil was discovered on tribal land'),
       ('Shutter Island', 6, 1, 'In 1954, U.S. Marshal Edward "Teddy" Daniels and his new partner Chuck Aule travel to Ashecliffe Hospital for the criminally insane on Shutter Island, Boston Harbor to investigate the disappearance of Rachel Solando, a patient of the hospital who had previously drowned her three children.'),
       ('Hellboy', 2, 2, 'The film draws inspiration from the debut comic Hellboy: Seed of Destruction. In the film, a charismatic demon-turned-investigator named "Hellboy" works with the secretive Bureau of Paranormal Research and Defense to suppress paranormal threats, but a resurrected sorcerer seeks to make Hellboy fulfill his destiny by triggering the apocalypse.'),
       ('Interstellar', 5, 3, 'In 2067, humanity is facing extinction following a global famine caused by ecocide. As a result, ex-NASA pilot, Joseph Cooper, is forced to work as a farmer, with his son Tom, daughter Murph and father-in-law Donald.'),
       ('The Terminator', 1, 4, 'Two men arrive separately in 1984 Los Angeles, having time traveled from 2029. One is a cybernetic assassin known as a Terminator, programmed to hunt and kill a woman named Sarah Connor. The other is a human soldier named Kyle Reese, intent on stopping it. They both steal guns and clothing.'),
       ('Catch Me If You Can', 2, 5, 'In 1969, FBI agent Carl Hanratty arrives in Marseille, France, to pick up a prisoner named Frank Abagnale Jr. who became ill due to the prison`s conditions.')


INSERT
INTO [T12_CinemaDb].[dbo].[Sessions]
VALUES ('2023/11/01 18:00', 1),
       ('2023/11/02 20:00', 1),
       ('2023/11/01 19:00', 2),
       ('2023/11/02 20:00', 2),
       ('2023/11/01 18:00', 3),
       ('2023/11/02 18:00', 3),
       ('2023/11/03 19:00', 4),
       ('2023/11/02 20:00', 4),
       ('2023/11/02 17:00', 5),
       ('2023/11/03 20:00', 5),
       ('2023/11/03 21:00', 6),
       ('2023/11/04 18:00', 6)

SELECT s.[EventDateTime], f.[Name] AS 'Name of film', g.[Name] AS 'Genre', (ISNULL(d.[FirstName], '') + ' ' + ISNULL(d.[MiddleName], '') + ' ' + ISNULL(d.[LastName], ''))  AS 'Directed by'
FROM [T12_CinemaDb].[dbo].[Sessions] AS s
     LEFT JOIN [T12_CinemaDb].[dbo].[Films] AS f ON f.[Id] = s.[FilmId]
     LEFT JOIN [T12_CinemaDb].[dbo].[Directors] AS d ON d.[Id] = f.[DirectorId]
     LEFT JOIN [T12_CinemaDb].[dbo].[Genres] AS g ON g.[Id] = f.[GenreId]
ORDER BY f.[Name]