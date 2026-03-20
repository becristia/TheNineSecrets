Add-Type -AssemblyName System.Drawing

$basePath = "C:\Users\18484\Documents\My Games\Terraria\tModLoader\ModSources\TheNineSecrets"

Get-ChildItem -Path $basePath -Recurse -Filter "*.png" | ForEach-Object {
    $img = [System.Drawing.Image]::FromFile($_.FullName)
    $relativePath = $_.FullName.Replace($basePath, "").TrimStart('\')
    Write-Output ("{0}x{1} - {2}" -f $img.Width, $img.Height, $relativePath)
    $img.Dispose()
}