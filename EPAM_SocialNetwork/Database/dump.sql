USE [master]
GO
/****** Object:  Database [SocialNetworkDb]    Script Date: 20.07.2021 12:27:10 ******/
CREATE DATABASE [SocialNetworkDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SocialNetworkDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SocialNetworkDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SocialNetworkDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SocialNetworkDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SocialNetworkDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SocialNetworkDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SocialNetworkDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SocialNetworkDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SocialNetworkDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SocialNetworkDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SocialNetworkDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET RECOVERY FULL 
GO
ALTER DATABASE [SocialNetworkDb] SET  MULTI_USER 
GO
ALTER DATABASE [SocialNetworkDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SocialNetworkDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SocialNetworkDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SocialNetworkDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SocialNetworkDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SocialNetworkDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SocialNetworkDb', N'ON'
GO
ALTER DATABASE [SocialNetworkDb] SET QUERY_STORE = OFF
GO
USE [SocialNetworkDb]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Sender] [int] NOT NULL,
	[Id_Addresse] [int] NOT NULL,
	[Id_Status] [int] NOT NULL,
	[MessageText] [text] NOT NULL,
	[CreationDate] [date] NOT NULL,
	[EditDate] [date] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Image] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Friend]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Friend](
	[Id_User] [int] NOT NULL,
	[Id_Friend] [int] NOT NULL,
 CONSTRAINT [PK_User_Friend] PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC,
	[Id_Friend] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Roles]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Roles](
	[Id_User] [int] NOT NULL,
	[Id_Role] [int] NOT NULL,
 CONSTRAINT [PK_User_Roles] PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC,
	[Id_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([Id_Sender])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User1] FOREIGN KEY([Id_Addresse])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User1]
GO
ALTER TABLE [dbo].[User_Friend]  WITH CHECK ADD  CONSTRAINT [FK_User_Friend_User] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Friend] CHECK CONSTRAINT [FK_User_Friend_User]
GO
ALTER TABLE [dbo].[User_Friend]  WITH CHECK ADD  CONSTRAINT [FK_User_Friend_User1] FOREIGN KEY([Id_Friend])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Friend] CHECK CONSTRAINT [FK_User_Friend_User1]
GO
ALTER TABLE [dbo].[User_Roles]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles_Roles] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Roles] CHECK CONSTRAINT [FK_User_Roles_Roles]
GO
ALTER TABLE [dbo].[User_Roles]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles_User_Roles] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Roles] CHECK CONSTRAINT [FK_User_Roles_User_Roles]
GO
/****** Object:  StoredProcedure [dbo].[Give_Role]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Give_Role]
	@id_user int,
	@id_role int
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.User_Roles (Id_User, Id_Role)
	VALUES (@id_user, @id_role)
END
GO
/****** Object:  StoredProcedure [dbo].[Message_Create]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Message_Create]
	@id_sender int,
	@id_addresse int,
	@messageText text,
	@creationDate date
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO Message (Id_Sender, Id_Addresse, Id_Status, MessageText, CreationDate)
	VALUES (@id_sender, @id_addresse, 1, @messageText, @creationDate)
END
GO
/****** Object:  StoredProcedure [dbo].[Message_Edit]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Message_Edit]
	@id int,
	@messageText text,
	@editDate date
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE Message SET
	MessageText = @messageText,
	EditDate = @editDate
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Message_Remove]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Message_Remove]
	@id int
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM Message
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Role_GetByName]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Role_GetByName]
	@role nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 * FROM Roles
	WHERE Role = @role
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_Create]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles_Create]
	@role nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.Roles (Role)
	VALUES (@role)
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_Edit]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles_Edit]
	@id int,
	@role nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE Roles SET
	Role = @role
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_GetAll]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Roles
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_GetUsers]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles_GetUsers]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Login, Password, Gender, FirstName, LastName, DateOfBirth, Image FROM User_Roles INNER JOIN [User]
	ON Id_Role = @id AND Id_User = [User].Id
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_Remove]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles_Remove]
	@id int
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM Roles
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_AddFriend]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_AddFriend]
	@id_user int,
	@id_friend int
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO User_Friend (Id_User, Id_Friend)
	VALUES (@id_user, @id_friend)

	INSERT INTO User_Friend (Id_User, Id_Friend)
	VALUES (@id_friend, @id_user)
END
GO
/****** Object:  StoredProcedure [dbo].[User_Create]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Create]
	@login nvarchar(50),
	@password nvarchar(50),
	@gender nvarchar(50),
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@dateOfBirth date,
	@image nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO dbo.[User] (Login, Password, Gender, FirstName, LastName, DateOfBirth, Image)
	VALUES (@login, @password, @gender, @firstName, @lastName, @dateOfBirth, @image)
END
GO
/****** Object:  StoredProcedure [dbo].[User_Edit]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Edit]
	@id int,
	@login nvarchar(50),
	@password nvarchar(50),
	@gender nvarchar(50),
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@dateOfBirth date,
	@image nvarchar(50)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [User] SET
	Login = @login,
	Password = @password,	
	Gender = @gender,
	FirstName = @firstName,
	LastName = @lastName,
	DateOfBirth = @dateOfBirth,
	Image = @image
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetAll]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [User]
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetAllMessages]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetAllMessages]
	@id_user int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Message
	WHERE Id_Sender = @id_user OR Id_Addresse = @id_user
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetAllMessages_WithProperties]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetAllMessages_WithProperties]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Message.Id, Id_Sender, Id_Addresse, MessageText, CreationDate, EditDate, [User].Login AS SenderLogin, [u2].Login AS AddresseLogin
	FROM (Message INNER JOIN [User] ON [User].Id = Id_Sender)
	INNER JOIN [User] u2 ON u2.Id = Id_Addresse
	WHERE Id_Sender = @id OR Id_Addresse = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetById]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetById]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
	Id, Login, Password, Gender, FirstName, LastName, DateOfBirth, Image FROM [User]
	WHERE Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetByLogin]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetByLogin]
	@login nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 * FROM [User]
	WHERE Login = @login
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetFriends]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetFriends]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Login, Password, Gender, FirstName, LastName, DateOfBirth, Image FROM User_Friend INNER JOIN [User] ON Id_Friend = Id
	WHERE Id_User = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetRoles]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetRoles]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Role FROM User_Roles INNER JOIN Roles
	ON Id_User = @id AND Id_Roles = Roles.Id
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetRolesByUserLogin]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetRolesByUserLogin]
	@login nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Roles.Id, Roles.Role FROM
	(Roles INNER JOIN User_Roles ON Roles.Id = Id_Role) INNER JOIN [User]
	ON [User].Id = Id_User
	WHERE [User].Login = @login
END
GO
/****** Object:  StoredProcedure [dbo].[User_Remove]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Remove]
	@id int
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM [User]
	WHERE Id = @id

	DELETE FROM User_Friend
	WHERE Id_User = @id OR Id_Friend = @id

	DELETE FROM Message
	WHERE Id_Sender = @id OR Id_Addresse = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_RemoveFriend]    Script Date: 20.07.2021 12:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_RemoveFriend]
	@id_user int,
	@id_friend int
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM User_Friend
	WHERE (Id_User = @id_user AND Id_Friend = @id_friend) OR
	(Id_User = @id_friend AND Id_Friend = @id_user)
END
GO
USE [master]
GO
ALTER DATABASE [SocialNetworkDb] SET  READ_WRITE 
GO
