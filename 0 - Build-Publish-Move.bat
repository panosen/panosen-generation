@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.Generation\bin\Release\Panosen.Generation.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.Generation.Extension\bin\Release\Panosen.Generation.Extension.*.nupkg D:\LocalSavoryNuget\

pause