using UnityEngine;

public class AnimalGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animal animal01 = new Animal("001", 1);
        animal01.Eat("Grass");
        animal01.makeSound();

        Dog dog01 = new Dog("Bo!", 3, "Man");
        dog01.Eat("KFC");
        dog01.makeSound();
        dog01.Smell("Bomb");

        Cat cat01 = new Cat("Som", 2, "Ploy");
        cat01.Eat("Santafe");
        cat01.makeSound();
        cat01.Scratch("Curtain");

        Birds birds01 = new Birds("Jack", 4, "Flame");
        birds01.Eat("Bird Food");
        birds01.makeSound();
        birds01.Peck("Tree");
    }
    
}
