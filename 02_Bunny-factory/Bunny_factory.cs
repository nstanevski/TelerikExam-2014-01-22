using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class Bunny_factory
{
    static void Main()
    {
        List<int> factory = new List<int>();
        string input = "";

        while ((input = Console.ReadLine()) != "END")
        {
            factory.Add(int.Parse(input));
        }
        
        int cycleNum = 1;
        while (true)
        {
            int numCages = 0;
            int factoryLen = factory.Count;

            for (int i = 0; i < cycleNum; i++)
                numCages += factory[i];

            if (factoryLen - cycleNum < numCages)
                break;

            int sum = 0;
            BigInteger product = 1;

            for (int i = cycleNum; i < numCages+cycleNum; i++)
            {
                sum += factory[i];
                product *= factory[i];
            }

            //string buffer holding newly created cages
            StringBuilder sb = new StringBuilder(sum.ToString() + product.ToString());
            //append untouched cages
            for (int i = numCages+cycleNum; i < factoryLen; i++)
                sb.Append(factory[i]);

            //load the new factory
            factory.Clear();
            char[] digits = sb.ToString().ToCharArray();
           
            for (int i = 0; i < digits.Length; i++)
            {
                int digit = (int)digits[i] - (int)'0';
                if (digit > 1)
                    factory.Add(digit);
            }
            cycleNum++;
        }

        //print output result
        for (int i = 0; i < factory.Count; i++)
        {
            Console.Write(factory[i]);
            if (i < factory.Count - 1)
                Console.Write(" ");
        }  
    }
}