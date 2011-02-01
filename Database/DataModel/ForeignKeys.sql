ALTER TABLE [User] 
ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile]([UserProfileId]); 
GO

ALTER TABLE [UserProfile] 
ADD FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]); 
GO