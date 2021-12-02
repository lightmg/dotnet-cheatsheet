# dotnet-cheatsheet
## Содержимое
- [structs](./structs)
- [records](./records)

## Полезные ресурсы
- https://sharplab.io - онлайн-песочница
  - Поддерживает декомпиляцию в IL и ASM
  - Есть реверсивная декомпиляция (C# -> IL -> C#) - полезно чтобы в читаемом виде посмотреть генерируемый компилятором код
  - Умеет рисовать граф памяти (метод [`Inspect.MemoryGraph(root)`](https://github.com/ashmind/SharpLab/blob/main/source/Runtime/Inspect.cs))