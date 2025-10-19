using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : Items
{
    public int damage = 25;

    public override void Oncollect(Player mPlayer)
    {
        base.Oncollect(mPlayer);
        transform.parent = mPlayer.RightHand;
        transform.localPosition = new Vector3(0.09f, -0.03f, 0.03f);
        Vector3 swordUp = new Vector3(90, 0 ,0);
        transform.localRotation = Quaternion.Euler(swordUp);
        _collider.enabled = false;
        mPlayer.Damage += damage;

        mPlayer.sword = gameObject;
    }
}
