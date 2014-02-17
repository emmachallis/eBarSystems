USE [eBarSystems]
GO
/****** Object:  StoredProcedure [dbo].[UserLogIn]    Script Date: 09/20/2013 14:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UserLogIn]
@UserID varchar(50),
@LogOn datetime

AS

BEGIN
INSERT dbo.UserLogging(UserID, LogOn)
OUTPUT INSERTED.UserLogId
VALUES (@UserID, @LogOn)
END