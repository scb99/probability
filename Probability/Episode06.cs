using System.Collections.Generic;
using static System.Console;

abstract class Animal { }

sealed class Cat : Animal { }

sealed class Dog : Animal { }

sealed class Goldfish : Animal { }

namespace Probability
{
    static class Episode06
    {
        public static void DoIt()
        {
            var cat = new Cat();
            var dog = new Dog();
            var fish = new Goldfish();
            var animals = new List<Animal>() { cat, dog, dog, fish };

            WriteLine("Episode 06");
            WriteLine();

            WriteLine(animals.ToUniform().Histogram());
            WriteLine();

            WriteLine(animals.ToUniform().ShowWeights());
            WriteLine();
        }
    }
}