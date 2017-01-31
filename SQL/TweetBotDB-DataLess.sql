USE [master]
GO
/****** Object:  Database [TweetBotDB]    Script Date: 30/01/2017 10:57:35 p. m. ******/
CREATE DATABASE [TweetBotDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TweetBotDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TweetBotDB.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TweetBotDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TweetBotDB_log.ldf' , SIZE = 1344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TweetBotDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TweetBotDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TweetBotDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TweetBotDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TweetBotDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TweetBotDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TweetBotDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TweetBotDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TweetBotDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TweetBotDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TweetBotDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TweetBotDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TweetBotDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TweetBotDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TweetBotDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TweetBotDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TweetBotDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TweetBotDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TweetBotDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TweetBotDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TweetBotDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TweetBotDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TweetBotDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TweetBotDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TweetBotDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TweetBotDB] SET  MULTI_USER 
GO
ALTER DATABASE [TweetBotDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TweetBotDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TweetBotDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TweetBotDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TweetBotDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TweetBotDB', N'ON'
GO
USE [TweetBotDB]
GO
/****** Object:  Table [dbo].[BannedWords]    Script Date: 30/01/2017 10:57:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BannedWords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bannedWord] [nvarchar](50) NOT NULL,
	[timestamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 30/01/2017 10:57:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[ConsumerKey] [nvarchar](255) NOT NULL,
	[ConsumerSecret] [nvarchar](255) NOT NULL,
	[AccessToken] [nvarchar](255) NOT NULL,
	[AccessTokenSecret] [nvarchar](255) NOT NULL,
	[Minutes] [int] NOT NULL,
	[RTCount] [int] NOT NULL,
	[TweetLimit] [int] NOT NULL,
	[FavLimit] [int] NOT NULL,
	[FollowLimit] [int] NOT NULL,
	[ImageCounter] [int] NULL,
	[FavCounter] [int] NULL,
	[FollowCounter] [int] NULL,
	[TweetCounter] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hashtags]    Script Date: 30/01/2017 10:57:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hashtags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hashtag] [nchar](50) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[repeated] [int] NOT NULL CONSTRAINT [DF_Hashtags_repeated]  DEFAULT ((0)),
 CONSTRAINT [PK_Hashtags] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Links]    Script Date: 30/01/2017 10:57:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Links](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](140) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[sortOrder] [int] NOT NULL DEFAULT ((0)),
	[link] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProgrammedTweets]    Script Date: 30/01/2017 10:57:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProgrammedTweets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tweet] [varchar](max) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Tweeted] [bit] NOT NULL,
	[Link] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tweeted]    Script Date: 30/01/2017 10:57:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tweeted](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](250) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[TweetId] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tweets]    Script Date: 30/01/2017 10:57:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tweets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tweet] [nvarchar](140) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[tweeted] [int] NOT NULL,
 CONSTRAINT [PK_Tweets] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Tweets] ADD  CONSTRAINT [DF_Tweets_tweeted]  DEFAULT ((0)) FOR [tweeted]
GO
USE [master]
GO
ALTER DATABASE [TweetBotDB] SET  READ_WRITE 
GO
