using System.Collections;
using TMPro;
using UnityEngine;

public class Door : Stuff, IInteractable
{
    private void Awake()
    {
        Name = "Door";
    }
    private bool isOpen = false;
    public Vector3 openOffset = new Vector3(0, 0, 2f);

    public float slideSpeed = 2f;
    public Transform door;

    [SerializeField]
    private float cooldownTime = 2f; // เวลา Cooldown หน่วยเป็นวินาที

    private bool isCooldown = false; // ตรวจว่ากำลังคูลดาวน์อยู่ไหม

    public bool isInteractable { get => canUse; set => canUse = value; }

    public void Interact(Player player)
    {
        if (isCooldown == true || isInteractable == false)
        {
            return;
        }

        StartCoroutine(StartCooldown());

        if (isOpen)
        {
            StartCoroutine(SlideDoor(door.position - openOffset));
        }
        else
        {
            StartCoroutine(SlideDoor(door.position + openOffset));
        }
        isOpen = !isOpen;
    }

    private IEnumerator SlideDoor(Vector3 targetPosition)
    {
        Vector3 startPosotion = door.position;
        float timeElapaed = 0;
        while (timeElapaed < 1)
        {
            timeElapaed += Time.deltaTime;
            door.position = Vector3.Lerp(startPosotion, targetPosition, timeElapaed);
            yield return null;
        }

        door.position = targetPosition;

    }

    private IEnumerator StartCooldown()
    {
        isCooldown = true;
        canUse = false;

        yield return new WaitForSeconds(cooldownTime);

        isCooldown = false;
        canUse = true;

    }

}
