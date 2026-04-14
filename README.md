# Tower Defence (Lite)

A simple tower defense game built with Unity, focused on strategic placement, enemy waves, and resource management.

## Overview

Place towers on designated spots to stop enemies from reaching your base. Earn coins, manage lives, and survive all waves.

## Features

* Tower placement system (grid-based)
* Multiple tower types
* Wave-based enemy progression
* Coin & life management
* Event-driven architecture (ScriptableObjects)
* Object pooling for performance

# Controls

Left Click: Select tower spots / interact with UI

## Setup

Unity Version: 6000.3.4f1
* Open project → Load `Tower Defence.unity` → Press Play

## Tech Highlights

* ScriptableObject-based event system (loose coupling)
* Modular architecture (Managers + SOs)
* Object pooling for enemies

## Goal

Win: Survive all waves
Lose: Lives reach 0

## Structure
Scripts/
├── Manager
├── Tower
├── Enemy
├── UI
├── Waves
└── Player

## Notes

Built for learning and demonstrating clean architecture in Unity.
