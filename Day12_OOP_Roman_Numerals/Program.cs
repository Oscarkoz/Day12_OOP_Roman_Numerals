﻿using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day12_OOP_Roman_Numerals
{
    internal class Program
    {
        //INPUT
          //Check correct input (IF STATEMENTS)
          //>Check if it's a string
          //Check Uppercase
          //>Check if it's a rom number

        //->Calculate rom number to decimal-format


        //OUTPUT
        static void Main(string[] args)
        {
            bool prgmRun = true;

            while(prgmRun)
            {
                string ErrorMessage = ""; //Variabel to store, error messages

                //Array: Numbers & Roman numbers
                int[] values = { 1000, 500, 100, 50, 10, 5, 1 };
                char[] symbols = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

                // INPUT----------------
                Console.Write("Enter 'Roman Number': ");
                string input = Console.ReadLine();

                // Regex into variabel. Usage: to controll if input is valid with roman number,and special rules
                string romanPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

                //If statements: Uppercase?, Valid roman number?
                if (input != input.ToUpper())
                {
                    ErrorMessage = "Input needs to be uppercase letters";
                    Console.WriteLine(ErrorMessage);
                    
                }
                else if (!Regex.IsMatch(input, romanPattern)) // COmpares, if Input is not a roman number
                {
                    ErrorMessage = "Input is not a valid Roman number";
                    Console.WriteLine(ErrorMessage);
                    return;
                }//----------------
                else // Converts input to number
                {

                    int total = 0;//Variables, to store the rom number as a value
                    int previousValue = 0; //To handle roman substraction

                    for (int i = 0; i < input.Length; i++)
                    {
                        char currentSymbol = input[i]; // STring is an array of char, so we can sepereate each element in input
                        int currentValue = 0;

                        //Loop, to check in symbol array 
                        for (int j = 0; j < symbols.Length; j++)
                        {
                            if (currentSymbol == symbols[j])
                            {
                                currentValue = values[j];// Roman number value adds into variable
                                break;
                            }
                        }

                        // If the roman number is for example IV, it will handle the calculation to correct value
                        if (currentValue > previousValue)
                        {
                            total += currentValue - 2 * previousValue;
                        }
                        else
                        {
                            total += currentValue;
                        }

                        previousValue = currentValue; // Update previous value for next iteration
                    }

                    //Decimal convert
                    decimal decimalResult = Convert.ToDecimal(total);

                    Console.WriteLine($"Roman number {input} " +
                        $"\nDecimal: {decimalResult:F2}");

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
       
                }//End if-statements

                //Controlls if player wants to play again-------------------------------s
                int selectedIndex = 0;
                string[] options = { "Yes", "No" };
                ConsoleKey key;//reads pressed key, declares into key as variable
                do
                {
                    Console.Clear();

                    Console.WriteLine("Do you want to play again?");

                    for (int i = 0; i < options.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; //Highlight
                            Console.Write("->");//Marker

                        }
                        else
                        {
                            Console.Write(" ");//Make sure the other option is not selected
                        }
                        Console.WriteLine(options[i]);
                        Console.ResetColor();//Resets color after highlgihted
                    }
                    key = Console.ReadKey(true).Key;//user key declares into variable

                    //If-statements: Controlls which arrow
                    if (key == ConsoleKey.UpArrow)
                    {
                        selectedIndex--; //Moves marker up, which means goes back in array index exempel []: 0, 1
                        if (selectedIndex < 0)
                        {
                            selectedIndex = options.Length - 1; //if user moves up too much, which is out of the array range. It will go back because 2-1 = 1. 1= option 'no'

                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        selectedIndex++; //Moves marker up, basically goes right side of array element --> 0 , 1. Right side is '1'
                        if (selectedIndex >= options.Length) //controlls the users navigation so it doesnt go outside of the array length
                        {
                            selectedIndex = 0;
                        }
                    }

                }
                while (key != ConsoleKey.Enter); //Loops until user press 'Enter'

                Console.WriteLine("You selected " + options[selectedIndex]);

                if (options[selectedIndex] == "No")
                {
                    prgmRun = false;
                }
                else
                {
                    prgmRun = true;
                }
                

            }//End of while
        }
    }
}
    