USE [master]
GO
/****** Object:  Database [WageFlowDataBase]    Script Date: 21.05.2025 16:26:25 ******/
CREATE DATABASE [WageFlowDataBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WageFlowDataBase', FILENAME = N'D:\SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\WageFlowDataBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WageFlowDataBase_log', FILENAME = N'D:\SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\WageFlowDataBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WageFlowDataBase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WageFlowDataBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WageFlowDataBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WageFlowDataBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WageFlowDataBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WageFlowDataBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WageFlowDataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WageFlowDataBase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WageFlowDataBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WageFlowDataBase] SET  MULTI_USER 
GO
ALTER DATABASE [WageFlowDataBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WageFlowDataBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WageFlowDataBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WageFlowDataBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WageFlowDataBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WageFlowDataBase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WageFlowDataBase] SET QUERY_STORE = ON
GO
ALTER DATABASE [WageFlowDataBase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [WageFlowDataBase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[id_payments] [int] IDENTITY(1,1) NOT NULL,
	[amount_payments] [real] NOT NULL,
	[comment] [nvarchar](50) NOT NULL,
	[date_payments] [date] NOT NULL,
	[id_staff] [int] NOT NULL,
	[id_payments_type] [int] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[id_payments] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments_Type]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments_Type](
	[id_payments_type] [int] IDENTITY(1,1) NOT NULL,
	[name_payments_type] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Payments_Type] PRIMARY KEY CLUSTERED 
(
	[id_payments_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[id_post] [int] IDENTITY(1,1) NOT NULL,
	[name_post] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[id_post] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary_Payment]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary_Payment](
	[id_salary_payment] [int] IDENTITY(1,1) NOT NULL,
	[amount_salary_payment] [real] NOT NULL,
	[start_date_salary_payment] [date] NOT NULL,
	[end_date_salary_payment] [date] NOT NULL,
	[date_salary_payment] [date] NOT NULL,
	[id_staff] [int] NOT NULL,
 CONSTRAINT [PK_Salary_Payment] PRIMARY KEY CLUSTERED 
(
	[id_salary_payment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[id_staff] [int] IDENTITY(1,1) NOT NULL,
	[lastname_staff] [nvarchar](50) NOT NULL,
	[name_staff] [nvarchar](50) NOT NULL,
	[patronymic_staff] [nvarchar](50) NOT NULL,
	[email_staff] [nvarchar](50) NOT NULL,
	[id_post] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[id_staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](30) NOT NULL,
	[user_password] [nvarchar](30) NOT NULL,
	[id_staff] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work_Entry]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_Entry](
	[id_work_entry] [int] IDENTITY(1,1) NOT NULL,
	[quantity_work_entry] [int] NOT NULL,
	[date_work_entry] [date] NOT NULL,
	[id_staff] [int] NOT NULL,
	[id_work_type] [int] NOT NULL,
 CONSTRAINT [PK_Work_Entry] PRIMARY KEY CLUSTERED 
(
	[id_work_entry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work_Type]    Script Date: 21.05.2025 16:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_Type](
	[id_work_type] [int] IDENTITY(1,1) NOT NULL,
	[name_work_type] [nvarchar](50) NOT NULL,
	[amount_work_type] [real] NOT NULL,
 CONSTRAINT [PK_Work_Type] PRIMARY KEY CLUSTERED 
(
	[id_work_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (1, 10000, N'Выполнение проекта раньше срока', CAST(N'2025-03-23' AS Date), 1, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (2, 6000, N'Отличная работа с клиентами или бизнес-заказчиком', CAST(N'2025-03-23' AS Date), 1, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (3, 5000, N'Игнорирование код-ревью и замечаний команды', CAST(N'2025-03-21' AS Date), 1, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (4, 3000, N'Обучение новых сотрудников', CAST(N'2025-03-27' AS Date), 1, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (5, 5000, N'Расширение клиенткой базы', CAST(N'2025-05-14' AS Date), 1, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (6, 3500, N'Выполнение проекта раньше срока', CAST(N'2024-06-15' AS Date), 2, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (7, 1500, N'Опоздание на работу', CAST(N'2024-09-12' AS Date), 2, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (8, 7500, N'Отличная работа с клиентами', CAST(N'2025-01-28' AS Date), 2, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (9, 2200, N'Игнорирование код-ревью', CAST(N'2024-11-05' AS Date), 2, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (10, 8000, N'Премия за квартальные результаты', CAST(N'2024-03-30' AS Date), 3, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (11, 1800, N'Нарушение дисциплины', CAST(N'2024-08-17' AS Date), 3, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (12, 4500, N'Выполнение проекта раньше срока', CAST(N'2025-02-10' AS Date), 3, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (13, 1000, N'Опоздание на работу', CAST(N'2025-04-22' AS Date), 3, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (14, 6700, N'Отличная работа с клиентами', CAST(N'2024-04-17' AS Date), 4, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (15, 2500, N'Игнорирование код-ревью', CAST(N'2024-10-08' AS Date), 4, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (16, 9000, N'Выполнение проекта раньше срока', CAST(N'2025-01-15' AS Date), 4, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (17, 3000, N'Премия', CAST(N'2024-07-25' AS Date), 4, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (18, 5500, N'Премия', CAST(N'2024-05-05' AS Date), 5, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (19, 800, N'Опоздание на работу', CAST(N'2024-08-28' AS Date), 5, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (20, 7800, N'Отличная работа с клиентами', CAST(N'2025-02-14' AS Date), 5, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (21, 2300, N'Игнорирование код-ревью', CAST(N'2025-05-01' AS Date), 5, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (22, 6200, N'Выполнение проекта раньше срока', CAST(N'2024-03-15' AS Date), 6, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (23, 1700, N'Нарушение дисциплины', CAST(N'2024-09-20' AS Date), 6, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (24, 8500, N'Премия', CAST(N'2025-01-08' AS Date), 6, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (25, 3000, N'Отличная работа с клиентами', CAST(N'2024-06-30' AS Date), 6, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (26, 2200, N'Игнорирование код-ревью', CAST(N'2025-04-10' AS Date), 6, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (27, 5400, N'Премия', CAST(N'2024-04-22' AS Date), 7, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (28, 1100, N'Опоздание на работу', CAST(N'2024-11-15' AS Date), 7, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (29, 6800, N'Выполнение проекта раньше срока', CAST(N'2025-02-28' AS Date), 7, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (30, 2000, N'Игнорирование код-ревью', CAST(N'2024-07-10' AS Date), 7, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (31, 4800, N'Отличная работа с клиентами', CAST(N'2024-05-19' AS Date), 8, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (32, 900, N'Нарушение дисциплины', CAST(N'2024-10-05' AS Date), 8, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (33, 7200, N'Выполнение проекта раньше срока', CAST(N'2025-01-25' AS Date), 8, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (34, 1500, N'Опоздание на работу', CAST(N'2025-04-15' AS Date), 8, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (35, 5500, N'Премия', CAST(N'2024-08-12' AS Date), 8, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (36, 6300, N'Премия', CAST(N'2024-03-28' AS Date), 9, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (37, 2100, N'Игнорирование код-ревью', CAST(N'2024-06-17' AS Date), 9, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (38, 8400, N'Выполнение проекта раньше срока', CAST(N'2024-12-05' AS Date), 9, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (39, 1300, N'Опоздание на работу', CAST(N'2025-03-20' AS Date), 9, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (40, 5900, N'Отличная работа с клиентами', CAST(N'2024-05-08' AS Date), 10, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (41, 1900, N'Нарушение дисциплины', CAST(N'2024-11-22' AS Date), 10, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (42, 7600, N'Премия', CAST(N'2025-02-18' AS Date), 10, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (43, 1000, N'Игнорирование код-ревью', CAST(N'2025-05-05' AS Date), 10, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (44, 6100, N'Выполнение проекта раньше срока', CAST(N'2024-04-14' AS Date), 11, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (45, 2300, N'Опоздание на работу', CAST(N'2024-09-25' AS Date), 11, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (46, 9200, N'Премия', CAST(N'2025-01-12' AS Date), 11, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (47, 1600, N'Нарушение дисциплины', CAST(N'2025-03-30' AS Date), 11, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (48, 4700, N'Отличная работа с клиентами', CAST(N'2024-07-15' AS Date), 11, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (49, 5800, N'Премия', CAST(N'2024-05-29' AS Date), 12, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (50, 1400, N'Игнорирование код-ревью', CAST(N'2024-10-18' AS Date), 12, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (51, 8700, N'Выполнение проекта раньше срока', CAST(N'2025-02-05' AS Date), 12, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (52, 900, N'Опоздание на работу', CAST(N'2025-04-28' AS Date), 12, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (53, 7300, N'Отличная работа с клиентами', CAST(N'2024-03-10' AS Date), 13, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (54, 2500, N'Нарушение дисциплины', CAST(N'2024-08-22' AS Date), 13, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (55, 9500, N'Премия', CAST(N'2024-12-15' AS Date), 13, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (56, 1200, N'Игнорирование код-ревью', CAST(N'2025-03-08' AS Date), 13, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (57, 6500, N'Выполнение проекта раньше срока', CAST(N'2025-05-10' AS Date), 13, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (58, 4900, N'Премия', CAST(N'2024-06-20' AS Date), 14, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (59, 1800, N'Опоздание на работу', CAST(N'2024-11-10' AS Date), 14, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (60, 7800, N'Отличная работа с клиентами', CAST(N'2025-01-30' AS Date), 14, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (61, 2200, N'Нарушение дисциплины', CAST(N'2024-09-05' AS Date), 14, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (62, 6400, N'Выполнение проекта раньше срока', CAST(N'2024-04-30' AS Date), 15, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (63, 950, N'Игнорирование код-ревью', CAST(N'2024-10-12' AS Date), 15, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (64, 8100, N'Премия', CAST(N'2025-02-22' AS Date), 15, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (65, 1700, N'Опоздание на работу', CAST(N'2024-07-05' AS Date), 15, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (66, 5300, N'Отличная работа с клиентами', CAST(N'2025-05-08' AS Date), 15, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (67, 7100, N'Премия', CAST(N'2024-03-18' AS Date), 16, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (68, 2000, N'Нарушение дисциплины', CAST(N'2024-08-29' AS Date), 16, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (69, 9800, N'Выполнение проекта раньше срока', CAST(N'2024-12-10' AS Date), 16, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (70, 1100, N'Игнорирование код-ревью', CAST(N'2025-04-05' AS Date), 16, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (71, 5700, N'Отличная работа с клиентами', CAST(N'2024-05-15' AS Date), 17, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (72, 1500, N'Опоздание на работу', CAST(N'2024-09-28' AS Date), 17, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (73, 7900, N'Премия', CAST(N'2025-01-20' AS Date), 17, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (74, 2400, N'Нарушение дисциплины', CAST(N'2025-03-15' AS Date), 17, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (75, 6900, N'Выполнение проекта раньше срока', CAST(N'2024-06-10' AS Date), 18, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (76, 1300, N'Игнорирование код-ревью', CAST(N'2024-11-02' AS Date), 18, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (77, 8300, N'Премия', CAST(N'2025-02-15' AS Date), 18, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (78, 1600, N'Опоздание на работу', CAST(N'2024-08-05' AS Date), 18, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (79, 5200, N'Отличная работа с клиентами', CAST(N'2025-04-20' AS Date), 18, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (80, 7500, N'Премия', CAST(N'2024-04-05' AS Date), 19, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (81, 2200, N'Нарушение дисциплины', CAST(N'2024-10-22' AS Date), 19, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (82, 9100, N'Выполнение проекта раньше срока', CAST(N'2025-01-05' AS Date), 19, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (83, 800, N'Игнорирование код-ревью', CAST(N'2025-05-12' AS Date), 19, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (84, 5600, N'Отличная работа с клиентами', CAST(N'2024-05-25' AS Date), 20, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (85, 1800, N'Опоздание на работу', CAST(N'2024-09-15' AS Date), 20, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (86, 8900, N'Премия', CAST(N'2025-02-08' AS Date), 20, 1)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (87, 2100, N'Нарушение дисциплины', CAST(N'2024-07-20' AS Date), 20, 2)
INSERT [dbo].[Payments] ([id_payments], [amount_payments], [comment], [date_payments], [id_staff], [id_payments_type]) VALUES (88, 6700, N'Выполнение проекта раньше срока', CAST(N'2025-04-25' AS Date), 20, 1)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments_Type] ON 

INSERT [dbo].[Payments_Type] ([id_payments_type], [name_payments_type]) VALUES (1, N'Премирование')
INSERT [dbo].[Payments_Type] ([id_payments_type], [name_payments_type]) VALUES (2, N'Депремирование')
SET IDENTITY_INSERT [dbo].[Payments_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([id_post], [name_post]) VALUES (1, N'Руководитель')
INSERT [dbo].[Post] ([id_post], [name_post]) VALUES (2, N'Менеджер')
INSERT [dbo].[Post] ([id_post], [name_post]) VALUES (3, N'Сотрудник')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Salary_Payment] ON 

INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (6, 78000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 1)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (7, 57000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 2)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (8, 64000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 3)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (9, 73000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 4)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (10, 142000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 5)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (11, 64000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 6)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (12, 190000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 7)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (13, 133000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 8)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (14, 30000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 9)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (15, 78000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 10)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (16, 104000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 11)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (17, 81000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 12)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (18, 111000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 13)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (19, 75000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 14)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (20, 84000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 16)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (21, 108000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 17)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (22, 169500, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 18)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (23, 78500, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 19)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (24, 60000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 20)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (25, 72000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 1)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (26, 37500, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 2)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (27, 80000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 3)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (28, 109000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 4)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (29, 48500, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 5)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (30, 74000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 6)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (31, 88000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 7)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (33, 140000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 8)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (34, 160000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 9)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (35, 53000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 10)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (36, 50500, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 11)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (37, 109000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 12)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (38, 15000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 13)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (39, 127000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 14)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (40, 65000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 15)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (41, 82000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 16)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (42, 141000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 17)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (43, 75000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 18)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (44, 102000, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 19)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (45, 47500, CAST(N'2024-02-01' AS Date), CAST(N'2024-03-01' AS Date), CAST(N'2024-03-01' AS Date), 20)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (46, 72000, CAST(N'2024-01-01' AS Date), CAST(N'2024-02-01' AS Date), CAST(N'2024-02-01' AS Date), 15)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (47, 65000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 1)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (48, 140000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 2)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (49, 39000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 3)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (50, 106500, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 4)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (51, 81000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 5)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (52, 86200, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 6)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (53, 33000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 7)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (54, 32000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 8)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (55, 75300, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 9)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (56, 141000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 10)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (57, 83000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 11)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (58, 106000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 12)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (59, 62300, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 13)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (60, 108000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 14)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (61, 211000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 15)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (62, 99100, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 16)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (63, 80000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 17)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (64, 59000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 18)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (65, 100000, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 19)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (66, 75500, CAST(N'2024-03-01' AS Date), CAST(N'2024-04-01' AS Date), CAST(N'2024-04-01' AS Date), 20)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (67, 45000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 1)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (68, 83000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 2)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (69, 36500, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 3)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (70, 121700, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 4)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (71, 66000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 5)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (72, 47000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 6)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (73, 291400, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 7)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (74, 20000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 8)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (75, 61000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 9)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (76, 160000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 10)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (77, 71100, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 11)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (78, 95000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 12)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (79, 88000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 13)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (80, 56000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 14)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (81, 157400, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 15)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (82, 82000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 16)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (83, 71000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 17)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (84, 66500, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 19)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (85, 36000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 18)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (86, 36000, CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(N'2024-05-01' AS Date), 20)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (87, 47000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 1)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (88, 31000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 2)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (89, 38000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 3)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (90, 28000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 4)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (91, 22500, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 5)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (92, 133000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 6)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (93, 212000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 7)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (94, 234800, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 8)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (95, 130000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 9)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (96, 70900, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 10)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (97, 70900, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 10)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (98, 99500, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 11)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (99, 60800, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 12)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (100, 99000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 13)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (101, 123000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 14)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (102, 110000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 15)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (103, 52000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 16)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (104, 75700, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 17)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (105, 175000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 18)
GO
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (106, 46000, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 19)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (107, 195600, CAST(N'2024-05-01' AS Date), CAST(N'2024-06-01' AS Date), CAST(N'2024-06-01' AS Date), 20)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (108, 60000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 1)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (109, 77500, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 2)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (110, 183000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 3)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (111, 45000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 4)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (112, 55000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 5)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (113, 143000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 6)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (114, 40000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 7)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (115, 105000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 8)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (116, 22900, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 9)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (117, 215000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 10)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (118, 90000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 11)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (119, 71000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 12)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (120, 122000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 13)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (121, 50900, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 14)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (122, 25000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 15)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (123, 180000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 16)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (124, 39900, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 18)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (125, 100000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 17)
INSERT [dbo].[Salary_Payment] ([id_salary_payment], [amount_salary_payment], [start_date_salary_payment], [end_date_salary_payment], [date_salary_payment], [id_staff]) VALUES (126, 160000, CAST(N'2024-06-01' AS Date), CAST(N'2024-07-01' AS Date), CAST(N'2025-07-01' AS Date), 19)
SET IDENTITY_INSERT [dbo].[Salary_Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (1, N'Проказников', N'Илья', N'Владимирович', N'prokaznikov@example.com', 1)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (2, N'Иванов', N'Олег', N'Кирилович', N'ivanov@example.com', 2)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (3, N'Карпов', N'Денис', N'Викторович', N'karpov@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (4, N'Смирнов', N'Алексей', N'Петрович', N'smirnov@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (5, N'Федорова', N'Мария', N'Николаевна', N'fedorova@example.com', 2)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (6, N'Кузнецов', N'Андрей', N'Иванович', N'kuznecov@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (7, N'Павлова', N'Светлана', N'Сергеевна', N'pavlova@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (8, N'Никитин', N'Евгений', N'Александрович', N'nikitin@example.com', 2)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (9, N'Сорокина', N'Анна', N'Владимировна', N'sorokina@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (10, N'Волков', N'Тимофей', N'Максимович', N'volkov@example.com', 2)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (11, N'Громова', N'Елизавета', N'Михайловна', N'gromova@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (12, N'Морозов', N'Виталий', N'Артемович', N'morozov@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (13, N'Коваль', N'Татьяна', N'Романовна', N'koval@example.com', 1)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (14, N'Беляев', N'Константин', N'Олегович', N'belyaev@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (15, N'Яковлева', N'Ирина', N'Петровна', N'yakovleva@example.com', 2)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (16, N'Попов', N'Николай', N'Васильевич', N'popov@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (17, N'Васильева', N'Дарья', N'Алексеевна', N'vasilieva@example.com', 2)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (18, N'Зайцев', N'Роман', N'Юрьевич', N'zaytsev@example.com', 1)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (19, N'Куликова', N'Наталья', N'Викторовна', N'kulikova@example.com', 3)
INSERT [dbo].[Staff] ([id_staff], [lastname_staff], [name_staff], [patronymic_staff], [email_staff], [id_post]) VALUES (20, N'Егоров', N'Артём', N'Никитич', N'egorov@example.com', 3)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (1, N'prokaznikov_iv', N'12345', 1)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (2, N'ivanov_ok', N'12345', 2)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (3, N'karpov_dv', N'12345', 3)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (4, N'smirnov_ap', N'K3fL2mD8', 4)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (5, N'fedorova_mn', N'jWq93LpT', 5)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (6, N'kuznecov_ai', N'TbL4mE9x', 6)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (7, N'pavlova_ss', N'nK82XyLp', 7)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (8, N'nikitin_ea', N'rD73VbqP', 8)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (9, N'sorokina_av', N'YpL48mQz', 9)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (10, N'volkov_tm', N'Mx3Q9rTn', 10)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (11, N'gromova_em', N'sK72LfW9', 11)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (12, N'morozov_va', N'Bq9XyP7k', 12)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (13, N'koval_tr', N'JwL72zKm', 13)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (14, N'belyaev_ko', N'RqP47nXc', 14)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (15, N'yakovleva_ip', N'qV7LzW3t', 15)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (16, N'popov_nv', N'Lm8RpZq3', 16)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (17, N'vasilieva_da', N'ZpK3nVx8', 17)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (18, N'zaytsev_ry', N'W7kRpLm2', 18)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (19, N'kulikova_nv', N'PvK49zLm', 19)
INSERT [dbo].[User] ([id_user], [user_name], [user_password], [id_staff]) VALUES (20, N'egorov_an', N'TqX93bKp', 20)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Work_Entry] ON 

INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (1, 2, CAST(N'2025-03-23' AS Date), 1, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (2, 1, CAST(N'2025-03-21' AS Date), 1, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (3, 4, CAST(N'2025-03-17' AS Date), 1, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (4, 7, CAST(N'2025-03-11' AS Date), 1, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (5, 3, CAST(N'2025-03-09' AS Date), 1, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (6, 2, CAST(N'2025-03-24' AS Date), 1, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (11, 10, CAST(N'2024-01-06' AS Date), 1, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (12, 7, CAST(N'2024-01-28' AS Date), 1, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (13, 2, CAST(N'2024-02-07' AS Date), 1, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (14, 9, CAST(N'2024-02-15' AS Date), 1, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (15, 4, CAST(N'2024-03-14' AS Date), 1, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (16, 5, CAST(N'2024-03-18' AS Date), 1, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (17, 5, CAST(N'2024-04-19' AS Date), 1, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (18, 4, CAST(N'2024-04-24' AS Date), 1, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (19, 2, CAST(N'2024-05-20' AS Date), 1, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (20, 3, CAST(N'2024-05-03' AS Date), 1, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (21, 10, CAST(N'2024-06-13' AS Date), 1, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (22, 1, CAST(N'2024-06-20' AS Date), 1, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (23, 2, CAST(N'2024-07-16' AS Date), 1, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (24, 2, CAST(N'2024-07-25' AS Date), 1, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (25, 7, CAST(N'2024-08-07' AS Date), 1, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (26, 7, CAST(N'2024-08-21' AS Date), 1, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (27, 6, CAST(N'2024-09-10' AS Date), 1, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (28, 5, CAST(N'2024-09-11' AS Date), 1, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (29, 7, CAST(N'2024-10-03' AS Date), 1, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (30, 4, CAST(N'2024-10-19' AS Date), 1, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (31, 7, CAST(N'2024-11-18' AS Date), 1, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (32, 9, CAST(N'2024-11-08' AS Date), 1, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (33, 5, CAST(N'2024-12-27' AS Date), 1, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (34, 9, CAST(N'2024-12-11' AS Date), 1, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (35, 4, CAST(N'2025-01-22' AS Date), 1, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (36, 8, CAST(N'2025-01-25' AS Date), 1, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (37, 2, CAST(N'2025-02-10' AS Date), 1, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (38, 2, CAST(N'2025-02-02' AS Date), 1, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (39, 6, CAST(N'2025-03-01' AS Date), 1, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (40, 1, CAST(N'2025-03-21' AS Date), 1, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (41, 1, CAST(N'2025-04-12' AS Date), 1, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (42, 7, CAST(N'2025-04-27' AS Date), 1, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (43, 4, CAST(N'2025-05-23' AS Date), 1, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (44, 9, CAST(N'2025-05-20' AS Date), 1, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (45, 8, CAST(N'2025-06-17' AS Date), 1, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (46, 4, CAST(N'2025-06-18' AS Date), 1, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (47, 4, CAST(N'2025-03-20' AS Date), 1, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (48, 4, CAST(N'2025-02-14' AS Date), 1, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (49, 9, CAST(N'2025-05-02' AS Date), 1, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (50, 1, CAST(N'2025-02-20' AS Date), 1, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (51, 9, CAST(N'2024-01-09' AS Date), 2, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (52, 4, CAST(N'2024-01-24' AS Date), 2, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (53, 5, CAST(N'2024-02-10' AS Date), 2, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (54, 2, CAST(N'2024-02-12' AS Date), 2, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (55, 6, CAST(N'2024-03-07' AS Date), 2, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (56, 10, CAST(N'2024-03-06' AS Date), 2, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (57, 1, CAST(N'2024-04-07' AS Date), 2, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (58, 5, CAST(N'2024-04-15' AS Date), 2, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (59, 2, CAST(N'2024-05-24' AS Date), 2, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (60, 2, CAST(N'2024-05-14' AS Date), 2, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (61, 8, CAST(N'2024-06-28' AS Date), 2, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (62, 6, CAST(N'2024-06-10' AS Date), 2, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (63, 2, CAST(N'2024-07-03' AS Date), 2, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (64, 7, CAST(N'2024-07-10' AS Date), 2, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (65, 9, CAST(N'2024-08-12' AS Date), 2, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (66, 5, CAST(N'2024-08-13' AS Date), 2, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (67, 7, CAST(N'2024-09-20' AS Date), 2, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (68, 2, CAST(N'2024-09-07' AS Date), 2, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (69, 1, CAST(N'2024-10-12' AS Date), 2, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (70, 7, CAST(N'2024-10-27' AS Date), 2, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (71, 4, CAST(N'2024-11-02' AS Date), 2, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (72, 5, CAST(N'2024-11-05' AS Date), 2, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (73, 10, CAST(N'2024-12-05' AS Date), 2, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (74, 8, CAST(N'2024-12-04' AS Date), 2, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (75, 7, CAST(N'2025-01-16' AS Date), 2, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (76, 1, CAST(N'2025-01-07' AS Date), 2, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (77, 1, CAST(N'2025-02-19' AS Date), 2, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (78, 1, CAST(N'2025-02-21' AS Date), 2, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (79, 9, CAST(N'2025-03-25' AS Date), 2, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (80, 7, CAST(N'2025-03-17' AS Date), 2, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (81, 3, CAST(N'2025-04-22' AS Date), 2, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (82, 2, CAST(N'2025-04-04' AS Date), 2, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (83, 10, CAST(N'2025-05-11' AS Date), 2, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (84, 10, CAST(N'2025-05-02' AS Date), 2, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (85, 10, CAST(N'2025-06-01' AS Date), 2, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (86, 2, CAST(N'2025-06-20' AS Date), 2, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (87, 7, CAST(N'2025-03-27' AS Date), 2, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (88, 5, CAST(N'2025-06-10' AS Date), 2, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (89, 5, CAST(N'2025-04-06' AS Date), 2, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (90, 2, CAST(N'2025-04-01' AS Date), 2, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (91, 4, CAST(N'2024-01-23' AS Date), 3, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (92, 8, CAST(N'2024-01-28' AS Date), 3, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (93, 8, CAST(N'2024-02-03' AS Date), 3, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (94, 4, CAST(N'2024-02-04' AS Date), 3, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (95, 3, CAST(N'2024-03-13' AS Date), 3, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (96, 1, CAST(N'2024-03-27' AS Date), 3, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (97, 3, CAST(N'2024-04-05' AS Date), 3, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (98, 2, CAST(N'2024-04-20' AS Date), 3, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (99, 6, CAST(N'2024-05-25' AS Date), 3, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (100, 2, CAST(N'2024-05-18' AS Date), 3, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (101, 7, CAST(N'2024-06-21' AS Date), 3, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (102, 8, CAST(N'2024-06-26' AS Date), 3, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (103, 9, CAST(N'2024-07-16' AS Date), 3, 2)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (104, 3, CAST(N'2024-07-05' AS Date), 3, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (105, 9, CAST(N'2024-08-09' AS Date), 3, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (106, 7, CAST(N'2024-08-20' AS Date), 3, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (107, 7, CAST(N'2024-09-22' AS Date), 3, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (108, 8, CAST(N'2024-09-02' AS Date), 3, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (109, 5, CAST(N'2024-10-05' AS Date), 3, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (110, 3, CAST(N'2024-10-06' AS Date), 3, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (111, 4, CAST(N'2024-11-18' AS Date), 3, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (112, 7, CAST(N'2024-11-02' AS Date), 3, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (113, 10, CAST(N'2024-12-10' AS Date), 3, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (114, 7, CAST(N'2024-12-03' AS Date), 3, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (115, 6, CAST(N'2025-01-06' AS Date), 3, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (116, 5, CAST(N'2025-01-17' AS Date), 3, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (117, 6, CAST(N'2025-02-18' AS Date), 3, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (118, 5, CAST(N'2025-02-19' AS Date), 3, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (119, 3, CAST(N'2025-03-17' AS Date), 3, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (120, 6, CAST(N'2025-03-28' AS Date), 3, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (121, 8, CAST(N'2025-04-08' AS Date), 3, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (122, 8, CAST(N'2025-04-19' AS Date), 3, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (123, 5, CAST(N'2025-05-20' AS Date), 3, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (124, 3, CAST(N'2025-05-25' AS Date), 3, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (125, 2, CAST(N'2025-06-26' AS Date), 3, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (126, 3, CAST(N'2025-06-25' AS Date), 3, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (127, 3, CAST(N'2025-01-23' AS Date), 3, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (128, 7, CAST(N'2025-05-02' AS Date), 3, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (129, 4, CAST(N'2025-06-11' AS Date), 3, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (130, 9, CAST(N'2025-01-18' AS Date), 3, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (131, 9, CAST(N'2024-01-21' AS Date), 4, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (132, 2, CAST(N'2024-01-20' AS Date), 4, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (133, 1, CAST(N'2024-02-17' AS Date), 4, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (134, 2, CAST(N'2024-02-11' AS Date), 4, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (135, 3, CAST(N'2024-03-23' AS Date), 4, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (136, 9, CAST(N'2024-03-01' AS Date), 4, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (137, 5, CAST(N'2024-04-08' AS Date), 4, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (138, 8, CAST(N'2024-04-26' AS Date), 4, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (139, 1, CAST(N'2024-05-25' AS Date), 4, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (140, 2, CAST(N'2024-05-19' AS Date), 4, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (141, 1, CAST(N'2024-06-22' AS Date), 4, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (142, 5, CAST(N'2024-06-26' AS Date), 4, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (143, 4, CAST(N'2024-07-09' AS Date), 4, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (144, 1, CAST(N'2024-07-16' AS Date), 4, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (145, 8, CAST(N'2024-08-05' AS Date), 4, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (146, 7, CAST(N'2024-08-15' AS Date), 4, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (147, 10, CAST(N'2024-09-19' AS Date), 4, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (148, 9, CAST(N'2024-09-09' AS Date), 4, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (149, 2, CAST(N'2024-10-06' AS Date), 4, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (150, 6, CAST(N'2024-10-18' AS Date), 4, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (151, 9, CAST(N'2024-11-01' AS Date), 4, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (152, 5, CAST(N'2024-11-25' AS Date), 4, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (153, 6, CAST(N'2024-12-14' AS Date), 4, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (154, 1, CAST(N'2024-12-03' AS Date), 4, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (155, 8, CAST(N'2025-01-22' AS Date), 4, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (156, 5, CAST(N'2025-01-06' AS Date), 4, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (157, 5, CAST(N'2025-02-13' AS Date), 4, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (158, 6, CAST(N'2025-02-07' AS Date), 4, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (159, 9, CAST(N'2025-03-17' AS Date), 4, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (160, 1, CAST(N'2025-03-09' AS Date), 4, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (161, 2, CAST(N'2025-04-24' AS Date), 4, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (162, 5, CAST(N'2025-04-20' AS Date), 4, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (163, 10, CAST(N'2025-05-16' AS Date), 4, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (164, 2, CAST(N'2025-05-28' AS Date), 4, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (165, 4, CAST(N'2025-06-22' AS Date), 4, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (166, 8, CAST(N'2025-06-04' AS Date), 4, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (167, 6, CAST(N'2025-04-16' AS Date), 4, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (168, 5, CAST(N'2025-03-03' AS Date), 4, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (169, 4, CAST(N'2025-02-25' AS Date), 4, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (170, 7, CAST(N'2025-02-18' AS Date), 4, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (171, 10, CAST(N'2024-01-07' AS Date), 5, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (172, 7, CAST(N'2024-01-23' AS Date), 5, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (173, 5, CAST(N'2024-02-10' AS Date), 5, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (174, 3, CAST(N'2024-02-07' AS Date), 5, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (175, 6, CAST(N'2024-03-19' AS Date), 5, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (176, 9, CAST(N'2024-03-24' AS Date), 5, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (177, 9, CAST(N'2024-04-03' AS Date), 5, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (178, 7, CAST(N'2024-04-23' AS Date), 5, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (179, 1, CAST(N'2024-05-11' AS Date), 5, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (180, 1, CAST(N'2024-05-28' AS Date), 5, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (181, 5, CAST(N'2024-06-21' AS Date), 5, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (182, 6, CAST(N'2024-06-27' AS Date), 5, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (183, 9, CAST(N'2024-07-16' AS Date), 5, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (184, 9, CAST(N'2024-07-11' AS Date), 5, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (185, 2, CAST(N'2024-08-02' AS Date), 5, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (186, 7, CAST(N'2024-08-07' AS Date), 5, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (187, 10, CAST(N'2024-09-18' AS Date), 5, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (188, 7, CAST(N'2024-09-10' AS Date), 5, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (189, 8, CAST(N'2024-10-17' AS Date), 5, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (190, 5, CAST(N'2024-10-20' AS Date), 5, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (191, 7, CAST(N'2024-11-23' AS Date), 5, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (192, 8, CAST(N'2024-11-10' AS Date), 5, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (193, 6, CAST(N'2024-12-21' AS Date), 5, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (194, 8, CAST(N'2024-12-17' AS Date), 5, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (195, 7, CAST(N'2025-01-22' AS Date), 5, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (196, 4, CAST(N'2025-01-24' AS Date), 5, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (197, 7, CAST(N'2025-02-12' AS Date), 5, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (198, 2, CAST(N'2025-02-15' AS Date), 5, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (199, 2, CAST(N'2025-03-05' AS Date), 5, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (200, 3, CAST(N'2025-03-09' AS Date), 5, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (201, 5, CAST(N'2025-04-09' AS Date), 5, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (202, 7, CAST(N'2025-04-15' AS Date), 5, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (203, 6, CAST(N'2025-05-03' AS Date), 5, 15)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (204, 4, CAST(N'2025-05-26' AS Date), 5, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (205, 8, CAST(N'2025-06-12' AS Date), 5, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (206, 5, CAST(N'2025-06-25' AS Date), 5, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (207, 10, CAST(N'2025-04-28' AS Date), 5, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (208, 6, CAST(N'2025-04-01' AS Date), 5, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (209, 6, CAST(N'2025-02-13' AS Date), 5, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (210, 4, CAST(N'2025-04-18' AS Date), 5, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (211, 5, CAST(N'2024-01-11' AS Date), 6, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (212, 8, CAST(N'2024-01-04' AS Date), 6, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (213, 6, CAST(N'2024-02-27' AS Date), 6, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (214, 4, CAST(N'2024-02-03' AS Date), 6, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (215, 10, CAST(N'2024-03-22' AS Date), 6, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (216, 5, CAST(N'2024-03-19' AS Date), 6, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (217, 4, CAST(N'2024-04-07' AS Date), 6, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (218, 3, CAST(N'2024-04-26' AS Date), 6, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (219, 8, CAST(N'2024-05-03' AS Date), 6, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (220, 9, CAST(N'2024-05-11' AS Date), 6, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (221, 10, CAST(N'2024-06-12' AS Date), 6, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (222, 8, CAST(N'2024-06-24' AS Date), 6, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (223, 3, CAST(N'2024-07-12' AS Date), 6, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (224, 6, CAST(N'2024-07-21' AS Date), 6, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (225, 10, CAST(N'2024-08-22' AS Date), 6, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (226, 9, CAST(N'2024-08-28' AS Date), 6, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (227, 1, CAST(N'2024-09-04' AS Date), 6, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (228, 6, CAST(N'2024-09-18' AS Date), 6, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (229, 6, CAST(N'2024-10-12' AS Date), 6, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (230, 2, CAST(N'2024-10-13' AS Date), 6, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (231, 6, CAST(N'2024-11-02' AS Date), 6, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (232, 5, CAST(N'2024-11-09' AS Date), 6, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (233, 5, CAST(N'2024-12-06' AS Date), 6, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (234, 1, CAST(N'2024-12-09' AS Date), 6, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (235, 2, CAST(N'2025-01-06' AS Date), 6, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (236, 9, CAST(N'2025-01-18' AS Date), 6, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (237, 5, CAST(N'2025-02-18' AS Date), 6, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (238, 2, CAST(N'2025-02-27' AS Date), 6, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (239, 5, CAST(N'2025-03-14' AS Date), 6, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (240, 4, CAST(N'2025-03-18' AS Date), 6, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (241, 1, CAST(N'2025-04-23' AS Date), 6, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (242, 1, CAST(N'2025-04-27' AS Date), 6, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (243, 10, CAST(N'2025-05-02' AS Date), 6, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (244, 8, CAST(N'2025-05-05' AS Date), 6, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (245, 1, CAST(N'2025-06-16' AS Date), 6, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (246, 7, CAST(N'2025-06-15' AS Date), 6, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (247, 9, CAST(N'2025-05-04' AS Date), 6, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (248, 8, CAST(N'2025-01-08' AS Date), 6, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (249, 1, CAST(N'2025-04-04' AS Date), 6, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (250, 10, CAST(N'2025-03-15' AS Date), 6, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (251, 2, CAST(N'2024-01-14' AS Date), 7, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (252, 9, CAST(N'2024-01-03' AS Date), 7, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (253, 4, CAST(N'2024-02-05' AS Date), 7, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (254, 4, CAST(N'2024-02-02' AS Date), 7, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (255, 3, CAST(N'2024-03-22' AS Date), 7, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (256, 3, CAST(N'2024-03-04' AS Date), 7, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (257, 1, CAST(N'2024-04-24' AS Date), 7, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (258, 8, CAST(N'2024-04-09' AS Date), 7, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (259, 10, CAST(N'2024-05-01' AS Date), 7, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (260, 3, CAST(N'2024-05-13' AS Date), 7, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (261, 5, CAST(N'2024-06-09' AS Date), 7, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (262, 5, CAST(N'2024-06-18' AS Date), 7, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (263, 6, CAST(N'2024-07-04' AS Date), 7, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (264, 10, CAST(N'2024-07-07' AS Date), 7, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (265, 9, CAST(N'2024-08-06' AS Date), 7, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (266, 2, CAST(N'2024-08-13' AS Date), 7, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (267, 1, CAST(N'2024-09-28' AS Date), 7, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (268, 2, CAST(N'2024-09-15' AS Date), 7, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (269, 10, CAST(N'2024-10-22' AS Date), 7, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (270, 5, CAST(N'2024-10-12' AS Date), 7, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (271, 7, CAST(N'2024-11-11' AS Date), 7, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (272, 8, CAST(N'2024-11-21' AS Date), 7, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (273, 4, CAST(N'2024-12-19' AS Date), 7, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (274, 2, CAST(N'2024-12-04' AS Date), 7, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (275, 8, CAST(N'2025-01-17' AS Date), 7, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (276, 4, CAST(N'2025-01-11' AS Date), 7, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (277, 10, CAST(N'2025-02-10' AS Date), 7, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (278, 8, CAST(N'2025-02-01' AS Date), 7, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (279, 5, CAST(N'2025-03-26' AS Date), 7, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (280, 2, CAST(N'2025-03-15' AS Date), 7, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (281, 7, CAST(N'2025-04-10' AS Date), 7, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (282, 6, CAST(N'2025-04-22' AS Date), 7, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (283, 8, CAST(N'2025-05-24' AS Date), 7, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (284, 7, CAST(N'2025-05-08' AS Date), 7, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (285, 6, CAST(N'2025-06-13' AS Date), 7, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (286, 8, CAST(N'2025-06-04' AS Date), 7, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (287, 3, CAST(N'2025-01-24' AS Date), 7, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (288, 2, CAST(N'2025-03-11' AS Date), 7, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (289, 8, CAST(N'2025-02-09' AS Date), 7, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (290, 10, CAST(N'2025-06-17' AS Date), 7, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (291, 8, CAST(N'2024-01-01' AS Date), 8, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (292, 7, CAST(N'2024-01-08' AS Date), 8, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (293, 5, CAST(N'2024-02-24' AS Date), 8, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (294, 9, CAST(N'2024-02-21' AS Date), 8, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (295, 2, CAST(N'2024-03-17' AS Date), 8, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (296, 6, CAST(N'2024-03-02' AS Date), 8, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (297, 2, CAST(N'2024-04-24' AS Date), 8, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (298, 1, CAST(N'2024-04-25' AS Date), 8, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (299, 8, CAST(N'2024-05-10' AS Date), 8, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (300, 7, CAST(N'2024-05-05' AS Date), 8, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (301, 7, CAST(N'2024-06-09' AS Date), 8, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (302, 9, CAST(N'2024-06-17' AS Date), 8, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (303, 8, CAST(N'2024-07-19' AS Date), 8, 21)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (304, 7, CAST(N'2024-07-17' AS Date), 8, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (305, 8, CAST(N'2024-08-08' AS Date), 8, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (306, 8, CAST(N'2024-08-04' AS Date), 8, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (307, 9, CAST(N'2024-09-14' AS Date), 8, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (308, 5, CAST(N'2024-09-03' AS Date), 8, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (309, 9, CAST(N'2024-10-06' AS Date), 8, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (310, 5, CAST(N'2024-10-04' AS Date), 8, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (311, 9, CAST(N'2024-11-04' AS Date), 8, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (312, 5, CAST(N'2024-11-08' AS Date), 8, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (313, 9, CAST(N'2024-12-04' AS Date), 8, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (314, 7, CAST(N'2024-12-01' AS Date), 8, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (315, 1, CAST(N'2025-01-20' AS Date), 8, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (316, 9, CAST(N'2025-01-08' AS Date), 8, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (317, 10, CAST(N'2025-02-13' AS Date), 8, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (318, 8, CAST(N'2025-02-05' AS Date), 8, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (319, 3, CAST(N'2025-03-03' AS Date), 8, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (320, 3, CAST(N'2025-03-14' AS Date), 8, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (321, 7, CAST(N'2025-04-27' AS Date), 8, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (322, 6, CAST(N'2025-04-08' AS Date), 8, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (323, 10, CAST(N'2025-05-25' AS Date), 8, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (324, 4, CAST(N'2025-05-13' AS Date), 8, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (325, 8, CAST(N'2025-06-04' AS Date), 8, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (326, 9, CAST(N'2025-06-14' AS Date), 8, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (327, 9, CAST(N'2025-06-11' AS Date), 8, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (328, 10, CAST(N'2025-04-05' AS Date), 8, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (329, 4, CAST(N'2025-05-24' AS Date), 8, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (330, 9, CAST(N'2025-02-19' AS Date), 8, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (331, 3, CAST(N'2024-01-09' AS Date), 9, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (332, 3, CAST(N'2024-01-23' AS Date), 9, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (333, 10, CAST(N'2024-02-06' AS Date), 9, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (334, 5, CAST(N'2024-02-22' AS Date), 9, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (335, 3, CAST(N'2024-03-15' AS Date), 9, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (336, 9, CAST(N'2024-03-01' AS Date), 9, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (337, 2, CAST(N'2024-04-17' AS Date), 9, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (338, 7, CAST(N'2024-04-27' AS Date), 9, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (339, 5, CAST(N'2024-05-20' AS Date), 9, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (340, 10, CAST(N'2024-05-05' AS Date), 9, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (341, 2, CAST(N'2024-06-28' AS Date), 9, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (342, 3, CAST(N'2024-06-15' AS Date), 9, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (343, 1, CAST(N'2024-07-23' AS Date), 9, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (344, 7, CAST(N'2024-07-19' AS Date), 9, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (345, 4, CAST(N'2024-08-20' AS Date), 9, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (346, 6, CAST(N'2024-08-25' AS Date), 9, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (347, 7, CAST(N'2024-09-24' AS Date), 9, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (348, 8, CAST(N'2024-09-13' AS Date), 9, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (349, 7, CAST(N'2024-10-19' AS Date), 9, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (350, 4, CAST(N'2024-10-15' AS Date), 9, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (351, 1, CAST(N'2024-11-19' AS Date), 9, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (352, 1, CAST(N'2024-11-13' AS Date), 9, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (353, 6, CAST(N'2024-12-19' AS Date), 9, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (354, 5, CAST(N'2024-12-18' AS Date), 9, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (355, 5, CAST(N'2025-01-18' AS Date), 9, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (356, 8, CAST(N'2025-01-06' AS Date), 9, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (357, 4, CAST(N'2025-02-12' AS Date), 9, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (358, 4, CAST(N'2025-02-23' AS Date), 9, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (359, 4, CAST(N'2025-03-09' AS Date), 9, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (360, 2, CAST(N'2025-03-16' AS Date), 9, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (361, 7, CAST(N'2025-04-27' AS Date), 9, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (362, 1, CAST(N'2025-04-17' AS Date), 9, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (363, 9, CAST(N'2025-05-17' AS Date), 9, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (364, 7, CAST(N'2025-05-10' AS Date), 9, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (365, 10, CAST(N'2025-06-15' AS Date), 9, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (366, 5, CAST(N'2025-06-07' AS Date), 9, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (367, 1, CAST(N'2025-05-21' AS Date), 9, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (368, 8, CAST(N'2025-04-05' AS Date), 9, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (369, 8, CAST(N'2025-01-12' AS Date), 9, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (370, 2, CAST(N'2025-01-17' AS Date), 9, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (371, 5, CAST(N'2024-01-15' AS Date), 10, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (372, 9, CAST(N'2024-01-03' AS Date), 10, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (373, 5, CAST(N'2024-02-13' AS Date), 10, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (374, 7, CAST(N'2024-02-25' AS Date), 10, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (375, 9, CAST(N'2024-03-28' AS Date), 10, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (376, 7, CAST(N'2024-03-12' AS Date), 10, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (377, 10, CAST(N'2024-04-19' AS Date), 10, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (378, 10, CAST(N'2024-04-04' AS Date), 10, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (379, 4, CAST(N'2024-05-20' AS Date), 10, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (380, 9, CAST(N'2024-05-03' AS Date), 10, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (381, 8, CAST(N'2024-06-11' AS Date), 10, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (382, 5, CAST(N'2024-06-27' AS Date), 10, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (383, 10, CAST(N'2024-07-01' AS Date), 10, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (384, 1, CAST(N'2024-07-13' AS Date), 10, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (385, 3, CAST(N'2024-08-27' AS Date), 10, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (386, 1, CAST(N'2024-08-06' AS Date), 10, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (387, 4, CAST(N'2024-09-16' AS Date), 10, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (388, 2, CAST(N'2024-09-22' AS Date), 10, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (389, 5, CAST(N'2024-10-05' AS Date), 10, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (390, 5, CAST(N'2024-10-13' AS Date), 10, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (391, 6, CAST(N'2024-11-28' AS Date), 10, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (392, 9, CAST(N'2024-11-13' AS Date), 10, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (393, 1, CAST(N'2024-12-26' AS Date), 10, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (394, 2, CAST(N'2024-12-01' AS Date), 10, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (395, 2, CAST(N'2025-01-14' AS Date), 10, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (396, 5, CAST(N'2025-01-26' AS Date), 10, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (397, 10, CAST(N'2025-02-20' AS Date), 10, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (398, 4, CAST(N'2025-02-16' AS Date), 10, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (399, 2, CAST(N'2025-03-23' AS Date), 10, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (400, 9, CAST(N'2025-03-28' AS Date), 10, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (401, 7, CAST(N'2025-04-24' AS Date), 10, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (402, 10, CAST(N'2025-04-02' AS Date), 10, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (403, 10, CAST(N'2025-05-19' AS Date), 10, 3)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (404, 5, CAST(N'2025-05-05' AS Date), 10, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (405, 1, CAST(N'2025-06-24' AS Date), 10, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (406, 4, CAST(N'2025-06-21' AS Date), 10, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (407, 1, CAST(N'2025-05-24' AS Date), 10, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (408, 8, CAST(N'2025-04-18' AS Date), 10, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (409, 7, CAST(N'2025-01-02' AS Date), 10, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (410, 8, CAST(N'2025-06-27' AS Date), 10, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (411, 4, CAST(N'2024-01-14' AS Date), 11, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (412, 6, CAST(N'2024-01-04' AS Date), 11, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (413, 1, CAST(N'2024-02-05' AS Date), 11, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (414, 5, CAST(N'2024-02-13' AS Date), 11, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (415, 7, CAST(N'2024-03-12' AS Date), 11, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (416, 4, CAST(N'2024-03-01' AS Date), 11, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (417, 6, CAST(N'2024-04-15' AS Date), 11, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (418, 5, CAST(N'2024-04-28' AS Date), 11, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (419, 9, CAST(N'2024-05-11' AS Date), 11, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (420, 10, CAST(N'2024-05-22' AS Date), 11, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (421, 2, CAST(N'2024-06-04' AS Date), 11, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (422, 6, CAST(N'2024-06-26' AS Date), 11, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (423, 10, CAST(N'2024-07-19' AS Date), 11, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (424, 8, CAST(N'2024-07-07' AS Date), 11, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (425, 5, CAST(N'2024-08-11' AS Date), 11, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (426, 7, CAST(N'2024-08-06' AS Date), 11, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (427, 5, CAST(N'2024-09-16' AS Date), 11, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (428, 2, CAST(N'2024-09-21' AS Date), 11, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (429, 8, CAST(N'2024-10-07' AS Date), 11, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (430, 4, CAST(N'2024-10-13' AS Date), 11, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (431, 9, CAST(N'2024-11-26' AS Date), 11, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (432, 6, CAST(N'2024-11-27' AS Date), 11, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (433, 6, CAST(N'2024-12-11' AS Date), 11, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (434, 9, CAST(N'2024-12-08' AS Date), 11, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (435, 8, CAST(N'2025-01-26' AS Date), 11, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (436, 4, CAST(N'2025-01-04' AS Date), 11, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (437, 2, CAST(N'2025-02-18' AS Date), 11, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (438, 8, CAST(N'2025-02-12' AS Date), 11, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (439, 7, CAST(N'2025-03-23' AS Date), 11, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (440, 9, CAST(N'2025-03-05' AS Date), 11, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (441, 8, CAST(N'2025-04-26' AS Date), 11, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (442, 9, CAST(N'2025-04-13' AS Date), 11, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (443, 6, CAST(N'2025-05-16' AS Date), 11, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (444, 3, CAST(N'2025-05-22' AS Date), 11, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (445, 4, CAST(N'2025-06-20' AS Date), 11, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (446, 3, CAST(N'2025-06-15' AS Date), 11, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (447, 1, CAST(N'2025-03-27' AS Date), 11, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (448, 9, CAST(N'2025-06-21' AS Date), 11, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (449, 5, CAST(N'2025-06-22' AS Date), 11, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (450, 10, CAST(N'2025-02-05' AS Date), 11, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (451, 4, CAST(N'2024-01-17' AS Date), 12, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (452, 9, CAST(N'2024-01-11' AS Date), 12, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (453, 9, CAST(N'2024-02-18' AS Date), 12, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (454, 4, CAST(N'2024-02-12' AS Date), 12, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (455, 7, CAST(N'2024-03-05' AS Date), 12, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (456, 8, CAST(N'2024-03-27' AS Date), 12, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (457, 7, CAST(N'2024-04-23' AS Date), 12, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (458, 5, CAST(N'2024-04-12' AS Date), 12, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (459, 6, CAST(N'2024-05-20' AS Date), 12, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (460, 5, CAST(N'2024-05-22' AS Date), 12, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (461, 6, CAST(N'2024-06-27' AS Date), 12, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (462, 7, CAST(N'2024-06-11' AS Date), 12, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (463, 4, CAST(N'2024-07-15' AS Date), 12, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (464, 3, CAST(N'2024-07-02' AS Date), 12, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (465, 10, CAST(N'2024-08-15' AS Date), 12, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (466, 8, CAST(N'2024-08-09' AS Date), 12, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (467, 4, CAST(N'2024-09-04' AS Date), 12, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (468, 9, CAST(N'2024-09-28' AS Date), 12, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (469, 5, CAST(N'2024-10-05' AS Date), 12, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (470, 6, CAST(N'2024-10-08' AS Date), 12, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (471, 4, CAST(N'2024-11-26' AS Date), 12, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (472, 4, CAST(N'2024-11-08' AS Date), 12, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (473, 1, CAST(N'2024-12-18' AS Date), 12, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (474, 9, CAST(N'2024-12-07' AS Date), 12, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (475, 7, CAST(N'2025-01-06' AS Date), 12, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (476, 5, CAST(N'2025-01-17' AS Date), 12, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (477, 4, CAST(N'2025-02-27' AS Date), 12, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (478, 8, CAST(N'2025-02-15' AS Date), 12, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (479, 2, CAST(N'2025-03-12' AS Date), 12, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (480, 1, CAST(N'2025-03-18' AS Date), 12, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (481, 9, CAST(N'2025-04-14' AS Date), 12, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (482, 1, CAST(N'2025-04-17' AS Date), 12, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (483, 7, CAST(N'2025-05-02' AS Date), 12, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (484, 3, CAST(N'2025-05-17' AS Date), 12, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (485, 7, CAST(N'2025-06-26' AS Date), 12, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (486, 10, CAST(N'2025-06-15' AS Date), 12, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (487, 5, CAST(N'2025-06-04' AS Date), 12, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (488, 4, CAST(N'2025-04-28' AS Date), 12, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (489, 6, CAST(N'2025-05-26' AS Date), 12, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (490, 8, CAST(N'2025-03-26' AS Date), 12, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (491, 9, CAST(N'2024-01-20' AS Date), 13, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (492, 3, CAST(N'2024-01-26' AS Date), 13, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (493, 1, CAST(N'2024-02-06' AS Date), 13, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (494, 2, CAST(N'2024-02-12' AS Date), 13, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (495, 6, CAST(N'2024-03-03' AS Date), 13, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (496, 5, CAST(N'2024-03-10' AS Date), 13, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (497, 4, CAST(N'2024-04-08' AS Date), 13, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (498, 8, CAST(N'2024-04-05' AS Date), 13, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (499, 7, CAST(N'2024-05-26' AS Date), 13, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (500, 10, CAST(N'2024-05-13' AS Date), 13, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (501, 10, CAST(N'2024-06-05' AS Date), 13, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (502, 6, CAST(N'2024-06-22' AS Date), 13, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (503, 7, CAST(N'2024-07-14' AS Date), 13, 1)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (504, 10, CAST(N'2024-07-08' AS Date), 13, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (505, 6, CAST(N'2024-08-05' AS Date), 13, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (506, 1, CAST(N'2024-08-15' AS Date), 13, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (507, 10, CAST(N'2024-09-17' AS Date), 13, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (508, 8, CAST(N'2024-09-10' AS Date), 13, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (509, 9, CAST(N'2024-10-26' AS Date), 13, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (510, 7, CAST(N'2024-10-19' AS Date), 13, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (511, 8, CAST(N'2024-11-08' AS Date), 13, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (512, 6, CAST(N'2024-11-18' AS Date), 13, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (513, 8, CAST(N'2024-12-28' AS Date), 13, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (514, 4, CAST(N'2024-12-02' AS Date), 13, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (515, 6, CAST(N'2025-01-26' AS Date), 13, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (516, 5, CAST(N'2025-01-12' AS Date), 13, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (517, 9, CAST(N'2025-02-18' AS Date), 13, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (518, 10, CAST(N'2025-02-15' AS Date), 13, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (519, 6, CAST(N'2025-03-09' AS Date), 13, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (520, 1, CAST(N'2025-03-21' AS Date), 13, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (521, 7, CAST(N'2025-04-13' AS Date), 13, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (522, 7, CAST(N'2025-04-15' AS Date), 13, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (523, 3, CAST(N'2025-05-16' AS Date), 13, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (524, 4, CAST(N'2025-05-17' AS Date), 13, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (525, 5, CAST(N'2025-06-08' AS Date), 13, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (526, 9, CAST(N'2025-06-23' AS Date), 13, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (527, 9, CAST(N'2025-06-22' AS Date), 13, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (528, 5, CAST(N'2025-04-25' AS Date), 13, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (529, 5, CAST(N'2025-03-12' AS Date), 13, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (530, 4, CAST(N'2025-06-25' AS Date), 13, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (531, 5, CAST(N'2024-01-21' AS Date), 14, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (532, 5, CAST(N'2024-01-05' AS Date), 14, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (533, 9, CAST(N'2024-02-17' AS Date), 14, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (534, 10, CAST(N'2024-02-12' AS Date), 14, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (535, 10, CAST(N'2024-03-02' AS Date), 14, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (536, 8, CAST(N'2024-03-25' AS Date), 14, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (537, 1, CAST(N'2024-04-03' AS Date), 14, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (538, 6, CAST(N'2024-04-14' AS Date), 14, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (539, 4, CAST(N'2024-05-15' AS Date), 14, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (540, 9, CAST(N'2024-05-07' AS Date), 14, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (541, 3, CAST(N'2024-06-21' AS Date), 14, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (542, 7, CAST(N'2024-06-12' AS Date), 14, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (543, 4, CAST(N'2024-07-02' AS Date), 14, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (544, 7, CAST(N'2024-07-16' AS Date), 14, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (545, 7, CAST(N'2024-08-07' AS Date), 14, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (546, 8, CAST(N'2024-08-09' AS Date), 14, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (547, 4, CAST(N'2024-09-25' AS Date), 14, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (548, 10, CAST(N'2024-09-16' AS Date), 14, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (549, 7, CAST(N'2024-10-25' AS Date), 14, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (550, 10, CAST(N'2024-10-13' AS Date), 14, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (551, 10, CAST(N'2024-11-19' AS Date), 14, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (552, 6, CAST(N'2024-11-08' AS Date), 14, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (553, 3, CAST(N'2024-12-10' AS Date), 14, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (554, 2, CAST(N'2024-12-06' AS Date), 14, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (555, 1, CAST(N'2025-01-20' AS Date), 14, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (556, 3, CAST(N'2025-01-28' AS Date), 14, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (557, 7, CAST(N'2025-02-15' AS Date), 14, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (558, 5, CAST(N'2025-02-26' AS Date), 14, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (559, 2, CAST(N'2025-03-13' AS Date), 14, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (560, 9, CAST(N'2025-03-15' AS Date), 14, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (561, 9, CAST(N'2025-04-08' AS Date), 14, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (562, 4, CAST(N'2025-04-26' AS Date), 14, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (563, 6, CAST(N'2025-05-16' AS Date), 14, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (564, 3, CAST(N'2025-05-21' AS Date), 14, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (565, 1, CAST(N'2025-06-07' AS Date), 14, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (566, 5, CAST(N'2025-06-21' AS Date), 14, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (567, 5, CAST(N'2025-05-18' AS Date), 14, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (568, 2, CAST(N'2025-05-17' AS Date), 14, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (569, 7, CAST(N'2025-02-12' AS Date), 14, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (570, 2, CAST(N'2025-06-14' AS Date), 14, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (571, 10, CAST(N'2024-01-24' AS Date), 15, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (572, 7, CAST(N'2024-01-06' AS Date), 15, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (573, 6, CAST(N'2024-02-23' AS Date), 15, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (574, 5, CAST(N'2024-02-22' AS Date), 15, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (575, 10, CAST(N'2024-03-10' AS Date), 15, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (576, 1, CAST(N'2024-03-27' AS Date), 15, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (577, 9, CAST(N'2024-04-23' AS Date), 15, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (578, 4, CAST(N'2024-04-07' AS Date), 15, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (579, 10, CAST(N'2024-05-03' AS Date), 15, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (580, 4, CAST(N'2024-05-14' AS Date), 15, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (581, 4, CAST(N'2024-06-13' AS Date), 15, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (582, 1, CAST(N'2024-06-28' AS Date), 15, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (583, 8, CAST(N'2024-07-24' AS Date), 15, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (584, 6, CAST(N'2024-07-20' AS Date), 15, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (585, 2, CAST(N'2024-08-07' AS Date), 15, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (586, 1, CAST(N'2024-08-27' AS Date), 15, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (587, 2, CAST(N'2024-09-01' AS Date), 15, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (588, 9, CAST(N'2024-09-18' AS Date), 15, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (589, 6, CAST(N'2024-10-02' AS Date), 15, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (590, 9, CAST(N'2024-10-06' AS Date), 15, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (591, 2, CAST(N'2024-11-01' AS Date), 15, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (592, 2, CAST(N'2024-11-19' AS Date), 15, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (593, 1, CAST(N'2024-12-07' AS Date), 15, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (594, 6, CAST(N'2024-12-21' AS Date), 15, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (595, 3, CAST(N'2025-01-27' AS Date), 15, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (596, 5, CAST(N'2025-01-04' AS Date), 15, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (597, 8, CAST(N'2025-02-02' AS Date), 15, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (598, 7, CAST(N'2025-02-09' AS Date), 15, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (599, 8, CAST(N'2025-03-18' AS Date), 15, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (600, 1, CAST(N'2025-03-27' AS Date), 15, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (601, 7, CAST(N'2025-04-28' AS Date), 15, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (602, 3, CAST(N'2025-04-13' AS Date), 15, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (603, 9, CAST(N'2025-05-12' AS Date), 15, 10)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (604, 2, CAST(N'2025-05-07' AS Date), 15, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (605, 3, CAST(N'2025-06-13' AS Date), 15, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (606, 1, CAST(N'2025-06-22' AS Date), 15, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (607, 6, CAST(N'2025-03-23' AS Date), 15, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (608, 3, CAST(N'2025-03-13' AS Date), 15, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (609, 10, CAST(N'2025-05-17' AS Date), 15, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (610, 1, CAST(N'2025-03-06' AS Date), 15, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (611, 8, CAST(N'2024-01-09' AS Date), 16, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (612, 8, CAST(N'2024-01-14' AS Date), 16, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (613, 10, CAST(N'2024-02-26' AS Date), 16, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (614, 5, CAST(N'2024-02-13' AS Date), 16, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (615, 4, CAST(N'2024-03-14' AS Date), 16, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (616, 2, CAST(N'2024-03-01' AS Date), 16, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (617, 8, CAST(N'2024-04-01' AS Date), 16, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (618, 7, CAST(N'2024-04-14' AS Date), 16, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (619, 4, CAST(N'2024-05-08' AS Date), 16, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (620, 4, CAST(N'2024-05-18' AS Date), 16, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (621, 7, CAST(N'2024-06-14' AS Date), 16, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (622, 5, CAST(N'2024-06-05' AS Date), 16, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (623, 6, CAST(N'2024-07-21' AS Date), 16, 1)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (624, 4, CAST(N'2024-07-16' AS Date), 16, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (625, 4, CAST(N'2024-08-16' AS Date), 16, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (626, 6, CAST(N'2024-08-26' AS Date), 16, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (627, 9, CAST(N'2024-09-26' AS Date), 16, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (628, 9, CAST(N'2024-09-10' AS Date), 16, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (629, 3, CAST(N'2024-10-23' AS Date), 16, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (630, 3, CAST(N'2024-10-28' AS Date), 16, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (631, 10, CAST(N'2024-11-23' AS Date), 16, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (632, 3, CAST(N'2024-11-12' AS Date), 16, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (633, 4, CAST(N'2024-12-05' AS Date), 16, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (634, 9, CAST(N'2024-12-27' AS Date), 16, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (635, 5, CAST(N'2025-01-02' AS Date), 16, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (636, 10, CAST(N'2025-01-03' AS Date), 16, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (637, 9, CAST(N'2025-02-25' AS Date), 16, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (638, 3, CAST(N'2025-02-23' AS Date), 16, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (639, 4, CAST(N'2025-03-21' AS Date), 16, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (640, 3, CAST(N'2025-03-16' AS Date), 16, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (641, 7, CAST(N'2025-04-11' AS Date), 16, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (642, 6, CAST(N'2025-04-01' AS Date), 16, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (643, 10, CAST(N'2025-05-02' AS Date), 16, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (644, 5, CAST(N'2025-05-14' AS Date), 16, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (645, 6, CAST(N'2025-06-23' AS Date), 16, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (646, 7, CAST(N'2025-06-13' AS Date), 16, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (647, 7, CAST(N'2025-02-03' AS Date), 16, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (648, 9, CAST(N'2025-04-05' AS Date), 16, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (649, 6, CAST(N'2025-02-13' AS Date), 16, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (650, 2, CAST(N'2025-03-25' AS Date), 16, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (651, 8, CAST(N'2024-01-19' AS Date), 17, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (652, 4, CAST(N'2024-01-09' AS Date), 17, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (653, 7, CAST(N'2024-02-20' AS Date), 17, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (654, 8, CAST(N'2024-02-14' AS Date), 17, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (655, 8, CAST(N'2024-03-25' AS Date), 17, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (656, 10, CAST(N'2024-03-17' AS Date), 17, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (657, 4, CAST(N'2024-04-05' AS Date), 17, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (658, 7, CAST(N'2024-04-28' AS Date), 17, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (659, 4, CAST(N'2024-05-14' AS Date), 17, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (660, 6, CAST(N'2024-05-13' AS Date), 17, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (661, 1, CAST(N'2024-06-13' AS Date), 17, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (662, 9, CAST(N'2024-06-06' AS Date), 17, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (663, 3, CAST(N'2024-07-21' AS Date), 17, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (664, 2, CAST(N'2024-07-27' AS Date), 17, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (665, 1, CAST(N'2024-08-09' AS Date), 17, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (666, 2, CAST(N'2024-08-25' AS Date), 17, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (667, 1, CAST(N'2024-09-07' AS Date), 17, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (668, 7, CAST(N'2024-09-10' AS Date), 17, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (669, 4, CAST(N'2024-10-21' AS Date), 17, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (670, 10, CAST(N'2024-10-27' AS Date), 17, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (671, 5, CAST(N'2024-11-10' AS Date), 17, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (672, 10, CAST(N'2024-11-11' AS Date), 17, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (673, 8, CAST(N'2024-12-05' AS Date), 17, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (674, 3, CAST(N'2024-12-27' AS Date), 17, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (675, 2, CAST(N'2025-01-17' AS Date), 17, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (676, 4, CAST(N'2025-01-01' AS Date), 17, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (677, 9, CAST(N'2025-02-02' AS Date), 17, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (678, 1, CAST(N'2025-02-03' AS Date), 17, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (679, 3, CAST(N'2025-03-08' AS Date), 17, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (680, 5, CAST(N'2025-03-17' AS Date), 17, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (681, 9, CAST(N'2025-04-12' AS Date), 17, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (682, 4, CAST(N'2025-04-04' AS Date), 17, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (683, 8, CAST(N'2025-05-24' AS Date), 17, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (684, 4, CAST(N'2025-05-09' AS Date), 17, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (685, 10, CAST(N'2025-06-12' AS Date), 17, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (686, 2, CAST(N'2025-06-06' AS Date), 17, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (687, 6, CAST(N'2025-03-12' AS Date), 17, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (688, 1, CAST(N'2025-05-27' AS Date), 17, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (689, 5, CAST(N'2025-04-14' AS Date), 17, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (690, 9, CAST(N'2025-04-09' AS Date), 17, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (691, 8, CAST(N'2024-01-06' AS Date), 18, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (692, 9, CAST(N'2024-01-13' AS Date), 18, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (693, 9, CAST(N'2024-02-09' AS Date), 18, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (694, 3, CAST(N'2024-02-22' AS Date), 18, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (695, 5, CAST(N'2024-03-15' AS Date), 18, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (696, 3, CAST(N'2024-03-08' AS Date), 18, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (697, 3, CAST(N'2024-04-07' AS Date), 18, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (698, 3, CAST(N'2024-04-09' AS Date), 18, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (699, 9, CAST(N'2024-05-22' AS Date), 18, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (700, 8, CAST(N'2024-05-15' AS Date), 18, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (701, 9, CAST(N'2024-06-15' AS Date), 18, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (702, 2, CAST(N'2024-06-16' AS Date), 18, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (703, 1, CAST(N'2024-07-16' AS Date), 18, 13)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (704, 5, CAST(N'2024-07-19' AS Date), 18, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (705, 3, CAST(N'2024-08-12' AS Date), 18, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (706, 3, CAST(N'2024-08-07' AS Date), 18, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (707, 3, CAST(N'2024-09-18' AS Date), 18, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (708, 5, CAST(N'2024-09-27' AS Date), 18, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (709, 3, CAST(N'2024-10-08' AS Date), 18, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (710, 1, CAST(N'2024-10-23' AS Date), 18, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (711, 8, CAST(N'2024-11-08' AS Date), 18, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (712, 9, CAST(N'2024-11-05' AS Date), 18, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (713, 3, CAST(N'2024-12-05' AS Date), 18, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (714, 10, CAST(N'2024-12-21' AS Date), 18, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (715, 5, CAST(N'2025-01-09' AS Date), 18, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (716, 7, CAST(N'2025-01-19' AS Date), 18, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (717, 3, CAST(N'2025-02-08' AS Date), 18, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (718, 2, CAST(N'2025-02-13' AS Date), 18, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (719, 6, CAST(N'2025-03-25' AS Date), 18, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (720, 10, CAST(N'2025-03-09' AS Date), 18, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (721, 5, CAST(N'2025-04-25' AS Date), 18, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (722, 2, CAST(N'2025-04-23' AS Date), 18, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (723, 9, CAST(N'2025-05-11' AS Date), 18, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (724, 4, CAST(N'2025-05-12' AS Date), 18, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (725, 2, CAST(N'2025-06-22' AS Date), 18, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (726, 6, CAST(N'2025-06-28' AS Date), 18, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (727, 10, CAST(N'2025-03-20' AS Date), 18, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (728, 7, CAST(N'2025-06-11' AS Date), 18, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (729, 1, CAST(N'2025-04-11' AS Date), 18, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (730, 1, CAST(N'2025-06-26' AS Date), 18, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (731, 8, CAST(N'2024-01-25' AS Date), 19, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (732, 7, CAST(N'2024-01-07' AS Date), 19, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (733, 10, CAST(N'2024-02-15' AS Date), 19, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (734, 6, CAST(N'2024-02-23' AS Date), 19, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (735, 2, CAST(N'2024-03-15' AS Date), 19, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (736, 9, CAST(N'2024-03-28' AS Date), 19, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (737, 7, CAST(N'2024-04-12' AS Date), 19, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (738, 8, CAST(N'2024-04-05' AS Date), 19, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (739, 7, CAST(N'2024-05-07' AS Date), 19, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (740, 3, CAST(N'2024-05-21' AS Date), 19, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (741, 1, CAST(N'2024-06-11' AS Date), 19, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (742, 10, CAST(N'2024-06-24' AS Date), 19, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (743, 3, CAST(N'2024-07-06' AS Date), 19, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (744, 6, CAST(N'2024-07-04' AS Date), 19, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (745, 8, CAST(N'2024-08-06' AS Date), 19, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (746, 1, CAST(N'2024-08-05' AS Date), 19, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (747, 5, CAST(N'2024-09-01' AS Date), 19, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (748, 6, CAST(N'2024-09-05' AS Date), 19, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (749, 4, CAST(N'2024-10-25' AS Date), 19, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (750, 7, CAST(N'2024-10-20' AS Date), 19, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (751, 4, CAST(N'2024-11-23' AS Date), 19, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (752, 10, CAST(N'2024-11-08' AS Date), 19, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (753, 6, CAST(N'2024-12-03' AS Date), 19, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (754, 9, CAST(N'2024-12-10' AS Date), 19, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (755, 9, CAST(N'2025-01-01' AS Date), 19, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (756, 8, CAST(N'2025-01-08' AS Date), 19, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (757, 10, CAST(N'2025-02-22' AS Date), 19, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (758, 3, CAST(N'2025-02-17' AS Date), 19, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (759, 5, CAST(N'2025-03-10' AS Date), 19, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (760, 7, CAST(N'2025-03-26' AS Date), 19, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (761, 5, CAST(N'2025-04-23' AS Date), 19, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (762, 5, CAST(N'2025-04-05' AS Date), 19, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (763, 6, CAST(N'2025-05-21' AS Date), 19, 4)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (764, 8, CAST(N'2025-05-18' AS Date), 19, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (765, 8, CAST(N'2025-06-19' AS Date), 19, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (766, 8, CAST(N'2025-06-24' AS Date), 19, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (767, 2, CAST(N'2025-06-15' AS Date), 19, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (768, 9, CAST(N'2025-05-27' AS Date), 19, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (769, 8, CAST(N'2025-04-09' AS Date), 19, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (770, 3, CAST(N'2025-02-19' AS Date), 19, 10)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (771, 6, CAST(N'2024-01-27' AS Date), 20, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (772, 5, CAST(N'2024-01-15' AS Date), 20, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (773, 7, CAST(N'2024-02-19' AS Date), 20, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (774, 1, CAST(N'2024-02-27' AS Date), 20, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (775, 6, CAST(N'2024-03-08' AS Date), 20, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (776, 5, CAST(N'2024-03-13' AS Date), 20, 26)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (777, 2, CAST(N'2024-04-27' AS Date), 20, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (778, 1, CAST(N'2024-04-28' AS Date), 20, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (779, 10, CAST(N'2024-05-02' AS Date), 20, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (780, 8, CAST(N'2024-05-05' AS Date), 20, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (781, 6, CAST(N'2024-06-18' AS Date), 20, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (782, 5, CAST(N'2024-06-21' AS Date), 20, 22)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (783, 7, CAST(N'2024-07-05' AS Date), 20, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (784, 6, CAST(N'2024-07-17' AS Date), 20, 3)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (785, 1, CAST(N'2024-08-23' AS Date), 20, 12)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (786, 9, CAST(N'2024-08-14' AS Date), 20, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (787, 7, CAST(N'2024-09-11' AS Date), 20, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (788, 9, CAST(N'2024-09-15' AS Date), 20, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (789, 1, CAST(N'2024-10-08' AS Date), 20, 15)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (790, 10, CAST(N'2024-10-13' AS Date), 20, 14)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (791, 7, CAST(N'2024-11-17' AS Date), 20, 9)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (792, 8, CAST(N'2024-11-15' AS Date), 20, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (793, 9, CAST(N'2024-12-02' AS Date), 20, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (794, 6, CAST(N'2024-12-08' AS Date), 20, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (795, 6, CAST(N'2025-01-15' AS Date), 20, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (796, 6, CAST(N'2025-01-17' AS Date), 20, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (797, 2, CAST(N'2025-02-26' AS Date), 20, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (798, 1, CAST(N'2025-02-04' AS Date), 20, 13)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (799, 10, CAST(N'2025-03-12' AS Date), 20, 21)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (800, 6, CAST(N'2025-03-05' AS Date), 20, 7)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (801, 10, CAST(N'2025-04-21' AS Date), 20, 23)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (802, 9, CAST(N'2025-04-16' AS Date), 20, 16)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (803, 10, CAST(N'2025-05-14' AS Date), 20, 10)
GO
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (804, 7, CAST(N'2025-05-07' AS Date), 20, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (805, 3, CAST(N'2025-06-26' AS Date), 20, 25)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (806, 8, CAST(N'2025-06-21' AS Date), 20, 11)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (807, 6, CAST(N'2025-03-26' AS Date), 20, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (808, 7, CAST(N'2025-05-16' AS Date), 20, 20)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (809, 4, CAST(N'2025-01-13' AS Date), 20, 24)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (810, 3, CAST(N'2025-02-10' AS Date), 20, 2)
INSERT [dbo].[Work_Entry] ([id_work_entry], [quantity_work_entry], [date_work_entry], [id_staff], [id_work_type]) VALUES (811, 5, CAST(N'2025-05-21' AS Date), 6, 10)
SET IDENTITY_INSERT [dbo].[Work_Entry] OFF
GO
SET IDENTITY_INSERT [dbo].[Work_Type] ON 

INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (1, N'Разработка REST API', 5000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (2, N'Разработка бэкенда для веб-приложения', 20000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (3, N'Разработка WPF-приложения', 10000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (4, N'Разработка телеграм-бота', 7000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (7, N'Настройка и развертывание базы данных', 5000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (9, N'Интеграция внешнего API', 8000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (10, N'Кастомизация Swagger-документации', 3000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (11, N'Оптимизация SQL-запросов и индексация БД', 5000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (12, N'Настройка логирования (Serilog, ELK-стек, Graylog)', 5000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (13, N'Рефакторинг и оптимизация кода (C#)', 7000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (14, N'Разработка мобильного приложения (Android)', 15000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (15, N'Подключение системы авторизации (OAuth 2.0, JWT)', 6000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (16, N'Реализация очередей сообщений (RabbitMQ, Kafka)', 7000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (20, N'Разработка системы экспорта данных (Excel/PDF)', 9000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (21, N'Интеграция с платёжными системами (Stripe, PayPal)', 10000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (22, N'Создание unit- и integration-тестов', 4000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (23, N'Настройка CI/CD (GitHub Actions, GitLab CI)', 5000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (24, N'Миграция базы данных и поддержка версионности', 6000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (25, N'Разработка административной панели', 11000)
INSERT [dbo].[Work_Type] ([id_work_type], [name_work_type], [amount_work_type]) VALUES (26, N'Проведение код-ревью и аудит безопасности', 5500)
SET IDENTITY_INSERT [dbo].[Work_Type] OFF
GO
/****** Object:  Index [IX_Payments_id_payments]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Payments_id_payments] ON [dbo].[Payments]
(
	[id_payments] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_id_payments_type]    Script Date: 21.05.2025 16:26:25 ******/
CREATE NONCLUSTERED INDEX [IX_Payments_id_payments_type] ON [dbo].[Payments]
(
	[id_payments_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_id_staff]    Script Date: 21.05.2025 16:26:25 ******/
CREATE NONCLUSTERED INDEX [IX_Payments_id_staff] ON [dbo].[Payments]
(
	[id_staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_Type_id_payments_type]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Payments_Type_id_payments_type] ON [dbo].[Payments_Type]
(
	[id_payments_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Post_id_post]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Post_id_post] ON [dbo].[Post]
(
	[id_post] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salary_Payment_id_salary_payment]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Salary_Payment_id_salary_payment] ON [dbo].[Salary_Payment]
(
	[id_salary_payment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salary_Payment_id_staff]    Script Date: 21.05.2025 16:26:25 ******/
CREATE NONCLUSTERED INDEX [IX_Salary_Payment_id_staff] ON [dbo].[Salary_Payment]
(
	[id_staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Staff_id_post]    Script Date: 21.05.2025 16:26:25 ******/
CREATE NONCLUSTERED INDEX [IX_Staff_id_post] ON [dbo].[Staff]
(
	[id_post] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Staff_id_staff]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Staff_id_staff] ON [dbo].[Staff]
(
	[id_staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_id_staff]    Script Date: 21.05.2025 16:26:25 ******/
CREATE NONCLUSTERED INDEX [IX_User_id_staff] ON [dbo].[User]
(
	[id_staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_id_user]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_id_user] ON [dbo].[User]
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Work_Entry_id_staff]    Script Date: 21.05.2025 16:26:25 ******/
CREATE NONCLUSTERED INDEX [IX_Work_Entry_id_staff] ON [dbo].[Work_Entry]
(
	[id_staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Work_Entry_id_work_entry]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Work_Entry_id_work_entry] ON [dbo].[Work_Entry]
(
	[id_work_entry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Work_Entry_id_work_type]    Script Date: 21.05.2025 16:26:25 ******/
CREATE NONCLUSTERED INDEX [IX_Work_Entry_id_work_type] ON [dbo].[Work_Entry]
(
	[id_work_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Work_Type_id_work_type]    Script Date: 21.05.2025 16:26:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Work_Type_id_work_type] ON [dbo].[Work_Type]
(
	[id_work_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Payments_Type_id_payments_type] FOREIGN KEY([id_payments_type])
REFERENCES [dbo].[Payments_Type] ([id_payments_type])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Payments_Type_id_payments_type]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Staff_id_staff] FOREIGN KEY([id_staff])
REFERENCES [dbo].[Staff] ([id_staff])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Staff_id_staff]
GO
ALTER TABLE [dbo].[Salary_Payment]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Payment_Staff_id_staff] FOREIGN KEY([id_staff])
REFERENCES [dbo].[Staff] ([id_staff])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Salary_Payment] CHECK CONSTRAINT [FK_Salary_Payment_Staff_id_staff]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Post_id_post] FOREIGN KEY([id_post])
REFERENCES [dbo].[Post] ([id_post])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Post_id_post]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Staff_id_staff] FOREIGN KEY([id_staff])
REFERENCES [dbo].[Staff] ([id_staff])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Staff_id_staff]
GO
ALTER TABLE [dbo].[Work_Entry]  WITH CHECK ADD  CONSTRAINT [FK_Work_Entry_Staff_id_staff] FOREIGN KEY([id_staff])
REFERENCES [dbo].[Staff] ([id_staff])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Work_Entry] CHECK CONSTRAINT [FK_Work_Entry_Staff_id_staff]
GO
ALTER TABLE [dbo].[Work_Entry]  WITH CHECK ADD  CONSTRAINT [FK_Work_Entry_Work_Type_id_work_type] FOREIGN KEY([id_work_type])
REFERENCES [dbo].[Work_Type] ([id_work_type])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Work_Entry] CHECK CONSTRAINT [FK_Work_Entry_Work_Type_id_work_type]
GO
USE [master]
GO
ALTER DATABASE [WageFlowDataBase] SET  READ_WRITE 
GO
