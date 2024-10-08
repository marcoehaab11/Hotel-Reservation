USE [master]
GO
/****** Object:  Database [Hotel]    Script Date: 9/20/2024 7:34:46 PM ******/
CREATE DATABASE [Hotel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Hotel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hotel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Hotel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Hotel] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hotel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hotel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Hotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hotel] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Hotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hotel] SET RECOVERY FULL 
GO
ALTER DATABASE [Hotel] SET  MULTI_USER 
GO
ALTER DATABASE [Hotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hotel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hotel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hotel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hotel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Hotel', N'ON'
GO
ALTER DATABASE [Hotel] SET QUERY_STORE = ON
GO
ALTER DATABASE [Hotel] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Hotel]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/20/2024 7:34:47 PM ******/
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
/****** Object:  Table [dbo].[MealPlanPerSeasons]    Script Date: 9/20/2024 7:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealPlanPerSeasons](
	[MealPlanID] [int] NOT NULL,
	[MealSeasonStartAndEndID] [int] NOT NULL,
	[RatePerPerson] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_MealPlanPerSeasons] PRIMARY KEY CLUSTERED 
(
	[MealPlanID] ASC,
	[MealSeasonStartAndEndID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealPlans]    Script Date: 9/20/2024 7:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealPlans](
	[MealPlanId] [int] IDENTITY(1,1) NOT NULL,
	[MealPlanName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MealPlans] PRIMARY KEY CLUSTERED 
(
	[MealPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealSeasonStartAndEndSeasons]    Script Date: 9/20/2024 7:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealSeasonStartAndEndSeasons](
	[MealSeasonId] [int] IDENTITY(1,1) NOT NULL,
	[SeasonName] [nvarchar](max) NOT NULL,
	[SeasonStartDate] [datetime2](7) NOT NULL,
	[SeasonEndDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MealSeasonStartAndEndSeasons] PRIMARY KEY CLUSTERED 
(
	[MealSeasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 9/20/2024 7:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[CheckInDate] [datetime2](7) NOT NULL,
	[CheckOutDate] [datetime2](7) NOT NULL,
	[NumberOfAdult] [int] NOT NULL,
	[NumberOfChildren] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[MealPlanID] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 9/20/2024 7:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomSeasons]    Script Date: 9/20/2024 7:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomSeasons](
	[RoomTypeId] [int] NOT NULL,
	[RoomSeasonStartAndEndID] [int] NOT NULL,
	[RatePerRoom] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_RoomSeasons] PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC,
	[RoomSeasonStartAndEndID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomSeasonStartAndEnds]    Script Date: 9/20/2024 7:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomSeasonStartAndEnds](
	[SeasonId] [int] IDENTITY(1,1) NOT NULL,
	[SeasonName] [nvarchar](max) NOT NULL,
	[SeasonStartDate] [datetime2](7) NOT NULL,
	[SeasonEndDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RoomSeasonStartAndEnds] PRIMARY KEY CLUSTERED 
(
	[SeasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240908074142_init', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240908110551_two', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240908110843_three', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240908113132_r', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240908135745_manytomany', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240908215050_manyToManyRooms', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910084433_changeRoomName', N'8.0.8')
GO
INSERT [dbo].[MealPlanPerSeasons] ([MealPlanID], [MealSeasonStartAndEndID], [RatePerPerson]) VALUES (1, 2, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[MealPlanPerSeasons] ([MealPlanID], [MealSeasonStartAndEndID], [RatePerPerson]) VALUES (1, 3, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[MealPlanPerSeasons] ([MealPlanID], [MealSeasonStartAndEndID], [RatePerPerson]) VALUES (2, 2, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[MealPlanPerSeasons] ([MealPlanID], [MealSeasonStartAndEndID], [RatePerPerson]) VALUES (2, 3, CAST(25.00 AS Decimal(18, 2)))
INSERT [dbo].[MealPlanPerSeasons] ([MealPlanID], [MealSeasonStartAndEndID], [RatePerPerson]) VALUES (4, 2, CAST(25.00 AS Decimal(18, 2)))
INSERT [dbo].[MealPlanPerSeasons] ([MealPlanID], [MealSeasonStartAndEndID], [RatePerPerson]) VALUES (4, 3, CAST(30.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[MealPlans] ON 

INSERT [dbo].[MealPlans] ([MealPlanId], [MealPlanName]) VALUES (1, N'Half Board')
INSERT [dbo].[MealPlans] ([MealPlanId], [MealPlanName]) VALUES (2, N'Full Board')
INSERT [dbo].[MealPlans] ([MealPlanId], [MealPlanName]) VALUES (4, N'All Inclusive')
SET IDENTITY_INSERT [dbo].[MealPlans] OFF
GO
SET IDENTITY_INSERT [dbo].[MealSeasonStartAndEndSeasons] ON 

INSERT [dbo].[MealSeasonStartAndEndSeasons] ([MealSeasonId], [SeasonName], [SeasonStartDate], [SeasonEndDate]) VALUES (2, N'Low Season', CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-05-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[MealSeasonStartAndEndSeasons] ([MealSeasonId], [SeasonName], [SeasonStartDate], [SeasonEndDate]) VALUES (3, N'High Seasin', CAST(N'2024-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-31T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[MealSeasonStartAndEndSeasons] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomTypeId], [RoomTypeName]) VALUES (1, N'Standard Room')
INSERT [dbo].[Rooms] ([RoomTypeId], [RoomTypeName]) VALUES (2, N'Sea View Room')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
INSERT [dbo].[RoomSeasons] ([RoomTypeId], [RoomSeasonStartAndEndID], [RatePerRoom]) VALUES (1, 1, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[RoomSeasons] ([RoomTypeId], [RoomSeasonStartAndEndID], [RatePerRoom]) VALUES (1, 2, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[RoomSeasons] ([RoomTypeId], [RoomSeasonStartAndEndID], [RatePerRoom]) VALUES (2, 1, CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[RoomSeasons] ([RoomTypeId], [RoomSeasonStartAndEndID], [RatePerRoom]) VALUES (2, 5, CAST(90.00 AS Decimal(18, 2)))
INSERT [dbo].[RoomSeasons] ([RoomTypeId], [RoomSeasonStartAndEndID], [RatePerRoom]) VALUES (2, 6, CAST(100.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[RoomSeasonStartAndEnds] ON 

INSERT [dbo].[RoomSeasonStartAndEnds] ([SeasonId], [SeasonName], [SeasonStartDate], [SeasonEndDate]) VALUES (1, N'1/1/2024 To  15/1/2024', CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoomSeasonStartAndEnds] ([SeasonId], [SeasonName], [SeasonStartDate], [SeasonEndDate]) VALUES (2, N'16/1/2024 To 30/4/2024', CAST(N'2024-01-16T00:00:00.0000000' AS DateTime2), CAST(N'2024-04-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoomSeasonStartAndEnds] ([SeasonId], [SeasonName], [SeasonStartDate], [SeasonEndDate]) VALUES (5, N'16/1/2024 To 31/3/2024', CAST(N'2024-01-16T00:00:00.0000000' AS DateTime2), CAST(N'2024-03-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoomSeasonStartAndEnds] ([SeasonId], [SeasonName], [SeasonStartDate], [SeasonEndDate]) VALUES (6, N'1/4/2024 To 30/4/2024', CAST(N'2024-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-04-30T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[RoomSeasonStartAndEnds] OFF
GO
/****** Object:  Index [IX_MealPlanPerSeasons_MealSeasonStartAndEndID]    Script Date: 9/20/2024 7:34:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_MealPlanPerSeasons_MealSeasonStartAndEndID] ON [dbo].[MealPlanPerSeasons]
(
	[MealSeasonStartAndEndID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_MealPlanID]    Script Date: 9/20/2024 7:34:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_MealPlanID] ON [dbo].[Reservations]
(
	[MealPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_RoomID]    Script Date: 9/20/2024 7:34:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_RoomID] ON [dbo].[Reservations]
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomSeasons_RoomSeasonStartAndEndID]    Script Date: 9/20/2024 7:34:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoomSeasons_RoomSeasonStartAndEndID] ON [dbo].[RoomSeasons]
(
	[RoomSeasonStartAndEndID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MealPlanPerSeasons]  WITH CHECK ADD  CONSTRAINT [FK_MealPlanPerSeasons_MealPlans_MealPlanID] FOREIGN KEY([MealPlanID])
REFERENCES [dbo].[MealPlans] ([MealPlanId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MealPlanPerSeasons] CHECK CONSTRAINT [FK_MealPlanPerSeasons_MealPlans_MealPlanID]
GO
ALTER TABLE [dbo].[MealPlanPerSeasons]  WITH CHECK ADD  CONSTRAINT [FK_MealPlanPerSeasons_MealSeasonStartAndEndSeasons_MealSeasonStartAndEndID] FOREIGN KEY([MealSeasonStartAndEndID])
REFERENCES [dbo].[MealSeasonStartAndEndSeasons] ([MealSeasonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MealPlanPerSeasons] CHECK CONSTRAINT [FK_MealPlanPerSeasons_MealSeasonStartAndEndSeasons_MealSeasonStartAndEndID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_MealPlans_MealPlanID] FOREIGN KEY([MealPlanID])
REFERENCES [dbo].[MealPlans] ([MealPlanId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_MealPlans_MealPlanID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Rooms_RoomID] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Rooms] ([RoomTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Rooms_RoomID]
GO
ALTER TABLE [dbo].[RoomSeasons]  WITH CHECK ADD  CONSTRAINT [FK_RoomSeasons_Rooms_RoomTypeId] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[Rooms] ([RoomTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomSeasons] CHECK CONSTRAINT [FK_RoomSeasons_Rooms_RoomTypeId]
GO
ALTER TABLE [dbo].[RoomSeasons]  WITH CHECK ADD  CONSTRAINT [FK_RoomSeasons_RoomSeasonStartAndEnds_RoomSeasonStartAndEndID] FOREIGN KEY([RoomSeasonStartAndEndID])
REFERENCES [dbo].[RoomSeasonStartAndEnds] ([SeasonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomSeasons] CHECK CONSTRAINT [FK_RoomSeasons_RoomSeasonStartAndEnds_RoomSeasonStartAndEndID]
GO
USE [master]
GO
ALTER DATABASE [Hotel] SET  READ_WRITE 
GO
