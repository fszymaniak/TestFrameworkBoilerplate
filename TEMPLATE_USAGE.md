# Test Framework Boilerplate - Template Usage Guide

This document explains how to package, test, install, and publish the TestFrameworkBoilerplate as a NuGet template.

---

## 📦 Packaging the Template

### Option 1: Using NuGet Pack (Recommended)

```bash
# From the repository root
nuget pack TestFrameworkBoilerplate.Template.nuspec -Version 1.0.0
```

This creates `TestFrameworkBoilerplate.Template.1.0.0.nupkg`.

### Option 2: Using dotnet pack

```bash
# Create a simple .csproj for packaging
dotnet pack -c Release -o ./artifacts
```

---

## 🧪 Testing the Template Locally

### 1. Install Template Locally

```bash
# Install from the repository directory
dotnet new install .

# Or install from the .nupkg file
dotnet new install ./TestFrameworkBoilerplate.Template.1.0.0.nupkg
```

### 2. Verify Installation

```bash
# List all installed templates (should show 'testfw')
dotnet new list

# Show detailed info about the template
dotnet new testfw --help
```

You should see output like:
```
Test Framework Boilerplate (testfw)
Author: Filip Szymaniak
Options:
  -t|--test-type              integration|contract|ui|performance - Default: integration
  -f|--framework              net8.0|net9.0 - Default: net8.0
  -wm|--use-wiremock          bool - Default: true
  -sf|--use-specflow          bool - Default: true
  -tr|--test-runner           NUnit|xUnit|MSTest - Default: NUnit
  -ex|--include-examples      bool - Default: true
  -ci|--include-ci            bool - Default: true
```

### 3. Test Template Creation

Create a test project to verify the template works:

```bash
# Create a test directory
mkdir /tmp/template-test
cd /tmp/template-test

# Create project with default options
dotnet new testfw -n MyTestProject

# Create project with custom options
dotnet new testfw -n MyApiTests \
  --test-type integration \
  --framework net8.0 \
  --use-wiremock true \
  --test-runner NUnit \
  --include-examples true
```

### 4. Verify Generated Project

```bash
cd MyTestProject

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run tests
dotnet test
```

### 5. Test with Interactive Script

```bash
# Run the interactive setup script
pwsh setup.ps1
```

---

## 🗑️ Uninstalling the Template

If you need to uninstall the template:

```bash
# Uninstall by template name
dotnet new uninstall TestFrameworkBoilerplate.Template

# Or uninstall from path
dotnet new uninstall /path/to/TestFrameworkBoilerplate
```

---

## 🚀 Publishing to NuGet.org

### Prerequisites

1. **NuGet Account**: Create account at https://www.nuget.org
2. **API Key**: Generate API key from https://www.nuget.org/account/apikeys

### Steps to Publish

#### 1. Update Version in .nuspec

Edit `TestFrameworkBoilerplate.Template.nuspec`:

```xml
<version>1.0.0</version>  <!-- Increment for each release -->
```

#### 2. Pack the Template

```bash
nuget pack TestFrameworkBoilerplate.Template.nuspec -Version 1.0.0
```

#### 3. Push to NuGet.org

```bash
# Set your API key (one-time setup)
nuget setapikey YOUR_API_KEY

# Push the package
nuget push TestFrameworkBoilerplate.Template.1.0.0.nupkg -Source https://api.nuget.org/v3/index.json

# Or using dotnet CLI
dotnet nuget push TestFrameworkBoilerplate.Template.1.0.0.nupkg \
  --api-key YOUR_API_KEY \
  --source https://api.nuget.org/v3/index.json
```

#### 4. Verify Publication

- Visit https://www.nuget.org/packages/TestFrameworkBoilerplate.Template
- Wait 5-15 minutes for indexing
- Test installation: `dotnet new install TestFrameworkBoilerplate.Template`

---

## 📋 Release Checklist

Before publishing a new version:

- [ ] Update version in `.nuspec` file
- [ ] Update `releaseNotes` section in `.nuspec`
- [ ] Test template locally with various parameter combinations
- [ ] Verify generated projects build and tests pass
- [ ] Update `README.md` with any new features
- [ ] Create Git tag matching version: `git tag v1.0.0`
- [ ] Push tags: `git push --tags`
- [ ] Build and test on clean machine/container
- [ ] Pack template: `nuget pack TestFrameworkBoilerplate.Template.nuspec`
- [ ] Push to NuGet: `nuget push *.nupkg`
- [ ] Verify package appears on NuGet.org
- [ ] Update GitHub Release with package notes

---

## 🔄 Updating an Existing Template

When you make changes to the template:

1. **Increment Version**:
   ```xml
   <version>1.0.1</version>  <!-- or 1.1.0, 2.0.0 based on semver -->
   ```

2. **Uninstall Old Version**:
   ```bash
   dotnet new uninstall TestFrameworkBoilerplate.Template
   ```

3. **Reinstall from Source**:
   ```bash
   dotnet new install .
   ```

4. **Test Changes**:
   ```bash
   dotnet new testfw -n TestProject -o /tmp/test-new-version
   ```

---

## 🛠️ Advanced Usage

### Using Template with .NET CLI Options

```bash
# Minimal project (no examples, no CI)
dotnet new testfw -n MinimalTests \
  --include-examples false \
  --include-ci false

# Contract testing setup (future)
dotnet new testfw -n ContractTests \
  --test-type contract \
  --use-wiremock false

# UI testing setup (future)
dotnet new testfw -n UITests \
  --test-type ui \
  --use-specflow true

# xUnit instead of NUnit
dotnet new testfw -n XUnitTests \
  --test-runner xUnit
```

### Template Parameters Reference

| Parameter | Short | Type | Default | Description |
|-----------|-------|------|---------|-------------|
| `--TestType` | `-t` | choice | `integration` | Test framework type |
| `--TargetFramework` | `-f` | choice | `net8.0` | .NET version |
| `--UseWireMock` | `-wm` | bool | `true` | Include WireMock |
| `--UseSpecFlow` | `-sf` | bool | `true` | Include SpecFlow |
| `--TestRunner` | `-tr` | choice | `NUnit` | Test runner |
| `--IncludeExamples` | `-ex` | bool | `true` | Include examples |
| `--IncludeGitHubActions` | `-ci` | bool | `true` | Include CI/CD |

---

## 🐛 Troubleshooting

### Template Not Found

```bash
# Check if template is installed
dotnet new list | grep testfw

# Reinstall from current directory
dotnet new install . --force
```

### Package Push Fails

```bash
# Verify API key
nuget setapikey YOUR_API_KEY

# Check package metadata
nuget verify -Signatures TestFrameworkBoilerplate.Template.1.0.0.nupkg

# Try with verbose output
nuget push *.nupkg -Verbosity detailed
```

### Template Doesn't Generate Expected Files

```bash
# Check template.json syntax
cat .template.config/template.json | jq .

# Verify conditions in modifiers
# Example: Check UseWireMock condition
```

### Tests Fail in Generated Project

```bash
# Check .NET SDK version
dotnet --version  # Should be 8.0 or higher

# Restore with verbose output
dotnet restore --verbosity detailed

# Check for missing dependencies
dotnet list package
```

---

## 📚 Additional Resources

- [.NET Template Documentation](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates)
- [template.json Schema](https://json.schemastore.org/template)
- [NuGet Package Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/publish-a-package)
- [Semantic Versioning](https://semver.org/)

---

## 🤝 Contributing Template Improvements

When contributing to the template:

1. Fork the repository
2. Make changes in a feature branch
3. Test template locally: `dotnet new install .`
4. Create test projects with various parameter combinations
5. Verify all tests pass: `dotnet test`
6. Submit PR with detailed description of changes

---

## 📝 Version History

### v1.0.0 (Initial Release)
- Integration test template with SpecFlow and WireMock
- Driver pattern implementation
- Autofac dependency injection
- Support for .NET 8.0 and 9.0
- GitHub Actions workflow
- Interactive PowerShell setup script
- Example HTTP scenarios (GET, POST, PUT)
- Living documentation generation

---

**Questions or Issues?**
- Open an issue: https://github.com/fszymaniak/TestFrameworkBoilerplate/issues
- Check documentation: README.md
- Review examples in the template
