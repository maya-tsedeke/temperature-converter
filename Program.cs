using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Please enter a temperature value and its unit of measurement (ex: 45 F or 7,22 C):");
            string? input = Console.ReadLine()?.Trim();

            if (input == null || input.ToLower() == "exit")
            {
                Console.WriteLine("Program terminated.");
                break;
            }
            string[] parts = input.Split(' ');

            if (parts.Length != 2 || !double.TryParse(parts[0], out double temperature) || !IsValidScale(parts[1]))
            {
                Console.WriteLine("Invalid input. Please enter a valid temperature value and its unit of measurement (F or C).");
                continue;
            }
            double convertedTemperature;
            string convertedScale;
            char fromScale;
            char toScale;
            if (parts[1].ToUpper() == "F")
            {
                fromScale = 'F';
                toScale = 'C';
                convertedScale = "Celsius";
            }
            else if (parts[1].ToUpper() == "C")
            {
                fromScale = 'C';
                toScale = 'F';
                convertedScale = "Fahrenheit";
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid temperature scale (F or C).");
                continue;
            }
            convertedTemperature = TempConvert(temperature, fromScale, toScale);
            Console.WriteLine($"{temperature} {parts[1].ToUpper()} = {convertedTemperature:F2} {convertedScale}\n");
        }
    }
    static bool IsValidScale(string scale)
    {
        return scale.ToUpper() == "F" || scale.ToUpper() == "C";
    }
    static double TempConvert(double temperature, char fromScale, char toScale)
    {
        switch (fromScale)
        {
            case 'F' when toScale == 'C':
                return (temperature - 32) * 5 / 9;
            case 'C' when toScale == 'F':
                return temperature * 9 / 5 + 32;
            default:
                return temperature;
        }
    }
}
