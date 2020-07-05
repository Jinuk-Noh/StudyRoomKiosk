USE [StudyRoomKiosk]
GO

/****** Object:  Table [dbo].[TBL_TIME]    Script Date: 2020-05-14 ���� 7:25:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBL_TIME](
	[timeUse] [varchar](10) NOT NULL,
	[amount] [int] NOT NULL,
 CONSTRAINT [PK_TBL_TIME] PRIMARY KEY CLUSTERED 
(
	[timeUse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--�ð� �߰�
  INSERT INTO [StudyRoomKiosk].[dbo].[TBL_TIME] VALUES
		('2�ð�', 3000),
		('3�ð�', 4000),
		('5�ð�', 6000),
		('7�ð�', 8000),
		('9�ð�', 10000),
		('����', 12000),
		('1��', 27000),
		('3��', 43000),
		('5��', 56000),
		('1��', 84000),
		('2��', 130000),
		('8��', 240000)

  --��� ������ ���� �߰�
  ALTER TABLE [StudyRoomKiosk].[dbo].[TBL_TIME] ADD status bit ;
  UPDATE [StudyRoomKiosk].[dbo].[TBL_TIME] SET [statuse] = 'true' where timeUse like '%��' or timeUse like '%��'  ;
  UPDATE [StudyRoomKiosk].[dbo].[TBL_TIME] SET [statuse] = 'false' where timeUse like '%�ð�';