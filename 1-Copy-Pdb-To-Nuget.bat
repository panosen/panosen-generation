dotnet restore

msbuild Savory.Canos.Engine.CSharp.sln /p:configuration=debug

copy-pdb-to-nuget debug

pause