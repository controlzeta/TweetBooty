USE [TweetBotDB]
GO
/****** Object:  Table [dbo].[BannedWords]    Script Date: 01/04/2017 10:44:48 p. m. ******/
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
/****** Object:  Table [dbo].[Configuration]    Script Date: 01/04/2017 10:44:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ConsumerKey] [nvarchar](255) NOT NULL,
	[ConsumerSecret] [nvarchar](255) NOT NULL,
	[AccessToken] [nvarchar](255) NOT NULL,
	[AccessTokenSecret] [nvarchar](255) NOT NULL,
	[Minutes] [int] NOT NULL,
	[RTCount] [int] NOT NULL,
	[TweetLimit] [int] NOT NULL,
	[FavLimit] [int] NOT NULL,
	[FollowLimit] [int] NOT NULL,
	[ImageCounter] [int] NOT NULL,
	[FavCounter] [int] NOT NULL,
	[FollowCounter] [int] NOT NULL,
	[TweetCounter] [int] NOT NULL,
	[AccountName] [nvarchar](50) NULL,
	[LastUse] [datetime] NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hashtags]    Script Date: 01/04/2017 10:44:48 p. m. ******/
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
/****** Object:  Table [dbo].[Links]    Script Date: 01/04/2017 10:44:48 p. m. ******/
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
/****** Object:  Table [dbo].[ProgrammedTweets]    Script Date: 01/04/2017 10:44:48 p. m. ******/
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
	[Link] [varchar](max) NULL,
	[Account] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProgrammedTweets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tweeted]    Script Date: 01/04/2017 10:44:48 p. m. ******/
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
/****** Object:  Table [dbo].[Tweets]    Script Date: 01/04/2017 10:44:48 p. m. ******/
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
