using UnityEngine;

public class Trap : Stuff, IInteractable
{
   public bool IsInteractable { get => canUse;  set => canUse = value; }
    public GameObject spikes;
    public int Damage = 10;
    public void Interact (Player player)
    {
        if (IsInteractable == false )
        {
            return;
        }
        _collider.enabled = false;
        spikes.gameObject.SetActive(false);
        IsInteractable = false;
        Debug.Log("Trap is Inactivated");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.TakeDamage(Damage);
        }
    }
}
