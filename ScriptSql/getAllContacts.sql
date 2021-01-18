USE [Contacts]
GO

/****** Object:  StoredProcedure [dbo].[getAllContacts]    Script Date: 17/1/2021 17:45:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Bmero>
-- Create date: <Create Date,,>
-- Description:	<traer todos los contactos>
-- =============================================
CREATE PROCEDURE [dbo].[getAllContacts] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 	[FirstName]
      ,[LastName]
      ,[Company]
      ,[Email]
      ,[PhoneNumber]
	FROM [Contacts].[dbo].[Contacts]
END
GO


