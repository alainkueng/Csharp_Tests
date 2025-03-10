
# LINQ Super Cheat Sheet (C#)

This cheat sheet gives you a powerful overview of **LINQ (Language Integrated Query)** in C#.  
Includes method description, syntax, and **example output**.

---

## General LINQ Structure

```csharp
var result = collection
    .Where(x => x.Property == value)
    .OrderBy(x => x.OtherProperty)
    .Select(x => new { x.Name, x.Age })
    .ToList();
```

LINQ is usually **chained in method syntax** using dot notation. This is the most common style in C# projects.

---

## LINQ Methods Overview

| Method             | Description                                      | Example | Example Output |
|--------------------|--------------------------------------------------|---------|------------------|
| `Where`            | Filters elements based on a condition             | `people.Where(p => p.Age > 30)` | `[{Name="Alice", Age=35}]` |
| `Select`           | Projects/transforms each element                  | `people.Select(p => p.Name)` | `["Alice", "Bob"]` |
| `SelectMany`       | Flattens nested collections                       | `teams.SelectMany(t => t.Players)` | `["Tom", "Jerry", "Lisa"]` |
| `OrderBy`          | Sorts ascending                                   | `people.OrderBy(p => p.Name)` | `[{Name="Alice"}, {Name="Bob"}]` |
| `OrderByDescending`| Sorts descending                                  | `people.OrderByDescending(p => p.Age)` | `[{Age=40}, {Age=30}]` |
| `ThenBy`           | Secondary ascending sort                          | `people.OrderBy(p => p.City).ThenBy(p => p.Age)` | `[{City="Berlin", Age=30}, {City="Berlin", Age=40}]` |
| `ThenByDescending` | Secondary descending sort                         | `people.OrderBy(p => p.City).ThenByDescending(p => p.Age)` | `[{City="Berlin", Age=40}, {City="Berlin", Age=30}]` |
| `GroupBy`          | Groups elements by key                            | `people.GroupBy(p => p.City)` | `{"Berlin": [...], "Paris": [...]}` |
| `ToList`           | Converts to `List<T>`                             | `people.ToList()` | `[Person, Person]` |
| `ToArray`          | Converts to array                                 | `people.ToArray()` | `[Person, Person]` |
| `ToDictionary`     | Converts to dictionary                            | `people.ToDictionary(p => p.Id)` | `{1: Person, 2: Person}` |
| `First`            | First element, throws if empty                    | `people.First()` | `{Name="Alice"}` |
| `FirstOrDefault`   | First element or `default`                        | `people.FirstOrDefault()` | `{Name="Alice"}` or `null` |
| `Single`           | Exactly one element, throws if more/none          | `people.Single(p => p.Id == 1)` | `{Name="Alice"}` |
| `SingleOrDefault`  | One or `default`, throws if more                  | `people.SingleOrDefault(p => p.Id == 1)` | `{Name="Alice"}` or `null` |
| `Last`             | Last element, throws if empty                     | `people.Last()` | `{Name="Zoe"}` |
| `LastOrDefault`    | Last or `default`                                 | `people.LastOrDefault()` | `{Name="Zoe"}` or `null` |
| `Any`              | Returns true if any element matches               | `people.Any(p => p.Age > 40)` | `true` or `false` |
| `All`              | Returns true if all elements match                | `people.All(p => p.Age >= 18)` | `true` or `false` |
| `Count`            | Counts elements                                   | `people.Count()` | `5` |
| `Sum`              | Sums values                                       | `people.Sum(p => p.Age)` | `157` |
| `Min`              | Minimum value                                     | `people.Min(p => p.Age)` | `19` |
| `Max`              | Maximum value                                     | `people.Max(p => p.Age)` | `65` |
| `Average`          | Average value                                     | `people.Average(p => p.Age)` | `31.4` |
| `Distinct`         | Removes duplicates                                | `numbers.Distinct()` | `[1, 2, 3]` |
| `DistinctBy`       | Distinct by key *(C# 6+)*                         | `people.DistinctBy(p => p.City)` | `[{City="Berlin"}, {City="Paris"}]` |
| `Union`            | Combines two collections without duplicates       | `list1.Union(list2)` | `[1, 2, 3, 4]` |
| `Intersect`        | Common elements                                   | `list1.Intersect(list2)` | `[2, 3]` |
| `Except`           | Elements in one but not in other                  | `list1.Except(list2)` | `[1]` |
| `Take`             | Takes first N elements                            | `people.Take(2)` | `[{Name="Alice"}, {Name="Bob"}]` |
| `Skip`             | Skips first N elements                            | `people.Skip(2)` | `[...rest]` |
| `TakeWhile`        | Takes while condition is true                     | `people.TakeWhile(p => p.Age < 40)` | `[Younger People]` |
| `SkipWhile`        | Skips while condition is true                     | `people.SkipWhile(p => p.Age < 40)` | `[Older People]` |
| `Reverse`          | Reverses order                                    | `people.Reverse()` | `[Zoe, Bob, Alice]` |
| `Zip`              | Merges two collections by index                   | `names.Zip(ages, (n, a) => new {n, a})` | `[{n="Alice", a=30}, {n="Bob", a=40}]` |
| `Append`           | Adds element at end                               | `people.Append(newPerson)` | `[..., NewPerson]` |
| `Prepend`          | Adds element at beginning                         | `people.Prepend(newPerson)` | `[NewPerson, ...]` |
| `OfType<T>()`      | Filters by type                                   | `mixed.OfType<string>()` | `["hello", "world"]` |
| `Cast<T>()`        | Casts all elements                                | `objects.Cast<string>()` | `["A", "B", "C"]` |
| `Join`             | Inner join on keys                                | `people.Join(cities, p => p.CityId, c => c.Id, (p, c) => ...)` | `[{PersonName, CityName}]` |
| `GroupJoin`        | Left join grouped                                 | `cities.GroupJoin(people, c => c.Id, p => p.CityId, ...)` | `{CityA: [Persons], CityB: [Persons]}` |
| `Chunk`            | Splits into chunks *(C# 8+)*                      | `numbers.Chunk(2)` | `[[1,2],[3,4]]` |
| `Concat`           | Concatenates sequences                            | `list1.Concat(list2)` | `[1, 2, 3, 4]` |
| `Aggregate`        | Accumulates value                                 | `numbers.Aggregate((a, b) => a + b)` | `10` |
| `SequenceEqual`    | Checks if sequences are equal                     | `list1.SequenceEqual(list2)` | `true` / `false` |

---


## 📚 **String Methods**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `.Contains()`         | Checks if a string contains another        | `"hello".Contains("he") → true` |
| `.StartsWith()`       | Checks if a string starts with a value     | `"world".StartsWith("w") → true` |
| `.EndsWith()`         | Checks if a string ends with a value       | `"file.txt".EndsWith(".txt") → true` |
| `.Substring()`        | Extracts part of a string                  | `"hello".Substring(1, 2) → "el"` |
| `.Replace()`          | Replaces characters                        | `"cat".Replace("c", "b") → "bat"` |
| `.ToLower()` / `.ToUpper()` | Changes casing                        | `"Hi".ToLower() → "hi"` |
| `string.IsNullOrEmpty()` | Checks for null or empty string           | `true / false` |
| `string.IsNullOrWhiteSpace()` | Checks for null or whitespace         | `true / false` |

## 📚 **Collection Methods**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `.Add()` / `.Remove()` | Add or remove elements from List           | `list.Add("a")` |
| `.Contains()`          | Checks if element exists                   | `list.Contains("a")` |
| `.IndexOf()`           | Finds index of an element                  | `list.IndexOf("a")` |
| `.Clear()`             | Empties the list                           | `list.Clear()` |
| `.Count`               | Number of elements                         | `list.Count → 5` |

## 📚 **Object & Null Safety Methods**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `?.` (null-conditional) | Avoid null reference exceptions           | `obj?.Property` |
| `??` (null-coalescing)  | Provide default if null                    | `name ?? "Unknown"` |
| `??=` (null-coalescing assignment) | Assign if null                       | `name ??= "Default"` |

## 📚 **DateTime Methods**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `DateTime.Now`         | Gets the current time                      | `DateTime.Now` |
| `AddDays()`, `AddHours()` | Adds time to the current time             | `now.AddDays(1)` |
| `.ToString("format")`  | Custom formatting of DateTime              | `now.ToString("yyyy-MM-dd")` |

## 📚 **Type Conversion Methods**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `int.Parse()`, `double.Parse()` | Converts string to number             | `int.Parse("5")` |
| `TryParse()`           | Safe conversion                            | `int.TryParse(str, out int result)` |
| `.ToString()`          | Converts to string                         | `5.ToString()` |

## 📚 **Math Methods**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `Math.Round()`         | Rounds decimal values                      | `Math.Round(3.1415, 2) → 3.14` |
| `Math.Floor()`, `Ceiling()` | Floor or ceiling values                | `Math.Floor(2.9) → 2` |
| `Math.Abs()`           | Absolute value                             | `Math.Abs(-5) → 5` |
| `Math.Max()` / `Min()` | Max/min values                             | `Math.Max(3,4) → 4` |

## 📚 **File I/O Methods**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `File.ReadAllText()`   | Reads file content                         | `File.ReadAllText("data.txt")` |
| `File.WriteAllText()`  | Writes text to file                        | `File.WriteAllText("out.txt", "Hello")` |

## 📚 **Loops & Control Structures**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `foreach`             | Loop through collection                    | `foreach(var item in list)` |
| `if/else`, `switch`    | Conditional statements                      | `if (x > 10) { ... }` |

## 📚 **Exception Handling**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `try/catch/finally`    | Handle errors                              | `try { ... } catch (Exception e)` |

## 📚 **Object-Oriented Programming Features**
| Method/Feature        | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `class`, `interface`, `inheritance`, `override`, `virtual` | OOP structure | - |
| `public`, `private`, `protected` | Access modifiers                    | - |
| `static`              | Belongs to class, not instance             | `static void Main()` |

## 📚 **Async Programming**
| Method                | Description                                | Example |
|-----------------------|--------------------------------------------|---------|
| `async/await`         | Asynchronous programming                   | `await DoSomethingAsync()` |
| `Task<T>`             | Return future value                        | `Task<string>` |

## Boiler Code

```csharp
// dotnet add package Dumpify
using Dumpify;
using System.Text.Json;

class Program
{
    static void Main()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        string json = File.ReadAllText("people.json");
        List<Person> people = JsonSerializer.Deserialize<List<Person>>(json, options);

        var result = people.Where(x => x.city?.StartsWith("A") ?? false).Select(x => x.city);
        result.Dump();
    }

}

public class Person
{
    public string? Name { get; set; }
    public string? Email { get; set; } 
    public string? city {get;set;}
}

public interface IDriveable
{
    void Start();
    void Stop();
}
public class Car : IDriveable{}

public abstract class Animal
{
    // Abstract method (does not have implementation)
    public abstract void MakeSound();

    // Concrete method (with implementation)
    public void Eat()
    {
        Console.WriteLine("This animal is eating.");
    }
}
public class Dog : Animal
{
    // Implementation of the abstract method
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
}
