@ECHO off
SETLOCAL
SET RootDir=%~dp0.\Database
SET Server=%1
SET DB=%2
SET InitFile=%3

IF NOT DEFINED %Server SET Server=localhost
IF NOT DEFINED %DB SET DB=CoolCode
IF NOT DEFINED %InitFile SET InitFile=Init.sql

ECHO Generating database %DB% on server %Server%

ECHO Creating database...
sqlcmd -E -S %Server% -i "%RootDir%\%InitFile%"

%RootDir%\DataModel\BuildDataModel %Server% %DB%

ECHO Finished.