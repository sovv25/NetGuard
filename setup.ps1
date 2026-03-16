# NetGuard Setup Script
# Run this after cloning: .\setup.ps1

Write-Host "=== NetGuard Setup ===" -ForegroundColor Cyan

# 1 - Create folder structure
Write-Host "`n[1/4] Creating folder structure..." -ForegroundColor Yellow

$folders = @(
    "src/NetGuard.ML/Data",
    "src/NetGuard.ML/Models", 
    "src/NetGuard.ML/Training",
    "src/NetGuard.ML/Evaluation",
    "src/NetGuard.Runner",
    "src/NetGuard.API",
    "src/NetGuard.Web",
    "data/raw",
    "data/processed",
    "docs/papers",
    "notebooks"
)

foreach ($folder in $folders) {
    New-Item -ItemType Directory -Force $folder | Out-Null
    Write-Host "  ✅ $folder"
}

# 2 - Restore NuGet packages
Write-Host "`n[2/4] Restoring NuGet packages..." -ForegroundColor Yellow
dotnet restore
if ($LASTEXITCODE -ne 0) {
    Write-Host "  ❌ dotnet restore failed" -ForegroundColor Red
    exit 1
}
Write-Host "  ✅ Packages restored"

# 3 - Build solution
Write-Host "`n[3/4] Building solution..." -ForegroundColor Yellow
dotnet build --no-restore
if ($LASTEXITCODE -ne 0) {
    Write-Host "  ❌ Build failed" -ForegroundColor Red
    exit 1
}
Write-Host "  ✅ Build succeeded"

# 4 - Check for dataset
Write-Host "`n[4/4] Checking dataset..." -ForegroundColor Yellow
$trainFile = "data/raw/KDDTrain+.txt"
$testFile = "data/raw/KDDTest+.txt"

if (Test-Path $trainFile) {
    Write-Host "  ✅ KDDTrain+.txt found"
} else {
    Write-Host "  ⚠️  KDDTrain+.txt not found" -ForegroundColor Yellow
    Write-Host "     Download from: https://www.kaggle.com/datasets/hassan06/nslkdd" -ForegroundColor Gray
    Write-Host "     Place in: data/raw/" -ForegroundColor Gray
}

if (Test-Path $testFile) {
    Write-Host "  ✅ KDDTest+.txt found"
} else {
    Write-Host "  ⚠️  KDDTest+.txt not found" -ForegroundColor Yellow
    Write-Host "     Download from: https://www.kaggle.com/datasets/hassan06/nslkdd" -ForegroundColor Gray
    Write-Host "     Place in: data/raw/" -ForegroundColor Gray
}

# Done
Write-Host "`n=== Setup Complete ===" -ForegroundColor Cyan
Write-Host "Once dataset is in data/raw/, run:" -ForegroundColor White
Write-Host "  dotnet run --project src/NetGuard.Runner" -ForegroundColor Green