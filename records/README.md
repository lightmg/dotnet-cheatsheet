# records 
- Добавлены в C# 9. 
- Под капотом `record` - `class`, для которого реализация `IEqutable`, `GetHashCode(), ToString()` генерируется компилятором
- Проверка на равенство - почленная: сравниваются свойства вместо сравнения ссылок по умолчанию
  - `new User("John") == new User("John")` вернёт `true`
- По умолчанию `record` является `class`. Начиная с C# 10 можно указать явно: `record class` или `record struct`
- Оператор `with` - копирование с переопределением некоторых свойств
- Позиционные `record` - сокращенное определение
  - Позиционные `record` по умолчанию immutable (свойства имеют accessors `get` и `init`, но не `set`)
  ```c#
  public record Point {
    public Point(int x, int y) {
      X = x;
      Y = y;
    }
  
    public int X { get; init; }
    public int Y { get; init; }
  }
  ```
  Равносильно
  ```c#
  public record Point(int X, int Y);
  ```
  
  ## Материалы
  - [C# Reference - MSDN \[EN\]](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
