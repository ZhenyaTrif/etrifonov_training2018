using System;
using System.Collections.Generic;

namespace HomeworkTask4_1
{
    class Factorial
    {
        public int[] result;

        public Factorial(int number)
        {
            result = CalcFactorial(number);
        }

        private int[] CalcFactorial(int number)
        {
            int[] factorial = new int[1] { 1 };
            for (int i = 1; i <= number; i++)
            {
                factorial = CalcMultiply(factorial, ConvertNumber(i));
            }
            List<int> nowFactorial = new List<int>();
            for (int i = 0; i < factorial.Length; i++)
            {
                if (nowFactorial.Count != 0 | factorial[i] != 0)
                {
                    nowFactorial.Add(factorial[i]);
                }
            }
            return nowFactorial.ToArray();
        }

        private int[] ConvertNumber(int number)
        {
            List<int> numberToArray = new List<int>();
            string knowLenghtOfNumber = number.ToString();
            for (int i = 0; i < knowLenghtOfNumber.Length; i++)
            {
                numberToArray.Add(Convert.ToInt32(knowLenghtOfNumber[i].ToString()));
            }
            return numberToArray.ToArray();
        }

        private int[] CalcMultiply(int[] number1, int[] number2)
        {
            int[][] sums = new int[number2.Length][];
            int[] resultNumber = new int[number1.Length + number2.Length];
            resultNumber[0] = 0;
            for (int i = 0; i < number2.Length; i++)
            {
                sums[i] = new int[number1.Length];
                for (int j = 0; j < number1.Length; j++)
                {
                    sums[i][j] = number1[j] * number2[i];
                }
            }
            for (int i = 0; i < number2.Length; i++)
            {
                for (int j = 0; j < number1.Length; j++)
                {
                    resultNumber[i + j + 1] += sums[i][j];
                }
            }
            while (!CheckNumber(resultNumber))
            {
                for (int i = 0; i < resultNumber.Length - 1; i++)
                {
                    resultNumber[i] += resultNumber[i + 1] / 10;
                    resultNumber[i + 1] -= (resultNumber[i + 1] / 10) * 10;
                }
            }
            return resultNumber;
        }

        private bool CheckNumber(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] / 10 != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int[] GetResult()
        {
            return result;
        }
    }
}
