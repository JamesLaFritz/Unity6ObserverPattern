# 🧭 The Observer Pattern in Unity

**Design Pattern:** Observer (Publisher–Subscriber, or Event Pattern)
**Language:** C#
**Engine:** Unity

This example demonstrates how to implement the **Observer Pattern** inside Unity using both **UnityEvents** and **C# Delegates / Actions / Events**.

The pattern helps you create **loosely coupled gameplay systems**, where one class (the *publisher*) broadcasts events and multiple other classes (the *observers*) respond to them — without direct references.

---

### 🎮 Example Scenario

In this demo project, a simple game loop is simulated where:

* The **Level** component gains XP and triggers a `LevelUp` event.
* The **Health** component listens for that event and resets HP to full.
* A **Particle System** plays to visually represent the level-up.
* A **Debugger** script displays live information for XP, Level, and Health.

---

### 🧩 Key Features

* Demonstrates **UnityEvent**, **Delegate**, and **Action** approaches.
* Promotes **loose coupling** and **reusability** between components.
* Adheres to **SOLID** principles (especially *Open–Closed*).
* Easy to extend with new observers such as UI, audio, or gameplay systems.

---

### 🧠 Concepts Covered

* **Observer Pattern / Publisher–Subscriber**
* **UnityEvent vs. C# Event** comparison
* **Delegates**, **Actions**, and **Event keyword** usage
* **Event subscription best practices** (`OnEnable` / `OnDisable`)
* **Fire-and-forget communication** between components

---

### 🏗 Project Structure

```
Assets/_ObserverPattern/
 ├── Scripts/
 │   ├── Level.cs
 │   ├── Health.cs
 │   ├── Debugger.cs
 │   └── ParticleController.cs
 ├── Prefabs/
 ├── Scenes/
 ├── Settings/
```

---

### 🚀 Getting Started

1. Open the project in Unity (6000.2.6f2 or higher recommended).
2. Open the **ObserverPattern** scene.
3. Enter **Play Mode** to see events trigger the observers.

---

### 🧠 Notes for Readers / Developers

* This setup is **for demonstrating the Observer Pattern concept only.**
* No actual events or UnityEvents are wired yet — that’s handled in later implementations (e.g., using `UnityEvent` or `C# events`).
* The goal is to **show the initial state** before adding the observer logic.
* Each component is independent — meaning they can evolve into **publishers or subscribers** when the event system is introduced.

---

### 🔗 Related Resources

* 🧩 [Medium Article: *The Observer Pattern in Unity*](https://medium.com/@ktmarine1999)
* 💡 [Unity Documentation: UnityEvent](https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html)
* 🧠 [Microsoft Docs: Delegates and Events](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/)

---

### 🏁 License

This project is open-source under the [MIT License](LICENSE).

---
