using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody))]
public class Character : Identity
{
    private int _health;
    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, maxHealth);
    }

    public int maxHealth = 100;
    public int Damage = 10;
    public int Defense = 0;
    public float movementSpeed = 5f;

    protected Animator animator;
    protected Rigidbody rb;
    private Quaternion newRotation;

    protected virtual bool HasShield => false;

    public override void SetUp()
    {
        base.SetUp();
        Health = maxHealth;

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (animator == null)
            Debug.LogError("Animator component not found on " + gameObject.name);

        newRotation = transform.rotation;
    }

    public void TakeDamage(int amount)
    {
        // ✅ ใช้ hook แทนการอ้าง shield ตรง ๆ
        int dmg = HasShield ? Mathf.Max(amount - Defense, 0) : amount;

        if (dmg <= 0)
        {
            Debug.Log($"{Name} blocked the attack.");
            return;
        }

        Health -= dmg;
        Debug.Log($"{Name} took {dmg} damage. HP: {Health}/{maxHealth}");

        if (Health <= 0)
        {
            Die();
        }   
    }


    public void Heal(int amount)
    {
        Health += amount;
        if (Health > maxHealth) Health = maxHealth;
        Debug.Log($"{Name} healed {amount}. HP: {Health}/{maxHealth}");
    }

    protected virtual void Turn(Vector3 direction)
    {
        if (direction != Vector3.zero)
            newRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 15f);
    }

    protected virtual void Move(Vector3 direction)
    {
        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);

        if (animator != null)
        {
            float horizontalSpeed = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z).magnitude;
            animator.SetFloat("Speed", horizontalSpeed);
        }
    }

    private void Die()
    {
        Debug.Log($"{Name} died!");
        Destroy(gameObject);
    }
}
