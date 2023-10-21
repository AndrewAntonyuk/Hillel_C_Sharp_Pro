--<-------------------------------------------------------->--
--Завдання
--<-------------------------------------------------------->--
--Усі назви в базі даних лише англійською мовою!
--Створіть базу даних для зберігання оцінок студентів.

--У базі даних створіть таблицю «Оцінки студентів», яка зберігатиме таку інформацію: 
--■ ПІБ студента;
--■ місто;
--■ країна;
--■ дата народження;
--■ електронна адреса;
--■ контактний телефон;
--■ назва групи;
--■ середня оцінка за рік з усіх предметів;
--■ назва предмета з мінімальною, середньою оцінкою;
--■ назва предмета з максимальною, середньою оцінкою

--Створіть наступні запити для таблиці з оцінками студентів із попереднього завдання: 
--■ Відображати всієї інформації з таблиці зі студентами та оцінками.
--■ Відображати ПІБ усіх студентів.
--■ Відображати усіх середніх оцінок.
--■ Показати ПІБ усіх студентів з мінімальною оцінкою, більшою, ніж зазначена.
--■ Показати країни студентів. Назви країн мають бути унікальними.
--■ Показати міста студентів. Назви міст мають бути унікальними.
--■ Показати назви груп. Назви груп мають бути унікальними.
--■ Показати назви предметів. Назви предметів мають бути унікальними.

--В ДЗ надіслати SQL файл, який виконує всі необхідні дії. 
--Кожній частині скрипта додати коментар з поясненнями того, що робить скрипт.

--<-------------------------------------------------------->--
--Створення даних
--<-------------------------------------------------------->--
--Створюємо базу даних "StudentGroup"
CREATE DATABASE [StudentsGroup]
GO
--Підключаємось до бази даних "StudentGroup" для подальшої роботи з нею
USE [StudentsGroup]

--Створюємо таблицю зі студентами "Students"
CREATE TABLE [Students]
(
   [Id] INT CONSTRAINT [PK_Student_Id] PRIMARY KEY IDENTITY(1, 1),
   [FirstName] NVARCHAR(30) NOT NULL,
   [MiddleName] NVARCHAR(30),
   [LastName] NVARCHAR(30) NOT NULL,
   [City] NVARCHAR(40),
   [Country] NVARCHAR(40),
   [BirthDate] DATE NOT NULL,
   [Email] NVARCHAR(20),
   [Phone] NVARCHAR(15),
   [GroupName] NVARCHAR (15) NOT NULL,
   [AvrgScore] FLOAT DEFAULT 40.0,
   [SubjectMinScore] NVARCHAR(20),
   [SubjectMaxScore] NVARCHAR(20)
)

--Додаємо нових студентів у групу
INSERT INTO [StudentsGroup].[dbo].[Students]
VALUES
		('Joseph', 'Robinette', 'Biden', 'Scranton', 'USA', '1942-11-20', 'brj@gmail.com', '+2 013456987', 'DF', 87.5, 'Mathematic', 'History'),
		('Barack', 'Hussein', 'Obama', 'Honolulu', 'USA', '1961-08-04', 'bho@gmail.com', '+2 031564897', 'SA', 88.12, 'History', 'Sociology'),
		('George', 'Walker', 'Bush', 'Scranton', 'USA', '1946-06-06', NULL, NULL, 'DF', DEFAULT, 'Chemistry', 'Mathematic'),
		('William', 'Jefferson', 'Clinton', 'Arkansas', 'USA', '1942-11-20', 'jwc@gmail.com', DEFAULT, 'SA', 90.01, 'Physics', 'Political science'),
		('Volodymyr', 'Oleksandrovych', 'Zelenskyy', 'Kryvyi Rih', 'Ukrain', '1978-02-25', 'ozv@gmail.cc', NULL, 'DF', 80.2, 'Mathematic', 'Physics'),
		('Petro', 'Oleksiyovych', 'Poroshenko', 'Bolhrad', 'Ukrain', '1965-09-26', 'roshen@gmail.com', '+30802564789', 'KL', 60.58, 'Physics', 'Music'),
		('Viktor', 'Andriyovych', 'Yushchenko', 'Khoruzhivka', 'Ukrain', '1954-02-23', 'asas@gmail.com', '+3506314879', 'KL', 70.54, 'Sociology', 'Literacy'),
		('Alain', NULL, 'Berset', 'Fribourg', 'Swiss', '1972-04-09', 'al@gmail.sw', NULL, 'KL', 99.5, 'Law', 'History'),
		('Ignazio', 'Daniele', 'Cassis', 'Sessa', 'Swiss', '1961-04-13', NULL, '+96325114780', 'SA', 60.24, 'History', 'Law'),
		('Guy', 'Bernard', 'Parmelin', 'Bursins', 'Swiss', '1959-11-09', 'myemail@gmail.com', NULL, 'DF', 51.24, 'Sociology', 'Quantum mechanics'),
		('Simonetta', 'Myriam', 'Sommaruga', 'Zug', 'Swiss', '1960-05-14', NULL, '+96584213700', 'KL', 78.24, 'History', 'Law')
 
 --<-------------------------------------------------------->--
--Опрацювання даних
--<-------------------------------------------------------->--
--Відображати всієї інформації з таблиці зі студентами та оцінками
SELECT * 
FROM [StudentsGroup].[dbo].[Students]

--Відображати ПІБ усіх студентів
SELECT	[FirstName] AS 'First name',
		[MiddleName] AS 'Middle name', 
		[LastName] AS 'Last name' 
FROM [StudentsGroup].[dbo].[Students]

--Відображати усіх середніх оцінок
SELECT [AvrgScore]
FROM [StudentsGroup].[dbo].[Students]

--Показати ПІБ усіх студентів з мінімальною оцінкою, більшою, ніж зазначена. Задана оцінка = 70
SELECT * 
FROM [StudentsGroup].[dbo].[Students]
WHERE [AvrgScore] > 70

--Показати країни студентів. Назви країн мають бути унікальними
SELECT DISTINCT [Country]
FROM [StudentsGroup].[dbo].[Students]

--Показати міста студентів. Назви міст мають бути унікальними
SELECT [City]
FROM [StudentsGroup].[dbo].[Students]
GROUP BY [City]

--Показати назви груп. Назви груп мають бути унікальними
SELECT [GroupName]
FROM [StudentsGroup].[dbo].[Students]
GROUP BY [GroupName]

--Показати назви предметів. Назви предметів мають бути унікальними
SELECT UniqueSubjects
FROM (
	SELECT [SubjectMinScore]
	FROM [StudentsGroup].[dbo].[Students]
	UNION
	SELECT [SubjectMaxScore]
	FROM [StudentsGroup].[dbo].[Students]
) AS NewTab(UniqueSubjects)
GROUP BY UniqueSubjects 

--USE [master]
--DROP TABLE [StudentsGroup].[dbo].[Students]
--DELETE [StudentsGroup].[dbo].[Students]
