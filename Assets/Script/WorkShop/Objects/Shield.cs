using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Shield : Stuff, IInteractable
{
    public GameObject shieldMesh;
    public int Defense = 10;
    public bool isInteractable { get => canUse; set => canUse = value; }
    public void Interact(Player player)
    {
        if (isInteractable == true)
        {
            shieldMesh.transform.parent = player.LeftHand;
            shieldMesh.transform.localPosition = new Vector3(-0.21f, 0, 0);
            Vector3 shieldUp = new Vector3(0, 90, -175);
            transform.localRotation = Quaternion.Euler(shieldUp);

            if (_collider != null)
            {
                _collider.enabled = false;
            }

            Collider meshCollider = shieldMesh.GetComponent<Collider>();
            if (meshCollider != null)
            {
                meshCollider.enabled = false;
            }

            player.Defense += Defense;
            isInteractable = false;
            player.shield = gameObject;

        }
    }
}
