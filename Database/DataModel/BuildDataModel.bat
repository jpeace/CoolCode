@ECHO off
SETLOCAL

SET RootDir=%~dp0.
SET Server=%1
SET DB=%2

ECHO 'Creating Data Model...'

sqlcmd -E -S %Server% -d %DB% -i %RootDir%\User.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\UserProfile.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\CodePost.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\CodeLanguage.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\CodeCategory.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\CodeComment.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\CodePostCategories.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\ForeignKeys.sql
