CREATE TABLE [CodePostCategories]
(
	CodePostCategoriesId	INT IDENTITY(1,1) NOT NULL,
	CodePostId				INT NOT NULL,
	CodeCategoryId			INT NOT NULL,
	
	PRIMARY KEY(CodePostCategoriesId)
)
GO