namespace Practicelab00F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Task 1: Creating Variables
            Console.WriteLine("Task 1: Creating Variables");
            Console.WriteLine("------------------------------");

            double low = GetUserInput("Enter the low number: ");
            double high = GetUserInput("Enter the high number: ");

            double difference = high - low;
            Console.WriteLine($"The difference between {low} and {high} is: {difference}");
            Console.WriteLine();

            // Task 2: Looping and Input Validation
            Console.WriteLine("Task 2: Looping and Input Validation");
            Console.WriteLine("--------------------------------------");

            low = GetPositiveInput("Enter a positive low number: ");
            high = GetHighInput(low);

            Console.WriteLine();

            // Task 3: Using Arrays and File I/O
            Console.WriteLine("Task 3: Using Lists, File I/O, and Prime Numbers");
            Console.WriteLine("-----------------------------------------------");

            List<double> numbersList = GenerateNumbersList(low, high);

            WriteNumbersToFile(numbersList, "numbers.txt");

            // Read numbers back from the file
            List<double> readNumbers = ReadNumbersFromFile("numbers.txt");

            // Print out the sum of the numbers
            double sum = CalculateSum(readNumbers);
            Console.WriteLine($"Sum of numbers read from file: {sum}");

            // Print out the prime numbers between low and high
            Console.WriteLine($"Prime numbers between {low} and {high}:");
            foreach (double number in readNumbers)
            {
                if (IsPrime(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }

        // Method to get and validate user input as double
        static double GetUserInput(string prompt)
        {
            double input;
            do
            {
                Console.Write(prompt);
            } while (!double.TryParse(Console.ReadLine(), out input));

            return input;
        }

        // Method to get positive input as double
        static double GetPositiveInput(string prompt)
        {
            double input;
            do
            {
                input = GetUserInput(prompt);
            } while (input <= 0);

            return input;
        }

        // Method to get high input greater than low input
        static double GetHighInput(double low)
        {
            double high;
            do
            {
                high = GetUserInput($"Enter a high number greater than {low}: ");
            } while (high <= low);

            return high;
        }

        // Method to generate a list of numbers between low and high
        static List<double> GenerateNumbersList(double low, double high)
        {
            List<double> numbersList = new List<double>();
            for (double i = low; i <= high; i++)
            {
                numbersList.Add(i);
            }
            return numbersList;
        }

        // Method to write numbers to a file
        static void WriteNumbersToFile(List<double> numbers, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (double number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }

        // Method to read numbers from a file
        static List<double> ReadNumbersFromFile(string fileName)
        {
            List<double> numbersList = new List<double>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (double.TryParse(line, out double number))
                    {
                        numbersList.Add(number);
                    }
                }
            }
            return numbersList;
        }

        // Method to calculate the sum of numbers in a list
        static double CalculateSum(List<double> numbers)
        {
            double sum = 0;
            foreach (double number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        // Method to check if a number is prime
        static bool IsPrime(double number)
        {
            if (number <= 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}