# 🗣️ Offline 3D-Avatar-Based Conversational Agent Powered by On-Device LLM

> Real-time, private, and cloud-free voice assistant with speech recognition, language understanding, TTS, and animated 3D avatar lip sync—fully operational on local hardware.

---

https://github.com/user-attachments/assets/33fbe515-e368-4937-9358-eb74b72ef213

## 🚀 Overview

This project presents an end-to-end pipeline for building a **real-time, LLM-powered conversational agent** that runs entirely **offline** on consumer-grade hardware. It integrates:

- On-device **speech-to-text (STT)**
- A **quantized large language model (LLM)** for natural language understanding and generation
- **Text-to-speech (TTS)** synthesis
- A **3D avatar** with synchronized **lip movements**

By eliminating reliance on cloud-based infrastructure, this system enables low-latency, privacy-preserving user interaction, particularly useful in remote, embedded, and bandwidth-constrained environments.

---

## 🎯 Objectives

- 💬 Enable real-time spoken conversations using an LLM entirely offline.
- 🛡️ Ensure user **privacy** and **data sovereignty** by avoiding cloud dependencies.
- 🎭 Deliver rich **HCI experiences** using a 3D animated avatar.
- 📦 Showcase the feasibility of full AI conversational pipelines on **consumer-grade hardware**.

---

## ✨ Features

- 🔊 Real-time speech input (STT)
- 🧠 Natural language understanding via quantized LLM
- 🗣️ Text-to-speech voice generation
- 🧍 3D avatar with dynamic facial animation and lip sync
- ⚙️ Fully offline operation — no internet or cloud required

---

## 🧩 Architecture

```
[Microphone] → [STT Engine] → [Quantized LLM] → [TTS Engine] → [3D Avatar + Lip Sync]
```

---

## 🛠️ Tech Stack

- 🧠 **LLM**: [GGUF-based quantized models](https://github.com/ggerganov/llama.cpp) (e.g., LLaMA, Mistral, Gemma)
- 🗣️ **STT**: Whisper.cpp, Vosk, or Mozilla DeepSpeech (local)
- 🔊 **TTS**: eSpeak NG, Coqui TTS, or Bark (offline)
- 👤 **3D Avatar**: Unity/Unreal/Blender-based rendering with lip sync
- ⚙️ **Programming Languages**: Python, C++, Unity C#

---

## 📦 Installation

```bash
git clone https://github.com/yourusername/offline-3d-llm-agent.git
cd offline-3d-llm-agent
# Follow installation steps for each component (STT, LLM, TTS, Avatar)
```

> 📌 Detailed installation instructions for each module are available in the respective subfolders.

---

## 🧪 Demo

Coming soon! 👀  
Check the [`demo/`](./demo) folder for sample recordings, avatar videos, and performance stats.

---

## 📚 Research Motivation

This project addresses a critical gap in the deployment of privacy-first conversational AI systems. While cloud-based systems dominate today’s assistants (Siri, Alexa, ChatGPT), they introduce:

- 🚫 Data privacy concerns  
- 🐌 Network latency  
- 📡 Inaccessibility in offline/remote regions  

By embedding intelligence directly into local devices, we empower more secure, fast, and accessible interaction models.

---

## 📁 Project Structure

```
offline-3d-llm-agent/
├── stt/                # Speech-to-text engine
├── llm/                # Quantized LLM interface
├── tts/                # Text-to-speech engine
├── avatar/             # 3D avatar and lip sync
├── demo/               # Demo files and recordings
└── README.md           # You're here!
```

---

## 🧠 Future Work

- 👥 Multi-user support with multiple avatars
- 🌍 Multilingual STT/TTS/LLM integration
- 🧪 Performance benchmarking across devices
- 🔐 On-device user profile adaptation

---

