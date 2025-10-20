using UnityEngine;

public class Trap : Stuff, IInteractable
{
    public bool isInteractable { get => canUse; set => canUse = value; }
    public int Damage = 10;
    public GameObject spikes;

    private void Awake()
    {
        // ✅ ตั้งชื่อใน Awake แทน constructor
        Name = "Trap";
    }

    public void Interact(Player player)
    {
        _collider.enabled = false;
        spikes.SetActive(false);
        canUse = false;
        Debug.Log("Trap Inactivated!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ✅ ใช้ Player instance ที่ชน trap
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(Damage);
            }
        }
    }
}
