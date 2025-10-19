using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableItem : Items
{
    public int value = 10;

    public override void Oncollect(Player mPlayer)
    {
        base.Oncollect(mPlayer);
        mPlayer.AddItem(this);
        gameObject.SetActive(false);
    }
}
