ALTER TABLE [User] 
ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile]([UserProfileId]); 
GO

ALTER TABLE [UserProfile] 
ADD FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]); 
GO

ALTER TABLE [CodePost] 
ADD FOREIGN KEY ([AuthorId]) REFERENCES [User]([UserId]);
GO

ALTER TABLE [CodePost] 
ADD FOREIGN KEY ([LanguageId]) REFERENCES [CodeLanguage]([CodeLanguageId]); 
GO

ALTER TABLE [CodePostCategories] 
ADD FOREIGN KEY ([CodePostId]) REFERENCES [CodePost]([CodePostId]);
GO

ALTER TABLE [CodePostCategories] 
ADD FOREIGN KEY ([CodeCategoryId]) REFERENCES [CodeCategory]([CodeCategoryId]); 
GO

ALTER TABLE [CodeComment] 
ADD FOREIGN KEY ([AuthorId]) REFERENCES [User]([UserId]);
GO

ALTER TABLE [CodeComment] 
ADD FOREIGN KEY ([PostId]) REFERENCES [CodePost]([CodePostId]); 
GO