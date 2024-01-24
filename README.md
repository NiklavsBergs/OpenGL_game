# OpenGl game
A top-down zombie defence shooter game.

Made with OpenGL, .NET, C#.

# Gameplay
The player is in the middle of the screen, zombies are spawned randomly around the player. Zombies slowly move towards the player. the player has to shoot the zombies with their color bullet. If a zombie touches the player a life is lost.

## Controls
* `Aim` - move the mouse, placing the pointer in the direction you want to shoot
* `Shoot` with the mouses `left-click`
* `Change bullet color` with keys `W,A,S,D`, shown in bottom right of the screen

## Game modes
### Levels
There are 2 levels.
Player has 3 lives (for completing both levels).
Each level has a certain number of enemies and a Boss at the end of the level.
In the second level more enemies spawn at the same time and the bos has one more life.

### Endless
The game only ends when all the lives are lost.
Every eith enemy is a boss, but it only has 3 lives.

### Expert
Similar to Endless, but the player has only one life and you lose a life if you shoot an enemy with the wrong color.


