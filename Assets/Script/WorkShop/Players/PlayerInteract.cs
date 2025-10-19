using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(GetComponent<Player>());
                }
            }
        }
    }

    // 🔹 วาด Gizmos ใน Scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        // วาดเส้น Ray
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * interactDistance);
        // วาดลูกศรปลายเส้นเพื่อดูระยะ
        Gizmos.DrawWireSphere(transform.position + transform.forward * interactDistance, 0.1f);
    }
}
