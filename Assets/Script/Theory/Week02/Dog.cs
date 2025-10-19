using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    public string boss;
    public Dog (string mAnimalName, int mAge, string mBoss) : base(mAnimalName, mAge)
    {
        Debug.Log($"A new dog named {animalName} was create");
        boss = mBoss;
        Debug.Log("My boss is " + mBoss);
    }

    public void Smell(string target)
    {
        Debug.Log($"{animalName} is smell! {target}");
    }

    public override void makeSound()
    {
        Debug.Log($"{animalName} says Woof!!");
    }
}
