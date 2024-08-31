using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Enter the date (dd/mm/yyyy): ");
            string inputDateEntered = Console.ReadLine();
            Console.Write("Enter the number of days to add: ");
            int noOfDaysToAdd = int.Parse(Console.ReadLine());

            if (!ValidateDate(inputDateEntered, out int day, out int month, out int year))
            {
                Console.WriteLine("Invalid date. Please enter a valid date.");
                continue; 
            }

            (int newDay, int newMonth, int newYear) = AddNoOfDays(day, month, year, noOfDaysToAdd);

            Console.WriteLine($"New Date: {newDay}/{newMonth}/{newYear}");

            Console.Write("Do you want to enter another date? (yes/no): ");
            string response = Console.ReadLine();
            if (response != "yes")
            {
                break; 
            }            
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static bool ValidateDate(string inputDateEntered, out int day, out int month, out int year)
    {
        day = month = year = 0;
        string[] datePartitions = inputDateEntered.Split('/');
        if (datePartitions.Length != 3)
        {
            return false;
        }

        if (!int.TryParse(datePartitions[0], out day) || !int.TryParse(datePartitions[1], out month) || !int.TryParse(datePartitions[2], out year))
        {
            return false;
        }

        if (month < 1 || month > 12 || day < 1 || day > NoOfDaysInMonth(month, year))
        {
            return false;
        }

        return true;
    }

    public static (int, int, int) AddNoOfDays(int day, int month, int year, int noOfDaysToAdd)
    {
        while (noOfDaysToAdd > 0)
        {
            int daysInCurrentMonth = NoOfDaysInMonth(month, year);
            if (day + noOfDaysToAdd > daysInCurrentMonth)
            {
                noOfDaysToAdd = noOfDaysToAdd - (daysInCurrentMonth - day + 1);
                day = 1;
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }
            else
            {
                day = day + noOfDaysToAdd;
                noOfDaysToAdd = 0;
            }
        }
        return (day, month, year);
    }

    public static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    public static int NoOfDaysInMonth(int month, int year)
    {
        int[] noOfDaysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (month == 2 && IsLeapYear(year))
        {
            return 29;
        }
        return noOfDaysInMonths[month - 1];
    }
}