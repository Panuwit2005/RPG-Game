using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ÊÃéÒ§ÅÔÊµì¢Í§ Food
        //Food food = new Food();ไม่สามารถสร้างสิ่งที่เรานิยามได้

        Food food = new Burger(true, "Pork", 80);

        //food.DisplayInfo();
        //food.Prepare();
        //food.Eat();

        List<string> pizzaToping = new List<string> { "pineapple", "ham", "sausage" };
        Pizza pizza = new Pizza("Hawaiian", 359, "L", pizzaToping, "Soft");

        List<Food> Order = new List<Food>();
        Order.Add(food);
        Order.Add(pizza);

        foreach (var item in Order)
        {
            item.DisplayInfo();
            item.Prepare();
            item.Eat();
        }


    }


}