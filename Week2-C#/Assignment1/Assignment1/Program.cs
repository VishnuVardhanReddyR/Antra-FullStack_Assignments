﻿using Exercise03;
namespace Assignment1;
using System.Numerics;

using System.Drawing;
class Program
{
    static void Main(string[] args)
    {
        /*
         * Using just the ReadLine and WriteLine methods and your current knowledge of variables,
           you can have the user pass in quite a few bits of information. Using this approach, create a
           console application that asks the user a few questions and then generates some custom
           output for them. For instance, your program could generate their "hacker name" by asking
           them their favorite color, their astrology sign, and their street address number. The result
           might be something like "Your hacker name is RedGemini480."
         */
        // #### Generating HackerName #####
        // generateHackerName();
        // UnderstandingTypes.memory();
        // Console.WriteLine("Enter Number of Centuries: ");
        // UnderstandingTypes.getDetailsOfCenturies(BigInteger.Parse(Console.ReadLine()));
        // ExerciseThree.getFizzBuzz();
        // ExerciseThree.GuessingGame();
        // ExerciseThree.printPyramid();
        // ExerciseThree.printAge();
        // ExerciseThree.greetings();
        // ExerciseThree.incrementalCounting();
        // ArraysAndStrings.cpyArray();
        // int[] primeNumbers = ArraysAndStrings.FindPrimesInRange(1, 10);
        // for(int i = 0; i < primeNumbers.Length; i++)
        // {
        //     Console.WriteLine(primeNumbers[i]);
        // }
        // ArraysAndStrings.arrayRotation();
        // ArraysAndStrings.longestSeq();
        // ArraysAndStrings.mostFrequent();
        // ArraysAndStrings.stringToChar();
        // ArraysAndStrings.backDirection();
        
        // string sentence = "C# is not C++, and PHP is not Delphi!";
        // Console.WriteLine("Original sentence: " + sentence);
        // Console.WriteLine("Reversed sentence: " + ArraysAndStrings.reverseWords(sentence));
        
        // string text = "Hi,exe? ABBA! Hog fully a string: ExE. Bob\na, ABBA, exe, ExE\n";
        // Console.WriteLine("Original text: " + text);
        // var palindromes = ArraysAndStrings.extractPalindromes(text);
        // Console.WriteLine("Palindromes: " + string.Join(", ", palindromes));
        
        ArraysAndStrings.parseURL();
    }
    public static void generateHackerName()
    {
        Console.WriteLine("Provide the following information to generate your Hacker Name: ");
        Console.WriteLine("What's Your Favourite Color? ");
        String color = Console.ReadLine();
        Console.WriteLine("What's your astrology sign? ");
        String astroSign = Console.ReadLine();
        Console.WriteLine("What's your Street Address? ");
        String address = Console.ReadLine();

        string hackerName = $"{color}{astroSign}{address}";
        Console.WriteLine($"Your HackerName is: {hackerName}");
    }
}