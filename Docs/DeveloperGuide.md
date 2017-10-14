# Setting up

Clone this repo (forking to your own is optional) into your local drive. <br>
Open Unity, choose Open (at the top right) and select the folder that you have cloned.

# Committing

If you make changes that you aren't sure whether to overwrite the previous commit, branch your changes and make a pull request. <br>
Since git does not support viewing parts of a .unity (scene) file, it is hard to resolve conflicts. Make commits incrementally as much as possible. If you want to make experimental changes while others are working on the main file, you can make a duplicate scene and make your changes there.

# For all moving objects in the stage

To correct angle of movement for ships, multiply movespeed by Axis.axis.

# UI settings

ALWAYS set scale mode to "scale with screen size" whenever possible (usually in Canvas for UI elements)

# UI animations

Since pause currently sets timescale to 0, animations that should still run when paused need their update mode to be set to unscaled time.

# UI popups

Add the BlankCanvas prefab and the popup object into a GameObject that uses the following code:
GameObject newCanvas = Instantiate(canvas) as GameObject; <br>
GameObject createImage = Instantiate(popup) as GameObject; <br>
createImage.transform.SetParent(newCanvas.transform, false);

# Triggering events on touch

To make something respond to a touch, you can add an Event Trigger or a Button component. Using Event Trigger, add a New Event Type, select the current object you want to call a function on, then choose a function to call from the scripts in the object. Note that the function to be called must be public. <br>

# Audio

Do not use .mp3 files. Use .wav or .ogg because mp3 files have a latency in Unity. <br>
When adding an Audio Source, select the output to be BGM or SFX group in the audio mixer. This is for ease of volume control.

# PlayerPrefs

Press '\' to delete all PlayerPrefs.

# Debug Room

This scene is for use in Unity Editor only. Do NOT add this scene to build settings. <br>
To use it, just type in intended last cleared stage number and press enter.

# Testing the game on Android

Follow steps in this link https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-android-device-testing