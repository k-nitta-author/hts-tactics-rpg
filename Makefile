build-format: tactics-rpg-demo.csproj
	dotnet format tactics-rpg-demo.csproj
	dotnet build

build-export:
	godot --headless "" --export-release "Windows Desktop" "./build/HTS.exe"

	
