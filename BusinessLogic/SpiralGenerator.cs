using System;

namespace BusinessLogic
{
    public class SpiralGenerator
    {
        #region Private functions
        private bool IsNumberInteger(double number)
        {
            // If the remainder is 0 dividing by 1 then the number is an integer.
            return (number % 1 == 0);
        }

        private bool IsDivisibleBy2(int number)
        {            
            return (number % 2 == 0);
        }

        private int GetNextOddNumber(int number)
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

        private int CalculateGridSize(int inputNumber)
        {
            //NOTE:  The grid needs to be square.
            //       It also needs to have an odd number of elements in each dimmension so the 0 element will always be at the center.

            // Add one to the number to accomodate for the element containing 0.
            inputNumber = inputNumber + 1;

            int result;

            // The Square Root will roughly tell the needed dimmension of the array.
            double squareRoot = Math.Sqrt(inputNumber);


            if (IsNumberInteger(squareRoot))
            {
                if (IsDivisibleBy2((int)squareRoot))
                {
                    // If the square root is divisible by 2 then it is even and we need it to be odd.  
                    // Get the next odd number...
                    result = GetNextOddNumber((int)squareRoot);
                }
                else
                {
                    result = (int)squareRoot;
                }
            }
            else
            {
                // Remove the decimal portion of the square root and get the next odd number.
                int integerPortion = (int)Math.Truncate(squareRoot);
                result = GetNextOddNumber(integerPortion);
            }

            return result;
        }

        private int CalculateCenterPoint(int gridSize)
        {
            // Since the grid dimensions are always odd then dividing by 2 will get the center point.
            return (gridSize / 2);
        }
        #endregion Private functions

        public int?[,] Generate(int number)
        {
            // Ignore negative numbers by taking the absolute value.
            number = Math.Abs(number);

            int gridSize = CalculateGridSize(number);
            int centerPoint = CalculateCenterPoint(gridSize);

            bool done = false;
            int currentNumber = 0;

            //These two variables are used to store the current size of the current side of the spiral.
            int rightDownStepSize = 1;
            int leftUpStepSize = 2;

            int x = centerPoint;
            int y = centerPoint;            

            // The spiral is stored in an array.
            int?[,] arr = new int?[gridSize, gridSize];

            // Loop until the number has been reached.  
            // The data is written from the center point out.
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

                // The next legs of the spiral have 2 more elements.
                rightDownStepSize += 2;
                leftUpStepSize += 2;
            }

            return arr;
        }
    }
}
