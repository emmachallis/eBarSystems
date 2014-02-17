USE [eBarSystems]
GO
/****** Object:  StoredProcedure [dbo].[UserLogOut]    Script Date: 09/20/2013 14:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UserLogOut]
@ID int,
@LogOff datetime

AS

BEGIN
UPDATE dbo.UserLogging
SET 
LogOff = @LogOff 
WHERE UserLogID = @ID
END