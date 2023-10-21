--<-------------------------------------------------------->--
--Завдання
--<-------------------------------------------------------->--
--Усі назви в базі даних лише англійською мовою!

--Створіть базу даних для барбершопу. 
--Продумати структуру бази даних та які таблиці створити.

--Необхідно зберігати таку інформацію: 
--■ Дані барберів: 
--▷ ПІБ;
--▷ стать; 
--▷ контактний телефон; 
--▷ email; 
--▷ дата народження; 
--▷ дата прийняття на роботу; 
--▷ позиція у барбершопі: чиф-барбер (тільки один), синьйор-барбер, джуніор-барбер; 
--▷ список послуг з цінами та тривалістю послуги за часом 
--▷ фідбеки клієнтів про барбер; 
--▷ оцінки барберів від клієнтів (дуже погано, погано, нормально, добре, чудово).

--■ Розклад барберів: 
--▷ доступність за датами та часом; 
--▷ запис на дату та час конкретного клієнта. 

--■ Дані клієнтів: 
--▷ ПІБ; 
--▷ контактний телефон; 
--▷ email; 
--▷ фідбеки клієнта про барбери; 
--▷ оцінки клієнтів барберам (дуже погано, погано, нормально, добре, чудово). 

--■ Архів відвідувань клієнтів: 
--▷ клієнт; 
--▷ барбер; 
--▷ послуга (і); 
--▷ дата; 
--▷ загальна вартість; 
--▷ оцінка; 
--▷ фідбек.

--Використовуючи тригери, функції користувача, збережені процедури реалізуйте наступну функціональність: 
--■ Повернути ПІБ всіх барберів салону. 
--■ Повернути інформацію про всіх синьйор-барберів. 
--■ Повернути інформацію про всіх барберів, які можуть надати послугу ручної стрижки. 
--■ Повернути інформацію про всіх барберів, які можуть надати конкретну послугу. Інформація про потрібну послугу надається як параметр.
--■ Повернути інформацію про всіх барберів, які працюють понад зазначену кількість років. Кількість років передається як параметр. 
--■ Повернути кількість синьйор-барберів та кількість джуніор-барберів. 
--■ Повернути інформацію про постійних клієнтів. Критерій постійного клієнта: був у салоні задану кількість разів. Кількість передається як параметр. 
--■ Заборонити можливість видалення інформації про чиф-барбер, якщо не додано другий чиф-барбер
--■ Заборонити додавати барберів молодше 21 року

--Функції користувача
--Створіть наступні функції користувача: 
--■ Функція користувача повертає вітання в стилі «Hello, ІМ'Я!» Де ІМ'Я передається як параметр. Наприклад, якщо передали Nick, то буде Hello, Nick! 
--■ Функція користувача повертає інформацію про поточну кількість хвилин; 
--■ Функція користувача повертає інформацію про поточний рік; 
--■ Функція користувача повертає інформацію про те: парний або непарний рік; 
--■ Функція користувача приймає число і повертає yes, якщо число просте і no, якщо число не просте; 
--■ Функція користувача приймає як параметри п'ять чисел. Повертає суму мінімального та максимального значення з переданих п'яти параметрів;
--■ Функція користувача показує всі парні або непарні числа в переданому діапазоні. Функція приймає три параметри: початок діапазону, кінець діапазону, парне чи непарне показувати.

--Збережені процедури
--Створіть наступні збережені процедури: 
--■ Збережена процедура виводить «Hello, world!»; 
--■ Збережена процедура повертає інформацію про поточний час; 
--■ Збережена процедура повертає інформацію про поточну дату; 
--■ Збережена процедура приймає три числа і повертає їхню суму; 
--■ Збережена процедура приймає три числа і повертає середньоарифметичне трьох чисел; 
--■ Збережена процедура приймає три числа і повертає максимальне значення; 
--■ Збережена процедура приймає три числа і повертає мінімальне значення; 
--■ Збережена процедура приймає число та символ. 
--В результаті роботи збереженої процедури відображається  лінія довжиною, що дорівнює числу. Лінія побудована із символу, вказаного у другому параметрі. 
--Наприклад, якщо було передано 5 та #, ми отримаємо лінію такого виду #####; 
--■ Збережена процедура приймає як параметр число і повертає його факторіал. 
--Формула розрахунку факторіалу: n! = 1 * 2 * ... n. Наприклад, 3! = 1 * 2 * 3 = 6; 
--■ Збережена процедура приймає два числові параметри. Перший параметр – це число. 
--Другий параметр – це ступінь. Процедура повертає число, зведене до ступеня. 
--Наприклад, якщо параметри дорівнюють 2 і 3, тоді повернеться 2 у третьому ступені, тобто 8.

--В ДЗ надіслати SQL файл, який виконує всі необхідні дії. 
--Кожній частині скрипта додати коментар з поясненнями того, що робить скрипт.

--Додаткове завдання: 
--До бази "барбершоп" з попередньої домашньої роботи додати:
--■ Створіть набір clustered (кластеризованих) індексів для тих таблиць, де це необхідно;
--■ Створіть набір nonclustered (некластеризованих) індексів для тих таблиць, де це необхідно;
--■ Вирішіть чи потрібні вам composite (композитні) індекси з урахуванням структури бази даних та запитів. Якщо так, створіть індекси;
--■ Вирішіть чи потрібні вам indexes with included columns (індекси з увімкненими стовпцями). Враховуйте структуру бази даних та запитів. Якщо потреба є, створіть індекси;
--■ Вирішіть, чи потрібні вам filtered indexes (відфільтровані індекси). Враховуйте структуру бази даних та запитів. Якщо потреба є, створіть індекси;
--■ Перевірте execution plans (плани виконання) для найважливіших запитів щодо частоти їх використання. Якщо знайдено слабке місце за продуктивністю, спробуйте вирішити цю проблему за допомогою створення нових індексів.

--<-------------------------------------------------------->--
--Створення таблиць 
--<-------------------------------------------------------->--
USE [master]

IF EXISTS(SELECT *
          FROM [sys].[databases]
          WHERE [name] = 'Barbershop')
BEGIN
    ALTER DATABASE [Barbershop]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE [Barbershop]
END

CREATE DATABASE [Barbershop]
GO
USE [Barbershop]

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

--Створюю таблицю зі зберігання статі
IF OBJECT_ID(N'Genders', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Genders]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(30) NOT NULL,

        CONSTRAINT [PK_Gender_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_Gender_Name] UNIQUE([Name]),
        CONSTRAINT [CK_Gender_Name] CHECK([dbo].[get_checked_len]([Name]) > 0)
    )
END

--Створюю таблицю з позиціями барберів
IF OBJECT_ID(N'Positions', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Positions]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(30) NOT NULL,

        CONSTRAINT [PK_Position_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_Position_Name] UNIQUE([Name]),
        CONSTRAINT [CK_Position_Name] CHECK([dbo].[get_checked_len]([Name]) > 0)
    )
END

--Створюю таблицю зі списком послуг
IF OBJECT_ID(N'Services', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Services]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(100) NOT NULL,
        [DurationMinutes] INT NOT NULL DEFAULT(60),
        [Price] MONEY NOT NULL,

        CONSTRAINT [PK_Service_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_Service_Name] UNIQUE([Name]),
        CONSTRAINT [CK_Service_Name] CHECK([dbo].[get_checked_len]([Name]) > 0),
        CONSTRAINT [CK_Service_Duration] CHECK([DurationMinutes] > 0),
        CONSTRAINT [CK_Service_Price] CHECK([Price] > 0.0)
    )
END

--Створюю таблицю з барберами
IF OBJECT_ID(N'Barbers', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Barbers]
    (
        [Id] INT IDENTITY,
        [FirstName] NVARCHAR(100) NOT NULL,
        [MiddleName] NVARCHAR(100),
        [LastName] NVARCHAR(100) NOT NULL,
        [GenderId] INT NOT NULL DEFAULT(0),
        [Phone] NVARCHAR(15) NOT NULL,
        [Email] NVARCHAR(20),
        [BirthDate] DATE,
        [HireDate] DATE NOT NULL DEFAULT(GETDATE()),

        CONSTRAINT [PK_Barber_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Barber_FirstName] CHECK([dbo].[get_checked_len]([FirstName]) > 0),
        CONSTRAINT [CK_Barber_LastName] CHECK([dbo].[get_checked_len]([LastName]) > 0),
        CONSTRAINT [FK_Barbers_To_Genders] FOREIGN KEY([GenderId]) 
                                           REFERENCES [Barbershop].[dbo].[Genders] ([Id])
                                           ON DELETE SET DEFAULT
                                           ON UPDATE CASCADE,
        CONSTRAINT [UQ_Barber_Phone] UNIQUE([Phone]),
        CONSTRAINT [CK_Barber_BirthDate] CHECK([BirthDate] < GETDATE()),
        CONSTRAINT [CK_Barber_HireDate] CHECK([HireDate] <= GETDATE())
    )
END

--Створюю таблицю з позиціями барберів
IF OBJECT_ID(N'BarbersPositions', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[BarbersPositions]
    (
        [Id] INT IDENTITY,
        [BarberId] INT NOT NULL,
        [PositionId] INT NOT NULL,

        CONSTRAINT [PK_BarberPosition_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_BarberPosition_BarberPosition] UNIQUE([BarberId], [PositionId]),
        CONSTRAINT [FK_BarbersPositions_To_Barbers] FOREIGN KEY([BarberId]) 
                                                    REFERENCES [Barbershop].[dbo].[Barbers] ([Id])
                                                    ON DELETE CASCADE
                                                    ON UPDATE CASCADE,
        CONSTRAINT [FK_BarbersPositions_To_Positions] FOREIGN KEY([PositionId]) 
                                                      REFERENCES [Barbershop].[dbo].[Positions] ([Id])
                                                      ON DELETE CASCADE
                                                      ON UPDATE CASCADE
    )
END

--Перевіряємо чи шеф один в системі (максимум 2 при додаванні нового)
IF EXISTS (SELECT  1
            FROM [INFORMATION_SCHEMA].[ROUTINES]
            WHERE Specific_schema = 'dbo'
              AND specific_name = 'sum_chief'
              AND Routine_Type = 'FUNCTION')

  DROP FUNCTION [dbo].[sum_chief]
GO

CREATE FUNCTION [dbo].[sum_chief]
                (
                    @id INT
                )
RETURNS INT
AS
BEGIN
   DECLARE @chiefid INT
   DECLARE @retval INT
   SET @retval = 0

   SELECT @chiefid = [Id] 
   FROM [Barbershop].[dbo].[Positions] 
   WHERE [Name] = 'Chief'

   IF (@id = @chiefid) 
   SELECT @retval = COUNT(*) FROM [Barbershop].[dbo].[BarbersPositions] WHERE [Id] = @chiefid
   
   RETURN @retval
END
GO

ALTER TABLE [Barbershop].[dbo].[BarbersPositions]
ADD CONSTRAINT [CK_BarberPosition_PositionId] CHECK(dbo.sum_chief([PositionId]) <= 2)

--Створюю таблицю зі списком відповідностей барбер - послуга
IF OBJECT_ID(N'BarbersServices', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[BarbersServices]
    (
        [Id] INT IDENTITY,
        [BarberId] INT NOT NULL,
        [ServiceId] INT NOT NULL,

        CONSTRAINT [PK_BarberService_Id] PRIMARY KEY([Id]),
        CONSTRAINT [UQ_BarberService_BarberService] UNIQUE([BarberId], [ServiceId]),
        CONSTRAINT [FK_BarbersServices_To_Barbers] FOREIGN KEY([BarberId]) 
                                                   REFERENCES [Barbershop].[dbo].[Barbers] ([Id])
                                                   ON DELETE CASCADE
                                                   ON UPDATE CASCADE,
        CONSTRAINT [FK_BarbersServices_To_Services] FOREIGN KEY([ServiceId]) 
                                                    REFERENCES [Barbershop].[dbo].[Services] ([Id])
                                                    ON DELETE CASCADE
                                                    ON UPDATE CASCADE
    )
END

--Створюю таблицю з клієнтами
IF OBJECT_ID(N'Clients', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Clients]
    (
        [Id] INT IDENTITY,
        [FirstName] NVARCHAR(100) NOT NULL,
        [MiddleName] NVARCHAR(100),
        [LastName] NVARCHAR(100) NOT NULL,
        [Phone] NVARCHAR(15) NOT NULL,
        [Email] NVARCHAR(20),

        CONSTRAINT [PK_Client_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Client_FirstName] CHECK([dbo].[get_checked_len]([FirstName]) > 0),
        CONSTRAINT [CK_Client_LastName] CHECK([dbo].[get_checked_len]([LastName]) > 0),
        CONSTRAINT [UQ_Client_Phone] UNIQUE([Phone])
    )
END

--Створюю таблицю з оцінками
IF OBJECT_ID(N'Values', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Values]
    (
        [Id] INT IDENTITY,
        [Rating] INT NOT NULL,
        [Describe] NVARCHAR(20) NOT NULL,

        CONSTRAINT [PK_Value_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Value_Rating] CHECK([Rating] > 0 AND [Rating] < 7),
        CONSTRAINT [UQ_Value_Rating] UNIQUE([Rating]),
        CONSTRAINT [UQ_Value_Describe] UNIQUE([Describe])
    )
END

--Створюю таблицю розкладів вільних слотів
IF OBJECT_ID(N'Freeslots', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Freeslots]
    (
        [Id] INT IDENTITY,
        [Date] DATE NOT NULL DEFAULT(GETDATE()),
        [StartTime] TIME(0) NOT NULL DEFAULT('9:00'),
        [EndTime] TIME(0) NOT NULL DEFAULT('18:00'),

        CONSTRAINT [PK_Freeslot_Id] PRIMARY KEY([Id]),
        --CONSTRAINT [CK_Freeslot_Date] CHECK(DATEDIFF(DAY, GETDATE(), [Date]) >= 0),
        CONSTRAINT [UQ_Freeslot_DateTime] UNIQUE([Date], [StartTime], [EndTime]),
        CONSTRAINT [CK_Freeslot_StartTime] CHECK([StartTime] < [EndTime]),
        CONSTRAINT [CK_Freeslot_EndTime] CHECK([EndTime] > [StartTime])
    )
END

--Повертаємо час виконання для послуги
IF EXISTS (SELECT  1
            FROM [INFORMATION_SCHEMA].[ROUTINES]
            WHERE Specific_schema = 'dbo'
              AND specific_name = 'get_duration'
              AND Routine_Type = 'FUNCTION')

  DROP FUNCTION [dbo].[get_duration]
GO

CREATE FUNCTION [dbo].[get_duration]
                (
                    @id INT
                )
RETURNS INT
AS
BEGIN
   DECLARE @retval INT

   SELECT @retval = [DurationMinutes] FROM [Barbershop].[dbo].[Services] WHERE [Id] = @id
   
   RETURN @retval
END
GO

--Створюю таблицю розкладів зайнятих слотів для клієнтів та барберів
IF OBJECT_ID(N'Busyslots', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Busyslots]
    (
        [Id] INT IDENTITY,
        [BarberId] INT NOT NULL,
        [ClientId] INT NOT NULL,
        [ServiceId] INT NOT NULL,
        [Date] DATE NOT NULL DEFAULT(GETDATE()),
        [StartTime] TIME(0) NOT NULL,
        [EndTime] TIME(0) NOT NULL,        

        CONSTRAINT [PK_Busyslot_Id] PRIMARY KEY([Id]),
        --CONSTRAINT [CK_Busyslot_Date] CHECK(DATEDIFF(DAY, GETDATE(), [Date]) >= 0),
        CONSTRAINT [FK_Busyslots_To_Barbers] FOREIGN KEY([BarberId]) 
                                             REFERENCES [Barbershop].[dbo].[Barbers] ([Id])
                                             ON DELETE CASCADE
                                             ON UPDATE CASCADE,
        CONSTRAINT [FK_Busyslots_To_Clients] FOREIGN KEY([ClientId]) 
                                             REFERENCES [Barbershop].[dbo].[Clients] ([Id])
                                             ON DELETE CASCADE
                                             ON UPDATE CASCADE,
        CONSTRAINT [FK_Busyslots_To_Services] FOREIGN KEY([ServiceId]) 
                                              REFERENCES [Barbershop].[dbo].[Services] ([Id])
                                              ON DELETE CASCADE
                                              ON UPDATE CASCADE,
    )
END

--Створюю процедуру для перевірки чи вільний для даного барбера часовий слот запису
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'check_busyslot')
              AND TYPE IN (N'P', N'PC'))

  DROP PROCEDURE [dbo].[check_busyslot]
GO

CREATE PROCEDURE [dbo].[check_busyslot]               
                    @setstarttime TIME(0), 
                    @setendtime TIME(0),
                    @date DATE,
                    @barberid INT               
AS
BEGIN
DECLARE @retval AS INT, @cntFree AS INT, @cntBusy AS INT

    SET @retval = 0

    SELECT @cntFree = COUNT(*)
    FROM 
        [Barbershop].[dbo].[Freeslots] AS free
    WHERE 
        (@setstarttime >= free.[StartTime] AND @setendtime<= free.[EndTime])
        AND @date = free.[Date]

    SELECT @cntBusy = COUNT(*)
    FROM 
        [Barbershop].[dbo].[Busyslots] AS busy
    WHERE 
        (@setstarttime >= busy.[StartTime] AND @setendtime <= busy.[EndTime])
        AND @date = busy.[Date]
        AND @barberid = busy.[BarberId]

    IF @cntFree > 0 AND @cntBusy <= 1
    BEGIN
        SET @retVal = @cntFree
    END

RETURN @retval
END
GO

--Створюю тригер, який запускатиме перевірку нового запису
--на перетин по часу з уже існуючими записами
IF EXISTS (SELECT  *
            FROM [sys].[triggers]
            WHERE [name] = N'Busyslots_AFTER_INSERT_UPDATE'
            )

  DROP TRIGGER [dbo].[Busyslots_AFTER_INSERT_UPDATE]
GO

CREATE TRIGGER [dbo].[Busyslots_AFTER_INSERT_UPDATE]
ON [Barbershop].[dbo].[Busyslots]
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @starttime AS TIME(0), @endtime AS TIME(0), @checkresult AS INT,
            @barberid AS INT, @date AS DATE

    SELECT @starttime = i.[StartTime], @endtime = i.[EndTime], @barberid = i.[BarberId], @date = i.[Date]
    FROM INSERTED i

    EXEC @checkresult = [dbo].[check_busyslot] @starttime, @endtime, @date, @barberid

    IF @checkresult <= 0 
    BEGIN    
        RAISERROR('This time period has been already busy', 16, 1)
        ROLLBACK
        RETURN
    END

    IF NOT EXISTS(SELECT * 
                  FROM [Barbershop].[dbo].[Feedbacks] AS fb
                  LEFT JOIN INSERTED AS new ON new.[Id] = fb.[BusyslotId])
        INSERT INTO [Barbershop].[dbo].[Feedbacks]([BusyslotId])
        SELECT ([Id])
        FROM INSERTED
END
GO

--Тимчасова таблиця для передачі фідбеків до архіву
IF OBJECT_ID('tempdb..##FeedbackInfo') IS NOT NULL 
    DROP TABLE ##FeedbackInfo

CREATE TABLE ##FeedbackInfo
(
    ValueId INT, 
    FeedBackDescribe  NVARCHAR(MAX), 
    BusyslotId INT
)

--Створюю тригер, який запускатиме передачу в архів
IF EXISTS (SELECT  *
            FROM [sys].[triggers]
            WHERE [name] = N'Busyslots_AFTER_DELETE'
            )

  DROP TRIGGER [dbo].[Busyslots_AFTER_DELETE]
GO

CREATE TRIGGER [dbo].[Busyslots_AFTER_DELETE]
ON [Barbershop].[dbo].[Busyslots]
FOR DELETE
AS
BEGIN
    INSERT INTO [Barbershop].[dbo].[Archives]([BarberId], [BarberFirstName], [BarberMiddleName], [BarberLastName], [BarberPhone], [BarberEmail],
                                              [ClientId], [ClientFirstName], [ClientMiddleName], [ClientLastName], [ClientPhone], [ClientEmail],
                                              [ServiceId], [ServiceName], [Date], [Cost], [Rating], [RatingDescrip], [Feedback])
    SELECT del.[BarberId], barb.[FirstName], barb.[MiddleName], barb.[LastName], barb.[Phone], barb.[Email], 
           del.[ClientId], client.[FirstName], client.[MiddleName], client.[LastName], client.[Phone], client.[Email],
           del.[ServiceId], serv.[Name], del.[Date], serv.[Price], val.[Rating], val.[Describe], fb.[FeedBackDescribe]
    FROM DELETED AS del
            LEFT JOIN ##FeedbackInfo AS fb ON fb.[BusyslotId] = del.[Id]
            LEFT JOIN [Barbershop].[dbo].[Barbers] AS barb ON barb.[Id] = del.[BarberId]
            LEFT JOIN [Barbershop].[dbo].[Clients] AS client ON client.[Id] = del.[ClientId]
            LEFT JOIN [Barbershop].[dbo].[Values] AS val ON val.[Id] = fb.[ValueId]
            LEFT JOIN [Barbershop].[dbo].[Services] AS serv ON serv.[Id] = del.[ServiceId]
END
GO

--Створюю таблицю з фідбеками i оцінками
IF OBJECT_ID(N'Feedbacks', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Feedbacks]
    (
        [Id] INT IDENTITY,        
        [BusyslotId] INT NOT NULL,
        [ValueId] INT NOT NULL DEFAULT(6),
        [Describe] NVARCHAR(MAX) DEFAULT(''),

        CONSTRAINT [PK_Feedback_Id] PRIMARY KEY([Id]),
        CONSTRAINT [FK_Feedbacks_To_Busyslots] FOREIGN KEY([BusyslotId]) 
                                               REFERENCES [Barbershop].[dbo].[Busyslots] ([Id])
                                               ON DELETE CASCADE
                                               ON UPDATE CASCADE,
        CONSTRAINT [FK_Feedbacks_To_Values] FOREIGN KEY([ValueId]) 
                                            REFERENCES [Barbershop].[dbo].[Values] ([Id])
                                            ON DELETE CASCADE
                                            ON UPDATE CASCADE
    )
END

--Створюю тригер, який запускатиме передачу в архів
IF EXISTS (SELECT  *
            FROM [sys].[triggers]
            WHERE [name] = N'Feedbacks_AFTER_DELETE'
            )

  DROP TRIGGER [dbo].[Feedbacks_AFTER_DELETE]
GO

CREATE TRIGGER [dbo].[Feedbacks_AFTER_DELETE]
ON [Barbershop].[dbo].[Feedbacks]
FOR DELETE
AS
BEGIN
    INSERT INTO ##FeedbackInfo
    SELECT del.[ValueId], del.[Describe], del.[BusyslotId]
    FROM DELETED AS del
END
GO

--Створюю таблицю архіву
IF OBJECT_ID(N'Archives', N'U') IS NULL
BEGIN
    CREATE TABLE [Barbershop].[dbo].[Archives]
    (
        [Id] INT IDENTITY,
        [BarberId] INT,
        [BarberFirstName] NVARCHAR(100),
        [BarberMiddleName] NVARCHAR(100),
        [BarberLastName] NVARCHAR(100),
        [BarberPhone] NVARCHAR(15),
        [BarberEmail] NVARCHAR(20),
        [ClientId] INT,
        [ClientFirstName] NVARCHAR(100),
        [ClientMiddleName] NVARCHAR(100),
        [ClientLastName] NVARCHAR(100),
        [ClientPhone] NVARCHAR(15),
        [ClientEmail] NVARCHAR(20),
        [ServiceId] INT,
        [ServiceName] NVARCHAR(100),
        [Date] DATE,
        [Cost] MONEY,
        [Rating] INT,
        [RatingDescrip] NVARCHAR(10),
        [Feedback] NVARCHAR(MAX),

        CONSTRAINT [PK_Archive_Id] PRIMARY KEY([Id])
    )
END

--<-------------------------------------------------------->--
--Додавання даних до таблиць
--<-------------------------------------------------------->--
--Наповнюю таблицю статі
INSERT
INTO [Barbershop].[dbo].[Genders]
VALUES ('UNDEF'),
       ('MALE'),
       ('FEMALE')

--Наповнюю таблицю з посадами
INSERT
INTO [Barbershop].[dbo].[Positions]
VALUES ('Chief'),
       ('Senior'),
       ('Junior')

--Наповнюю таблицю зі списком послуг
INSERT
INTO [Barbershop].[dbo].[Services]
VALUES ('Traditional shaving', 30, 250.0),
       ('Hand haircut', 60, 400.0),
       ('Haircut with a machine', 20, 200.0),
       ('Mustache and beard trimming', 70, 550.0)

--Наповнюю таблицю з барберами
INSERT
INTO [Barbershop].[dbo].[Barbers]
VALUES('Grant', NULL, 'Williams', 2, '0123654789', NULL, '1993-03-10', '2018-10-01'),
      ('Bruce', 'Scoot', 'Brown', 2, '0215487963', 'gera@mail.com', '1998-06-17', '2021-03-21'), 
      ('Markelle', NULL, 'Fultz', 2, '0321456987', 'mf1@mail.com', '1985-11-01', '2015-12-13'), 
      ('Jordan', 'Williams', 'Poole', 1, '0987456321', NULL, '2001-07-18', '2020-02-18'), 
      ('Lisa', 'Walker', 'Kessler', 3, '0852369741', 'sila@mail.com', '2005-11-11', '2022-05-07'),
      ('Kevin', NULL, 'Huerter', 2, '0789654123', 'keva@mail.com', '1999-09-12', '2023-05-19') 

--Наповнюю таблицю з позиціями барберів
INSERT
INTO [Barbershop].[dbo].[BarbersPositions]
VALUES (1, 1),
       (2, 3),
       (3, 2),
       (4, 2),
       (5, 3),
       (6, 3)

--Наповнюю таблицю зі списком відповідностей барбер - послуга
INSERT
INTO [Barbershop].[dbo].[BarbersServices]
VALUES (1, 1),
       (1, 2),
       (1, 3),
       (1, 4),
       (2, 3),
       (2, 4),
       (3, 1),
       (3, 2),
       (3, 3),
       (3, 4),
       (4, 1),
       (4, 2),
       (4, 3),
       (4, 4),
       (5, 3),
       (5, 4),
       (6, 2),
       (6, 4)

--Наповнюю таблицю з клієнтами
INSERT
INTO [Barbershop].[dbo].[Clients]
VALUES('Herbert', 'Alperen', 'Jones', '0123654789', NULL),
      ('Jaden', NULL, 'McDaniels', '0852369741', 'mail@mail.com'), 
      ('Nicolas', 'York', 'Claxton', '0654789321', NULL), 
      ('Scottie', 'Doe', 'Barnes', '0321456987', NULL), 
      ('Austin', 'McEnen', 'Reaves', '0254789631', 'amr@mail.com'), 
      ('Derrick', NULL, 'White', '0987564123', NULL), 
      ('Rudy', NULL, 'Gobert', '0745698231', 'my@mail.com'), 
      ('Paolo', NULL, 'Banchero', '0564978312', 'pb@mail.go'), 
      ('Cade', NULL, 'Cunningham', '0286459713', 'cun@mail.us'), 
      ('Lauri', 'Joseph', 'Markkanen', '0491325687', NULL)

--Наповнюю таблицю з оцінками
INSERT
INTO [Barbershop].[dbo].[Values]
VALUES (1, 'VERY BAD'),
       (2, 'BAD'),
       (3, 'NORMAL'),
       (4, 'GOOD'),
       (5, 'VERY GOOD'),
       (6, 'UNVALUED')

--Наповнюю таблицю розкладів вільних слотів
INSERT
INTO [Barbershop].[dbo].[Freeslots]
VALUES ('2023-10-12', '9:00', '13:00'),
       ('2023-10-12', '14:00', '17:00'),
       ('2023-10-13', '9:00', '13:00'),
       ('2023-10-13', '14:00', '18:00'),
       ('2023-10-14', '9:00', '14:00'),
       ('2023-10-15', '9:00', '13:00')

--Наповнюю таблицю розкладів зайнятих слотів для клієнтів та барберів
INSERT
INTO [Barbershop].[dbo].[Busyslots]
VALUES (2, 10, 3, '2023-10-12', '11:00', DATEADD(MINUTE, [dbo].[get_duration](3), '11:00')),
       (6, 5, 1, '2023-10-12', '9:00', DATEADD(MINUTE, [dbo].[get_duration](1), '9:00')),
       (3, 2, 2, '2023-10-13', '10:00', DATEADD(MINUTE, [dbo].[get_duration](2), '10:00')),
       (4, 5, 4, '2023-10-14', '11:00', DATEADD(MINUTE, [dbo].[get_duration](4), '11:00')),
       (5, 2, 4, '2023-10-15', '9:00', DATEADD(MINUTE, [dbo].[get_duration](4), '9:00')),
       (6, 2, 1, '2023-10-12', '14:00', DATEADD(MINUTE, [dbo].[get_duration](1), '14:00')),
       (3, 8, 2, '2023-10-13', '14:00', DATEADD(MINUTE, [dbo].[get_duration](2), '14:00')),
       (1, 3, 4, '2023-10-14', '9:30', DATEADD(MINUTE, [dbo].[get_duration](4), '9:30')),
       (4, 2, 3, '2023-10-15', '10:00', DATEADD(MINUTE, [dbo].[get_duration](3), '10:00')),
       (5, 7, 3, '2023-10-12', '15:00', DATEADD(MINUTE, [dbo].[get_duration](3), '15:00')),
       (4, 10, 1, '2023-10-13', '15:00', DATEADD(MINUTE, [dbo].[get_duration](1), '15:00')),
       (3, 2, 4, '2023-10-14', '12:00', DATEADD(MINUTE, [dbo].[get_duration](4), '12:00')),
       (2, 5, 2, '2023-10-13', '16:00', DATEADD(MINUTE, [dbo].[get_duration](2), '16:00')),
       (3, 6, 1, '2023-10-12', '16:00', DATEADD(MINUTE, [dbo].[get_duration](1), '16:00')),
       (1, 1, 2, '2023-10-13', '17:00', DATEADD(MINUTE, [dbo].[get_duration](2), '17:00')),
       (5, 3, 4, '2023-10-14', '12:00', DATEADD(MINUTE, [dbo].[get_duration](4), '12:00')),
       (4, 8, 1, '2023-10-12', '17:00', DATEADD(MINUTE, [dbo].[get_duration](1), '17:00'))

--Наповнюю таблицю з фідбеками i оцінками
UPDATE [Barbershop].[dbo].[Feedbacks]
SET [ValueId] = 5, [Describe] = 'Very cool!!:)'
WHERE [BusyslotId] = 12 
      OR [BusyslotId] = 2
      OR [BusyslotId] = 5
      OR [BusyslotId] = 15
      OR [BusyslotId] = 11
      OR [BusyslotId] = 9
      OR [BusyslotId] = 4
      OR [BusyslotId] = 17
      OR [BusyslotId] = 13

UPDATE [Barbershop].[dbo].[Feedbacks]
SET [ValueId] = 4, [Describe] = 'Not bad but can better'
WHERE [BusyslotId] = 1 
      OR [BusyslotId] = 3
      OR [BusyslotId] = 6
      OR [BusyslotId] = 7
      OR [BusyslotId] = 8
      OR [BusyslotId] = 10
      OR [BusyslotId] = 12

SELECT *
FROM [Barbershop].[dbo].[Feedbacks]

--Наповнюю таблицю архіву через видалення виконаних записів
DELETE [Barbershop].[dbo].[Busyslots]
WHERE [Id] = 1 
      OR [Id] = 9 
      OR [Id] = 10 
      OR [Id] = 14 

SELECT * 
FROM [Barbershop].[dbo].[Archives]

SELECT *
FROM [Barbershop].[dbo].[Feedbacks]

--<-------------------------------------------------------->--
--Виконання завдань
--<-------------------------------------------------------->--
--Використовуючи тригери, функції користувача, збережені процедури реалізував наступну функціональність: 
--■ Повернути ПІБ всіх барберів салону. 
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'get_all_barbers')
              AND TYPE IN (N'P', N'PC'))

  DROP PROCEDURE [dbo].[get_all_barbers]
GO

CREATE PROCEDURE [dbo].[get_all_barbers]
AS
BEGIN
    SELECT *
    FROM [Barbershop].[dbo].[Barbers]
END
GO

EXEC [dbo].[get_all_barbers]

--■ Повернути інформацію про всіх синьйор-барберів. 
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'get_senior_barbers')
              AND TYPE IN (N'P', N'PC'))

  DROP PROCEDURE [dbo].[get_senior_barbers]
GO

CREATE PROCEDURE [dbo].[get_senior_barbers]
AS
BEGIN
    SELECT *
    FROM [Barbershop].[dbo].[Barbers] AS barb
    LEFT JOIN [Barbershop].[dbo].[BarbersPositions] AS barbpos ON barbpos.[BarberId] = barb.[Id]
    LEFT JOIN [Barbershop].[dbo].[Positions] AS pos ON pos.[Id] = barbpos.[PositionId] 
    WHERE pos.[Name] = 'Senior'
END
GO

EXEC [dbo].[get_senior_barbers]

--■ Повернути інформацію про всіх барберів, які можуть надати послугу ручної стрижки. 
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'get_handcutting_barbers')
              AND TYPE IN (N'P', N'PC'))

  DROP PROCEDURE [dbo].[get_handcutting_barbers]
GO

CREATE PROCEDURE [dbo].[get_handcutting_barbers]
AS
BEGIN
    SELECT *
    FROM [Barbershop].[dbo].[Barbers] AS barb
    LEFT JOIN [Barbershop].[dbo].[BarbersServices] AS barbserv ON barbserv.[BarberId] = barb.[Id]
    LEFT JOIN [Barbershop].[dbo].[Services] AS serv ON serv.[Id] = barbserv.[ServiceId] 
    WHERE serv.[Name] = 'Hand haircut'
END
GO

EXEC [dbo].[get_handcutting_barbers]

--■ Повернути інформацію про всіх барберів, які можуть надати конкретну послугу. Інформація про потрібну послугу надається як параметр.
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'get_barbersbyserv')
              AND TYPE IN (N'P', N'PC'))

  DROP PROCEDURE [dbo].[get_barbersbyserv]
GO

CREATE PROCEDURE [dbo].[get_barbersbyserv]
    @servid AS INT
AS
BEGIN
    SELECT *
    FROM [Barbershop].[dbo].[Barbers] AS barb
    LEFT JOIN [Barbershop].[dbo].[BarbersServices] AS barbserv ON barbserv.[BarberId] = barb.[Id]
    LEFT JOIN [Barbershop].[dbo].[Services] AS serv ON serv.[Id] = barbserv.[ServiceId] 
    WHERE serv.[Id] = @servid
END
GO

EXEC [dbo].[get_barbersbyserv] 1

--■ Повернути інформацію про всіх барберів, які працюють понад зазначену кількість років. Кількість років передається як параметр. 
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'get_barbers_by_hire_period')
              AND TYPE IN (N'P', N'PC'))

  DROP PROCEDURE [dbo].[get_barbers_by_hire_period]
GO

CREATE PROCEDURE [dbo].[get_barbers_by_hire_period]
    @years AS INT
AS
BEGIN
    SELECT *
    FROM [Barbershop].[dbo].[Barbers] AS barb
    WHERE DATEDIFF(YEAR, barb.[HireDate], GETDATE())> @years
END
GO

EXEC [dbo].[get_barbers_by_hire_period] 2

--■ Повернути кількість синьйор-барберів та кількість джуніор-барберів. 
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'get_senior_junior')
              AND TYPE IN (N'FN', N'IF', N'TF'))

  DROP FUNCTION [dbo].[get_senior_junior]
GO

CREATE FUNCTION [dbo].[get_senior_junior]()
RETURNS @rettab TABLE
(
    TotalSeniors INT,
    TotalJuniors INT
)
AS
BEGIN
    DECLARE @seniors AS INT, @juniors AS INT

    SELECT @seniors = COUNT(*) 
    FROM [Barbershop].[dbo].[Barbers] AS barb
            LEFT JOIN [Barbershop].[dbo].[BarbersPositions] AS barbpos ON barbpos.[BarberId] = barb.[Id]
            LEFT JOIN [Barbershop].[dbo].[Positions] AS pos ON pos.[Id] = barbpos.[PositionId] 
    WHERE pos.[Name] = 'Senior'

    SELECT @juniors = COUNT(*) 
    FROM [Barbershop].[dbo].[Barbers] AS barb
            LEFT JOIN [Barbershop].[dbo].[BarbersPositions] AS barbpos ON barbpos.[BarberId] = barb.[Id]
            LEFT JOIN [Barbershop].[dbo].[Positions] AS pos ON pos.[Id] = barbpos.[PositionId] 
    WHERE pos.[Name] = 'Junior'

    INSERT INTO @rettab
    SELECT @seniors AS 'Total seniors', @juniors AS 'Total juniors'
RETURN
END
GO

SELECT * FROM [dbo].[get_senior_junior]()

--■ Повернути інформацію про постійних клієнтів. Критерій постійного клієнта: був у салоні задану кількість разів. Кількість передається як параметр. 
IF EXISTS (SELECT  *
            FROM [sys].[objects]
            WHERE object_id = OBJECT_ID(N'get_loyal_clients')
              AND TYPE IN (N'P', N'PC'))

  DROP PROCEDURE [dbo].[get_loyal_clients]
GO

CREATE PROCEDURE [dbo].[get_loyal_clients]
    @timesinbarber AS INT
AS
BEGIN
    DECLARE @temptblarch AS TABLE
    (
        ClientId INT,
        Total INT
    ) 

    DECLARE @temptblbusy AS TABLE
    (
        ClientId INT,
        Total INT
    ) 

    INSERT INTO @temptblarch
    SELECT arch.[ClientId], COUNT(*)
    FROM [Barbershop].[dbo].[Archives] AS arch
    GROUP BY arch.[ClientId]

    INSERT INTO @temptblbusy
    SELECT busy.[ClientId], COUNT(*)
    FROM [Barbershop].[dbo].[Busyslots] AS busy
    GROUP BY busy.[ClientId]

    SELECT *
    FROM [Barbershop].[dbo].[Clients] AS client
    LEFT JOIN @temptblarch AS arch ON arch.[ClientId] = client.[Id]
    LEFT JOIN @temptblbusy AS busy ON busy.[ClientId] = client.[Id]
    WHERE (ISNULL(arch.[Total], 0) + ISNULL(busy.[Total],0)) > @timesinbarber
END
GO

EXEC [dbo].[get_loyal_clients] 3

--■ Заборонити можливість видалення інформації про чиф-барбер, якщо не додано другий чиф-барбер
IF EXISTS (SELECT  *
            FROM [sys].[triggers]
            WHERE [name] = N'BarbersPositions_AFTER_DELETE'
            )

  DROP TRIGGER [dbo].[BarbersPositions_AFTER_DELETE]
GO

CREATE TRIGGER [dbo].[BarbersPositions_AFTER_DELETE]
ON [Barbershop].[dbo].[BarbersPositions]
AFTER DELETE
AS
BEGIN
    DECLARE @countchiefs AS INT

    SELECT @countchiefs = COUNT(*)
    FROM [Barbershop].[dbo].[BarbersPositions] AS barbpos
         LEFT JOIN [Barbershop].[dbo].[Positions] AS pos ON barbpos.[PositionId] = pos.[Id]
    WHERE pos.[Name] = 'Chief'

    IF @countchiefs <= 0
    BEGIN
        ROLLBACK
        RAISERROR('Can not delete chief because there only one', 16, 1)
    END
END
GO

--DELETE [Barbershop].[dbo].[BarbersPositions]
--WHERE [Id] = 1

--SELECT *
--FROM [Barbershop].[dbo].[BarbersPositions]

--SELECT *
--FROM [Barbershop].[dbo].[Barbers]

--DELETE [Barbershop].[dbo].[BarbersPositions]
--WHERE [Id] = 2

--INSERT INTO [Barbershop].[dbo].[BarbersPositions]
--VALUES (2, 1)

--DELETE [Barbershop].[dbo].[BarbersPositions]
--WHERE [Id] = 1

--SELECT *
--FROM [Barbershop].[dbo].[BarbersPositions]

--DELETE [Barbershop].[dbo].[Barbers]
--WHERE [Id] = 1

--SELECT *
--FROM [Barbershop].[dbo].[Barbers]

--■ Заборонити додавати барберів молодше 21 року
IF EXISTS (SELECT  *
            FROM [sys].[triggers]
            WHERE [name] = N'Barbers_AFTER_INSERT_UPDATE'
            )

  DROP TRIGGER [dbo].[Barbers_AFTER_INSERT_UPDATE]
GO

CREATE TRIGGER [dbo].[Barbers_AFTER_INSERT_UPDATE]
ON [Barbershop].[dbo].[Barbers]
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @years AS INT

    SELECT @years = DATEDIFF(YEAR, GETDATE(), ins.[BirthDate])
    FROM INSERTED AS ins
    
    IF @years < 21
    BEGIN
        ROLLBACK
        RAISERROR('Can not insert barber with less than 21 years', 16, 1)
    END
END
GO

--INSERT
--INTO [Barbershop].[dbo].[Barbers]
--VALUES('John', NULL, 'Holt', 2, '0369852147', NULL, '2015-03-10', DEFAULT)

--Функції користувача
--Створив наступні функції користувача: 
--■ Функція користувача повертає вітання в стилі «Hello, ІМ'Я!» Де ІМ'Я передається як параметр. Наприклад, якщо передали Nick, то буде Hello, Nick! 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_welcome'
                  AND [type] IN (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[get_welcome]
GO

CREATE FUNCTION [dbo].[get_welcome]
                (
                    @name NVARCHAR(50)
                )
RETURNS NVARCHAR(100)
AS
BEGIN
    RETURN CONCAT('Hello, ', @name, '!')
END
GO

PRINT  [dbo].[get_welcome]('John')

--■ Функція користувача повертає інформацію про поточну кількість хвилин; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_total_minutes'
                  AND [type] IN (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[get_total_minutes]
GO

CREATE FUNCTION [dbo].[get_total_minutes]()
RETURNS INT
AS
BEGIN
    --RETURN DATEDIFF(MINUTE, '0:0:0', CONVERT(TIME(0),GETDATE()))
    RETURN FORMAT(GETDATE(), 'mm')
END
GO

PRINT  CONCAT('Minutes from start - ', [dbo].[get_total_minutes]())

--■ Функція користувача повертає інформацію про поточний рік; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_total_years'
                  AND [type] IN (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[get_total_years]
GO

CREATE FUNCTION [dbo].[get_total_years]()
RETURNS INT
AS
BEGIN
    --RETURN YEAR(GETDATE())
    RETURN FORMAT(GETDATE(), 'yyyy')
END
GO

PRINT  CONCAT('Years from start - ', [dbo].[get_total_years]())

--■ Функція користувача повертає інформацію про те: парний або непарний рік; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'check_leap_year'
                  AND [type] IN (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[check_leap_year]
GO

CREATE FUNCTION [dbo].[check_leap_year]
                (
                    @year INT
                )
RETURNS NVARCHAR(10)
AS
BEGIN
    RETURN CASE WHEN ((@year & 3) = 0 AND (@year % 25 <> 0 OR @year & 15 = 0)) THEN  'LEAP'
                ELSE 'NORMAL'
           END
END
GO

DECLARE @setyear AS INT

SET @setyear = 1992
PRINT  CONCAT('Year ', @setyear, ' is leap? : ', [dbo].[check_leap_year](@setyear))

SET @setyear = 1999
PRINT  CONCAT('Year ', @setyear, ' is leap? : ', [dbo].[check_leap_year](@setyear))

--■ Функція користувача приймає число і повертає yes, якщо число просте і no, якщо число не просте; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'check_prime_number'
                  AND [type] IN (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[check_prime_number]
GO

CREATE FUNCTION [dbo].[check_prime_number]
                (
                    @inputnum INT
                )
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @counter INT, @isprime INT

    IF @inputnum % 2 = 0 AND @inputnum > 2
        SET @isprime = 0
    ELSE
        SET @isprime = 1

    SET @counter = 3

    WHILE (@counter <= FLOOR(SQRT(@inputnum))) AND (@isprime = 1) 
    BEGIN
        IF @inputnum % @counter = 0
            SET @isprime = 0

        SET @counter = @counter + 2
    END
    
    RETURN CASE WHEN @isprime = 1 THEN 'PRIME'
                ELSE 'NOT PRIME'
           END
END
GO

DECLARE @testnum AS INT
SET @testnum = 1111
PRINT  CONCAT('Number ', @testnum, ' is prime? : ', [dbo].[check_prime_number](@testnum))

SET @testnum = 7
PRINT  CONCAT('Number ', @testnum, ' is prime? : ', [dbo].[check_prime_number](@testnum))

--■ Функція користувача приймає як параметри п'ять чисел. Повертає суму мінімального та максимального значення з переданих п'яти параметрів;
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_sum_min_max'
                  AND [type] IN (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[get_sum_min_max]
GO

CREATE FUNCTION [dbo].[get_sum_min_max]
                (
                    @inputnum1 INT,
                    @inputnum2 INT,
                    @inputnum3 INT,
                    @inputnum4 INT,
                    @inputnum5 INT
                )
RETURNS INT
AS
BEGIN
    DECLARE @tmptab AS TABLE
    (
        Num INT
    )

    INSERT INTO @tmptab
    VALUES (@inputnum1),
           (@inputnum2),
           (@inputnum3),
           (@inputnum4),
           (@inputnum5)

    RETURN (SELECT MIN(Num) FROM @tmptab) + (SELECT MAX(Num) FROM @tmptab)
END
GO

DECLARE @testnum1 AS INT, @testnum2 AS INT , @testnum3 AS INT, @testnum4 AS INT, @testnum5 AS INT
SET @testnum1 = 1
SET @testnum2 = 2
SET @testnum3 = 3
SET @testnum4 = 4
SET @testnum5 = 5

PRINT  CONCAT('Sum of max and min values for nambers ', @testnum1, ', ',@testnum2, ', ',@testnum3, ', ',@testnum4, ', ',@testnum5, ': ' , [dbo].[get_sum_min_max](@testnum1,
                                                                                                                                                                  @testnum2,
                                                                                                                                                                  @testnum3,
                                                                                                                                                                  @testnum4,
                                                                                                                                                                  @testnum5))

SET @testnum1 = 10
SET @testnum2 = 2
SET @testnum3 = -1
SET @testnum4 = 4
SET @testnum5 = 100

PRINT  CONCAT('Sum of max and min values for nambers ', @testnum1, ', ',@testnum2, ', ',@testnum3, ', ',@testnum4, ', ',@testnum5, ': ' , [dbo].[get_sum_min_max](@testnum1,
                                                                                                                                                                  @testnum2,
                                                                                                                                                                  @testnum3,
                                                                                                                                                                  @testnum4,
                                                                                                                                                                  @testnum5))

--■ Функція користувача показує всі парні або непарні числа в переданому діапазоні. Функція приймає три параметри: початок діапазону, кінець діапазону, парне чи непарне показувати.
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'show_even_odd'
                  AND [type] IN (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[show_even_odd]
GO

CREATE FUNCTION [dbo].[show_even_odd]
                (
                    @startrange INT,
                    @endrange INT,
                    @showodd BIT
                )
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @counter AS INT, @retval AS NVARCHAR(MAX)

    IF (@startrange >= @endrange
       OR @startrange <= 0 
       OR @endrange <= 0)
    BEGIN
        RETURN ''
    END

    SET @retval = ''

    IF @startrange % 2 = 0 AND  @showodd = 0
       OR @startrange % 2 <> 0 AND  @showodd = 1
        SET @counter = @startrange
    ELSE
        SET @counter = @startrange + 1

    WHILE @counter <= @endrange
    BEGIN
        SET @retval = CONCAT(@retval, @counter, ' ')
        SET @counter = @counter + 2
    END
    
    RETURN @retval
END
GO

DECLARE @teststart AS INT, @testend AS INT, @testshowodd AS BIT
SET @teststart = 2
SET @testend = 9
SET @testshowodd = 0

PRINT  CONCAT('Show even for range ', @teststart, ' to ', @testend, ': ', [dbo].[show_even_odd](@teststart, @testend, @testshowodd))

SET @teststart = 11
SET @testend = 21
SET @testshowodd = 1

PRINT  CONCAT('Show odd for range ', @teststart, ' to ', @testend, ': ', [dbo].[show_even_odd](@teststart, @testend, @testshowodd))

--Збережені процедури
--Створив наступні збережені процедури: 
--■ Збережена процедура виводить «Hello, world!»; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'show_hello_world'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[show_hello_world]
GO

CREATE PROCEDURE [dbo].[show_hello_world]
AS
PRINT 'Hello world!'
GO

 PRINT('Result of procedure show_hello_world: ')
 EXEC [dbo].[show_hello_world]
 PRINT('=======================================')
 PRINT('')

--■ Збережена процедура повертає інформацію про поточний час; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_current_time'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_current_time]
GO

CREATE PROCEDURE [dbo].[get_current_time]
            @result NVARCHAR(20) OUTPUT
AS
    SET @result = CONVERT(NVARCHAR(20),FORMAT(GETDATE(), 'hh:mm:ss'))
GO

DECLARE @retval AS NVARCHAR(20)

EXEC [dbo].[get_current_time] @retval OUTPUT

PRINT(CONCAT('Result of procedure [show_current_time]: ' , @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура повертає інформацію про поточну дату; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_current_date'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_current_date]
GO

CREATE PROCEDURE [dbo].[get_current_date]
            @result NVARCHAR(20) OUTPUT
AS
    SET @result = FORMAT(GETDATE(), 'yyyy-MM-dd')
GO

DECLARE @retval AS NVARCHAR(20)

EXEC [dbo].[get_current_date] @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_current_date]: ', @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура приймає три числа і повертає їхню суму; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_three_sum'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_three_sum]
GO

CREATE PROCEDURE [dbo].[get_three_sum]
            @num1 INT,
            @num2 INT,
            @num3 INT
AS
    RETURN (@num1 + @num2 + @num3)
GO

DECLARE @retval INT, @num1 INT, @num2 INT, @num3 INT
SET @num1 = 3
SET @num2 = 11
SET @num3 = 18

EXEC @retval = [dbo].[get_three_sum] @num1, @num2, @num3

PRINT(CONCAT('Result of procedure [get_three_sum] for ', @num1, ' ', @num2, ' ', @num3, ': ', @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура приймає три числа і повертає середньоарифметичне трьох чисел; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_middle_three_sum'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_middle_three_sum]
GO

CREATE PROCEDURE [dbo].[get_middle_three_sum]
            @num1 INT,
            @num2 INT,
            @num3 INT,
            @result DECIMAL(10, 3) OUTPUT
AS
    SET @result = (@num1 + @num2 + @num3)/3.0
GO

DECLARE @retval DECIMAL(10, 3), @num1 INT, @num2 INT, @num3 INT
SET @num1 = 31
SET @num2 = 47
SET @num3 = 139

EXEC [dbo].[get_middle_three_sum] @num1, @num2, @num3, @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_middle_three_sum] for ', @num1, ' ', @num2, ' ', @num3, ': ', @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура приймає три числа і повертає максимальне значення; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_max_three'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_max_three]
GO

CREATE PROCEDURE [dbo].[get_max_three]
            @num1 DECIMAL(10, 3),
            @num2 DECIMAL(10, 3),
            @num3 DECIMAL(10, 3),
            @result DECIMAL(10, 3) OUTPUT
AS
BEGIN
    DECLARE @tmptbl TABLE
    (
        Num DECIMAL(10, 3)
    )

    INSERT INTO @tmptbl
    VALUES (@num1), (@num2), (@num3)

    SET @result = (SELECT MAX(Num) FROM @tmptbl)
END
GO

DECLARE @retval DECIMAL(10, 3), @num1 DECIMAL(10, 3), @num2 DECIMAL(10, 3), @num3 DECIMAL(10, 3)
SET @num1 = 3.345
SET @num2 = -234.12
SET @num3 = 897.345

EXEC [dbo].[get_max_three] @num1, @num2, @num3, @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_max_three] for ', @num1, ' ', @num2, ' ', @num3, ': ', @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура приймає три числа і повертає мінімальне значення;
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_mmin_three'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_mmin_three]
GO

CREATE PROCEDURE [dbo].[get_mmin_three]
            @num1 DECIMAL(10, 3),
            @num2 DECIMAL(10, 3),
            @num3 DECIMAL(10, 3),
            @result DECIMAL(10, 3) OUTPUT
AS
BEGIN
    DECLARE @tmptbl TABLE
    (
        Num DECIMAL(10, 3)
    )

    INSERT INTO @tmptbl
    VALUES (@num1), (@num2), (@num3)

    SET @result = (SELECT MIN(Num) FROM @tmptbl)
END
GO

DECLARE @retval DECIMAL(10, 3), @num1 DECIMAL(10, 3), @num2 DECIMAL(10, 3), @num3 DECIMAL(10, 3)
SET @num1 = 1234.56
SET @num2 = -16543.999
SET @num3 = 123.98

EXEC [dbo].[get_mmin_three] @num1, @num2, @num3, @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_mmin_three] for ', @num1, ' ', @num2, ' ', @num3, ': ', @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура приймає число та символ. 
--В результаті роботи збереженої процедури відображається  лінія довжиною, що дорівнює числу. Лінія побудована із символу, вказаного у другому параметрі. 
--Наприклад, якщо було передано 5 та #, ми отримаємо лінію такого виду #####; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_string_symbol'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_string_symbol]
GO

CREATE PROCEDURE [dbo].[get_string_symbol]
            @numtimes INT,
            @symbol NVARCHAR(10),
            @result NVARCHAR(MAX) OUTPUT
AS
BEGIN
    DECLARE @counter INT
    SET @counter = 0
    SET @result = ''

    WHILE @counter < @numtimes
    BEGIN
        SET @result = CONCAT(@result, @symbol)
        SET @counter = @counter + 1
    END
END
GO

DECLARE @retval NVARCHAR(MAX), @numtimes INT, @symbol NVARCHAR(10)
SET @numtimes = 7
SET @symbol = '$'

EXEC [dbo].[get_string_symbol] @numtimes, @symbol, @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_string_symbol] for ', @numtimes, ' and ', @symbol, ': ', @retval))
PRINT('=======================================')
PRINT('')

SET @numtimes = 5
SET @symbol = 'oU'

EXEC [dbo].[get_string_symbol] @numtimes, @symbol, @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_string_symbol] for ', @numtimes, ' and ', @symbol, ': ', @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура приймає як параметр число і повертає його факторіал. 
--Формула розрахунку факторіалу: n! = 1 * 2 * ... n. Наприклад, 3! = 1 * 2 * 3 = 6; 
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_factorial'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_factorial]
GO

CREATE PROCEDURE [dbo].[get_factorial]
            @number INT,
            @result DECIMAL(15,0) OUTPUT
AS
BEGIN
    DECLARE @counter INT
    SET @counter = 1
    SET @result = 1

    WHILE @counter <= @number
    BEGIN
        SET @result = @result * @counter
        SET @counter = @counter + 1
    END
END
GO

DECLARE @retval DECIMAL(15,0), @number INT
SET @number = 9

EXEC [dbo].[get_factorial] @number, @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_factorial] for ', @number, ': ', @retval))
PRINT('=======================================')
PRINT('')

--■ Збережена процедура приймає два числові параметри. Перший параметр – це число. 
--Другий параметр – це ступінь. Процедура повертає число, зведене до ступеня. 
--Наприклад, якщо параметри дорівнюють 2 і 3, тоді повернеться 2 у третьому ступені, тобто 8.
IF EXISTS (SELECT *
           FROM [sys].[objects]
           WHERE [name] = N'get_power'
                AND [type] IN (N'PC', N'P'))
    DROP PROCEDURE [dbo].[get_power]
GO

CREATE PROCEDURE [dbo].[get_power]
            @number DECIMAL(9,3),
            @power INT ,
            @result DECIMAL(15,3) OUTPUT
AS
    SET @result = POWER(@number, @power)
GO

DECLARE @retval DECIMAL(15,3), @number FLOAT, @power INT
SET @number = 25.5
SET @power = 2

EXEC [dbo].[get_power] @number, @power, @retval OUTPUT

PRINT(CONCAT('Result of procedure [get_power] for ', @number, ' and ', @power, ': ', @retval))
PRINT('=======================================')
PRINT('')

--Додаткове завдання: 
--До бази "барбершоп" з попередньої домашньої роботи додати:
--■ Створіть набір clustered (кластеризованих) індексів для тих таблиць, де це необхідно;
--Не бачу потреби створювати кластеризовані індекси, оскільки кожна таблиця має первинні ключі

--■ Створіть набір nonclustered (некластеризованих) індексів для тих таблиць, де це необхідно;
SELECT c.[FirstName], c.[LastName], c.[Phone], c.[Email]
FROM [Barbershop].[dbo].[Clients] AS c
WHERE c.[FirstName] = 'Rudy'

DROP INDEX IF EXISTS [ix_Clients_FirstName]
ON [dbo].[Clients]

CREATE INDEX [ix_Clients_FirstName]
ON [dbo].[Clients]([FirstName]);

DROP INDEX IF EXISTS [ix_Barbers_FirstName]
ON [dbo].[Barbers]

CREATE INDEX [ix_Barbers_FirstName]
ON [dbo].[Barbers]([FirstName]);

DROP INDEX IF EXISTS [ix_Services_Name]
ON [dbo].[Services]

CREATE INDEX [ix_Services_Name]
ON [dbo].[Services]([Name]);

SELECT b.[FirstName], b.[LastName], c.[FirstName], c.[LastName], s.[Name]
FROM [Barbershop].[dbo].[Busyslots] AS bs
     LEFT JOIN [Barbershop].[dbo].[Clients] AS c ON bs.[ClientId] = c.[Id]
     LEFT JOIN [Barbershop].[dbo].[Barbers] AS b ON bs.[ClientId] = b.[Id]
     LEFT JOIN [Barbershop].[dbo].[Services] AS s ON s.[Id] = bs.[ServiceId]
WHERE b.[FirstName] = 'Test'
      AND c.[FirstName] = 'Test'

DROP INDEX IF EXISTS [ix_Busyslots_BarberId]
ON [dbo].[Busyslots]

CREATE INDEX [ix_Busyslots_BarberId]
ON [dbo].[Busyslots]([BarberId]);

DROP INDEX IF EXISTS [ix_Busyslots_ClientId]
ON [dbo].[Busyslots]

CREATE INDEX [ix_Busyslots_ClientId]
ON [dbo].[Busyslots]([ClientId]);

DROP INDEX IF EXISTS [ix_Busyslots_ServiceId]
ON [dbo].[Busyslots]

CREATE INDEX [ix_Busyslots_ServiceId]
ON [dbo].[Busyslots]([ServiceId]);

--■ Вирішіть чи потрібні вам composite (композитні) індекси з урахуванням структури бази даних та запитів. Якщо так, створіть індекси;
--■ Вирішіть чи потрібні вам indexes with included columns (індекси з увімкненими стовпцями). Враховуйте структуру бази даних та запитів. Якщо потреба є, створіть індекси;
--■ Вирішіть, чи потрібні вам filtered indexes (відфільтровані індекси). Враховуйте структуру бази даних та запитів. Якщо потреба є, створіть індекси;
--■ Перевірте execution plans (плани виконання) для найважливіших запитів щодо частоти їх використання. Якщо знайдено слабке місце за продуктивністю, спробуйте вирішити цю проблему за допомогою створення нових індексів.

