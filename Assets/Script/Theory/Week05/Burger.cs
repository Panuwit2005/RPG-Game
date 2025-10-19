using System;
using UnityEngine;

public class Burger : Food 
{
    public bool HasChess;
    public string Meat;


    public Burger(bool hasChesse,string typeMeat, double price) : base("Burger", price)
    {
        HasChess = hasChesse;
        Meat = typeMeat;
    }
    public override void Eat()
    {
        Debug.Log("tongue touch");
    }
    public override void Prepare()
    {
        Debug.Log($"Grilled {Meat} and buns are toasted");
        if (HasChess)
        {
            Debug.Log("add cheese");
        }
        else
        {
            Debug.Log("with out cheese");
        }
    }
}
