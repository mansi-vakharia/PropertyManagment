USE [master]
GO
/****** Object:  Database [PropertyManagment]    Script Date: 4/24/2021 9:15:54 PM ******/
CREATE DATABASE [PropertyManagment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropertyManagment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVEREXPRESS\MSSQL\DATA\PropertyManagment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropertyManagment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVEREXPRESS\MSSQL\DATA\PropertyManagment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PropertyManagment] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropertyManagment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropertyManagment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropertyManagment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropertyManagment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropertyManagment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropertyManagment] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropertyManagment] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PropertyManagment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropertyManagment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropertyManagment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropertyManagment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropertyManagment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropertyManagment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropertyManagment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropertyManagment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropertyManagment] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PropertyManagment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropertyManagment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropertyManagment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropertyManagment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropertyManagment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropertyManagment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PropertyManagment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropertyManagment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PropertyManagment] SET  MULTI_USER 
GO
ALTER DATABASE [PropertyManagment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropertyManagment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropertyManagment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropertyManagment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropertyManagment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PropertyManagment] SET QUERY_STORE = OFF
GO
USE [PropertyManagment]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 4/24/2021 9:15:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyNumber] [nvarchar](50) NULL,
	[Title] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
	[Badroom] [nvarchar](50) NULL,
	[Bathroom] [nvarchar](50) NULL,
	[Kitchen] [nvarchar](50) NULL,
	[Parking] [nvarchar](50) NULL,
	[Size] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Livingroom] [nvarchar](50) NULL,
	[Price] [float] NULL,
	[UserId] [int] NULL,
	[ClientId] [int] NULL,
	[ImagePath] [nvarchar](100) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK__Property__3214EC077AE4E06F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/24/2021 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[DOB] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserType] [nvarchar](50) NULL,
	[RefId] [int] NULL,
	[ImagePath] [nvarchar](100) NULL,
	[About] [nvarchar](100) NULL,
	[MobileNo] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([Id], [PropertyNumber], [Title], [Address], [Badroom], [Bathroom], [Kitchen], [Parking], [Size], [Type], [Livingroom], [Price], [UserId], [ClientId], [ImagePath], [Status]) VALUES (1, N'138-B', N'Khetan House', N'Olive Road Two', N'2', N'2', N'2', N'1', N'2', N'340m', N'2', 500000, 1, 4, N'd3c1f1bb-af97-4b87-b4f2-8ab33c3346c3.jpg', N'On Sale')
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FullName], [DOB], [Email], [Password], [UserType], [RefId], [ImagePath], [About], [MobileNo]) VALUES (1, N'Admin', N'10-06-1991', N'admin@gmail.com', N'123', N'admin', NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [FullName], [DOB], [Email], [Password], [UserType], [RefId], [ImagePath], [About], [MobileNo]) VALUES (3, N'Mark D a', NULL, N'mark@gmail.com', N'1234', N'agent', 4, N'4c58d004-c05b-4654-9f69-0ec6b0592b92.jpg', N'Sample testing data for mark ', N'8890780988')
INSERT [dbo].[User] ([Id], [FullName], [DOB], [Email], [Password], [UserType], [RefId], [ImagePath], [About], [MobileNo]) VALUES (4, N'Chetan', NULL, N'chetan@gmail.com', N'123', N'client', 3, N'87b52238-aaac-4ff5-b385-08fd9f6a63d5.jpg', N'dfjksdfjksd fdjkfjsdlkf kdfsdfldkl  dkfkdl', N'8388383883')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK__Property__UserId__4BAC3F29] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK__Property__UserId__4BAC3F29]
GO
USE [master]
GO
ALTER DATABASE [PropertyManagment] SET  READ_WRITE 
GO
