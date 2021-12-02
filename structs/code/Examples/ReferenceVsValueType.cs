using System;

namespace Examples
{
    public static class ReferenceVsValueType
    {
        public static void Demo()
        {
            Console.WriteLine(nameof(ReferenceExample));
            ReferenceExample();

            Console.WriteLine(nameof(ValueExample));
            ValueExample();

            Console.WriteLine(nameof(BoxingExample));
            BoxingExample();
        }

        private static void ReferenceExample()
        {
            var c = new Class(0);
            Console.WriteLine($"N before: {c.N}"); // 0
            IncrementClass(c); // передаётся ссылка, изменяется тот же инстанс
            Console.WriteLine($"N after: {c.N}"); // 1
        }

        private static void ValueExample()
        {
            var s = new Struct(0);
            Console.WriteLine($"N before: {s.N}"); // 0
            IncrementStruct(s); // передаётся копия структуры, оригинальная остается без изменений
            Console.WriteLine($"N after: {s.N}"); // 0
        }

        private static void BoxingExample()
        {
            var s = new Struct(0);
            Console.WriteLine($"N source: {s.N}"); // 0
            IInterface i = s; // упаковка: структура копируется и помещается в heap
            IncrementInterface(i); // передали ссылку на упакованную структуру
            Console.WriteLine($"N source after: {s.N}"); // исходная без изменений
            Console.WriteLine($"N boxed after: {i.N}"); // упакованная передается по ссылке = ведёт себя как класс
        }

        private static void IncrementClass(Class c) => c.N++;

        private static void IncrementStruct(Struct c) => c.N++;

        private static void IncrementInterface(IInterface c) => c.N++;

        private class Class
        {
            public Class(int n) => N = n;
            public int N { get; set; }
        }

        private struct Struct : IInterface
        {
            public Struct(int n) => N = n;
            public int N { get; set; }
        }

        private interface IInterface
        {
            int N { get; set; }
        }
    }
}