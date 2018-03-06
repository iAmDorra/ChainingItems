# Chaining items

Imagine that we have a collection of 20000 items.
An item has those properties :
* id
* previousItemId
* followingItemId

The goal is to get out chains from the collection.

Let's get a scenario :
	Given those items :
	{ id = 1, previousItemId = 2, followingItemId = 3 },
	{ id = 2, previousItemId = 4, followingItemId = 1 },
	{ id = 3, previousItemId = NULL, followingItemId = NULL },
	{ id = 4, previousItemId = NULL, followingItemId = 2 },
	{ id = 5, previousItemId = 8, followingItemId = NULL },
	{ id = 6, previousItemId = NULL, followingItemId = 7 },
	{ id = 7, previousItemId = NULL, followingItemId = NULL },
	{ id = 8, previousItemId = 9, followingItemId = NULL },
	{ id = 9, previousItemId = NULL, followingItemId = 8 },
	{ id = 10, previousItemId = NULL, followingItemId = NULL },
	{ id = 11, previousItemId = NULL, followingItemId = NULL }
	When I run the chaining algo
	Then I should get those chains 
	{4, 2, 1, 3},
	{9, 8, 5},
	{6, 7},
	{10},
	{11}

Enjoy :)