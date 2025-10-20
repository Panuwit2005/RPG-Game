using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Sign : MonoBehaviour, IReadable ,IHasInteractionUI
{
    [TextArea]
    public string message = "Hope Town";
    public TMP_Text interactionTextUI;
    public float interactDistance = 2f;

    private Player player;
    private bool isPlayerNearby = false;
    private bool isMessageShown = false;

    public TMP_Text InteractionTextUI
    {
        get { return interactionTextUI; }
    }

    private void Start()
    {
        player = FindFirstObjectByType<Player>();

        if (interactionTextUI == null)
        {
            interactionTextUI = GetComponentInChildren<TMP_Text>();
        }

        if (interactionTextUI != null)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= interactDistance)
        {
            if (!isPlayerNearby)
            {
                isPlayerNearby = true;
                ShowHint("[E]");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Read(player);
            }
        }
        else
        {
            if (isPlayerNearby)
            {
                isPlayerNearby = false;
                HideHint();
            }
        }
    }

    // 🔹 เมธอดจาก interface IReadable
    public void Read(Player player)
    {
        if (interactionTextUI == null) return;

        if (!isMessageShown)
        {
            interactionTextUI.text = message;
            interactionTextUI.gameObject.SetActive(true);
            isMessageShown = true;
        }
        else
        {
            interactionTextUI.gameObject.SetActive(false);
            isMessageShown = false;
        }
    }

    private void ShowHint(string text)
    {
        if (interactionTextUI == null) return;
        interactionTextUI.text = text;
        interactionTextUI.gameObject.SetActive(true);
    }

    private void HideHint()
    {
        if (interactionTextUI == null) return;
        interactionTextUI.gameObject.SetActive(false);
    }
}
