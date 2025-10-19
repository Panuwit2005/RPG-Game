using System;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : Food
{
    public string Size;
    public string Flour;
    public List<string> Toppins;

    public Pizza(string name, double price, string size, List<string> toppings, string flour)
        : base(name, price)
    {
        Size = size;
        Toppins = toppings;
        Flour = flour;
    }

    public override void Eat()
    {
        Debug.Log("Take one and eat");
    }

    public override void Prepare()
    {
        Debug.Log($"Prepare a {Size} pizza name {Name} flour {Flour} with toppings:");
        foreach (var p in Toppins)
        {
            Debug.Log(p);
        }
    }
}