# NetGuard 🛡️
**AI-Driven Network Intrusion Detection System**

A machine learning system that classifies network traffic as 
normal or attack types (DoS, Probe, R2L, U2R) using ML.NET, 
exposed via an ASP.NET Core API and visualized in a Blazor dashboard.

## Project Status
🚧 In active development 

## Tech Stack
- ML.NET — model training & inference
- ASP.NET Core — REST API
- Blazor Server — web dashboard
- NSL-KDD — benchmark dataset

## Project Structure
- `src/NetGuard.ML` — data pipeline, feature engineering, model training
- `src/NetGuard.API` — REST API endpoints
- `src/NetGuard.Web` — Blazor frontend dashboard
- `data/` — dataset storage (raw files not tracked by Git)
- `notebooks/` — Python scripts for ONNX model export

## Research Topic
AI-Driven Intrusion Detection Systems 


## Dataset
NSL-KDD — available on [Kaggle](https://www.kaggle.com/datasets/hassan06/nslkdd)
