namespace Assignment1;
using System.Numerics;

public class UnderstandingTypes {
// Practice number sizes and ranges
/* 1. Create a console application project named /02UnderstandingTypes/ that outputs the
number of bytes in memory that each of the following number types uses, and the
minimum and maximum values they can have: sbyte, byte, short, ushort, int, uint, long,
ulong, float, double, and decimal.
    Composite Formatting to learn how to align text in a console application */
    public static void memory()
    {
        Console.WriteLine("Size and Range of Various Data Types:");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("{0,-10} {1,5} {2,30}", "Type", "Bytes", "Min/Max Value");
        // sbyte
        Console.WriteLine("{0,-10} {1,5} {2,30}", "sbyte", sizeof(sbyte), $"{sbyte.MinValue}/{sbyte.MaxValue}");
            
        // byte
        Console.WriteLine("{0,-10} {1,5} {2,30}", "byte", sizeof(byte), $"{byte.MinValue}/{byte.MaxValue}");
            
        // short
        Console.WriteLine("{0,-10} {1,5} {2,30}", "short", sizeof(short), $"{short.MinValue}/{short.MaxValue}");
            
        // ushort
        Console.WriteLine("{0,-10} {1,5} {2,30}", "ushort", sizeof(ushort), $"{ushort.MinValue}/{ushort.MaxValue}");
            
        // int
        Console.WriteLine("{0,-10} {1,5} {2,30}", "int", sizeof(int), $"{int.MinValue}/{int.MaxValue}");
            
        // uint
        Console.WriteLine("{0,-10} {1,5} {2,30}", "uint", sizeof(uint), $"{uint.MinValue}/{uint.MaxValue}");
            
        // long
        Console.WriteLine("{0,-10} {1,5} {2,30}", "long", sizeof(long), $"{long.MinValue}/{long.MaxValue}");
            
        // ulong
        Console.WriteLine("{0,-10} {1,5} {2,30}", "ulong", sizeof(ulong), $"{ulong.MinValue}/{ulong.MaxValue}");
            
        // float
        Console.WriteLine("{0,-10} {1,5} {2,30}", "float", sizeof(float), $"{float.MinValue}/{float.MaxValue}");
            
        // double
        Console.WriteLine("{0,-10} {1,5} {2,30}", "double", sizeof(double), $"{double.MinValue}/{double.MaxValue}");
            
        // decimal
        Console.WriteLine("{0,-10} {1,5} {2,30}", "decimal", sizeof(decimal), $"{decimal.MinValue}/{decimal.MaxValue}");
    }

/*
 Write program to enter an integer number of centuries and convert it to years, days, hours,
   minutes, seconds, milliseconds, microseconds, nanoseconds. Use an appropriate data
   type for every data conversion. Beware of overflows!
 */
    public static void getDetailsOfCenturies(BigInteger century)
    {
        BigInteger years = century * 100;
        BigInteger days = years * 365;
        BigInteger hours = days * 24;
        BigInteger minutes = hours * 60;
        BigInteger seconds = minutes * 60;
        BigInteger milliSeconds = seconds * 1000;
        BigInteger microSeconds = milliSeconds * 1000;
        BigInteger nanoSeconds = microSeconds * 1000;
        Console.WriteLine($"{century} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliSeconds} milliseconds = {microSeconds} microseconds = {nanoSeconds} nanoseconds");
    }
}