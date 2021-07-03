# PT_ConsoleApp_GameShipsAndBoats

## General Information

PT_ConsoleApp_GameShipsAndBoats is a familiar paper-and-pencil game which I used to play with my father.  
What we needed were 2 pens, 2 sheets of paper and our backs agains each other!

![GitHub Logo](res/scrot/PT_ConsoleApp_GameShipsAndBoats.jpg)

20 years later, I decided to implement the game as a console application.  
The most interesting challenge was the pseudo "AI" algorithm that was needed for the role of the Opponent (PC).  
Once it hits anything - how it chooses what slot to attack next and which slots should it consider pointless...

## Technologies

- NUnit
- System.Data.SqlClient

## Rules\*

There are 2 players - You and the Opponent (PC).

Both sides have a battlefield - a square matrix (10 x 10 slots).

Both opponents have a fleet of 10 vessels that consists of:

- 1 Tanker (TTTT)
- 2 Submarines (SSS)
- 3 Carriers (CC)
- 4 Boats (B)

Before the game starts the Engine randomly generates the 10 vessels on your battlefield as well as 10 onto the Opponent's matrix. It follows the rules below:

- A Boat (B) could be placed anywhere (in the corners, on the edges or in the middle)
- A Carrier (CC), a Submarine (SSS) or a Tanker (TTTT) could be placed in the middle or onto an edge of the matrix. If on edge - only 1 of its segments can touch it.
- 2 vessels cannot touch (either on a side or diagonally)
- All slots surrounding a vessel should be left empty (left, right, top, bottom + 4 "diagonal" slots)

The Gameplay follows these simple rules:

- The Opponent opens the game by playing first
- You shoot at your Opponent's battlefield by an input of 2 coordinates (column (A-J) + row (0-9)). B6, j0, a1 are valid commands (case insensitive)
- It is the opponent's turn once you hit a blank slot and vice versa.
- Once a slot with a vessel is hit it turns to 'T', 'S', 'C' or 'B'. If the slot was already hit it would turn to 'X'. If empty - 

The one to destroy all enemy's vessels first wins!

\* If you are about to play the game - please go to Instructions from the main menu in order to watch some animated examples.

## Contents

The solution contains 2 directories:

- src
  - Game
    - GameShipsAndBoats.Game (.NET Core Console Application)
    - GameShipsAndBoats.Game.Tests (NUnit test project)
- res
  - scrot
    - PT_ConsoleApp_GameShipsAndBoats.jpg
  - PT_Console_App_ShipsAndBoatsGame.ico

\~THE END\~
