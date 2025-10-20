using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int score = 0;

    [Header("Hand setting")]
    public Transform RightHand;
    public Transform LeftHand;

    [Header("Inventory")]
    public List<Items> inventory = new List<Items>();

    [HideInInspector] public GameObject sword;
    [HideInInspector] public GameObject shield;

    [Header("Attack Settings")]
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackRadius = 0.5f;

    private Vector3 _inputDirection;
    private bool _isAttacking = false;

    public bool isInvisible = false;

    // ให้ Character รู้ว่า player มีโล่ไหม
    protected override bool HasShield => shield != null && shield.activeInHierarchy;

    protected override void Start()
    {
        base.Start();
        SetUp();
        Debug.Log($"Player HP: {Health}/{maxHealth}");
    }

    private void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
    }

    private void Update()
    {
        HandleInput();
        HandleWeaponToggle();
        Attack(_isAttacking);
    }

    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _inputDirection = new Vector3(x, 0, y);

        if (Input.GetMouseButtonDown(0))
            _isAttacking = true;
    }

    public void Attack(bool isAttacking)
    {
        if (!isAttacking) return;

        animator.SetTrigger("Attack");

        Collider[] hits = Physics.OverlapSphere(transform.position + transform.forward * attackRange, attackRadius);
        foreach (Collider col in hits)
        {
            Character enemy = col.GetComponent<Character>();
            if (enemy != null && enemy != this)
            {
                enemy.TakeDamage(Damage);
                Debug.Log($"{Name} attacks {enemy.Name} for {Damage} damage.");
            }
        }

        _isAttacking = false;
    }

    public void AddItem(Items item) => inventory.Add(item);

    public void Coin(int amount) => score += amount;

    // ✅ ระบบกด H / J
    private void HandleWeaponToggle()
    {
        // -----------------
        // 🔹 ปุ่ม H: สลับโล่
        // -----------------
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (shield != null)
            {
                bool isActive = !shield.activeSelf;
                shield.SetActive(isActive);

                if (isActive)
                {
                    Debug.Log("🛡️ Draw Shield");
                    Defense += 10; // เพิ่มเกราะเมื่อถือโล่
                }
                else
                {
                    Debug.Log("🛡️ Hide Shield");
                    Defense = Mathf.Max(0, Defense - 10); // เอาโล่ลง ลดเกราะกลับ
                }
            }
        }

        // -----------------
        // 🔹 ปุ่ม J: สลับดาบ
        // -----------------
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (sword != null)
            {
                bool isActive = !sword.activeSelf;
                sword.SetActive(isActive);

                Sword swordComp = sword.GetComponent<Sword>();

                if (swordComp != null)
                {
                    if (isActive)
                    {
                        Debug.Log("⚔️ Draw Sword");
                        Damage += swordComp.damage; // เพิ่มดาเมจตามค่าดาบ
                    }
                    else
                    {
                        Debug.Log("👊 Use Fist");
                        Damage = Mathf.Max(10, Damage - swordComp.damage); // กลับไปใช้หมัด
                    }
                }
            }
        }
    }

    // เพื่อให้เห็นระยะโจมตีใน Scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * attackRange, attackRadius);
    }
}
