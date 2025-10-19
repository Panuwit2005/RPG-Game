using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : Items
{

    public override void Oncollect(Player mPlayer)
    {
        base.Oncollect(mPlayer);
        transform.parent = mPlayer.LeftHand;
        transform.localPosition = new Vector3(-0.21f,0,0);
        Vector3 shieldUp = new Vector3(0, 90, -175);
        transform.localRotation = Quaternion.Euler(shieldUp);
        _collider.enabled = false;

        mPlayer.shield = gameObject;
    }
}
