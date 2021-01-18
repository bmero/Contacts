USE [Contacts]
GO

/****** Object:  StoredProcedure [dbo].[addContacts]    Script Date: 17/1/2021 17:41:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Bmero>
-- Create date: <Create Date,,>
-- Description:	<traer todos los contactos>
-- =============================================
CREATE PROCEDURE [dbo].[addContacts] (
			@FirstName AS varchar(50),
			@LastName AS varchar(50),
			@Company AS varchar(50),
			@Email AS varchar(50),
			@PhoneNumber AS int
	)
AS
BEGIN
		INSERT INTO [dbo].[Contacts]
				   ([FirstName]
				   ,[LastName]
				   ,[Company]
				   ,[Email]
				   ,[PhoneNumber])
			 VALUES
				   (@FirstName
				   ,@LastName
				   ,@Company
				   ,@Email
				   ,@PhoneNumber)
END
GO


