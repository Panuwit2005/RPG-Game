using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public string slave;

    public Cat(string mAnimalName, int mAge, string mSlave) : base(mAnimalName, mAge)
    {
        Debug.Log($"A new cat named {animalName} was create");
        slave = mSlave;
        Debug.Log($"My slave is {slave}");
    }

    public void Scratch(string target)
    {
        Debug.Log($"{animalName} is scratching {target}");
    }

    public override void makeSound()
    {
        Debug.Log($"{animalName} says Meow");
    }
}
