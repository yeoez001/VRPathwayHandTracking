# VR Pathway Project (UniSA/Data61): Hand tracking and multi-user support

This project builds upon the VR Pathway Project to implement hand tracking using the Oculus Quest and a multiplayer experience using Photon.  Users are able to interact with metabolites in the pathway visualisation using various hand gestures. It is also a collaborative system that allows multiple users to observe other users’ hand gestures and interact with virtual objects together.

## Photon Setup

1. Create a [Photon](https://www.photonengine.com/) account and go to Dashboard.
2. Create a new app.
3. Copy the __Application ID__ .
4. Open the Unity project and navigate to __Window > Photon Unity Networking > Highlight Server Settings__.
5. Open the inspector and navigate to __Server/Cloud Settings > App Id PUN__.
6. Paste the Application ID into the text field. 

## Application Setup
Push the application to the Oculus Quest device with Oculus Link by __Oculus > OVR Build > OVR Build APK and Run__. For multiple devices to connect to the same room, ensure the same __Application ID__ is used in the Photon setup.
On a PC, the application can be played and viewed from the Scene or Game view. Whilst the application is running, the __Camera__ Gameobjects under __Cameras__ can be enabled for a four-way view of the scene from the Game view. 
On the Oculus Quest device, if hand tracking stops working or your hands disappear from the scene, restart the application. 
## Usage
### Interactions
1. Object grabbing: Pinch or use a full hand grab to pick up objects. Grabbable objects are highlighted blue when they are within grabbing distance and green when they are grabbed. Unpinching or releasing the full hand grab subsequently releases the object.
2. Poke selection: Poke metabolites in the pathway using a pointing gesture to toggle showing its name, chemical structure and graph (if available). Poke the "Show Labels" button to toggle showing the names of all metabolites in the pathway.
3. Laser pointer: A pointing gesture can also be used to trigger a laser pointer that projects from the tip of your index finger. Grabbable objects being pointed to are highlighted yellow. This feature must enabled by navigating to the folder __Resources__ in the project in Unity and double-clicking on __NetworkPlayer__. Then, enable the GameObject __Laser_L__ and/or __Laser_R__ for the preferred hand. 
### Scenes
HandTracking: Various cubes to experience grabbing, pushing and throwing static or gravity-affected objects.
PathwayScene: Pathway visualisation with metabolites that can be grabbed and poked for additional related information. 
SampleScene: Not currently functional. 
