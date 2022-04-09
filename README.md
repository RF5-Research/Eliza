# Eliza

 A cross-platform (RF5) Rune Factory 5 Save Editor

## Building

1. Install the [.NET 5.0+ SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
2. Download the repository by clicking the ``Clone`` dropdownbox and clicking either ``Download Zip`` or ``Open with Github Desktop``.
3. Extract the raw contents of the repository.
4. Open a console (command prompt, git bash, etc.) in the repository folder, and run ``dotnet publish [TargetPlatform] -c Release`` with ``[TargetPlatform]`` being either ``Eliza.Windows`` (Windows), ``Eliza.Linux`` (Linux), or ``Eliza.Mac`` (MacOS) to build the binary.

## Maintainers

## Credits and Thanks

- [SPICA](https://github.com/gdkchan/SPICA) for base for serialization
- [SinsofSloth](https://github.com/SinsofSloth) for the original creation of the save editor.
- Blazagon for name data
- bluedart and other testers
- Item list from: <https://docs.google.com/spreadsheets/d/13-ql1gKkne1F4c9rzgAw3woR8PXR6_vb>

## Soil stats

Soil stats are stored in four BitVector32 structures. Each structure contains 4 soil values a 8-bytes.
Variables labeled with 'Boost' are the ones the player can influence with items like greenifier.
Variables labeled with 'Lvl' are the experience points of the soil that increase with harvesting. Once they overflow they increase the base values.
Variables labeled with "base" are the base values of the soil.
Other variables kind of influence the other stats in a weird way.<br>

### Structure of the soil values

|Name|First Byte|Second Byte|Third Byte|Fourth Byte|
|---|---|---|---|---|
|SI0|Quality Boost|Some kind of multiplier?|Growth Boost|Some kind of multiplier?|
|SI1|Size Boost|Health Boost|Defense Boost|Some kind of multiplier?|
|SI2|Speed Lvl Exp|Base quality|Base Size|Base Number of Crops|
|SI3|Base Speed|Size Lvl Exp|Quality Lvl Exp|Number of Crops Lvl Exp|
