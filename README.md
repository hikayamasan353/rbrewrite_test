# rbrewrite_test
This is a rewrite of the now highly obsolete GUI route editor for BVE/openbve named RouteBuilder.
Will not be that graphic but more similar to now extinct ConstructorBVE.
However it will still be based on GUI and modular route construction.


About modular route construction
A BVE route by its nature is a CSV code that can be separated in the With Route, With Structure/Texture/Cycle and With Track namespaces.
Route namespace is a route general properties, or "metadata" (what I was initially thinking about). In original RouteBuilder, it was
contained in Project Properties. It will be implemented similarly.

Structure/Texture/Cycle namespaces are a part of the Object Library.
In RouteBuilder and ConstructorBVE, the library was generating itself automatically according to the objects specified.
However, the fault of RouteBuilder was that the library was made all with FreeObjs and not all the existing codes.
While making the route manually, you had to write this from scratch, and almost every manually made route can have these object
libraries different. Some common code might also be done. Object Library makes this code as common to all routes based on it.

Track namespace is what is being highly flawed in RouteBuilder due to object issues.
But it will be highly different and based on modules.
Every module could be: crossing, station, turn, bridge, switchings etc. It has its own code.
Modules sequenced together will form a complete route.


