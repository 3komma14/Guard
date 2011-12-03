
echo ------------------------------ .Net 4.0 ------------------------------
msbuild CodeGuard\Seterlund.CodeGuard.csproj /t:Clean;ReBuild /p:Configuration=Release;TargetFrameworkVersion=v4.0
copy CodeGuard\bin\Release\Seterlund.CodeGuard.dll NuGet\lib\net40\

echo ------------------------------ .Net 3.5 ------------------------------
msbuild CodeGuard\Seterlund.CodeGuard.csproj /t:Clean;ReBuild /p:Configuration=Release;TargetFrameworkVersion=v3.5
copy CodeGuard\bin\Release\Seterlund.CodeGuard.dll NuGet\lib\net35\


echo ------------------------------ Build package and upload it ------------------------------

pushd NuGet
..\packages\NuGet.CommandLine.1.5.21005.9019\tools\NuGet.exe pack Seterlund.CodeGuard.nuspec
..\packages\NuGet.CommandLine.1.5.21005.9019\tools\NuGet.exe push Seterlund.CodeGuard.2.1.nupkg
popd