# OpenGL game
A top-down zombie defence shooter game.

Made with OpenGL, .NET, C#.
<p align="center" width="60%">
  <img src="/gameplay.jpg" alt="Gameplay" width="100%">
</p>

# Gameplay
The player is in the middle of the screen, zombies are spawned randomly around the player. Zombies slowly move towards the player. The player has to shoot the zombies with a colored bullet, thats the same color as the zombie. If a zombie touches the player a life is lost.

## Score
You can see the score in top right of the screen.
* Eliminating Regular enemies gives 1 point
* Eliminating Bosses gives 5 points
  
For now, the scores are not saved after the game ends.

## Controls
* `Aim` - move the mouse, placing the pointer in the direction you want to shoot
* `Shoot` with the mouses `left-click`
* `Change bullet color` with keys `W,A,S,D`, shown in bottom right of the screen

## Game modes
### Levels
There are 2 levels.
Player has 3 lives (for completing both levels).
Each level has a certain number of enemies and a Boss at the end of the level.
In the second level more enemies spawn at the same time and the boss has one more life.

### Endless
The game only ends when all the lives are lost.
Every eith enemy is a boss, but it only has 3 lives.

### Expert
Similar to Endless, but the player has only one life and you lose a life if you shoot an enemy with the wrong color.

## Enemies
### Regular enemy
Zombie colored in a certain color - shoot it with the same color bullet to destroy it.

### Boss
Bigger and slover zombie with multiple lives. Each of its lives can be a different color. To remove a bosses life shoot it with a bullet in the color of the boss. After it loses a life it changes its color. Bosses can have 2 to 5 lives, depending on the mode.

# Run game
To run the game download the `OpenGL_game.zip` from Releases.
* Extract the .zip.
* Open the `OpenGL_game.exe` file.



