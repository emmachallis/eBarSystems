CREATE TABLE Log
(
	LogID int PRIMARY KEY IDENTITY,
	PumpID int,
	UserID varchar(50),
	Date date,
	Time time
)