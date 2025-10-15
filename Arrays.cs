using System;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Collections_exercises
{
    internal class Arrays
    {

        static void Main()
        {
            // Skapa en konsolapplikation som hanterar ett antal tal i en array.
            // 1. Be användaren ange hur många tal som ska lagras.
            // 2. Skapa en int[] med den storleken.
            // 3. Be användaren mata in varje tal och spara det i arrayen.
            // 4. Skriv ut alla tal som användaren matade in.
            // 5. (Utmaning) Beräkna och skriv ut summan och medelvärdet av talen.

            Console.Write("How many elements the array should have? ");
            int size;

            // while (true) creates an infinite loop — it repeats forever because the condition true never becomes false.
            // The loop keeps asking for input until the user provides something that passes TryParse.
            // Once it succeeds, break stops the loop and execution continues after it.

            while (true)
            {
                // out size is an output parameter — a way for TryParse to return a value through one of its arguments.
                if (int.TryParse(Console.ReadLine(), out size)) 
                    break;
                Console.Write("Invalid input. Please enter a positive integer: ");
            }
                
            Console.WriteLine();

            int[] numbers = new int[size];

            int sumOfNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter element at index {i}: ");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out numbers[i]))
                        break;
                    Console.Write("Invalid input. Please enter a positive integer: ");
                }
                sumOfNumbers += numbers[i];
            }

            Console.WriteLine();

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"\nThe sum of the numbers is {sumOfNumbers}");
            Console.WriteLine($"The average of the numbers is {(double)sumOfNumbers/size}");

            Console.ReadKey();
        }
    }
}
