USE [Contacts]
GO

/****** Object:  Table [dbo].[Contacts]    Script Date: 17/1/2021 17:39:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts](
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNumber] [int] NULL
) ON [PRIMARY]
GO


