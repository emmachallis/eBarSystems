CREATE TABLE table_users
(
	UserID varchar(50) PRIMARY KEY,
	Password varchar(50) NOT NULL,
	Name text NOT NULL,
	AccessType text NOT NULL,
	AccountCreated datetime
);

