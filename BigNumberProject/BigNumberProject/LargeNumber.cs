using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumberProject
{
    class LargeNumber
    {
        private int[] Number { get; set; }
        private bool Negative { get; set; }

        public LargeNumber(LargeNumber inputNumber)
        {
            Number = inputNumber.Number;
            Negative = inputNumber.Negative;
        }
        public LargeNumber(string inputNumber)
        {
            Number = ConvertNumber(inputNumber);
        }
        public LargeNumber(long inputNumber)
        {
            Number = ConvertNumber(inputNumber);
        }
        public LargeNumber(int inputNumber)
        {
            Number = ConvertNumber(inputNumber);
        }
        public LargeNumber(byte inputNumber)
        {
            Number = ConvertNumber(inputNumber);
        }

        private int[] ConvertNumber(long inputNumber)
        {
            if (inputNumber < 0)
            {
                Negative = true;
            }
            else
            {
                Negative = false;
            }
            inputNumber = Math.Abs(inputNumber);
            List<int> numberToArray = new List<int>();
            string knowLenghtOfNumber = inputNumber.ToString();
            for (int i = 0; i < knowLenghtOfNumber.Length; i++)
            {
                numberToArray.Add(knowLenghtOfNumber[i] - 48);
            }
            return numberToArray.ToArray();
        }
        private int[] ConvertNumber(string inputNumber)
        {
            if (inputNumber[0] == '-')
            {
                Negative = true;
                string[] helpString = inputNumber.Split('-');
                inputNumber = helpString[1];
            }
            else
            {
                Negative = false;
            }
            List<int> numberToArray = new List<int>();
            for (int i = 0; i < inputNumber.Length; i++)
            {
                numberToArray.Add(inputNumber[i] - 48);
            }
            return numberToArray.ToArray();
        }

        public void Multiply(LargeNumber secondNum)
        {
            List<int> helpList = new List<int>();
            if ((Negative && secondNum.Negative) || (!Negative && !secondNum.Negative))
            {
                Negative = false;
            }else if((!Negative && secondNum.Negative) || (Negative && !secondNum.Negative))
            {
                Negative = true;
            }
            Array.Reverse(Number);
            for (int i = 0; i < secondNum.Number.Length; i++)
            {
                for (int j = 0; j < Number.Length; j++)
                {
                    if (i == 0)
                    {
                        helpList.Add(secondNum.Number[i] * Number[j]);
                    }
                    else
                    {
                        if (i + j >= helpList.Count)
                        {
                            helpList.Add(secondNum.Number[i] * Number[j]);
                        }
                        else
                        {
                            helpList[i + j] += secondNum.Number[i] * Number[j];
                        }
                    }
                }
            }
            Number = CutLargeValue(helpList).ToArray();
            Array.Reverse(Number);
        }
        public void Multiply(long secondNum)
        {
            this.Multiply(new LargeNumber(secondNum));
        }
        public void Multiply(int secondNum)
        {
            this.Multiply(new LargeNumber(secondNum));
        }
        public void Multiply(byte secondNum)
        {
            this.Multiply(new LargeNumber(secondNum));
        }
        public void Multiply(string secondNum)
        {
            this.Multiply(new LargeNumber(secondNum));
        }

        public void Add(LargeNumber secondNum)
        {
            int lengthOfLargest, smallestLength;
            bool ourNumSmaller;
            List<int> helpList = new List<int>();
            Array.Reverse(Number);
            if (Number.Length >= secondNum.Number.Length)
            {
                lengthOfLargest = Number.Length;
                smallestLength = secondNum.Number.Length;
                ourNumSmaller = false;
            }
            else
            {
                lengthOfLargest = secondNum.Number.Length;
                smallestLength = Number.Length;
                ourNumSmaller = true;
            }
            for (int i = 0; i < lengthOfLargest; i++)
            {
                if (i < smallestLength)
                {
                    helpList.Add(Number[i] + secondNum.Number[i]);
                }else if (ourNumSmaller)
                {
                    helpList.Add(secondNum.Number[i]);
                }else if (!ourNumSmaller)
                {
                    helpList.Add(Number[i]);
                }
            }
            Number = CutLargeValue(helpList).ToArray();
            Array.Reverse(Number);
        }
        public void Add(long secondNum)
        {
            this.Add(new LargeNumber(secondNum));
        }
        public void Add(int secondNum)
        {
            this.Add(new LargeNumber(secondNum));
        }
        public void Add(byte secondNum)
        {
            this.Add(new LargeNumber(secondNum));
        }
        public void Add(string secondNum)
        {
            this.Add(new LargeNumber(secondNum));
        }

        public void Substract(LargeNumber secondNum)
        {
            int lengthOfLargest = 0, smallestLength = 0;
            int ourNumSmaller = 0;
            List<int> helpList = new List<int>();
            Array.Reverse(Number);
            if(Number.Length == secondNum.Number.Length)
            {
                for(int i = Number.Length - 1; i >= 0; i--)
                {
                    if (CheckSmaller(secondNum.Number[i], Number[i]))
                    {
                        lengthOfLargest = Number.Length;
                        smallestLength = Number.Length;
                        ourNumSmaller = -1;
                        break;
                    }else if (CheckSmaller(Number[i], secondNum.Number[i]))
                    {
                        lengthOfLargest = Number.Length;
                        smallestLength = Number.Length;
                        ourNumSmaller = 1;
                        break;
                    }
                    if (i == 0)
                    {
                        Number = new int[] { 0 };
                        return;
                    }
                }
                if(ourNumSmaller == 1)
                {
                    for(int j = 0; j < lengthOfLargest; j++)
                    {
                        if(CheckSmaller(Number[j], secondNum.Number[j]))
                        {
                            Number[j] += 10;
                            Number[j + 1] = Number[j + 1] - 1;
                            helpList.Add(Number[j] - secondNum.Number[j]);
                        }
                        else
                        {
                            helpList.Add(Number[j] - secondNum.Number[j]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < lengthOfLargest; j++)
                    {
                        if (Number[j] <= secondNum.Number[j])
                        {
                            helpList.Add(secondNum.Number[j] - Number[j]);
                        }
                        else
                        {
                            secondNum.Number[j] += 10;
                            secondNum.Number[j + 1] -= 1;
                            helpList.Add(secondNum.Number[j] - Number[j]);
                        }
                    }
                }
                
            }else if(Number.Length > secondNum.Number.Length)
            {
                lengthOfLargest = Number.Length;
                smallestLength = secondNum.Number.Length;
                ourNumSmaller = -1;
                for (int j = 0; j < smallestLength; j++)
                {
                    if (Number[j] >= secondNum.Number[j])
                    {
                        helpList.Add(Number[j] - secondNum.Number[j]);
                    }
                    else
                    {
                        Number[j] += 10;
                        Number[j + 1] -= 1;
                        helpList.Add(Number[j] - secondNum.Number[j]);
                    }
                }
                for(int j = smallestLength; j < lengthOfLargest; j++)
                {
                    helpList.Add(Number[j]);
                }
            }
            else
            {
                lengthOfLargest = secondNum.Number.Length;
                smallestLength = Number.Length;
                ourNumSmaller = 1;
                for (int j = 0; j < smallestLength; j++)
                {
                    if (Number[j] <= secondNum.Number[j])
                    {
                        helpList.Add(secondNum.Number[j] - Number[j]);
                    }
                    else
                    {
                        secondNum.Number[j] += 10;
                        secondNum.Number[j + 1] -= 1;
                        helpList.Add(secondNum.Number[j] - Number[j]);
                    }
                }
                for (int j = smallestLength; j < lengthOfLargest; j++)
                {
                    helpList.Add(secondNum.Number[j]);
                }
            }

            Number = CutLargeValue(helpList).ToArray();
            Array.Reverse(Number);
        }
        public void Substract(long secondNum)
        {
            this.Substract(new LargeNumber(secondNum));
        }
        public void Substract(int secondNum)
        {
            this.Substract(new LargeNumber(secondNum));
        }
        public void Substract(byte secondNum)
        {
            this.Substract(new LargeNumber(secondNum));
        }
        public void Substract(string secondNum)
        {
            this.Substract(new LargeNumber(secondNum));
        }

        private bool CheckSmaller(int a, int b)
        {
            if (a < b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private List<int> CutLargeValue(List<int> list)
        {
            int toNext = 0;

            for (int i = 0; i < list.Count; i++)
            {
                toNext += list[i] / 10;
                list[i] %= 10;
                if (i + 1 >= list.Count && toNext != 0)
                {
                    list.Add(toNext);
                    toNext = 0;
                }
                else
                {
                    if (toNext == 0 && i + 1 >= list.Count)
                    {
                        break;
                    }
                    list[i + 1] += toNext;
                    toNext = 0;
                }
            }
            return list;
        }

        public string Value()
        {
            string value = "";
            if (Negative)
            {
                value += '-';
            }
            foreach (int item in Number)
            {
                value += item;
            }
            return value;
        }
    }
}
