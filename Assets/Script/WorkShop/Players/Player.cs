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

    Vector3 _inputDirection;
    bool _isAttacking = false;

    public bool isInvisible = false;

    void Start()
    {
        SetUp();
        Debug.Log($"Player HP: {Health}/{maxHealth}");
    }

    public void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
    }

    public void Update()
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
        {
            _isAttacking = true;
        }
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

    public void AddItem(Items item)
    {
        inventory.Add(item);
    }

    public void Coin(int amount)
    {
        score += amount;
    }

    void HandleWeaponToggle()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (sword != null && shield != null)
            {
                bool isActive = !sword.activeSelf;
                sword.SetActive(isActive);
                shield.SetActive(isActive);

                if (isActive)
                {
                    Debug.Log("Draw Weapon");
                    Damage += 25;
                }
                else
                {
                    Debug.Log("Sheath Weapon");
                    Damage -= 25;
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
