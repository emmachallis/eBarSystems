USE [eBarSystems]
GO
/****** Object:  StoredProcedure [dbo].[transaction]    Script Date: 09/20/2013 14:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE[dbo].[transaction](@username varchar(50), @Date varchar(50), @TimeStart time(7), @TimeEnd time(7)) AS BEGIN SELECT        *
                                                                                                                                                                                                                                                                                                   FROM            Log
                                                                                                                                                                                                                                                                                                   WHERE        UserNumber = @username AND
                                                                                                                                                                                                                                                                                                                             Date = @Date AND 
                                                                                                                                                                                                                                                                                                                            Time > @TimeStart AND 
                                                                                                                                                                                                                                                                                                                            Time < @TimeEnd END