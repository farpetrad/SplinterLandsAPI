[![Release](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/Publish.yaml/badge.svg?event=push)](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/Publish.yaml)

# SplinterLandsAPI

This is just a demonstration of using the Splinterlands API through .NET 6.0 C#.  
These API's are not documented and are subject to change at any time

# Supported APIs

## Cards

* GetCards - returns a list of all Splinterlands cards
* GetCardDetails - look up a card by its id, returns details on ownership

## Battles

* GetBattlesForPlayer - returns the last 50 battles a player has participated in

## Quests

* GetPlayersCurrentQuest - returns details about the current quest for a player


# Known Issues
- If you hit any of these API's in quick sucession you will get rate limited'
