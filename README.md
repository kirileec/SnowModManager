# SnowModManager

[ÖÐÎÄREADME](README_CN.md)

## Features

1. save game path for next time 
2. drag pak file into the `DataGridView` to install mods (multiple files are supported)
3. manage mods with subdirectory (category)
4. auto fetch game directory from registry when running with administrator, but `drag and drop` will be invalid
5. enable or disable a mod easily
6. watch mod directory changes, auto reload

## TODO

- [ ] comment your mods
- [ ] localization (maybe)


## Cautions

- based on .NET8 runtime
- just run as administrator once, you can auto fetch the game directory. And next time, double click the exe to start.