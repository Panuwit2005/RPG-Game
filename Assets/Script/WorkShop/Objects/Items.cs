using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Items : MonoBehaviour
{
    public string itemName;
    protected Player player;
    protected Collider _collider;

    protected virtual void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            Oncollect(player);
        }
    }

    public virtual void Oncollect(Player mPlayer)
    {
        Debug.Log($"Collected {itemName}");
    }

    public virtual void OnUse(Player mPlayer)
    {
        Debug.Log($"Using {itemName}");
    }
}
