using UnityEngine;

public class Torch : Stuff, IInteractable
{
    public bool isInteractable { get => canUse; set => canUse = value; }

    private bool isOn;
    public GameObject Firelight;

    public void Interact(Player player)
    {
        isOn = !isOn;
        Debug.Log("Can't use Torch");
        Firelight.SetActive(isOn);
    }
}
