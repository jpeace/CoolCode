CREATE TABLE [User]
(
	UserId 			INT IDENTITY(1,1) NOT NULL,
	Username 		NVARCHAR(64) NOT NULL,
	Password 		NVARCHAR(128) NOT NULL,
	UserProfileId 	INT NOT NULL,
	
	PRIMARY KEY(UserId)
)
GO