using System;

namespace Ex01_04
{
    class Program
    {
        private const uint k_InputStringLen = 10;

        public static void Main()
        {
            StringAnalysis();
        }
        public static void StringAnalysis()
        {
            string validInputString, PalindromeAnalysis, divisibleBy4Analysis, numOfLowercaseLettersAnalysis, analysisSummary;
            validInputString = getValidInputString();

            PalindromeAnalysis = getPalindromeAnalysis(validInputString);
            divisibleBy4Analysis = getNumberAnalysis(validInputString);
            numOfLowercaseLettersAnalysis = getEnglishStrAnalysis(validInputString);

            analysisSummary = string.Format(
                @"
Palindrome analysis: {0}.
Number analysis of the string: {1}.
English analysis of the string: {2}."
, PalindromeAnalysis, divisibleBy4Analysis, numOfLowercaseLettersAnalysis);

            Console.WriteLine(analysisSummary);
        }

        private static string getValidInputString()
        {
            string inputString, welcomeMessage = $"Please enter a string with {k_InputStringLen} characters consisting solely of either English alphabet letters or digits.";

            Console.WriteLine(welcomeMessage);
            inputString = Console.ReadLine();

            while (!isStringValid(inputString))
            {
                Console.Write("Invalid string ");
                Console.WriteLine(welcomeMessage);
                inputString = Console.ReadLine();
            }

            return inputString;
        }

        private static bool isStringValid(string i_string)
        {
            bool isNumber, isStringInEnglish, isStringOnlyLowerCase, isStringOnlyUpperCase, isStringValid;

            if (i_string.Length == k_InputStringLen) // If the length is valid
            {
                isNumber = isStringANumber(i_string);
                isStringInEnglish = IsStringInEnglish(i_string);
                isStringOnlyLowerCase = i_string == i_string.ToLower();
                isStringOnlyUpperCase = i_string == i_string.ToUpper();
                isStringValid = isNumber || (isStringInEnglish && (isStringOnlyLowerCase || isStringOnlyUpperCase));
            }
            else
                isStringValid = false;

            return isStringValid;
        }

        private static bool isStringANumber(string i_string)
        {
            int stringNumberValue;
            return int.TryParse(i_string, out stringNumberValue);
        }
        private static bool IsStringInEnglish(string i_String)
        {
            bool IsStringInEnglish = true;
            char currentChar;

            for (int i = 0; i < i_String.Length && IsStringInEnglish; i++)
            {
                currentChar = i_String[i];
                if ((currentChar < 'A' || currentChar > 'Z') && (currentChar < 'a' || currentChar > 'z') && !char.IsWhiteSpace(currentChar))
                {
                    IsStringInEnglish = false;
                }
            }

            return IsStringInEnglish;
        }

        private static void printArray(string[] i_Array)
        {
            for (int i = 0; i < i_Array.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(i_Array[i]);
            }
            Console.Write(Environment.NewLine);
        }

        private static string getPalindromeAnalysis(string i_ValidString)
        {
            return "dfafdsa";
        }

        private static string getNumberAnalysis(string i_ValidString)
        {
            return "dfafdsa";
        }

        private static string getEnglishStrAnalysis(string i_ValidString)
        {
            return "dfafdsa";
        }

    }
}
