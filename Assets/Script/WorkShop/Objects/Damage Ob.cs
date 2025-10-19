using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOb : Items
{
    public int obDamage = 40;
    public override void Oncollect(Player mPlayer)
    {
        base.Oncollect(mPlayer);
        mPlayer.TakeDamage(obDamage);
        Destroy(gameObject);
    }
}
