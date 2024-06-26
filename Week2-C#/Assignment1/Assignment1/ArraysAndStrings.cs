namespace Assignment1;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class ArraysAndStrings
{
    /*
     * Copying an Array
       Write code to create a copy of an array. First, start by creating an initial array. (You can use
       whatever type of data you want.) Let’s start with 10 items. Declare an array variable and
       assign it a new array with 10 items in it. Use the things we’ve discussed to put some values
       in the array.
       Now create a second array variable. Give it a new array with the same length as the first.
       Instead of using a number for this length, use the Lengthproperty to get the size of the
       original array.
       Use a loop to read values from the original array and place them in the new array. Also
       print out the contents of both arrays, to be sure everything copied correctly.
     */
    public static void cpyArray()
    {
        int[] originalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Create a second array with the same length as the original
        int[] copiedArray = new int[originalArray.Length];

        // Use a loop to copy values from the original array to the new array
        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }

        // Print out the contents of the original array
        Console.WriteLine("Original Array:");
        foreach (int value in originalArray)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine(); // Newline for readability

        // Print out the contents of the copied array
        Console.WriteLine("Copied Array:");
        foreach (int value in copiedArray)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine(); // Newline for readability
    }
    
    /*
     * Write a simple program that lets the user manage a list of elements. It can be a grocery list,
       "to do" list, etc. Refer to Looping Based on a Logical Expression if necessary to see how to
       implement an infinite loop. Each time through the loop, ask the user to perform an
       operation, and then show the current contents of their list. The operations available should
       be Add, Remove, and Clear. The syntax should be as follows:
       + some item
       - some item
       --
       Your program should read in the user's input and determine if it begins with a “+” or “-“ or
       if it is simply “—“ . In the first two cases, your program should add or remove the string
       given ("some item" in the example). If the user enters just “—“ then the program should
       clear the current list. Your program can start each iteration through its loop with the
       following instruction:
       Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
     */
    public static void listManager()
    {
        List<string> itemList = new List<string>();
        string userInput;
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("Enter command (+ item, - item, -- to clear, exit to quit):");
            userInput = Console.ReadLine();

            if (userInput.StartsWith("+"))
            {
                // Add item to the list (remove the '+' and trim whitespace)
                itemList.Add(userInput.Substring(1).Trim());
            }
            else if (userInput.StartsWith("-"))
            {
                // Remove item from the list (remove the '-' and trim whitespace)
                string itemToRemove = userInput.Substring(1).Trim();
                if (itemList.Contains(itemToRemove))
                {
                    itemList.Remove(itemToRemove);
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
            else if (userInput == "--")
            {
                // Clear the list
                itemList.Clear();
            }
            else if (userInput.ToLower() == "exit")
            {
                // Exit the program
                exitProgram = true;
                continue;
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }

            // Display the current list
            Console.WriteLine("Current list:");
            foreach (string item in itemList)
            {
                Console.WriteLine(item);
            }
        }
    }
    
    /*
     * Write a method that calculates all prime numbers in given range and returns them as array
       of integers
       static int[] FindPrimesInRange(startNum, endNum)
       {
       }
     */

    public static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primesList = new List<int>();

        for (int num = startNum; num <= endNum; num++)
        {
            if (IsPrime(num))
            {
                primesList.Add(num);
            }
        }

        return primesList.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
    
    /*
     * Write a program to read an array of n integers (space separated on a single line) and an
       integer k, rotate the array right k times and sum the obtained arrays after each rotation as
       shown below.
       After r rotations the element at position I goes to position (I + r) % n.
       The sum[] array can be calculated by two nested loops: for r = 1 ... k; for I = 0 ... n-1.
     */
    public static void arrayRotation()
    {
        Console.WriteLine("Enter n integers (space-separated):");
        int[] originalArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine("Enter the number of rotations k:");
        int k = int.Parse(Console.ReadLine());

        int[] sumArray = new int[originalArray.Length];
        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = RotateArray(originalArray, r);
            for (int i = 0; i < originalArray.Length; i++)
            {
                sumArray[i] += rotatedArray[i];
            }
        }

        Console.WriteLine("Sum array after rotations:");
        Console.WriteLine(string.Join(" ", sumArray));
    }

    static int[] RotateArray(int[] array, int rotations)
    {
        int n = array.Length;
        int[] rotatedArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            rotatedArray[(i + rotations) % n] = array[i];
        }
        return rotatedArray;
    }
    
    /*
     * Write a program that finds the longest sequence of equal elements in an array of integers.
       If several longest sequences exist, print the leftmost one.
     */
    public static void longestSeq()
    {
        Console.WriteLine("Enter the array of integers (space-separated):");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int bestStart = 0;
        int bestLength = 1;
        int currentStart = 0;
        int currentLength = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
                currentStart = i;
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
                bestStart = currentStart;
            }
        }

        int[] longestSequence = new int[bestLength];
        Array.Copy(array, bestStart, longestSequence, 0, bestLength);

        Console.WriteLine("The longest sequence of equal elements is:");
        Console.WriteLine(string.Join(" ", longestSequence));
    }
    
    /*
     * Write a program that finds the most frequent number in a given sequence of numbers. In
       case of multiple numbers with the same maximal frequency, print the leftmost of them
     */

    public static void mostFrequent()
    {
        Console.WriteLine("Enter the sequence of numbers (space-separated):");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Dictionary<int, int> numberFrequencies = new Dictionary<int, int>();
        int maxFrequency = 0;
        int mostFrequentNumber = numbers[0];

        foreach (int number in numbers)
        {
            if (numberFrequencies.ContainsKey(number))
            {
                numberFrequencies[number]++;
            }
            else
            {
                numberFrequencies[number] = 1;
            }

            if (numberFrequencies[number] > maxFrequency)
            {
                maxFrequency = numberFrequencies[number];
                mostFrequentNumber = number;
            }
            else if (numberFrequencies[number] == maxFrequency &&
                     numbers.ToList().IndexOf(number) < numbers.ToList().IndexOf(mostFrequentNumber))
            {
                // If current number has the same frequency but is the leftmost
                mostFrequentNumber = number;
            }
        }

        Console.WriteLine($"The most frequent number is: {mostFrequentNumber}");
    }
    
    /*
     * Write a program that reads a string from the console, reverses its letters and prints the
       result back at the console.
       Write in two ways
       - Convert the string to char array, reverse it, then convert it to string again
       - Print the letters of the string in back direction (from the last to the first) in a for-loop
     */

    public static void stringToChar()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversedString = new string(charArray);

        Console.WriteLine("Reversed string:");
        Console.WriteLine(reversedString);
    }

    public static void backDirection()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        Console.WriteLine("Reversed string:");
        for (int i = input.Length - 1; i >= 0; i--)
        {
            Console.Write(input[i]);
        }
        Console.WriteLine();
    }
    
    /*
     * Write a program that reverses the words in a given sentence without changing the
       punctuation and spaces
       - Use the following separators between the words: . , : ; = ( ) & [ ] " ' \ / ! ? (space).
       - All other characters are considered part of words, e.g. C++, a+b, and a77 are
       considered valid words.
       - The sentences always start by word and end by separator.
     */

    public static string reverseWords(string sentence)
    {
        string[] separators = { ".", ",", ":", ";", "=", "(", ")", "&", "[", "]", "\"", "'", "\\", "/", "!", "?", " " };
        string[] words = Regex.Split(sentence, "(\\.|,|:|;|=|\\(|\\)|&|\\[|\\]|\"|'|\\\\|/|!|\\?| )");
        Array.Reverse(words);

        int wordIndex = 0;
        string result = Regex.Replace(sentence, "(\\.|,|:|;|=|\\(|\\)|&|\\[|\\]|\"|'|\\\\|/|!|\\?| )", match =>
        {
            return words[wordIndex++] + match.Value;
        });

        return result;
    }
    
    /*
     * Write a program that extracts from a given text all palindromes, e.g. “ABBA”, “lamal”, “exe”
       and prints them on the console on a single line, separated by comma and space.Print all
       unique palindromes (no duplicates), sorted
     */

    public static List<String> extractPalindromes(String text)
    {
        var words = text.Split(new[] { ' ', ',', '.', '?', '!', ';', ':', '-', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var palindromes = new HashSet<string>();

        foreach (var word in words)
        {
            if (IsPalindrome(word))
            {
                palindromes.Add(word.ToLower());
            }
        }

        return palindromes.OrderBy(p => p).ToList();
    }
    
    static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if (char.ToLower(word[left]) != char.ToLower(word[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
    
    /*
     * Write a program that parses an URL given in the following format:
       [protocol]://[server]/[resource]
       The parsing extracts its parts: protocol, server and resource.
       The [server] part is mandatory.
       The [protocol] and [resource] parts are optional.
     */
    public static void parseURL()
    {
        string url = Console.ReadLine();
        string protocol = "";
        string server = "";
        string resource = "";

        // Extract the protocol
        int protocolEnd = url.IndexOf("://");
        if (protocolEnd != -1)
        {
            protocol = url.Substring(0, protocolEnd);
            url = url.Substring(protocolEnd + 3);
        }

        // Extract the server
        int serverEnd = url.IndexOf("/");
        if (serverEnd != -1)
        {
            server = url.Substring(0, serverEnd);
            resource = url.Substring(serverEnd + 1);
        }
        else
        {
            server = url;
        }

        Console.WriteLine($"Protocol: {protocol}");
        Console.WriteLine($"Server: {server}");
        Console.WriteLine($"Resource: {resource}");
    }
}