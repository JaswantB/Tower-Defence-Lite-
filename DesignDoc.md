## TOWER DEFENCE LITE  

 

## Ideation 

This project is a grid-based tower defense game where the player strategically places towers on predefined spots to prevent enemies from reaching the base. Enemies spawn in waves and follow a fixed path, requiring the player to optimize tower placement and resource usage. 

The design is inspired by games like Bloons TD 6 and Raid Rush, focusing on simple mechanics with strategic depth. 

## Core System 

#  ***Tower Placement System*** 

* Uses raycasting from mouse input to detect valid placement areas.  

* Only allows placement on predefined TowerSpot objects.  

* Clicking a valid spot opens a UI panel for tower selection.  

* Selected tower is instantiated on the chosen spot.  

## ***Design Reasoning:*** 

* Raycasting ensures precise and scalable input handling.  

* Restricting placement to TowerSpots avoids invalid placements and simplifies logic. 

 

## ***Enemy System*** 

* Enemies follow a predefined path using waypoints (Level Generator).  

* Movement is handled using simple transform-based logic.  

* When an enemy reaches the base:  

* Player loses a life  

* Event is triggered  

***Design Reasoning:*** 

* Waypoint system provides predictable movement and easy level design.  

* Keeps logic lightweight and efficient. 

 

## ***Economy System*** 

* Players earn coins when enemies are defeated.  

* Coins are spent to place towers.  

* Coin updates are handled through an event-driven system.  

* Design Reasoning: 

* Encourages strategic decision-making.  

* Keeps gameplay loop engaging and resource-driven. 

##  ***Event System (ScriptableObject-Based)*** 

* Centralized GameEvents ScriptableObject handles communication.  

* Events include:  

* Coin changes  

* Lives update  

* Wave start  

* Game over  

***Design Reasoning:*** 

* Reduces tight coupling between systems.  

* More modular than Singleton-based approaches.  

* Improves scalability and maintainability. 

 

## ***Architecture Decisions*** 

* Use of ScriptableObjects 

Used for:  

* Tower data (TowerSO)  

* Game event system  

* Enables data-driven design.  

 Benefit: 

* Designers can tweak values without modifying code. 

 

## ***Loose Coupling via Events*** 

* Systems communicate through GameEvents instead of direct references.  

Benefit: 

* Improves modularity  

* Easier to debug and extend 

 

## ***Prefab-Based Design*** 

Towers and enemies are implemented as prefabs.  

Benefit: 

Reusability  

Faster iteration during development 

 

## ***Game Balancing*** 

* Enemy health increases gradually with each wave.  

* Coin rewards scale slightly to match difficulty.  

* Tower costs remain constant to maintain challenge.  

***Design Goal:*** 

Early game: Easy onboarding  

Mid game: Strategic placement becomes important  

Late game: Resource pressure increases 

## ***Scope Decisions*** 

To maintain focus and ensure timely completion, the following features were intentionally excluded: 

Power-ups  

Complex enemy types  

Advanced UI/animations  

Reasoning: 
Focus was kept on building strong core systems rather than feature overload. 

## Future Improvements 

Add multiple tower types with unique abilities  

Introduce enemy variations (fast, tank, flying)  

Implement tower upgrades  

Improve UI/UX with animations and feedback  

Add sound effects and polish 

## Design Inspiration 

This project draws inspiration from: 

Bloons TD 6 
→ Clean mechanics and strategic tower placement  

Raid Rush 
→ Resource management and placement strategy 