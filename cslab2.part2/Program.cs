using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSlab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input first number");
            string num1 = Console.ReadLine();
            Console.WriteLine("input second number");
            string num2 = Console.ReadLine();
            division(num1, num2);
            Console.ReadKey();
        }
        public static void division(string num1, string num2)
        {
            Int64 divisor, remainderAndQuotient;
            divisor = Int32.Parse(num1);
            remainderAndQuotient = Int32.Parse(num2);
            divisor <<= 32;
            bool setRemLSBToOne = false;
            for (int i = 0; i <= 32; ++i)
            {
                if (divisor <= remainderAndQuotient)
                {
                    remainderAndQuotient -= divisor;
                    setRemLSBToOne = true;
                }
                else
                    Console.Write("");
                remainderAndQuotient <<= 1;

                if (setRemLSBToOne)
                {
                    setRemLSBToOne = false;
                    remainderAndQuotient |= 1;
                }

                Console.WriteLine("Divisor IS:\n" + finisherOfString(Convert.ToString(divisor, 2)) +
                "\n(R)&(Q) IS:\n" + finisherOfString(Convert.ToString(remainderAndQuotient, 2)));
            }
            long quotient = remainderAndQuotient & ((long)Math.Pow(2, 33) - 1);
            long remainder = remainderAndQuotient >> 33;
            Console.WriteLine("Quotient IS:" + finisherOfString(Convert.ToString(quotient, 2)) +
            "[" + quotient + "]");

            Console.WriteLine("Remainder IS:" + finisherOfString(Convert.ToString(remainder, 2)) +
            "[" + remainder + "]");
            Console.WriteLine("________________________________________________________________________");
        }
        static string finisherOfString(string val)
        {
            int count = 64 - val.Length;
            string head = "";
            for (int i = 0; i < count; ++i)
                head += "0";
            return head + val;
        }
    }
}
