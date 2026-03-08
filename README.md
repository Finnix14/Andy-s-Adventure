# Andy's Adventure

Early Unity prototype created while learning **C# programming and game development fundamentals**.

The project explores basic gameplay systems including player movement, enemy AI, interactive environments, and scene management.

This repository represents one of my first experiments building a playable game using Unity.

---

## Technologies

- Unity Game Engine
- C#
- Unity Physics & Animation systems
- A* Pathfinding Project (third party AI navigation library)

---

## Features

### Player Systems

Basic player controller and gameplay interactions.

Scripts:
- `PlayerController.cs`
- `PlayerDeath.cs`
- `Fall.cs`

---

### Enemy AI

Enemies use AI behaviour and pathfinding to navigate the level.

Scripts:
- `EnemyAI.cs`
- `EnemyGFX.cs`
- `DeathAI.cs`

Navigation is handled using the **A* Pathfinding Project**.

---

### Environment Mechanics

**Rope System**

- `StickyRope.cs`
- `RopeSegment.cs`

Experimental rope physics and attachment behaviour.

**Moving Platforms**

- `MovingPlatform.cs`
- `StickyPlatform.cs`

Used to create traversal challenges within levels.

---

### Camera System

- `CameraController.cs`

Controls camera tracking and framing during gameplay.

---

### Level & Scene Management

Scripts managing level transitions and scene loading:

- `LevelManager.cs`
- `LevelLoader.cs`
- `SceneChange.cs`

---

### Menus

Basic menu systems for navigating the game.

- `MainMenu.cs`
- `PauseMenu.cs`
- `MenuLoad.cs`

---

### Audio System

Manages music and sound effects.

- `AudioManager.cs`
- `MusicManager.cs`
- `Musicplay.cs`
- `SoundManager.cs`

---

## Purpose

This project was created while learning:

- Unity’s component system
- C# gameplay scripting
- Basic AI behaviour
- Physics interactions
- Scene management and UI systems

## Author

**Finley Nye**  
Game Development Student – University of Brighton

GitHub:  
https://github.com/Finnix14
