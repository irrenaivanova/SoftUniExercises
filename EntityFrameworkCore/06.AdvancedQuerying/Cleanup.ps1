
$rootPath = "C:\Users\schhh\Desktop\SoftUni\SoftUniExercises\EntityFrameworkCore\06.AdvancedQuerying"

$directories = Get-ChildItem -Path $rootPath -Recurse -Directory -Include "obj","bin"

foreach ($directory in $directories) {
    try {
        Remove-Item -Path $directory.FullName -Recurse -Force
        Write-Host "Deleted: $($directory.FullName)"
    } catch {
        Write-Host "Failed to delete: $($directory.FullName) - $($_.Exception.Message)"
    }
}

Write-Host "Cleanup complete."

