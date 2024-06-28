namespace Assignment3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a length for array: ");
        int[] numbers = GenerateNumbers(int.Parse(Console.ReadLine()));
        Reverse(numbers);
        PrintNumbers(numbers);
        
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(Fibonacci(i));
        }
        
        Animal myDog = new Dog("Buddy");
        Animal myCat = new Cat("Whiskers");
        
        myDog.DisplayInfo();
        myDog.Speak();
        
        myCat.DisplayInfo();
        myCat.Speak();
        
        // Create a department
        Department compSci = new Department
        {
            Budget = 500000,
            StartDate = new DateTime(2024, 1, 1),
            EndDate = new DateTime(2024, 12, 31)
        };
        
        // Create courses
        Course programming = new Course { Name = "Programming Fundamentals" };
        Course algorithms = new Course { Name = "Algorithms" };
        
        // Add courses to the department
        compSci.Courses.Add(programming);
        compSci.Courses.Add(algorithms);
        
        // Create an instructor
        Instructor profSmith = new Instructor("John Smith", new DateTime(1980, 6, 15), 90000000, new DateTime(2010, 9, 1),
            compSci);
        compSci.Head = profSmith;
        
        // Create a student
        Student studentJane = new Student("Jane Doe", new DateTime(2000, 4, 20), 0);
        studentJane.EnrollCourse(programming);
        studentJane.EnrollCourse(algorithms);
        
        // Add students to courses
        programming.EnrolledStudents.Add(studentJane);
        algorithms.EnrolledStudents.Add(studentJane);
        
        // Add addresses to the instructor
        profSmith.AddAddress("1234 University Way");
        profSmith.AddAddress("5678 College Blvd");
        
        // Demonstrate polymorphism with salary calculation
        Console.WriteLine($"Professor Smith's salary with bonus: {profSmith.CalculateSalary()}");
        
        // Demonstrate encapsulation by accessing properties and methods
        Console.WriteLine($"Student Jane's age: {studentJane.CalculateAge()}");
        
        // Output the names of the courses Jane is enrolled in
        Console.WriteLine("Jane is enrolled in the following courses:");
        foreach (var course in studentJane.GetCourses())
        {
            Console.WriteLine(course.Name);
        }
        
        // Create a few Color instances
        Color redColor = new Color(255, 0, 0);
        Color blueColor = new Color(0, 0, 255);

        // Create a few Ball instances
        Ball redBall = new Ball(10, redColor);
        Ball blueBall = new Ball(15, blueColor);

        // Throw the balls around
        redBall.Throw();
        redBall.Throw();
        blueBall.Throw();

        // Pop one ball and try to throw it
        redBall.Pop();
        redBall.Throw(); // This should not increment the throw count

        // Print out the number of times the balls have been thrown
        Console.WriteLine($"The red ball has been thrown {redBall.GetThrowCount()} times.");
        Console.WriteLine($"The blue ball has been thrown {blueBall.GetThrowCount()} times.");
    }
    
    /*
     * Let’s make a program that uses methods to accomplish a task. Let’s take an array and
       reverse the contents of it. For example, if you have 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, it would
       become 10, 9, 8, 7, 6, 5, 4, 3, 2, 1.
       To accomplish this, you’ll create three methods: one to create the array, one to reverse the
       array, and one to print the array at the end.
       Your Mainmethod will look something like this:
       static void Main(string[] args) {
       int[] numbers = GenerateNumbers();
       Reverse(numbers);
       PrintNumbers(numbers);
       }
       The GenerateNumbersmethod should return an array of 10 numbers. (For bonus points,
       change the method to allow the desired length to be passed in, instead of just always
       being 10.)
       The PrintNumbersmethod should use a for or foreachloop to print out each item in the
       array. The Reversemethod will be the hardest. Give it a try and see what you can make
       happen. If you get
       stuck, here’s a couple of hints:
       Hint #1:To swap two values, you will need to place the value of one variable in a temporary
       location to make the swap:
       // Swapping a and b.
       int a = 3;
       int b = 5;
       int temp = a;
       a = b;
       b = temp;
       Hint #2:Getting the right indices to swap can be a challenge. Use a forloop, starting at 0
       and going up to the length of the array / 2. The number you use in the forloop will be the
       index of the first number to swap, and the other one will be the length of the array minus
       the index minus 1. This is to account for the fact that the array is 0-based. So basically,
       you’ll be swapping array[index]with array[arrayLength – index – 1].
     */
    static int[] GenerateNumbers(int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }

    static void Reverse(int[] numbers)
    {
        int temp;
        for (int i = 0; i < numbers.Length / 2; i++)
        {
            temp = numbers[i];
            numbers[i] = numbers[numbers.Length - i - 1];
            numbers[numbers.Length - i - 1] = temp;
        }
        Console.WriteLine("Array Reversed");
    }

    static void PrintNumbers(int[] numbers)
    {
        Console.WriteLine("The array elements are: ");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        
        
    }
    
    /*
     * The Fibonacci sequence is a sequence of numbers where the first two numbers are 1 and 1,
       and every other number in the sequence after it is the sum of the two numbers before it. So
       the third number is 1 + 1, which is 2. The fourth number is the 2nd number plus the 3rd,
       which is 1 + 2. So the fourth number is 3. The 5th number is the 3rd number plus the 4th
       number: 2 + 3 = 5. This keeps going forever.
       The first few numbers of the Fibonacci sequence are: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...
       Because one number is defined by the numbers before it, this sets up a perfect
       opportunity for using recursion.
       Your mission, should you choose to accept it, is to create a method called Fibonacci, which
       takes in a number and returns that number of the Fibonacci sequence. So if someone calls
       Fibonacci(3), it would return the 3rd number in the Fibonacci sequence, which is 2. If
       someone calls Fibonacci(8), it would return 21.
       In your Mainmethod, write code to loop through the first 10 numbers of the Fibonacci
       sequence and print them out.
       Hint #1:Start with your base case. We know that if it is the 1st or 2nd number, the value will
       be 1.
       Hint #2:For every other item, how is it defined in terms of the numbers before it? Can you
       come up with an equation or formula that calls the Fibonaccimethod again?
     */
    
    public static int Fibonacci(int n)
    {
        if (n <= 2)
        {
            return 1;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}