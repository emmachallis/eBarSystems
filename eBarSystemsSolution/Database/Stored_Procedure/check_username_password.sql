USE [eBarSystems]
GO
/****** Object:  StoredProcedure [dbo].[CheckUser]    Script Date: 09/20/2013 14:28:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CheckUser]
(
@username varchar(50),
@password varchar(50)
)
AS
BEGIN
SELECT * 
FROM UserTable
WHERE UserID = @username
AND Password = @password
END
RETURN 0