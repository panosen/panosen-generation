dotnet restore

msbuild /p:configuration=debug

copy-pdb-to-nuget debug

pause