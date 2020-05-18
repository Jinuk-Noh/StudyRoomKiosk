USE [StudyRoomKiosk]
GO

/****** Object:  Table [dbo].[TBL_TIME]    Script Date: 2020-05-14 ���� 7:25:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBL_TIME](
	[timeUse] [datetime] NOT NULL,
	[amount] [int] NOT NULL,
 CONSTRAINT [PK_TBL_TIME] PRIMARY KEY CLUSTERED 
(
	[timeUse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

