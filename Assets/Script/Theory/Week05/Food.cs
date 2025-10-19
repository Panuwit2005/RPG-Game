using System;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    public string Name;
    public double Price;
    public Food(string name,double price) 
    { 
        Name = name;
        Price = price;
    
    }
    //public abstract void Eat() { } เขียนเต็มรูปไม่ได้
    public abstract void Eat();
    public abstract void Prepare(); //ทุกตัวใช้ไม่เหมือนกัน

    public void DisplayInfo() //ทุกตัวใช้เหมือนกัน
    {
        Debug.Log("----print info----");
        Debug.Log("Food Name is : "+Name);
        Debug.Log("Price : " + Price);
    }


}
