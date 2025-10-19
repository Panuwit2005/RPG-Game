using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items
{
    public int coin = 1;

    public override void Oncollect(Player mPlayer)
    {
        base.Oncollect(mPlayer);
        mPlayer.Coin(coin);
        Debug.Log($"Score : {player.score}");
        Destroy(gameObject);
    }
}
