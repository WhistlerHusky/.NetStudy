using System;

namespace NetStudy.InDepth.NewLanguageFeatures
{
    public class RefLocalsAndReturns
    {
        private int[] _array = new int[10];

        public ref int ArrayValue(int index)
        {
            return ref _array[index];
        }

        public void Run()
        {
            Console.WriteLine($"_array[1] = {_array[1]}");
            ref var val = ref ArrayValue(1);
            val++;
            Console.WriteLine($"after val++ = _array[1] = {_array[1]}");
            val++;
            Console.WriteLine($"after val++ = _array[1] = {_array[1]}");
            _array[1]++;
            Console.WriteLine($"after _array[1]++ = val = {val}");
            _array[1]++;
            Console.WriteLine($"after _array[1]++ = val = {val}");

            Console.WriteLine($"_array[1] = {_array[1]}");
        }
    }
}