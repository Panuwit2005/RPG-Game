using TMPro;
using UnityEngine;

public class MoveAbleEnemyInteractable : MoveAbleEnemy, IInteractable, IHasInteractionUI
{
    public TMP_Text InteractionTextUI { get; private set; }
    public bool IsInteractable { get; set; } = true; // สามารถ interact ได้ครั้งเดียว
    private bool isAttacking = false;

    private void Awake()
    {
        InteractionTextUI = GetComponentInChildren<TMP_Text>();
        if (InteractionTextUI != null)
            InteractionTextUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Player == null || InteractionTextUI == null) return;

        // แสดง interaction text ถ้าใกล้ ≤ 2 หน่วย และยัง interact ได้
        float distance = GetDistanPlayer();
        if (distance <= 2f && IsInteractable)
        {
            InteractionTextUI.gameObject.SetActive(true);
        }
        else
        {
            InteractionTextUI.gameObject.SetActive(false);
        }

        // ตรวจสอบ input กด E
        if (distance <= 2f && IsInteractable && Input.GetKeyDown(KeyCode.E))
        {
            Interact(Player);
        }
    }

    public void Interact(Player player)
    {
        if (!IsInteractable) return;

        // โต้ตอบครั้งเดียว
        IsInteractable = false; // ไม่สามารถ interact ซ้ำ
        if (InteractionTextUI != null)
            InteractionTextUI.gameObject.SetActive(false);

        rb.isKinematic = false;
        isAttacking = true;
        Debug.Log($"{Name} started attacking {player.Name}!");
    }

    public new void FixedUpdate()
    {
        if (!isAttacking) return;

        if (Player == null || Player.isInvisible)
        {
            animator.SetBool("Attack", false);
            rb.linearVelocity = Vector3.zero;
            return;
        }

        Vector3 direction = Player.transform.position - transform.position;
        Turn(direction);

        if (GetDistanPlayer() > moveableDistance)
        {
            Vector3 moveDir = direction.normalized;
            rb.MovePosition(rb.position + moveDir * movementSpeed * Time.fixedDeltaTime);
            animator.SetFloat("Speed", movementSpeed);
            animator.SetBool("Attack", false);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            animator.SetFloat("Speed", 0);
        }

        timer -= Time.deltaTime;

        if (GetDistanPlayer() <= moveableDistance)
        {
            Attack(Player);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
}
