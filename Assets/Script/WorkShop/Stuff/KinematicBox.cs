using UnityEngine;

public class KinematicBox : Stuff, IInteractable
{
    public bool IsInteractable { get; set; } = true; // สามารถ interact ได้
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning($"{name} ไม่มี Rigidbody!");
        }
    }

    public void Interact(Player player)
    {
        if (IsInteractable = false || rb == null) return;

        // สลับค่า isKinematic
        rb.isKinematic = !rb.isKinematic;
        Debug.Log($"{name}: isKinematic = {rb.isKinematic}");
    }
}
