--<-------------------------------------------------------->--
--Завдання
--<-------------------------------------------------------->--
--Увага! 
--У цій версії бази даних "Лікарня" є додаткові таблиці. 
--Будь ласка, створіть нову версію бази даних або змініть існуючу додавши нові таблиці та нові колонки в існуючі таблиці.

--База даних Лікарня (Hospital) містить інформацію про лікарів та пожертвування.
--Лікарі, які працюють у лікарні, представлені у вигляді таблиці Лікарі (Doctors), в якій зібрано основну інформацію: ім’я, прізвище, зарплата. 
--Спеціалізації лікарів представлені у вигляді таблиць Спеціалізації (Specializations) та Лікарі та спеціалізації (DoctorsSpecializations). 
--Також у базі даних є інформацію про відпустки лікарів, яка міститься в таблиці Відпустки (Vacations).
--Дані про спонсорів та пожертвування зберігаються в таблицях Спонсори (Sponsors) та Пожертвування (Donations) відповідно.
--Також у базі даних міститься інформація про палати лікарні в таблиці Палати (Wards), які тісно пов’язані з відділеннями, де вони розташовуються, та представлені таблицею Відділення (Departments).

--Нижче наведено детальний опис структури кожної таблиці.

--- Відділення (Departments)
--■ Ідентифікатор (Id). Унікальний ідентифікатор відділення.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Назва (Name). Назва відділення.
--▷ Тип даних — nvarchar(100).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.
--▷ Має бути унікальною.

--- Лікарі (Doctors)
--■ Ідентифікатор (Id). Унікальний ідентифікатор лікаря.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Ім’я (Name). Ім’я лікаря.
--▷ Тип даних — nvarchar(max).
--▷ Не містить null-значення.
--▷ Не може бути порожнє.
--■ Надбавка (Premium). Надбавка лікаря.
--▷ Тип даних для зберігання грошових значень.
--▷ Не містить null-значення.
--▷ Не може бути менше, ніж 0.
--▷ Значення за замовчуванням — 0.
--■ Ставка (Salary). Ставка лікаря.
--▷ Тип даних для зберігання грошових значень.
--▷ Не містить null-значення.
--▷ Не може бути меншою або дорівнювати 0.
--■ Прізвище (Surname). Прізвище лікаря.
--▷ Тип даних — nvarchar(max).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.

--- Спеціалізації (Specializations)
--■ Ідентифікатор (Id). Унікальний ідентифікатор спеціалізації.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Назва (Name). Назва спеціалізації.
--▷ Тип даних — nvarchar(100).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.
--▷ Має бути унікальною.

--- Лікарі та спеціалізації (DoctorsSpecializations)
--■ Ідентифікатор (Id). Унікальний ідентифікатор лікаря та спеціалізації.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Ідентифікатор лікаря (DoctorId). Лікар.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Зовнішній ключ.
--■ Ідентифікатор спеціалізації (SpecializationId). Спеціалізація.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Зовнішній ключ.

--- Спонсори (Sponsors)
--■ Ідентифікатор (Id). Унікальний ідентифікатор спонсора.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Назва (Name). Назва спонсора.
--▷ Тип даних — nvarchar(100).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.
--▷ Має бути унікальною.

--- Пожертвування (Donations)
--■ Ідентифікатор (Id). Унікальний ідентифікатор пожертвування.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Сума (Amount). Сума пожертвування.
--▷ Тип даних для зберігання грошових значень.
--▷ Не містить null-значення.
--▷ Не може бути меншою або дорівнювати 0.
--■ Дата (Date). Дата пожертвування.
--▷ Тип даних для зберігання дати.
--▷ Не містить null-значення.
--▷ Не може бути більшою за поточну дату.
--▷ Значення за замовчуванням — поточна дата.
--■ Ідентифікатор відділення (DepartmentId). Відділення, якому було надано пожертвування.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Зовнішній ключ.
--■ Ідентифікатор спонсора (SponsorId). Спонсор, який зробив пожертвування.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Зовнішній ключ.

--- Відпустки (Vacations)
--■ Ідентифікатор (Id). Унікальний ідентифікатор відпустки.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Дата завершення (EndDate). Дата завершення відпустки.
--▷ Тип даних для зберігання дати.
--▷ Не містить null-значення.
--▷ Має бути більшою за дату початку відпустки.
--■ Дата початку (StartDate). Дата початку відпустки.
--▷ Тип даних для зберігання дати.
--▷ Не містить null-значення.
--■ Ідентифікатор лікаря (DoctorId). Лікар, який у відпустці.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Зовнішній ключ.

--- Палати (Wards)
--■ Ідентифікатор (Id). Унікальний ідентифікатор.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Назва (Name). Назва палати.
--▷ Тип даних — nvarchar(20).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.
--▷ Має бути унікальною.
--■ Ідентифікатор відділення (DepartmentId). Відділення, де знаходиться палата.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Зовнішній ключ.

--Виконайте запити:
--1. Виведіть повні імена лікарів та їх спеціалізації.
--2. Виведіть прізвища та зарплати (сума ставки та надбавки) лікарів, які не перебувають у відпустці.
--3. Виведіть назви палат, які знаходяться у відділенні «DRFT».
--4. Виведіть назви відділень без повторень, які спонсоруються компанією «Umbrella Corporation».
--5. Виведіть усі пожертвування за останній місяць у вигляді: відділення, спонсор, сума пожертвування, дата пожертвування.
--6. Виведіть прізвища лікарів із зазначенням відділень, в яких вони проводять обстеження. Враховуйте обстеження, які проводяться лише у будні дні.
--7. Виведіть назви палат і корпуси відділень, в яких проводить обстеження лікар «Helen Williams».
--8. Виведіть назви відділень, які отримували пожертвування у розмірі понад 100000, із зазначенням їх лікарів.
--9. Виведіть назви відділень, в яких лікарі не отримують надбавки.
--10. Виведіть назви спеціалізацій, які беруть участь у лікуванні захворювань із ступенем тяжкості вище 3.
--11. Виведіть назви відділень і назви захворювань, обстеження з яких вони проводили за останні півроку.
--12. Виведіть назви відділень і назви палат, в яких проводилися обстеження із заразних захворювань.

--<-------------------------------------------------------->--
--Створення даних
--<-------------------------------------------------------->--
USE [master]

IF EXISTS(SELECT *
          FROM [sys].[databases]
          WHERE [name] = 'Hospital')
BEGIN
    ALTER DATABASE [Hospital]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE [Hospital]
END

CREATE DATABASE [Hospital]
GO
USE [Hospital]

IF OBJECT_ID(N'[Hospital].[dbo].[Departments]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Departments]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(100) NOT NULL,

        CONSTRAINT [PK_Department_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Department_Name] CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT [UQ_Department_Name] UNIQUE([Name])
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Doctors]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Doctors]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(MAX) NOT NULL,
        [Premium] MONEY NOT NULL DEFAULT 0.0,
        [Salary] MONEY NOT NULL,
        [Surname] NVARCHAR(MAX) NOT NULL,

        CONSTRAINT [PK_Doctor_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Doctor_Name] CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT [CK_Doctor_Premium] CHECK([Premium] >= 0.0),
        CONSTRAINT [CK_Doctor_Salary] CHECK([Salary] > 0.0),
        CONSTRAINT [CK_Doctor_Surname] CHECK(LEN(TRIM([Surname])) > 0)
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Specializations]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Specializations]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(100) NOT NULL,

        CONSTRAINT [PK_Specialization_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Specialization_Name] CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT [UQ_Specialization_Name] UNIQUE([Name])
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Diseases]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Diseases]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(100) NOT NULL,
        [Severity] INT NOT NULL DEFAULT 1

        CONSTRAINT [PK_Diseas_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Diseas_Name] CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT [UQ_Diseas_Name] UNIQUE([Name]),
        CONSTRAINT [CK_Diseas_Severity] CHECK ([Severity] > 0)
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[DoctorsSpecializations]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[DoctorsSpecializations]
    (
        [Id] INT IDENTITY,
        [DoctorId] INT NOT NULL,
        [SpecializationId] INT NOT NULL,

        CONSTRAINT [PK_DoctorsSpecialization_Id] PRIMARY KEY([Id]),
        CONSTRAINT [FK_DoctorsSpecializations_To_Doctors] FOREIGN KEY([DoctorId]) 
                                                          REFERENCES [Hospital].[dbo].[Doctors] ([Id]) 
                                                          ON DELETE CASCADE
                                                          ON UPDATE CASCADE,
        CONSTRAINT [FK_DoctorsSpecializations_To_Specializations] FOREIGN KEY([SpecializationId]) 
                                                                  REFERENCES [Hospital].[dbo].[Specializations] (Id)
                                                                  ON DELETE CASCADE
                                                                  ON UPDATE CASCADE
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[DoctorsDepartments]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[DoctorsDepartments]
    (
        [Id] INT IDENTITY,
        [DoctorId] INT NOT NULL,
        [DepartmentId] INT NOT NULL,

        CONSTRAINT [PK_DoctorsDepartment_Id] PRIMARY KEY([Id]),
        CONSTRAINT [FK_DoctorsDepartments_To_Doctors] FOREIGN KEY([DoctorId])
                                                      REFERENCES [Hospital].[dbo].[Doctors]([Id])
                                                      ON DELETE CASCADE
                                                      ON UPDATE CASCADE,
        CONSTRAINT [FK_DoctorsDepartments_To_Departments] FOREIGN KEY ([DepartmentId])
                                                          REFERENCES [Hospital].[dbo].[Departments]([Id])
                                                          ON DELETE CASCADE
                                                          ON UPDATE CASCADE
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[DiseasesSpecializations]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[DiseasesSpecializations]
    (
        [Id] INT IDENTITY,
        [DiseaseId] INT NOT NULL,
        [SpecializationId] INT NOT NULL,

        CONSTRAINT [PK_DiseasesSpecialization_Id] PRIMARY KEY(Id),        
        CONSTRAINT [FK_DiseasesSpecializations_To_Diseases] FOREIGN KEY([DiseaseId])
                                                            REFERENCES [Hospital].[dbo].[Diseases]([Id])
                                                            ON DELETE CASCADE
                                                            ON UPDATE CASCADE,
        CONSTRAINT [FK_DiseasesSpecializations_To_Specializations] FOREIGN KEY([SpecializationId])
                                                                   REFERENCES [Hospital].[dbo].[Specializations]([Id])
                                                                   ON DELETE CASCADE
                                                                   ON UPDATE CASCADE
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Sponsors]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Sponsors]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(100) NOT NULL,

        CONSTRAINT [PK_Sponsor_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Sponsor_Name] CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT [UQ_Sponsor_Name] UNIQUE([Name])
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Donations]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Donations]
    (
        [Id] INT IDENTITY,
        [Amount] MONEY NOT NULL,
        [Date] DATE NOT NULL DEFAULT GETDATE(),
        [DepartmentId] INT NOT NULL,
        [SponsorId] INT NOT NULL,

        CONSTRAINT [PK_Donation_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Donation_Amount] CHECK([Amount] > 0.0),
        CONSTRAINT [CK_Donation_Date] CHECK([Date] <= GETDATE()),
        CONSTRAINT [FK_Donations_To_Departments] FOREIGN KEY([DepartmentId])
                                                 REFERENCES [Hospital].[dbo].[Departments]([Id])
                                                 ON DELETE CASCADE
                                                 ON UPDATE CASCADE,
        CONSTRAINT [FK_Donations_To_Sponsors] FOREIGN KEY([SponsorId])
                                              REFERENCES [Hospital].[dbo].[Sponsors]([Id])
                                              ON DELETE CASCADE
                                              ON UPDATE CASCADE
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Vacations]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Vacations]
    (
        [Id] INT IDENTITY,
        [EndDate] DATE NOT NULL,
        [StartDate] DATE NOT NULL,
        [DoctorId] INT NOT NULL,

        CONSTRAINT [PK_Vacation_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Vacation_EndDate] CHECK([EndDate] > [StartDate]),
        CONSTRAINT [FK_Vacations_To_Doctors] FOREIGN KEY([DoctorId])
                                             REFERENCES [Hospital].[dbo].[Doctors]([Id])
                                             ON DELETE CASCADE
                                             ON UPDATE CASCADE
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Wards]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Wards]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(20) NOT NULL,
        [DepartmentId] INT NOT NULL,

        CONSTRAINT [PK_Ward_Id] PRIMARY KEY([Id]),
        CONSTRAINT [CK_Ward_Name] CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT [UQ_Ward_Name] UNIQUE([Name]),
        CONSTRAINT [FK_Wards_To_Departments] FOREIGN KEY([DepartmentId])
                                             REFERENCES [Hospital].[dbo].[Departments]([Id])
                                             ON DELETE CASCADE
                                             ON UPDATE CASCADE
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Examinations]', N'U') IS NULL
BEGIN
    CREATE TABLE [Hospital].[dbo].[Examinations]
    (
        [Id] INT IDENTITY,
        [Date] DATE DEFAULT GETDATE() NOT NULL,
        [EndTime] TIME(0) NOT NULL,
        [Name] NVARCHAR(100) NOT NULL,
        [StartTime] TIME(0) NOT NULL,
        [WardId] INT NOT NULL,
        [DoctorId] INT NOT NULL,
        [DiseaseId] INT NOT NULL,

        CONSTRAINT [PK_Examination_Id] PRIMARY KEY([Id]),
        --CONSTRAINT [CK_Examination_Date] CHECK([Date] >= GETDATE()),
        CONSTRAINT [CK_Examination_EndTime] CHECK([EndTime] > [StartTime]),
        CONSTRAINT [CK_Examination_Name] CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT [CK_Examination_StartTime] CHECK([StartTime] >= '8:00' AND [StartTime] <= '18:00'),
        CONSTRAINT [FK_Examinations_To_Wards] FOREIGN KEY([WardId]) 
                                              REFERENCES [Hospital].[dbo].[Wards]([Id])
                                              ON DELETE CASCADE
                                              ON UPDATE CASCADE,
        CONSTRAINT [FK_Examinations_To_Doctors] FOREIGN KEY([DoctorId])
                                                REFERENCES [Hospital].[dbo].[Doctors]([Id])
                                                ON DELETE CASCADE
                                                ON UPDATE CASCADE,
        CONSTRAINT [FK_Examinations_To_Diseases] FOREIGN KEY([DiseaseId])
                                                 REFERENCES [Hospital].[dbo].[Diseases]([Id])
                                                 ON DELETE CASCADE
                                                 ON UPDATE CASCADE
    )
END

--Додаємо дані до бази даних
INSERT 
INTO [Hospital].[dbo].[Departments]
VALUES ('DRFT-19'),
       ('JKTE-52'),
       ('DRFT-27'),
       ('LKUT-21'),
       ('MKHG-45'),
       ('LKUT-47'),
       ('JKTE-15'),
       ('MKHG-19')

INSERT 
INTO [Hospital].[dbo].[Doctors]
VALUES ('Alexander', 158.0, 2000.0, 'Fleming'),
       ('Edward', 250.0, 1500.0, 'Jenner'),
       ('William', DEFAULT, 1000.0, 'Osler'),
       ('Helen', 500.0, 1500.0, 'Williams'),
       ('Sigmund', 1500.0, 6000.0, 'Freud'),
       ('Louis', 700.0, 1800.0, 'Pasteur'),
       ('Elizabeth', DEFAULT, 7000.0, 'Blackwell'),
       ('Merit', 300.0, 8100.0, 'Nurse'),
       ('Metrodora', DEFAULT, 4100.0, 'Nanat')
        
INSERT 
INTO [Hospital].[dbo].[Specializations]
VALUES ('MMDF'),
       ('DEFR'),
       ('PLOK'),
       ('MJUY'),
       ('NMHG'),
       ('SRFD')

INSERT 
INTO [Hospital].[dbo].[Diseases]
VALUES  ('Pneumonia', 5),
        ('Polio', 2),
        ('Typhoid', 8),
        ('Common Cold', DEFAULT),
        ('Malaria', 3),
        ('Amoebiasis', 5),
        ('Ascariasis', 8),
        ('Filariasis', 2),
        ('Appendix', 3)

INSERT 
INTO [Hospital].[dbo].[DoctorsSpecializations]
VALUES (1, 3),
       (2, 4),
       (3, 5),
       (4, 6),
       (5, 1),
       (6, 2),
       (7, 6),
       (8, 5),
       (9, 1),
       (1, 5),
       (3, 1),
       (5, 2),
       (7, 4)

INSERT 
INTO [Hospital].[dbo].[DoctorsDepartments]
VALUES (1, 8),
       (2, 7),
       (3, 6),
       (4, 5),
       (5, 4),
       (6, 3),
       (7, 2),
       (8, 1),
       (9, 2),
       (8, 3),
       (7, 4),
       (6, 5)

INSERT 
INTO [Hospital].[dbo].[DiseasesSpecializations]
VALUES (1, 6),
       (2, 5),
       (3, 4),
       (4, 3),
       (5, 2),
       (6, 1),
       (7, 2),
       (8, 3),
       (9, 4),
       (8, 5),
       (7, 6),
       (6, 5),
       (5, 4),
       (4, 3)

INSERT 
INTO [Hospital].[dbo].[Sponsors]
VALUES ('Umbrella Corporation'),
       ('Goodness LLC'),
       ('World in our hands Corp.'),
       ('Dreams supplier LLC'),
       ('Different world Corp.'),
       ('World for people Corporation'),
       ('Together Corporation'),
       ('Unlimited goodness Corp.')

INSERT 
INTO [Hospital].[dbo].[Donations]
VALUES (100000.0, '2022-10-21', 2, 8),
       (120000.0, '2023-02-17', 8, 4),
       (1000000.0, '2023-01-01', 3, 1),
       (90000.0, '2023-06-26', 5, 2),
       (1000.0, '2023-04-20', 5, 3),
       (50000.0, DEFAULT, 1, 5),
       (200000.0, '2023-09-11', 4, 6),
       (210000.0, '2023-09-12', 6, 7),
       (80000.0, '2023-07-14', 7, 3),
       (35000.0, '2023-09-14', 2, 8),
       (2000.0, '2023-06-25', 4, 1),
       (155000.0, DEFAULT, 8, 2),
       (14000.0, '2023-05-03', 1, 4),
       (21000.0, '2023-04-04', 3, 3),
       (121000.0, '2023-05-15', 5, 5),
       (50000.0, '2023-08-02', 4, 6),
       (30000.0, '2023-08-24', 7, 3),
       (40000.0, '2023-08-28', 6, 2),
       (50000.0, '2023-05-13', 3, 6),
       (60000.0, '2023-05-10', 1, 1),
       (70000.0, DEFAULT, 5, 5),
       (180000.0, '2022-12-31', 7, 4),
       (190000.0, '2023-05-23', 4, 1),
       (220000.0, '2023-04-28', 6, 2),
       (225000.0, '2022-11-18', 1, 4),
       (99999.0, DEFAULT, 2, 1)

INSERT 
INTO [Hospital].[dbo].[Vacations]
VALUES ('2023-12-20', '2023-12-10', 2),
       ('2023-9-29', '2023-9-15', 8),
       ('2023-2-15', '2023-2-1', 4),
       ('2023-8-2', '2023-7-20', 7),
       ('2023-9-20', '2023-9-10', 9),
       ('2023-8-17', '2023-8-12', 3),
       ('2023-11-8', '2023-10-29', 5),
       ('2023-11-20', '2023-11-13', 6),
       ('2023-9-21', '2023-9-15', 8),
       ('2023-10-21', '2023-10-12', 4),
       ('2023-4-8', '2023-3-30', 5),
       ('2023-3-28', '2023-3-18', 7),
       ('2023-5-3', '2023-4-25', 3),
       ('2023-6-1', '2023-5-22', 6),
       ('2023-9-25', '2023-9-12', 5)

INSERT 
INTO [Hospital].[dbo].[Wards]
VALUES ('SWS', 2),
       ('DFS', 8),
       ('MNS', 3),
       ('UJS', 5),
       ('MYS', 4),
       ('ERS', 1),
       ('ASS', 6),
       ('OLS', 7),
       ('OLP', 4),
       ('ERP', 2),
       ('DFP', 6),
       ('UJP', 3),
       ('MNP', 7),
       ('ASP', 5),
       ('SWP', 1),
       ('MYP', 8),
       ('OLQ', 3),
       ('ASQ', 1),
       ('ERQ', 5),
       ('MNQ', 8),
       ('UJQ', 4),
       ('SWQ', 6),
       ('DFQ', 7),
       ('MYQ', 2)

INSERT 
INTO [Hospital].[dbo].[Examinations]
VALUES  ('2023-09-11', '9:00', 'E-TFR-324', '8:30', 20, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 9 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 9),
        ('2023-07-3', '14:30', 'E-DFG-12', '14:00', 5, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 8 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 8),
        ('2022-11-10', '11:25', 'E-KMJ-85', '10:10', 14, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 7 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 7),
        ('2023-06-12', '13:10', 'E-OKM-96', '12:15', 2, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 6 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 6),
        ('2023-04-15', '18:00', 'E-ERF-245', '17:00', 7, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 5 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 5),
        ('2023-03-12', '10:20', 'E-CSD-124', '8:00', 22, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 4 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 4),
        ('2023-03-16', '14:10', 'E-PLS-88', '12:13', 21, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 3 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 3),
        ('2023-06-19', '13:15', 'E-WER-14', '11:45', 4, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 2 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 2),
        ('2023-06-24', '16:16', 'E-NJS-758', '14:50', 17, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 1 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 1),
        ('2023-07-21', '15:28', 'E-AVS-444', '13:20', 19, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 2 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 2),
        ('2023-07-25', '12:30', 'E-PLK-157', '12:00', 1, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 3 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 3),
        ('2023-10-12', '17:45', 'E-MKD-517', '16:16', 3, (SELECT TOP 1 [docspec].[DoctorId] 
                                                            FROM [Hospital].[dbo].[DoctorsSpecializations] AS [docspec], 
                                                                [Hospital].[dbo].[DiseasesSpecializations] AS [desspec] 
                                                            WHERE [desspec].[DiseaseId] = 4 AND [docspec].[SpecializationId] = [desspec].[SpecializationId]), 4)

--<-------------------------------------------------------->--
--Опрацювання даних
--<-------------------------------------------------------->--
----1. Виведіть повні імена лікарів та їх спеціалізації
SELECT [doctor].[Name] AS 'Name of Doctor',
       [doctor].[Surname] AS 'Surame of Doctor',
       [spec].[Name] AS 'Specialization of Doctor'
FROM [Hospital].[dbo].[DoctorsSpecializations] AS [ds]
     LEFT JOIN [Hospital].[dbo].[Doctors] AS [doctor] ON [ds].[DoctorId] = [doctor].[Id]
     LEFT JOIN [Hospital].[dbo].[Specializations] AS [spec] ON [ds].[SpecializationId] = [spec].[Id]
ORDER BY [doctor].[Name], [doctor].[Surname]

--2. Виведіть прізвища та зарплати (сума ставки та надбавки) лікарів, які не перебувають у відпустці
SELECT DISTINCT [doctor].[Surname] AS 'Surname of Doctor',
       [doctor].[Id],
       [doctor].[Salary] + [doctor].[Premium] AS 'Salary of Doctor'
FROM [Hospital].[dbo].[Doctors] AS [doctor]
WHERE [doctor].[Id] NOT IN(SELECT [Vacations].[DoctorId]
                           FROM [Hospital].[dbo].[Vacations]
                           WHERE GETDATE() BETWEEN [Vacations].[StartDate] AND [Vacations].[EndDate]
                           )
ORDER BY [doctor].[Surname]

--3. Виведіть назви палат, які знаходяться у відділенні «DRFT»
SELECT [ward].[Name]
FROM [Hospital].[dbo].[Wards] AS [ward]
     LEFT JOIN [Hospital].[dbo].[Departments] AS [dep] ON [dep].[Id] = [ward].[DepartmentId]
WHERE [dep].[Name] LIKE 'DRFT%'
ORDER BY [ward].[Name]

--4. Виведіть назви відділень без повторень, які спонсоруються компанією «Umbrella Corporation»
SELECT DISTINCT [dept].[Name] AS 'Name of Department'
FROM [Hospital].[dbo].[Donations] AS [donat]
     LEFT JOIN [Hospital].[dbo].[Departments] AS [dept] ON [dept].[Id] = [donat].[DepartmentId]
     LEFT JOIN [Hospital].[dbo].[Sponsors] AS [sponsor] ON [sponsor].[Id] = [donat].[SponsorId]
WHERE [sponsor].[Name] = 'Umbrella Corporation'
ORDER BY [dept].[Name]

--5. Виведіть усі пожертвування за останній місяць у вигляді: відділення, спонсор, сума пожертвування, дата пожертвування
SELECT [dept].[Name] AS 'Name of Department',
       [sponsor].[Name] AS 'Name of Sponsor',
       [donat].[Amount] AS 'Amount od donation',
       [donat].[Date] AS 'Date of donation',
       DATEDIFF(DAY, [donat].[Date], GETDATE()) AS 'Period'
FROM [Hospital].[dbo].[Donations] AS [donat]
     LEFT JOIN [Hospital].[dbo].[Departments] AS [dept] ON [dept].[Id] = [donat].[DepartmentId]
     LEFT JOIN [Hospital].[dbo].[Sponsors] AS [sponsor] ON [sponsor].[Id] = [donat].[SponsorId]
WHERE DATEDIFF(DAY, [donat].[Date], GETDATE()) <= 30

--6. Виведіть прізвища лікарів із зазначенням відділень, в яких вони проводять обстеження. Враховуйте обстеження, які проводяться лише у будні дні.
SELECT [doctor].[Surname],
       (SELECT [Name] 
        FROM [Departments] 
        WHERE [Departments].[Id] = [ward].[DepartmentId]) AS 'Name of department',
       [exam].[Date],
       DATEPART(WEEKDAY, [exam].[Date]) AS 'Day of week'
FROM [Hospital].[dbo].[Doctors] AS [doctor],
     [Hospital].[dbo].[Examinations] AS [exam],
     [Hospital].[dbo].[Wards] AS [ward]
WHERE [exam].[DoctorId] = [doctor].[Id]
      AND [exam].[WardId] = [ward].[Id]
      AND DATEPART(WEEKDAY, [exam].[Date]) < 7
      AND DATEPART(WEEKDAY, [exam].[Date]) > 1
ORDER BY [doctor].[Name]
 
--Те сaме через JOIN 
SELECT [doctor].[Surname],
       (SELECT [Name] 
        FROM [Departments] 
        WHERE [Departments].[Id] = [ward].[DepartmentId]) AS 'Name of department',
       [exam].[Date],
       DATEPART(WEEKDAY, [exam].[Date]) AS 'Day of week'
FROM [Hospital].[dbo].[Examinations] AS [exam]
RIGHT JOIN [Hospital].[dbo].[Doctors] AS [doctor] ON [doctor].[Id] = [exam].[DoctorId]
LEFT JOIN [Hospital].[dbo].[Wards] AS [ward] ON [ward].[Id] = [exam].[WardId]
WHERE DATEPART(WEEKDAY, [exam].[Date]) < 7
      AND DATEPART(WEEKDAY, [exam].[Date]) > 1
ORDER BY [doctor].[Name]

--7. Виведіть назви палат і корпуси відділень, в яких проводить обстеження лікар «Helen Williams».
SELECT [ward].[Name] AS 'Name of ward',
       [depart].[Name] AS 'Name of department'
FROM [Hospital].[dbo].[Examinations] AS [exam],
     [Hospital].[dbo].[Wards] AS [ward],
     [Hospital].[dbo].[Doctors] AS [doctor],
     [Hospital].[dbo].[Departments] AS [depart]
WHERE [doctor].[Name] = 'Helen'
      AND [doctor].[Surname] = 'Williams'
      AND [depart].Id = [ward].[DepartmentId]
      AND [exam].[WardId] = [ward].[Id]
      AND [exam].[DoctorId] = [doctor].[Id]

--Те саме через JOIN
SELECT [ward].[Name] AS 'Name of ward',
       [depart].[Name] AS 'Name of department'
FROM [Hospital].[dbo].[Examinations] AS [exam]
     LEFT JOIN [Hospital].[dbo].[Doctors] AS [doctor] ON [doctor].[Id] = [exam].[DoctorId]
     LEFT JOIN [Hospital].[dbo].[Wards] AS [ward] ON [ward].[Id] = [exam].[WardId]
     LEFT JOIN [Hospital].[dbo].[Departments] AS [depart] ON [depart].[Id] = [ward].[DepartmentId]
WHERE [doctor].[Name] = 'Helen'
      AND [doctor].[Surname] = 'Williams'

--8. Виведіть назви відділень, які отримували пожертвування у розмірі понад 100000 із зазначенням їх лікарів.
SELECT DISTINCT [dept].[Name] AS 'Name of Department',
       [doctor].[Name] AS 'Name of Doctor',
       [doctor].[Surname] AS 'Surname of Doctor'
FROM [Hospital].[dbo].[Donations] AS [donat]
     LEFT JOIN [Hospital].[dbo].[Departments] AS [dept] ON [dept].[Id] = [donat].[DepartmentId],
     [Hospital].[dbo].[DoctorsDepartments] AS [docdep] 
     LEFT JOIN [Hospital].[dbo].[Doctors] AS [doctor] ON [doctor].[Id] = [docdep].[DoctorId]
WHERE [donat].[Amount] > 100000
      AND [docdep].[DepartmentId] = [donat].[DepartmentId]
ORDER BY  [dept].[Name]

--Те саме ,без JOIN
SELECT DISTINCT [dept].[Name] AS 'Name of Department',
       [doctor].[Name] AS 'Name of Doctor',
       [doctor].[Surname] AS 'Surname of Doctor'
FROM [Hospital].[dbo].[Donations] AS [donat],
     [Hospital].[dbo].[Departments] AS [dept],
     [Hospital].[dbo].[DoctorsDepartments] AS [docdep],
     [Hospital].[dbo].[Doctors] AS [doctor]
WHERE [donat].[Amount] > 100000
      AND [donat].[DepartmentId] = [dept].[Id]
      AND [doctor].[Id] = [docdep].[DoctorId]
      AND [dept].[Id] = [docdep].[DepartmentId]
ORDER BY  [dept].[Name]

--9. Виведіть назви відділень, в яких лікарі не отримують надбавки.
SELECT DISTINCT [dept].[Name] AS 'Name of Department',
       [doctor].[Name] AS 'Name of Doctor',
       [doctor].[SurName] AS 'Surname of Doctor',
       [doctor].[Premium] AS 'Premium of Doctor'
FROM [Hospital].[dbo].[DoctorsDepartments] AS [docdept]
     LEFT JOIN [Hospital].[dbo].[Departments] AS [dept] ON [dept].[Id] = [docdept].[DepartmentId]
     LEFT JOIN [Hospital].[dbo].[Doctors] AS [doctor] ON [doctor].[Id] = [docdept].[DoctorId] 
WHERE [doctor].[Premium] = 0.0
ORDER BY [doctor].[Name]

--Те саме без JOIN
SELECT DISTINCT [dep].[Name] AS 'Name of Department',
       [doc].[Name] AS 'Name of Doctor',
       [doc].[SurName] AS 'Surname of Doctor',
       [doc].[Premium] AS 'Premium of Doctor'
FROM [Hospital].[dbo].[DoctorsDepartments] AS [dd],
     [Hospital].[dbo].[Doctors] AS [doc],
     [Hospital].[dbo].[Departments] AS [dep]
WHERE [dd].[DepartmentId] = [dep].[Id]
      AND [dd].[DoctorId] = [doc].[Id]
      AND [doc].[Premium] = 0
ORDER BY [doc].[Name]

--10. Виведіть назви спеціалізацій, які беруть участь у лікуванні захворювань із ступенем тяжкості вище 3.
SELECT [spec].[Name] AS 'Name of specialization',
       [dis].[Name] AS 'Name of disease',
       [dis].[Severity] AS 'Severity of disease'
FROM [Hospital].[dbo].[DiseasesSpecializations] AS [disspec]
     LEFT JOIN [Hospital].[dbo].[Diseases] AS [dis] ON [disspec].[DiseaseId] = [dis].[Id]
     LEFT JOIN [Hospital].[dbo].[Specializations] AS [spec] ON [disspec].[SpecializationId] = [spec].[Id]
WHERE [dis].[Severity] > 3

--11. Виведіть назви відділень і назви захворювань, обстеження з яких вони проводили за останні півроку.
SELECT [dep].[Name] AS 'Name of department',
       [dis].[Name] AS 'Name of disease',
       [exam].[Date] AS 'Date of examination',
       DATEDIFF(MONTH, [exam].[Date], GETDATE()) AS 'Period of time'
FROM [Hospital].[dbo].[Examinations] AS [exam]
     LEFT JOIN [Hospital].[dbo].[Wards] AS [ward] ON [exam].[WardId] = [ward].[Id]
     LEFT JOIN [Hospital].[dbo].[Departments] AS [dep] ON [ward].[DepartmentId] = [dep].[Id]
     LEFT JOIN [Hospital].[dbo].[Diseases] AS [dis] ON [exam].[DiseaseId] = [dis].[Id]
WHERE DATEDIFF(MONTH, [exam].[Date], GETDATE()) <= 6

--12. Виведіть назви відділень і назви палат, в яких проводилися обстеження із заразних захворювань.
SELECT [dep].[Name] AS 'Name of department',
       [ward].[Name] AS 'Name of ward',
       [dis].[Name] AS 'Name of Disease',
       [exam].[Name] AS 'Name of Examination'
FROM [Hospital].[dbo].[Examinations] AS [exam],
     [Hospital].[dbo].[Wards] AS [ward],
     [Hospital].[dbo].[Departments] AS [dep],
     [Hospital].[dbo].[Diseases] AS [dis]
WHERE [exam].[WardId] = [ward].[Id]
      AND [dep].[Id] = [ward].[DepartmentId]
      AND [exam].[DiseaseId] = [dis].[Id]
      AND ([dis].[Name] = 'Polio'
           OR [dis].[Name] = 'Typhoid'
           OR [dis].[Name] = 'Malaria')
