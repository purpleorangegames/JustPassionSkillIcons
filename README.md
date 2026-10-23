# JustPassionSkillIcons

Inspired by Oracle's Skill Icon Retextures (https://steamcommunity.com/sharedfiles/filedetails/?id=3214465250).

Replaces the vanilla passion icons, and if you use Vanilla Skills Expanded (https://steamcommunity.com/sharedfiles/filedetails/?id=2854967442) it also replaces its passion icons (apathy, natural and critical).

New icons, redrawn with cleaner edges.

Steam version: https://steamcommunity.com/sharedfiles/filedetails/?id=3215203476

Requires Harmony.

## Versions

1.7 is built from the code in the Source folder. The game loads the passion icons before the mod textures, so the dll sets them again the first time the skills or work tab is drawn.

1.4 to 1.6 use the old dll I used before (Legacy folder).

The Vanilla Skills Expanded part is in the VSE folder and only loads when that mod is active.

## Building

You need the .NET 10 SDK, then inside this folder run:

    dotnet build Source -c Release

The dll goes to 1.7/Assemblies. To test it, copy or link this folder to RimWorld/Mods.

## License

CC0, you can do whatever you want with it, no need to give credits.

AI was used to help code/fix issues
