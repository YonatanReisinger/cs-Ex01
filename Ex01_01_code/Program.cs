using System;
using System.Text;

namespace Ex01_01
{
    class Program
    {
        private const int k_NumOfInputNumbers = 3;
        private const int k_BinarySeriesLength = 9;

        public static void Main()
        {
            BinarySeries();
        }
        public static void BinarySeries()
        {
            string[] binaryStringsArray = getBinarySeriesFromUser();
            uint[] binarySeriesDecimalValues = getBinarySeriesDecimalValues(binaryStringsArray);

            Array.Sort(binarySeriesDecimalValues);
            Console.Write("The numbers in ascending manner are:");
            printArray(binarySeriesDecimalValues);
            printStatisticsOfNumbers(binarySeriesDecimalValues, binaryStringsArray);
        }
        private static string[] getBinarySeriesFromUser()
        {
            string[] binaryNumbers = new string[k_NumOfInputNumbers];
            int validCount = 0;
            string userInput;
            
            Console.WriteLine($"Please enter {k_NumOfInputNumbers} binary numbers of {k_BinarySeriesLength} digits each:");

            while (validCount < k_NumOfInputNumbers)
            {
                userInput = Console.ReadLine();

                if (userInput.Length == k_BinarySeriesLength && isInputValid(userInput))
                {
                    binaryNumbers[validCount] = userInput;
                    validCount++;
                }
                else
                {
                    Console.WriteLine("Invalid binary number. Please enter a positive binary number of 9 digits.");
                }
            }

            return binaryNumbers;
        }

        private static bool isInputValid(string i_userInput)
        {
            bool isBinaryNum = true, isPositiveNum = false;

            for (int i = 0; i < i_userInput.Length && isBinaryNum; i++)
            {
                if (i_userInput[i] != '0' && i_userInput[i] != '1')
                {
                    isBinaryNum = false;
                }
                else if(i_userInput[i] == '1')
                {
                    isPositiveNum = true;
                }
            }
            
            return isBinaryNum && isPositiveNum;
        }

        private static uint[] getBinarySeriesDecimalValues(string[] i_binaryStringsArray)
        {
            uint[] decimalValues = new uint[i_binaryStringsArray.Length];

            for (int i = 0; i < i_binaryStringsArray.Length; i++)
            {
                decimalValues[i] = Convert.ToUInt32(i_binaryStringsArray[i], 2);
            }

            return decimalValues;
        }

        private static void printArray(uint[] i_array)
        {
            for (int i = 0; i < i_array.Length; i++)
            {
                Console.Write(" ");
                Console.Write(i_array[i]);
            }
            Console.Write(Environment.NewLine);
        }

        private static void printStatisticsOfNumbers(uint[] i_array, string [] i_binaryStringsArray)
        {
            uint[] zerosInBinaryStringCounters = new uint[i_binaryStringsArray.Length], onesInBinaryStringCounters = new uint[i_binaryStringsArray.Length];
            uint powerOfTwoNumbersCounter, ascendingSeriesNumberCounter = 0;
            float averageNumOfZeros, averageNumOfOnes;
            string statistics;

            CountZerosAndOnesInBinaryNumsArray(i_binaryStringsArray, zerosInBinaryStringCounters, onesInBinaryStringCounters);
            averageNumOfZeros = (float)SumArray(zerosInBinaryStringCounters) / (float)i_binaryStringsArray.Length;
            averageNumOfOnes = (float)SumArray(onesInBinaryStringCounters) / (float)i_binaryStringsArray.Length;
            powerOfTwoNumbersCounter = countPowerOfTwoNumbers(onesInBinaryStringCounters);
            ascendingSeriesNumberCounter = countAscendingSeriesNumbers(i_array);
            statistics = string.Format(
                @"The average number of zeros in the binary number is {0}.
The average number of ones in the binary number is {1}.
There are {2} numbers which are a power of 2.
There are {3} numbers which their decimal digits are an ascending series
The largest number is {4} and the smallest is {5}", averageNumOfZeros, averageNumOfOnes, powerOfTwoNumbersCounter, ascendingSeriesNumberCounter, i_array[i_array.Length - 1], i_array[0]);
            Console.WriteLine(statistics);
        }

        private static void CountZerosAndOnesInBinaryNumsArray(string[] i_binaryStringsArray, uint[] io_ZerosInBinaryStringCounters, uint[] io_OnesInBinaryStringCounters)
        {
            uint currentBinaryStringZerosCounter, currentBinaryStringOnesCounter;

            for (int i = 0; i < i_binaryStringsArray.Length; i++)
            {
                currentBinaryStringZerosCounter = currentBinaryStringOnesCounter = 0;
                CountZerosAndOnesInBinarySeries(i_binaryStringsArray[i], ref currentBinaryStringZerosCounter, ref currentBinaryStringOnesCounter);
                io_ZerosInBinaryStringCounters[i] = currentBinaryStringZerosCounter;
                io_OnesInBinaryStringCounters[i] = currentBinaryStringOnesCounter;
            }
        }

        private static void CountZerosAndOnesInBinarySeries(string i_binaryString, ref uint io_zerosCounter, ref uint io_onesCounter)
        {
            foreach (char digit in i_binaryString)
            {
                if (digit == '0')
                {
                    io_zerosCounter++;
                }
                else if (digit == '1')
                {
                    io_onesCounter++;
                }
            }
        }

        private static uint SumArray(uint[] i_array)
        {
            uint total = 0;
            foreach (uint num in i_array)
            {
                total += num;
            }
            return total;
        }

        private static uint countPowerOfTwoNumbers(uint[] i_onesInBinaryStringCounters)
        {
            uint powerOfTwoNumbersCounter = 0;

            foreach(uint numOfOnes in i_onesInBinaryStringCounters)
            {
                if (numOfOnes == 1)
                    powerOfTwoNumbersCounter++;
            }

            return powerOfTwoNumbersCounter;
        }

        private static uint countAscendingSeriesNumbers(uint[] i_numbers)
        {
            uint count = 0;

            foreach (uint num in i_numbers)
            {
                if (isDigitsAnAscendingSeries(num))
                {
                    count++;
                }
            }

            return count;
        }

        private static bool isDigitsAnAscendingSeries(uint i_number)
        {
            string numberString = i_number.ToString();
            bool isDigitsAnAscendingSeries = true;

            for (int i = 1; i < numberString.Length && isDigitsAnAscendingSeries; i++)
            {
                if (numberString[i] <= numberString[i - 1])
                {
                    isDigitsAnAscendingSeries = false;
                }
            }

            return isDigitsAnAscendingSeries;
        }
    }


}
