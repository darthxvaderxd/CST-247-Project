/****** Object:  Table [dbo].[users]    Script Date: 1/13/2021 3:30:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[users]'))
BEGIN
CREATE TABLE [dbo].[users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[age] [int] NOT NULL,
	[sex] [nvarchar](50) NOT NULL,
	[state] [nvarchar](50) NOT NULL,
	[email_address] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
ELSE
 PRINT 'Table "users" already exists';
GO
IF NOT EXISTS
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[highScores]'))
BEGIN
CREATE TABLE [dbo].[highScores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[user] [int] NOT NULL,
	[timespan] [bigint] NOT NULL,
	[difficulty] [int] NOT NULL,
	[boardsize] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[highScores]  WITH CHECK ADD FOREIGN KEY([user])
REFERENCES [dbo].[users] ([Id])
END
ELSE 
 PRINT 'Table "highScores" already exists';
GO
IF NOT EXISTS
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[savedGames]'))
BEGIN
CREATE TABLE [dbo].[savedGames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[turns] [int] NOT NULL,
	[size] [int] NOT NULL,
	[difficulty] [int] NOT NULL,
	[timer] [int] NOT NULL,
	[jsonData] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
ALTER TABLE [dbo].[savedGames]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[users] ([Id])
END
ELSE
 PRINT 'Table "savedGames" already exists';
GO