using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Stuff : Identity
{
    public TMP_Text interactionTextUI;
    protected Collider _collider;
    public bool canUse = true;
    public override void SetUp()
    {
        base.SetUp();
        interactionTextUI = GetComponentInChildren<TMP_Text>();
        _collider = GetComponent<Collider>();
    }
    public void Update()
    {
        //Logic for Stuff
        if(GetDistanPlayer() >= 2 || canUse == false)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(true);
        }
    }

}
