USE [StudyRoomKiosk]
GO

/****** Object:  Table [dbo].[TBL_MEMBER]    Script Date: 2020-06-10 ���� 5:19:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TBL_MEMBER](
	--ȸ�� ��ȣ
	[memberNo] [int] NOT NULL,
	--ȸ�� �̸�
	[name] [varchar](20) NULL,
	--ȸ������
	[dateBirth] [varchar](6) NULL,
	--ȸ�� ����
	[gender] [varchar](6) NULL,
	--ȸ�� �޴��� ��Ż�
	[newsAgency] [varchar](10) NULL,
	--ȸ�� �޴��� ��ȣ
	[phoneNum] [varchar](20) NOT NULL,
	--���� ���� �ð�
	[expiredTime] [datetime] NULL,
	--���� �¼� ��ȣ
	[seatNo] [int] NULL,
	--������ ���� ��¥
	[checkInDate] [datetime] NULL,
	--��ȸ��/��ȸ�� ����
	[memberBool] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_MEMBER_1] PRIMARY KEY CLUSTERED 
(
	[phoneNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TBL_MEMBER]  WITH CHECK ADD  CONSTRAINT [FK_TBL_MEMBER_TBL_SEAT] FOREIGN KEY([seatNo])
REFERENCES [dbo].[TBL_SEAT] ([seatNo])
GO

ALTER TABLE [dbo].[TBL_MEMBER] CHECK CONSTRAINT [FK_TBL_MEMBER_TBL_SEAT]
GO


