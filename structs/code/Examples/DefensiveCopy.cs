using System;

namespace Examples
{
    public static class DefensiveCopy
    {
        public static void Demo()
        {
            var nsp = new NumberSequenceProvider(new Holder(5));
            nsp.GetNextInt();
            nsp.GetNextInt();
            Console.WriteLine(nsp.GetNextInt());
        }

        private class NumberSequenceProvider
        {
            private readonly Holder _holder;

            public NumberSequenceProvider(Holder holder)
            {
                _holder = holder;
            }

            public int GetNextInt()
            {
                // здесь создается defensive copy т.к. Integer - mutable struct, а поле _integer - readonly
                return _holder.Next; 
            }
        }

        private struct Holder
        {
            private int _current;
            public int Next => _current++;

            public Holder(int n)
            {
                _current = n;
            }
        }
    }
}