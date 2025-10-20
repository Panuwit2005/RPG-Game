using UnityEngine;
using static UnityEditor.Progress;

[RequireComponent(typeof(SphereCollider))]
public class Items : Identity
{
    protected Player player;
    protected Collider _collider;

    public override void SetUp()
    {
        base.SetUp();
        _collider = GetComponent<Collider>();
        if (_collider != null)
            _collider.isTrigger = true;
    }

    private void Reset()
    {
        var sphere = GetComponent<SphereCollider>();
        if (sphere != null)
        {
            sphere.isTrigger = true;
            sphere.radius = 1.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (player == null)
            player = other.GetComponent<Player>();

        Oncollect(player);
    }

    public virtual void Oncollect(Player mPlayer)
    {
        Debug.Log($"Collected {Name}");
    }

    public virtual void OnUse(Player mPlayer)
    {
        Debug.Log($"Using {Name}");
    }
}
