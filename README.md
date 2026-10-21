# Mod Menu
A mod menu for Cryptid Farm

## Target Values for Mod Menu Button in Main Menu

![Target Rect Transform Values][target-rect-transform-values]

## How to write your own .csproj.user file
```xml
<Project>
  <PropertyGroup>
    <!-- Game path -->
    <GameDir>PATH_TO_GAME_FOLDER</GameDir>
  </PropertyGroup>

  <!-- Auto-copy DLL to game's mod folder -->
  <Target Name="Copy Mod Files" AfterTargets="Build">
    <Copy SourceFiles="$(TargetDir)$(TargetFileName)" DestinationFolder="$(GameDir)\Mods" />
  </Target>
</Project>
```


<!-- MEDIA LINKING -->
[target-rect-transform-values]: "https://github.com/gus-srod1121/modmenu-cryptidfarm/blob/dev/README/Media/1080pRectTransformButtonValues.png?raw=true"
