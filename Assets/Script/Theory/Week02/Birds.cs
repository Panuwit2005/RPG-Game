using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : Animal
{
    public string boss;
    public Birds (string mAnimalName, int mAge, string mBoss) : base(mAnimalName, mAge)
    {
        Debug.Log($"A new bird named {animalName} was create");
        boss = mBoss;
        Debug.Log("My boss is " + mBoss);
    }

    public void Peck(string target)
    {
        Debug.Log($"{animalName} is peck! {target}");
    }

    public override void makeSound()
    {
        Debug.Log($"{animalName} says Jib! Jib!");
    }
}
