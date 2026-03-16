# NetGuard — Project TODO

> Last updated: 2026-03-16 | Progress: `████████░░░░░░░░░░░░` 35% complete

---

## ✅ COMPLETED

### Week 1 — Foundation & Setup
- [x] Read research paper — *"A Dependable Hybrid Machine Learning Model for Network Intrusion Detection"*
- [x] Set up GitHub repo (public, MIT license)
- [x] Created folder structure (`src`, `data`, `docs`, `notebooks`)
- [x] Added `.gitignore`, `.gitkeep` files
- [x] Added `setup.ps1` for post-clone setup
- [x] Added `CHANGELOG.md` and version badges to README
- [x] Downloaded NSL-KDD dataset (`KDDTrain+.txt`, `KDDTest+.txt`)

### Week 2 — Data Pipeline
- [x] Scaffolded .NET 10 solution with 4 projects (`NetGuard.ML`, `NetGuard.API`, `NetGuard.Web`, `NetGuard.Runner`)
- [x] Created `NetworkTrafficRecord.cs` — input data model with all 41 NSL-KDD features
- [x] Created `NetworkTrafficPrediction.cs` — output model with label and confidence scores
- [x] Created `DataLoader.cs` — CSV ingestion pipeline using ML.NET
- [x] Created `DataPreprocessor.cs` — OneHotEncoding, label encoding, feature concatenation, normalization
- [x] Created `ModelTrainer.cs` — SdcaMaximumEntropy multiclass classifier
- [x] Created `ModelEvaluator.cs` — accuracy, F1, confusion matrix, JSON export
- [x] Created `NetGuard.Runner` — console app for training and evaluation
- [x] Successfully trained first model → saved to `data/processed/netguard-model.zip`
- [x] Fixed cross-machine path issue with `AppDomain.CurrentDomain.BaseDirectory`

---

## 🔲 TO DO

### Week 2 — Finish (this week)
- [ ] Run full evaluation on `KDDTest+.txt` and get actual metrics printed
- [ ] Verify `metrics.json` is saved to `data/processed/`
- [ ] Read one more paper — search *"NSL-KDD intrusion detection benchmark"* on Google Scholar
- [ ] Write *"Dataset & Preprocessing"* section of your paper (1-2 pages)

### Week 3 — Baseline Models
- [ ] Add `LogisticRegression` trainer alongside `SdcaMaximumEntropy`
- [ ] Train both models and compare metrics side by side
- [ ] Add a second trainer method `TrainLogisticRegression()` in `ModelTrainer.cs`
- [ ] Log results for both models to separate JSON files
- [ ] Answer: *which attack type is hardest to detect and why?*
- [ ] Write *"Baseline Models"* section of your paper

### Week 4 — Deep Learning Model
- [ ] Set up Python environment (`pip install tensorflow onnx tf2onnx`)
- [ ] Write Python script in `notebooks/` to train a small neural network on NSL-KDD
- [ ] Export it to ONNX format
- [ ] Load ONNX model in C# using `Microsoft.ML.OnnxRuntime`
- [ ] Run inference pipeline: raw record → ONNX prediction → result
- [ ] Compare Neural Net vs SdcaMaximumEntropy — core research comparison
- [ ] Write *"Deep Learning Approach"* section of your paper

### Week 5 — ASP.NET Core API
- [ ] Clean up the default `NetGuard.API` boilerplate
- [ ] Add `PredictionController.cs` with:
  - `POST /predict` — accepts JSON traffic record, returns prediction
  - `GET /metrics` — returns stored `metrics.json`
  - `POST /simulate` — generates random traffic batch, classifies it
- [ ] Load trained model on API startup using `ModelTrainer.LoadModel()`
- [ ] Add Swagger UI for testing endpoints
- [ ] Write integration tests for API endpoints
- [ ] Test with Postman or curl

### Week 6 — Blazor Dashboard
- [ ] Clean up default `NetGuard.Web` boilerplate
- [ ] Create `Pages/Monitor.razor` — submit a traffic record, see prediction + confidence bar
- [ ] Create `Pages/Metrics.razor` — display confusion matrix table, F1 scores per attack type
- [ ] Create `Pages/Simulation.razor` — run 100 random records, show pie chart of attack distribution
- [ ] Connect Blazor pages to the API via `HttpClient`
- [ ] Add Chart.js via JS interop for visualizations
- [ ] Style with Bootstrap 5

### Week 7 — Research Evaluation
- [ ] Run core experiment: vary training data size (10%, 25%, 50%, 100%) and record accuracy
- [ ] Plot learning curves — data amount vs accuracy
- [ ] Compare all models in a results table (LR vs SDCA vs Neural Net)
- [ ] Calculate false positive rate — critical metric for IDS
- [ ] Write *"Results & Discussion"* section — the academic heart of your paper
- [ ] Record a short demo video of the dashboard

### Week 8 — Polish & Submission
- [ ] Complete full research paper (intro, related work, methodology, results, conclusion)
- [ ] Add XML doc comments to all public classes and methods
- [ ] Write deployment instructions in README
- [ ] Bump version to `0.1.0` in README badges
- [ ] Prepare 10-slide presentation
- [ ] Final clean commit with tag: `git tag v0.1.0`
- [ ] Push tag: `git push origin v0.1.0`
