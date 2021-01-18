USE [Contacts]
GO

/****** Object:  StoredProcedure [dbo].[deleteContacts]    Script Date: 17/1/2021 17:44:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Bmero>
-- Create date: <Create Date,,>
-- Description:	<traer todos los contactos>
-- =============================================
CREATE PROCEDURE [dbo].[deleteContacts] (
			@FirstName AS varchar(50),
			@LastName AS varchar(50)
	)
AS
BEGIN
		DELETE FROM [dbo].[Contacts]
				 WHERE 
						FirstName = @FirstName AND
						LastName = @LastName
END
GO


