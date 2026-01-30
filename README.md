# World XR Sandbox

> **Portfolio Project:** Multiplayer Augmented Reality application demonstrating advanced networking, real-time synchronization, and cross-platform mobile development

A production-ready XR application enabling multiple users to collaboratively interact with AR objects in shared physical space. Built with **Unity**, **C#**, **Photon Networking (PUN 2)**, and **AR Foundation**, this project showcases expertise in real-time multiplayer systems, augmented reality development, and mobile application architecture.

![example1](https://user-images.githubusercontent.com/31843656/133831706-e700f8fb-7a8c-428a-bd31-ddbff70cb563.png)

## 🎯 Key Technical Achievements

- **Real-Time Multiplayer Networking**: Implemented room-based architecture using Photon Unity Networking 2 (PUN 2) for seamless multi-user collaboration
- **AR Object Synchronization**: Developed synchronized object manipulation system allowing users to create, move, rotate, and scale 3D objects with real-time updates across all connected clients
- **Cross-Platform AR Development**: Built for Android devices using Unity's AR Foundation and ARCore
- **Scalable Architecture**: Designed modular C# codebase following Unity best practices for maintainability and extensibility
- **State Management**: Implemented custom room properties and player state synchronization using Photon's callback system

## 💻 Technologies & Skills Demonstrated

### Core Technologies
- **Unity 2020.3** - Game engine and XR framework
- **C# / .NET** - Primary programming language for all application logic
- **Photon Unity Networking 2 (PUN 2)** - Real-time multiplayer networking framework
- **AR Foundation / ARCore** - Augmented reality platform for Android
- **Mixed Reality Toolkit (MRTK)** - UI/UX framework for XR applications

### Technical Skills
- Real-time networked multiplayer systems
- Client-server architecture and synchronization
- Object-oriented programming and design patterns
- Mobile AR development and optimization
- Unity scene management and lifecycle
- Network state management and custom properties
- Cross-platform mobile deployment (Android APK builds)

## 📝 Project Overview

Originally developed as a capstone project in partnership with **SphereGen** (mixed reality consultancy), this application was designed to explore the intersection of augmented reality and real-time networking. The project demonstrates practical implementation of enterprise-grade multiplayer AR experiences.

### Core Features
- **Host/Join System**: Create or join multiplayer AR rooms with unique room IDs
- **Real-Time Object Manipulation**: Instantiate and manipulate 3D AR objects visible to all users
- **Synchronized Transforms**: Position, rotation, and scale updates propagated across all clients
- **Player Management**: Handle multiple concurrent users with proper connection/disconnection handling

## 🏗️ Architecture & Implementation

### Networking Layer
- Implemented using **Photon PUN 2** for reliable real-time communication
- Custom room creation system with auto-generated unique room IDs
- Master client architecture for authoritative game state
- Automatic scene synchronization across all connected clients
- Custom properties system for shared room state

### AR Implementation
- **ARCore** integration for Android device tracking and plane detection
- Camera-relative object spawning for intuitive AR placement
- Real-time transform synchronization using PhotonView components
- Optimized for mobile performance with efficient networking protocols

### Code Architecture
```
Key Components:
├── Launcher.cs          → Connection management and room operations
├── RoomManager.cs       → Room lifecycle and player callbacks
├── ObjectManager.cs     → AR object instantiation and management
└── PlayerNameInputField → User identification and preferences
```

## 🚀 Getting Started

### Prerequisites
- Android device with ARCore support
- Camera permissions enabled

### Installation
1. Download the latest APK from [Releases](https://github.com/JavaPhish/World-XR-Sandbox/releases/tag/v1.0-android)
2. Install on ARCore-compatible Android device
3. Grant camera permissions when prompted

### Usage
**Host Mode**: Create a new multiplayer session
- Enter your name
- Tap "Host" to create a room
- Share the generated Room ID with others

**Join Mode**: Connect to an existing session
- Enter your name
- Input the Room ID provided by host
- Tap "Join" to connect

Once connected, tap to place and manipulate 3D objects in AR space—all changes are synchronized in real-time across all connected users.

## 📦 Dependencies & Frameworks

| Technology | Purpose | Version |
|-----------|---------|---------|
| Unity | Game engine and AR platform | 2020.3.10f1 |
| Photon Unity Networking 2 (PUN 2) | Real-time multiplayer framework | Latest |
| Mixed Reality Toolkit (MRTK) | XR UI/UX components | 2.7.2 |
| AR Foundation | Cross-platform AR abstraction | 4.1.7 |
| ARCore XR Plugin | Android AR implementation | 4.1.7 |
| TextMesh Pro | Advanced text rendering | 3.0.6 |

## 👥 Development Team & Acknowledgments

**Developers:**
- **Carter Clements** - [@JavaPhish](https://github.com/JavaPhish)
- **Mitchell Moscovics** - [@mmoscovics](https://github.com/mmoscovics)

**Mentor:**
- Eric Wilson - Mixed Reality Developer at [SphereGen](https://www.spheregen.com)

**Partnership:**
This project was developed in collaboration with SphereGen, a mixed reality consultancy, who provided concept development, technical mentorship, and industry best practices guidance throughout the development cycle.

## 🔧 Technical Highlights for Recruiters

This project demonstrates proficiency in:

- ✅ **C# / .NET Development** - Clean, maintainable object-oriented code
- ✅ **Real-Time Networking** - Multiplayer synchronization and state management
- ✅ **Mobile Development** - Android deployment with performance optimization
- ✅ **Augmented Reality** - ARCore integration and spatial computing
- ✅ **Unity Engine** - Scene management, prefab systems, and component architecture
- ✅ **Problem Solving** - Handling network latency, state synchronization, and cross-platform compatibility
- ✅ **Collaboration** - Worked with industry mentor and partner organization
- ✅ **Version Control** - Git workflow and collaborative development

## 📊 Project Status

**Current Version**: v1.0 (MVP)

This MVP implementation includes:
- ✅ Functional room host/join system
- ✅ Real-time object creation and manipulation
- ✅ Multi-user synchronization
- ✅ Android deployment pipeline

**Future Enhancement Opportunities:**
- Persistent object anchoring (with alternative to deprecated Azure Spatial Anchors)
- Advanced gesture controls and interactions
- Voice chat integration
- iOS platform support
- Enhanced UI/UX with more MRTK components
- Performance optimizations for larger rooms

## 📄 License

This is a portfolio project demonstrating technical capabilities in XR development and real-time networking.

---

**Note**: This project previously utilized Azure Spatial Anchors for persistent world anchoring, which has been deprecated by Microsoft. The current implementation focuses on session-based multiplayer AR without persistent anchors.