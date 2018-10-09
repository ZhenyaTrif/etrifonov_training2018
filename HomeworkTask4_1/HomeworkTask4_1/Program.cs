using System;

namespace HomeworkTask4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            Factorial factorial = new Factorial(inputNumber);
            Console.Write("Факториал " + inputNumber + " = ");
            int[] resultNumber = factorial.GetResult();
            for(int i = 0; i < resultNumber.Length; i++)
            {
                Console.Write(resultNumber[i]);
            }
            Console.ReadKey();
        }
    }
}
