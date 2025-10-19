using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : Stuff
{
    public Switch() { 
        Name = "Switch";
    }
    public bool isInteractable { get => canUse; set => canUse = value; }
    [SerializeField]
    //bool isOn = false;
    Animator animator;
    public Identity InteracTo;
}

