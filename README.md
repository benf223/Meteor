# Meteor
Meteor is an endless mobile game where one must protect a village from falling meteorites by swiping them away into the surrounding waters. The goal is gain the most amount of points by surviving as long as possible.

## Acquiring our game
These instructions will get you a copy of the Unity project of Meteor to view the source code, see how game was built, and of course, to try out the game yourself on an Android device. 
NOTE: Our game is yet not officially released on any app stores, so there are limitations and requirements to try out Meteor.
The game has only been tested on Android devices, so we are unsure if the game would work on other operating systems such as iOS devices.

### Prerequisites
These prerequisites have only been written for Android devices.
* Unity
* Android Device with USB debugging enabled

### Installing the Game
1. Visit our GitHub repository here: [Meteor](https://github.com/benf223/Meteor)
2. Click on the green button that says "Clone or Download"
3. Either clone, or download the zip if you prefer to use the the GitHub application, or get the direct Unity project in a ZIP file.
4. Open the project with Unity
5. Connect Android device via USB (with USB Debugging Enabled)
6. In Unity, navigate to > File > Build Settings
7. Select Android under "Platform"
8. Select "Build and Run"
9. Select a location to store the .apk file and click "Save"
10. Wait for game to build and enjoy the game on your Android device!

## Playing the Game
### Controls
Touch the buttons in the menu to navigate through.
Swipe the meteorites in the direction you wish to flick them towards (preferably away from the village :))
### Starting the Game
When in the main menu, which should be the first screen, touch on "Play Game" to start playing the game
### Your Objective
Meteorites will be falling from the sky, with some of them directly targeting the village. You must swipe the meteorites away from the village in order to protect it from extinction. Scoring will be tracked by how many meteorites have been avoided from the village, and by staying alive. 
### Difficulty
Does the game sound easy enough? Well here's the catch:
* There are walls on the edges of the screen, so meteorites will bounce off them.
* Meteorites can only be swiped ONCE!
* Some meteorites will directly target the village (Aggressive meteorites, coloured RED)

As the game progresses, the difficulty of the game will increase. Here are the affecting factors:
* Increased Meteorite Speed
* Increased Meteorite Spawn Delay (More meteorites will spawn)
* Village Expansion (Village will expand max of two times; bigger hitbox)
* More Aggressive Meteorites (More will directly target the village)
### Scoring
* 1 point for every second survived
* 2 points for every meteorite landing in the waters
### Powerups
Every 10 seconds, an item box will parachute down from the sky. These boxes can be swiped. If an item box hits the village, you will receive one of the following powerups for a short duration:
* Cannon: A cannon that shoots cannon balls in an arc that will destroy incoming meteorites if made contact.
* Multiple Touhces: Meteorites can be swiped multiple times, instead of once.
* Shield: Grants a protective shield over the village that destroys meteorites when made contact with.
* Slow Meteorites: Meteorites travel slower
* Wall Breaker: Walls have been temporarily disabled, allowing you to swipe meteorites out of the screen.
### Game End
The game ends when a meteorite has made contact with the village, causing both to explode. Highscores will be tracked locally and can be accessed in the menu.
### Game Pause
The game can be paused during gameplay by touching on the red pause button located at the upper right of the screen.
The options available during game pause:
* Resume: Unpause the game and continue gameplay
* Restart: Restarts the game like you've just started a new game.
* Menu: Returns to main menu.

## The Menu
### Main Menu
* Play Game: Start saving villages from falling meteorites!
* Highscores: View the top highscores acheived for this device
* Settings: Adjust various game settings
* Quit: Exit the game to return to your launcher
### Highscores
View the top 5 highscores currently stored in this device.
* Back: Return to the main menu.
### Settings
* Music Slider: Adjust the volume for the music
* SFX: Adjust the volume for sound effects
* Master: Adjust the overall volume of the game
* Mute: Sets all volume sliders to the minimal, effectively muting all sounds. Touch again to unmute.
* Reset Highscores: Resets all highscores to 0 for this device.
* Apply: Applies all settings and returns to the main menu.

## Deployment
(See  "Installing the Game" above)

## Authors
- FUKANG, INC: Software Development Practice Stream 51 

See the list of [contributors](https://github.com/benf223/Meteor/graphs/contributors) who participated in this project.

## Licensing
The majority of the music were mixed by one of our developers. Other music and sound effects were found online and are Royalty-Free.
All artwork seen in the game has been designed by our creative developers themselves.

