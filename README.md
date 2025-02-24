# 🚀 Bridging Kotlin Multiplatform (KMP) with C# (UWP/WinUI)
This repository explores the experience of integrating **Kotlin Multiplatform (KMP) business logic** into a **C# UWP (WinUI) application**, covering:

✅ Calling **Kotlin/Native (`.dll`) from C#** using **P/Invoke (`DllImport`)**  
✅ Using **UnmanagedExports (`DllExport`)** to expose C# methods to Kotlin  
✅ Exploring **IKVM.NET** for using Kotlin JVM code in .NET  
✅ Finding alternatives for **Flow & Channel in C# (callbacks, shared memory)**  
✅ **Avoiding unnecessary network dependencies (gRPC/WebSockets)**  

⚠️ **This is only an experimental demo project.**

## 🎯 **Why Kotlin Multiplatform (KMP) with C#?**
**KMP is great for sharing business logic across platforms** (Android, iOS, Web, Windows), but integrating **C# (UWP/WinUI) with Kotlin** comes with major challenges.  
Unlike Swift (which has **SKIE** by Touchlab), **C# lacks an official tool** for seamless interop with KMP.

---

## 💀 **Major Pain Points & Lessons Learned**
### ❌ **1. Kotlin Coroutines (`Flow`, `Channel`) Do Not Work in C#**
- **Problem:** `Flow` and `Channel` rely on coroutines, which do not exist in .NET.
- **Attempted Fix:** Used **IKVM.NET** to convert Kotlin **JVM** logic to .NET DLL.
- **Issue:** IKVM.NET **does NOT support coroutines**, so `Flow` and `Channel` cannot be used.
- **Solution:** Replaced `Flow` with **C function pointers (callbacks)**.

✅ **Final Fix:** Use **callbacks (`registerCallback()`) instead of Flow for real-time updates.**  

---

### ❌ **2. Kotlin Data Classes Are Not Directly Usable in C#**
- **Problem:** Kotlin **data classes** (immutable objects) are **not directly readable in C#**.
- **Attempted Fix:** Tried using `IKVM.NET` to convert Kotlin `data class` into a `.NET class`.
- **Issue:** IKVM.NET does not fully support Kotlin's property delegation.
- **Solution:** Convert Kotlin data classes into **C-compatible structs**.

✅ **Final Fix:** Used `@CName` to export a **C Struct** instead of `data class`.

---

### ❌ **3. No Native Kotlin-to-C# Message Passing**
- **Problem:** No way to efficiently **send continuous updates from Kotlin to C#**.
- **Attempted Fix:** Used **polling (`getLatestValue()`)** in C# to check for changes.
- **Issue:** Polling is **inefficient** and wastes CPU.
- **Solution:** Used **shared memory (`MemoryMappedFile`)** instead.

✅ **Final Fix:** Used `MapViewOfFile()` to share memory between Kotlin and C#.

---

## 🚀 **Final Working Solutions**
| Problem | Failed Attempt | Working Solution |
|---------|---------------|------------------|
| **Flow (`Channel`)** | IKVM.NET | ✅ **Function Pointers (`registerCallback()`)** |
| **Data Class (`User`)** | IKVM.NET | ✅ **C Struct (`@CName` export)** |
| **Real-Time Data Updates** | Polling | ✅ **Shared Memory (`MemoryMappedFile`)** |

---

## 🔥 **Future Work**
- 🔄 Add **multi-threading support** for background Kotlin tasks.
- 🛡 Investigate **ZeroMQ or direct IPC (inter-process communication)** as an alternative to shared memory.
- 📦 Package these solutions into an **open-source C# equivalent of Touchlab SKIE** for easier integration.

### **Would you like to contribute? 🚀**
- **Submit Issues** for bugs and feature requests.
- **Open Pull Requests** if you improve performance or add features.

---

## 🎯 **Authors**
- **[@Mahmudxon](https://github.com/mahmudxon)** – Original research, implementation, and fixes.
- **Open for contributions!** Feel free to submit PRs.

---

## 📜 **License**
[MIT License](LICENSE) – Free to use and modify.

