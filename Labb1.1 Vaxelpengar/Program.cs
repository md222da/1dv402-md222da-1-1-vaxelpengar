using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1._1_Vaxelpengar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar variabler
            double sum,
            paid,
            roundOff,
            change;
            uint total;

            total = 0;
            roundOff = 0;
            //Läser in summan att betala (sum) och testar att det är ett heltal
            while (true)
            {
                try
                {
                    Console.Write("Skriv in summan att betala: ");
                    sum = double.Parse(Console.ReadLine());
                    total = (uint)Math.Round(sum); //Rundar av till heltal, total är ny sum
                    roundOff = total - sum;  // Öresavrundingen
                    

                    if ((int)total < 1) // Testar att total inte är mindre än 1
                    {
                        throw new Exception();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Du måste ange ett heltal.");
                    Console.ResetColor();
                    
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
                    Console.ResetColor();
                    return;
                }
                
            }

            // Läser in erhållet belopp och testar att det är ett heltal
            change = 0;
            while (true)
            {
                try
                {
                    Console.Write("Skriv in erhållet belopp: "); 
                    paid = double.Parse(Console.ReadLine());
                    change = paid - total; // Räknar ut växeln
                    
                    if (change < 0)  // Testar att erhållet belopp inte är mindre än priset att betala
                    {
                        throw new Exception();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Du måste ange ett heltal.");
                    Console.ResetColor();
                    
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Erhållet belopp är för litet. Köpet kunde inte genomföras.");
                    Console.ResetColor();
                    return;
                }
                
            } 

            // Skriver ut kvittot 
            Console.WriteLine("KVITTO");
            Console.WriteLine("-------------------");
            Console.WriteLine("Totalt         :       {0, 10:c}.", sum);
            Console.WriteLine("Öresavrundning :       {0, 10:c}.", roundOff);
            Console.WriteLine("Att betala     :       {0, 10:c}.", total);
            Console.WriteLine("Kontant        :       {0, 10:c}.", paid);
            Console.WriteLine("Tillbaka       :       {0, 10:c}.", change);


            // Växeln ska delas upp i 500,100,50,20-lappar samt 10, 5 och 1-kr

            int number = 0;
            int remainingChange = (int)change;
            // Räknar ut antalet 500-lappar genom division
            number = remainingChange / 500;
            // Skriver ut antalet 500-lappar representerade av number om värdet är större eller lika med ett
            if (number >= 1)
            {
                Console.WriteLine("500-lappar : " + number);
            }

            // Räknar genom modulus ut vad som blir kvar och tilldelar remainingChange det värdet
            remainingChange = remainingChange % 500;
            number = remainingChange / 100;
            if (number >= 1)
            {
                Console.WriteLine("100-lappar : " + number);
            }

            remainingChange = remainingChange % 100;
            number = remainingChange / 50;
            if (number >= 1)
            {
                Console.WriteLine("50-lappar : " + number);
            }

            remainingChange = remainingChange % 50;
            number = remainingChange / 20;
            if (number >= 1)
            {
                Console.WriteLine("20-lappar : " + number);
            }

            remainingChange = remainingChange % 20;
            number = remainingChange / 10;
            if (number >= 1)
            {
                Console.WriteLine("10-kronor : " + number);
            }

            remainingChange = remainingChange % 10;
            number = remainingChange / 5;
            if (number >= 1)
            {
                Console.WriteLine("5-kronor : " + number);
            }

            remainingChange = remainingChange % 5;
            number = remainingChange / 1;
            if (number >= 1)
            {
                Console.WriteLine("1-kronor : " + number);
            }
        }
    }
}
