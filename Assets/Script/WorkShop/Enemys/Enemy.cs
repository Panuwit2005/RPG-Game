using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    protected float distanceEnemyForAttack = 1.5f;
    protected float timeToAttack = 1;

    protected float timer = 0;

    public void FixedUpdate()
    {
        // ✅ เช็ค invisible
        if (Player == null || Player.isInvisible)
        {
            animator.SetBool("Attack", false);
            rb.linearVelocity = Vector3.zero;
            return;
        }

        Vector3 direction = Player.transform.position - transform.position;
        Turn(direction);

        timer -= Time.deltaTime;

        if (GetDistanPlayer() <= distanceEnemyForAttack)
        {
            Attack(Player);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    protected override void Turn(Vector3 direction)
    {
        Quaternion lockRotation = Quaternion.LookRotation(direction);
        transform.rotation = lockRotation;
    }

    public void Attack(Player _player)
    {
        if (timer <= 0)
        {
            if (_player != null && !_player.isInvisible) // ✅ กันโจมตีตอนล่องหน
            {
                _player.TakeDamage(Damage);
                animator.SetBool("Attack", true);
                Debug.Log($"{Name} attack {_player.Name} for {Damage} damage");
            }
            timer = timeToAttack;
        }
    }
}
