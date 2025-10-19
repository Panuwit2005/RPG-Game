using UnityEngine;

public class KinematicBox : Stuff, IInteractable
{
    public bool IsInteractable { get; set; } = true; // ����ö interact ��
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning($"{name} ����� Rigidbody!");
        }
    }

    public void Interact(Player player)
    {
        if (IsInteractable = false || rb == null) return;

        // ��Ѻ��� isKinematic
        rb.isKinematic = !rb.isKinematic;
        Debug.Log($"{name}: isKinematic = {rb.isKinematic}");
    }
}
