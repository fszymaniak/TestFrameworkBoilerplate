#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Interactive setup script for Test Framework Boilerplate template.

.DESCRIPTION
    This script helps you create a new test project from the TestFrameworkBoilerplate template
    with an interactive menu for configuration options.

.PARAMETER ProjectName
    Name of the test project to create.

.PARAMETER TestType
    Type of test framework (integration, contract, ui, performance).

.PARAMETER TargetFramework
    Target .NET framework version (net8.0 or net9.0).

.PARAMETER OutputPath
    Directory where the project will be created (default: current directory).

.EXAMPLE
    .\setup.ps1
    # Interactive mode - prompts for all options

.EXAMPLE
    .\setup.ps1 -ProjectName "MyApiTests" -TestType integration -TargetFramework net8.0
    # Non-interactive mode with specified parameters
#>

param(
    [Parameter(Mandatory=$false)]
    [string]$ProjectName,

    [Parameter(Mandatory=$false)]
    [ValidateSet('integration', 'contract', 'ui', 'performance')]
    [string]$TestType,

    [Parameter(Mandatory=$false)]
    [ValidateSet('net8.0', 'net9.0')]
    [string]$TargetFramework,

    [Parameter(Mandatory=$false)]
    [string]$OutputPath = ".",

    [Parameter(Mandatory=$false)]
    [ValidateSet('NUnit', 'xUnit', 'MSTest')]
    [string]$TestRunner,

    [Parameter(Mandatory=$false)]
    [bool]$UseWireMock,

    [Parameter(Mandatory=$false)]
    [bool]$UseSpecFlow,

    [Parameter(Mandatory=$false)]
    [bool]$IncludeExamples,

    [Parameter(Mandatory=$false)]
    [bool]$IncludeGitHubActions
)

# Color output functions
function Write-Header {
    param([string]$Message)
    Write-Host "`n$Message" -ForegroundColor Cyan
    Write-Host ("=" * $Message.Length) -ForegroundColor Cyan
}

function Write-Success {
    param([string]$Message)
    Write-Host "✓ $Message" -ForegroundColor Green
}

function Write-Info {
    param([string]$Message)
    Write-Host "ℹ $Message" -ForegroundColor Yellow
}

function Write-Error-Custom {
    param([string]$Message)
    Write-Host "✗ $Message" -ForegroundColor Red
}

# Banner
Clear-Host
Write-Host @"
╔════════════════════════════════════════════════════════════╗
║                                                            ║
║   Test Framework Boilerplate - Interactive Setup          ║
║   SpecFlow · WireMock · Autofac · RestSharp               ║
║                                                            ║
╚════════════════════════════════════════════════════════════╝
"@ -ForegroundColor Cyan

# Check if dotnet CLI is installed
Write-Header "Checking Prerequisites"
try {
    $dotnetVersion = dotnet --version
    Write-Success ".NET SDK detected: $dotnetVersion"
} catch {
    Write-Error-Custom ".NET SDK not found. Please install from https://dotnet.microsoft.com/download"
    exit 1
}

# Interactive prompts if parameters not provided
if (-not $ProjectName) {
    Write-Header "Project Configuration"
    $ProjectName = Read-Host "Enter project name (e.g., MyApiTests)"

    if ([string]::IsNullOrWhiteSpace($ProjectName)) {
        Write-Error-Custom "Project name cannot be empty"
        exit 1
    }
}

if (-not $TestType) {
    Write-Host "`nSelect test type:"
    Write-Host "  1) Integration tests (WireMock + RestSharp)" -ForegroundColor White
    Write-Host "  2) Contract tests (Future: Pact support)" -ForegroundColor Gray
    Write-Host "  3) UI tests (Future: Selenium/Playwright)" -ForegroundColor Gray
    Write-Host "  4) Performance tests (Future: NBomber/K6)" -ForegroundColor Gray

    do {
        $choice = Read-Host "`nChoice [1-4]"
    } while ($choice -notin @('1', '2', '3', '4'))

    $TestType = switch ($choice) {
        '1' { 'integration' }
        '2' { 'contract' }
        '3' { 'ui' }
        '4' { 'performance' }
    }
}

if (-not $TargetFramework) {
    Write-Host "`nSelect target framework:"
    Write-Host "  1) .NET 8.0 (LTS - Recommended)" -ForegroundColor White
    Write-Host "  2) .NET 9.0 (Latest)" -ForegroundColor White

    do {
        $choice = Read-Host "`nChoice [1-2]"
    } while ($choice -notin @('1', '2'))

    $TargetFramework = if ($choice -eq '1') { 'net8.0' } else { 'net9.0' }
}

if (-not $TestRunner) {
    Write-Host "`nSelect test runner:"
    Write-Host "  1) NUnit (Default)" -ForegroundColor White
    Write-Host "  2) xUnit" -ForegroundColor White
    Write-Host "  3) MSTest" -ForegroundColor White

    do {
        $choice = Read-Host "`nChoice [1-3]"
    } while ($choice -notin @('1', '2', '3'))

    $TestRunner = switch ($choice) {
        '1' { 'NUnit' }
        '2' { 'xUnit' }
        '3' { 'MSTest' }
    }
}

if ($null -eq $UseWireMock) {
    $response = Read-Host "`nInclude WireMock for HTTP mocking? [Y/n]"
    $UseWireMock = $response -ne 'n'
}

if ($null -eq $UseSpecFlow) {
    $response = Read-Host "Include SpecFlow for BDD scenarios? [Y/n]"
    $UseSpecFlow = $response -ne 'n'
}

if ($null -eq $IncludeExamples) {
    $response = Read-Host "Include example features and test data? [Y/n]"
    $IncludeExamples = $response -ne 'n'
}

if ($null -eq $IncludeGitHubActions) {
    $response = Read-Host "Include GitHub Actions CI/CD workflow? [Y/n]"
    $IncludeGitHubActions = $response -ne 'n'
}

# Summary
Write-Header "Configuration Summary"
Write-Host "  Project Name:       " -NoNewline -ForegroundColor Gray
Write-Host $ProjectName -ForegroundColor White
Write-Host "  Test Type:          " -NoNewline -ForegroundColor Gray
Write-Host $TestType -ForegroundColor White
Write-Host "  Target Framework:   " -NoNewline -ForegroundColor Gray
Write-Host $TargetFramework -ForegroundColor White
Write-Host "  Test Runner:        " -NoNewline -ForegroundColor Gray
Write-Host $TestRunner -ForegroundColor White
Write-Host "  WireMock:           " -NoNewline -ForegroundColor Gray
Write-Host $(if ($UseWireMock) { "Yes" } else { "No" }) -ForegroundColor White
Write-Host "  SpecFlow:           " -NoNewline -ForegroundColor Gray
Write-Host $(if ($UseSpecFlow) { "Yes" } else { "No" }) -ForegroundColor White
Write-Host "  Include Examples:   " -NoNewline -ForegroundColor Gray
Write-Host $(if ($IncludeExamples) { "Yes" } else { "No" }) -ForegroundColor White
Write-Host "  GitHub Actions:     " -NoNewline -ForegroundColor Gray
Write-Host $(if ($IncludeGitHubActions) { "Yes" } else { "No" }) -ForegroundColor White
Write-Host "  Output Path:        " -NoNewline -ForegroundColor Gray
Write-Host (Resolve-Path $OutputPath) -ForegroundColor White

$confirm = Read-Host "`nProceed with project creation? [Y/n]"
if ($confirm -eq 'n') {
    Write-Info "Setup cancelled by user"
    exit 0
}

# Create project
Write-Header "Creating Project"

# Build dotnet new command
$cmd = "dotnet new testfw -n `"$ProjectName`" -o `"$OutputPath/$ProjectName`" " +
       "--TestType $TestType " +
       "--TargetFramework $TargetFramework " +
       "--TestRunner $TestRunner " +
       "--UseWireMock $UseWireMock " +
       "--UseSpecFlow $UseSpecFlow " +
       "--IncludeExamples $IncludeExamples " +
       "--IncludeGitHubActions $IncludeGitHubActions"

Write-Info "Executing: $cmd"

try {
    Invoke-Expression $cmd

    if ($LASTEXITCODE -eq 0) {
        Write-Success "Project created successfully!"

        # Post-creation steps
        Write-Header "Next Steps"
        Write-Host "1. Navigate to project:" -ForegroundColor Yellow
        Write-Host "   cd $OutputPath/$ProjectName" -ForegroundColor White
        Write-Host "`n2. Restore dependencies:" -ForegroundColor Yellow
        Write-Host "   dotnet restore" -ForegroundColor White
        Write-Host "`n3. Build the project:" -ForegroundColor Yellow
        Write-Host "   dotnet build" -ForegroundColor White
        Write-Host "`n4. Run tests:" -ForegroundColor Yellow
        Write-Host "   dotnet test" -ForegroundColor White

        if ($IncludeExamples) {
            Write-Host "`n5. Explore example scenarios:" -ForegroundColor Yellow
            Write-Host "   Check Features/HttpExamples.feature" -ForegroundColor White
        }

        Write-Host "`n📚 Documentation: Check README.md in your project folder" -ForegroundColor Cyan
        Write-Success "`nHappy Testing! 🚀"

    } else {
        Write-Error-Custom "Project creation failed with exit code $LASTEXITCODE"

        Write-Host "`nTroubleshooting:" -ForegroundColor Yellow
        Write-Host "  • Ensure the template is installed: dotnet new install TestFrameworkBoilerplate.Template"
        Write-Host "  • Check template list: dotnet new list"
        Write-Host "  • Verify .NET SDK version: dotnet --version"

        exit 1
    }
} catch {
    Write-Error-Custom "An error occurred: $_"
    exit 1
}
