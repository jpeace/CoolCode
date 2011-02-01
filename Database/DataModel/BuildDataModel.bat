@ECHO off
SETLOCAL

SET RootDir=%~dp0.
SET Server=%1
SET DB=%2

ECHO 'Creating Data Model...'

sqlcmd -E -S %Server% -d %DB% -i %RootDir%\User.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\UserProfile.sql
sqlcmd -E -S %Server% -d %DB% -i %RootDir%\ForeignKeys.sql
