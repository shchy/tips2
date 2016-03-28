@echo off

set MIGRATION_TAG=%1
set MIGRATIONS_PATH="./Migrations"
set FINDED=0

FOR /R %MIGRATIONS_PATH% %%f in ( *%MIGRATION_TAG%.cs ) do (
    set FINDED=1
)
    
if %FINDED% == 1 (
    echo "Already Exists Migrations"
) else (
    mkdir -p data
    dnx ef migrations add %MIGRATION_TAG%
    dnx ef database update
)

dnx web

