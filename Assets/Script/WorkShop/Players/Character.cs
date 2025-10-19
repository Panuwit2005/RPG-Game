using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : Identity
{
    private int _health;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, maxHealth);
        }
    }
    public int maxHealth = 100;
    public int Damage = 10;
    public float movementSpeed = 5;

    protected Animator animator;
    protected Rigidbody rb;
    Quaternion newRotation;

    public override void SetUp()
    {
        base.SetUp();
        Health = maxHealth;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }


    public void TakeDamage(int amount)
    {
        Health -= amount;
        Debug.Log($"{Name} took {amount} damage. HP: {Health}/{maxHealth}");
        if (Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log($"{Name} died!");
        }
    }
    public void Heal(int amount)
    {
        Health += amount;
        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
        Debug.Log($"Player healed {amount}. HP: {Health}/{maxHealth}");
    }
    protected virtual void Turn(Vector3 direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 15f);

        if (rb.linearVelocity.magnitude < 0.1f || direction == Vector3.zero) return;
        newRotation = Quaternion.LookRotation(direction);
    }
    protected virtual void Move(Vector3 direction)
    {
        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);
    }
}