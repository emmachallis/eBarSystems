CREATE TABLE table_logging
(
	LogID int PRIMARY KEY IDENTITY,
	UserID varchar(50),
	LogOn datetime,
	LogOff datetime
)