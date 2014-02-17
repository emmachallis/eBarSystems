USE [eBarSystems]
GO
/****** Object:  StoredProcedure [dbo].[Save]    Script Date: 09/20/2013 14:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Save]
	@PumpNumber int = 0,
	@UserNumber varchar(50),
	@Date varchar(50),
	@time time(7)
AS
	BEGIN 
		INSERT table_log(PumpID, UserID, Date, time)
		VALUES (@PumpNumber, @UserNumber, @Date, @time)
		END

RETURN 0