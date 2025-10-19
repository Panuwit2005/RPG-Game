using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string animalName;
    public float health;
    public int age;

    public Animal(string mAnimalName, int mAge)
    {
        this.animalName = mAnimalName;
        health = 100.0f;
        age = mAge;
        Debug.Log($"A new Animal name {animalName} was create");
    }

    public void Eat(string food)
    {
        if (string.IsNullOrEmpty(food))
        {
            health -= 10.0f;
            Debug.Log($"{animalName} has nothing to eat");
        }
        else
        {
            health += 10.0f;
            Debug.Log($"{animalName} is eating {food}");
        }
    }

    public virtual void makeSound()
    {
        Debug.Log($"{animalName} make a generic Sound");
    }
}
