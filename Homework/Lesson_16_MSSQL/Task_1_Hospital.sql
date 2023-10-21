--<-------------------------------------------------------->--
--Завдання
--<-------------------------------------------------------->--
--Усі назви в базі даних лише англійською мовою!
--Опис бази даних 
--Створіть базу даних Лікарня (Hospital), яка міститиме інформацію про обстеження, які проводяться в лікарні.
--Обстеження, які проводяться в лікарні, представлені у вигляді таблиці Обстеження (Examinations), в якій зібрано основну інформацію: назва обстеження, день тижня, коли проводиться обстеження, а також час початку та завершення.
--Також у базі даних є інформація про персонал лікарні, яка зберігається в таблиці Лікарі (Doctors).
--Дані про відділення та захворювання містяться в таблицях Відділення (Departments) та Захворювання (Diseases) відповідно.
--Опис палат зберігається в таблиці Палати (Wards).
--Таблиці 
--Нижче наведено детальний опис структури кожної таблиці.
--Відділення (Departments) 
--■ Ідентифікатор (Id). Унікальний ідентифікатор відділення.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Корпус (Building). Номер корпусу, в якому знаходиться відділення.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Має бути в діапазоні від 1 до 5.
--■ Фінансування (Financing). Фонд фінансування відділення.
--▷ Тип даних для зберігання грошових значень.
--▷ Не містить null-значення.
--▷ Не може бути менше, ніж 0.
--▷ Значення за замовчуванням — 0.
--■ Назва (Name). Назва відділення.
--▷ Тип даних — nvarchar(100).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.
--▷ Має бути унікальною.

--Захворювання (Diseases) 
--■ Ідентифікатор (Id). Унікальний ідентифікатор захворювання.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Назва (Name). Назва захворювання.
--▷ Тип даних — nvarchar(100).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.
--▷ Має бути унікальною.
--■ Ступінь тяжкості (Severity). Ступінь тяжкості захворювання.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Не може бути менше, ніж 1.
--▷ Значення за замовчуванням — 1.

--Лікарі (Doctors) 
--■ Ідентифікатор (Id). Унікальний ідентифікатор лікаря.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ Ім’я (Name). Ім’я лікаря.
--▷ Тип даних — nvarchar(max).
--▷ Не містить null-значення.
--▷ Не може бути порожнє.
--■ Телефон (Phone). Телефонний номер лікаря.
--▷ Тип даних — char(10).
--▷ Може містити null-значення.
--■ Ставка (Salary). Ставка лікаря.
--▷ Тип даних для зберігання грошових значень.
--▷ Не містить null-значення.
--▷ Не може бути меншою або дорівнювати 0.
--■ Прізвище (Surname). Прізвище лікаря.
--▷ Тип даних — nvarchar(max).
--▷ Не містить null-значення.
--▷ Не може бути порожнє.

--Обстеження (Examinations) 
--■ Ідентифікатор (Id). Унікальний ідентифікатор обстеження.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення.
--▷ Первинний ключ.
--■ День тижня (DayOfWeek). День тижня, коли проводиться обстеження.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Має бути в діапазоні від 1 до 7.
--■ Час завершення (EndTime). Час завершення обстеження.
--▷ Тип даних для зберігання часу.
--▷ Не містить null-значення.
--▷ Має бути більше, ніж час початку обстеження.
--■ Назва (Name). Назва обстеження.
--▷ Тип даних — nvarchar(100).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.
--▷ Має бути унікальною.
--■ Час початку (StartTime). Час початку обстеження.
--▷ Тип даних для зберігання часу.
--▷ Не містить null-значення.
--▷ Має бути в діапазоні від 8:00 до 18:00.

--Палати (Wards) 
--■ Ідентифікатор (Id). Унікальний ідентифікатор.
--▷ Тип даних — int.
--▷ Автоприріст.
--▷ Не містить null-значення
--▷ Первинний ключ.
--■ Корпус (Building). Номер корпусу, де знаходиться палата.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Має бути в діапазоні від 1 до 5.
--■ Поверх (Floor). Номер поверху, на якому знаходиться палата.
--▷ Тип даних — int.
--▷ Не містить null-значення.
--▷ Не може бути менше, ніж 1.
--■ Назва (Name). Назва палати.
--▷ Тип даних — nvarchar(20).
--▷ Не містить null-значення.
--▷ Не може бути порожньою.

--▷ Має бути унікальною.
--Для бази даних «Лікарня» створіть такі запити:
--1. Вивести вміст таблиці палат.
--2. Вивести прізвища та телефони усіх лікарів.
--3. Вивести усі поверхи без повторень, де розміщуються палати.
--4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease».
--5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми.
--6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000.
--7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000.
--8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі.
--9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 3 або 6 та мають фонд фінансування менший, ніж 11000 або більший за 25000.
--10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500.
--11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку.
--12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00.
--13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10.
--14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го.
--15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі.
--16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі.
--17. Вивести прізвища лікарів, що починаються з літери «N».
--В ДЗ надіслати SQL файл, який виконує всі необхідні дії. 
--Кожній частині скрипта додати коментар з поясненнями того, що робить скрипт.

--<-------------------------------------------------------->--
--Створення даних
--<-------------------------------------------------------->--
USE master

IF EXISTS(SELECT * 
          FROM sys.databases 
          WHERE NAME = 'Hospital')
BEGIN
    ALTER DATABASE [Hospital]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE IF EXISTS [Hospital]
END

CREATE DATABASE [Hospital]
GO
USE [Hospital]

IF OBJECT_ID(N'[Hospital].[dbo].[Departments]', N'U') IS NULL
BEGIN
    CREATE TABLE [Departments]
    (
        [Id] INT IDENTITY,
        [Building] INT NOT NULL,
        [Financing] MONEY NOT NULL DEFAULT 0.0,
        [Name] NVARCHAR(100) NOT NULL,

        CONSTRAINT PK_Department_Id PRIMARY KEY([Id]),
        CONSTRAINT CK_Department_Building CHECK([Building] > 0 AND [Building] < 6),
        CONSTRAINT CK_Department_Financing CHECK([Financing] >= 0.0),
        CONSTRAINT CK_Department_Name CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT UQ_Department_Name UNIQUE([Name])
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Diseases]', N'U') IS NULL
BEGIN
    CREATE TABLE [Diseases]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(100) NOT NULL,
        [Severity] INT NOT NULL DEFAULT 1

        CONSTRAINT PK_Diseas_Id PRIMARY KEY([Id]),
        CONSTRAINT CK_Diseas_Name CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT UQ_Diseas_Name UNIQUE([Name]),
        CONSTRAINT CK_Diseas_Severity CHECK ([Severity] > 0)
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Doctors]', N'U') IS NULL
BEGIN
    CREATE TABLE [Doctors]
    (
        [Id] INT IDENTITY,
        [Name] NVARCHAR(MAX) NOT NULL,
        [Phone] CHAR(10),
        [Salary] MONEY NOT NULL,
        [Bonus] MONEY NOT NULL,
        [Surname] NVARCHAR(MAX) NOT NULL,

        CONSTRAINT PK_Doctor_Id PRIMARY KEY([Id]),
        CONSTRAINT CK_Doctor_Name CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT CK_Doctor_Salary CHECK([Salary] > 0.0),
        CONSTRAINT CK_Doctor_Bonus CHECK([Bonus] >= 0.0),
        CONSTRAINT CK_Doctor_Surname CHECK(LEN(TRIM([Surname])) > 0)
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Examinations]', N'U') IS NULL
BEGIN
    CREATE TABLE [Examinations]
    (
        [Id] INT IDENTITY,
        [DayOfWeek] INT NOT NULL,
        [EndTime] TIME(0) NOT NULL,
        [Name] NVARCHAR(100) NOT NULL,
        [StartTime] TIME(0) NOT NULL,

        CONSTRAINT PK_Examination_Id PRIMARY KEY([Id]),
        CONSTRAINT CK_Examination_DayOfWeek CHECK([DayOfWeek] >= 1 AND [DayOfWeek] <= 7),
        CONSTRAINT CK_Examination_EndTime CHECK([EndTime] > [StartTime]),
        CONSTRAINT CK_Examination_Name CHECK(LEN(TRIM([Name])) > 0),
        CONSTRAINT CK_Examination_StartTime CHECK([StartTime] >= '8:00' AND [StartTime] <= '18:00')
    )
END

IF OBJECT_ID(N'[Hospital].[dbo].[Wards]', N'U') IS NULL
BEGIN
    CREATE TABLE [Wards]
    (
        [Id] INT IDENTITY,
        [Building] INT NOT NULL,
        [Floor] INT NOT NULL,
        [Name] NVARCHAR(20) NOT NULL,

        CONSTRAINT PK_Ward_Id PRIMARY KEY([Id]),
        CONSTRAINT CK_Ward_Building CHECK([Building] BETWEEN 1 AND 5),
        CONSTRAINT CK_Ward_Floor CHECK([Floor] >= 1),
        CONSTRAINT CK_Ward_Name CHECK(LEN(TRIM([Name])) > 0)
    )
END

--Додаємо дані до бази даних
INSERT 
INTO [Hospital].[dbo].[Departments]
VALUES  (1, 15000.0, 'DRFT-19'),
        (5, 19000.0, 'JKTE-52'),
        (2, 25000.0, 'DRFT-27'),
        (3, 20000.0, 'LKUT-21'),
        (5, 10000.0, 'MKHG-45'),
        (4, 16000.0, 'LKUT-47'),
        (1, 17000.0, 'JKTE-15'),
        (3, 10000.0, 'VWTR-33')

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
INTO [Hospital].[dbo].[Doctors]
VALUES  ('Alexander', '0123456789', 2000.0, 800.0,'Fleming'),
        ('Edward', '0326598741', 1500.0, 900.0, 'Jenner'),
        ('William', '0215487963', 1000.0, 100.0, 'Osler'),
        ('Hippocrates', '0258741369', 700.0, 200.0, 'Neon'),
        ('Sigmund', '0213654789', 6000.0, 300.0, 'Freud'),
        ('Louis', '0325698714', 9000.0, 300.0, 'Pasteur'),
        ('Elizabeth', '0246589713', 3200.0, 50.0, 'Blackwell'),
        ('Merit', '0258993447', 2001.0, 100.0, 'Nurse'),
        ('Metrodora', '0123654789', 8600.0, 2001.0, 'Nanat')

INSERT 
INTO [Hospital].[dbo].[Examinations]
VALUES  (1, '9:00', 'E-TFR-324', '8:30'),
        (2, '14:30', 'E-DFG-12', '14:00'),
        (5, '11:25', 'E-KMJ-85', '10:10'),
        (3, '13:10', 'E-OKM-96', '12:15'),
        (7, '18:00', 'E-ERF-245', '17:00'),
        (5, '10:20', 'E-CSD-124', '8:00'),
        (4, '14:10', 'E-PLS-88', '12:13'),
        (6, '13:15', 'E-WER-14', '11:45'),
        (7, '16:16', 'E-NJS-758', '14:50'),
        (5, '15:28', 'E-AVS-444', '13:20'),
        (3, '12:30', 'E-PLK-157', '12:00'),
        (1, '17:45', 'E-MKD-517', '16:16')

INSERT 
INTO [Hospital].[dbo].[Wards]
VALUES  (1, 3, 'B-NDM-547'),
        (5, 1, 'B-SCF-21'),
        (2, 3, 'B-YHG-47'),
        (2, 3, 'B-WBD-78'),
        (3, 2, 'B-TGD-127'),
        (4, 2, 'B-BHG-964'),
        (1, 3, 'B-MKJ-715'),
        (3, 3, 'B-SRF-55'),
        (4, 1, 'B-SDW-73'),
        (1, 3, 'B-CSD-124'),
        (5, 2, 'B-OKD-52')
--DROP TABLE [Hospital].[dbo].[Departments]
--DROP TABLE [Hospital].[dbo].[Diseases]
--DROP TABLE [Hospital].[dbo].[Doctors]
--DROP TABLE [Hospital].[dbo].[Examinations]
--DROP TABLE [Hospital].[dbo].[Wards]

 --<-------------------------------------------------------->--
--Опрацювання даних
--<-------------------------------------------------------->--
--1. Вивести вміст таблиці палат
SELECT *
FROM [Hospital].[dbo].[Wards]

--2. Вивести прізвища та телефони усіх лікарів
SELECT [Surname] AS 'Doctor Surnames',
       [Phone]
FROM [Hospital].[dbo].[Doctors]

--3. Вивести усі поверхи без повторень, де розміщуються палати
SELECT DISTINCT [Floor] AS 'Ward floors'
FROM [Hospital].[dbo].[Wards]

--4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease»
SELECT [Name] AS 'Name of Disease',
       [Severity] AS 'Severity of Disease'
FROM [Hospital].[dbo].[Diseases]

--5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми
SELECT [ward].[Building] AS 'Building', 
       [ward].[Name] AS 'Ward name', 
       [department].[Name] AS 'Department name', 
       [doctor].[Name] AS 'Doctor name'
FROM [Hospital].[dbo].[Wards] AS ward,
     [Hospital].[dbo].[Departments] AS department,
     [Hospital].[dbo].[Doctors] AS doctor
WHERE department.Building = ward.Building
      AND doctor.Id = department.Id

--6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000
SELECT [Name] AS 'Name of department'
FROM [Hospital].[dbo].[Departments]
WHERE [Building] = 5 
      AND [Financing] < 30000

--7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000
SELECT [Name] AS 'Name of department'
FROM [Hospital].[dbo].[Departments]
WHERE [Building] = 3 
      AND [Financing] BETWEEN 12000 AND 15000

--8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі
SELECT [Name]
FROM [Hospital].[dbo].[Wards]
WHERE [Building] BETWEEN 4 AND 5
      AND [Floor] = 1

--9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 3 або 5 та мають фонд фінансування менший, ніж 11000 або більший за 25000
SELECT [Name] AS 'Name of departments',
       [Building] AS 'Building of departments',
       [Financing] AS 'Financing of departments'
FROM [Hospital].[dbo].[Departments]
WHERE ([Building] = 3 
         OR [Building] = 5)
      AND ([Financing] <= 11000
           OR [Financing] >= 25000)

--10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 2000
SELECT [Surname] AS 'Surname of doctor',
       [Salary] AS 'Salary of doctor'
FROM [Hospital].[dbo].[Doctors]
WHERE [Salary] > 2000

--11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку
SELECT [Surname] AS 'Surname of doctor',
       [Salary] AS 'Salary of doctor',
       [Bonus] AS 'Bonus of doctor'
FROM [Hospital].[dbo].[Doctors]
WHERE [Salary] / 2 > [Bonus] * 3

--12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00
SELECT DISTINCT [Name]
FROM [Hospital].[dbo].[Examinations]
WHERE [DayOfWeek] BETWEEN 1 AND 3
      AND [StartTime] >= '12:00'
      AND [EndTime] <= '15:00'

--13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 5
SELECT [Name] AS 'Name of Department',
       [Building] AS 'Building of Department'
FROM [Hospital].[dbo].[Departments]
WHERE [Building] = 1
      OR [Building] = 3
      OR [Building] = 5

--14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го
SELECT [Name] AS 'Disease',
       [Severity] AS 'Severity stage'
FROM [Hospital].[dbo].[Diseases]
WHERE [Severity] NOT IN (1, 2)

--15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі
SELECT [Name] AS 'Name of department',
       [Building] AS 'Building of department'
FROM [Hospital].[dbo].[Departments]
WHERE [Building] != 1
      AND [Building] != 3

--16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі
SELECT [Name] AS 'Name of department',
       [Building] AS 'Building of department'
FROM [Hospital].[dbo].[Departments]
WHERE [Building] IN (1, 3)

--17. Вивести прізвища лікарів, що починаються з літери «N»
SELECT [doc].[Surname] AS 'Surname of Doctor'
FROM [Hospital].[dbo].Doctors AS doc
WHERE [Surname] LIKE 'N%'