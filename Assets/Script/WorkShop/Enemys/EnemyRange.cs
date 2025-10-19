using UnityEngine;

public class EnemyRange : Enemy
{
    [SerializeField] private float distanceRange = 10f;

    public new void FixedUpdate()
    {
        // ✅ เช็ค invisible
        if (Player == null || Player.isInvisible)
        {
            animator.SetBool("Attack", false);
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 direction = Player.transform.position - transform.position;
        Turn(direction);

        if (GetDistanPlayer() > distanceRange)
        {
            Vector3 moveDir = direction.normalized;
            rb.MovePosition(rb.position + moveDir * movementSpeed * Time.fixedDeltaTime);
            animator.SetFloat("Speed", movementSpeed);
            animator.SetBool("Attack", false);
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetFloat("Speed", 0);
        }

        timer -= Time.deltaTime;

        if (GetDistanPlayer() <= distanceRange)
        {
            Attack(Player);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    public new void Attack(Player _player)
    {
        if (timer <= 0)
        {
            if (_player != null && !_player.isInvisible) // ✅ กันโจมตีตอนล่องหน
            {
                _player.TakeDamage(Damage);
                animator.SetBool("Attack", true);
                Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage");
            }
            timer = timeToAttack;
        }
    }
}
