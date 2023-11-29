using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class Program
    {
        class Human
        {
            public int age;
            public int height;
            public int weight;
            public string name;
            public Human partner;
            public Human()
            {

            }

            public Human(int age, int height, int weight, string name)
            {
                this.age = age;
                this.height = height;
                this.weight = weight;
                this.name = name;
            }

            public void IntroduceHuman()
            {
                Console.WriteLine($"jmenuji se {name}, je mi {age} let, měřím {height}cm a vážím {weight}kg");
            }
            public float BMI()
            {
                float HeightForBmi = height / 100f;
                float bmi = weight / (HeightForBmi * HeightForBmi);
                return bmi;
            }
            public static Human MakeChild(Human human1, Human human2)
            {
                if (human1.partner == human2 && human2.partner == human1) 
                {
                    Human child = new Human();
                    child.age = 0;
                    child.height = (human1.height + human2.height) / 2;
                    child.weight = (human2.weight + human2.weight) / 2;
                    child.name = human1.name + " " + human2.name;
                    child.partner = null;
                    return child;
                }
                else
                {
                    Console.WriteLine("tady někdo zahýbá");
                    return new Human ("bastard");

                }
                
            }
            public static Human makeChildWith(Human human2)
            {
                Human child = new Human();
                child.age = 0;
                child.height = (height + human2.height) / 2;
                child.weight = (weight + human2.weight) / 2;
                child.name = human1.name + " " + human2.name;
                child.partner = null;
                return child;
            }
        }
        static void Main(string[] args)
        {
            int[] IntArray = new int[5];

            Human human1 = new Human();
            human1.age = 32;
            human1.height = 180;
            human1.weight = 75;
            human1.name = "Honza";
            human1.IntroduceHuman();
            float bmi1 = human1.BMI();
            Console.WriteLine($"bmi honzy je {bmi1}");

            Human human2 = new Human(25, 160, 62, "Marie");
            human2.IntroduceHuman();
             
            float bmi2 = human2.BMI();
            Console.WriteLine($"bmi Marie je {bmi2}");
            Human newChild = Human.MakeChild(human1, human2);
            newChild.IntroduceHuman();

            Human newerChild = human2.makeChildWith(Human human2);

            Console.ReadKey();
        }
    }
}
