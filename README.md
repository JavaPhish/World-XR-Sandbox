# World XR Sandbox

An XR demo that lets Users interact with AR props in the real world. Using Azure Spatial Anchors and Photon Networking, users in the real world can see each other interacting with AR objects in real time, in the same position.

![example1](https://user-images.githubusercontent.com/31843656/133831706-e700f8fb-7a8c-428a-bd31-ddbff70cb563.png)

## Description

This project was created to meet the requirements of Holbertons AR/VR Specializations Final Portfolio Project.
We worked in partner with SphereGen, they provided a concept and mentored us allowing us to create a functional product with real world application, as well as providing assistance when discussing concepts frameworks and troubleshooting.
Initially created with only an MVP in mind to understand concepts and functionality of XR Networking.

## Installation

Download APK and source code via [releases](https://github.com/JavaPhish/World-XR-Sandbox/releases/tag/v1.0-android)
Make sure to allow camera access
Only works on Android devices with AR capability

## Usage

Host - Creates a room/session to instantiate and interact with objects.
Join - Joins a room/session based on the room ID from the hosted session.
Follow on screen prompts for more information.

Connect to a room with others to interact with 3D AR objects in real time.
Object creation and manipulation, including movement, rotation, and scaling, is updated and synced across everyone in the room.

## Assets

photon unity networking 2 - [PUN 2](https://assetstore.unity.com/packages/tools/network/pun-2-free-119922)
Mixed Reality Toolkit-Unity - [MRTK](https://github.com/microsoft/MixedRealityToolkit-Unity)

## Authors & Acknowledgement

Carter Clements @ https://github.com/JavaPhish
Mitchell Moscovics @ https://github.com/mmoscovics

Mentor: Eric Wilson - Mixed Reality Developer from [SphereGen](https://www.spheregen.com/?gclid=CjwKCAjwhaaKBhBcEiwA8acsHO1QE0jO1Nf-D7wx5VLw0QRFLD9YPpGIAlpFHfce6AomEJK_4bXiQhoC2OUQAvD_BwE)

## Project Status

This is an MVP build that has basic functionality of a room host and join system, and basic object creation and manipulation.