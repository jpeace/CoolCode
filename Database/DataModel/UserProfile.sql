CREATE TABLE [UserProfile]
(
	UserProfileId 	INT IDENTITY(1,1) NOT NULL,
	FirstName 		NVARCHAR(64),
	LastName 		NVARCHAR(64),
	Email			NVARCHAR(128),
	Company			NVARCHAR(64),
	UserId			INT NOT NULL,
	
	PRIMARY KEY(UserProfileId)
)
GO