using System;
using System.Text;

class Tres4Numbers
{
    static void Main()
    {
        ulong input = ulong.Parse(Console.ReadLine());
        string[] tres4Digits = { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
        int rem = 0;
        StringBuilder output = new StringBuilder();
        while (input >= 9)
        {
            rem = (int)input%9;
            output.Insert(0, tres4Digits[rem]);
            input /= 9;
        }
        Console.WriteLine("");
        output.Insert(0, tres4Digits[input]);
        Console.WriteLine(output);
    }
}