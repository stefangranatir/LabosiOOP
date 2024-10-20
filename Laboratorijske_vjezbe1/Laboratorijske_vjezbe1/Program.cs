using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorijske_vjezbe1
{
    internal class Program
    {
        public class Die
        {
            private int brojStranica { get; set; }
            private int RolledNumber { get; set; }
            Random generator = new Random();
            public void SetRolledNumber(int number)
            {
                if(number>=1 && number <= brojStranica)
                {
                    RolledNumber = number;
                }
            }
            public void Roll()
            {
                RolledNumber=generator.Next(1,this.brojStranica);
            }

            public int GetSideCount()
            {
                return this.brojStranica;
            }
            public int GetRolledNumber()
            {
                return this.RolledNumber;
            }
            public Die()
            {
                this.brojStranica = 6;
                this.RolledNumber=1;
            }
            public Die(int brojStranica, int rolledNumber, Random generator)
            {
                this.brojStranica = brojStranica;
                RolledNumber = rolledNumber;
                this.generator = generator;
            }
        }

        public static void RunDemo()
        {
            Die first = new Die();
            Die second = new Die(20, 6, new Random());
            Console.WriteLine($"First die: {first.GetSideCount()}, rolled: {first.GetRolledNumber()}");
            Console.WriteLine($"First die: {second.GetSideCount()}, rolled: {second.GetRolledNumber()}");
            first.SetRolledNumber(6);
            second.SetRolledNumber(99);
            Console.WriteLine($"First die: {first.GetSideCount()}, rolled: {first.GetRolledNumber()}");
            Console.WriteLine($"First die: {second.GetSideCount()}, rolled: {second.GetRolledNumber()}");
            first.Roll();
            second.Roll();
            Console.WriteLine($"First die: {first.GetSideCount()}, rolled: {first.GetRolledNumber()}");
            Console.WriteLine($"First die: {second.GetSideCount()}, rolled: {second.GetRolledNumber()}");
        }

        public static float RunExperiment(Die test,int brojPonavljanja, int trazeniBroj)
        {
            int ukupnoPokusaja = 0;
            for (int i = 0; i< brojPonavljanja; i++) {
                int brojPokusaja = 0;
                int vrijednosti = 0;
                do
                {
                    test.Roll();
                    brojPokusaja++;
                    Console.WriteLine($"guess: {test.GetRolledNumber()}, number: {trazeniBroj}");
                } while (test.GetRolledNumber() != trazeniBroj);
                /*while (test.GetRolledNumber() != trazeniBroj)
                {
                    brojPokusaja++;
                    test.Roll();
                    Console.WriteLine($"guess: {test.GetRolledNumber()}, number: {trazeniBroj}");
                }*/
                ukupnoPokusaja += brojPokusaja;
                brojPokusaja = 0;
                Console.WriteLine("");
                Console.WriteLine(ukupnoPokusaja);
            }
            
            return (float)ukupnoPokusaja / brojPonavljanja;
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine(RunExperiment(new Die(),4,4));
        }
    }
}
