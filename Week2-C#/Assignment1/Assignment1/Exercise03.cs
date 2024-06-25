namespace Exercise03;

class ExerciseThree
{
       /* Practice loops and operators
        1. FizzBuzzis a group word game for children to teach them about division. Players take turns
            to count incrementally, replacing any number divisible by three with the word /fizz/, any
            number divisible by five with the word /buzz/, and any number divisible by both with /
            fizzbuzz/.
        Create a console application in Chapter03 named Exercise03 that outputs a simulated
            FizzBuzz game counting up to 100. The output should look something like the following
        screenshot:
*/
    public static void getFizzBuzz(){
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
    
/*
 * What will happen if this code executes?
       
          int max = 500;
          for (byte i = 0; i < max; i++) // i is of type byte, which has a maximum value of 255. Since max is set to 500, the loop will result in an overflow,
          {
              Console.WriteLine(i); // This is not recognised because Console is missing
          }
          The code you’ve provided will result in an infinite loop because the byte data type has a maximum value of 255. When i reaches 255 and is incremented, it will overflow and wrap around back to 0, causing the loop to continue indefinitely.
             
   ##### Warning Code: To warn about the problem without changing the existing code, you could add a check to see if i has wrapped around:
   if (i == 255){
       Console.WriteLine("Warning: 'byte' type will overflow and wrap around.");
       break; // Exit the loop
   }
 */ 

/*  Write a program that generates a random number between 1 and 3 and asks the user to
    guess what the number is. Tell the user if they guess low, high, or get the correct answer.
    Also, tell the user if their answer is outside of the range of numbers that are valid guesses
    (less than 1 or more than 3). You can convert the user's typed answer from a string to an
    int using this code:
*/

    public static void GuessingGame()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess a number (1-3): ");
        int guessedNumber = int.Parse(Console.ReadLine());

        if (guessedNumber < 1 || guessedNumber > 3)
        {
            Console.WriteLine("Your guess is outside the valid range.");
        }
        else if (guessedNumber < correctNumber)
        {
            Console.WriteLine("Your guess is too low.");
        }
        else if (guessedNumber > correctNumber)
        {
            Console.WriteLine("Your guess is too high.");
        }
        else
        {
            Console.WriteLine("You guessed correctly!");
        }
    }
    
    /*
     * Print-a-Pyramid.Like the star pattern examples that we saw earlier, create a program that
       will print the following pattern: If you find yourself getting stuck, try recreating the two
       examples that we just talked about in this chapter first. They’re simpler, and you can
       compare your results with the code included above.
       This can actually be a pretty challenging problem, so here is a hint to get you going. I used
       three total loops. One big one contains two smaller loops. The bigger loop goes from line
       to line. The first of the two inner loops prints the correct number of spaces, while the
       second inner loop prints out the correct number of stars.
     */
    public static void printPyramid()
    {
        Console.WriteLine("Enter the Height of Pyramid: ");
        int pyramidHeight = int.Parse(Console.ReadLine());
        for (int i = 1; i <= pyramidHeight; i++)
        {
            // Print leading spaces
            for (int j = pyramidHeight; j > i; j--)
            {
                Console.Write(" ");
            }

            // Print stars
            for (int k = 1; k <= (2 * i - 1); k++)
            {
                Console.Write("*");
            }

            // New line after each row
            Console.WriteLine();
        }
    }
    
    /*
     * Write a simple program that defines a variable representing a birth date and calculates
       how many days old the person with that birth date is currently.
       For extra credit, output the date of their next 10,000 day (about 27 years) anniversary.
       Note: once you figure out their age in days, you can calculate the days until the next
       anniversary using int daysToNextAnniversary = 10000 - (days % 10000); 
     */

    public static void printAge()
    {
        Console.WriteLine("Enter a date of birth(format: MM/dd/yyyy): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());
        DateTime currentDate = DateTime.Today;
        
        int daysOld = (currentDate - birthDate).Days;
        Console.WriteLine($"You are {daysOld} days old.");

        // Calculate the days until the next 10,000day anniversary
        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversary);
        Console.WriteLine($"Your next 10,000 day anniversary will be on {nextAnniversary.ToShortDateString()}.");
    }
    
    /*
     * Write a program that greets the user using the appropriate greeting for the time of day.
       Use only if , not else or switch , statements to do so. Be sure to include the following
       greetings:
       "Good Morning"
       "Good Afternoon"
       "Good Evening"
       "Good Night"
       It's up to you which times should serve as the starting and ending ranges for each of the
       greetings. If you need a refresher on how to get the current time, see DateTime
       Formatting. When testing your program, you'll probably want to use a DateTime variable
       you define, rather than the current time. Once you're confident the program works
       correctly, you can substitute DateTime.Now for your variable (or keep your variable and just
       assign DateTime.Now as its value, which is often a better approach).
     */

    public static void greetings()
    {
        DateTime currentTime = DateTime.Now; // Replace with a specific time if needed

        // Get the current hour
        int hour = currentTime.Hour;

        // Greet the user based on the time of day
        if (hour >= 5 && hour < 12)
        {
            Console.WriteLine("Good Morning!!");
        }
        if (hour >= 12 && hour < 17)
        {
            Console.WriteLine("Good Afternoon!");
        }
        if (hour >= 17 && hour < 21)
        {
            Console.WriteLine("Good Evening!!");
        }
        if (hour >= 21 || hour < 5)
        {
            Console.WriteLine("Good Night!");
        }
    }
    /*
     * Write a program that prints the result of counting up to 24 using four different increments.
       First, count by 1s, then by 2s, by 3s, and finally by 4s.
       Use nested for loops with your outer loop counting from 1 to 4. You inner loop should
       count from 0 to 24, but increase the value of its /loop control variable/ by the value of the /
       loop control variable/ from the outer loop. This means the incrementing in the /
       afterthought/ expression will be based on a variable.
       Your output should look something like this:
     */
    public static void incrementalCounting()
    {
        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine($"Counting by {i}s:");

            // Inner loop - counts from 0 to 24, incrementing by the outer loop's control variable
            for (int j = 0; j <= 24; j += i)
            {
                Console.Write(j + " ");
            }

            // Print a newline for better readability between each count
            Console.WriteLine("\n");
        }
    }
}