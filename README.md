[![Nuget Release](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/Publish.yaml/badge.svg?event=push)](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/Publish.yaml)
<br />
[![CodeQL](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/CodeQL.yaml/badge.svg?branch=master)](https://github.com/farpetrad/SplinterLandsAPI/actions/workflows/CodeQL.yaml)

# SplinterLandsAPI

This is just a demonstration of using the Splinterlands API through .NET 8.0 C#.  
These API's are not documented and are subject to change at any time.

# Client

The client is defined as implementing the ISplinterLandsClient interface which is a collection of interfaces seperated by 'Api'.  Each interface supports both async and non async methods.

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
* GetTokenBalancesForPlayer - returns a list of all tokens held by the player and their balances

## Land

* GetActiveWorksite - returns active worksite information for a plot by deed_uid
* GetActiveWorksiteAsync -
* GetDeedDetails - get the details about a deed by id

## Liquidity Pools
* GetLiquidityPools - returns list of all available liquidity pools
* GetLiquidityPoolsAsync - returns list of all available liquidity pools async
* GetLiquidityRegionResources - gets regions player holds resources in
* GetLiquidityRegionResourcesAsync - gets regions player holds resources in async
* GetPlayerLiquidityHoldings - returns list of liquidity by player and resource
* GetPlayerLiquidityHoldingsAsync - returns list of liquidity by player and resource async
* GetLiquidityPoolById - returns liquidity pool by id
* GetLiquidityPoolByIdAsync - returns liquidity pool by id async
* GetLiquidityRewards - returns a collection of all liquidity rewards earned
* GetLiquidityRewardsAsync - returns a collection of all liquidity rewards earned async

## Token Activity
* GetTokenHistory - returns history of tokens for player
* GetTokenHistoryAsync - returns history of tokens for player async
* GetExchangeHistory - returns exchange history of tokens for player
* GetExchangeHistoryAsync - returns exchange history of tokens for player async

# Known Issues
- If you hit any of these API's in quick sucession you will get rate limited'
