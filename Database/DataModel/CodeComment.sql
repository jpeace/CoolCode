CREATE TABLE [CodeComment]
(
	CodeCommentId	INT IDENTITY(1,1) NOT NULL,
	Timestamp		DATETIME NOT NULL,
	AuthorId		INT NOT NULL,
	Body			NVARCHAR(256) NOT NULL,
	PostId			INT NOT NULL,
	
	PRIMARY KEY(CodeCommentId)
)
GO