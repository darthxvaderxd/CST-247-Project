/****** Object:  Table [dbo].[highScores]    Script Date: 2/4/2021 2:50:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
