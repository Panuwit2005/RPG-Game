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
        _collider.isTrigger = false;
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
            player = FindObjectOfType<Player>();
            if (player == null) return;
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 2f)
        {
            if (_interactionTextUI != null)
                _interactionTextUI.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Collect(player);
            }
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

        Items itemComponent = GetComponent<Items>();
        if (itemComponent != null)
        {
            player.AddItem(itemComponent);
            Debug.Log($"{player.Name} collected {itemName}");
        }

        gameObject.SetActive(false);
    }
}
