using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedicnost
{
    internal class Program
    {
        class Animal
        {
            public string name;
            public int MaxAge;
                public void MakeNoise()
            {
                Console.WriteLine("*animal noise*");
            }
             
        }

        class Dog : Animal
        {
            public string race;

            public override void MakeNoise()
            {
                Console.WriteLine("Woof Woof");
            }
        }
        class cat : Animal
        {
            public string furColor;

            public override void MakeNoise()
            {
                Console.WriteLine("Meow");
            }
        }
        class Mammal : Animal
        {
            public string PregnancyTime;
        }
        

        static void Main(string[] args)
        {
            Animal newAnimal = new Animal();
            newAnimal.MakeNoise();

            Dog newDog = new Dog();
            newDog.name = "fido";
            newDog.MaxAge = 14;
            newDog.race = "Lajka";
            //newDog.PregnancyTime = "69 měsíců";
            Console.WriteLine($"{newDog.name} is {newDog.MaxAge} is a {newDog.race} and is pregnant for");
            newDog.MakeNoise();

            cat newCat = new cat();
            newCat.name = "Micka";
            newCat.MaxAge = 7;
            newCat.furColor = "brown";
            Console.WriteLine($"{newCat.name} is {newCat.MaxAge} and has {newCat.furColor} fur");

            Console.ReadKey();
        }
    }
}
