using TMPro;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractableItem : Items, IHasInteractionUI
{
    public TMP_Text InteractionTextUI { get; private set; }
    private TMP_Text _interactionTextUI;

    public bool canInteract = true;

    protected override void Start()
    {
        base.Start();

        // ถ้าอยากใช้โหมด “ยืนใกล้ + กด E” โดยไม่ให้ OnTrigger ทำงาน
        // ให้คอลลิเดอร์เป็น non-trigger (ตามโค้ดเดิม)
        if (_collider == null) _collider = GetComponent<Collider>();
        if (_collider != null) _collider.isTrigger = false;
    }

    private void Awake()
    {
        _interactionTextUI = GetComponentInChildren<TMP_Text>();
        InteractionTextUI = _interactionTextUI;

        if (_interactionTextUI != null)
            _interactionTextUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!canInteract) return;

        if (player == null)
        {
            player = FindFirstObjectByType<Player>();
            if (player == null) return;
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 2f)
        {
            if (_interactionTextUI != null)
                _interactionTextUI.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
                Collect(player);
        }
        else
        {
            if (_interactionTextUI != null)
                _interactionTextUI.gameObject.SetActive(false);
        }
    }

    private void Collect(Player player)
    {
        canInteract = false;

        if (_interactionTextUI != null)
            _interactionTextUI.gameObject.SetActive(false);

        var itemComponent = GetComponent<Items>();
        if (itemComponent != null)
        {
            // ให้แน่ใจว่า Player.AddItem(Items item) มีซิกเนเจอร์ตรงนี้จริง
            player.AddItem(itemComponent);
            Debug.Log($"{player.Name} collected {Name}");
        }

        gameObject.SetActive(false);
    }
}
