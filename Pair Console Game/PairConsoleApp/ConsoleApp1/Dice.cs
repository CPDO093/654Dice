using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Dice
    {

        Random rand = new Random();
        public int Rolled { get; set; }
        public Dice()
        {

            Rolled = rand.Next(1, 7);
            int roll = Rolled;
            
            if (roll == 6)
            {
                Console.WriteLine("Rolled a 6 and found a ship");
            }
            else if (roll == 5)
            {
                Console.WriteLine("Rolled a 5 and found a Capitan");
            }
            else if (roll == 4)
            {
                Console.WriteLine("Rolled a 4 and found a crew");
            }
            else
            {
                Console.WriteLine("Rolled a " + roll);
            }

            System.Threading.Thread.Sleep(500);


            Rolled = rand.Next(1, 7);
            int roll2 = Rolled;
            if (roll <= 3)
            {
                if (roll2 == 6)
                {
                    Console.WriteLine("Rolled a 6 and found a ship on second throw.");
                }
                else if (roll2 == 5)
                {
                    Console.WriteLine("Rolled a 5 and found a Capitan on second throw.");
                }
                else if (roll2 == 4)
                {
                    Console.WriteLine("Rolled a 4 and found a crew on second throw.");
                }
                else
                {
                    Console.WriteLine("Rolled a " + roll2 + " on second throw.");
                }
            }
            else
            {
                Console.WriteLine();
            }

            System.Threading.Thread.Sleep(500);


            Rolled = rand.Next(1, 7);
            int roll3 = Rolled;
            if (roll2 <= 3 && roll <= 3)
            {
                if (roll3 == 6)
                {
                    Console.WriteLine("Rolled a 6 and found a ship on third throw.");
                }
                else if (roll3 == 5)
                {
                    Console.WriteLine("Rolled a 5 and found a Capitan on third throw.");
                }
                else if (roll3 == 4)
                {
                    Console.WriteLine("Rolled a 4 and found a crew on third throw.");
                }
                else
                {
                    Console.WriteLine("Rolled a " + roll3 + " on third throw.");
                }

            }
            else
            {
                Console.WriteLine();
            }
            
               
            

            
        }


    }
}
   
