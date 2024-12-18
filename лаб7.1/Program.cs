using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Введите дату в формате YYYY-MM-DD: ");
        string inputDate = Console.ReadLine();
        DateTime date;
        if (DateTime.TryParse(inputDate, out date))
        {
            string formattedDate = FormatDate(date);
            Console.WriteLine($"Отформатированная дата: {formattedDate}");
            int quarter = GetQuarter(date);
            int daysPassed = GetDaysPassed(date);
            Console.WriteLine($"Квартал: {quarter}, Дней с начала года: {daysPassed}");
        }
        else
        {
            Console.WriteLine("Ошибка: неверный формат даты.");
        }
    }

    static string FormatDate(DateTime date)
    {
        string day = date.Day.ToString("D2");
        string month = date.ToString("MMMM", new CultureInfo("ru-RU")); 
        string year = date.ToString("yy"); 

        return $"{day} {month} {year}";
    }

    static int GetQuarter(DateTime date)
    {
       
        int month = date.Month;
        if (month >= 1 && month <= 3) return 1;
        else if (month >= 4 && month <= 6) return 2;
        else if (month >= 7 && month <= 9) return 3;
        else return 4; 
    }

    static int GetDaysPassed(DateTime date)
    {
       
        DateTime startOfYear = new DateTime(date.Year, 1, 1);
        return (date - startOfYear).Days + 1; 
    }
}

