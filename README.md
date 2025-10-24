# ⚔️ Unity-3Room-Dungeon-Slayer (or Dungeon-Slayer-Survival)

## Project Description

A 2D/3D action-survival game developed in **Unity** where the player navigates through **three distinct dungeon rooms**, facing a variety of enemies and environmental hazards. The core loop involves managing limited player health while utilizing a ranged attack (shooting) to clear the rooms and defeat the final boss.

This project focuses on implementing diverse AI behaviors (Chase, Patrol, Guard), complex trap mechanics, and essential game features like checkpoints and combat systems.

---

## ⚙️ Core Gameplay Mechanics

### 1. Player Systems (Slayer)
* **Health:** The player has a limited health pool.
* **Ranged Combat:** The player is equipped with a primary shooting mechanism to engage and eliminate enemies from a distance.

### 2. Environment & Progression
* **3-Room Structure:** The game is divided into three consecutive challenge rooms.
* **Checkpoint/Respawn:** A **checkpoint is established at the start of Room 3**. Upon death, the player respawns at the most recent checkpoint.

---

## 🎯 Enemy Types and AI Behavior

The game features three unique enemy types, each presenting a different challenge:

| Enemy | Behavior / Mechanics | Threat Level |
| :--- | :--- | :--- |
| **🐻 The Hunter (Bear/Charger)** | **Aggressive Chase:** Initiates a sprint towards the player once the player enters its **line of sight**. Deals damage upon collision. | **High (Direct Threat)** |
| **🚶‍♂️ The Wanderer (Patroller)** | **Simple Patrol:** Moves back and forth along a fixed path. **Must be avoided or jumped over** as direct shooting is the primary method of engagement. | **Medium (Platforming/Movement Check)** |
| **🛡️ The Guardian (Final Boss)** | **Guarding and Melee:** **Stays in a fixed area** guarding the end of Room 3. Attacks (punches) the player with a short-range melee attack when they get too close. **Defeating this enemy completes the game.** | **Boss (Endgame Objective)** |

---

## 💀 Traps and Environmental Hazards

Each room contains hazards designed to test player navigation and reaction time:

| Trap | Mechanic | Description |
| :--- | :--- | :--- |
| **Spikes (Ground Trap)** | **Instant Damage:** Spikes embedded in the floor that deal damage instantly upon contact. Requires precise jumping/movement. | **Fixed Hazard** |
| **🔥 Fire Torches (Delayed Activation)** | **Timed Damage:** Torches that briefly ignite after a **0.5-second delay** upon the player's initial collision. Requires quick movement away from the point of contact to avoid burn damage. | **Interactive Hazard** |

---

### Game Design 


#### All rooms

![images](https://github.com/MahdisSep/Unity-3Room-Dungeon-Slayer/blob/main/Room%20Pictures/All%20rooms.png)

#### Room 1

![images](https://github.com/MahdisSep/Unity-3Room-Dungeon-Slayer/blob/main/Room%20Pictures/room1.png)

#### Room 2

![images](https://github.com/MahdisSep/Unity-3Room-Dungeon-Slayer/blob/main/Room%20Pictures/room2.png)

#### Room 3

![images](https://github.com/MahdisSep/Unity-3Room-Dungeon-Slayer/blob/main/Room%20Pictures/room3.png)


-----

## 🚀 How to Run the Project

This project requires **Unity** to run.

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/USERNAME/Unity-3Room-Dungeon-Slayer.git](https://github.com/MahdisSep/Unity-3Room-Dungeon-Slayer.git)
    ```
2.  **Open in Unity:** Open the cloned folder as a project in the Unity Editor (The uploaded `SampleScene.unity` will be the main level).
3.  **Run:** Press the Play button in the Unity Editor.

*(Note: The `SampleScene.unity` file is the primary scene containing all game objects and logic.)*
