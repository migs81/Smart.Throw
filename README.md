# 📚 Smart.Throw

A lightweight C# library for simplifying parameter validation and exception throwing.

## 📝 Description

Smart.Throw is designed to make input validation and exception throwing more concise and maintainable.
Reduces boilerplate code and improves readability by providing expressive validation methods.

## ✨ Features

- **Common Validations**: Built-in checks for `null`, empty strings, ranges, and custom conditions.
- **Exception Throwing**: Throw exceptions with descriptive messages concisely.
- **Cross-Platform**: Supports `.NET Standard 2.0`, `.NET 6.0`, and `.NET 8.0`.

## 🛠️ Prerequisites

- .NET SDK (6.0 or 8.0) or a compatible IDE (Visual Studio, Rider, etc.).

## 📦 Installation

1. Clone the repository:
  ```bash
   git clone https://github.com/migs81/Smart.Throw.git
  ```
2. Navigate to the project directory:
  ```bash
   cd Smart.Throw
  ```
3. Restore dependencies:
  ```bash
   dotnet restore
  ```
4. Build the project:
  ```bash
   dotnet build
  ```

## 💻 Usage

### Basic Validation

```csharp
using Smart.Throw;

string? path = null;
string? filename = null;

// validate a parameter and throw if null
Throw<ArgumentNullException>.IfNull(path);

// validate a string and throw if null or empty
Throw<ArgumentException>.IfNullOrEmpty(path);

// validate a collection of arguments
Throw<NullReferenceException>.IfAnyNull(path, filename);

// define a custom error message
Throw<ArgumentNullException>.IfNull(path, "custom message");
```

### Custom Validation

```csharp
// validate with custom conditions
Throw<PathTooLongException>.If(path.Length > 255);
Throw<ArgumentException>.If(path?.StartsWith('C') == true);
```

### Extensions

```csharp
public class UserProfile
{
    public string Username { get; set; }
    public ICollection<string> Permissions { get; set; }

    public UserProfile(string username, ICollection<string> permissions)
    {
        // validate arguments with extension methods
        Username = username.ThrowIfNullOrWhiteSpace();
        Permissions = permissions.ThrowIfNullOrEmpty();
    }
}
```

## 📊 Benchmarks

This project includes a benchmark project to measure the performance of the library. 
You can find it in the `/benchmarks/` folder.

### Running Benchmarks

1. Navigate to the benchmark project:
  ```bash
   cd benchmarks/Smart.Throw.Benchmarks
  ```
2. Run the benchmarks using [BenchmarkDotNet](https://benchmarkdotnet.org/):
  ```bash
   dotnet run -c Release
  ```

## 📂 Project Structure

```
Smart.Throw/
├── src/
│   ├── Smart.Throw/              # Core library
├── benchmarks/                       
│   └── Smart.Throw.Benchmarks    # Benchmarks
├── tests/                       
│   └── Smart.Throw.Tests         # Unit tests
└── README.md                    # This file
```

## 🤝 Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## 📄 License

This project is licensed under the [MIT License](LICENSE).