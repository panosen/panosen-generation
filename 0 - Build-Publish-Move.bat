@echo off

dotnet restore

msbuild /p:configuration=release

nuget push Panosen.Generation\bin\Release\Panosen.Generation.*.nupkg -source https://package.savory.cn/v3/index.json

move /Y Panosen.Generation\bin\Release\Panosen.Generation.*.nupkg D:\LocalSavoryNuget\

pause