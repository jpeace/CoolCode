USE master
GO

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'CoolCode'))
BEGIN
  PRINT 'CoolCode already exists... Dropping database.'
  DROP DATABASE CoolCode
END
GO

CREATE DATABASE CoolCode
GO