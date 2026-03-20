Add-Type -AssemblyName System.Drawing

function Create-PlaceholderPng {
    param(
        [string]$path,
        [int]$width,
        [int]$height,
        [string]$color
    )

    $bitmap = New-Object System.Drawing.Bitmap($width, $height)
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)

    $brushColor = [System.Drawing.ColorTranslator]::FromHtml($color)
    $brush = New-Object System.Drawing.SolidBrush($brushColor)
    $graphics.FillRectangle($brush, 0, 0, $width, $height)

    $pen = New-Object System.Drawing.Pen([System.Drawing.Color]::White, 2)
    $graphics.DrawRectangle($pen, 1, 1, $width-2, $height-2)

    $bitmap.Save($path, [System.Drawing.Imaging.ImageFormat]::Png)
    $graphics.Dispose()
    $bitmap.Dispose()
    Write-Host "Created: $path"
}

$basePath = "C:\Users\18484\Documents\My Games\Terraria\tModLoader\ModSources\TheNineSecrets"

# Create directories
$dirs = @(
    "Items/Accessories/BaseSecrets",
    "Items/Accessories/Combined",
    "Items/Accessories/Tier3",
    "Items/Accessories/Ultimate",
    "Items/Crafting",
    "Tiles",
    "Projectiles",
    "Buffs"
)

foreach ($dir in $dirs) {
    $fullPath = Join-Path $basePath $dir
    if (-not (Test-Path $fullPath)) {
        New-Item -ItemType Directory -Path $fullPath -Force | Out-Null
    }
}

# Tier 1 Base Secrets (32x32)
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/DouSecret.png" 32 32 "#FF4444"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/ZheSecret.png" 32 32 "#44FF44"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/LinSecret.png" 32 32 "#4444FF"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/BingSecret.png" 32 32 "#FFAA00"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/JieSecret.png" 32 32 "#FFD700"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/ZhenSecret.png" 32 32 "#9944FF"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/LieSecret.png" 32 32 "#00FFFF"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/XingSecret.png" 32 32 "#FF66FF"
Create-PlaceholderPng "$basePath/Items/Accessories/BaseSecrets/QianSecret.png" 32 32 "#AAAAAA"

# Tier 2 Combined (32x32)
Create-PlaceholderPng "$basePath/Items/Accessories/Combined/DouBingSecret.png" 32 32 "#FF6622"
Create-PlaceholderPng "$basePath/Items/Accessories/Combined/ZheLinSecret.png" 32 32 "#44AA88"
Create-PlaceholderPng "$basePath/Items/Accessories/Combined/JieQianSecret.png" 32 32 "#CCAA55"
Create-PlaceholderPng "$basePath/Items/Accessories/Combined/XingLieSecret.png" 32 32 "#AA88CC"
Create-PlaceholderPng "$basePath/Items/Accessories/Combined/ZhenJieSecret.png" 32 32 "#BB66DD"

# Tier 3 (32x32)
Create-PlaceholderPng "$basePath/Items/Accessories/Tier3/ZhanShengSecret.png" 32 32 "#FF3333"
Create-PlaceholderPng "$basePath/Items/Accessories/Tier3/ShunYingSecret.png" 32 32 "#33DDFF"
Create-PlaceholderPng "$basePath/Items/Accessories/Tier3/ShouHuSecret.png" 32 32 "#3366FF"

# Tier 4 Ultimate
Create-PlaceholderPng "$basePath/Items/Accessories/Ultimate/NineSecretsUltimate.png" 32 32 "#FFFFFF"

# Crafting Materials
Create-PlaceholderPng "$basePath/Items/Crafting/SecretCore.png" 24 24 "#AA66FF"
Create-PlaceholderPng "$basePath/Items/Crafting/HighSecretCore.png" 24 24 "#DD88FF"
Create-PlaceholderPng "$basePath/Items/Crafting/UltimateCore.png" 24 24 "#FFAAFF"
Create-PlaceholderPng "$basePath/Items/Crafting/SecretForge.png" 44 32 "#886644"

# Tile
Create-PlaceholderPng "$basePath/Tiles/SecretForgeTile.png" 54 36 "#886644"

# Projectile
Create-PlaceholderPng "$basePath/Projectiles/SecretRune.png" 24 24 "#BB88FF"

# Buffs
Create-PlaceholderPng "$basePath/Buffs/LinCooldownBuff.png" 32 32 "#4466FF"
Create-PlaceholderPng "$basePath/Buffs/QianCooldownBuff.png" 32 32 "#888899"
Create-PlaceholderPng "$basePath/Buffs/XingSpeedBuff.png" 32 32 "#FF88FF"

Write-Host "All 27 placeholder textures created successfully!"