USE [Contacts]
GO

/****** Object:  StoredProcedure [dbo].[editContacts]    Script Date: 17/1/2021 17:44:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Bmero>
-- Create date: <Create Date,,>
-- Description:	<traer todos los contactos>
-- =============================================
CREATE PROCEDURE [dbo].[editContacts] (
			@FirstName AS varchar(50),
			@LastName AS varchar(50),
			@Company AS varchar(50),
			@Email AS varchar(50),
			@PhoneNumber AS int
	)
AS
BEGIN
	UPDATE [dbo].[Contacts]
	   SET [FirstName] = @FirstName
		  ,[LastName] = @LastName
		  ,[Company] = @Company
		  ,[Email] = @Email
		  ,[PhoneNumber] = @PhoneNumber
	 WHERE 
			FirstName = @FirstName AND
			LastName = @LastName
END
GO


