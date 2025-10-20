using UnityEngine;

public class Box : Stuff, IInteractable
{
    public bool isInteractable { get => canUse; set => canUse = value; }
    public GameObject crate;
    public GameObject objectToShow;

    public override void SetUp()
    {
        base.SetUp();

        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }


    public void Interact(Player player)
    {
        if (isInteractable == false)
        {
            return;
        }
        _collider.enabled = false;
        crate.gameObject.SetActive(false);
        isInteractable = false;
        Debug.Log("Breaking crate");

        if (objectToShow != null)
        {  
            objectToShow.SetActive(true);
        }
    }

}
