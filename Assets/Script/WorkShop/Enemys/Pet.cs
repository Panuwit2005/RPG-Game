using TMPro;

using UnityEngine;



public class Pet : Enemy

{

    public TMP_Text interactionTextUI;

    public bool Follow = true;

    public GameObject pet;

    public float stoppingDistance = 1f;

    public bool IsInteractable

    {

        get => Follow;

        set => Follow = value;

    }

    public void Interact(Player player)

    {

        Follow = !Follow;





        if (!Follow)

        {

            rb.velocity = Vector3.zero;

            animator.SetBool("Walk", false);

        }

    }
   protected override void Turn(Vector3 direction)

    {

        if (direction == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = lookRotation;

    }

    private void Update()

    {

        if (Player == null)

        {

            animator.SetBool("Walk", false);

            return;

        }

        float distance = GetDistanPlayer();



        if (Follow)

        {

            Turn(Player.transform.position - transform.position);



            if (distance > stoppingDistance)

            {

                Vector3 direction = (Player.transform.position - transform.position).normalized;

                Move(direction);

                animator.SetBool("Walk", true);

            }

            else

            {

                rb.velocity = Vector3.zero;

                animator.SetBool("Walk", false);

            }

        }

       if (GetDistanPlayer() >= 2 || Follow == false)
        {
            interactionTextUI.gameObject.SetActive(false);
        }
        else
        {
           interactionTextUI.gameObject.SetActive(true);
        }
    }
}