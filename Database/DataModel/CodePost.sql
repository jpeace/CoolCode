CREATE TABLE [CodePost]
(
	CodePostId 		INT IDENTITY(1,1) NOT NULL,
	TimeStamp 		DATETIME NOT NULL,
	AuthorId 		INT NOT NULL,
	LanguageId		INT NOT NULL,
	Title			NVARCHAR(64) NOT NULL,
	Code			TEXT NOT NULL,
	
	PRIMARY KEY(CodePostId)
)
GO