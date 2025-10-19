using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Items
{
    public int healPoint = 20;
    public int damagePoint = 20;
    public bool isHealingPotion = true;

    public override void Oncollect(Player mPlayer)
    {
        base.Oncollect(mPlayer);

        if (isHealingPotion)
        {
            mPlayer.Heal(healPoint);
        }
        else
        {
            mPlayer.TakeDamage(damagePoint);
        }

        Destroy(gameObject);
    }
}
