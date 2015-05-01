using System;
using System.Collections.Generic;
using System.Text;

class Variable_length_code
{
    static void Main()
    {
        //process input
        string[] encChars = Console.ReadLine().Split(' ');
        List<int> encNums = new List<int>();
        for (int i = 0; i < encChars.Length; i++)
        {
            if (encChars[i].Length == 0)
                continue;
            encNums.Add(int.Parse(encChars[i]));
        }
        int numMapEntries = int.Parse(Console.ReadLine());
        Dictionary<char, int> map = new Dictionary<char, int>();
        for (int i = 0; i < numMapEntries; i++)
        {
            String line = Console.ReadLine();
            char ch = line[0];
            int numOnes = int.Parse(line.Substring(1));
            map.Add(ch, numOnes);
        }

        //decrypt
        StringBuilder encMsg = new StringBuilder();
        foreach (int encNum in encNums)
        {     
            string binCharStr = Convert.ToString(encNum, 2);
            encMsg.Append(binCharStr);
        }
        //remove trailing zeroes:
        while (encMsg[encMsg.Length - 1] == '0')
            encMsg.Remove(encMsg.Length - 1, 1);

        //split by zeroes and find corresponding map entries:
        string[] onesArr = encMsg.ToString().Split('0');
        foreach (string onesEntry in onesArr)
        {
            int numOnes = onesEntry.Length;
            foreach (KeyValuePair<char, int> entry in map)
            {
                if (entry.Value == numOnes)
                {
                    Console.Write(entry.Key);
                    break;
                }
            }
        }
        Console.WriteLine();
    }
}