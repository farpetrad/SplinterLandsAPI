[![Nuget Release](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/Publish.yaml/badge.svg?event=push)](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/Publish.yaml)
<br />
[![CodeQL](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/CodeQL.yaml/badge.svg?branch=master)](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/CodeQL.yaml)

# SplinterLandsAPI

This is just a demonstration of using the Splinterlands API through .NET 6.0 C#.  
These API's are not documented and are subject to change at any time

# Supported APIs

## Cards

* GetCards - returns a list of all Splinterlands cards
* GetCardDetails - look up a card by its id, returns details on ownership

## Battles

* GetBattlesForPlayer - returns the last 50 battles a player has participated in

## Player

* GetPlayersCurrentQuest - returns details about the current quest for a player
* GetReferralsForPlayer - returns an object with a list of referrals and a list of purchases made by the referrals
* GetPackPurchaesForPlayerByEdition - returns an object describing the purchases made for packs by edition
* GetActiveRentalsForPlayer - returns a list of active rentals for a player
* GetActivelyRentaledCardsForPlayer - returns a list of actively rented cards for a player

# Known Issues
- If you hit any of these API's in quick sucession you will get rate limited'
