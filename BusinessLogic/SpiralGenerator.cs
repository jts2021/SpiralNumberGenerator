using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SpiralGenerator
    {
        //private bool HandleElement()
        //{
        //    bool done = false;
        //    arr[x, y] = currentNumber;
        //    if (currentNumber == number) { done = true; break; }
        //    currentNumber++;

        //    return done;
        //}

        public bool IsNumberInteger(double number)
        {
            return (number % 1 == 0);
        }

        public bool IsDivisibleBy2(int number)
        {
            return (number % 2 == 0);
        }

        public int GetNextOddNumber(int number)
        {
            int result = number;

            if (IsDivisibleBy2(number))
            {
                result++;
            }
            else
            {
                result += 2;
            }
            return result;
        }


        public int CalculateGridSize(int inputNumber)
        {
            // Add one to the number to accomidate for the element containing 0.
            inputNumber = inputNumber + 1;

            int result;
            double squareRoot = Math.Sqrt(inputNumber);

            if (IsNumberInteger(squareRoot))
            {
                result = (int)squareRoot;
            }
            else
            {
                int integerPortion = (int)Math.Truncate(squareRoot);
                result = GetNextOddNumber(integerPortion);
            }

            return result;
        }

        public int CalculateCenterPoint(int gridSize)
        {
            return (gridSize / 2);
        }

        public int[,] Generate(int number)
        {
            int gridSize = CalculateGridSize(number);
            int centerPoint = CalculateCenterPoint(gridSize);

            bool done = false;
            int currentNumber = 0;
            int rightDownStepSize = 1;
            int leftUpStepSize = 2;

            int x = centerPoint;
            int y = centerPoint;
            

            int[,] arr = new int[gridSize, gridSize];


            //Target:
            //       0  1  2  3  4
            //          
            //  0   20 21 22 23 24
            //  1   19  6  7  8  9
            //  2   18  5  0  1 10
            //  3   17  4  3  2 11
            //  4   16 15 14 13 12


            while (!done)
            {
                //Go Right
                for (int i = 0; i < rightDownStepSize; i++)
                {
                    arr[x, y] = currentNumber;
                    if (currentNumber == number) { done = true; break; }
                    currentNumber++;

                    x++;

                }


                //Go Down
                for (int i = 0; i < rightDownStepSize; i++)
                {
                    arr[x, y] = currentNumber;
                    if (currentNumber == number) { done = true; break; }
                    currentNumber++;
                    y++;
                }


                //Go Left
                for (int i = 0; i < leftUpStepSize; i++)
                {
                    arr[x, y] = currentNumber;
                    if (currentNumber == number) { done = true; break; }
                    currentNumber++;
                    x--;
                }



                //Go Up
                for (int i = 0; i < leftUpStepSize; i++)
                {
                    arr[x, y] = currentNumber;
                    if (currentNumber == number) { done = true; break; }
                    currentNumber++;
                    y--;
                }

                rightDownStepSize += 2;
                leftUpStepSize += 2;
            }

            return arr;
        }
    }
}
