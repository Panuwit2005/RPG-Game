using UnityEngine;

public class MoveAbleEnemy : Enemy
{
    [SerializeField] protected float moveableDistance = 3f;

    public new void FixedUpdate()
    {
        if (Player == null || Player.isInvisible)
        {
            animator.SetBool("Attack", false);
            rb.velocity = Vector3.zero;
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
            rb.velocity = Vector3.zero;
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

    protected override void Turn(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion lockRotation = Quaternion.LookRotation(direction);
            transform.rotation = lockRotation;
        }
    }

    public new void Attack(Player _player)
    {
        if (timer <= 0)
        {
            if (_player != null && !_player.isInvisible)
            {
                _player.TakeDamage(Damage);
                animator.SetBool("Attack", true);
                Debug.Log($"{Name} attacks {_player.Name} for {Damage} damage");
            }
            timer = timeToAttack;
        }
    }
}
